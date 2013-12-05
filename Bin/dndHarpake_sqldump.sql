-- MySQL dump 10.13  Distrib 5.1.69, for redhat-linux-gnu (i386)
--
-- Host: mysql.labranet.jamk.fi    Database: G2776
-- ------------------------------------------------------
-- Server version	5.1.69

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `encounter`
--

DROP TABLE IF EXISTS `encounter`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `encounter` (
  `encounterID` int(11) NOT NULL AUTO_INCREMENT,
  `user_userID` int(11) NOT NULL,
  `encounterName` text,
  `encounterDesc` text,
  `encounterMonsters` text,
  `encounterExp` text,
  `encounterLevel` text,
  PRIMARY KEY (`encounterID`),
  KEY `fk_encounter_user_idx` (`user_userID`),
  CONSTRAINT `fk_encounter_user` FOREIGN KEY (`user_userID`) REFERENCES `user` (`userID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `encounter`
--

LOCK TABLES `encounter` WRITE;
/*!40000 ALTER TABLE `encounter` DISABLE KEYS */;
INSERT INTO `encounter` VALUES (1,1,'Ebin taistelu','Lohikärmes hwaiting','Young Black Dragon','875','4'),(2,1,'Hurja taisto','Ylläri lohari nurkan takaa','Young Black Dragon','875','3'),(3,1,'Hurja tappelu',':<','Young Black Dragon','875','4'),(4,3,'Uusi kohtaaminen','asdasd','nimi||erinimi|nimi',NULL,'4'),(5,3,'Salmonsnake Battle','wow such epic','Young Black Dragon||Young Black Dragon 2',NULL,'4'),(6,4,'Goblin Ambush','Archerit ja Sentryt väyjyttävät ryhmän, Blackblade liittyy taisteluun ryhmän takaa 1 kierroksen kuluttua','||Goblin Sentry|Goblin Blackblade|Goblin Archer|Goblin Archer|Goblin Sentry|',NULL,'1'),(7,4,'Lurkkereiden Kokoontuminen','Lurkkerit lurkkaa suolla','|||Goblin Blackblade||||Goblin Blackblade|Goblin Blackblade|Young Black Dragon|',NULL,'4');
/*!40000 ALTER TABLE `encounter` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `userID` int(11) NOT NULL AUTO_INCREMENT,
  `userName` text NOT NULL,
  `userEmail` text,
  `userPassword` text NOT NULL,
  PRIMARY KEY (`userID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'user','user@email.com','pass'),(2,'admin','admin@admin,admin','123'),(3,'Deaddis','deaddis@hotmail.com','12a81f70801a236871edc960dfba56cbad9503e5daec9f5527bae2c050e8eb61%'),(4,'Bulltrick','bulltrick@win.com','075a421a01fe4984b4ade4a89afec861f9a435f54b5bced6d0a0e5a8792e521c');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-12-05  8:07:00
