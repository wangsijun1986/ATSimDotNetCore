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
   GroupId              bigint not null auto_increment comment '组Id',
   GroupName            varchar(50) not null comment '组名称',
   primary key (GroupId)
);

alter table AdminGroup comment '管理员组';

/*==============================================================*/
/* Table: AdminOperationRecords                                 */
/*==============================================================*/
create table AdminOperationRecords
(
   AdminOperationId     varchar(36) not null comment '管理员操作Id',
   OperationName        varchar(100) not null comment '操作名称',
   AdminId              bigint not null comment '管理员Id',
   CreateTime           datetime not null default CURRENT_TIMESTAMP comment '操作时间',
   primary key (AdminOperationId)
);

alter table AdminOperationRecords comment '管理员操作记录';

/*==============================================================*/
/* Table: AdminUsers                                            */
/*==============================================================*/
create table AdminUsers
(
   AdminId              bigint not null auto_increment comment '管理员Id',
   LoginName            varchar(20) not null comment '登录名',
   Phone                varchar(15) not null comment '手机号',
   Password             varchar(255) not null comment '密码',
   Role                 varchar(50) not null comment '角色',
   GroupId              bigint not null comment '所属组Id',
   UserName             varchar(20) not null comment '姓名',
   OrganizationId       bigint not null comment '组织Id',
   Email                varchar(50) not null comment '邮箱',
   UniqueCode           varchar(36) not null comment '唯一码',
   CreateTime           datetime not null default CURRENT_TIMESTAMP comment '管理员创建时间',
   LastLoginTime        datetime not null default CURRENT_TIMESTAMP comment '管理员最后登录时间',
   CurrentlyLoginTime   datetime not null default CURRENT_TIMESTAMP comment '当前登录时间',
   IsStop               bit not null default 0 comment '账号已禁用',
   primary key (AdminId)
);

alter table AdminUsers comment '管理员';

/*==============================================================*/
/* Table: BankCard                                              */
/*==============================================================*/
create table BankCard
(
   CardNo               varchar(20) not null comment '银行卡编号',
   WalletId             bigint not null comment '钱包Id',
   LicenseKey           varchar(50) comment '授权码',
   CreateTime           datetime not null default CURRENT_TIMESTAMP comment '创建时间',
   primary key (CardNo)
);

alter table BankCard comment '银行卡';

/*==============================================================*/
/* Table: Business                                              */
/*==============================================================*/
create table Business
(
   BusinessId           bigint not null auto_increment comment '企业Id',
   BusinessName         varchar(50) not null comment '企业名称',
   UserId               bigint not null comment '用户Id',
   BusinessAddress      varchar(100) not null comment '企业地址',
   BusinessLicense      varchar(1000) not null comment '营业执照地址',
   BusinessDoorHead     varchar(1000) not null comment '企业门口照片地址',
   BusinessIncome       decimal(10,2) not null default 0 comment '企业收入',
   primary key (BusinessId)
);

alter table Business comment '企业';

/*==============================================================*/
/* Table: BusinessVehicles                                      */
/*==============================================================*/
create table BusinessVehicles
(
   BusinessVehicleId    bigint not null auto_increment comment '企业车辆Id',
   BusinessId           bigint not null comment '企业Id',
   DriverId             bigint not null comment '驾驶员Id',
   primary key (BusinessVehicleId)
);

alter table BusinessVehicles comment '企业车辆';

/*==============================================================*/
/* Table: Community                                             */
/*==============================================================*/
create table Community
(
   CommunityId          int not null auto_increment comment '市Id',
   CommunityName        varchar(30) not null comment '市名称',
   CommunityCode        varchar(15) not null comment '市对应码',
   primary key (CommunityId)
);

alter table Community comment '市';

/*==============================================================*/
/* Table: Driver                                                */
/*==============================================================*/
create table Driver
(
   DriverId             bigint not null auto_increment comment '司机信息Id',
   VehicleNo            varchar(20) not null comment '车牌号',
   UserId               bigint not null comment '用户Id',
   VehicleType          int not null comment '车型',
   DriverLicense        varchar(1000) not null comment '驾驶证图片地址',
   VehicleLicense       varchar(1000) not null comment '行驶证图片地址',
   DriverPhotoPath      varchar(1000) not null comment '司机照片地址',
   VehiclePhotoFrontPath varchar(1000) not null comment '车辆照片(前方)地址',
   VehiclePhotoBackPath varchar(1000) not null comment '车辆照片(背后)地址',
   CarInsurancePolicy   varchar(1000) not null comment '车辆保险单地址',
   Income               decimal(10,2) not null default 0 comment '收益',
   DriverStatus         varchar(20) not null default 'Close' comment '司机状态',
   primary key (DriverId)
);

alter table Driver comment '司机信息';

