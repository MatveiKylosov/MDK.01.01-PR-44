CREATE TABLECREATE TABLE `Priority` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `NamePriority` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;

CREATE TABLE `Tasks` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  `DateExecute` date DEFAULT NULL,
  `Comment` varchar(1000) DEFAULT NULL,
  `Done` tinyint(1) DEFAULT NULL,
  `PriorityId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Tasks_Priority` (`PriorityId`),
  CONSTRAINT `fk_Tasks_Priority` FOREIGN KEY (`PriorityId`) REFERENCES `Priority` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;