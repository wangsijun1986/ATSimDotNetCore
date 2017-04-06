USE `adh`$$
drop procedure if exists `USP_Page_Users`;


DELIMITER $$
USE `adh`$$
CREATE PROCEDURE `USP_Page_Users` (
    pageIndex INT,
    pageSize INT,
    OUT pagecount INT
)
BEGIN
    DECLARE startIndex INT DEFAULT 0;
    DECLARE pCount INT DEFAULT 0;
    SET startIndex = (pageIndex-1)*pageSize;
SELECT 
    UserId,
    Phone,
    Password,
    Role,
    CreateTime,
    LastLoginTime,
    CurrentlyLoginTime,
    CurrentlyIP,
    CurrentlyPort,
    IdentityCardNo,
    IdentityCardPath,
    IdentityCardBackPath,
    UserIntegrals,
    Avatar,
    Validity
FROM
    Users
LIMIT STARTINDEX , PAGESIZE;
SELECT 
    COUNT(1)
INTO pCount FROM
    Users;
    SET pagecount=pCount;
END$$

DELIMITER ;