/*==============================================================*/
/* Table: FundsFlow                                             */
/*==============================================================*/
create table FundsFlow
(
   FundsFlowNo          varchar(36) not null comment '资金流水号',
   UserId               bigint not null comment '用户Id',
   DriverId             bigint not null comment '司机Id',
   WalletId             bigint not null comment '钱包Id',
   Amount               decimal(10,2) not null comment '金额',
   OrderNo              varchar(36) not null comment '订单编号',
   CreateTime           datetime not null default CURRENT_TIMESTAMP comment '创建时间',
   primary key (FundsFlowNo)
);

alter table FundsFlow comment '资金流水';

/*==============================================================*/
/* Table: Hitchhike                                             */
/*==============================================================*/
create table Hitchhike
(
   HitchhikeNo          varchar(36) not null comment '顺风车编号',
   DriverId             bigint not null comment '司机Id',
   DepartTime           datetime not null comment '出发时间',
   CommunityId          int not null comment '出发城市',
   DepartCoordinateX    double not null comment '出发位置坐标X',
   DepartCoordinateY    double not null comment '出发位置坐标Y',
   DestinationCoordinateX double not null comment '目的地位置坐标X',
   DestinationCoordinateY double not null comment '目的地位置坐标Y',
   CreateTime           datetime not null default CURRENT_TIMESTAMP comment '顺风车信息创建时间',
   SameCity             bit not null comment '同城顺风车信息',
   primary key (HitchhikeNo)
);

alter table Hitchhike comment '顺风车信息';

/*==============================================================*/
/* Table: OrderAdditionService                                  */
/*==============================================================*/
create table OrderAdditionService
(
   OrderAdditionServiceId varchar(36) not null comment '订单增值服务Id',
   OrderNo              varchar(36) not null comment '订单编号',
   AdditionServiceId    int not null comment '增值服务Id',
   ExplainMessage       varchar(1000) comment '说明信息',
   StartTime            datetime comment '司机到达时间',
   BeginTime            datetime comment '服务开始计费时间',
   EndTime              datetime comment '服务终止计费时间',
   BasicPrice           decimal(10,2) not null comment '增值服务计费基本价',
   TimeTag              int not null comment '基本价时率标记',
   FreeTime             int not null comment '免费时间标记',
   primary key (OrderAdditionServiceId)
);

alter table OrderAdditionService comment '订单增值服务';

/*==============================================================*/
/* Table: Orders                                                */
/*==============================================================*/
create table Orders
(
   OrderNo              varchar(36) not null comment '订单编号',
   UserId               bigint not null comment '发货人Id',
   TransportMode        varchar(20) not null comment '运输方式',
   PayMode              varchar(20) not null comment '付款方式',
   SelfPickup           bit not null comment '自提货物',
   GoodsLocation        varchar(200) not null comment '货物位置',
   DepartProviceId      int not null comment '发货省/州Id',
   DepartCommunityId    int not null comment '发货城市Id',
   GoodsCoordinateX     double not null comment '货物坐标X',
   GoodsCoordinateY     double not null comment '货物坐标Y',
   Consignee            varchar(20) not null comment '收货人',
   ConsigneePhone       varchar(50) not null comment '收货人电话',
   DestinationProviceId int not null comment '收货省/州Id',
   DestinationCommunityId int not null comment '收货城市Id',
   DeliveryAddress      varchar(200) not null comment '收货地址',
   DestinationCoordinateX double not null comment '目的地坐标X',
   DestinationCoordinateY double not null comment '目的地坐标Y',
   Insured              bit not null comment '保价',
   NegotiatePrice       bit not null comment '议价',
   OrderStatus          varchar(30) not null default 'NewCreate' comment '订单状态',
   DriverId             bigint comment '司机Id',
   VehicleNo            varchar(20) comment '车牌号',
   GoodsName            varchar(100) not null comment '货物名称',
   GoodsWidth           decimal(10,2) comment '货物宽度',
   GoodsWeight          decimal(10,2) comment '货物重量',
   GoodsHeight          decimal(10,2) comment '货物高度',
   GoodsVolumeWeight    decimal(10,2) comment '货物体积重',
   TransportAmount      decimal(10,2) not null comment '运输金额(最终价格)',
   TransportEstimate    decimal(10,2) not null comment '运费估价',
   TransportConsultPrices decimal(10,2) not null comment '运费协商价',
   GoodsWidthEstimate   decimal(10,2) comment '暂估货物宽度',
   GoodsWeightEstimate  decimal(10,2) comment '暂估货物重量',
   GoodsHeightEstimate  decimal(10,2) comment '暂估货物高度',
   CreateTime           datetime not null default CURRENT_TIMESTAMP comment '订单创建时间',
   OrderStartTime       datetime comment '车辆出发时间(司机装完货出发时间)',
   OrderEndTime         datetime comment '车辆到达时间(司机到达目的地时间)',
   OrderFinishTime      datetime comment '订单结束时间(系统分配收益完成时间)',
   OrderBeginTime       datetime comment '订单开始时间(司机接单成功时间)',
   OrderPayTime         datetime comment '订单完成付款时间',
   OrderValidityCode    varchar(5) comment '订单收货验证码',
   Sortation            bit comment '已分拣',
   Packed               bit comment '已集包',
   Unpacked             bit comment '已解包',
   Verify               bit comment '已核对',
   primary key (OrderNo)
);

