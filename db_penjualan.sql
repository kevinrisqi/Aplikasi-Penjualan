-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 10, 2019 at 11:29 AM
-- Server version: 10.1.36-MariaDB
-- PHP Version: 7.2.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_penjualan`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `id_admin` varchar(6) NOT NULL,
  `nama_admin` varchar(20) NOT NULL,
  `password_admin` varchar(20) NOT NULL,
  `level_admin` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`id_admin`, `nama_admin`, `password_admin`, `level_admin`) VALUES
('ADM001', 'admin', 'admin', 'ADMIN'),
('ADM002', 'user', 'user', 'USER'),
('ADM003', 'lidya', 'kevin', 'ADMIN'),
('ADM004', 'kevin', 'kevin', 'ADMIN'),
('ADM005', 'risqi', 'wati', 'USER'),
('ADM006', 'uus', 'uus', 'ADMIN');

-- --------------------------------------------------------

--
-- Table structure for table `barang`
--

CREATE TABLE `barang` (
  `id` int(11) NOT NULL,
  `id_barang` varchar(10) NOT NULL,
  `nama_barang` varchar(50) NOT NULL,
  `harga_beli` int(11) NOT NULL,
  `harga_jual` int(11) NOT NULL,
  `stok` int(11) NOT NULL,
  `satuan` varchar(15) NOT NULL,
  `keterangan` text NOT NULL,
  `id_kategori` int(11) NOT NULL,
  `tanggal_input` datetime NOT NULL,
  `tanggal_update` datetime NOT NULL,
  `nama_admin` varchar(35) NOT NULL,
  `ppn` enum('Ya','Tidak') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `barang`
--

INSERT INTO `barang` (`id`, `id_barang`, `nama_barang`, `harga_beli`, `harga_jual`, `stok`, `satuan`, `keterangan`, `id_kategori`, `tanggal_input`, `tanggal_update`, `nama_admin`, `ppn`) VALUES
(1, 'ANK001', 'Gurita', 2500, 5000, 34, 'pcs', 'baru', 1, '0000-00-00 00:00:00', '2019-05-10 08:57:53', 'kevin', 'Ya'),
(2, 'VAX5', 'V. AXIS 5 GB', 40000, 46000, 100, 'pcs', 'bagus', 2, '0000-00-00 00:00:00', '0000-00-00 00:00:00', '', 'Ya'),
(4, 'VAX30', 'V. AXIS 30 GB', 50000, 60000, 40, 'pcs', 'BARU', 2, '0000-00-00 00:00:00', '0000-00-00 00:00:00', '', 'Ya'),
(5, 'ANK002', 'Tempered Glass', 70000, 80000, 49, 'Pcs', 'bagus', 1, '0000-00-00 00:00:00', '2019-05-10 00:42:39', 'kevin', 'Ya'),
(6, 'ANK003', 'Case', 4000, 5000, 39, 'pcs', 'dfklsa', 1, '0000-00-00 00:00:00', '2019-05-10 00:42:43', 'kevin', 'Ya'),
(7, 'AX001', 'Axis', 4000, 5000, 50, 'Pcs', 'bagus murah', 2, '0000-00-00 00:00:00', '0000-00-00 00:00:00', '', 'Ya'),
(9, 'AX003', 'Axis 30', 5000, 6000, 10, 'packs', 'baik', 2, '0000-00-00 00:00:00', '2019-05-05 14:46:40', 'admin', 'Ya'),
(13, 'ANK004', 'screen', 6000, 7600, 35, 'pcs', 'bagus', 1, '2019-04-28 23:54:48', '2019-05-10 00:42:50', 'kevin', 'Ya'),
(14, 'ANK006', 'Case Oppo', 50000, 60000, 33, 'pcs', 'bagus', 1, '2019-05-01 14:11:11', '2019-05-10 00:42:55', 'kevin', 'Ya'),
(15, 'ANK007', 'Case Oppo', 5000, 6000, 4, 'pcs', 'PPN', 1, '2019-05-05 14:45:13', '2019-05-10 00:43:08', 'kevin', 'Ya'),
(16, 'ANK008', 'Ring', 3000, 5000, 94, 'pcs', 'bagus', 1, '2019-05-06 10:50:08', '2019-05-10 00:43:21', 'kevin', 'Ya'),
(17, 'ANK009', 'Case Samsung', 4600, 5000, 5, 'Pcs', 'bagus', 1, '2019-05-08 14:09:54', '2019-05-08 14:12:38', 'kevin', 'Ya'),
(18, 'ANK010', 'Case Vivo', 3000, 3000, 6, 'Pcs', 'bagus', 1, '2019-05-08 14:13:56', '2019-05-08 14:26:03', 'admin', 'Ya'),
(19, 'ANK011', 'Case Vivo', 4000, 4000, 5, 'Pcs', 'bagus', 1, '2019-05-08 14:25:08', '2019-05-08 14:25:48', 'admin', 'Ya'),
(20, 'ANK012', 'Temper', 5000, 6000, 5, 'Pcs', 'bagus', 1, '2019-05-09 10:04:51', '0000-00-00 00:00:00', 'admin', 'Ya'),
(21, 'ANK005', 'Ring o', 6000, 10000, 50, 'Pcs', 'bagus', 1, '2019-05-10 08:58:36', '0000-00-00 00:00:00', 'kevin', 'Ya');

-- --------------------------------------------------------

--
-- Table structure for table `detail_penjualan`
--

CREATE TABLE `detail_penjualan` (
  `id` int(11) NOT NULL,
  `id_penjualan` varchar(14) NOT NULL,
  `id_barang` varchar(10) NOT NULL,
  `nama_barang` varchar(30) NOT NULL,
  `harga_satuan` int(11) NOT NULL,
  `qty` int(11) NOT NULL,
  `subtotal` int(11) NOT NULL,
  `harga_pokok` int(11) NOT NULL,
  `diskon` int(11) NOT NULL,
  `netto` int(11) NOT NULL,
  `total_pokok` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `detail_penjualan`
--

INSERT INTO `detail_penjualan` (`id`, `id_penjualan`, `id_barang`, `nama_barang`, `harga_satuan`, `qty`, `subtotal`, `harga_pokok`, `diskon`, `netto`, `total_pokok`) VALUES
(1, 'T20190507001', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(2, 'T20190507002', 'ANK002', 'Tempered Glass', 80000, 1, 80000, 0, 0, 0, 0),
(3, 'T20190507003', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(4, 'T20190507004', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(5, 'T20190507005', 'ANK002', 'Tempered Glass', 80000, 1, 80000, 0, 0, 0, 0),
(6, 'T20190507006', 'ANK002', 'Tempered Glass', 80000, 1, 80000, 0, 0, 0, 0),
(7, 'T20190507007', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(8, 'T20190507008', 'ANK004', 'screen', 7600, 1, 7600, 0, 0, 0, 0),
(9, 'T20190507009', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(10, 'T20190508010', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(11, 'T20190508010', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(12, 'T20190508010', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(13, 'T20190508011', 'ANK002', 'Tempered Glass', 80000, 1, 80000, 0, 0, 0, 0),
(14, 'T20190508011', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(15, 'T20190508012', 'ANK002', 'Tempered Glass', 80000, 1, 80000, 0, 0, 0, 0),
(16, 'T20190508013', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(17, 'T20190508014', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(18, 'T20190509015', 'ANK002', 'Tempered Glass', 80000, 1, 80000, 0, 0, 0, 0),
(19, 'T20190509015', 'ANK002', 'Tempered Glass', 80000, 1, 80000, 0, 0, 0, 0),
(20, 'T20190509016', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(21, 'T20190509016', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(22, 'T20190509016', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(23, 'T20190509016', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(24, 'T20190509016', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(25, 'T20190509016', 'ANK002', 'Tempered Glass', 80000, 1, 80000, 0, 0, 0, 0),
(26, 'T20190509017', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(27, 'T20190509017', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(28, 'T20190509017', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(29, 'T20190509017', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(30, 'T20190509017', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(31, 'T20190509017', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(32, 'T20190509017', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(33, 'T20190509017', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(34, 'T20190509017', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(35, 'T20190509017', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(36, 'T20190509017', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(37, 'T20190509017', 'ANK001', 'Gurita', 5000, 1, 5000, 0, 0, 0, 0),
(38, 'T20190509018', 'ANK012', 'Temper', 6000, 1, 6000, 0, 0, 0, 0),
(39, 'T20190509018', 'ANK001', 'Gurita', 5000, 1, 5000, 2500, 0, 5000, 2500),
(40, 'T20190509018', 'ANK001', 'Gurita', 5000, 1, 5000, 2500, 1000, 4000, 2500),
(41, 'T20190509018', 'ANK002', 'Tempered Glass', 80000, 1, 80000, 70000, 1000, 79000, 70000),
(42, 'T20190509018', 'ANK002', 'Tempered Glass', 80000, 1, 80000, 70000, 1000, 79000, 70000),
(43, 'T20190509018', 'ANK002', 'Tempered Glass', 80000, 1, 80000, 70000, 0, 80000, 70000),
(44, 'T20190509018', 'ANK001', 'Gurita', 5000, 1, 5000, 2500, 0, 5000, 2500),
(45, 'T20190509018', 'ANK001', 'Gurita', 5000, 1, 5000, 2500, 1000, 4000, 2500),
(46, 'T20190509018', 'ANK001', 'Gurita', 5000, 1, 5000, 2500, 5000, 0, 2500),
(47, 'T20190509018', 'ANK012', 'Temper', 6000, 1, 6000, 5000, 5000, 1000, 5000),
(48, 'T20190509018', 'ANK011', 'Case Vivo', 4000, 1, 4000, 4000, 5000, -1000, 4000),
(49, 'T20190509019', 'ANK001', 'Gurita', 5000, 1, 5000, 2500, 0, 5000, 2500),
(50, 'T20190509019', 'ANK001', 'Gurita', 5000, 1, 5000, 2500, 1000, 4000, 2500),
(51, 'T20190509019', 'ANK001', 'Gurita', 5000, 1, 5000, 2500, 1000, 4000, 2500),
(52, 'T20190509019', 'ANK001', 'Gurita', 5000, 1, 5000, 2500, 1000, 4000, 2500),
(53, 'T20190509019', 'ANK001', 'Gurita', 5000, 1, 5000, 2500, 0, 5000, 2500),
(54, 'T20190509019', 'ANK002', 'Tempered Glass', 80000, 1, 80000, 70000, 0, 80000, 70000),
(55, 'T20190509019', 'ANK002', 'Tempered Glass', 80000, 1, 80000, 70000, 70000, 10000, 70000),
(56, 'T20190509020', 'ANK001', 'Gurita', 5000, 1, 5000, 2500, 0, 5000, 2500),
(57, 'T20190509021', 'ANK001', 'Gurita', 5000, 1, 5000, 2500, 0, 5000, 2500),
(58, 'T20190509021', 'ANK001', 'Gurita', 5000, 1, 5000, 2500, 0, 5000, 2500),
(59, 'T20190509021', 'ANK002', 'Tempered Glass', 80000, 50, 4000000, 70000, 0, 4000000, 3500000),
(60, 'T20190509021', 'ANK002', 'Tempered Glass', 80000, 50, 4000000, 70000, 0, 4000000, 3500000),
(61, 'T20190509022', 'ANK003', 'Case', 5000, 5, 25000, 4000, 0, 25000, 20000),
(62, 'T20190509022', 'ANK003', 'Case', 5000, 5, 25000, 4000, 0, 25000, 20000),
(63, 'T20190509022', 'ANK003', 'Case', 5000, 5, 25000, 4000, 0, 25000, 20000),
(64, 'T20190509022', 'ANK003', 'Case', 5000, 5, 25000, 4000, 0, 25000, 20000),
(65, 'T20190509022', 'ANK003', 'Case', 5000, 5, 25000, 4000, 0, 25000, 20000),
(66, 'T20190509022', 'ANK003', 'Case', 5000, 5, 25000, 4000, 0, 25000, 20000),
(67, 'T20190509022', 'ANK003', 'Case', 5000, 5, 25000, 4000, 0, 25000, 20000),
(68, 'T20190509022', 'ANK003', 'Case', 5000, 5, 25000, 4000, 0, 25000, 20000),
(69, 'T20190509022', 'ANK002', 'Tempered Glass', 80000, 1, 80000, 70000, 0, 80000, 70000),
(70, 'T20190509022', 'ANK002', 'Tempered Glass', 80000, 1, 80000, 70000, 0, 80000, 70000),
(71, 'T20190509022', 'ANK002', 'Tempered Glass', 80000, 47, 3760000, 70000, 0, 3760000, 3290000),
(72, 'T20190509022', 'ANK002', 'Tempered Glass', 80000, 1, 80000, 70000, 0, 80000, 70000),
(73, 'T20190509022', 'ANK004', 'screen', 7600, 3, 22800, 6000, 0, 22800, 18000),
(74, 'T20190509022', 'ANK006', 'Case Oppo', 60000, 4, 240000, 50000, 0, 240000, 200000),
(75, 'T20190509023', 'ANK001', 'Gurita', 5000, 1, 5000, 2500, 0, 5000, 2500),
(76, 'T20190509023', 'ANK003', 'Case', 5000, 1, 5000, 4000, 0, 5000, 4000),
(77, 'T20190509023', 'ANK003', 'Case', 5000, 1, 5000, 4000, 0, 5000, 4000),
(78, 'T20190509023', 'ANK007', 'Case Oppo', 6000, 50, 300000, 19000, 0, 300000, 950000),
(96, 'T20190510023', 'ANK001', 'Gurita', 5000, 1, 5000, 2500, 0, 5000, 2500),
(97, 'T20190510024', 'ANK001', 'Gurita', 5000, 1, 5000, 2500, 0, 5000, 2500),
(98, 'T20190510024', 'ANK002', 'Tempered Glass', 80000, 1, 80000, 70000, 0, 80000, 70000),
(99, 'T20190510024', 'ANK003', 'Case', 5000, 1, 5000, 4000, 0, 5000, 4000),
(103, 'T20190510025', 'ANK001', 'Gurita', 5000, 5, 25000, 2500, 0, 25000, 12500),
(104, 'T20190510026', 'ANK001', 'Gurita', 5000, 5, 25000, 2500, 1000, 24000, 12500),
(105, 'T20190510027', 'ANK001', 'Gurita', 5000, 1, 5000, 2500, 0, 5000, 2500);

-- --------------------------------------------------------

--
-- Table structure for table `kategori_barang`
--

CREATE TABLE `kategori_barang` (
  `id_kategori` int(11) NOT NULL,
  `nama_kategori` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `kategori_barang`
--

INSERT INTO `kategori_barang` (`id_kategori`, `nama_kategori`) VALUES
(1, 'Aksesoris'),
(2, 'Voucher'),
(3, 'Perdana'),
(4, 'Elektrik');

-- --------------------------------------------------------

--
-- Table structure for table `penjualan`
--

CREATE TABLE `penjualan` (
  `id_penjualan` varchar(14) NOT NULL,
  `tanggal` date NOT NULL,
  `jam` time NOT NULL,
  `item_jual` int(11) NOT NULL,
  `total_jual` int(11) NOT NULL,
  `total_dibayar` int(11) NOT NULL,
  `kembali` int(11) NOT NULL,
  `id_admin` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `penjualan`
--

INSERT INTO `penjualan` (`id_penjualan`, `tanggal`, `jam`, `item_jual`, `total_jual`, `total_dibayar`, `kembali`, `id_admin`) VALUES
('T20190507001', '2019-05-07', '10:35:48', 1, 5000, 5000, 0, 'ADM004'),
('T20190507002', '2019-05-07', '10:36:15', 1, 80000, 700000, 620000, 'ADM004'),
('T20190507003', '2019-05-07', '10:37:55', 1, 5000, 6000, 1000, 'ADM004'),
('T20190507004', '2019-05-07', '10:43:44', 1, 5000, 50000, 45000, 'ADM001'),
('T20190507005', '2019-05-07', '10:44:31', 1, 80000, 600000, 520000, 'ADM001'),
('T20190507006', '2019-05-07', '10:48:06', 1, 80000, 5, -79995, 'ADM004'),
('T20190507007', '2019-05-07', '10:51:22', 1, 5000, 5000, 0, 'ADM001'),
('T20190507008', '2019-05-07', '10:55:27', 1, 7600, 8000, 400, 'ADM001'),
('T20190507009', '2019-05-07', '11:00:00', 1, 5000, 50000, 45000, 'ADM001'),
('T20190508010', '2019-05-08', '01:14:20', 3, 15000, 15000, 0, 'ADM001'),
('T20190508011', '2019-05-08', '01:18:46', 2, 85000, 500000, 415000, 'ADM001'),
('T20190508012', '2019-05-08', '01:19:16', 1, 80000, 500000, 420000, 'ADM001'),
('T20190508013', '2019-05-08', '01:28:13', 1, 5000, 5000, 0, 'ADM004'),
('T20190508014', '2019-05-08', '01:57:25', 1, 5000, 5000, 0, 'ADM001'),
('T20190509015', '2019-05-09', '08:47:07', 2, 160000, 1000000, 840000, 'ADM001'),
('T20190509016', '2019-05-09', '09:20:12', 0, 105000, 1000000, 895000, 'ADM001'),
('T20190509017', '2019-05-09', '09:37:23', 12, 60000, 1000000, 940000, 'ADM001'),
('T20190509018', '2019-05-09', '03:01:18', 11, 281000, 500000, 219000, 'ADM004'),
('T20190509019', '2019-05-09', '05:37:45', 0, 112000, 200000, 88000, 'ADM004'),
('T20190509020', '2019-05-09', '05:41:32', 0, 5000, 5000, 0, 'ADM004'),
('T20190509021', '2019-05-09', '05:55:55', 0, 8010000, 500000000, 491990000, 'ADM004'),
('T20190509022', '2019-05-09', '09:58:16', 97, 4462800, 5000000, 537200, 'ADM004'),
('T20190510023', '2019-05-10', '12:44:08', 1, 5000, 10000, 5000, 'ADM004'),
('T20190510024', '2019-05-10', '12:46:17', 3, 90000, 100000, 10000, 'ADM004'),
('T20190510025', '2019-05-10', '12:50:57', 5, 25000, 26000, 1000, 'ADM004'),
('T20190510026', '2019-05-10', '12:55:05', 5, 24000, 25000, 1000, 'ADM004'),
('T20190510027', '2019-05-10', '01:31:54', 1, 5000, 6000, 1000, 'ADM004');

-- --------------------------------------------------------

--
-- Table structure for table `setup_toko`
--

CREATE TABLE `setup_toko` (
  `id` int(11) NOT NULL,
  `nama_toko` varchar(30) NOT NULL,
  `alamat_toko` varchar(70) NOT NULL,
  `telepon` varchar(13) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `setup_toko`
--

INSERT INTO `setup_toko` (`id`, `nama_toko`, `alamat_toko`, `telepon`) VALUES
(1, 'Citra Cellular 2', 'Jl Danau Sentani C4E/28', '085868473754');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id_admin`);

--
-- Indexes for table `barang`
--
ALTER TABLE `barang`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `detail_penjualan`
--
ALTER TABLE `detail_penjualan`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `kategori_barang`
--
ALTER TABLE `kategori_barang`
  ADD PRIMARY KEY (`id_kategori`);

--
-- Indexes for table `penjualan`
--
ALTER TABLE `penjualan`
  ADD PRIMARY KEY (`id_penjualan`);

--
-- Indexes for table `setup_toko`
--
ALTER TABLE `setup_toko`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `barang`
--
ALTER TABLE `barang`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `detail_penjualan`
--
ALTER TABLE `detail_penjualan`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=106;

--
-- AUTO_INCREMENT for table `kategori_barang`
--
ALTER TABLE `kategori_barang`
  MODIFY `id_kategori` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `setup_toko`
--
ALTER TABLE `setup_toko`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
