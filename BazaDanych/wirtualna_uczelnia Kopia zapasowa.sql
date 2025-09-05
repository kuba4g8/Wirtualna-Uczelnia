DROP DATABASE IF EXISTS wirtualna_uczelnia;
CREATE DATABASE wirtualna_uczelnia;
USE wirtualna_uczelnia;


-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Cze 11, 2025 at 12:57 PM
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
(19, 'Kolokwium z elektorniki', 'strasznie ciezkie kolokwium nikt nie zda', '2025-06-05', '12:00:00', '14:00:00', 3, 'Elektronika', 'Kolokwium', '2025-05-24 10:45:50', '2025-05-24 10:45:50', 8),
(20, 'Kolokwium', 'Kolokwium z matematyki', '2025-06-11', NULL, NULL, 3, '', 'Kolokwium', '2025-05-27 19:18:17', '2025-05-27 19:18:17', 14),
(21, 'chuj', 'cfel', '2025-05-15', NULL, NULL, 3, 'asdasd', 'Kolokwium', '2025-05-28 08:03:50', '2025-05-28 08:03:50', 21),
(22, 'Kolokwium', 'Matematyka', '2025-05-16', '12:00:00', '14:00:00', 3, 'Matematyka', 'Kolokwium', '2025-05-28 09:38:11', '2025-05-28 09:38:11', 13),
(23, 'Na pewno nie oddanie projektu', '', '2025-06-13', NULL, NULL, 3, '', 'Dzień wolny', '2025-06-03 18:28:48', '2025-06-03 18:28:48', NULL),
(24, 'Sesja', 'SESJA EGZAMINACYJNA', '2025-06-14', NULL, NULL, 3, '', 'Sesja', '2025-06-03 18:41:14', '2025-06-03 18:41:14', NULL),
(25, 'Sesja', 'SESJA EGZAMINACYJNA', '2025-06-15', NULL, NULL, 3, '', 'Sesja', '2025-06-03 18:41:14', '2025-06-03 18:41:14', NULL),
(26, 'Sesja', 'SESJA EGZAMINACYJNA', '2025-06-16', NULL, NULL, 3, '', 'Sesja', '2025-06-03 18:41:14', '2025-06-03 18:41:14', NULL),
(27, 'Sesja', 'SESJA EGZAMINACYJNA', '2025-06-17', NULL, NULL, 3, '', 'Sesja', '2025-06-03 18:41:14', '2025-06-03 18:41:14', NULL),
(28, 'Sesja', 'SESJA EGZAMINACYJNA', '2025-06-18', NULL, NULL, 3, '', 'Sesja', '2025-06-03 18:41:14', '2025-06-03 18:41:14', NULL),
(29, 'Sesja', 'SESJA EGZAMINACYJNA', '2025-06-19', NULL, NULL, 3, '', 'Sesja', '2025-06-03 18:41:14', '2025-06-03 18:41:14', NULL),
(30, 'Sesja', 'SESJA EGZAMINACYJNA', '2025-06-20', NULL, NULL, 3, '', 'Sesja', '2025-06-03 18:41:14', '2025-06-03 18:41:14', NULL),
(31, 'Sesja', 'SESJA EGZAMINACYJNA', '2025-06-21', NULL, NULL, 3, '', 'Sesja', '2025-06-03 18:41:14', '2025-06-03 18:41:14', NULL),
(32, 'Sesja', 'SESJA EGZAMINACYJNA', '2025-06-22', NULL, NULL, 3, '', 'Sesja', '2025-06-03 18:41:14', '2025-06-03 18:41:14', NULL),
(33, 'Sesja', 'SESJA EGZAMINACYJNA', '2025-06-23', NULL, NULL, 3, '', 'Sesja', '2025-06-03 18:41:14', '2025-06-03 18:41:14', NULL),
(34, 'Sesja', 'SESJA EGZAMINACYJNA', '2025-06-24', NULL, NULL, 3, '', 'Sesja', '2025-06-03 18:41:14', '2025-06-03 18:41:14', NULL),
(35, 'Sesja', 'SESJA EGZAMINACYJNA', '2025-06-25', NULL, NULL, 3, '', 'Sesja', '2025-06-03 18:41:14', '2025-06-03 18:41:14', NULL);

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
(17, 'uzytkownik@szkola.pl', 'haslo123', 1, 0, 'ale slonojnmg', NULL),
(103, 'nauczyciel10@uczelnia.pl', '5ca7896ca87673c66e093e02c0b2e4d25a34746f1c2ed5e76eb8336dbd9f190d', 1, 0, '4bkf/l0QjJdjLOE6BExZVQ==', NULL),
(104, 'student4@uczelnia.pl', '5fa9e0603b07104c6c5c4824c1597bc6475b4e9572d62793f9df780b3db57a7e', 0, 0, 'E6UGCHBr0rkqwjdvLDkepw==', NULL),
(105, 'student5@uczelnia.pl', 'd812120fd9d87117183a72bb3ab9409ffa025465b1a5d6a63fd36c46ac65b9f0', 0, 0, '1cgSVPgKiDlB+0hQrSvO6w==', NULL),
(106, 'nauczyciel3@uczelnia.pl', '4b4abf0329d66981cb8fee0acb382c6d3f3798394418ceb69295d94134f79b5a', 1, 0, 'PSXNeIw55IaqCVBOCC4etw==', NULL),
(107, 'student@uczelnia.pl', 'c21b810ad4d668fb2600c49b9bd3773839b7b178ea7350cf1a0dbe3ee7f33635', 0, 0, 'UEFoZXCg3MdSwhl9fQyGBg==', NULL);

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
(11, 5, 3, 4.0, '2025-05-20'),
(12, 1, 4, 4.0, '2025-05-27'),
(14, 5, 16, 2.0, '2025-05-27'),
(15, 1, 4, 5.0, '2025-05-28'),
(16, 1, 4, 2.0, '2025-06-02'),
(18, 2, 10, 5.0, '2025-06-07'),
(19, 2, 9, 5.0, '2025-06-07'),
(20, 2, 12, 5.0, '2025-06-07');

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
  `id_przedmiotu` int(11) DEFAULT NULL,
  `rodzaj` varchar(255) NOT NULL,
  `notatki` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `plan_lekcji`
