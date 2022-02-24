from functools import reduce
import config
from binance.client import Client
from binance.enums import *
from datetime import datetime


EMA_LENGTH = 10
EMA_SOURCE = 'close'

candles = []

client = Client(config.API_KEY, config.API_SECRET, tld='com')
symbolTicker = 'BTCUSDT'

cantCompra = 0
cantVenta = 0
dineroBTC = 0.0
dineroUSD = 100000.0
q = 0

dt_obj = datetime.strptime('1.1.2019 00:00:00', '%d.%m.%Y %H:%M:%S')
millisec = dt_obj.timestamp() * 1000

dt_obj2 = datetime.strptime('24.2.2022 00:00:00', '%d.%m.%Y %H:%M:%S')
millisec2 = dt_obj2.timestamp() * 1000

klines = client.get_historical_klines(
    symbolTicker, Client.KLINE_INTERVAL_1DAY, str(millisec), str(millisec2))  # "1 year ago UTC"
# Client.KLINE_INTERVAL_4HOUR, "15 Feb, 2021", "23 Feb, 2022"
# Client.KLINE_INTERVAL_1DAY, "1 Ene, 2021", "23 Feb, 2022"


def read_candles():
    print(len(klines))

    for i in range(len(klines)):
        candles.append({
            'ts': datetime.fromtimestamp(klines[i][0]/1000),
            'open': float(klines[i][1]),
            'high': float(klines[i][2]),
            'low': float(klines[i][3]),
            'close': float(klines[i][4])
        })

# Calculates the SMA of an array of candles using the `source` price.


def calculate_sma(candles, source):
    length = len(candles)
    sum = reduce((lambda last, x: {source: last[source] + x[source]}), candles)
    sma = sum[source] / length
    return sma

# Calculates the EMA of an array of candles using the `source` price.


def calculate_ema(candles, source, emaN):
    length = len(candles)
    target = candles[0]
    previous = candles[1]

    # if there is no previous EMA calculated, then EMA=SMA
    if emaN not in previous or previous[emaN] == None:
        return calculate_sma(candles, source)

    else:
        # multiplier: (2 / (length + 1))
        # EMA: (close - EMA(previous)) x multiplier + EMA(previous)
        multiplier = 2 / (length + 1)

        ema = (target[source] * multiplier) + \
            (previous[emaN] * (1 - multiplier))
        # Formula updated from the original one to be clearer, both give the same results. Old formula:
        # ema = ((target[source] - previous['ema']) * multiplier) + previous['ema']

        return ema


def calculate(source, length, smaN, emaN):
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


if __name__ == '__main__':
    read_candles()
    # print(candles)

    # progress through the array of candles to calculate the indicators for each
    # block of candles
    calculate(EMA_SOURCE, 10, 'sma10', 'ema10')
    calculate(EMA_SOURCE, 55, 'sma55', 'ema55')

    for candle in candles:
        if 'ema55' in candle:
            print('{}: ema10={} ema55={}'.format(
                candle['ts'], candle['ema10'], candle['ema55']))
            break

    dt_obj3 = datetime.strptime('23.2.2020 00:00:00', '%d.%m.%Y %H:%M:%S')
    millisec3 = dt_obj3.timestamp() * 1000

    # STRATEGY
    for candle in candles:
        if 'ema55' in candle:
            if (candle['ema10'] > candle['ema55'] and 0 <= q < 1 and candle['ts'].timestamp() * 1000 >= millisec3):
                # compra
                # print("compra  " + str(klines[i][4]))
                q = q + 1
                cantCompra = cantCompra + 1
                dineroBTC = dineroUSD / candle['close']
                dineroUSD = 0.0

                print(candle['ts'].strftime("%Y-%m-%d %H:%M:%S"))
                print(candle['ts'].timestamp() * 1000)
                print(millisec3)
                # dineroFinal = dineroFinal - candle['ema10']*0.99  # *1.00075
                # time.sleep(1)

            if (candle['ema10'] < candle['ema55'] and 0 < q <= 1):
                # venta
                # print("venta  " + str(klines[i][4]))
                q = q - 1
                cantVenta = cantVenta + 1
                dineroUSD = dineroBTC * candle['close']
                dineroBTC = 0.0
                # dineroFinal = dineroFinal + candle['ema10']*1.01  # *0.99925
                # time.sleep(1)

    print(f"dineroBTC: {dineroBTC}")
    print(f"dineroUSD: {dineroUSD}")
    print(f"ganancia: {dineroUSD - 100000.0}")
    print(f"porcentaje: {((dineroUSD - 100000.0) * 100.0) / 100000.0}")
    print(cantCompra)
    print(cantVenta)
