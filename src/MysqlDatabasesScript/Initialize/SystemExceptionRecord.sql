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
   Name                 varchar(50) not null comment '����',
   HelpLink             varchar(200) comment '��������',
   Source               varchar(50) not null comment '�쳣����λ��',
   Message              text not null comment '�쳣��Ϣ',
   StackTrace           text comment '��ջ����',
   HResult              int not null comment '�ض��쳣���',
   Data                 text comment '��������',
   InnerException       text comment '�ڲ�������Ϣ',
   CreateTime           datetime not null comment '������ʱ��',
   primary key (Id)
);

alter table SystemExceptionRecord comment 'ϵͳ�쳣��¼';

