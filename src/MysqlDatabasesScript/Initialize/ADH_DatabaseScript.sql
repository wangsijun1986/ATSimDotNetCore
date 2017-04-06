/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     2017/4/7 3:08:27                             */
/*==============================================================*/


drop procedure if exists USP_Page_Users;

drop table if exists AdminGroup;

drop table if exists AdminOperationRecords;

drop table if exists AdminUsers;

drop table if exists BankCard;

drop table if exists Business;

drop table if exists BusinessVehicles;

drop table if exists Community;

drop table if exists Driver;

drop table if exists FundsFlow;

drop table if exists Hitchhike;

drop table if exists OrderAdditionService;

drop table if exists Orders;

drop table if exists OrdersPackage;

drop table if exists OrdersPackageMapping;

drop table if exists Organization;

drop table if exists Provice;

drop table if exists Users;

drop table if exists Wallet;

/*==============================================================*/
/* Table: AdminGroup                                            */
/*==============================================================*/
create table AdminGroup
(
   GroupId              bigint not null auto_increment comment '��Id',
   GroupName            varchar(50) not null comment '������',
   primary key (GroupId)
);

alter table AdminGroup comment '����Ա��';

/*==============================================================*/
/* Table: AdminOperationRecords                                 */
/*==============================================================*/
create table AdminOperationRecords
(
   AdminOperationId     varchar(36) not null comment '����Ա����Id',
   OperationName        varchar(100) not null comment '��������',
   AdminId              bigint not null comment '����ԱId',
   CreateTime           datetime not null default CURRENT_TIMESTAMP comment '����ʱ��',
   primary key (AdminOperationId)
);

alter table AdminOperationRecords comment '����Ա������¼';

/*==============================================================*/
/* Table: AdminUsers                                            */
/*==============================================================*/
create table AdminUsers
(
   AdminId              bigint not null auto_increment comment '����ԱId',
   LoginName            varchar(20) not null comment '��¼��',
   Phone                varchar(15) not null comment '�ֻ���',
   Password             varchar(255) not null comment '����',
   Role                 varchar(50) not null comment '��ɫ',
   GroupId              bigint not null comment '������Id',
   UserName             varchar(20) not null comment '����',
   OrganizationId       bigint not null comment '��֯Id',
   Email                varchar(50) not null comment '����',
   UniqueCode           varchar(36) not null comment 'Ψһ��',
   CreateTime           datetime not null default CURRENT_TIMESTAMP comment '����Ա����ʱ��',
   LastLoginTime        datetime not null default CURRENT_TIMESTAMP comment '����Ա����¼ʱ��',
   CurrentlyLoginTime   datetime not null default CURRENT_TIMESTAMP comment '��ǰ��¼ʱ��',
   IsStop               bit not null default 0 comment '�˺��ѽ���',
   primary key (AdminId)
);

alter table AdminUsers comment '����Ա';

/*==============================================================*/
/* Table: BankCard                                              */
/*==============================================================*/
create table BankCard
(
   CardNo               varchar(20) not null comment '���п����',
   WalletId             bigint not null comment 'Ǯ��Id',
   LicenseKey           varchar(50) comment '��Ȩ��',
   CreateTime           datetime not null default CURRENT_TIMESTAMP comment '����ʱ��',
   primary key (CardNo)
);

alter table BankCard comment '���п�';

/*==============================================================*/
/* Table: Business                                              */
/*==============================================================*/
create table Business
(
   BusinessId           bigint not null auto_increment comment '��ҵId',
   BusinessName         varchar(50) not null comment '��ҵ����',
   UserId               bigint not null comment '�û�Id',
   BusinessAddress      varchar(100) not null comment '��ҵ��ַ',
   BusinessLicense      varchar(1000) not null comment 'Ӫҵִ�յ�ַ',
   BusinessDoorHead     varchar(1000) not null comment '��ҵ�ſ���Ƭ��ַ',
   BusinessIncome       decimal(10,2) not null default 0 comment '��ҵ����',
   primary key (BusinessId)
);

alter table Business comment '��ҵ';

/*==============================================================*/
/* Table: BusinessVehicles                                      */
/*==============================================================*/
create table BusinessVehicles
(
   BusinessVehicleId    bigint not null auto_increment comment '��ҵ����Id',
   BusinessId           bigint not null comment '��ҵId',
   DriverId             bigint not null comment '��ʻԱId',
   primary key (BusinessVehicleId)
);

alter table BusinessVehicles comment '��ҵ����';

/*==============================================================*/
/* Table: Community                                             */
/*==============================================================*/
create table Community
(
   CommunityId          int not null auto_increment comment '��Id',
   CommunityName        varchar(30) not null comment '������',
   CommunityCode        varchar(15) not null comment '�ж�Ӧ��',
   primary key (CommunityId)
);

