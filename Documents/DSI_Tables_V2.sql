/*
//================================================================================
//  FileName: DSI_Tables_V2.sql
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-4
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
*/
---------------------------------------------------------------------------------------------
--单位表。
if exists (select 0 from sysobjects where xtype = 'u' and name = 'tblDSIUnit')
begin
	print 'drop table tblDSIUnit'
	drop table tblDSIUnit
end
go
	print 'create table tblDSIUnit '
go
create table tblDSIUnit
(
	UnitID		GUIDEx,--单位ID。
	UnitCode	GUIDEx,--单位代码。
	UnitName	nvarchar(128),--用户单位。
	
	constraint PK_tblDSIUnit primary key(UnitID),--主键约束。
	constraint UK_tblDSIUnit_UnitCode unique(UnitCode)--唯一约束。			
)
go
------------------------------------------------------------------------------------------------------------------------
--用户表。
if exists(select 0 from sysobjects where xtype = 'u' and name ='tblDSIEmployee')
begin
	print 'drop table tblDSIEmployee'
	drop table tblDSIEmployee
end
go
	print 'create table tblDSIEmployee'
go
create table tblDSIEmployee
(
	EmployeeID     nvarchar(32),--用户ID。
	EmployeeCode   nvarchar(32),--用户代码。	
	EmployeeName   nvarchar(32),--用户姓名。	   	
	
	constraint PK_tblDSIEmployee primary key(EmployeeID),--主键约束。
	constraint UK_tblDSIEmployee_EmployeeCode unique(EmployeeCode)--唯一约束。
)
go
------------------------------------------------------------------------------------------------------------------------
--用户对应单位。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIEmployeeUnit')
begin
	 print 'drop table tblDSIEmployeeUnit '
	 drop table tblDSIEmployeeUnit
end
go
	print 'create table tblDSIEmployeeUnit'
go
create table tblDSIEmployeeUnit
(
	EmployeeID		nvarchar(32),--用户ID。
	UnitID			nvarchar(32),--单位ID。
	
	constraint PK_tblDSIEmployeeUnit primary key(EmployeeID,UnitID)--主键约束。				
)
go
------------------------------------------------------------------------------------------------------------------------
--教职工救助申请档案表。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIStaffAppForm')
begin
	print 'drop table tblDSIStaffAppForm'
	drop table tblDSIStaffAppForm
end
go
	print 'create table tblDSIStaffAppForm'
go
create table tblDSIStaffAppForm
(
	StaffID			nvarchar(64),--职工ID。
	StaffCode		nvarchar(64),--职工编号。
	HardCategory	int default(0),--困难类别：1-低保户，2-低保边缘户，3-意外致困户。
	Theidentity		int default(1),--身份：1-在职，2-退休，3-离休，4-病休，5-临时聘用
	StaffName		nvarchar(20),--姓名。
	Gender			int default(0),--性别(0:未知，1:男，2:女)。
	PeopleID		nvarchar(64),--民族。
	PoliticalFace	int default(0),--政治面貌(0:未知)。
	Birthday		datetime default(null),--出生日期。
	IDCard			nvarchar(32),--身份证号。
	HealthStatus	int default(0),--健康状况：1-良好，2-疾病，3-残疾。
	Disability		nvarchar(32),--残疾类别。
	HouseType		int default(0),--住房类型(0-承租单位公房，1-政府廉租房，2-自购房，3-其他)。
	BuildArea		float default(0),--建筑面积。
	ZipCode			nvarchar(32),--邮政编码。
	Contact			nvarchar(32),--联系电话。
	TimeWorkStart	datetime default(null),--参加工作时间。
	Maritalstatus	int default(0),--婚姻状况(0：未知)。
	UnitID			nvarchar(64),--工作单位ID。
	Address			nvarchar(512),--家庭住址。
	
	SelfHelp		int default(0),--是否有自救能力(0:否,1:是;)。
	
	AvgIncome			float	default(0),--本月平均收入。
	FamilyIncome		float	default(0),--家庭年度总收入。
	
	FamilyCount			int		default(0),--家庭人口。
	FamilyAvgIncome		float	default(0),--家庭月人均收入。
	
	HardBecause			int,--致困主要原因。
	HardBecauseDesc		text,--致困原因描述。
		
	CreateTime		datetime default(getdate()),--创建时间。
	CreateUserID	nvarchar(64),--创建者ID。
	CreateUserName	nvarchar(32),--创建者名称。
	
	constraint PK_tblDSIStaffAppForm primary key(StaffID)--主键约束。
)
go
---------------------------------------------------------------------------------------------
--教职工救助申请表家庭成员。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIStaffAppFormFamily')
begin
	print 'drop table tblDSIStaffAppFormFamily'
	drop table tblDSIStaffAppFormFamily
end
go
	print 'create table tblDSIStaffAppFormFamily'
