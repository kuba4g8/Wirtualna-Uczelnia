-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Maj 24, 2025 at 02:25 PM
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
-- Struktura tabeli dla tabeli `calendar_events`
--

CREATE TABLE `calendar_events` (
  `id` int(11) NOT NULL,
  `title` varchar(255) NOT NULL,
  `description` text DEFAULT NULL,
  `event_date` date NOT NULL,
  `event_time` time DEFAULT NULL,
  `end_time` time DEFAULT NULL,
  `teacher_id` int(11) NOT NULL,
  `subject` varchar(255) DEFAULT NULL,
  `event_type` varchar(50) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `id_grupy` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `calendar_events`
--

INSERT INTO `calendar_events` (`id`, `title`, `description`, `event_date`, `event_time`, `end_time`, `teacher_id`, `subject`, `event_type`, `created_at`, `updated_at`, `id_grupy`) VALUES
(3, 'Kolokwium - Całki podwójne', 'całki podwoje testttest', '2025-05-20', '10:15:00', '11:00:00', 3, 'Matematyka', 'Kolokwium', '2025-05-20 11:14:52', '2025-05-22 12:56:25', 9),
(4, 'Kolokwium matematyka', 'test', '2025-05-26', '10:15:00', '11:00:00', 3, 'Matematyka', 'Kolokwium', '2025-05-20 12:14:48', '2025-05-20 12:14:48', NULL),
(5, 'Kolokwium - Bazy danych', 'Test z SQL i normalizacji', '2025-05-27', '09:00:00', '10:30:00', 3, 'Bazy danych', 'Kolokwium', '2025-05-22 12:00:00', '2025-05-22 12:00:00', 9),
(6, 'Zapisy na projekty', 'Termin składania tematów projektów', '2025-05-28', '12:00:00', '13:00:00', 6, 'Inżynieria oprogramowania', 'Spotkanie', '2025-05-22 12:05:00', '2025-05-22 12:05:00', 7),
(7, 'Wykład gościnny', 'Nowoczesne metody SI w biznesie', '2025-05-29', '15:00:00', '16:30:00', 3, 'Sztuczna inteligencja', 'Wykład', '2025-05-22 12:10:00', '2025-05-22 12:10:00', NULL),
(8, 'Egzamin poprawkowy', 'Dla studentów z oceną niedostateczną', '2025-05-30', '10:00:00', '12:00:00', 6, 'Matematyka dyskretna', 'Egzamin', '2025-05-22 12:15:00', '2025-05-22 12:15:00', 10),
(19, 'Kolokwium z elektorniki', 'strasznie ciezkie kolokwium nikt nie zda', '2025-06-05', '12:00:00', '14:00:00', 3, 'Elektronika', 'Kolokwium', '2025-05-24 10:45:50', '2025-05-24 10:45:50', 8);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `grupy`
--

CREATE TABLE `grupy` (
  `id_grupy` int(11) NOT NULL,
  `id_kierunku` int(11) NOT NULL,
  `typ_grupy` enum('Laboratoryjna','Ćwiczeniowa','Wykładowa','Seminarium') DEFAULT NULL,
  `numer_grupy` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `grupy`
--

INSERT INTO `grupy` (`id_grupy`, `id_kierunku`, `typ_grupy`, `numer_grupy`) VALUES
(7, 1, 'Laboratoryjna', 1),
(8, 1, 'Laboratoryjna', 2),
(9, 1, 'Laboratoryjna', 3),
(10, 1, 'Ćwiczeniowa', 1),
(11, 1, 'Ćwiczeniowa', 2),
(12, 2, 'Laboratoryjna', 1),
(13, 2, 'Laboratoryjna', 2),
(14, 2, 'Laboratoryjna', 3),
(15, 2, 'Ćwiczeniowa', 1),
(16, 2, 'Ćwiczeniowa', 2),
(17, 3, 'Laboratoryjna', 1),
(18, 3, 'Laboratoryjna', 2),
(19, 3, 'Laboratoryjna', 3),
(20, 3, 'Ćwiczeniowa', 1),
(21, 3, 'Ćwiczeniowa', 2),
(22, 4, 'Laboratoryjna', 1),
(23, 4, 'Laboratoryjna', 2),
(24, 4, 'Laboratoryjna', 3),
(25, 4, 'Ćwiczeniowa', 1),
(26, 4, 'Ćwiczeniowa', 2),
(27, 5, 'Laboratoryjna', 1),
(28, 5, 'Laboratoryjna', 2),
(29, 5, 'Laboratoryjna', 3),
(30, 5, 'Ćwiczeniowa', 1),
(31, 5, 'Ćwiczeniowa', 2),
(32, 6, 'Laboratoryjna', 1),
(33, 6, 'Laboratoryjna', 2),
(34, 6, 'Laboratoryjna', 3),
(35, 6, 'Ćwiczeniowa', 1),
(36, 6, 'Ćwiczeniowa', 2),
(37, 7, 'Laboratoryjna', 1),
(38, 7, 'Laboratoryjna', 2),
(39, 7, 'Laboratoryjna', 3),
(40, 7, 'Ćwiczeniowa', 1),
(41, 7, 'Ćwiczeniowa', 2),
(42, 8, 'Laboratoryjna', 1),
(43, 8, 'Laboratoryjna', 2),
(44, 8, 'Laboratoryjna', 3),
(45, 8, 'Ćwiczeniowa', 1),
(46, 8, 'Ćwiczeniowa', 2),
(47, 9, 'Laboratoryjna', 1),
(48, 9, 'Laboratoryjna', 2),
(49, 9, 'Laboratoryjna', 3),
(50, 9, 'Ćwiczeniowa', 1),
(51, 9, 'Ćwiczeniowa', 2),
(52, 10, 'Laboratoryjna', 1),
(53, 10, 'Laboratoryjna', 2),
(54, 10, 'Laboratoryjna', 3),
(55, 10, 'Ćwiczeniowa', 1),
(56, 10, 'Ćwiczeniowa', 2),
(57, 11, 'Laboratoryjna', 1),
(58, 11, 'Laboratoryjna', 2),
(59, 11, 'Laboratoryjna', 3),
(60, 11, 'Ćwiczeniowa', 1),
(61, 11, 'Ćwiczeniowa', 2),
(62, 12, 'Laboratoryjna', 1),
(63, 12, 'Laboratoryjna', 2),
(64, 12, 'Laboratoryjna', 3),
(65, 12, 'Ćwiczeniowa', 1),
(66, 12, 'Ćwiczeniowa', 2);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `kierunki`
--

CREATE TABLE `kierunki` (
  `id_kierunku` int(11) NOT NULL,
  `id_opiekunaRoku` int(11) NOT NULL,
  `semestr` int(11) DEFAULT NULL,
  `nazwa_kierunku` varchar(100) DEFAULT NULL,
  `specjalizacja` varchar(100) DEFAULT NULL,
  `tryb_studiow` enum('stacjonarne','niestacjonarne') DEFAULT 'stacjonarne',
  `tytul` enum('inżynier','licencjat') DEFAULT 'inżynier',
  `id_wydzialu` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `kierunki`
--

INSERT INTO `kierunki` (`id_kierunku`, `id_opiekunaRoku`, `semestr`, `nazwa_kierunku`, `specjalizacja`, `tryb_studiow`, `tytul`, `id_wydzialu`) VALUES
(1, 6, 1, 'Informatyka', 'Inżynieria Oprogramowania', 'stacjonarne', 'inżynier', 1),
(2, 6, 1, 'Informatyka', 'Cyberbezpieczeństwo', 'stacjonarne', 'inżynier', 1),
(3, 6, 1, 'Elektrotechnika', 'Systemy Pomiarowe', 'stacjonarne', 'inżynier', 1),
(4, 6, 1, 'Elektrotechnika', 'Elektroenergetyka', 'stacjonarne', 'inżynier', 1),
(5, 6, 1, 'Mechanika i Budowa Maszyn', 'Pojazdy i Maszyny Robocze', 'stacjonarne', 'inżynier', 2),
(6, 6, 1, 'Mechanika i Budowa Maszyn', 'Eksploatacja Pojazdów', 'stacjonarne', 'inżynier', 2),
(7, 6, 1, 'Mechatronika', 'Systemy Mechatroniczne', 'stacjonarne', 'inżynier', 2),
(8, 6, 1, 'Mechatronika', 'Robotyka', 'stacjonarne', 'inżynier', 2),
(9, 6, 1, 'Nawigacja', 'Eksploatacja Statków', 'stacjonarne', 'inżynier', 3),
(10, 6, 1, 'Nawigacja', 'Systemy Transportowe', 'stacjonarne', 'inżynier', 3),
(11, 6, 1, 'Transport', 'Logistyka Morska', 'stacjonarne', 'inżynier', 3),
(12, 6, 1, 'Transport', 'Inżynieria Transportu', 'stacjonarne', 'inżynier', 3);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `logowanie`
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
(6, 'nauczyciel2@uczelnia.pl', 'fb14f3923cb387fde49b62a819cc218833485477c207324327bb5f614464197a', 1, 0, '2omSCI87pTqjLdZts904GA==', 'bezpieczne123'),
(17, 'uzytkownik@szkola.pl', 'haslo123', 1, 0, 'ale slonojnmg', NULL);

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
(5, 2, 5, 4.0, '2024-05-12'),
(6, 1, 3, 4.0, '2025-05-15'),
(7, 1, 4, 3.5, '2025-05-16'),
(8, 2, 1, 4.5, '2025-05-17'),
(9, 2, 5, 5.0, '2025-05-18'),
(10, 5, 2, 3.0, '2025-05-19'),
(11, 5, 3, 4.0, '2025-05-20');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `plan_lekcji`
--

CREATE TABLE `plan_lekcji` (
  `id_zajecia` int(11) NOT NULL,
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

--
-- Dumping data for table `plan_lekcji`
--

INSERT INTO `plan_lekcji` (`id_zajecia`, `id_prowadzacego`, `id_grupy`, `id_kierunku`, `sala`, `dzien`, `godzina_startu`, `godzina_konca`, `przedmiot`, `rodzaj`, `notatki`) VALUES
(44, 6, 7, 1, 'C101', '2025-05-26', '08:00:00', '09:30:00', 'Programowanie obiektowe', 'Laboratorium', 'Dziedziczenie i polimorfizm'),
(45, 3, 7, 1, 'C102', '2025-05-26', '10:00:00', '11:30:00', 'Bazy danych', 'Laboratorium', 'SQL - JOINy i podzapytania'),
(46, 4, 10, 1, 'B101', '2025-05-26', '12:00:00', '13:30:00', 'Matematyka dyskretna', 'Ćwiczenia', 'Teoria grafów'),
(47, 6, 7, 1, 'C101', '2025-05-27', '08:00:00', '09:30:00', 'Programowanie obiektowe', 'Laboratorium', 'Polimorfizm i interfejsy'),
(48, 3, 7, 1, 'C102', '2025-05-27', '10:00:00', '11:30:00', 'Bazy danych', 'Laboratorium', 'Transakcje i blokady'),
(49, 4, 10, 1, 'B101', '2025-05-27', '12:00:00', '13:30:00', 'Algorytmy i struktury danych', 'Ćwiczenia', 'Sortowanie szybkie i zliczanie'),
(50, 6, 10, 1, 'B102', '2025-05-28', '08:00:00', '09:30:00', 'Matematyka dyskretna', 'Ćwiczenia', 'Kombinatoryka'),
(51, 3, 7, 1, 'C103', '2025-05-28', '10:00:00', '11:30:00', 'Programowanie obiektowe', 'Laboratorium', 'Wzorce projektowe'),
(52, 4, 7, 1, 'C104', '2025-05-28', '12:00:00', '13:30:00', 'Bazy danych', 'Laboratorium', 'Optymalizacja zapytań'),
(53, 6, 10, 1, 'B103', '2025-05-29', '08:00:00', '09:30:00', 'Algorytmy i struktury danych', 'Ćwiczenia', 'Grafy i drzewa'),
(54, 3, 7, 1, 'C105', '2025-05-29', '10:00:00', '11:30:00', 'Programowanie obiektowe', 'Laboratorium', 'Testowanie jednostkowe'),
(55, 4, 10, 1, 'B104', '2025-05-29', '12:00:00', '13:30:00', 'Matematyka dyskretna', 'Ćwiczenia', 'Logika i rachunek zdań'),
(56, 6, 7, 1, 'C106', '2025-05-30', '08:00:00', '09:30:00', 'Bazy danych', 'Laboratorium', 'Normalizacja baz danych'),
(57, 3, 7, 1, 'C107', '2025-05-30', '10:00:00', '11:30:00', 'Programowanie obiektowe', 'Laboratorium', 'Refleksja i atrybuty'),
(58, 4, 10, 1, 'B105', '2025-05-30', '12:00:00', '13:30:00', 'Algorytmy i struktury danych', 'Ćwiczenia', 'Algorytmy zachłanne'),
(59, 6, 13, 2, 'E101', '2025-05-26', '08:00:00', '09:30:00', 'Cyberbezpieczeństwo', 'Laboratorium', 'Podstawy kryptografii'),
(60, 3, 13, 2, 'E102', '2025-05-26', '10:00:00', '11:30:00', 'Testowanie penetracyjne', 'Laboratorium', 'Narzędzia Kali Linux'),
(61, 4, 15, 2, 'B201', '2025-05-26', '12:00:00', '13:30:00', 'Sieci komputerowe', 'Ćwiczenia', 'Protokoły bezpieczeństwa'),
(62, 6, 13, 2, 'E103', '2025-05-27', '08:00:00', '09:30:00', 'Cyberbezpieczeństwo', 'Laboratorium', 'Ataki DoS i DDoS'),
(63, 3, 13, 2, 'E104', '2025-05-27', '10:00:00', '11:30:00', 'Testowanie penetracyjne', 'Laboratorium', 'SQL Injection'),
(64, 4, 15, 2, 'B202', '2025-05-27', '12:00:00', '13:30:00', 'Forensyka cyfrowa', 'Ćwiczenia', 'Analiza logów'),
(65, 6, 15, 2, 'B203', '2025-05-28', '08:00:00', '09:30:00', 'Sieci komputerowe', 'Ćwiczenia', 'Bezpieczeństwo WiFi'),
(66, 3, 13, 2, 'E105', '2025-05-28', '10:00:00', '11:30:00', 'Cyberbezpieczeństwo', 'Laboratorium', 'Firewall i IDS'),
(67, 4, 13, 2, 'E106', '2025-05-28', '12:00:00', '13:30:00', 'Testowanie penetracyjne', 'Laboratorium', 'Testy penetracyjne web'),
(68, 6, 15, 2, 'B204', '2025-05-29', '08:00:00', '09:30:00', 'Forensyka cyfrowa', 'Ćwiczenia', 'Analiza pamięci RAM'),
(69, 3, 13, 2, 'E107', '2025-05-29', '10:00:00', '11:30:00', 'Cyberbezpieczeństwo', 'Laboratorium', 'Szyfrowanie danych'),
(70, 4, 15, 2, 'B205', '2025-05-29', '12:00:00', '13:30:00', 'Sieci komputerowe', 'Ćwiczenia', 'Routing i switching'),
(71, 6, 13, 2, 'E108', '2025-05-30', '08:00:00', '09:30:00', 'Testowanie penetracyjne', 'Laboratorium', 'Metody automatyzacji'),
(72, 3, 15, 2, 'B206', '2025-05-30', '10:00:00', '11:30:00', 'Forensyka cyfrowa', 'Ćwiczenia', 'Analiza dysków twardych'),
(73, 4, 13, 2, 'E109', '2025-05-30', '12:00:00', '13:30:00', 'Cyberbezpieczeństwo', 'Laboratorium', 'Audyt bezpieczeństwa'),
(74, 6, 30, 5, 'M101', '2025-05-26', '08:00:00', '09:30:00', 'Mechanika techniczna', 'Ćwiczenia', 'Statyka'),
(75, 3, 30, 5, 'M102', '2025-05-26', '10:00:00', '11:30:00', 'Termodynamika', 'Ćwiczenia', 'Przemiany gazowe'),
(76, 6, 30, 5, 'M103', '2025-05-27', '08:00:00', '09:30:00', 'Materiały konstrukcyjne', 'Ćwiczenia', 'Stale stopowe'),
(77, 3, 30, 5, 'M104', '2025-05-27', '10:00:00', '11:30:00', 'Hydraulika', 'Ćwiczenia', 'Pompy i zawory'),
(78, 6, 30, 5, 'M105', '2025-05-28', '08:00:00', '09:30:00', 'Mechanika techniczna', 'Ćwiczenia', 'Dynamika'),
(79, 3, 30, 5, 'M106', '2025-05-28', '10:00:00', '11:30:00', 'Termodynamika', 'Ćwiczenia', 'Silniki cieplne'),
(80, 6, 30, 5, 'M107', '2025-05-29', '08:00:00', '09:30:00', 'Materiały konstrukcyjne', 'Ćwiczenia', 'Tworzywa sztuczne'),
(81, 3, 30, 5, 'M108', '2025-05-29', '10:00:00', '11:30:00', 'Hydraulika', 'Ćwiczenia', 'Systemy hydrauliczne'),
(82, 6, 30, 5, 'M109', '2025-05-30', '08:00:00', '09:30:00', 'Mechanika techniczna', 'Ćwiczenia', 'Statyka i wytrzymałość'),
(83, 3, 30, 5, 'M110', '2025-05-30', '10:00:00', '11:30:00', 'Termodynamika', 'Ćwiczenia', 'Procesy cieplne'),
(84, 6, 13, 2, 'E203', '2025-06-02', '09:45:00', '11:15:00', 'Cyberbezpieczeństwo', 'Laboratorium', 'Podstawy kryptografii'),
(85, 4, 15, 2, 'B203', '2025-06-02', '11:30:00', '13:00:00', 'Sieci komputerowe', 'Ćwiczenia', 'Protokoły bezpieczeństwa'),
(86, 3, 7, 1, 'C103', '2025-06-03', '07:30:00', '09:00:00', 'Programowanie obiektowe', 'Laboratorium', 'Dziedziczenie i polimorfizm'),
(87, 6, 10, 1, 'B201', '2025-06-03', '09:15:00', '10:45:00', 'Matematyka dyskretna', 'Ćwiczenia', 'Kombinatoryka'),
(88, 4, 30, 5, 'M102', '2025-06-03', '11:00:00', '12:30:00', 'Termodynamika', 'Ćwiczenia', 'Przemiany gazowe'),
(89, 3, 13, 2, 'E204', '2025-06-04', '08:00:00', '09:30:00', 'Testowanie penetracyjne', 'Laboratorium', 'Narzędzia Kali Linux'),
(90, 6, 15, 2, 'B204', '2025-06-04', '09:45:00', '11:15:00', 'Forensyka cyfrowa', 'Ćwiczenia', 'Analiza logów'),
(91, 4, 7, 1, 'C104', '2025-06-04', '11:30:00', '13:00:00', 'Bazy danych', 'Laboratorium', 'SQL - złożone zapytania'),
(92, 3, 10, 1, 'B202', '2025-06-05', '08:00:00', '09:30:00', 'Algorytmy i struktury danych', 'Ćwiczenia', 'Sortowanie szybkie'),
(93, 6, 30, 5, 'M103', '2025-06-05', '09:45:00', '11:15:00', 'Materiały konstrukcyjne', 'Ćwiczenia', 'Stale stopowe'),
(94, 4, 13, 2, 'E205', '2025-06-05', '11:30:00', '13:00:00', 'Bezpieczeństwo sieci', 'Laboratorium', 'Firewall i IDS'),
(95, 3, 15, 2, 'B205', '2025-06-06', '08:00:00', '09:30:00', 'Analiza malware', 'Ćwiczenia', 'Reverse engineering'),
(96, 6, 7, 1, 'C105', '2025-06-06', '09:45:00', '11:15:00', 'Programowanie obiektowe', 'Laboratorium', 'Interfejsy i klasy abstrakcyjne'),
(97, 4, 10, 1, 'B203', '2025-06-06', '11:30:00', '13:00:00', 'Matematyka dyskretna', 'Ćwiczenia', 'Grafy i drzewa'),
(98, 3, 30, 5, 'M104', '2025-06-09', '08:00:00', '09:30:00', 'Hydraulika', 'Ćwiczenia', 'Pompy i zawory'),
(99, 6, 13, 2, 'E206', '2025-06-09', '09:45:00', '11:15:00', 'Systemy operacyjne', 'Laboratorium', 'Procesy i wątki'),
(100, 4, 15, 2, 'B206', '2025-06-09', '11:30:00', '13:00:00', 'Sieci komputerowe', 'Ćwiczenia', 'Protokoły routingowe'),
(101, 3, 7, 1, 'C106', '2025-06-10', '07:30:00', '09:00:00', 'Programowanie obiektowe', 'Laboratorium', 'Wzorce projektowe'),
(102, 6, 10, 1, 'B204', '2025-06-10', '09:15:00', '10:45:00', 'Matematyka dyskretna', 'Ćwiczenia', 'Permutacje i kombinacje'),
(103, 4, 30, 5, 'M105', '2025-06-10', '11:00:00', '12:30:00', 'Mechanika techniczna', 'Ćwiczenia', 'Dynamika'),
(104, 3, 13, 2, 'E207', '2025-06-11', '08:00:00', '09:30:00', 'Cyberbezpieczeństwo', 'Laboratorium', 'Szyfrowanie'),
(105, 6, 15, 2, 'B207', '2025-06-11', '09:45:00', '11:15:00', 'Forensyka cyfrowa', 'Ćwiczenia', 'Analiza dysków'),
(106, 4, 7, 1, 'C107', '2025-06-11', '11:30:00', '13:00:00', 'Bazy danych', 'Laboratorium', 'Optymalizacja zapytań'),
(107, 3, 10, 1, 'B205', '2025-06-12', '08:00:00', '09:30:00', 'Algorytmy i struktury danych', 'Ćwiczenia', 'Drzewa binarne'),
(108, 6, 30, 5, 'M106', '2025-06-12', '09:45:00', '11:15:00', 'Materiały konstrukcyjne', 'Ćwiczenia', 'Metale'),
(109, 4, 13, 2, 'E208', '2025-06-12', '11:30:00', '13:00:00', 'Systemy operacyjne', 'Laboratorium', 'Zarządzanie pamięcią'),
(110, 3, 15, 2, 'B208', '2025-06-13', '08:00:00', '09:30:00', 'Testowanie penetracyjne', 'Ćwiczenia', 'Ataki sieciowe'),
(111, 6, 7, 1, 'C108', '2025-06-13', '09:45:00', '11:15:00', 'Programowanie obiektowe', 'Laboratorium', 'Polimorfizm'),
(112, 4, 10, 1, 'B206', '2025-06-13', '11:30:00', '13:00:00', 'Matematyka dyskretna', 'Ćwiczenia', 'Logika matematyczna');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `pracownicy`
--

CREATE TABLE `pracownicy` (
  `userID` int(11) NOT NULL,
  `imie` varchar(100) NOT NULL,
  `nazwisko` varchar(100) NOT NULL,
  `stanowisko` varchar(150) NOT NULL,
  `stopien_naukowy` varchar(100) DEFAULT NULL,
  `konsultacje` varchar(255) DEFAULT NULL COMMENT 'Informacje o terminach konsultacji pracownika'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Dumping data for table `pracownicy`
--

INSERT INTO `pracownicy` (`userID`, `imie`, `nazwisko`, `stanowisko`, `stopien_naukowy`, `konsultacje`) VALUES
(3, 'Piotr', 'Zieliński', 'Profesor', 'Dr hab.', 'Wtorek 14:00-16:00'),
(4, 'admin', 'test', 'ADMIN', NULL, 'Środa 10:00-12:00'),
(6, 'Katarzyna', 'Wójcik', 'Adiunkt', 'Dr', 'Czwartek 15:00-17:00'),
(17, 'imie', 'nazwisko', 'stanowisko', 'stopein naukowy', 'Poniedziałek 13:00-15:00');

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
  `id_wydzialu` int(11) DEFAULT NULL,
  `id_kierunku` int(11) DEFAULT NULL,
  `id_grupy` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Dumping data for table `studenci`
--

INSERT INTO `studenci` (`userID`, `imie`, `nazwisko`, `nr_indeksu`, `semestr`, `id_wydzialu`, `id_kierunku`, `id_grupy`) VALUES
(1, 'Jan', 'Kowalski', 'S12345', 1, NULL, 1, 7),
(2, 'Anna', 'Nowak', 'S67890', 2, NULL, 2, 13),
(5, 'Marek', 'Wiśniewski', 'S54321', 3, NULL, 11, 60);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `studenci_grupy`
--

CREATE TABLE `studenci_grupy` (
  `id` int(11) NOT NULL,
  `userID` int(11) NOT NULL,
  `id_grupy` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `studenci_grupy`
--

INSERT INTO `studenci_grupy` (`id`, `userID`, `id_grupy`) VALUES
(1, 1, 7),
(2, 1, 10),
(3, 2, 13),
(4, 2, 15),
(5, 5, 30),
(6, 1, 8),
(7, 1, 11),
(8, 2, 12),
(9, 2, 16),
(10, 5, 31);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `wydzialy`
--

CREATE TABLE `wydzialy` (
  `id_wydzialu` int(11) NOT NULL,
  `nazwa` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `wydzialy`
--

INSERT INTO `wydzialy` (`id_wydzialu`, `nazwa`) VALUES
(1, 'Wydział Elektryczny'),
(2, 'Wydział Mechaniczny'),
(3, 'Wydział Nawigacyjny');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `calendar_events`
--
ALTER TABLE `calendar_events`
  ADD PRIMARY KEY (`id`),
  ADD KEY `teacher_id` (`teacher_id`),
  ADD KEY `fk_calendar_events_grupy` (`id_grupy`);

--
-- Indeksy dla tabeli `grupy`
--
ALTER TABLE `grupy`
  ADD PRIMARY KEY (`id_grupy`),
  ADD KEY `id_kierunku` (`id_kierunku`);

--
-- Indeksy dla tabeli `kierunki`
--
ALTER TABLE `kierunki`
  ADD PRIMARY KEY (`id_kierunku`),
  ADD KEY `id_opiekunaRoku` (`id_opiekunaRoku`),
  ADD KEY `id_wydzialu` (`id_wydzialu`);

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
-- Indeksy dla tabeli `plan_lekcji`
--
ALTER TABLE `plan_lekcji`
  ADD PRIMARY KEY (`id_zajecia`),
  ADD KEY `id_grupy` (`id_grupy`),
  ADD KEY `id_kierunku` (`id_kierunku`),
  ADD KEY `id_prowadzacego` (`id_prowadzacego`);

--
-- Indeksy dla tabeli `pracownicy`
--
ALTER TABLE `pracownicy`
  ADD PRIMARY KEY (`userID`);

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
  ADD UNIQUE KEY `nr_indeksu` (`nr_indeksu`),
  ADD KEY `id_wydzialu` (`id_wydzialu`),
  ADD KEY `fk_studenci_kierunki` (`id_kierunku`),
  ADD KEY `fk_studenci_grupy` (`id_grupy`);

--
-- Indeksy dla tabeli `studenci_grupy`
--
ALTER TABLE `studenci_grupy`
  ADD PRIMARY KEY (`id`),
  ADD KEY `userID` (`userID`),
  ADD KEY `id_grupy` (`id_grupy`);

--
-- Indeksy dla tabeli `wydzialy`
--
ALTER TABLE `wydzialy`
  ADD PRIMARY KEY (`id_wydzialu`),
  ADD UNIQUE KEY `nazwa` (`nazwa`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `calendar_events`
--
ALTER TABLE `calendar_events`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `grupy`
--
ALTER TABLE `grupy`
  MODIFY `id_grupy` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=67;

--
-- AUTO_INCREMENT for table `kierunki`
--
ALTER TABLE `kierunki`
  MODIFY `id_kierunku` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT for table `logowanie`
--
ALTER TABLE `logowanie`
  MODIFY `userID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=103;

--
-- AUTO_INCREMENT for table `oceny`
--
ALTER TABLE `oceny`
  MODIFY `id_oceny` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `plan_lekcji`
--
ALTER TABLE `plan_lekcji`
  MODIFY `id_zajecia` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=113;

--
-- AUTO_INCREMENT for table `przedmioty`
--
ALTER TABLE `przedmioty`
  MODIFY `id_przedmiotu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `studenci_grupy`
--
ALTER TABLE `studenci_grupy`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `wydzialy`
--
ALTER TABLE `wydzialy`
  MODIFY `id_wydzialu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `calendar_events`
--
ALTER TABLE `calendar_events`
  ADD CONSTRAINT `calendar_events_ibfk_1` FOREIGN KEY (`teacher_id`) REFERENCES `pracownicy` (`userID`),
  ADD CONSTRAINT `fk_calendar_events_grupy` FOREIGN KEY (`id_grupy`) REFERENCES `grupy` (`id_grupy`) ON UPDATE CASCADE;

--
-- Constraints for table `grupy`
--
ALTER TABLE `grupy`
  ADD CONSTRAINT `grupy_ibfk_1` FOREIGN KEY (`id_kierunku`) REFERENCES `kierunki` (`id_kierunku`);

--
-- Constraints for table `kierunki`
--
ALTER TABLE `kierunki`
  ADD CONSTRAINT `kierunki_ibfk_1` FOREIGN KEY (`id_opiekunaRoku`) REFERENCES `pracownicy` (`userID`),
  ADD CONSTRAINT `kierunki_ibfk_2` FOREIGN KEY (`id_wydzialu`) REFERENCES `wydzialy` (`id_wydzialu`);

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
  ADD CONSTRAINT `plan_lekcji_ibfk_2` FOREIGN KEY (`id_kierunku`) REFERENCES `kierunki` (`id_kierunku`),
  ADD CONSTRAINT `plan_lekcji_ibfk_3` FOREIGN KEY (`id_prowadzacego`) REFERENCES `logowanie` (`userID`);

--
-- Constraints for table `pracownicy`
--
ALTER TABLE `pracownicy`
  ADD CONSTRAINT `pracownicy_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `logowanie` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `studenci`
--
ALTER TABLE `studenci`
  ADD CONSTRAINT `fk_studenci_grupy` FOREIGN KEY (`id_grupy`) REFERENCES `grupy` (`id_grupy`),
  ADD CONSTRAINT `fk_studenci_kierunki` FOREIGN KEY (`id_kierunku`) REFERENCES `kierunki` (`id_kierunku`),
  ADD CONSTRAINT `studenci_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `logowanie` (`userID`) ON DELETE CASCADE,
  ADD CONSTRAINT `studenci_ibfk_2` FOREIGN KEY (`id_wydzialu`) REFERENCES `wydzialy` (`id_wydzialu`);

--
-- Constraints for table `studenci_grupy`
--
ALTER TABLE `studenci_grupy`
  ADD CONSTRAINT `studenci_grupy_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `studenci` (`userID`) ON DELETE CASCADE,
  ADD CONSTRAINT `studenci_grupy_ibfk_2` FOREIGN KEY (`id_grupy`) REFERENCES `grupy` (`id_grupy`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
