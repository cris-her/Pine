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
dineroFinal = 0.0
q = 0

klines = client.get_historical_klines(
    symbolTicker, Client.KLINE_INTERVAL_1DAY, "1 Ene, 2021", "23 Feb, 2022")  # "1 year ago UTC"
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


def calculate_ema(candles, source):
    length = len(candles)
    target = candles[0]
    previous = candles[1]

    # if there is no previous EMA calculated, then EMA=SMA
    if 'ema10' not in previous or previous['ema10'] == None:
        return calculate_sma(candles, source)

    else:
        # multiplier: (2 / (length + 1))
        # EMA: (close - EMA(previous)) x multiplier + EMA(previous)
        multiplier = 2 / (length + 1)

        ema = (target[source] * multiplier) + \
            (previous['ema10'] * (1 - multiplier))
        # Formula updated from the original one to be clearer, both give the same results. Old formula:
        # ema = ((target[source] - previous['ema']) * multiplier) + previous['ema']

        return ema


def calculate_ema55(candles, source):
    length = len(candles)
    target = candles[0]
    previous = candles[1]

    # if there is no previous EMA calculated, then EMA=SMA
    if 'ema55' not in previous or previous['ema55'] == None:
        return calculate_sma(candles, source)

    else:
        # multiplier: (2 / (length + 1))
        # EMA: (close - EMA(previous)) x multiplier + EMA(previous)
        multiplier = 2 / (length + 1)

        ema = (target[source] * multiplier) + \
            (previous['ema55'] * (1 - multiplier))
        # Formula updated from the original one to be clearer, both give the same results. Old formula:
        # ema = ((target[source] - previous['ema']) * multiplier) + previous['ema']

        return ema


def calculate(candles, source):
    sma10 = calculate_sma(candles, source)
    ema10 = calculate_ema(candles, source)
    candles[0]['sma10'] = sma10
    candles[0]['ema10'] = ema10


def calculate55(candles, source):
    sma55 = calculate_sma(candles, source)
    ema55 = calculate_ema55(candles, source)
    candles[0]['sma55'] = sma55
    candles[0]['ema55'] = ema55


if __name__ == '__main__':
    read_candles()
    # print(candles)

    # progress through the array of candles to calculate the indicators for each
    # block of candles

    position = 0
    while position + EMA_LENGTH <= len(candles):
        current_candles = candles[position:(position+EMA_LENGTH)]
        current_candles = list(reversed(current_candles))
        calculate(current_candles, EMA_SOURCE)
        position += 1

    # print(candles)

    position55 = 0
    while position55 + 55 <= len(candles):
        current_candles55 = candles[position55:(position55+55)]
        current_candles55 = list(reversed(current_candles55))
        calculate55(current_candles55, EMA_SOURCE)
        position55 += 1

    # print(candles)

    for candle in candles:
        if 'ema55' in candle:
            print('{}: ema10={} ema55={}'.format(
                candle['ts'], candle['ema10'], candle['ema55']))
            break

    # STRATEGY
    for candle in candles:
        if 'ema55' in candle:
            if (candle['ema10'] > candle['ema55'] and 0 <= q < 1):
                # compra
                #print("compra  " + str(klines[i][4]))
                q = q + 1
                cantCompra = cantCompra + 1
                dineroFinal = dineroFinal - candle['ema10']*0.99  # *1.00075
                # time.sleep(1)

            if (candle['ema10'] < candle['ema55'] and 0 < q <= 1):
                # venta
                #print("venta  " + str(klines[i][4]))
                q = q - 1
                cantVenta = cantVenta + 1
                dineroFinal = dineroFinal + candle['ema10']*1.01  # *0.99925
                # time.sleep(1)

    print(dineroFinal)
    print(cantCompra)
    print(cantVenta)
