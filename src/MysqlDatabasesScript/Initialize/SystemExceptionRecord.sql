/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     2016/12/21 23:02:27                          */
/*==============================================================*/


drop table if exists SystemExceptionRecord;

/*==============================================================*/
/* Table: SystemExceptionRecord                                 */
/*==============================================================*/
create table SystemExceptionRecord
(
   Id                   bigint not null auto_increment comment 'Id',
   Name                 varchar(50) not null comment '名称',
   HelpLink             varchar(200) comment '帮助链接',
   Source               varchar(50) not null comment '异常发生位置',
   Message              text not null comment '异常消息',
   StackTrace           text comment '堆栈跟踪',
   HResult              int not null comment '特定异常编号',
   Data                 text comment '发起数据',
   InnerException       text comment '内部错误信息',
   CreateTime           datetime not null comment '错误发生时间',
   primary key (Id)
);

alter table SystemExceptionRecord comment '系统异常记录';

