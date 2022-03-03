import requests
from Binance import Binance


class SpotConsultas(Binance):
    def __init__(self):
        Binance.__init__(self)

    def ObtenerOperaciones(self, simbolo: str, limite: int = 500):
        endPoint = self.url + "/api/v3/trades"
        parametro = "symbol=" + simbolo.upper()
        if limite != 500 and limite <= 1000 and limite > 0:
            parametro += "&limit=" + str(limite)
        r = requests.get(endPoint, parametro)
        return r.json()

    '''
    def ObtenerBalance(self):
        endPoint = self.url + "/api/v3/balance"
        parametros = "timestamp=" + str(self.ObtenerFechaServer())
        parametros = self.Firmar(parametros)
        h = self.Encabezados(self.apiKey)
        r = requests.get(endPoint, params=parametros, headers=h)
        return r.json()'''

    def ObtenerCuentaGeneral(self) -> dict:
        endPoint = self.url + "/api/v3/account"
        parametros = "timestamp=" + str(self.ObtenerFechaServer())
        parametros = self.Firmar(parametros)
        h = self.Encabezados(self.apiKey)
        r = requests.get(endPoint, params=parametros, headers=h)
        return r.json()

    def ObtenerPosiciones(self) -> dict:
        ac = self.ObtenerCuentaGeneral()
        if "balances" in ac.keys():
            return ac["balances"]
        return None

    def ObtenerPosicion(self, simbolo: str) -> dict:
        pos = self.ObtenerPosiciones()
        ticker = simbolo.upper()
        for item in pos:
            if item["asset"] in ticker:
                return float(item["free"])
        return 0.0

    def Obtener1000Klines(self, simbolo, intervalo, desde, hasta):
        endPoint = "https://api.binance.com/api/v3/klines"
        ticker = simbolo.upper()
        parametros = "symbol=" + ticker
        parametros += "&interval=" + intervalo
        parametros += "&startTime=" + str(int(desde))
        parametros += "&endTime=" + str(int(hasta))
        parametros += "&limit=1000"
        r = requests.get(endPoint, params=parametros)
        return r.json()
