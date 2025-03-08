-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 08, 2025 at 02:53 PM
-- Wersja serwera: 10.4.32-MariaDB
-- Wersja PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `wirtualna_uczelnia`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `logowanie`
--

CREATE TABLE `logowanie` (
  `userID` int(11) NOT NULL,
  `email` varchar(255) NOT NULL,
  `haslo` varchar(255) NOT NULL,
  `isTeacher` tinyint(1) NOT NULL,
  `isAdmin` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Dumping data for table `logowanie`
--

INSERT INTO `logowanie` (`userID`, `email`, `haslo`, `isTeacher`, `isAdmin`) VALUES
(1, 'student1@uczelnia.pl', 'haslo123', 0, 0),
(2, 'student2@uczelnia.pl', 'haslo123', 0, 0),
(3, 'nauczyciel1@uczelnia.pl', 'tajnehaslo', 1, 0),
(4, 'admin@uczelnia.pl', 'admin123', 1, 1),
(5, 'student3@uczelnia.pl', 'haslo123', 0, 0),
(6, 'nauczyciel2@uczelnia.pl', 'bezpieczne123', 1, 0),
(14, 'chuj.cfelowski@gmail.com', 'chuj123!', 1, 1);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `oceny`
--

CREATE TABLE `oceny` (
  `id_oceny` int(11) NOT NULL,
  `userID` int(11) NOT NULL,
  `id_przedmiotu` int(11) NOT NULL,
  `ocena` decimal(3,1) NOT NULL,
  `data_wystawienia` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Dumping data for table `oceny`
--

INSERT INTO `oceny` (`id_oceny`, `userID`, `id_przedmiotu`, `ocena`, `data_wystawienia`) VALUES
(1, 1, 1, 4.5, '2024-01-15'),
(2, 1, 2, 3.0, '2024-02-20'),
(3, 2, 3, 5.0, '2024-03-10'),
(4, 5, 4, 3.5, '2024-04-05'),
(5, 2, 5, 4.0, '2024-05-12');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `pracownicy`
--

CREATE TABLE `pracownicy` (
  `userID` int(11) NOT NULL,
  `imie` varchar(100) NOT NULL,
  `nazwisko` varchar(100) NOT NULL,
  `stanowisko` varchar(150) NOT NULL,
  `stopien_naukowy` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Dumping data for table `pracownicy`
--

INSERT INTO `pracownicy` (`userID`, `imie`, `nazwisko`, `stanowisko`, `stopien_naukowy`) VALUES
(3, 'Piotr', 'Zieliński', 'Profesor', 'Dr hab.'),
(4, 'admin', 'test', 'ADMIN', NULL),
(6, 'Katarzyna', 'Wójcik', 'Adiunkt', 'Dr'),
(14, 'chuj', 'cfelowski', 'admin', 'debil');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `prowadzone_przedmioty`
--

CREATE TABLE `prowadzone_przedmioty` (
  `userID` int(11) NOT NULL,
  `id_przedmiotu` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Dumping data for table `prowadzone_przedmioty`
--

INSERT INTO `prowadzone_przedmioty` (`userID`, `id_przedmiotu`) VALUES
(3, 1),
(3, 2),
(3, 5),
(6, 3),
(6, 4);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `przedmioty`
--

CREATE TABLE `przedmioty` (
  `id_przedmiotu` int(11) NOT NULL,
  `nazwa` varchar(255) NOT NULL,
  `ects` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Dumping data for table `przedmioty`
--

INSERT INTO `przedmioty` (`id_przedmiotu`, `nazwa`, `ects`) VALUES
(1, 'Matematyka', 6),
(2, 'Fizyka', 5),
(3, 'Programowanie', 7),
(4, 'Bazy Danych', 6),
(5, 'Algorytmy', 6);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `studenci`
--

CREATE TABLE `studenci` (
  `userID` int(11) NOT NULL,
  `imie` varchar(100) NOT NULL,
  `nazwisko` varchar(100) NOT NULL,
  `nr_indeksu` varchar(50) NOT NULL,
  `semestr` int(11) NOT NULL,
  `wydzial` varchar(100) NOT NULL,
  `kierunek` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Dumping data for table `studenci`
--

INSERT INTO `studenci` (`userID`, `imie`, `nazwisko`, `nr_indeksu`, `semestr`, `wydzial`, `kierunek`) VALUES
(1, 'Jan', 'Kowalski', 'S12345', 1, 'Mechaniczny', 'Automatyka'),
(2, 'Anna', 'Nowak', 'S67890', 2, 'Informatyka', 'Cyberbezpieczeństwo'),
(5, 'Marek', 'Wiśniewski', 'S54321', 3, 'Budownictwo', 'Architektura');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `zapisane_przedmioty`
--

CREATE TABLE `zapisane_przedmioty` (
  `userID` int(11) NOT NULL,
  `id_przedmiotu` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Dumping data for table `zapisane_przedmioty`
--

INSERT INTO `zapisane_przedmioty` (`userID`, `id_przedmiotu`) VALUES
(1, 1),
(1, 3),
(2, 2),
(2, 4),
(5, 5);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `logowanie`
--
ALTER TABLE `logowanie`
  ADD PRIMARY KEY (`userID`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Indeksy dla tabeli `oceny`
--
ALTER TABLE `oceny`
  ADD PRIMARY KEY (`id_oceny`),
  ADD KEY `userID` (`userID`),
  ADD KEY `id_przedmiotu` (`id_przedmiotu`);

--
-- Indeksy dla tabeli `pracownicy`
--
ALTER TABLE `pracownicy`
  ADD PRIMARY KEY (`userID`);

--
-- Indeksy dla tabeli `prowadzone_przedmioty`
--
ALTER TABLE `prowadzone_przedmioty`
  ADD PRIMARY KEY (`userID`,`id_przedmiotu`),
  ADD KEY `id_przedmiotu` (`id_przedmiotu`);

--
-- Indeksy dla tabeli `przedmioty`
--
ALTER TABLE `przedmioty`
  ADD PRIMARY KEY (`id_przedmiotu`);

--
-- Indeksy dla tabeli `studenci`
--
ALTER TABLE `studenci`
  ADD PRIMARY KEY (`userID`),
  ADD UNIQUE KEY `nr_indeksu` (`nr_indeksu`);

--
-- Indeksy dla tabeli `zapisane_przedmioty`
--
ALTER TABLE `zapisane_przedmioty`
  ADD PRIMARY KEY (`userID`,`id_przedmiotu`),
  ADD KEY `id_przedmiotu` (`id_przedmiotu`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `logowanie`
--
ALTER TABLE `logowanie`
  MODIFY `userID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `oceny`
--
ALTER TABLE `oceny`
  MODIFY `id_oceny` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `przedmioty`
--
ALTER TABLE `przedmioty`
  MODIFY `id_przedmiotu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `oceny`
--
ALTER TABLE `oceny`
  ADD CONSTRAINT `oceny_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `studenci` (`userID`) ON DELETE CASCADE,
  ADD CONSTRAINT `oceny_ibfk_2` FOREIGN KEY (`id_przedmiotu`) REFERENCES `przedmioty` (`id_przedmiotu`) ON DELETE CASCADE;

--
-- Constraints for table `pracownicy`
--
ALTER TABLE `pracownicy`
  ADD CONSTRAINT `pracownicy_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `logowanie` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `prowadzone_przedmioty`
--
ALTER TABLE `prowadzone_przedmioty`
  ADD CONSTRAINT `prowadzone_przedmioty_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `pracownicy` (`userID`) ON DELETE CASCADE,
  ADD CONSTRAINT `prowadzone_przedmioty_ibfk_2` FOREIGN KEY (`id_przedmiotu`) REFERENCES `przedmioty` (`id_przedmiotu`) ON DELETE CASCADE;

--
-- Constraints for table `studenci`
--
ALTER TABLE `studenci`
  ADD CONSTRAINT `studenci_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `logowanie` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `zapisane_przedmioty`
--
ALTER TABLE `zapisane_przedmioty`
  ADD CONSTRAINT `zapisane_przedmioty_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `studenci` (`userID`) ON DELETE CASCADE,
  ADD CONSTRAINT `zapisane_przedmioty_ibfk_2` FOREIGN KEY (`id_przedmiotu`) REFERENCES `przedmioty` (`id_przedmiotu`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
