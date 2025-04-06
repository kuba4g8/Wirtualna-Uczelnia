-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 06, 2025 at 08:26 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

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
-- Table structure for table `grupy`
--

CREATE TABLE `grupy` (
  `id_grupy` int(11) NOT NULL,
  `id_kierunku` int(11) NOT NULL,
  `typ_grupy` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `kierunki`
--

CREATE TABLE `kierunki` (
  `id_kierunku` int(11) NOT NULL,
  `id_opiekunaRoku` int(11) NOT NULL,
  `wydzial` text DEFAULT NULL,
  `semestr` int(11) DEFAULT NULL,
  `nazwa_kierunku` text DEFAULT NULL,
  `specjalizacja` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `logowanie`
--

CREATE TABLE `logowanie` (
  `userID` int(11) NOT NULL,
  `email` varchar(255) NOT NULL,
  `haslo` varchar(255) NOT NULL,
  `isTeacher` tinyint(1) NOT NULL,
  `isAdmin` tinyint(1) NOT NULL,
  `salt` varchar(64) NOT NULL,
  `haslobezhash` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Dumping data for table `logowanie`
--

INSERT INTO `logowanie` (`userID`, `email`, `haslo`, `isTeacher`, `isAdmin`, `salt`, `haslobezhash`) VALUES
(1, 'student1@uczelnia.pl', 'db3c0e58b6098051e63b4b1fd2698cdb90b3e926d61393bed4378d20daaf0704', 0, 0, 'Yr46IuFMBjma3anTMOuXcw==', 'haslo123'),
(2, 'student2@uczelnia.pl', '78fb78059a6c365205328e7351cdbd0b74497f047ea4bff02afc5b7b5766b976', 0, 0, '+qAm/sY9OpjdFeT6MrTCpw==', 'haslo123'),
(3, 'nauczyciel1@uczelnia.pl', 'd4651b7fa8033c8a694eeb9c9c3a94a5a82ff8a8d0d936edc6466decbb173b1c', 1, 0, 'bQj7gneHNGx5MV4RAvWNzA==', 'tajnehaslo'),
(4, 'admin@uczelnia.pl', '7e619e41deca0453c246018254fae57e9f76f51e9f4ca4d6099c9bf95696e72f', 1, 1, 'trC8KEIfgcq0qs8E7RGTnA==', 'admin123'),
(5, 'student3@uczelnia.pl', '4d9b7c5e98f24f42f152da4953918016361ed40c3519ed3bc10f8b67e9006dbb', 0, 0, 'DF7oFdpsMMMt4/QJojWSyA==', 'haslo123'),
(6, 'nauczyciel2@uczelnia.pl', 'fb14f3923cb387fde49b62a819cc218833485477c207324327bb5f614464197a', 1, 0, '2omSCI87pTqjLdZts904GA==', 'bezpieczne123');

-- --------------------------------------------------------

--
-- Table structure for table `oceny`
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
-- Table structure for table `plan_lekcji`
--

CREATE TABLE `plan_lekcji` (
  `id_planu` int(11) NOT NULL,
  `id_prowadzacego` int(11) NOT NULL,
  `id_grupy` int(11) NOT NULL,
  `id_kierunku` int(11) NOT NULL,
  `sala` varchar(255) DEFAULT NULL,
  `dzien` date NOT NULL,
  `godzina_startu` time NOT NULL,
  `godzina_konca` time NOT NULL,
  `przedmiot` varchar(255) NOT NULL,
  `rodzaj` varchar(255) NOT NULL,
  `notatki` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `pracownicy`
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
(6, 'Katarzyna', 'Wójcik', 'Adiunkt', 'Dr');

-- --------------------------------------------------------

--
-- Table structure for table `przedmioty`
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
-- Table structure for table `studenci`
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

--
-- Indexes for dumped tables
--

--
-- Indexes for table `grupy`
--
ALTER TABLE `grupy`
  ADD PRIMARY KEY (`id_grupy`),
  ADD KEY `id_kierunku` (`id_kierunku`);

--
-- Indexes for table `kierunki`
--
ALTER TABLE `kierunki`
  ADD PRIMARY KEY (`id_kierunku`),
  ADD KEY `id_opiekunaRoku` (`id_opiekunaRoku`);

--
-- Indexes for table `logowanie`
--
ALTER TABLE `logowanie`
  ADD PRIMARY KEY (`userID`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Indexes for table `oceny`
--
ALTER TABLE `oceny`
  ADD PRIMARY KEY (`id_oceny`),
  ADD KEY `userID` (`userID`),
  ADD KEY `id_przedmiotu` (`id_przedmiotu`);

--
-- Indexes for table `plan_lekcji`
--
ALTER TABLE `plan_lekcji`
  ADD PRIMARY KEY (`id_planu`),
  ADD KEY `id_grupy` (`id_grupy`),
  ADD KEY `id_kierunku` (`id_kierunku`);

--
-- Indexes for table `pracownicy`
--
ALTER TABLE `pracownicy`
  ADD PRIMARY KEY (`userID`);

--
-- Indexes for table `przedmioty`
--
ALTER TABLE `przedmioty`
  ADD PRIMARY KEY (`id_przedmiotu`);

--
-- Indexes for table `studenci`
--
ALTER TABLE `studenci`
  ADD PRIMARY KEY (`userID`),
  ADD UNIQUE KEY `nr_indeksu` (`nr_indeksu`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `grupy`
--
ALTER TABLE `grupy`
  MODIFY `id_grupy` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `kierunki`
--
ALTER TABLE `kierunki`
  MODIFY `id_kierunku` int(11) NOT NULL AUTO_INCREMENT;

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
-- AUTO_INCREMENT for table `plan_lekcji`
--
ALTER TABLE `plan_lekcji`
  MODIFY `id_planu` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `przedmioty`
--
ALTER TABLE `przedmioty`
  MODIFY `id_przedmiotu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `grupy`
--
ALTER TABLE `grupy`
  ADD CONSTRAINT `grupy_ibfk_1` FOREIGN KEY (`id_kierunku`) REFERENCES `kierunki` (`id_kierunku`);

--
-- Constraints for table `kierunki`
--
ALTER TABLE `kierunki`
  ADD CONSTRAINT `kierunki_ibfk_1` FOREIGN KEY (`id_opiekunaRoku`) REFERENCES `pracownicy` (`userID`);

--
-- Constraints for table `oceny`
--
ALTER TABLE `oceny`
  ADD CONSTRAINT `oceny_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `studenci` (`userID`) ON DELETE CASCADE,
  ADD CONSTRAINT `oceny_ibfk_2` FOREIGN KEY (`id_przedmiotu`) REFERENCES `przedmioty` (`id_przedmiotu`) ON DELETE CASCADE;

--
-- Constraints for table `plan_lekcji`
--
ALTER TABLE `plan_lekcji`
  ADD CONSTRAINT `plan_lekcji_ibfk_1` FOREIGN KEY (`id_grupy`) REFERENCES `grupy` (`id_grupy`),
  ADD CONSTRAINT `plan_lekcji_ibfk_2` FOREIGN KEY (`id_kierunku`) REFERENCES `kierunki` (`id_kierunku`);

--
-- Constraints for table `pracownicy`
--
ALTER TABLE `pracownicy`
  ADD CONSTRAINT `pracownicy_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `logowanie` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `studenci`
--
ALTER TABLE `studenci`
  ADD CONSTRAINT `studenci_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `logowanie` (`userID`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
