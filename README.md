System Bankowy

Projekt ten służy do, obsługi internetowego konta bankowego

Spis treści

•	Informacje o projekcie
•	Dane testowe
•	Testowanie aplikacji
•	Autor


Informacje o projekcie

Strona ma za zadanie umożliwiać tworzenie konta bankowego, robienie przelewów a także zakładanie karty do wybranego konta. Aby móc korzystać ze strony wymagane jest założenie konta, bez niego użytkownik może jedynie zobaczyć aktualne kursy walut.

Kiedy zaloguje się użytkownik

Po zalogowaniu opcje menu rozszerzają się o parę opcji 

•	odblokowana zostaje funkcja tworzenia konta;
•	możliwość robienia przelewów;
•	usuwanie konta;
•	szczegóły konta;
•	w szczegółach konta możliwe jest dodanie karty do konta;
•	Users - w tym miejscu administrator może zobaczyć wszystkich użytkowników strony oraz w razie problemów zwykłego użytkownika, czy chęć zmiany innych upoważnionych, edytować czy usunąć konto.

Dane testowe:

Aby zalogować się należy podać:

E-mail: Janek@op.pl 
Password: abc1234

Testowanie aplikacji

Aplikacja znajduje się na GitHubie. Należy pobrać ją jako plik .zip i otworzyć w odpowiednim środowisku. W tym przypadku jest to Visual Studio.
Aby ujrzeć stronę należy skompilować kod. Jeśli pojawią się problemy z danymi należy w konsoli:
•	sprawdzić migracje get-migration
•	jeśli ostatnia migracja jest false update-database
•	jeśli ostatnia migracja jest true add-migration przykładowa Nazwa, a następnie update-database

Adres do połączenia z bazą danych: 
"ConnectionStrings": {
    "BankDbContext": "Server=DESKTOP-UEJG1T3;Database=BankSys;Trusted_Connection=True;MultipleActiveResultSets=true;"
	 należy tu także zamienić nazwę serwera na taką jakiej się używa na swoim komputerze
Microsoft SQL Managment Studio

Autor

•	Andrzej Kołacz, numer indeksu: 13946

