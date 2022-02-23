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
    symbolTicker, Client.KLINE_INTERVAL_1DAY, "1 year ago UTC")


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
    if 'ema' not in previous or previous['ema'] == None:
        return calculate_sma(candles, source)

    else:
        # multiplier: (2 / (length + 1))
        # EMA: (close - EMA(previous)) x multiplier + EMA(previous)
        multiplier = 2 / (length + 1)

        ema = (target[source] * multiplier) + \
            (previous['ema'] * (1 - multiplier))
        # Formula updated from the original one to be clearer, both give the same results. Old formula:
        # ema = ((target[source] - previous['ema']) * multiplier) + previous['ema']

        return ema


def calculate(candles, source):
    sma = calculate_sma(candles, source)
    ema = calculate_ema(candles, source)
    candles[0]['sma'] = sma
    candles[0]['ema'] = ema


if __name__ == '__main__':
    read_candles()

    # progress through the array of candles to calculate the indicators for each
    # block of candles
    position = 0
    while position + EMA_LENGTH <= len(candles):
        current_candles = candles[position:(position+EMA_LENGTH)]
        current_candles = list(reversed(current_candles))
        calculate(current_candles, EMA_SOURCE)
        position += 1

    for candle in candles:
        if 'sma' in candle:
            print('{}: sma={} ema={}'.format(
                candle['ts'], candle['sma'], candle['ema']))

    # STRATEGY
    for candle in candles:
        if 'sma' in candle:
            if (candle['ema'] < candle['close'] and 0 <= q < 1):
                # compra
                #print("compra  " + str(klines[i][4]))
                q = q + 1
                cantCompra = cantCompra + 1
                dineroFinal = dineroFinal - candle['ema']*0.99  # *1.00075
                # time.sleep(1)

            if (candle['ema'] > candle['close'] and 0 < q <= 1):
                # venta
                #print("venta  " + str(klines[i][4]))
                q = q - 1
                cantVenta = cantVenta + 1
                dineroFinal = dineroFinal + candle['ema']*1.01  # *0.99925
                # time.sleep(1)

    print(dineroFinal)
    print(cantCompra)
    print(cantVenta)
