# RUZWatcher
Aplikácia RUZWatcher slúži ako vypracovanie zadania pre prácu s RUZ API (Register účtovných závierok API).<br />
Webová aplikácia je postavená na .NET 8, technológii Blazor s Radzen komponentmi a obsahuje lokálnu databázu.

Aplikácia je spustiteľná pomocou voľne dostupného vývojového prostredia Microsoft Visual Studio Community 2022.

**Postup spustenia:**
1. Stiahneme zdrojový kód z Githubu
2. Projekt otvoríme vo Visual Studio 2022 pomocou súboru RUZWatcher.sln
3. Spustíme aplikáciu zeleným tlačidlom s ikonou Play a textom https alebo zvolíme možnosť Debug -> Start (Without) Debugging

(Poznámka: Databáza je súčasťou projektu s connection stringom "DefaultLocalConnection": "Data Source=ruzwatcher.db" takže nie je potrebná jej inicializácia pomocou inicializačných migračných skriptov)

**Architektúra a rozhodnutia**<br />
Na základe skúsenosti z dlhoročného vývoja interného nástroja Testovačka v O2 Slovakia boli zvolené podobné technológie - .NET webová aplikácia na technológii Blazor s Radzen komponentmi (https://blazor.radzen.com/?theme=material3).<br />
Na získavanie údajov je použité podľa zadania RUZ API - https://www.registeruz.sk/cruz-public/home/api<br />
Na ukladanie údajov (konkrétne zoznamu sledovaných subjektov) bola vytvorená pomocou Entity Framework Core lokálna databáza (ruzwatcher.db a príslušné súbory).

Pre prístup k API alebo k databáze používajú jednotlivé razor komponenty (resp. stránky) nainjectované servisy, napríklad pre prístup k API (RUZHttpClient.cs) alebo DB (DBServis.cs).
Ako bonus je pridaný servis pre ukladanie do súboru excel. (ExcelExportService.cs)
