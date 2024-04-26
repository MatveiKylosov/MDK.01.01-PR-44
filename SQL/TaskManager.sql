CREATE TABLE `Priorities` (
  `Name` varchar(30) NOT NULL,
  PRIMARY KEY (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `Tasks` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  `Priority` varchar(30) DEFAULT NULL,
  `DateExecute` date DEFAULT NULL,
  `Comment` varchar(1000) DEFAULT NULL,
  `Done` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Priority` (`Priority`),
  CONSTRAINT `Tasks_ibfk_1` FOREIGN KEY (`Priority`) REFERENCES `Priorities` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;
