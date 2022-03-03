# https://binance.github.io/binance-api-swagger/
from SpotConsultas import SpotConsultas as Consultas
from SpotOrdenes import SpotOrdenes as Ordenes
from Binance import Binance
import json


class SpotBot(Binance):
    orden = ""
    ticker = ""

    def __init__(self):
        Binance.__init__(self)

    def ObtenerComando(self, texto: str) -> str:
        compra = ["comprar", "compra", "buy", "long"]
        venta = ["vender", "venta", "sell", "short"]
        if texto.lower() in compra:
            return "Comprar"
        if texto.lower() in venta:
            return "Vender"

    def ObtenerTicker(self, texto: str) -> str:
        ticker = texto.upper()
        if "PERP" in ticker:
            ticker = ticker.replace("PERP", "")
        if "USDT" not in ticker:
            ticker += "USDT"

    def Desglozar(self, mensaje: str):
        x = mensaje.slit()
        self.orden = self.ObtenerComando(x[0])
        self.ticker = self.ObtenerTicker(x[1])

    def ObtenerPosicion(self, ticker: str) -> float:
        c = Consultas()
        return c.ObtenerPosicion(ticker)  # XXXUSDT

    def ObtenerCantidad(self, ticker: str) -> float:
        f = open("Cantidades.json", "r")
        cantidades = json.load(f)
        f.close()
        if ticker in cantidades:
            return cantidades[ticker]
        return 0.0

    def Entrar(self, mensaje: str) -> bool:

        # desglozar mensaje
        self.Desglozar(mensaje)

        # obtener la posicion actual del ticker
        pos = self.ObtenerPosicion(self.ticker)

        # obtener la cantidad a operar segun el ticker
        cantidad = self.ObtenerCantidad(self.ticker)

        #print(self.orden + "->" + self.ticker + " " + str(cantidad) + "Pos actual:" + str(pos))

        o = Ordenes()
        if self.orden == "Comprar":
            '''
            if pos < 0:
                o.CerrarVentaMarket(self.ticker, abs(pos))
                self.Log("Cerrando short previo " +
                         self.ticker + " Cant:" + str(abs(pos)))
            '''
            maximo = cantidad * 10
            if pos + cantidad > maximo:
                return
            o.ComprarMarket(self.ticker, cantidad)
            self.Log(self.orden + ":" + self.ticker + " cant:" + str(cantidad))

        if self.orden == "Vender":
            if pos > 0:
                o.CerrarCompraMarket(self.ticker, pos)
                self.Log("Cerrando long previo " +
                         self.ticker + " Cant:" + str(pos))
            '''
            maximo = cantidad * 10
            if abs(pos) + cantidad > maximo:
                return
            o.VenderMarket(self.ticker, cantidad)
            self.Log(self.orden + ":" + self.ticker + " cant:" + str(cantidad))
            '''