--

INSERT INTO `plan_lekcji` (`id_zajecia`, `id_prowadzacego`, `id_grupy`, `id_kierunku`, `sala`, `dzien`, `godzina_startu`, `godzina_konca`, `id_przedmiotu`, `rodzaj`, `notatki`) VALUES
(44, 6, 7, 2, 'C101', '2025-05-26', '08:00:00', '09:30:00', 6, 'Laboratorium', 'JAVAAAAAA'),
(45, 103, 7, 1, 'B205', '2025-06-02', '10:15:00', '11:45:00', 17, 'ćwiczenia', 'ale bezpiecznie'),
(46, 6, 10, 1, 'B101', '2025-05-26', '12:00:00', '13:30:00', 7, 'ćwiczenia', 'Teoria grafów'),
(47, 6, 7, 1, 'C101', '2025-05-27', '08:00:00', '09:30:00', 6, 'Laboratorium', 'Polimorfizm i interfejsy'),
(49, 4, 10, 1, 'B101', '2025-05-27', '12:00:00', '13:30:00', 8, 'Ćwiczenia', 'Sortowanie szybkie i zliczanie'),
(50, 6, 10, 1, 'B102', '2025-05-28', '08:00:00', '09:30:00', 7, 'Ćwiczenia', 'Kombinatoryka'),
(51, 3, 7, 1, 'C103', '2025-05-28', '10:00:00', '11:30:00', 6, 'Laboratorium', 'Wzorce projektowe'),
(52, 4, 7, 1, 'C104', '2025-05-28', '12:00:00', '13:30:00', 4, 'Laboratorium', 'Optymalizacja zapytań'),
(53, 6, 10, 1, 'B103', '2025-05-29', '08:00:00', '09:30:00', 8, 'Ćwiczenia', 'Grafy i drzewa'),
(54, 3, 7, 1, 'C105', '2025-05-29', '10:00:00', '11:30:00', 6, 'Laboratorium', 'Testowanie jednostkowe'),
(55, 4, 10, 1, 'B104', '2025-05-29', '12:00:00', '13:30:00', 7, 'Ćwiczenia', 'Logika i rachunek zdań'),
(56, 6, 7, 1, 'C106', '2025-05-30', '08:00:00', '09:30:00', 4, 'Laboratorium', 'Normalizacja baz danych'),
(57, 3, 7, 1, 'C107', '2025-05-30', '10:00:00', '11:30:00', 6, 'Laboratorium', 'Refleksja i atrybuty'),
(58, 4, 10, 1, 'B105', '2025-05-30', '12:00:00', '13:30:00', 8, 'Ćwiczenia', 'Algorytmy zachłanne'),
(59, 6, 13, 2, 'E101', '2025-05-26', '08:00:00', '09:30:00', 9, 'Laboratorium', 'Podstawy kryptografii'),
(60, 3, 13, 2, 'E102', '2025-05-26', '10:00:00', '11:30:00', 10, 'Laboratorium', 'Narzędzia Kali Linux'),
(61, 4, 15, 2, 'B201', '2025-05-26', '12:00:00', '13:30:00', 11, 'Ćwiczenia', 'Protokoły bezpieczeństwa'),
(62, 6, 13, 2, 'E103', '2025-05-27', '08:00:00', '09:30:00', 9, 'Laboratorium', 'Ataki DoS i DDoS'),
(63, 3, 13, 2, 'E104', '2025-05-27', '10:00:00', '11:30:00', 10, 'Laboratorium', 'SQL Injection'),
(64, 4, 15, 2, 'B202', '2025-05-27', '12:00:00', '13:30:00', 12, 'Ćwiczenia', 'Analiza logów'),
(65, 6, 15, 2, 'B203', '2025-05-28', '08:00:00', '09:30:00', 11, 'Ćwiczenia', 'Bezpieczeństwo WiFi'),
(66, 3, 13, 2, 'E105', '2025-05-28', '10:00:00', '11:30:00', 9, 'Laboratorium', 'Firewall i IDS'),
(67, 4, 13, 2, 'E106', '2025-05-28', '12:00:00', '13:30:00', 10, 'Laboratorium', 'Testy penetracyjne web'),
(68, 6, 15, 2, 'B204', '2025-05-29', '08:00:00', '09:30:00', 12, 'Ćwiczenia', 'Analiza pamięci RAM'),
(69, 3, 13, 2, 'E107', '2025-05-29', '10:00:00', '11:30:00', 9, 'Laboratorium', 'Szyfrowanie danych'),
(70, 4, 15, 2, 'B205', '2025-05-29', '12:00:00', '13:30:00', 11, 'Ćwiczenia', 'Routing i switching'),
(71, 6, 13, 2, 'E108', '2025-05-30', '08:00:00', '09:30:00', 10, 'Laboratorium', 'Metody automatyzacji'),
(72, 3, 15, 2, 'B206', '2025-05-30', '10:00:00', '11:30:00', 12, 'Ćwiczenia', 'Analiza dysków twardych'),
(73, 4, 13, 2, 'E109', '2025-05-30', '12:00:00', '13:30:00', 9, 'Laboratorium', 'Audyt bezpieczeństwa'),
(74, 6, 30, 5, 'M101', '2025-05-26', '08:00:00', '09:30:00', 13, 'Ćwiczenia', 'Statyka'),
(75, 3, 30, 5, 'M102', '2025-05-26', '10:00:00', '11:30:00', 14, 'Ćwiczenia', 'Przemiany gazowe'),
(76, 6, 30, 5, 'M103', '2025-05-27', '08:00:00', '09:30:00', 15, 'Ćwiczenia', 'Stale stopowe'),
(77, 3, 30, 5, 'M104', '2025-05-27', '10:00:00', '11:30:00', 16, 'Ćwiczenia', 'Pompy i zawory'),
(78, 6, 30, 5, 'M105', '2025-05-28', '08:00:00', '09:30:00', 13, 'Ćwiczenia', 'Dynamika'),
(79, 3, 30, 5, 'M106', '2025-05-28', '10:00:00', '11:30:00', 14, 'Ćwiczenia', 'Silniki cieplne'),
(80, 6, 30, 5, 'M107', '2025-05-29', '08:00:00', '09:30:00', 15, 'Ćwiczenia', 'Tworzywa sztuczne'),
(81, 3, 30, 5, 'M108', '2025-05-29', '10:00:00', '11:30:00', 16, 'Ćwiczenia', 'Systemy hydrauliczne'),
(82, 6, 30, 5, 'M109', '2025-05-30', '08:00:00', '09:30:00', 13, 'Ćwiczenia', 'Statyka i wytrzymałość'),
(83, 3, 30, 5, 'M110', '2025-05-30', '10:00:00', '11:30:00', 14, 'Ćwiczenia', 'Procesy cieplne'),
(84, 6, 13, 2, 'E203', '2025-06-02', '09:45:00', '11:15:00', 9, 'Laboratorium', 'Podstawy kryptografii'),
(85, 4, 15, 2, 'B203', '2025-06-02', '11:30:00', '13:00:00', 11, 'Ćwiczenia', 'Protokoły bezpieczeństwa'),
(86, 3, 7, 1, 'C103', '2025-06-03', '07:30:00', '09:00:00', 6, 'Laboratorium', 'Dziedziczenie i polimorfizm'),
(87, 6, 10, 1, 'B201', '2025-06-03', '09:15:00', '10:45:00', 7, 'Ćwiczenia', 'Kombinatoryka'),
(88, 4, 30, 5, 'M102', '2025-06-03', '11:00:00', '12:30:00', 14, 'Ćwiczenia', 'Przemiany gazowe'),
(89, 3, 13, 2, 'E204', '2025-06-04', '08:00:00', '09:30:00', 10, 'Laboratorium', 'Narzędzia Kali Linux'),
(90, 6, 15, 2, 'B204', '2025-06-04', '09:45:00', '11:15:00', 12, 'Ćwiczenia', 'Analiza logów'),
(91, 4, 7, 1, 'C104', '2025-06-04', '11:30:00', '13:00:00', 4, 'Laboratorium', 'SQL - złożone zapytania'),
(92, 3, 10, 1, 'B202', '2025-06-05', '08:00:00', '09:30:00', 8, 'Ćwiczenia', 'Sortowanie szybkie'),
(93, 6, 30, 5, 'M103', '2025-06-05', '09:45:00', '11:15:00', 15, 'Ćwiczenia', 'Stale stopowe'),
(94, 4, 13, 2, 'E205', '2025-06-05', '11:30:00', '13:00:00', 17, 'Laboratorium', 'Firewall i IDS'),
(95, 3, 15, 2, 'B205', '2025-06-06', '08:00:00', '09:30:00', 18, 'Ćwiczenia', 'Reverse engineering'),
(96, 6, 7, 1, 'C105', '2025-06-06', '09:45:00', '11:15:00', 6, 'Laboratorium', 'Interfejsy i klasy abstrakcyjne'),
(97, 4, 10, 1, 'B203', '2025-06-06', '11:30:00', '13:00:00', 7, 'Ćwiczenia', 'Grafy i drzewa'),
(98, 3, 30, 5, 'M104', '2025-06-09', '08:00:00', '09:30:00', 16, 'Ćwiczenia', 'Pompy i zawory'),
(99, 6, 13, 2, 'E206', '2025-06-09', '09:45:00', '11:15:00', 19, 'Laboratorium', 'Procesy i wątki'),
(100, 4, 15, 2, 'B206', '2025-06-09', '11:30:00', '13:00:00', 11, 'Ćwiczenia', 'Protokoły routingowe'),
(101, 3, 7, 1, 'C106', '2025-06-10', '07:30:00', '09:00:00', 6, 'Laboratorium', 'Wzorce projektowe'),
(102, 6, 10, 1, 'B204', '2025-06-10', '09:15:00', '10:45:00', 7, 'Ćwiczenia', 'Permutacje i kombinacje'),
(103, 4, 30, 5, 'M105', '2025-06-10', '11:00:00', '12:30:00', 13, 'Ćwiczenia', 'Dynamika'),
(104, 3, 13, 2, 'E207', '2025-06-11', '08:00:00', '09:30:00', 9, 'Laboratorium', 'Szyfrowanie'),
(105, 6, 15, 2, 'B207', '2025-06-11', '09:45:00', '11:15:00', 12, 'Ćwiczenia', 'Analiza dysków'),
(106, 4, 7, 1, 'C107', '2025-06-11', '11:30:00', '13:00:00', 4, 'Laboratorium', 'Optymalizacja zapytań'),
(107, 3, 10, 1, 'B205', '2025-06-12', '08:00:00', '09:30:00', 8, 'Ćwiczenia', 'Drzewa binarne'),
(108, 6, 30, 5, 'M106', '2025-06-12', '09:45:00', '11:15:00', 15, 'Ćwiczenia', 'Metale'),
(109, 4, 13, 2, 'E208', '2025-06-12', '11:30:00', '13:00:00', 19, 'Laboratorium', 'Zarządzanie pamięcią'),
(110, 3, 15, 2, 'B208', '2025-06-13', '08:00:00', '09:30:00', 10, 'Ćwiczenia', 'Ataki sieciowe'),
(111, 6, 7, 1, 'C108', '2025-06-13', '09:45:00', '11:15:00', 6, 'Laboratorium', 'Polimorfizm'),
(112, 4, 10, 1, 'B206', '2025-06-13', '11:30:00', '13:00:00', 7, 'Ćwiczenia', 'Logika matematyczna'),
(115, 17, 7, 1, 'B303', '2025-06-03', '12:00:00', '14:00:00', 19, 'laboratoria', 'Labki'),
(116, 6, 7, 1, 'C303', '2025-06-04', '10:00:00', '12:00:00', 5, 'wykład', 'Wykłady tym razem'),
(117, 6, 7, 1, 'C150', '2025-06-02', '12:00:00', '16:00:00', 17, 'wykład', 'Bardzo dlugi i nudny wyklad o kolankach'),
(118, 17, 30, 5, 'B20', '2025-06-06', '20:00:00', '22:00:00', 6, 'laboratoria', NULL),
(119, 103, 7, 1, 'B205', '2025-06-02', '07:00:00', '10:00:00', 5, 'wykład', 'Algorytmika'),
(121, 17, 54, 10, 'C123', '2025-06-02', '12:00:00', '14:00:00', 5, 'laboratoria', 'eluwina'),
(122, 17, 53, 10, 'lol', '2025-06-03', '12:00:00', '14:00:00', 5, 'wykład', 'asdasd'),
(123, 6, 42, 8, 'C090', '2025-06-03', '12:00:00', '14:00:00', 5, 'laboratoria', 'Szkola i jeszcze raz szkola'),
(124, 6, 46, 8, 'C20', '2025-06-02', '12:00:00', '14:00:00', 1, 'wykład', 'nudy na pudy'),
(125, 103, 42, 8, 'sala', '2025-06-02', '12:00:00', '14:00:00', 5, 'laboratoria', 'lol'),
(126, 3, 42, 8, 'asd', '2025-06-02', '07:00:00', '11:45:00', 13, 'ćwiczenia', 'asd'),
(127, 3, 45, 8, 'C123', '2025-06-11', '08:15:00', '12:45:00', 15, 'ćwiczenia', ''),
(128, 3, 27, 5, 'A303', '2025-06-09', '08:00:00', '10:00:00', 2, 'laboratoria', NULL),
(129, 17, 27, 5, 'A305', '2025-06-09', '10:15:00', '12:00:00', 5, 'ćwiczenia', 'Lolixon'),
(130, 6, 30, 5, 'C21', '2025-06-10', '10:00:00', '15:00:00', 16, 'wykład', '');

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
(3, 'Piotr', 'Zieliński', 'Magister', 'Dr hab.', NULL),
(4, 'admin', 'test', 'ADMIN', NULL, 'Środa 10:00-12:00'),
(6, 'Katarzyna', 'Wójcik', 'Adiunkt', 'Dr', 'Czwartek 15:00-17:00'),
(17, 'imie', 'nazwisko', 'Woźny', 'Magister', NULL),
(103, 'Magdalon', 'Nazwiskowa', 'Nauczyciel', 'Dr. Hab.', NULL),
(106, 'Jan', 'Wójtowicz', 'Profesor', 'Profesor', NULL);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `przedmioty`
--

