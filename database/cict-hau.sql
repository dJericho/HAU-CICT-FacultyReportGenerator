-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Sep 12, 2017 at 12:02 AM
-- Server version: 10.1.19-MariaDB
-- PHP Version: 7.0.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cict-hau`
--

-- --------------------------------------------------------

--
-- Table structure for table `classifications`
--

CREATE TABLE `classifications` (
  `id` int(10) UNSIGNED NOT NULL,
  `classification` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `classifications`
--

INSERT INTO `classifications` (`id`, `classification`) VALUES
(3, 'BSCS'),
(4, 'BSIT-ANIMATION'),
(5, 'BSIT-WEBDEV'),
(6, 'BSIT-NETWORKING'),
(7, 'ALL COURSES');

-- --------------------------------------------------------

--
-- Table structure for table `faculty`
--

CREATE TABLE `faculty` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `undergrad` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `postgrad` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `roleId` int(10) UNSIGNED NOT NULL,
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `faculty`
--

INSERT INTO `faculty` (`id`, `name`, `undergrad`, `postgrad`, `roleId`, `password`) VALUES
(1, 'Joshua Jimenez', 'BS Computer Science, HAU', 'Master of Computer Science, HAU', 1, 'secret'),
(2, 'Jericho Diaz', 'BS Computer Science, HAU', '', 2, 'secret');

-- --------------------------------------------------------

--
-- Table structure for table `facultyloads`
--

CREATE TABLE `facultyloads` (
  `id` int(10) UNSIGNED NOT NULL,
  `facultyId` int(10) UNSIGNED NOT NULL,
  `subjectId` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `facultyloads`
--

INSERT INTO `facultyloads` (`id`, `facultyId`, `subjectId`) VALUES
(2, 1, 2),
(1, 1, 3),
(3, 2, 4),
(4, 2, 5);

-- --------------------------------------------------------

--
-- Table structure for table `roles`
--

CREATE TABLE `roles` (
  `id` int(10) UNSIGNED NOT NULL,
  `roleName` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `roles`
--

INSERT INTO `roles` (`id`, `roleName`) VALUES
(1, 'ADMIN'),
(2, 'FACULTY');

-- --------------------------------------------------------

--
-- Table structure for table `seminars`
--

CREATE TABLE `seminars` (
  `id` int(10) UNSIGNED NOT NULL,
  `seminarName` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `seminarType` int(10) UNSIGNED NOT NULL,
  `classificationId` int(10) UNSIGNED NOT NULL,
  `venue` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `seminars`
--

INSERT INTO `seminars` (`id`, `seminarName`, `seminarType`, `classificationId`, `venue`, `date`) VALUES
(1, 'Cisco Networking Academy Partner Conference', 5, 5, 'The Manor, Baguio City', '2017-09-13'),
(2, 'Training on Good Research Practice(CLHRDC)', 6, 6, 'PGN HAU', '2017-09-10');

-- --------------------------------------------------------

--
-- Table structure for table `seminarsattendance`
--

CREATE TABLE `seminarsattendance` (
  `id` int(10) UNSIGNED NOT NULL,
  `facultyId` int(10) UNSIGNED NOT NULL,
  `seminarId` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `seminarsattendance`
--

INSERT INTO `seminarsattendance` (`id`, `facultyId`, `seminarId`) VALUES
(1, 1, 1),
(4, 2, 1),
(2, 1, 2);

-- --------------------------------------------------------

--
-- Table structure for table `seminartypes`
--

CREATE TABLE `seminartypes` (
  `id` int(10) UNSIGNED NOT NULL,
  `type` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `seminartypes`
--

INSERT INTO `seminartypes` (`id`, `type`) VALUES
(5, 'HRD/ARO (NONMAJOR)'),
(6, 'WORKSHOP'),
(7, 'TALK');

-- --------------------------------------------------------

--
-- Table structure for table `subjects`
--

CREATE TABLE `subjects` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `classificationId` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `subjects`
--

INSERT INTO `subjects` (`id`, `name`, `classificationId`) VALUES
(1, '6COMPRO3L', 7),
(2, '6WEBTECH3', 5),
(3, '6ROUTING', 6),
(4, '6BDRAW', 4),
(5, '6COMPRO3L', 3);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `classifications`
--
ALTER TABLE `classifications`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `faculty`
--
ALTER TABLE `faculty`
  ADD PRIMARY KEY (`id`),
  ADD KEY `faculty_roleid_foreign` (`roleId`);

--
-- Indexes for table `facultyloads`
--
ALTER TABLE `facultyloads`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `facultyloads` (`subjectId`,`facultyId`),
  ADD KEY `facultyloads_facultyid_foreign` (`facultyId`);

--
-- Indexes for table `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `seminars`
--
ALTER TABLE `seminars`
  ADD PRIMARY KEY (`id`),
  ADD KEY `seminars_seminartype_foreign` (`seminarType`),
  ADD KEY `seminars_classificationid_foreign` (`classificationId`);

--
-- Indexes for table `seminarsattendance`
--
ALTER TABLE `seminarsattendance`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `seminarsattendance` (`seminarId`,`facultyId`),
  ADD KEY `seminarsattendance_facultyid_foreign` (`facultyId`);

--
-- Indexes for table `seminartypes`
--
ALTER TABLE `seminartypes`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `subjects`
--
ALTER TABLE `subjects`
  ADD PRIMARY KEY (`id`),
  ADD KEY `subjects_classificationid_foreign` (`classificationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `classifications`
--
ALTER TABLE `classifications`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `faculty`
--
ALTER TABLE `faculty`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `facultyloads`
--
ALTER TABLE `facultyloads`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `roles`
--
ALTER TABLE `roles`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `seminars`
--
ALTER TABLE `seminars`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `seminarsattendance`
--
ALTER TABLE `seminarsattendance`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `seminartypes`
--
ALTER TABLE `seminartypes`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `subjects`
--
ALTER TABLE `subjects`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `faculty`
--
ALTER TABLE `faculty`
  ADD CONSTRAINT `faculty_roleid_foreign` FOREIGN KEY (`roleId`) REFERENCES `roles` (`id`) ON DELETE CASCADE;

--
-- Constraints for table `facultyloads`
--
ALTER TABLE `facultyloads`
  ADD CONSTRAINT `facultyloads_facultyid_foreign` FOREIGN KEY (`facultyId`) REFERENCES `faculty` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `facultyloads_subjectid_foreign` FOREIGN KEY (`subjectId`) REFERENCES `subjects` (`id`) ON DELETE CASCADE;

--
-- Constraints for table `seminars`
--
ALTER TABLE `seminars`
  ADD CONSTRAINT `seminars_classificationid_foreign` FOREIGN KEY (`classificationId`) REFERENCES `classifications` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `seminars_seminartype_foreign` FOREIGN KEY (`seminarType`) REFERENCES `seminartypes` (`id`) ON DELETE CASCADE;

--
-- Constraints for table `seminarsattendance`
--
ALTER TABLE `seminarsattendance`
  ADD CONSTRAINT `seminarsattendance_facultyid_foreign` FOREIGN KEY (`facultyId`) REFERENCES `faculty` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `seminarsattendance_seminarid_foreign` FOREIGN KEY (`seminarId`) REFERENCES `seminars` (`id`) ON DELETE CASCADE;

--
-- Constraints for table `subjects`
--
ALTER TABLE `subjects`
  ADD CONSTRAINT `subjects_classificationid_foreign` FOREIGN KEY (`classificationId`) REFERENCES `classifications` (`id`) ON DELETE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
