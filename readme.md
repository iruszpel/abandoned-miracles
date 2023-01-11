# Projekt realizowany w ramach przedmiotu "Azure and AI" na studiach inżynierskich na politechnice Warszawskiej. 

## Cel projektu
Celem projektu jest stworznie aplikacji ułatwiającej znalezienie poszukiwanych zwierząt. Aplikacja pozwala na zgłaszanie zwierząt błąkających się po ulicach. Zgłoszenia są przyjmowane przez apliacje mobilną, natomiast mogą być przeglądene przez aplikacje internetową. W ramach zgłoszenia aplikacja rozpoznaje gatunek zwierzęcia(poprzez AI), przyjmuje krótki opis o zwierzęciu, miejsce oraz czas gdzie było widziane zwierze oraz wykonane zdjęcie zwierzęcia.

## Opis funkcjonalności
Użytkownik poprzez aplikacje mobliną wysyła zgłoszenie w którego skad wchodzi: zdjęcie wykonane aparatem, opis, adres gdzie było widziane zwierze, i współrzedne geograficzne, które są automatycznie ustalane na podstawie adresu. Wszytkie zgłosznia można przejrzeć poprzez aplikację internetową po zalogowaniu. W aplikacji internetowej można sprawdzić swoje zgłoszenia wraz z ich statusem oraz zgłoszenia od innych osób. Aktualnie akceptowalne rodzaje zwierząt to kot, pies i szop pracz, ale naszą aplikację można w prosty sposób rozszerzyć o więcej gatunków.

## Prezentacja działania aplikacji
[Prezentacja](https://youtu.be/vZZ12LQf1Q8)

## Demo aplikacji
[Demo](https://happy-moss-01101c303.2.azurestaticapps.net/zgloszenia)

## Wykorzystane serwisy
- Key vault - przechowywanie sekretów na backendzie
- Storage Account - przechowywanie zdjęć w containers na backendzie oraz przechowywanie bundla dla static web apps na frontendzie
- Azure SQL - baza danych z której korzysta backend
- Azure ML - model do rozpoznawania gatunku zwierzęcia
- Azure Functions - Proxy pomiędzy backendem a Azure ML w celu zmniejszenia obciążenia backendu
- Azure Maps -Wyświetlanie mapy na frontendzie oraz usługi lokalizacyjne w aplikacji mobilnej
- App Insights - monitorowanie aplikacji frontendowej i mobilnej

## Diagram rozwiązania
![alt text](https://abandonedmiracle.blob.core.windows.net/misc/azure.drawio.png)

## Diagram bazy danych
![alt text](https://abandonedmiracle.blob.core.windows.net/misc/database.png)

## Stos technologiczny
- Funkcja w typescript
- Backend w Asp.Net Core
- Frontend w React
- Aplikacja mobilna w Flutter

## Autorzy
[Ignacy Ruszpel](https://github.com/iruszpel)\
[Łukasz Sobczak](https://github.com/sobczal2)\
[Nikodem Wójcik](https://github.com/01NikodemW)\
[Piotr Klepacki](https://github.com/Klepackp)\
[Robert Odrowaz](https://github.com/RobertOdrowaz)\
[Agnieszka Stefankowska](https://github.com/NeferHikari)
