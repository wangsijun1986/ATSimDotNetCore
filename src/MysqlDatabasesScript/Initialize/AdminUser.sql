/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     2016/12/21 23:02:27                          */
/*==============================================================*/
USE `TEST`;
DROP TABLE IF EXISTS AdminUser;

/*==============================================================*/
/* Table: user													*/
/*==============================================================*/
CREATE TABLE `AdminUser`(
	`Id` INT(11) NOT NULL AUTO_INCREMENT COMMENT 'Id',
    `UserName` VARCHAR(50) NOT NULL COMMENT '用户名',
    `Password` VARCHAR(255) NOT NULL COMMENT '密码',
    `Role` VARCHAR(50) NOT NULL COMMENT '角色',
    `Email` VARCHAR(50) NOT NULL COMMENT 'Email',
    `CreateTime` DATETIME NOT NULL DEFAULT NOW() COMMENT '创建时间',
    `IsStop` BIT NOT NULL DEFAULT 0 COMMENT '已停止使用',
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;