alter table Community comment '��';

/*==============================================================*/
/* Table: Driver                                                */
/*==============================================================*/
create table Driver
(
   DriverId             bigint not null auto_increment comment '˾����ϢId',
   VehicleNo            varchar(20) not null comment '���ƺ�',
   UserId               bigint not null comment '�û�Id',
   VehicleType          int not null comment '����',
   DriverLicense        varchar(1000) not null comment '��ʻ֤ͼƬ��ַ',
   VehicleLicense       varchar(1000) not null comment '��ʻ֤ͼƬ��ַ',
   DriverPhotoPath      varchar(1000) not null comment '˾����Ƭ��ַ',
   VehiclePhotoFrontPath varchar(1000) not null comment '������Ƭ(ǰ��)��ַ',
   VehiclePhotoBackPath varchar(1000) not null comment '������Ƭ(����)��ַ',
   CarInsurancePolicy   varchar(1000) not null comment '�������յ���ַ',
   Income               decimal(10,2) not null default 0 comment '����',
   DriverStatus         varchar(20) not null default 'Close' comment '˾��״̬',
   primary key (DriverId)
);

alter table Driver comment '˾����Ϣ';

/*==============================================================*/
/* Table: FundsFlow                                             */
/*==============================================================*/
create table FundsFlow
(
   FundsFlowNo          varchar(36) not null comment '�ʽ���ˮ��',
   UserId               bigint not null comment '�û�Id',
   DriverId             bigint not null comment '˾��Id',
   WalletId             bigint not null comment 'Ǯ��Id',
   Amount               decimal(10,2) not null comment '���',
   OrderNo              varchar(36) not null comment '�������',
   CreateTime           datetime not null default CURRENT_TIMESTAMP comment '����ʱ��',
   primary key (FundsFlowNo)
);

alter table FundsFlow comment '�ʽ���ˮ';

/*==============================================================*/
/* Table: Hitchhike                                             */
/*==============================================================*/
create table Hitchhike
(
   HitchhikeNo          varchar(36) not null comment '˳�糵���',
   DriverId             bigint not null comment '˾��Id',
   DepartTime           datetime not null comment '����ʱ��',
   CommunityId          int not null comment '��������',
   DepartCoordinateX    double not null comment '����λ������X',
   DepartCoordinateY    double not null comment '����λ������Y',
   DestinationCoordinateX double not null comment 'Ŀ�ĵ�λ������X',
   DestinationCoordinateY double not null comment 'Ŀ�ĵ�λ������Y',
   CreateTime           datetime not null default CURRENT_TIMESTAMP comment '˳�糵��Ϣ����ʱ��',
   SameCity             bit not null comment 'ͬ��˳�糵��Ϣ',
   primary key (HitchhikeNo)
);

alter table Hitchhike comment '˳�糵��Ϣ';

/*==============================================================*/
/* Table: OrderAdditionService                                  */
/*==============================================================*/
create table OrderAdditionService
(
   OrderAdditionServiceId varchar(36) not null comment '������ֵ����Id',
   OrderNo              varchar(36) not null comment '�������',
   AdditionServiceId    int not null comment '��ֵ����Id',
   ExplainMessage       varchar(1000) comment '˵����Ϣ',
   StartTime            datetime comment '˾������ʱ��',
   BeginTime            datetime comment '����ʼ�Ʒ�ʱ��',
   EndTime              datetime comment '������ֹ�Ʒ�ʱ��',
   BasicPrice           decimal(10,2) not null comment '��ֵ����Ʒѻ�����',
   TimeTag              int not null comment '������ʱ�ʱ��',
   FreeTime             int not null comment '���ʱ����',
   primary key (OrderAdditionServiceId)
);

alter table OrderAdditionService comment '������ֵ����';

