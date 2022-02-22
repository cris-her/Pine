from FuturosBot import FuturosBot

bot = FuturosBot()
bot.Entrar("comprar eth")

'''
import json
from FuturosOrdenes import FuturosOrdenes as Ordenes
from FuturosConsultas import FuturosConsultas as Consultas

c = Consultas()
cantidad = c.ObtenerPosicion("ETHUSDT")

o = Ordenes()
if cantidad > 0:
    o.CerrarCompraMarket("ETHUSDT", cantidad)

if cantidad < 0:
    o.CerrarVentaMarket("ETHUSDT", -cantidad)
'''
'''
#operaciones = c.ObtenerOperaciones("ETHUSDT", 5)
balance = c.ObtenerBalance()

for item in balance:
    if item["asset"] == "USDT":
        print(item["balance"])

#print(json.dump(balance))
'''
#o.ComprarMarket("ETHUSDT", 0.003)