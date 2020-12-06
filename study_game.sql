-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th12 06, 2020 lúc 02:29 PM
-- Phiên bản máy phục vụ: 10.4.17-MariaDB
-- Phiên bản PHP: 8.0.0

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
-- Cấu trúc bảng cho bảng `click_rank`
--

CREATE TABLE `click_rank` (
  `id` bigint(20) NOT NULL,
  `name` text NOT NULL,
  `idclass` int(11) NOT NULL,
  `level` int(11) NOT NULL,
  `time` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `click_rank`
--

INSERT INTO `click_rank` (`id`, `name`, `idclass`, `level`, `time`) VALUES
(132512712398611046, 'phan thi kim hoa', 1, 1, '00:00:05'),
(132512712510299732, 'phan thi kim hoa', 1, 2, '00:00:09'),
(132512712746366844, 'phan thi kim hoa', 1, 3, '00:00:22'),
(132512713109855499, 'le thi ha', 1, 1, '00:00:05'),
(132512713194864490, 'le thi ha', 1, 2, '00:00:07'),
(132512713398503308, 'le thi ha', 1, 3, '00:00:19'),
(132512862608758289, 'Tran Minh', 1, 1, '00:00:38'),
(132512862765579408, 'Tran Minh', 1, 2, '00:00:12'),
(132512862938601449, 'Tran Minh', 1, 3, '00:00:16'),
(132512863294899908, 'Tran Minh', 1, 4, '00:00:34'),
(132516922936002388, 'k', 1, 1, '00:00:23'),
(132516923783112055, 'k', 1, 2, '00:01:16');

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
(132511368245232258, 'phan le', 1, 1, '00:00:08'),
(132512863610405709, 'ly thi hai', 2, 1, '00:00:10'),
(132512863744244285, 'ly thi hai', 2, 2, '00:00:10'),
(132512864082295894, 'ly thi hai', 2, 3, '00:00:28'),
(132512865422337131, 'huynh ha', 2, 1, '00:00:08');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `typedoc_rank`
--

CREATE TABLE `typedoc_rank` (
  `id` bigint(20) NOT NULL,
  `idclass` int(11) NOT NULL,
  `name` text NOT NULL,
  `time` time NOT NULL,
  `accurary` int(11) NOT NULL,
  `speed` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `typedoc_rank`
--

INSERT INTO `typedoc_rank` (`id`, `idclass`, `name`, `time`, `accurary`, `speed`) VALUES
(132517221966458343, 1, 'Minh', '00:00:11', 40, 2);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `type_rank`
--

CREATE TABLE `type_rank` (
  `id` bigint(20) NOT NULL,
  `idclass` int(11) NOT NULL,
  `name` text NOT NULL,
  `level` text NOT NULL,
  `accurary` int(11) NOT NULL,
  `speed` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `class`
--
ALTER TABLE `class`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `click_rank`
--
ALTER TABLE `click_rank`
  ADD KEY `idclass` (`idclass`);

--
-- Chỉ mục cho bảng `drag_rank`
--
ALTER TABLE `drag_rank`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idclass` (`idclass`);

--
-- Chỉ mục cho bảng `typedoc_rank`
--
ALTER TABLE `typedoc_rank`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idclass` (`idclass`);

--
-- Chỉ mục cho bảng `type_rank`
--
ALTER TABLE `type_rank`
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
-- Các ràng buộc cho bảng `click_rank`
--
ALTER TABLE `click_rank`
  ADD CONSTRAINT `click_rank_ibfk_1` FOREIGN KEY (`idclass`) REFERENCES `class` (`id`);

--
-- Các ràng buộc cho bảng `drag_rank`
--
ALTER TABLE `drag_rank`
  ADD CONSTRAINT `drag_rank_ibfk_1` FOREIGN KEY (`idclass`) REFERENCES `class` (`id`);

--
-- Các ràng buộc cho bảng `typedoc_rank`
--
ALTER TABLE `typedoc_rank`
  ADD CONSTRAINT `typedoc_rank_ibfk_1` FOREIGN KEY (`idclass`) REFERENCES `class` (`id`);

--
-- Các ràng buộc cho bảng `type_rank`
--
ALTER TABLE `type_rank`
  ADD CONSTRAINT `type_rank_ibfk_1` FOREIGN KEY (`idclass`) REFERENCES `class` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