/*==============================================================*/
/* Table: Orders                                                */
/*==============================================================*/
create table Orders
(
   OrderNo              varchar(36) not null comment '�������',
   UserId               bigint not null comment '������Id',
   TransportMode        varchar(20) not null comment '���䷽ʽ',
   PayMode              varchar(20) not null comment '���ʽ',
   SelfPickup           bit not null comment '�������',
   GoodsLocation        varchar(200) not null comment '����λ��',
   DepartProviceId      int not null comment '����ʡ/��Id',
   DepartCommunityId    int not null comment '��������Id',
   GoodsCoordinateX     double not null comment '��������X',
   GoodsCoordinateY     double not null comment '��������Y',
   Consignee            varchar(20) not null comment '�ջ���',
   ConsigneePhone       varchar(50) not null comment '�ջ��˵绰',
   DestinationProviceId int not null comment '�ջ�ʡ/��Id',
   DestinationCommunityId int not null comment '�ջ�����Id',
   DeliveryAddress      varchar(200) not null comment '�ջ���ַ',
   DestinationCoordinateX double not null comment 'Ŀ�ĵ�����X',
   DestinationCoordinateY double not null comment 'Ŀ�ĵ�����Y',
   Insured              bit not null comment '����',
   NegotiatePrice       bit not null comment '���',
   OrderStatus          varchar(30) not null default 'NewCreate' comment '����״̬',
   DriverId             bigint comment '˾��Id',
   VehicleNo            varchar(20) comment '���ƺ�',
   GoodsName            varchar(100) not null comment '��������',
   GoodsWidth           decimal(10,2) comment '������',
   GoodsWeight          decimal(10,2) comment '��������',
   GoodsHeight          decimal(10,2) comment '����߶�',
   GoodsVolumeWeight    decimal(10,2) comment '���������',
   TransportAmount      decimal(10,2) not null comment '������(���ռ۸�)',
   TransportEstimate    decimal(10,2) not null comment '�˷ѹ���',
   TransportConsultPrices decimal(10,2) not null comment '�˷�Э�̼�',
   GoodsWidthEstimate   decimal(10,2) comment '�ݹ�������',
   GoodsWeightEstimate  decimal(10,2) comment '�ݹ���������',
   GoodsHeightEstimate  decimal(10,2) comment '�ݹ�����߶�',
   CreateTime           datetime not null default CURRENT_TIMESTAMP comment '��������ʱ��',
   OrderStartTime       datetime comment '��������ʱ��(˾��װ�������ʱ��)',
   OrderEndTime         datetime comment '��������ʱ��(˾������Ŀ�ĵ�ʱ��)',
   OrderFinishTime      datetime comment '��������ʱ��(ϵͳ�����������ʱ��)',
   OrderBeginTime       datetime comment '������ʼʱ��(˾���ӵ��ɹ�ʱ��)',
   OrderPayTime         datetime comment '������ɸ���ʱ��',
   OrderValidityCode    varchar(5) comment '�����ջ���֤��',
   Sortation            bit comment '�ѷּ�',
   Packed               bit comment '�Ѽ���',
   Unpacked             bit comment '�ѽ��',
   Verify               bit comment '�Ѻ˶�',
   primary key (OrderNo)
);

alter table Orders comment '����';

/*==============================================================*/
/* Table: OrdersPackage                                         */
/*==============================================================*/
create table OrdersPackage
(
   PackageNo            varchar(36) not null comment '������',
   PackageName          varchar(50) not null comment '��������',
   DepartProviceId      int not null comment '����ʡ/��Id',
   DepartCommunityId    int not null comment '������Id',
   DestinationProviceId int not null comment '�ջ�ʡ/��Id',
   DestinationCommunityId int not null comment '�ջ���Id',
   DepartOrangizationId bigint not null comment '������֯Id',
   DestinationOrangizationId bigint not null comment '�ջ���֯Id',
   DriverId             bigint not null comment '˾��Id',
   VehicleNo            varchar(20) not null comment '���ƺ�',
   CreateTime           datetime not null default CURRENT_TIMESTAMP comment '����ʱ��',
   PackageStartTime     datetime comment '��������ʱ��',
   PackageEndTime       datetime comment '��������ʱ��',
   UnpackedTime         datetime comment '���ʱ��',
   PackedTime           datetime comment '����ʱ��',
   PackageStatus        varchar(30) not null default 'NewCreate' comment '����״̬',
   primary key (PackageNo)
);

alter table OrdersPackage comment '����������Ϣ';

/*==============================================================*/
/* Table: OrdersPackageMapping                                  */
/*==============================================================*/
create table OrdersPackageMapping
(
   OrderPackageNo       varchar(36) not null comment '��������ӳ����',
   OrderNo              varchar(36) not null comment '�������',
   PackageNo            varchar(36) not null comment '����������',
   CreateTime           datetime not null default CURRENT_TIMESTAMP comment '����ʱ��',
   primary key (OrderPackageNo)
);

alter table OrdersPackageMapping comment '��������ӳ��';

/*==============================================================*/
/* Table: Organization                                          */
/*==============================================================*/
create table Organization
(
   OrganizationId       bigint not null auto_increment comment '��֯Id',
   OrganizationName     varchar(50) not null comment '��֯����',
   OrganizationDescription varchar(1000) not null comment '��֯����',
   ProviceId            int not null comment 'ʡ/��',
   CommunityId          int not null comment '��',
   OrganizationLevel    int not null comment '��֯����',
   primary key (OrganizationId)
);

alter table Organization comment '��֯';

/*==============================================================*/
/* Table: Provice                                               */
/*==============================================================*/
create table Provice
(
   ProviceId            int not null auto_increment comment 'ʡ/��Id',
   ProviceName          varchar(50) not null comment 'ʡ/������',
   ProviceCode          varchar(15) not null comment 'ʡ/�ݶ�Ӧ��',
   primary key (ProviceId)
);

