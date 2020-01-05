-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Oct 18, 2017 at 01:00 PM
-- Server version: 5.7.19
-- PHP Version: 5.6.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `learning_activity`
--

-- --------------------------------------------------------

--
-- Table structure for table `absence`
--

DROP TABLE IF EXISTS `absence`;
CREATE TABLE IF NOT EXISTS `absence` (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `class` int(11) UNSIGNED NOT NULL,
  `count_excused` decimal(10,2) UNSIGNED NOT NULL,
  `count_unexcused` decimal(10,2) UNSIGNED NOT NULL,
  `time` enum('Първи срок','Годишни') NOT NULL,
  PRIMARY KEY (`id`),
  KEY `class` (`class`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `absence`
--

INSERT INTO `absence` (`id`, `class`, `count_excused`, `count_unexcused`, `time`) VALUES
(1, 1, '391.00', '12.66', 'Първи срок'),
(2, 2, '379.00', '26.00', 'Първи срок'),
(3, 3, '887.00', '64.33', 'Първи срок'),
(4, 4, '315.00', '3.66', 'Първи срок'),
(5, 5, '560.00', '2.66', 'Първи срок'),
(6, 6, '1020.00', '77.66', 'Първи срок'),
(7, 7, '783.00', '14.33', 'Първи срок'),
(8, 9, '1323.00', '81.00', 'Първи срок'),
(9, 8, '931.00', '38.33', 'Първи срок'),
(10, 10, '348.00', '1.33', 'Първи срок'),
(11, 11, '574.00', '22.66', 'Първи срок'),
(12, 12, '258.00', '0.00', 'Първи срок'),
(13, 13, '422.00', '26.00', 'Първи срок'),
(14, 14, '462.00', '9.33', 'Първи срок'),
(15, 15, '760.00', '74.66', 'Първи срок'),
(16, 16, '860.00', '51.33', 'Първи срок'),
(17, 17, '755.00', '39.66', 'Първи срок'),
(18, 22, '575.00', '52.33', 'Първи срок'),
(19, 23, '861.00', '70.33', 'Първи срок'),
(20, 4, '800.00', '6.33', 'Годишни'),
(21, 16, '5000.00', '70.66', 'Годишни'),
(22, 10, '500.00', '4.66', 'Годишни'),
(23, 31, '0.00', '0.00', 'Първи срок'),
(24, 13, '600.00', '7.66', 'Годишни'),
(25, 12, '558.00', '10.00', 'Годишни'),
(26, 8, '1811.00', '79.66', 'Годишни'),
(27, 7, '1560.00', '44.33', 'Годишни');

-- --------------------------------------------------------

--
-- Table structure for table `classes`
--

DROP TABLE IF EXISTS `classes`;
CREATE TABLE IF NOT EXISTS `classes` (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `school_year` int(4) NOT NULL,
  `grade` tinyint(3) UNSIGNED NOT NULL,
  `class` char(1) NOT NULL,
  `profile` int(10) UNSIGNED NOT NULL,
  `students` tinyint(3) UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`),
  KEY `profile` (`profile`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `classes`
--

INSERT INTO `classes` (`id`, `school_year`, `grade`, `class`, `profile`, `students`) VALUES
(1, 2016, 9, 'в', 4, 15),
(2, 2016, 9, 'б', 3, 20),
(3, 2016, 11, 'в', 4, 25),
(4, 2016, 8, 'а', 1, 25),
(5, 2016, 10, 'г', 5, 24),
(6, 2016, 12, 'в', 4, 21),
(7, 2016, 9, 'г', 5, 26),
(8, 2016, 12, 'б', 3, 23),
(9, 2016, 12, 'г', 5, 25),
(10, 2016, 8, 'б', 3, 24),
(11, 2016, 10, 'б', 3, 27),
(12, 2016, 8, 'г', 5, 26),
(13, 2016, 8, 'в', 4, 21),
(14, 2016, 9, 'а', 1, 26),
(15, 2016, 12, 'а', 1, 25),
(16, 2016, 10, 'а', 1, 24),
(17, 2016, 11, 'б', 3, 23),
(18, 2015, 8, 'г', 5, 20),
(19, 2015, 12, 'б', 3, 23),
(20, 2015, 2, 'а', 1, 20),
(21, 2014, 1, 'а', 1, 20),
(22, 2016, 10, 'в', 4, 18),
(23, 2016, 11, 'а', 1, 24),
(24, 2015, 8, 'а', 1, 26),
(25, 2015, 9, 'а', 1, 26),
(26, 2015, 11, 'б', 3, 23),
(27, 2014, 10, 'б', 3, 23),
(28, 2013, 9, 'б', 3, 23),
(29, 2012, 8, 'б', 3, 23),
(30, 2012, 6, 'б', 3, 20),
(31, 2014, 7, 'е', 1, 25);

-- --------------------------------------------------------

--
-- Table structure for table `profiles`
--

DROP TABLE IF EXISTS `profiles`;
CREATE TABLE IF NOT EXISTS `profiles` (
  `id` int(10) UNSIGNED ZEROFILL NOT NULL AUTO_INCREMENT,
  `name_profile` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
  `pp1` int(10) UNSIGNED NOT NULL,
  `pp2` int(10) UNSIGNED NOT NULL,
  `pp3` int(10) UNSIGNED NOT NULL,
  `pp4` int(10) UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name_profile_2` (`name_profile`),
  KEY `pp1` (`pp1`) USING BTREE,
  KEY `pp2` (`pp2`) USING BTREE,
  KEY `pp3` (`pp3`),
  KEY `pp4` (`pp4`),
  KEY `name_profile` (`name_profile`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `profiles`
--

INSERT INTO `profiles` (`id`, `name_profile`, `pp1`, `pp2`, `pp3`, `pp4`) VALUES
(0000000001, 'Природоматематически (Инф, Мат, АЕ, ИТ)', 14, 5, 2, 13),
(0000000003, 'Природоматематически (Мат, ИТ, АЕ, ИИ)', 5, 13, 2, 6),
(0000000004, 'Технологичен (ИТ, Г, АЕ, НЕ)', 13, 11, 2, 4),
(0000000005, 'Природоматематически (Б, Х, АЕ, ИТ)', 26, 8, 2, 13),
(0000000006, 'друг', 1, 2, 3, 4);

-- --------------------------------------------------------

--
-- Table structure for table `purpose`
--

DROP TABLE IF EXISTS `purpose`;
CREATE TABLE IF NOT EXISTS `purpose` (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `class` int(10) UNSIGNED NOT NULL,
  `subject` int(10) UNSIGNED NOT NULL,
  `type` int(10) UNSIGNED NOT NULL,
  `count_2` tinyint(3) UNSIGNED NOT NULL,
  `count_3` tinyint(3) UNSIGNED NOT NULL,
  `count_4` tinyint(3) UNSIGNED NOT NULL,
  `count_5` tinyint(3) UNSIGNED NOT NULL,
  `count_6` tinyint(3) UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  KEY `class` (`class`),
  KEY `subject` (`subject`),
  KEY `type` (`type`)
) ENGINE=InnoDB AUTO_INCREMENT=253 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `purpose`
--

INSERT INTO `purpose` (`id`, `class`, `subject`, `type`, `count_2`, `count_3`, `count_4`, `count_5`, `count_6`) VALUES
(1, 1, 1, 1, 0, 6, 5, 3, 2),
(2, 1, 2, 1, 0, 3, 9, 3, 0),
(3, 1, 4, 1, 0, 2, 2, 5, 6),
(4, 1, 5, 1, 1, 6, 7, 1, 0),
(5, 1, 13, 1, 0, 1, 7, 5, 2),
(6, 1, 12, 1, 0, 8, 6, 1, 0),
(7, 1, 11, 1, 0, 2, 3, 9, 1),
(9, 1, 8, 1, 0, 2, 3, 6, 4),
(10, 1, 7, 1, 0, 0, 2, 5, 7),
(11, 2, 1, 1, 1, 4, 9, 5, 1),
(12, 2, 3, 1, 0, 1, 1, 7, 3),
(13, 2, 4, 1, 0, 0, 2, 2, 4),
(14, 2, 5, 1, 2, 2, 10, 4, 2),
(15, 2, 13, 1, 0, 0, 6, 10, 4),
(16, 2, 11, 1, 0, 0, 4, 9, 7),
(17, 2, 26, 1, 0, 1, 6, 9, 4),
(18, 2, 8, 1, 0, 0, 1, 11, 8),
(19, 2, 7, 1, 0, 0, 0, 7, 13),
(31, 4, 1, 1, 0, 2, 13, 8, 2),
(32, 4, 2, 1, 0, 0, 3, 12, 10),
(33, 4, 5, 1, 0, 3, 10, 6, 6),
(34, 4, 7, 1, 0, 0, 0, 13, 12),
(35, 5, 1, 1, 0, 3, 6, 7, 8),
(36, 5, 3, 1, 0, 0, 0, 2, 11),
(37, 5, 2, 1, 0, 5, 9, 7, 3),
(38, 5, 5, 1, 0, 2, 5, 7, 10),
(39, 5, 13, 1, 0, 0, 0, 13, 11),
(40, 5, 12, 1, 0, 2, 6, 11, 5),
(41, 5, 22, 1, 0, 0, 0, 5, 19),
(42, 5, 26, 1, 0, 0, 2, 9, 13),
(43, 5, 9, 1, 0, 5, 9, 10, 0),
(44, 5, 8, 1, 0, 0, 5, 5, 14),
(45, 5, 7, 1, 0, 0, 0, 4, 15),
(46, 6, 1, 1, 1, 4, 9, 6, 1),
(47, 6, 2, 1, 0, 7, 5, 5, 4),
(48, 6, 4, 1, 1, 11, 4, 5, 0),
(49, 6, 5, 1, 0, 14, 1, 4, 2),
(50, 6, 13, 1, 1, 1, 5, 4, 10),
(51, 6, 12, 1, 2, 12, 3, 4, 0),
(52, 6, 11, 1, 0, 2, 8, 5, 6),
(53, 6, 24, 1, 0, 3, 4, 5, 9),
(54, 6, 7, 1, 0, 0, 0, 13, 8),
(55, 7, 1, 1, 0, 3, 10, 6, 7),
(56, 7, 3, 1, 0, 1, 0, 6, 6),
(57, 7, 2, 1, 0, 1, 6, 8, 11),
(58, 7, 4, 1, 0, 1, 2, 6, 4),
(59, 7, 5, 1, 0, 5, 6, 5, 10),
(60, 7, 13, 1, 0, 0, 1, 18, 7),
(61, 7, 12, 1, 0, 1, 9, 12, 4),
(62, 7, 11, 1, 0, 0, 0, 11, 15),
(63, 7, 26, 1, 0, 0, 4, 9, 13),
(64, 7, 8, 1, 0, 0, 3, 13, 10),
(65, 8, 1, 1, 0, 2, 7, 11, 3),
(66, 8, 3, 1, 0, 0, 1, 3, 19),
(67, 8, 2, 1, 0, 3, 6, 10, 4),
(68, 8, 5, 1, 0, 3, 4, 8, 8),
(69, 8, 13, 1, 0, 0, 4, 15, 4),
(70, 8, 12, 1, 0, 5, 12, 5, 1),
(71, 8, 24, 1, 0, 0, 2, 9, 12),
(72, 8, 7, 1, 0, 0, 0, 9, 13),
(75, 9, 3, 1, 0, 0, 2, 1, 9),
(76, 9, 2, 1, 0, 2, 12, 7, 4),
(77, 9, 4, 1, 0, 4, 4, 3, 2),
(78, 9, 5, 1, 0, 9, 10, 4, 2),
(79, 9, 12, 1, 0, 9, 12, 4, 0),
(80, 9, 24, 1, 0, 2, 3, 5, 15),
(81, 9, 26, 1, 0, 0, 0, 5, 20),
(82, 9, 8, 1, 0, 0, 0, 7, 18),
(83, 9, 7, 1, 0, 0, 3, 7, 14),
(84, 10, 1, 1, 0, 2, 14, 7, 1),
(85, 10, 2, 1, 0, 5, 10, 6, 3),
(86, 10, 5, 1, 0, 8, 7, 5, 4),
(87, 10, 7, 1, 0, 0, 1, 9, 14),
(88, 11, 1, 1, 0, 8, 9, 7, 3),
(89, 11, 3, 1, 0, 0, 0, 6, 7),
(90, 11, 2, 1, 0, 5, 8, 10, 4),
(91, 11, 4, 1, 1, 3, 6, 4, 0),
(92, 11, 5, 1, 0, 4, 10, 9, 4),
(93, 11, 13, 1, 0, 4, 11, 11, 1),
(94, 11, 12, 1, 0, 10, 14, 2, 1),
(95, 11, 22, 1, 0, 0, 3, 11, 13),
(96, 11, 26, 1, 0, 1, 3, 14, 9),
(97, 11, 9, 1, 0, 11, 8, 6, 2),
(98, 11, 8, 1, 0, 4, 9, 9, 5),
(99, 11, 7, 1, 0, 0, 0, 5, 21),
(100, 12, 1, 1, 0, 0, 6, 16, 4),
(101, 12, 2, 1, 0, 0, 6, 10, 10),
(102, 12, 5, 1, 0, 1, 10, 14, 1),
(103, 12, 7, 1, 0, 0, 0, 9, 15),
(104, 13, 1, 1, 1, 5, 9, 6, 0),
(105, 13, 2, 1, 0, 2, 10, 8, 1),
(106, 13, 5, 1, 0, 10, 6, 4, 1),
(107, 13, 7, 1, 0, 1, 5, 6, 9),
(108, 14, 1, 1, 0, 3, 11, 10, 2),
(109, 14, 3, 1, 0, 1, 0, 7, 2),
(110, 14, 2, 1, 0, 1, 4, 11, 10),
(111, 14, 4, 1, 0, 0, 1, 0, 15),
(112, 14, 5, 1, 0, 1, 8, 11, 6),
(113, 14, 14, 1, 0, 1, 0, 6, 19),
(114, 14, 12, 1, 0, 1, 7, 12, 6),
(115, 14, 11, 1, 0, 0, 0, 9, 17),
(116, 14, 26, 1, 0, 1, 1, 11, 13),
(117, 14, 8, 1, 0, 0, 5, 12, 9),
(118, 14, 7, 1, 0, 0, 0, 9, 13),
(119, 15, 1, 1, 1, 3, 9, 8, 4),
(120, 15, 3, 1, 0, 0, 2, 0, 8),
(121, 15, 2, 1, 0, 5, 7, 6, 7),
(122, 15, 5, 1, 1, 5, 7, 6, 6),
(123, 15, 14, 1, 0, 1, 6, 10, 8),
(124, 15, 12, 1, 0, 3, 11, 7, 2),
(125, 15, 24, 1, 1, 0, 2, 9, 13),
(126, 15, 7, 1, 0, 0, 0, 4, 19),
(127, 16, 1, 1, 0, 4, 9, 11, 0),
(128, 16, 3, 1, 0, 0, 3, 3, 0),
(129, 16, 2, 1, 0, 4, 10, 9, 1),
(130, 16, 5, 1, 0, 5, 10, 6, 3),
(131, 16, 13, 1, 0, 1, 8, 6, 9),
(134, 16, 22, 1, 0, 0, 8, 8, 8),
(135, 16, 26, 1, 0, 2, 5, 12, 5),
(136, 16, 9, 1, 0, 9, 7, 7, 1),
(137, 16, 8, 1, 0, 3, 7, 10, 4),
(138, 16, 7, 1, 0, 0, 4, 8, 12),
(152, 18, 1, 1, 0, 3, 0, 0, 17),
(153, 19, 1, 1, 4, 0, 0, 0, 16),
(156, 16, 4, 1, 0, 2, 9, 2, 5),
(157, 16, 12, 1, 0, 0, 6, 13, 5),
(158, 16, 14, 1, 0, 5, 5, 5, 9),
(159, 22, 1, 1, 0, 10, 7, 1, 0),
(160, 22, 2, 1, 1, 12, 3, 2, 0),
(161, 22, 4, 1, 1, 11, 4, 2, 0),
(162, 22, 5, 1, 2, 10, 4, 2, 0),
(163, 22, 13, 1, 0, 7, 5, 6, 0),
(164, 22, 12, 1, 0, 14, 2, 2, 0),
(165, 22, 11, 1, 0, 4, 9, 4, 1),
(166, 22, 22, 1, 0, 2, 6, 9, 1),
(167, 22, 26, 1, 0, 6, 8, 1, 3),
(168, 22, 9, 1, 3, 8, 7, 0, 0),
(169, 22, 8, 1, 0, 6, 10, 2, 0),
(170, 22, 7, 1, 0, 0, 0, 8, 9),
(171, 5, 4, 1, 0, 0, 1, 6, 4),
(172, 23, 1, 1, 0, 5, 9, 6, 4),
(173, 23, 2, 1, 0, 0, 7, 8, 9),
(174, 23, 4, 1, 1, 3, 8, 4, 8),
(175, 23, 5, 1, 0, 3, 9, 8, 4),
(176, 23, 14, 1, 0, 3, 6, 4, 11),
(177, 23, 13, 1, 0, 0, 5, 10, 9),
(178, 23, 12, 1, 0, 1, 6, 11, 6),
(179, 23, 11, 1, 0, 0, 6, 9, 9),
(180, 23, 26, 1, 0, 0, 1, 7, 16),
(181, 23, 9, 1, 0, 5, 7, 4, 8),
(182, 23, 8, 1, 0, 0, 10, 8, 6),
(183, 23, 7, 1, 0, 0, 1, 4, 16),
(184, 15, 4, 1, 0, 0, 0, 7, 8),
(185, 2, 2, 1, 0, 2, 3, 8, 7),
(186, 2, 12, 1, 0, 4, 9, 5, 2),
(187, 1, 26, 1, 0, 0, 7, 5, 3),
(188, 7, 7, 1, 0, 0, 2, 6, 16),
(189, 17, 1, 1, 0, 2, 10, 9, 2),
(190, 17, 3, 1, 0, 0, 0, 2, 7),
(191, 17, 2, 1, 0, 3, 12, 6, 2),
(192, 17, 4, 1, 0, 0, 3, 1, 10),
(193, 17, 5, 1, 0, 3, 7, 8, 5),
(194, 17, 13, 1, 0, 0, 4, 5, 14),
(195, 17, 12, 1, 0, 1, 6, 13, 3),
(196, 17, 11, 1, 1, 0, 3, 12, 7),
(197, 17, 26, 1, 0, 0, 2, 5, 16),
(198, 17, 9, 1, 0, 4, 3, 10, 6),
(199, 17, 8, 1, 1, 1, 4, 6, 11),
(200, 17, 6, 1, 0, 0, 0, 3, 20),
(201, 17, 7, 1, 0, 0, 0, 8, 14),
(202, 3, 1, 1, 1, 11, 10, 3, 0),
(203, 3, 2, 1, 0, 9, 6, 10, 0),
(204, 3, 4, 1, 4, 10, 8, 3, 0),
(205, 3, 5, 1, 1, 10, 14, 0, 0),
(206, 3, 13, 1, 0, 4, 6, 9, 6),
(207, 3, 12, 1, 1, 6, 16, 2, 0),
(208, 3, 11, 1, 0, 2, 3, 17, 3),
(209, 3, 26, 1, 0, 0, 5, 8, 12),
(210, 3, 9, 1, 2, 8, 10, 5, 0),
(211, 3, 8, 1, 0, 7, 4, 7, 7),
(212, 3, 7, 1, 0, 0, 0, 7, 17),
(213, 9, 1, 1, 0, 6, 6, 11, 1),
(214, 24, 1, 1, 0, 2, 8, 10, 6),
(215, 25, 1, 1, 1, 3, 12, 6, 0),
(216, 26, 1, 1, 0, 2, 11, 5, 5),
(217, 27, 1, 1, 0, 2, 7, 10, 0),
(218, 28, 1, 1, 1, 1, 9, 12, 0),
(219, 29, 2, 1, 0, 1, 9, 8, 5),
(220, 31, 26, 4, 6, 3, 3, 4, 9),
(221, 31, 1, 4, 0, 5, 0, 5, 5),
(222, 31, 11, 4, 5, 0, 5, 5, 0),
(223, 31, 6, 4, 0, 0, 0, 5, 0),
(224, 8, 1, 3, 0, 2, 4, 13, 4),
(225, 8, 3, 3, 0, 0, 0, 1, 22),
(226, 8, 2, 3, 0, 3, 6, 10, 4),
(227, 8, 5, 3, 0, 2, 6, 4, 11),
(228, 8, 13, 3, 0, 0, 4, 9, 10),
(229, 8, 12, 3, 0, 4, 9, 8, 2),
(230, 8, 11, 3, 0, 0, 6, 12, 5),
(231, 8, 24, 3, 0, 0, 1, 7, 15),
(232, 8, 9, 3, 0, 2, 6, 11, 4),
(233, 8, 8, 3, 0, 0, 1, 5, 16),
(234, 8, 18, 3, 0, 0, 0, 0, 13),
(235, 7, 1, 3, 0, 2, 6, 11, 7),
(236, 7, 3, 3, 0, 0, 1, 3, 9),
(237, 7, 2, 3, 0, 1, 7, 5, 13),
(238, 7, 4, 3, 0, 0, 2, 4, 7),
(239, 7, 5, 3, 0, 4, 4, 5, 13),
(240, 7, 14, 3, 0, 0, 7, 8, 11),
(241, 7, 13, 3, 0, 0, 1, 15, 10),
(242, 7, 12, 3, 0, 0, 5, 16, 5),
(243, 7, 11, 3, 0, 0, 3, 10, 13),
(244, 7, 21, 3, 0, 0, 1, 9, 16),
(245, 7, 26, 3, 0, 0, 0, 5, 21),
(246, 7, 9, 3, 0, 1, 10, 7, 8),
(247, 7, 8, 3, 0, 0, 0, 4, 22),
(248, 7, 15, 3, 0, 0, 0, 0, 26),
(249, 7, 6, 3, 0, 0, 0, 0, 26),
(250, 7, 7, 3, 0, 0, 0, 3, 21),
(251, 7, 25, 3, 0, 0, 0, 0, 26),
(252, 7, 27, 3, 0, 0, 0, 0, 26);

-- --------------------------------------------------------

--
-- Table structure for table `subject`
--

DROP TABLE IF EXISTS `subject`;
CREATE TABLE IF NOT EXISTS `subject` (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `name_subject` varchar(35) NOT NULL,
  `number` int(10) UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name_subject` (`name_subject`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `subject`
--

INSERT INTO `subject` (`id`, `name_subject`, `number`) VALUES
(1, 'Български език и литература', 1),
(2, 'Английски език', 3),
(3, 'Руски еизк', 2),
(4, 'Немски език', 4),
(5, 'Математика', 5),
(6, 'Изобразително изкуство', 18),
(7, 'Физическо възпитание и спорт', 19),
(8, 'Химия и ООС', 16),
(9, 'Физика и астрономия', 15),
(11, 'География и икономика', 9),
(12, 'История и цивилизация', 8),
(13, 'Информационни технологии', 7),
(14, 'Информатика', 6),
(15, 'Музика', 16),
(17, 'Сип-Математика', 30),
(18, 'Сип-Български език и литература', 31),
(19, 'Сип-Информатика', 32),
(21, 'Психология и логика', 10),
(22, 'Етика и право', 11),
(23, 'Философия ', 12),
(24, 'Свят и личност', 13),
(25, 'СИП биология', 33),
(26, 'Биология и здравно образование', 14),
(27, 'СИП химия', 40);

-- --------------------------------------------------------

--
-- Table structure for table `teachers`
--

DROP TABLE IF EXISTS `teachers`;
CREATE TABLE IF NOT EXISTS `teachers` (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `name_teacher` varchar(15) NOT NULL,
  `family_teacher` varchar(30) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `family_teacher` (`family_teacher`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `teachers`
--

INSERT INTO `teachers` (`id`, `name_teacher`, `family_teacher`) VALUES
(1, 'Мария', 'Мария'),
(2, 'Христина', 'Янчева'),
(3, 'Росица', 'Росица'),
(4, 'Хрисна', 'Костова'),
(5, 'Емилия', 'Узунова'),
(6, 'Теменужка', 'Кременарова'),
(7, 'Валентина', 'Велкова'),
(8, 'Мария', 'Иванова');

-- --------------------------------------------------------

--
-- Table structure for table `teaching`
--

DROP TABLE IF EXISTS `teaching`;
CREATE TABLE IF NOT EXISTS `teaching` (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `class` int(10) UNSIGNED NOT NULL,
  `subject` int(10) UNSIGNED NOT NULL,
  `teacher` int(10) UNSIGNED NOT NULL,
  `workload` mediumint(8) UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  KEY `class` (`class`),
  KEY `subject` (`subject`),
  KEY `teacher` (`teacher`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `teaching`
--

INSERT INTO `teaching` (`id`, `class`, `subject`, `teacher`, `workload`) VALUES
(1, 4, 1, 1, 144),
(2, 4, 2, 1, 36),
(3, 4, 5, 1, 36);

-- --------------------------------------------------------

--
-- Table structure for table `types`
--

DROP TABLE IF EXISTS `types`;
CREATE TABLE IF NOT EXISTS `types` (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `name_type` varchar(25) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `types`
--

INSERT INTO `types` (`id`, `name_type`) VALUES
(1, 'Първи срок'),
(2, 'Втори срок'),
(3, 'Годишно'),
(4, 'Входно ниво'),
(5, 'Изходно ниво'),
(6, 'Класна работа №1'),
(7, 'Класна рабоа №2'),
(8, 'Външно оценяване'),
(9, 'ДЗИ');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `absence`
--
ALTER TABLE `absence`
  ADD CONSTRAINT `absence@x0_ibfk_1` FOREIGN KEY (`class`) REFERENCES `classes` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `classes`
--
ALTER TABLE `classes`
  ADD CONSTRAINT `classes_ibfk_1` FOREIGN KEY (`profile`) REFERENCES `profiles` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `profiles`
--
ALTER TABLE `profiles`
  ADD CONSTRAINT `profiles_ibfk_1` FOREIGN KEY (`pp1`) REFERENCES `subject` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `profiles_ibfk_2` FOREIGN KEY (`pp2`) REFERENCES `subject` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `profiles_ibfk_3` FOREIGN KEY (`pp3`) REFERENCES `subject` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `profiles_ibfk_4` FOREIGN KEY (`pp4`) REFERENCES `subject` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `purpose`
--
ALTER TABLE `purpose`
  ADD CONSTRAINT `purpose_ibfk_1` FOREIGN KEY (`class`) REFERENCES `classes` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `purpose_ibfk_2` FOREIGN KEY (`subject`) REFERENCES `subject` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `purpose_ibfk_3` FOREIGN KEY (`type`) REFERENCES `types` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `teaching`
--
ALTER TABLE `teaching`
  ADD CONSTRAINT `teaching_ibfk_1` FOREIGN KEY (`class`) REFERENCES `classes` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `teaching_ibfk_2` FOREIGN KEY (`subject`) REFERENCES `subject` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `teaching_ibfk_3` FOREIGN KEY (`teacher`) REFERENCES `teachers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
