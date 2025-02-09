START TRANSACTION;

ALTER TABLE `Recipes` ADD `IsRequired` tinyint(1) NOT NULL DEFAULT FALSE;

ALTER TABLE `MenuPositionProducts` ADD `IsDefault` tinyint(1) NOT NULL DEFAULT FALSE;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20250209111716_AdjustRecipesAndMenuProducts', '8.0.2');

COMMIT;