CREATE DATABASE Biblioteka;
USE Biblioteka;

CREATE TABLE Ksiazki (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tytul VARCHAR(64) NOT NULL,
    autor VARCHAR(64) NOT NULL,
    rok_wydania YEAR NOT NULL,
    dostepna BOOLEAN DEFAULT TRUE
);

INSERT INTO Ksiazki (tytul, autor, rok_wydania) VALUES
('Pan Tadeusz', 'Adam Mickiewicz', 1834),
('Lalka', 'Bolesław Prus', 1890),
('Krzyżacy', 'Henryk Sienkiewicz', 1900),
('W pustyni i w puszczy', 'Henryk Sienkiewicz', 1911),
('Ferdydurke', 'Witold Gombrowicz', 1937),
('Dziady', 'Adam Mickiewicz', 1823),
('Quo Vadis', 'Henryk Sienkiewicz', 1896),
('Zbrodnia i kara', 'Fiodor Dostojewski', 1866),
('Mistrz i Małgorzata', 'Michaił Bułhakow', 1967),
('Mały Książę', 'Antoine de Saint-Exupéry', 1943),
('Rok 1984', 'George Orwell', 1949),
('Hobbit', 'J.R.R. Tolkien', 1937),
('Harry Potter i Kamień Filozoficzny', 'J.K. Rowling', 1997),
('Opowieści z Narnii', 'C.S. Lewis', 1950),
('Bajki robotów', 'Stanisław Lem', 1964);

CREATE TABLE Uzytkownicy (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nazwa_uzytkownika VARCHAR(128) UNIQUE NOT NULL,
    haslo VARCHAR(128) NOT NULL,
    rola ENUM('administrator', 'uzytkownik') NOT NULL
);

INSERT INTO Uzytkownicy (nazwa_uzytkownika, haslo, rola) VALUES
('admin', 'admin', 'administrator');

CREATE TABLE Wypozyczenia (
    id INT AUTO_INCREMENT PRIMARY KEY,
    id_uzytkownika INT NOT NULL,
    id_ksiazki INT NOT NULL,
    data_wypozyczenia DATE NOT NULL,
    data_zwrotu DATE,
    FOREIGN KEY (id_uzytkownika) REFERENCES Uzytkownicy(id),
    FOREIGN KEY (id_ksiazki) REFERENCES Ksiazki(id)
);

-- Procedura do wypożyczania książki

CREATE PROCEDURE WypozyczKsiazke (
    IN p_id_uzytkownika INT,
    IN p_id_ksiazki INT
)
BEGIN
    START TRANSACTION;
    IF (SELECT dostepna FROM Ksiazki WHERE id = p_id_ksiazki) = TRUE THEN
        INSERT INTO Wypozyczenia (id_uzytkownika, id_ksiazki, data_wypozyczenia) 
        VALUES (p_id_uzytkownika, p_id_ksiazki, CURDATE());
        UPDATE Ksiazki SET dostepna = FALSE WHERE id = p_id_ksiazki;
        COMMIT;
    ELSE
        ROLLBACK;
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Ksiazka jest juz wypozyczona';
    END IF;
END 
;

-- Procedura do zwracania książki

CREATE PROCEDURE ZwrocKsiazke (
    IN p_id_ksiazki INT
)
BEGIN
    START TRANSACTION;
    UPDATE Wypozyczenia SET data_zwrotu = CURDATE() 
    WHERE id_ksiazki = p_id_ksiazki AND data_zwrotu IS NULL;
    UPDATE Ksiazki SET dostepna = TRUE WHERE id = p_id_ksiazki;
    COMMIT;
END 
;

-- Przykładowe dodanie użytkownika
INSERT INTO Uzytkownicy (nazwa_uzytkownika, haslo, rola) VALUES
('uczen1', 'uczen1', 'uzytkownik');

-- Przykład użycia procedur
-- CALL WypozyczKsiazke(2, 1); -- Uczeń 2 wypożycza książkę o id 1
-- CALL ZwrocKsiazke(1);       -- Zwrot książki o id 1

CREATE PROCEDURE DodajUzytkownika (
    IN p_nazwa_uzytkownika VARCHAR(128),
    IN p_haslo VARCHAR(128),
    IN p_rola ENUM('administrator', 'uzytkownik')
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
        BEGIN
            -- W przypadku błędu, wykonaj rollback
            ROLLBACK;
        END;

    START TRANSACTION;

    -- Sprawdź, czy użytkownik o podanej nazwie już istnieje
(SELECT COUNT(*) FROM Uzytkownicy WHERE nazwa_uzytkownika = p_nazwa_uzytkownika);
    END