CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `MenuCategories` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_MenuCategories` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Orders` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `CreateAt` datetime(0) NOT NULL,
    `CompletedAt` datetime(0) NULL,
    `Status` int NOT NULL,
    CONSTRAINT `PK_Orders` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `ProductGroups` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_ProductGroups` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `MenuSubcategories` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `MenuCategoryId` int NOT NULL,
    `Name` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_MenuSubcategories` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_MenuSubcategories_MenuCategories_MenuCategoryId` FOREIGN KEY (`MenuCategoryId`) REFERENCES `MenuCategories` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `Products` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ProductGroupId` int NOT NULL,
    `Name` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Products` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Products_ProductGroups_ProductGroupId` FOREIGN KEY (`ProductGroupId`) REFERENCES `ProductGroups` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `MenuPositions` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `MenuSubcategoryId` int NOT NULL,
    `Name` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_MenuPositions` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_MenuPositions_MenuSubcategories_MenuSubcategoryId` FOREIGN KEY (`MenuSubcategoryId`) REFERENCES `MenuSubcategories` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `OrderItems` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `OrderId` int NOT NULL,
    `MenuPositionId` int NOT NULL,
    CONSTRAINT `PK_OrderItems` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_OrderItems_MenuPositions_MenuPositionId` FOREIGN KEY (`MenuPositionId`) REFERENCES `MenuPositions` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_OrderItems_Orders_OrderId` FOREIGN KEY (`OrderId`) REFERENCES `Orders` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `Recipes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `MenuPositionId` int NOT NULL,
    `ProductGroupId` int NOT NULL,
    CONSTRAINT `PK_Recipes` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Recipes_MenuPositions_MenuPositionId` FOREIGN KEY (`MenuPositionId`) REFERENCES `MenuPositions` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Recipes_ProductGroups_ProductGroupId` FOREIGN KEY (`ProductGroupId`) REFERENCES `ProductGroups` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `MenuPositionProducts` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `RecipeId` int NOT NULL,
    `ProductId` int NOT NULL,
    CONSTRAINT `PK_MenuPositionProducts` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_MenuPositionProducts_Products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `Products` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_MenuPositionProducts_Recipes_RecipeId` FOREIGN KEY (`RecipeId`) REFERENCES `Recipes` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `OrderItemDetails` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `OrderItemId` int NOT NULL,
    `ProductId` int NOT NULL,
    `RecipeId` int NOT NULL,
    CONSTRAINT `PK_OrderItemDetails` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_OrderItemDetails_OrderItems_OrderItemId` FOREIGN KEY (`OrderItemId`) REFERENCES `OrderItems` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_OrderItemDetails_Products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `Products` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_OrderItemDetails_Recipes_RecipeId` FOREIGN KEY (`RecipeId`) REFERENCES `Recipes` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_MenuPositionProducts_ProductId` ON `MenuPositionProducts` (`ProductId`);

CREATE INDEX `IX_MenuPositionProducts_RecipeId` ON `MenuPositionProducts` (`RecipeId`);

CREATE INDEX `IX_MenuPositions_MenuSubcategoryId` ON `MenuPositions` (`MenuSubcategoryId`);

CREATE INDEX `IX_MenuSubcategories_MenuCategoryId` ON `MenuSubcategories` (`MenuCategoryId`);

CREATE INDEX `IX_OrderItemDetails_OrderItemId` ON `OrderItemDetails` (`OrderItemId`);

CREATE INDEX `IX_OrderItemDetails_ProductId` ON `OrderItemDetails` (`ProductId`);

CREATE INDEX `IX_OrderItemDetails_RecipeId` ON `OrderItemDetails` (`RecipeId`);

CREATE INDEX `IX_OrderItems_MenuPositionId` ON `OrderItems` (`MenuPositionId`);

CREATE INDEX `IX_OrderItems_OrderId` ON `OrderItems` (`OrderId`);

CREATE INDEX `IX_Products_ProductGroupId` ON `Products` (`ProductGroupId`);

CREATE INDEX `IX_Recipes_MenuPositionId` ON `Recipes` (`MenuPositionId`);

CREATE INDEX `IX_Recipes_ProductGroupId` ON `Recipes` (`ProductGroupId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20250208213505_InitialSchema', '8.0.2');

COMMIT;