alter table Orders comment '订单';

/*==============================================================*/
/* Table: OrdersPackage                                         */
/*==============================================================*/
create table OrdersPackage
(
   PackageNo            varchar(36) not null comment '集包号',
   PackageName          varchar(50) not null comment '集包名称',
   DepartProviceId      int not null comment '发货省/州Id',
   DepartCommunityId    int not null comment '发货市Id',
   DestinationProviceId int not null comment '收货省/州Id',
   DestinationCommunityId int not null comment '收货市Id',
   DepartOrangizationId bigint not null comment '发布组织Id',
   DestinationOrangizationId bigint not null comment '收货组织Id',
   DriverId             bigint not null comment '司机Id',
   VehicleNo            varchar(20) not null comment '车牌号',
   CreateTime           datetime not null default CURRENT_TIMESTAMP comment '创建时间',
   PackageStartTime     datetime comment '车辆出发时间',
   PackageEndTime       datetime comment '车辆到达时间',
   UnpackedTime         datetime comment '解包时间',
   PackedTime           datetime comment '集包时间',
   PackageStatus        varchar(30) not null default 'NewCreate' comment '集包状态',
   primary key (PackageNo)
);

alter table OrdersPackage comment '订单集包信息';

/*==============================================================*/
/* Table: OrdersPackageMapping                                  */
/*==============================================================*/
create table OrdersPackageMapping
(
   OrderPackageNo       varchar(36) not null comment '订单集包映射编号',
   OrderNo              varchar(36) not null comment '订单编号',
   PackageNo            varchar(36) not null comment '订单集包号',
   CreateTime           datetime not null default CURRENT_TIMESTAMP comment '创建时间',
   primary key (OrderPackageNo)
);

alter table OrdersPackageMapping comment '订单集包映射';

/*==============================================================*/
/* Table: Organization                                          */
/*==============================================================*/
create table Organization
(
   OrganizationId       bigint not null auto_increment comment '组织Id',
   OrganizationName     varchar(50) not null comment '组织名称',
   OrganizationDescription varchar(1000) not null comment '组织描述',
   ProviceId            int not null comment '省/州',
   CommunityId          int not null comment '市',
   OrganizationLevel    int not null comment '组织级别',
   primary key (OrganizationId)
);

alter table Organization comment '组织';

/*==============================================================*/
/* Table: Provice                                               */
/*==============================================================*/
create table Provice
(
   ProviceId            int not null auto_increment comment '省/州Id',
   ProviceName          varchar(50) not null comment '省/州名称',
   ProviceCode          varchar(15) not null comment '省/州对应码',
   primary key (ProviceId)
);

alter table Provice comment '省/州';

/*==============================================================*/
/* Table: Users                                                 */
/*==============================================================*/
create table Users
(
   UserId               bigint not null auto_increment comment '用户Id',
   Phone                varchar(11) not null comment '手机号',
   Password             varchar(255) not null comment '密码',
   Role                 varchar(50) not null comment '角色',
   CreateTime           datetime not null default CURRENT_TIMESTAMP comment '注册时间',
   LastLoginTime        datetime not null default CURRENT_TIMESTAMP comment '最后登录时间',
   CurrentlyLoginTime   datetime not null default CURRENT_TIMESTAMP comment '当前登录时间',
   CurrentlyIP          varchar(15) comment '当前IP',
   CurrentlyPort        int comment '当前端口',
   IdentityCardNo       varchar(18) comment '身份证号',
   IdentityCardPath     varchar(1000) comment '身份证图片地址',
   IdentityCardBackPath varchar(1000) comment '身份证背面图片地址',
   UserIntegrals        int not null default 0 comment '用户积分',
   Avatar               varchar(1000) not null comment '头像',
   Validity             bit not null default 0 comment '是否已认证',
   primary key (UserId)
);

alter table Users comment '用户';

/*==============================================================*/
/* Table: Wallet                                                */
/*==============================================================*/
create table Wallet
(
   WalletId             bigint not null auto_increment comment '钱包Id',
   UserId               bigint not null comment '用户Id',
   Balance              decimal(10,2) not null default 0 comment '余额',
   BankCradNo           varchar(20) not null comment '银行卡编号',
   primary key (WalletId)
);

alter table Wallet comment '钱包';

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