go
create table tblDSIStaffAppFormFamily
(
	StaffID			nvarchar(64),--职工ID。
	MemberID		nvarchar(64),--家庭成员ID。
	MemberName		nvarchar(32),--成员姓名。
	  
    Relation		int default(0),--成员关系(0:未知)。
  	  
	Gender			int default(0),--成员性别(0:未知，1：男，2:女)。
	PoliticalFace	int default(0),--政治面貌(0:未知)。
  
	IDCard			nvarchar(32),--身份证号。
	Birthday		datetime default(null),--出生日期。
  
	HealthStatus	nvarchar(32) default(0),--健康状况：1-良好，2-疾病（此项不填序号，填写具体疾病名称），3-残疾。
	Income			float default(0),--月收入。
  
	MemberTheidentity	int default(0),--身份（0:未知）。
  
	UnitSchool		nvarchar(512),--工作单位或学校。
	  	  
	constraint PK_tblDSIStaffAppFormFamily primary key(MemberID)--主键约束。
)
---------------------------------------------------------------------------------------------
--档案修改记录表
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIStaffAppFormModifyRecord')
begin
	print 'drop table tblDSIStaffAppFormModifyRecord'
	drop table tblDSIStaffAppFormModifyRecord
end
go
	print 'create table tblDSIStaffAppFormModifyRecord'
go
create table tblDSIStaffAppFormModifyRecord
(
	RecordID		nvarchar(64),--记录ID。
	StaffID			nvarchar(64),--档案ID。
	Content			text,--修改内容。
	CreateTime		datetime default(getdate()),--创建时间。
	CreateUserId	GUIDEx,--修改的用户ID。
	CreateUserName	nvarchar(32),--修改的用户名称。
	
	constraint PK_tblDSIStaffModifyRecord primary key(RecordID)--主键。
)
go
-----------------------------------------------------------------------------------------------------
--附件管理表
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIAttachment')
begin
	print 'drop table tblDSIAttachment'
	drop table tblDSIAttachment
end
go
	print 'create table tblDSIAttachment'
go
create table tblDSIAttachment
(
	AttachID		nvarchar(64),--附件ID。
	AttachName		nvarchar(128),--附件名称。
	ContentType		nvarchar(50),--文件类型。
	AttachSize		float default(0),--附件大小(KB)。
	AttachPath		nvarchar(256),--附件路径。
	AttachCreate	datetime default(getdate()),--附件
	
	constraint PK_tblDSIAttachment primary key(AttachID)
)
go
--------------------------------------------------------------------------------------------
--档案附件关联表（多个附件）。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIStaffAppFormAttachment')
begin
	print 'drop table tblDSIStaffAppFormAttachment'
	drop table tblDSIStaffAppFormAttachment
end
go
	print 'create table tblDSIStaffAppFormAttachment'
go
create table tblDSIStaffAppFormAttachment
(
	StaffID		nvarchar(64),--职工ID。
	AttachID	nvarchar(64),--附件ID。
	
	constraint PK_tblDSIStaffAppFormAttachment primary key(StaffID,AttachID)
)
go
--------------------------------------------------------------------------------------------
--设置申报项目表。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIProject')
begin
	print 'drop table tblDSIProject'
	drop table tblDSIProject
end
go
	print 'create table tblDSIProject'
go
create table tblDSIProject
(
	ProjectID		nvarchar(64),--项目ID。
	ProjectName		nvarchar(128),--项目名称。
	StartTime		datetime	default(getdate()),--申报项目开始时间。
	EndTime			datetime	default(getdate()),--申报项目结束时间。
	IsView			int	default(0),--是否在首页显示。
	
	Content			ntext null,--内容。
	
	CreateTime		datetime	default(getdate()),--创建时间。
	CreateUserID	nvarchar(64),--创建用户ID。
	CreateUserName	nvarchar(32),--创建用户名称。
	
	constraint PK_tblDSIProject primary key(ProjectID)--主键约束。
)
go
----------------------------------------------------------------------------------------------
--设置申报项目附件表。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIProjectAttachment')
begin
	print 'drop table tblDSIProjectAttachment'
	drop table tblDSIProjectAttachment
end
go
	print 'create table tblDSIProjectAttachment'
go
create table tblDSIProjectAttachment
(
	ProjectID		nvarchar(64),--项目ID。
	AttachID		nvarchar(64),--附件ID。
	
	constraint PK_tblDSIProjectAttachment primary key(ProjectID,AttachID)
)
go
----------------------------------------------------------------------------------------------
--职工项目申报。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIStaffAppFormReq')
begin
	print 'drop table tblDSIStaffAppFormReq'
	drop table tblDSIStaffAppFormReq
end
go
	print 'create table tblDSIStaffAppFormReq'
go
create table tblDSIStaffAppFormReq
(
	StaffID			nvarchar(64),--职工ID。
	ProjectID		nvarchar(64),--项目ID。
	
	PrimaryAllowance	float default(0),--拟申请补助金额。
	PrimaryAudit		nvarchar(32),--初审审核人。
	PrimaryAuditTime	datetime	default(getdate()),--审核时间。
	
	CommitteeAllowance	float default(0),--委员会拟补助。
	LeadershipAllowance	float default(0),--主管领导拟补助。
	FinalAllowance		float default(0),--总负责人拟补助。
	
	Payee				nvarchar(50),--领取人签名。
	
	CreateUserID		nvarchar(64),--申请人ID。
	CreateUserName		nvarchar(32),--申请人名称。
	CreateTime			datetime	default(getdate()),--申请时间。
	
	Status				int	default(0),--申报状态(0-申请，1-基层工会初审，-1-初审未过，2-局工会终审，-2-终审未过,3-已领款)。
	
	constraint PK_tblDSIStaffAppFormReq primary key(StaffID,ProjectID)--主键约束。
)
go
----------------------------------------------------------------------------------------------