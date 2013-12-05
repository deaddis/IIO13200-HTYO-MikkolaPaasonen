SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `G2776` DEFAULT CHARACTER SET latin1 ;
USE `G2776` ;

-- -----------------------------------------------------
-- Table `G2776`.`user`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `G2776`.`user` ;

CREATE  TABLE IF NOT EXISTS `G2776`.`user` (
  `userID` INT(11) NOT NULL AUTO_INCREMENT ,
  `userName` TEXT NOT NULL ,
  `userEmail` TEXT NULL DEFAULT NULL ,
  `userPassword` TEXT NOT NULL ,
  PRIMARY KEY (`userID`) )
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `G2776`.`encounter`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `G2776`.`encounter` ;

CREATE  TABLE IF NOT EXISTS `G2776`.`encounter` (
  `encounterID` INT(11) NOT NULL AUTO_INCREMENT ,
  `user_userID` INT(11) NOT NULL ,
  `encounterName` TEXT NULL DEFAULT NULL ,
  `encounterDesc` TEXT NULL DEFAULT NULL ,
  `encounterMonsters` TEXT NULL DEFAULT NULL ,
  `encounterExp` TEXT NULL DEFAULT NULL ,
  `encounterLevel` TEXT NULL DEFAULT NULL ,
  PRIMARY KEY (`encounterID`) ,
  INDEX `fk_encounter_user_idx` (`user_userID` ASC) ,
  CONSTRAINT `fk_encounter_user`
    FOREIGN KEY (`user_userID` )
    REFERENCES `G2776`.`user` (`userID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 8
DEFAULT CHARACTER SET = latin1;

USE `G2776` ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
