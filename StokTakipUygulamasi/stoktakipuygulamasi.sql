-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1:3306
-- Üretim Zamanı: 21 Eyl 2020, 13:22:37
-- Sunucu sürümü: 10.5.4-MariaDB
-- PHP Sürümü: 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `stoktakipuygulamasi`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `altyetkiler`
--

DROP TABLE IF EXISTS `altyetkiler`;
CREATE TABLE IF NOT EXISTS `altyetkiler` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Yetki` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Yetki_UNIQUE` (`Yetki`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `calisanlar`
--

DROP TABLE IF EXISTS `calisanlar`;
CREATE TABLE IF NOT EXISTS `calisanlar` (
  `ID` int(11) NOT NULL DEFAULT 0,
  `Ad` varchar(45) COLLATE utf8_turkish_ci NOT NULL,
  `Soyad` varchar(45) COLLATE utf8_turkish_ci NOT NULL,
  `TC` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `Kadi` varchar(45) COLLATE utf8_turkish_ci NOT NULL,
  `Sifre` varchar(45) COLLATE utf8_turkish_ci NOT NULL,
  `Foto` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Adres` text COLLATE utf8_turkish_ci NOT NULL,
  `Silindi_Mi` tinyint(4) DEFAULT 0,
  `Silinme_Aciklamasi` longtext COLLATE utf8_turkish_ci DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Kadi_UNIQUE` (`Kadi`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `calisan_bilgileri`
--

DROP TABLE IF EXISTS `calisan_bilgileri`;
CREATE TABLE IF NOT EXISTS `calisan_bilgileri` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Tel` varchar(10) COLLATE utf8_turkish_ci NOT NULL,
  `E-mail` varchar(45) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Calisan_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`,`Calisan_ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  UNIQUE KEY `Tel_UNIQUE` (`Tel`),
  KEY `fk_Calisan_Bilgileri_Calisan1_idx` (`Calisan_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `calisan_indirimdekiler`
--

DROP TABLE IF EXISTS `calisan_indirimdekiler`;
CREATE TABLE IF NOT EXISTS `calisan_indirimdekiler` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Guncelleme_Tarihi` datetime DEFAULT NULL,
  `Calisanlar_ID` int(11) NOT NULL,
  `Indirimdekiler_ID` int(11) NOT NULL,
  `Indirimdekiler_Urunler_ID` int(11) NOT NULL,
  `Indirimdekiler_Urunler_Olcu_Birimi_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`,`Calisanlar_ID`,`Indirimdekiler_ID`,`Indirimdekiler_Urunler_ID`,`Indirimdekiler_Urunler_Olcu_Birimi_ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `fk_Calisan_Indirimdekiler_Calisanlar1_idx` (`Calisanlar_ID`),
  KEY `fk_Calisan_Indirimdekiler_Indirimdekiler1_idx` (`Indirimdekiler_ID`,`Indirimdekiler_Urunler_ID`,`Indirimdekiler_Urunler_Olcu_Birimi_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `calisan_yetki`
--

DROP TABLE IF EXISTS `calisan_yetki`;
CREATE TABLE IF NOT EXISTS `calisan_yetki` (
  `Yetki_ID` int(11) NOT NULL,
  `Calisan_ID` int(11) NOT NULL,
  PRIMARY KEY (`Yetki_ID`,`Calisan_ID`),
  KEY `fk_Yetki_has_Calisan_Calisan1_idx` (`Calisan_ID`),
  KEY `fk_Yetki_has_Calisan_Yetki1_idx` (`Yetki_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `cirolar`
--

DROP TABLE IF EXISTS `cirolar`;
CREATE TABLE IF NOT EXISTS `cirolar` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Gelir` int(11) DEFAULT NULL,
  `Gider` int(11) DEFAULT NULL,
  `Tarih` date DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `faturalar`
--

DROP TABLE IF EXISTS `faturalar`;
CREATE TABLE IF NOT EXISTS `faturalar` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Fatura_No` varchar(45) NOT NULL,
  `Tarih` datetime DEFAULT NULL,
  `musteriler_ID` int(11) DEFAULT NULL,
  `toptancilar_ID` int(11) DEFAULT NULL,
  `İslem_Tarihi` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Fatura_No_UNIQUE` (`Fatura_No`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `fk_faturalar_toptancilar1_idx` (`toptancilar_ID`),
  KEY `fk_Faturalar_musteriler1_idx` (`musteriler_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `hesap_turu`
--

DROP TABLE IF EXISTS `hesap_turu`;
CREATE TABLE IF NOT EXISTS `hesap_turu` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Hesap_Turu` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `indirimdekiler`
--

DROP TABLE IF EXISTS `indirimdekiler`;
CREATE TABLE IF NOT EXISTS `indirimdekiler` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Baslangic_Tarihi` date DEFAULT NULL,
  `Bitis_Tarihi` date DEFAULT NULL,
  `Yuzde` int(11) DEFAULT NULL,
  `Satis_Fiyati` int(11) DEFAULT NULL,
  `Indirimde_mi` tinyint(4) DEFAULT 1,
  `Urunler_ID` int(11) NOT NULL,
  `Urunler_Olcu_Birimi_ID` int(11) NOT NULL,
  `Indirim_Taban_Fiyati` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`,`Urunler_ID`,`Urunler_Olcu_Birimi_ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `fk_Indirimdekiler_Urunler1_idx` (`Urunler_ID`,`Urunler_Olcu_Birimi_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kategoriler`
--

DROP TABLE IF EXISTS `kategoriler`;
CREATE TABLE IF NOT EXISTS `kategoriler` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Kategori_Adi` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  UNIQUE KEY `Kategori_Adi_UNIQUE` (`Kategori_Adi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `musteriler`
--

DROP TABLE IF EXISTS `musteriler`;
CREATE TABLE IF NOT EXISTS `musteriler` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Musteri_No` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `Musteri_Adi` varchar(45) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Musteri_Soyadi` varchar(45) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Vergi_Dairesi` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Vergi_No` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `E_mail` varchar(50) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Musteri_Grubu_ID` int(11) NOT NULL,
  `Silindi_Mi` tinyint(4) DEFAULT 0,
  `Silinme_Aciklamasi` longtext COLLATE utf8_turkish_ci DEFAULT NULL,
  PRIMARY KEY (`ID`,`Musteri_Grubu_ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  UNIQUE KEY `Musteri_No` (`Musteri_No`),
  KEY `fk_Musteri_Musteri_Grubu1_idx` (`Musteri_Grubu_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `musteri_bilgileri`
--

DROP TABLE IF EXISTS `musteri_bilgileri`;
CREATE TABLE IF NOT EXISTS `musteri_bilgileri` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Adres` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Is_Tel` varchar(10) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Cep_Tel` varchar(10) COLLATE utf8_turkish_ci NOT NULL,
  `Fax_No` varchar(45) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Musteri_ID` int(11) NOT NULL,
  `Musteri_Grubu_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`,`Musteri_ID`,`Musteri_Grubu_ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  UNIQUE KEY `Cep_Tel_UNIQUE` (`Cep_Tel`),
  KEY `fk_Musteri_Bilgileri_Musteri1_idx` (`Musteri_ID`,`Musteri_Grubu_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `musteri_grubu`
--

DROP TABLE IF EXISTS `musteri_grubu`;
CREATE TABLE IF NOT EXISTS `musteri_grubu` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Musteri_Grubu` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  UNIQUE KEY `Musteri_Grubu_UNIQUE` (`Musteri_Grubu`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `olcu_birimi`
--

DROP TABLE IF EXISTS `olcu_birimi`;
CREATE TABLE IF NOT EXISTS `olcu_birimi` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Olcu_Birimi` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  UNIQUE KEY `Olcu_Birimi_UNIQUE` (`Olcu_Birimi`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `stok`
--

DROP TABLE IF EXISTS `stok`;
CREATE TABLE IF NOT EXISTS `stok` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Eldeki_Miktar` int(11) DEFAULT NULL,
  `Toplam_Giris` int(11) DEFAULT NULL,
  `Toplam_Cikis` int(11) DEFAULT NULL,
  `Urun_ID` int(11) NOT NULL,
  `Urun_Olcu_Birimi_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`,`Urun_ID`,`Urun_Olcu_Birimi_ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `fk_Stok_Urun1_idx` (`Urun_ID`,`Urun_Olcu_Birimi_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `toptancilar`
--

DROP TABLE IF EXISTS `toptancilar`;
CREATE TABLE IF NOT EXISTS `toptancilar` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Toptanci_Adi` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Adres` text COLLATE utf8_turkish_ci DEFAULT NULL,
  `Silindi_Mi` tinyint(4) DEFAULT 0,
  `Silinme_Aciklamasi` longtext COLLATE utf8_turkish_ci DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `toptanci_bilgileri`
--

DROP TABLE IF EXISTS `toptanci_bilgileri`;
CREATE TABLE IF NOT EXISTS `toptanci_bilgileri` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Cep_Tel` varchar(10) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Ev_Tel` varchar(10) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Fax_No` varchar(45) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Toptanci_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`,`Toptanci_ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `fk_Toptanci_Bilgileri_Toptanci1_idx` (`Toptanci_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urunler`
--

DROP TABLE IF EXISTS `urunler`;
CREATE TABLE IF NOT EXISTS `urunler` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Urun_Adi` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `Barkod_No` varchar(45) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Aciklama` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `KDV_Orani` int(11) DEFAULT NULL,
  `Kar_Orani` int(11) DEFAULT NULL,
  `Satis_Fiyati` int(11) DEFAULT NULL,
  `Olcu_Birimi_ID` int(11) NOT NULL,
  `Satista_mi` tinyint(4) DEFAULT 1,
  `Olcu_Miktar` varchar(45) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Resim` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Silindi_Mi` tinyint(4) DEFAULT 0,
  `Silinme_Aciklamasi` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Kritik_Durum` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`,`Olcu_Birimi_ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  UNIQUE KEY `Barkod_No_UNIQUE` (`Barkod_No`),
  KEY `fk_Urun_Olcu_Birimi1_idx` (`Olcu_Birimi_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urun_alis`
--

DROP TABLE IF EXISTS `urun_alis`;
CREATE TABLE IF NOT EXISTS `urun_alis` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Alis_Fiyati` int(11) DEFAULT NULL,
  `Adet` int(11) DEFAULT NULL,
  `Alis_Zamani` datetime DEFAULT NULL,
  `Toptanci_ID` int(11) NOT NULL,
  `Urun_ID` int(11) NOT NULL,
  `Urun_Olcu_Birimi_ID` int(11) NOT NULL,
  `Calisan_ID` int(11) NOT NULL,
  `urun_aliscol` varchar(45) COLLATE utf8_turkish_ci DEFAULT NULL,
  `faturalar_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`,`Toptanci_ID`,`Urun_ID`,`Urun_Olcu_Birimi_ID`,`Calisan_ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `fk_Urun_Alis_Toptanci1_idx` (`Toptanci_ID`),
  KEY `fk_Urun_Alis_Urun1_idx` (`Urun_ID`,`Urun_Olcu_Birimi_ID`),
  KEY `fk_Urun_Alis_Calisan1_idx` (`Calisan_ID`),
  KEY `fk_urun_alis_faturalar1_idx` (`faturalar_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urun_kategori`
--

DROP TABLE IF EXISTS `urun_kategori`;
CREATE TABLE IF NOT EXISTS `urun_kategori` (
  `Kategori_ID` int(11) NOT NULL,
  `Urun_ID` int(11) NOT NULL,
  PRIMARY KEY (`Kategori_ID`,`Urun_ID`),
  KEY `fk_Kategori_has_Urun_Urun1_idx` (`Urun_ID`),
  KEY `fk_Kategori_has_Urun_Kategori1_idx` (`Kategori_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urun_satis`
--

DROP TABLE IF EXISTS `urun_satis`;
CREATE TABLE IF NOT EXISTS `urun_satis` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Adet` int(11) DEFAULT NULL,
  `Fiyat` int(11) DEFAULT NULL,
  `Urun_ID` int(11) NOT NULL,
  `Urun_Olcu_Birimi_ID` int(11) NOT NULL,
  `Calisan_ID` int(11) NOT NULL,
  `Faturalar_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`,`Urun_ID`,`Urun_Olcu_Birimi_ID`,`Calisan_ID`,`Faturalar_ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `fk_Urun_Satis_Urun1_idx` (`Urun_ID`,`Urun_Olcu_Birimi_ID`),
  KEY `fk_Urun_Satis_Calisan1_idx` (`Calisan_ID`),
  KEY `fk_urun_satis_Faturalar2_idx` (`Faturalar_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urun_siparis`
--

DROP TABLE IF EXISTS `urun_siparis`;
CREATE TABLE IF NOT EXISTS `urun_siparis` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Adet` varchar(45) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Siparis_Tarihi` varchar(45) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Urun_ID` int(11) NOT NULL,
  `Urun_Olcu_Birimi_ID` int(11) NOT NULL,
  `Toptanci_ID` int(11) NOT NULL,
  `Calisan_ID` int(11) NOT NULL,
  `Silindi_Mi` tinyint(4) DEFAULT 0,
  `Silinme_Aciklamasi` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  PRIMARY KEY (`ID`,`Urun_ID`,`Urun_Olcu_Birimi_ID`,`Toptanci_ID`,`Calisan_ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `fk_Urun_Siparis_Urun1_idx` (`Urun_ID`,`Urun_Olcu_Birimi_ID`),
  KEY `fk_Urun_Siparis_Toptanci1_idx` (`Toptanci_ID`),
  KEY `fk_Urun_Siparis_Calisan1_idx` (`Calisan_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `veresiye`
--

DROP TABLE IF EXISTS `veresiye`;
CREATE TABLE IF NOT EXISTS `veresiye` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Para_Turu` varchar(45) COLLATE utf8_turkish_ci DEFAULT '₺',
  `Son_Odeme_Tarihi` date DEFAULT NULL,
  `Gun` int(11) DEFAULT NULL,
  `Toplam_Bakiye` int(11) DEFAULT NULL,
  `Musteri_ID` int(11) DEFAULT NULL,
  `Calisan_ID` int(11) DEFAULT NULL,
  `toptancilar_ID` int(11) DEFAULT NULL,
  `faturalar_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`,`faturalar_ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `fk_Veresiye_Calisan1_idx` (`Calisan_ID`),
  KEY `fk_veresiye_toptancilar1_idx` (`toptancilar_ID`),
  KEY `fk_veresiye_faturalar1_idx` (`faturalar_ID`),
  KEY `fk_Veresiye_Musteri1_idx` (`Musteri_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `veresiye_detay`
--

DROP TABLE IF EXISTS `veresiye_detay`;
CREATE TABLE IF NOT EXISTS `veresiye_detay` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Aciklama` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Islem_Turu` varchar(45) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Borc` int(11) DEFAULT NULL,
  `Tahsilat` int(11) DEFAULT NULL,
  `Veresiye_ID` int(11) NOT NULL,
  `Islem_Tarihi` datetime DEFAULT NULL,
  `Calisan_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`,`Veresiye_ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `fk_Veresiye_Detay_Veresiye1_idx` (`Veresiye_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `yetkiler`
--

DROP TABLE IF EXISTS `yetkiler`;
CREATE TABLE IF NOT EXISTS `yetkiler` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Yetki_Kodu` varchar(45) COLLATE utf8_turkish_ci NOT NULL,
  `Yetki` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Yeki_Kodu_UNIQUE` (`Yetki_Kodu`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  UNIQUE KEY `Yetki_UNIQUE` (`Yetki`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `yetkiler_altyetkiler`
--

DROP TABLE IF EXISTS `yetkiler_altyetkiler`;
CREATE TABLE IF NOT EXISTS `yetkiler_altyetkiler` (
  `Yetkiler_ID` int(11) NOT NULL,
  `AltYetkiler_ID` int(11) NOT NULL,
  PRIMARY KEY (`Yetkiler_ID`,`AltYetkiler_ID`),
  KEY `fk_Yetkiler_has_AltYetkiler_AltYetkiler1_idx` (`AltYetkiler_ID`),
  KEY `fk_Yetkiler_has_AltYetkiler_Yetkiler1_idx` (`Yetkiler_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Dökümü yapılmış tablolar için kısıtlamalar
--

--
-- Tablo kısıtlamaları `calisan_bilgileri`
--
ALTER TABLE `calisan_bilgileri`
  ADD CONSTRAINT `fk_Calisan_Bilgileri_Calisan1` FOREIGN KEY (`Calisan_ID`) REFERENCES `calisanlar` (`ID`);

--
-- Tablo kısıtlamaları `calisan_indirimdekiler`
--
ALTER TABLE `calisan_indirimdekiler`
  ADD CONSTRAINT `fk_Calisan_Indirimdekiler_Calisanlar1` FOREIGN KEY (`Calisanlar_ID`) REFERENCES `calisanlar` (`ID`),
  ADD CONSTRAINT `fk_Calisan_Indirimdekiler_Indirimdekiler1` FOREIGN KEY (`Indirimdekiler_ID`,`Indirimdekiler_Urunler_ID`,`Indirimdekiler_Urunler_Olcu_Birimi_ID`) REFERENCES `indirimdekiler` (`ID`, `Urunler_ID`, `Urunler_Olcu_Birimi_ID`);

--
-- Tablo kısıtlamaları `calisan_yetki`
--
ALTER TABLE `calisan_yetki`
  ADD CONSTRAINT `fk_Yetki_has_Calisan_Calisan1` FOREIGN KEY (`Calisan_ID`) REFERENCES `calisanlar` (`ID`),
  ADD CONSTRAINT `fk_Yetki_has_Calisan_Yetki1` FOREIGN KEY (`Yetki_ID`) REFERENCES `yetkiler` (`ID`);

--
-- Tablo kısıtlamaları `faturalar`
--
ALTER TABLE `faturalar`
  ADD CONSTRAINT `fk_Faturalar_musteriler1` FOREIGN KEY (`musteriler_ID`) REFERENCES `musteriler` (`ID`),
  ADD CONSTRAINT `fk_faturalar_toptancilar1` FOREIGN KEY (`toptancilar_ID`) REFERENCES `toptancilar` (`ID`);

--
-- Tablo kısıtlamaları `indirimdekiler`
--
ALTER TABLE `indirimdekiler`
  ADD CONSTRAINT `fk_Indirimdekiler_Urunler1` FOREIGN KEY (`Urunler_ID`,`Urunler_Olcu_Birimi_ID`) REFERENCES `urunler` (`ID`, `Olcu_Birimi_ID`);

--
-- Tablo kısıtlamaları `musteriler`
--
ALTER TABLE `musteriler`
  ADD CONSTRAINT `fk_Musteri_Musteri_Grubu1` FOREIGN KEY (`Musteri_Grubu_ID`) REFERENCES `musteri_grubu` (`ID`);

--
-- Tablo kısıtlamaları `musteri_bilgileri`
--
ALTER TABLE `musteri_bilgileri`
  ADD CONSTRAINT `fk_Musteri_Bilgileri_Musteri1` FOREIGN KEY (`Musteri_ID`,`Musteri_Grubu_ID`) REFERENCES `musteriler` (`ID`, `Musteri_Grubu_ID`);

--
-- Tablo kısıtlamaları `stok`
--
ALTER TABLE `stok`
  ADD CONSTRAINT `fk_Stok_Urun1` FOREIGN KEY (`Urun_ID`) REFERENCES `urunler` (`ID`);

--
-- Tablo kısıtlamaları `toptanci_bilgileri`
--
ALTER TABLE `toptanci_bilgileri`
  ADD CONSTRAINT `fk_Toptanci_Bilgileri_Toptanci1` FOREIGN KEY (`Toptanci_ID`) REFERENCES `toptancilar` (`ID`);

--
-- Tablo kısıtlamaları `urunler`
--
ALTER TABLE `urunler`
  ADD CONSTRAINT `fk_Urun_Olcu_Birimi1` FOREIGN KEY (`Olcu_Birimi_ID`) REFERENCES `olcu_birimi` (`ID`);

--
-- Tablo kısıtlamaları `urun_alis`
--
ALTER TABLE `urun_alis`
  ADD CONSTRAINT `fk_Urun_Alis_Calisan1` FOREIGN KEY (`Calisan_ID`) REFERENCES `calisanlar` (`ID`),
  ADD CONSTRAINT `fk_Urun_Alis_Toptanci1` FOREIGN KEY (`Toptanci_ID`) REFERENCES `toptancilar` (`ID`),
  ADD CONSTRAINT `fk_Urun_Alis_Urun1` FOREIGN KEY (`Urun_ID`) REFERENCES `urunler` (`ID`),
  ADD CONSTRAINT `fk_urun_alis_faturalar1` FOREIGN KEY (`faturalar_ID`) REFERENCES `faturalar` (`ID`);

--
-- Tablo kısıtlamaları `urun_kategori`
--
ALTER TABLE `urun_kategori`
  ADD CONSTRAINT `fk_Kategori_has_Urun_Kategori1` FOREIGN KEY (`Kategori_ID`) REFERENCES `kategoriler` (`ID`),
  ADD CONSTRAINT `fk_Kategori_has_Urun_Urun1` FOREIGN KEY (`Urun_ID`) REFERENCES `urunler` (`ID`);

--
-- Tablo kısıtlamaları `urun_satis`
--
ALTER TABLE `urun_satis`
  ADD CONSTRAINT `fk_Urun_Satis_Calisan1` FOREIGN KEY (`Calisan_ID`) REFERENCES `calisanlar` (`ID`),
  ADD CONSTRAINT `fk_Urun_Satis_Urun1` FOREIGN KEY (`Urun_ID`) REFERENCES `urunler` (`ID`),
  ADD CONSTRAINT `fk_urun_satis_Faturalar2` FOREIGN KEY (`Faturalar_ID`) REFERENCES `faturalar` (`ID`);

--
-- Tablo kısıtlamaları `urun_siparis`
--
ALTER TABLE `urun_siparis`
  ADD CONSTRAINT `fk_Urun_Siparis_Calisan1` FOREIGN KEY (`Calisan_ID`) REFERENCES `calisanlar` (`ID`),
  ADD CONSTRAINT `fk_Urun_Siparis_Toptanci1` FOREIGN KEY (`Toptanci_ID`) REFERENCES `toptancilar` (`ID`),
  ADD CONSTRAINT `fk_Urun_Siparis_Urun1` FOREIGN KEY (`Urun_ID`) REFERENCES `urunler` (`ID`);

--
-- Tablo kısıtlamaları `veresiye`
--
ALTER TABLE `veresiye`
  ADD CONSTRAINT `fk_Veresiye_Calisan1` FOREIGN KEY (`Calisan_ID`) REFERENCES `calisanlar` (`ID`),
  ADD CONSTRAINT `fk_veresiye_faturalar1` FOREIGN KEY (`faturalar_ID`) REFERENCES `faturalar` (`ID`),
  ADD CONSTRAINT `fk_veresiye_toptancilar1` FOREIGN KEY (`toptancilar_ID`) REFERENCES `toptancilar` (`ID`);

--
-- Tablo kısıtlamaları `veresiye_detay`
--
ALTER TABLE `veresiye_detay`
  ADD CONSTRAINT `fk_Veresiye_Detay_Veresiye1` FOREIGN KEY (`Veresiye_ID`) REFERENCES `veresiye` (`ID`);

--
-- Tablo kısıtlamaları `yetkiler_altyetkiler`
--
ALTER TABLE `yetkiler_altyetkiler`
  ADD CONSTRAINT `fk_Yetkiler_has_AltYetkiler_AltYetkiler1` FOREIGN KEY (`AltYetkiler_ID`) REFERENCES `altyetkiler` (`ID`),
  ADD CONSTRAINT `fk_Yetkiler_has_AltYetkiler_Yetkiler1` FOREIGN KEY (`Yetkiler_ID`) REFERENCES `yetkiler` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
