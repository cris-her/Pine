from functools import reduce
import config
from binance.client import Client
from binance.enums import *
from datetime import datetime

client = Client(config.API_KEY, config.API_SECRET, tld='com')
symbolTicker = 'BTCUSDT'
candles1D = []
candles4H = []

compras = []
ventas = []
dineroBTC = 0.0
dineroUSD = 100000.0
q = 0

sl = 0.0
tp = 0.0
en_pausa = 0

stop_loss = 1000  # 0.2  # Porcentaje de stop loss
take_profit = 1000  # 29.6  # Porcentaje Take profit
esperar = 4  # Velas a esperar

# alcista = (line1 > line2)// and close > line2 and angulo(line1) > a//(ema(close, 10) > ema(close, 55))
# bajista =  (line1 < line2) //  angulo(line1) < a  // close < line2  // not alcista //
#comprado = strategy.position_size > 0
en_pausa = esperar  # := max(en_pausa - 1, 0)

desde_datos = datetime.strptime(
    '1.1.2019 00:00:00', '%d.%m.%Y %H:%M:%S').timestamp() * 1000
hasta_datos = datetime.now().timestamp() * 1000
desde_estrategia = datetime.strptime(
    '23.2.2020 00:00:00', '%d.%m.%Y %H:%M:%S').timestamp() * 1000
hasta_estrategia = datetime.strptime(
    '23.2.2022 00:00:00', '%d.%m.%Y %H:%M:%S').timestamp() * 1000

klines1D = client.get_historical_klines(
    symbolTicker, Client.KLINE_INTERVAL_1DAY, str(desde_datos), str(hasta_datos))  # "1 year ago UTC"
klines4H = client.get_historical_klines(
    symbolTicker, Client.KLINE_INTERVAL_4HOUR, str(desde_datos), str(hasta_datos))
# Client.KLINE_INTERVAL_4HOUR, "15 Feb, 2021", "23 Feb, 2022"
# Client.KLINE_INTERVAL_1DAY, "1 Ene, 2021", "23 Feb, 2022"


def read_candles(klines, candles):
    for i in range(len(klines)):
        candles.append({
            'ts': datetime.fromtimestamp(klines[i][0]/1000),
            'open': float(klines[i][1]),
            'high': float(klines[i][2]),
            'low': float(klines[i][3]),
            'close': float(klines[i][4])
        })


def calculate_sma(candles, source):
    sum = reduce((lambda last, x: {source: last[source] + x[source]}), candles)
    sma = sum[source] / len(candles)
    return sma


def calculate_ema(candles, source, emaN):
    target = candles[0]
    previous = candles[1]

    if emaN not in previous or previous[emaN] == None:
        return calculate_sma(candles, source)
    else:
        multiplier = 2 / (len(candles) + 1)
        ema = (target[source] * multiplier) + \
            (previous[emaN] * (1 - multiplier))
        # Formula updated from the original one to be clearer, both give the same results. Old formula:
        # ema = ((target[source] - previous['ema']) * multiplier) + previous['ema']
        return ema


def calculate(source, length, smaN, emaN, candles):
    position = 0
    while position + length <= len(candles):
        current_candles = candles[position:(position+length)]
        current_candles = list(reversed(current_candles))
        #calculate(current_candles, EMA_SOURCE)
        sma = calculate_sma(current_candles, source)
        ema = calculate_ema(current_candles, source, emaN)
        current_candles[0][smaN] = sma
        current_candles[0][emaN] = ema
        position += 1


def fecha_valida(candle):
    return candle['ts'].timestamp() * \
        1000 >= desde_estrategia and candle['ts'].timestamp(
    ) * 1000 <= hasta_estrategia


if __name__ == '__main__':
    print('--------------------')
    read_candles(klines1D, candles1D)
    read_candles(klines4H, candles4H)
    print(
        f'1D Candles: {len(klines1D)}, 4H Candles: {len(klines4H)}')
    print('--------------------')

    # progress through the array of candles to calculate the indicators for each
    # block of candles
    calculate('close', 10, 'sma10', 'ema10', candles1D)
    calculate('close', 55, 'sma55', 'ema55', candles1D)

    main_candles = candles1D
    for candle in main_candles:
        if 'ema55' in candle:
            print('{}: ema10={} ema55={}'.format(
                candle['ts'], candle['ema10'], candle['ema55']))
            break

    # STRATEGY
    for candle in main_candles:
        if 'ema55' in candle:
            if en_pausa > 0:
                en_pausa = en_pausa - 1
            #:= max(en_pausa - 1, 0)
            if (candle['ema10'] > candle['ema55'] and 0 <= q < 1 and fecha_valida(candle) and en_pausa == 0):
                # compra
                q = q + 1
                compras.append(candle)
                dineroBTC = dineroUSD / candle['close']
                dineroUSD = 0.0
                # dineroFinal = dineroFinal - candle['ema10']*0.99  # *1.00075
                # time.sleep(1)
                sl = candle['close'] * (1 - stop_loss/100)
                tp = candle['close'] * (1 + take_profit/100)

            if 0 < q <= 1:
                if candle['close'] <= sl:
                    # salir sl
                    # strategy.close("Compra", comment="SL")
                    q = q - 1
                    ventas.append(candle)
                    dineroUSD = dineroBTC * candle['close']
                    dineroBTC = 0.0
                    en_pausa = esperar

                if candle['close'] >= tp:
                    # salir tp
                    # strategy.close("Compra", comment="TP")
                    q = q - 1
                    ventas.append(candle)
                    dineroUSD = dineroBTC * candle['close']
                    dineroBTC = 0.0

                if (candle['ema10'] < candle['ema55']):
                    # realizar venta x cruce
                    q = q - 1
                    ventas.append(candle)
                    dineroUSD = dineroBTC * candle['close']
                    dineroBTC = 0.0
                    # dineroFinal = dineroFinal + candle['ema10']*1.01  # *0.99925
                    # time.sleep(1)

                if not fecha_valida(candle):
                    # realizar venta x finalizacion periodo
                    # strategy.close("Compra", comment="Venta x fin")
                    q = q - 1
                    ventas.append(candle)
                    dineroUSD = dineroBTC * candle['close']
                    dineroBTC = 0.0

    for o in range(len(compras)):
        print(f"{o + 1} BUY: {compras[o]['ts']} - {compras[o]['close']}")
        if o < len(ventas):
            print(f"{o + 1} SELL: {ventas[o]['ts']} - {ventas[o]['close']}")
    print('--------------------')
    print(f"BTC: {dineroBTC}")
    print(f"USD: {dineroUSD}")
    print(f"Net profit: {dineroUSD - 100000.0}")
    print(f"%: {((dineroUSD - 100000.0) * 100.0) / 100000.0}")
    print(f"Open trades: {len(compras)}")
    print(f"Closed trades: {len(ventas)}")
    print('--------------------')