alter table Provice comment 'ʡ/��';

/*==============================================================*/
/* Table: Users                                                 */
/*==============================================================*/
create table Users
(
   UserId               bigint not null auto_increment comment '�û�Id',
   Phone                varchar(11) not null comment '�ֻ���',
   Password             varchar(255) not null comment '����',
   Role                 varchar(50) not null comment '��ɫ',
   CreateTime           datetime not null default CURRENT_TIMESTAMP comment 'ע��ʱ��',
   LastLoginTime        datetime not null default CURRENT_TIMESTAMP comment '����¼ʱ��',
   CurrentlyLoginTime   datetime not null default CURRENT_TIMESTAMP comment '��ǰ��¼ʱ��',
   CurrentlyIP          varchar(15) comment '��ǰIP',
   CurrentlyPort        int comment '��ǰ�˿�',
   IdentityCardNo       varchar(18) comment '���֤��',
   IdentityCardPath     varchar(1000) comment '���֤ͼƬ��ַ',
   IdentityCardBackPath varchar(1000) comment '���֤����ͼƬ��ַ',
   UserIntegrals        int not null default 0 comment '�û�����',
   Avatar               varchar(1000) not null comment 'ͷ��',
   Validity             bit not null default 0 comment '�Ƿ�����֤',
   primary key (UserId)
);

alter table Users comment '�û�';

/*==============================================================*/
/* Table: Wallet                                                */
/*==============================================================*/
create table Wallet
(
   WalletId             bigint not null auto_increment comment 'Ǯ��Id',
   UserId               bigint not null comment '�û�Id',
   Balance              decimal(10,2) not null default 0 comment '���',
   BankCradNo           varchar(20) not null comment '���п����',
   primary key (WalletId)
);

alter table Wallet comment 'Ǯ��';

alter table AdminOperationRecords add constraint FK_Reference_5 foreign key (AdminId)
      references AdminUsers (AdminId) on delete restrict on update restrict;

alter table AdminUsers add constraint FK_Reference_1 foreign key (GroupId)
      references AdminGroup (GroupId) on delete restrict on update restrict;

alter table AdminUsers add constraint FK_Reference_2 foreign key (OrganizationId)
      references Organization (OrganizationId) on delete restrict on update restrict;

alter table BankCard add constraint FK_Reference_15 foreign key (WalletId)
      references Wallet (WalletId) on delete restrict on update restrict;

alter table Business add constraint FK_Reference_9 foreign key (UserId)
      references Users (UserId) on delete restrict on update restrict;

alter table BusinessVehicles add constraint FK_Reference_10 foreign key (BusinessId)
      references Business (BusinessId) on delete restrict on update restrict;

alter table BusinessVehicles add constraint FK_Reference_11 foreign key (DriverId)
      references Driver (DriverId) on delete restrict on update restrict;

alter table Driver add constraint FK_Reference_7 foreign key (UserId)
      references Users (UserId) on delete restrict on update restrict;

alter table FundsFlow add constraint FK_Reference_17 foreign key (WalletId)
      references Wallet (WalletId) on delete restrict on update restrict;

alter table FundsFlow add constraint FK_Reference_18 foreign key (UserId)
      references Users (UserId) on delete restrict on update restrict;

alter table FundsFlow add constraint FK_Reference_19 foreign key (DriverId)
      references Driver (DriverId) on delete restrict on update restrict;

alter table FundsFlow add constraint FK_Reference_20 foreign key (OrderNo)
      references Orders (OrderNo) on delete restrict on update restrict;

alter table OrderAdditionService add constraint FK_Reference_12 foreign key (OrderNo)
      references Orders (OrderNo) on delete restrict on update restrict;

alter table Orders add constraint FK_Reference_6 foreign key (UserId)
      references Users (UserId) on delete restrict on update restrict;

alter table Orders add constraint FK_Reference_8 foreign key (DriverId)
      references Driver (DriverId) on delete restrict on update restrict;

alter table OrdersPackageMapping add constraint FK_Reference_13 foreign key (OrderNo)
      references Orders (OrderNo) on delete restrict on update restrict;

alter table OrdersPackageMapping add constraint FK_Reference_14 foreign key (PackageNo)
      references OrdersPackage (PackageNo) on delete restrict on update restrict;

alter table Organization add constraint FK_Reference_3 foreign key (ProviceId)
      references Provice (ProviceId) on delete restrict on update restrict;

alter table Organization add constraint FK_Reference_4 foreign key (CommunityId)
      references Community (CommunityId) on delete restrict on update restrict;

alter table Wallet add constraint FK_Reference_16 foreign key (UserId)
      references Users (UserId) on delete restrict on update restrict;


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

