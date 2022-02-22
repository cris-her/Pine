# A very simple Flask Hello World app for you to get started with...

from FuturosBot import FuturosBot

from flask import request
from flask import Flask

app = Flask(__name__)

@app.route('/')
def hello_world():
  return 'Hola mundo!'

@app.route('/bot', methods=["POST"])
def bot():
  parametro = str(request.data, 'UTF-8').lower()
  bot = FuturosBot()
  bot.Entrar(parametro)
  # f = open("salida.txt", "a")
  # f.write(parametro + "\n")
  # f.close()
  return "OK"
