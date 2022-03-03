import Configuration
import requests
import json
import hmac
import hashlib
from datetime import datetime

class Binance:
    apiKey = ""
    secretKey = ""
    url = ""
    def _init_(self):
        self.apiKey = Configuration.API_KEY
        self.secretKey = Configuration.SECRET_KEY
        self.url = "https://fapi.binance.com"

    def ObtenerFechaServer(self) -> int:
        endPoint = self.url + "/fapi/v1/time"
        r = requests.get(endPoint)
        resp = r.json()
        return resp["serverTime"]

    def Firmar(self, parametros:str) -> str:
        m = hmac.new(self.secretKey.encode('utf-8'), parametros.encode('utf-8'), hashlib.sha256)
        return parametros + "&signature=" + m.hexdigest()

    def Encabezados(self, apiKey="") -> dict:
        headers = {
            'Accept': 'application/json',
            'User-Agent': 'Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36'
        }
        if apiKey != "":
            headers["X-MBX-APIKEY"] = apiKey
        return headers
    
    def Log(self, texto:str):
        f = open("ordenes.log", "a")
        f.write(datetime.now().strftime("%H:%m:%d %H:%M:%S") + " -> " + texto + "\n")
        f.close()