import json
from SpotConsultas import SpotConsultas as Consultas
from SpotOrdenes import SpotOrdenes as Ordenes

c = Consultas()
#operaciones = c.ObtenerOperaciones("ETHUSDT", 5)
# print(json.dumps(operaciones))

#cuenta = c.ObtenerCuentaGeneral()
# print(json.dumps(cuenta))

cantidad = c.ObtenerPosicion("ETH")
print(cantidad)

'''
balance = c.ObtenerBalance()
print(json.dumps(balance))
for item in balance:
    if item["asset"] == "USDT":
        print(item["balance"])
'''

o = Ordenes()
#o.ComprarMarket("ETHUSDT", 0.003)

# if cantidad > 0:
#o.CerrarCompraMarket("ETHUSDT", cantidad)
# if cantidad < 0:
#o.CerrarVentaMarket("ETHUSDT", -cantidad)


'''
from SpotBot import SpotBot
bot = SpotBot()
bot.Entrar("COMpra ethUSDTperp")
'''
