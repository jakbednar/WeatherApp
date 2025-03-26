# 🌦️ Konzolová aplikace Počasí

Jednoduchá konzolová aplikace v jazyce **C#**, která umožňuje uživateli zadat název města a zobrazit aktuální meteorologické informace. Aplikace využívá online službu [WeatherAPI](https://www.weatherapi.com/) pro získání dat.

## 🔧 Funkce aplikace

- 📍 Načtení názvu města od uživatele  
- 🌐 Volání API a zpracování odpovědi ve formátu JSON  
- 📊 Zobrazení těchto údajů:
  - Název města, region a stát
  - Čas poslední aktualizace počasí
  - Aktuální teplota a pocitová teplota
  - Stav počasí (např. jasno, oblačno, déšť…)
  - Rychlost větru (v km/h)
  - UV index

## ▶️ Ukázka použití
```shell
Zadej název města: Brno

Brno, South Moravian, Czech Republic
Čas: 26.03.2025 - 14:35
Teplota: 12.3°C
Pocitová teplota: 10.7°C
Vítr: 13 km/h
Počasí: Zataženo
UV index: 3
