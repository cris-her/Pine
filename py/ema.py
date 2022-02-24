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

longitud_mm_v = 4  # 4  # 10
longitud_mm_r = 38  # 38  # 55
sl = 0.0
tp = 0.0
comprado = False
en_pausa = 0  # := max(en_pausa - 1, 0)

stop_loss = 0.2  # 0.2  # 1000  # 0.2  # Porcentaje de stop loss
take_profit = 29.6  # 29.6  # 1000  # 29.6  # Porcentaje Take profit
esperar = 4  # Velas a esperar

# alcista = (line1 > line2)// and close > line2 and angulo(line1) > a//(ema(close, 10) > ema(close, 55))
# bajista =  (line1 < line2) //  angulo(line1) < a  // close < line2  // not alcista //
#comprado = strategy.position_size > 0

desde_datos = datetime.strptime(
    '1.1.2019 00:00:00', '%d.%m.%Y %H:%M:%S').timestamp() * 1000
hasta_datos = datetime.now().timestamp() * 1000
desde_estrategia = datetime.strptime(
    '1.12.2020 00:00:00', '%d.%m.%Y %H:%M:%S').timestamp() * 1000
hasta_estrategia = datetime.strptime(
    '23.12.2021 00:00:00', '%d.%m.%Y %H:%M:%S').timestamp() * 1000

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


def calculate_ema(candles, source, emaC):
    target = candles[0]
    previous = candles[1]

    if emaC not in previous or previous[emaC] == None:
        return calculate_sma(candles, source)
    else:
        multiplier = 2 / (len(candles) + 1)
        ema = (target[source] * multiplier) + \
            (previous[emaC] * (1 - multiplier))
        # Formula updated from the original one to be clearer, both give the same results. Old formula:
        # ema = ((target[source] - previous['ema']) * multiplier) + previous['ema']
        return ema


def calculate(source, length, smaC, emaC, candles):
    position = 0
    while position + length <= len(candles):
        current_candles = candles[position:(position+length)]
        current_candles = list(reversed(current_candles))
        #calculate(current_candles, EMA_SOURCE)
        sma = calculate_sma(current_candles, source)
        ema = calculate_ema(current_candles, source, emaC)
        current_candles[0][smaC] = sma
        current_candles[0][emaC] = ema
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
    calculate('close', longitud_mm_v, 'smaV', 'emaV', candles1D)
    calculate('close', longitud_mm_r, 'smaR', 'emaR', candles1D)
    calculate('close', longitud_mm_v, 'smaV', 'emaV', candles4H)
    calculate('close', longitud_mm_r, 'smaR', 'emaR', candles4H)

    main_candles = candles4H
    for candle in main_candles:
        if 'emaR' in candle:
            print('{}: emaV={} emaR={}'.format(
                candle['ts'], candle['emaV'], candle['emaR']))
            break

    # STRATEGY
    for candle in main_candles:
        if 'emaR' in candle:
            if en_pausa > 0:
                en_pausa -= 1
            #:= max(en_pausa - 1, 0)
            if (not comprado) and (candle['emaV'] > candle['emaR'] and fecha_valida(candle) and en_pausa == 0):
                # compra
                comprado = True  # q = q + 1
                compras.append(candle)
                dineroBTC = dineroUSD / candle['close']
                dineroUSD = 0.0
                # dineroFinal = dineroFinal - candle['ema10']*0.99  # *1.00075
                # time.sleep(1)
                sl = candle['close'] * (1 - stop_loss/100)
                tp = candle['close'] * (1 + take_profit/100)
                print(
                    f"{len(compras)} BUY: {compras[len(compras)-1]['ts']}, CLOSE: {compras[len(compras)-1]['close']}, BTC:{dineroBTC}")
                continue

            if comprado:
                if candle['close'] <= sl:
                    # salir sl
                    # strategy.close("Compra", comment="SL")
                    #q = q - 1
                    comprado = False
                    ventas.append(candle)
                    dineroUSD = dineroBTC * candle['close']
                    dineroBTC = 0.0
                    en_pausa = esperar
                    print(
                        f"{len(compras)} SL: {ventas[len(compras)-1]['ts']}, CLOSE: {ventas[len(compras)-1]['close']}, USD:{dineroUSD}")
                    continue

                if candle['close'] >= tp:
                    # salir tp
                    # strategy.close("Compra", comment="TP")
                    #q = q - 1
                    comprado = False
                    ventas.append(candle)
                    dineroUSD = dineroBTC * candle['close']
                    dineroBTC = 0.0
                    print(
                        f"{len(compras)} TP: {ventas[len(compras)-1]['ts']}, CLOSE: {ventas[len(compras)-1]['close']}, USD:{dineroUSD}")
                    continue

                if (candle['emaV'] < candle['emaR']):
                    # realizar venta x cruce
                    #q = q - 1
                    comprado = False
                    ventas.append(candle)
                    dineroUSD = dineroBTC * candle['close']
                    dineroBTC = 0.0
                    # dineroFinal = dineroFinal + candle['ema10']*1.01  # *0.99925
                    # time.sleep(1)
                    print(
                        f"{len(compras)} SELL: {ventas[len(compras)-1]['ts']}, CLOSE: {ventas[len(compras)-1]['close']}, USD:{dineroUSD}")
                    continue

                if not fecha_valida(candle):
                    # realizar venta x finalizacion periodo
                    # strategy.close("Compra", comment="Venta x fin")
                    #q = q - 1
                    comprado = False
                    ventas.append(candle)
                    dineroUSD = dineroBTC * candle['close']
                    dineroBTC = 0.0
                    print(
                        f"{len(compras)} FIN: {ventas[len(compras)-1]['ts']}, CLOSE: {ventas[len(compras)-1]['close']}, USD:{dineroUSD}")
                    break

    print('--------------------')
    print(f"BTC: {dineroBTC}")
    print(f"USD: {dineroUSD}")
    print(f"Net profit: {dineroUSD - 100000.0}")
    print(f"%: {((dineroUSD - 100000.0) * 100.0) / 100000.0}")
    print(f"Open trades: {len(compras)}")
    print(f"Closed trades: {len(ventas)}")
    print('--------------------')
