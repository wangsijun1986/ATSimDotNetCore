/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     2016/12/21 23:02:27                          */
/*==============================================================*/


drop table if exists user;

/*==============================================================*/
/* Table: user													*/
/*==============================================================*/
CREATE DATABASE `test` ;
use `test`;
CREATE TABLE `user` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(255) DEFAULT NULL,
  `Url` varchar(255) DEFAULT NULL,
  `Age` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



--{
--  "admin_id":0,
--  "login_name":"wangsijun1",
--  "password":"wangsijun1",
--  "role":"Admin",
--  "phone":"15332345550",
--  "group_id":1,
--  "user_name":"王思俊1",
--  "organization_id":1,
--  "email":"wangsijun1986@vip.qq.com"
--}