CREATE TABLE `przedmioty` (
  `id_przedmiotu` int(11) NOT NULL,
  `nazwa` varchar(255) DEFAULT NULL,
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
(5, 'Algorytmy', 6),
(6, 'Programowanie Obiektowe', 5),
(7, 'Matematyka Dyskretna', 5),
(8, 'Algorytmy i Struktury Danych', 5),
(9, 'Cyberbezpieczeństwo', 5),
(10, 'Testowanie Penetracyjne', 5),
(11, 'Sieci Komputerowe', 5),
(12, 'Forensyka Cyfrowa', 5),
(13, 'Mechanika Techniczna', 5),
(14, 'Termodynamika', 5),
(15, 'Materiały Konstrukcyjne', 5),
(16, 'Hydraulika', 5),
(17, 'Bezpieczeństwo Sieci', 5),
(18, 'Analiza Malware', 5),
(19, 'Systemy Operacyjne', 5);

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
(1, 'Jan', 'Kowalski', 'S12345', 1, 1, 2, 7),
(2, 'Anna', 'Nowak', 'S67890', 2, NULL, 2, 13),
(5, 'Maciek', 'Wiśniewski', 'S54321', 3, 3, 10, 60),
(104, 'Jan', 'Zielony', 'S42099', 2, 2, 8, NULL),
(105, 'Daniel', 'Czerwony', 'niewiem', 2, 3, 11, NULL),
(107, 'student', 'biedny', 'S126543', 2, 2, 6, NULL);

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
(3, 2, 13),
(4, 2, 15),
(8, 2, 12),
(9, 2, 16),
(15, 1, 7),
(16, 1, 11),
(17, 5, 8),
(18, 5, 10),
(25, 105, 57),
(26, 105, 61),
(27, 104, 42),
(28, 104, 45),
(29, 107, 32),
(30, 107, 35);

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
  ADD KEY `id_prowadzacego` (`id_prowadzacego`),
  ADD KEY `fk_plan_lekcji_przedmioty` (`id_przedmiotu`);

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

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
  MODIFY `userID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=108;

--
-- AUTO_INCREMENT for table `oceny`
--
ALTER TABLE `oceny`
  MODIFY `id_oceny` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `plan_lekcji`
--
ALTER TABLE `plan_lekcji`
  MODIFY `id_zajecia` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=131;

--
-- AUTO_INCREMENT for table `przedmioty`
--
ALTER TABLE `przedmioty`
  MODIFY `id_przedmiotu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `studenci_grupy`
--
ALTER TABLE `studenci_grupy`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

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
  ADD CONSTRAINT `fk_plan_lekcji_przedmioty` FOREIGN KEY (`id_przedmiotu`) REFERENCES `przedmioty` (`id_przedmiotu`),
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
