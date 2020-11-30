-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th10 30, 2020 lúc 01:29 AM
-- Phiên bản máy phục vụ: 10.4.16-MariaDB
-- Phiên bản PHP: 7.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `study_game`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `class`
--

CREATE TABLE `class` (
  `id` int(5) NOT NULL,
  `class` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `class`
--

INSERT INTO `class` (`id`, `class`) VALUES
(1, '3a'),
(2, '3b'),
(3, '3c'),
(4, '3d');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `drag_rank`
--

CREATE TABLE `drag_rank` (
  `id` bigint(20) NOT NULL,
  `name` text NOT NULL,
  `idclass` int(11) NOT NULL,
  `level` int(11) NOT NULL,
  `time` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `drag_rank`
--

INSERT INTO `drag_rank` (`id`, `name`, `idclass`, `level`, `time`) VALUES
(132510910185290627, 'minh', 1, 3, '00:00:04'),
(132510910971326865, 'tran thi my kim', 1, 3, '00:00:05'),
(132510917029191186, 'tran minh', 1, 3, '00:04:34'),
(132510917324774274, 'le la loi loc', 1, 2, '00:00:08'),
(132510922550740361, 'le thi la', 1, 3, '00:00:02'),
(132510936390198886, 'phan thi kim hoa', 1, 1, '00:00:05'),
(132510936546529571, 'phan thi kim hoa', 1, 2, '00:00:12'),
(132510936923046799, 'phan thi kim hoa', 1, 3, '00:00:34'),
(132511368245232258, 'phan le', 1, 1, '00:00:08');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `class`
--
ALTER TABLE `class`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `drag_rank`
--
ALTER TABLE `drag_rank`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idclass` (`idclass`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `class`
--
ALTER TABLE `class`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `drag_rank`
--
ALTER TABLE `drag_rank`
  ADD CONSTRAINT `drag_rank_ibfk_1` FOREIGN KEY (`idclass`) REFERENCES `class` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
