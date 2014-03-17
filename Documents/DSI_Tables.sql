/*
//==========================================================================
//	FileName:DSI_Tables.sql
//	Desc:
//
//	Called by
//
//	Auth:吴俊
//	Date:2011/11/02
//==========================================================================
//	Change History
//==========================================================================
//	Date	Author	Description
//	----	------	-----------
//
//==========================================================================
//	Copyright (C)  2004-2011	Yaesoft Corporation
*/
----------------------------------------------------------------------------
---------------------------------------------------------------------------------------------
--补助发放。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIAllowance')
begin
	print 'drop table tblDSIAllowance'
	drop table tblDSIAllowance
end
go
---------------------------------------------------------------------------------------------
--教育局审核结果。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIEduAuditResult')
begin
	print 'drop table tblDSIEduAuditResult '
	drop table tblDSIEduAuditResult
end
go
---------------------------------------------------------------------------------------------
--系统初选结果。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIFilterResult')
begin
	print 'drop table tblDSIFilterResult'
	drop table tblDSIFilterResult
end
go
---------------------------------------------------------------------------------------------
--初选轮次条件设置。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIFilterRoundSettings')
begin
	print 'drop table tblDSIFilterRoundSettings'
	drop table tblDSIFilterRoundSettings
end
go
---------------------------------------------------------------------------------------------
--职工申报。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIStaffRequest')
begin
	print 'drop table tblDSIStaffRequest'
	drop table tblDSIStaffRequest
end
go
---------------------------------------------------------------------------------------------
--家庭成员关系。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIStaffFamilyMember')
begin
	print 'drop table tblDSIStaffFamilyMember'
	drop table tblDSIStaffFamilyMember
end
go
---------------------------------------------------------------------------------------------
--附件。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIStaffAttachment')
begin
	print 'drop table tblDSIStaffAttachment'
	drop table tblDSIStaffAttachment
end
go
---------------------------------------------------------------------------------------------
--职工基本信息。
if exists(select 0 from sysobjects where xtype = 'u' and name='tblDSIStaffInfo')
begin
	print 'drop table tblDSIStaffInfo '
	drop table tblDSIStaffInfo
end
go
---------------------------------------------------------------------------------------------
--用户对应单位。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIEmployeeUnit')
begin
	 print 'drop table tblDSIEmployeeUnit '
	 drop table tblDSIEmployeeUnit
end
go
---------------------------------------------------------------------------------------------
--设置申报轮次。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIRequestRound')
begin
	print 'drop table tblDSIRequestRound'
	drop table tblDSIRequestRound
end
go
	print 'create table tblDSIRequestRound'
go
create table tblDSIRequestRound
(
	RoundID				GUIDEx,--申报轮次ID。
	RoundName			nvarchar(128),--轮次名称。
	StartTime			datetime default(null),--申报起始时间。
	EndTime				datetime default(null),--申报结束时间。
	
	constraint PK_tblDSIRequestRound primary key(RoundID)--主键约束。
)
go
---------------------------------------------------------------------------------------------------------------
--民族设置。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIPeople')
begin
	print 'drop table tblDSIPeople'
	drop table tblDSIPeople
end
go
	print 'create table tblDSIPeople'
go
create table tblDSIPeople
(
	PeopleID	GUIDEx,--民族代码。
	PeopleCode	int,--代码。
	PeopleName	nvarchar(128),--名称。
		
	constraint PK_tblDSIPeople primary key(PeopleID),--主键约束。
	constraint UK_tblDSIPeople_PeopleCode unique(PeopleCode)
)
----------------------------------------------------------------------------------------------------------------------
--所属行业。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSISector')
begin
	print 'drop table tblDSISector'
	drop table tblDSISector
end
go
	print 'create table tblDSISector'
go
create table tblDSISector
(
	SectorID	 GUIDEx,--行业代码。
	SectorCode	 int,--代码。
	SectorName	 nvarchar(128),--名称。
		
	constraint PK_tblDSISector primary key(SectorID),--主键约束。
	constraint UK_tblDSISector_SectorCode unique(SectorCode)
)
------------------------------------------------------------------------------------------------------------------------
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
----------------------------------------------------------------------------
--主要困难情况。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIHardSituation')
begin
	print 'drop table tblDSIHardSituation'
	drop table tblDSIHardSituation
end
go
	print 'create table tblDSIHardSituation'
go
create table tblDSIHardSituation
(
	HardSituationID		GUIDEx, --主要困难情况ID。
	HardSituationCode	int default(0),--主要困难情况代码。
	HardSituationName	nvarchar(128),--主要困难情况名称。
	
	constraint PK_tblDSIHardSituation primary key(HardSituationID),--主键约束。
	constraint UK_tblDSIHardSituation_HardSituationCode unique(HardSituationCode)--唯一约束。
)
----------------------------------------------------------------------------
--职工基本信息。
if exists(select 0 from sysobjects where xtype = 'u' and name='tblDSIStaffInfo')
begin
	print 'drop table tblDSIStaffInfo '
	drop table tblDSIStaffInfo
end
go
	print 'create table tblDSIStaffInfo'
go
create table tblDSIStaffInfo
(	
	StaffID				GUIDEx,--职工ID。
	StaffCode			GUIDEx null,--职工编号。
	StaffName			nvarchar(32),--姓名。
	StaffStatus			int default(1),--职工状态。
	
	HardCategory		int default(0),--困难类别(0:低保线以上;1:享受低保;2:未享受低保)。
	
	PeopleID			GUIDEx null,--民族。
	Gender				int default(0),--性别(0:未知，1:男，2:女)。
	PoliticalFace		int default(0),--政治面貌(0:未知)。
	
	IDCard				nvarchar(32),--身份证号。
	Birthday			datetime default(null),--出生日期。
	
	HealthStatus		int default(0),--健康状况(0:未知)。
	Disability			nvarchar(32),--残疾类别。
	
	--Theidentity			int default(0),--身份(0:未知)。
	LaborModelType		int default(0),--劳模类型(0:非劳模)。
	
	HouseType			int default(0),--住房类型(0-承租单位公房，1-政府廉租房，2-自购房，3-其他)。
	BuildArea			float default(0),--建筑面积。
		
	ZipCode				nvarchar(32),--邮政编码。
	Contact				nvarchar(128),--联系电话。
	TimeWorkStart		datetime default(null),--参加工作时间。
	SectorID			GUIDEx null,--所属行业(0：无业)。
	Maritalstatus		int default(0),--婚姻状况(0：未知)。
	
	ResidenceType		int default(0),--户口类型(0:非农业;1:农业;2:农转居)。
	Address				nvarchar(512),--家庭住址。
	UnitID				GUIDEx,--工作单位。
	UnitNature			int default(0),--单位性质(0:未知)。
	IsWhethersingle		int default(0),--是否单亲(0:否;1:是)。
	
	AvgIncome			float	default(0),--月平均收入。
	FamilyAl			float	default(0),--家庭年度总收入。
	
	Household			int		default(0),--家庭人口。
	AvgFamilyIncome		float	default(0),--家庭年度平均收入。
	
	ResidenceArea		nvarchar(512),--户口所在行政区划。
	MedicareStatus		int default(1),--是否进入医保(0:未知，1:是;2:否)。
	
	SelfHelp			int default(0),--是否有自救能力(0:否,1:是;)。
	ZeroEmployment		int default(0),--是否零就业(0:否,1:是;)。
	HardSituation		GUIDEx	null,--主要困难情况。
	HardSituationDescription	nvarchar(512),--主要困难情况描述。
	HardBecause			int	default(1),--致困原因
	
	CreateEmployeeID	GUIDEx null,--创建人ID。
	CreateEmoloyeeName	nvarchar(32),--创建人名称。
	CreateDateTime		datetime default(getdate()),--创建日期。
	
	constraint PK_tblDSIStaffInfo primary key(StaffID),--主键约束。
	constraint UK_tblDSIStaffInfo_IDCard unique(IDCard),--身份证唯一约束。
	constraint UK_tblDSIStaffInfo_StaffCode unique(StaffCode),--员工编号唯一约束。
	constraint FK_tblDSIStaffInfo_tblDSIPeople_PeopleID foreign key(PeopleID) references tblDSIPeople(PeopleID),--民族外键约束。
	constraint FK_tblDSIStaffInfo_tblDSISector_SectorID foreign key(SectorID) references tblDSISector(SectorID),--所属行业外键约束。
	constraint FK_tblDSIStaffInfo_tblDSIUnit_UnitID foreign key(UnitID) references tblDSIUnit(UnitID)--所属单位外键约束。
)
go

------------------------------------------------------------------------------------------------------------------------
--家庭成员关系。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIStaffFamilyMember')
begin
	print 'drop table tblDSIStaffFamilyMember'
	drop table tblDSIStaffFamilyMember
end
go
	print 'create table tblDSIStaffFamilyMember'
go
create table tblDSIStaffFamilyMember
(
	  StaffID			GUIDEx,--职工ID。  

	  MemberID			GUIDEx,--家庭成员ID。
	  MemberName		nvarchar(32),--成员姓名。
	  
	  Relation			int default(0),--成员关系(0:未知)。
	  	  
	  Gender			int default(0),--成员性别(0:未知，1：男，2:女)。
	  PoliticalFace		int default(0),--政治面貌(0:未知)。
	  
	  IDCard			nvarchar(32),--身份证号。
	  Birthday			datetime default(null),--出生日期。
	  
	  HealthStatus		int default(0),--健康状况(0：未知)。
	  Income			float default(0),--月收入。
	  
	  MemberTheidentity	int default(0),--身份（0:未知）。
  	  
	  UnitSchool		nvarchar(512),--工作单位或学校。
	  	  
	  constraint PK_tblDSIStaffFamilyMember primary key(MemberID),--主键约束。
	  constraint FK_tblDSIStaffFamilyMember_tblDSIStaffInfo_StaffID foreign key(StaffID) references tblDSIStaffInfo(StaffID)--外键约束。
)
go
--------------------------------------------------------------------------------------------------------
--附件。
--if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIStaffAttachment')
--begin
--	print 'drop table tblDSIStaffAttachment'
--	drop table tblDSIStaffAttachment
--end
--go
--	print 'create table tblDSIStaffAttachment'
--go
--create table tblDSIStaffAttachment
--(
--	
--	 StaffID		GUIDEx,--教职工ID。
--	 FileType		int default(0),--文件类型：0-附件，1-照片。
--	 FileID			GUIDEx,--附件ID。
--	 FileName		nvarchar(128),--附件名称。
--	 Mime			nvarchar(128),--MIME 内容类型。
--	 [Size]			float default(0),--附件大小。
--	 Extension		nvarchar(10),--附件后缀名。
--	 CheckCode		nvarchar(32),--校验码。
--	 
--	 LastModifyTime	datetime default(getdate()),--最后更新时间。
--	 
--	 constraint PK_tblDSIStaffAttachment primary key(FileID),-- 主键约束。
-- 	 constraint FK_tblDSIStaffAttachment_tblDSIStaffInfo_StaffID foreign key(StaffID) references tblDSIStaffInfo(StaffID)--外键约束。
--)
--go
--------------------------------------------------------------------------------------------------------------
--职工申报。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIStaffRequest')
begin
	print 'drop table tblDSIStaffRequest'
	drop table tblDSIStaffRequest
end
go
	print 'create table tblDSIStaffRequest'
go
create table tblDSIStaffRequest
(
	RequestID			GUIDEx,--申报ID。
	RoundID				GUIDEx,--申报轮次ID。	
	StaffID				GUIDEx,--职工ID。
	
	CreateEmployeeID	GUIDEx null,--申报人ID。
	CreateEmployeeName	nvarchar(32),--申报人名称。
    CreateRequestTime	datetime default(getdate()),--申报时间。
		
	constraint PK_tblDSIStaffRequest primary key(RequestID),--主键约束。
	constraint UK_tblDSIStaffRequest_RoundID_StaffID unique(RoundID,StaffID),--唯一约束。
	constraint FK_tblDSIStaffRequest_tblDSIRequestRound_RoundID foreign key(RoundID) references tblDSIRequestRound(RoundID),--外键约束。
	constraint FK_tblDSIStaffRequest_tblDSIStaffInfo_StaffID foreign key(StaffID) references tblDSIStaffInfo(StaffID)--外键约束。
)
go
----------------------------------------------------------------------------------------------------------------------
--初选轮次
--if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIFilterRound')
--begin
--	print 'drop table tblDSIFilterRound'
--	drop table tblDSIFilterRound
--end
--go
--	print 'create table tblDSIFilterRound'
--go
--create table tblDSIFilterRound
--(
--	RoundID		GUIDEx,--初选ID。
--	RoundName	nvarchar(128),--初选轮次名称。
--	Status		int default(1),--状态，（0-停用，1-启用）
--	
--	PublicityStatus		int default(1),--公示状态（0-不公示，1-公示）。
--	PublicityStartTime	datetime default(null),--公示起始时间。
--	PublicityEndTime	datetime default(null),--公示结束时间。
--		
--	constraint PK_tblDSIFilterRound primary key(RoundID)--主键约束。
--)
--go
--------------------------------------------------------------------------------------------------------------
--初选轮次条件设置（注释字段启用时采用完全二叉树形式存储）。
--if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIFilterRoundSettings')
--begin
--	print 'drop table tblDSIFilterRoundSettings'
--	drop table tblDSIFilterRoundSettings
--end
--go
--	print 'create table tblDSIFilterRoundSettings'
--go
--create table tblDSIFilterRoundSettings
--(
--	FilterRoundID			GUIDEx,--初选轮次ID。
--	--ParentSettingID	GUIDEx default(null),--上级条件
--	SettingID		GUIDEx,--条件设置ID。
--	SettingName		nvarchar(128),--条件设置名称。
--	TargetValue		nvarchar(32),--目标值。
--	--Computing		int default(0),--条件运算（只在上级条件不为空时有效，0-无效，1-与，2-或，3-非）
--	TableName		nvarchar(64),--条件来源表。
--	FieldName		nvarchar(64),--条件来源字段。	
--	constraint PK_tblDSIFilterRoundSettings_SettingID primary key(SettingID),--主键。
--	constraint FK_tblDSIFilterRoundSettings_tblDSIFilterRound_FilterRoundID foreign key(FilterRoundID) references tblDSIFilterRound(RoundID)--外键约束。
--)
--------------------------------------------------------------------------------------------------------------
--系统初选结果。
--if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIFilterResult')
--begin
--	print 'drop table tblDSIFilterResult'
--	drop table tblDSIFilterResult
--end
--go
--	print 'create table tblDSIFilterResult'
--go
--create table tblDSIFilterResult
--(
--	RequestID		  GUIDEx,--申报ID。	
--	FilterRoundID	  GUIDEx,--初选轮次ID。	
--	FilterTime		  datetime default(getdate()),--初选时间。
--	EmployeeID			GUIDEx,--初选人ID。
--	EmployeeName		nvarchar(32),--初选人名称。	
--	constraint PK_tblDSIFilterResult primary key(RequestID),--主键约束。
--	constraint FK_tblDSIFilterResult_tblDSIStaffRequest_RequestID foreign key(RequestID) references	tblDSIStaffRequest(RequestID),--申报ID外键。
--	constraint FK_tblDSIFilterResult_tblDSIFilterRound_FilterRoundID foreign key(FilterRoundID) references tblDSIFilterRound(RoundID)--外键约束。
--)
go
--------------------------------------------------------------------------------------------------------------
--教育局审核结果。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIEduAuditResult')
begin
	print 'drop table tblDSIEduAuditResult '
	drop table tblDSIEduAuditResult
end
go
	print 'create table tblDSIEduAuditResult '
go
create table tblDSIEduAuditResult
(	
	RequestID		GUIDEx,--申报ID。
		
	AuditTime		datetime default(getdate()),--审核通过时间。
	EmployeeID		GUIDEx,--审核人ID。
	EmployeeName	nvarchar(32),--审核人名称。	
	
	constraint PK_tblDSIEduAuditResult primary key(RequestID),--主键约束。
	constraint FK_tblDSIEduAuditResult_tblDSIStaffRequest_RequestID foreign key(RequestID) references tblDSIStaffRequest(RequestID)--外键约束。	
)
go
----------------------------------------------------------------------------------------------------------------
--补助轮次。
--if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIAllowanceRound')
--begin
--	print 'drop table tblDSIAllowanceRound'
--	drop table	tblDSIAllowanceRound
--end
--go
--	print 'create table tblDSIAllowanceRound'
--go
--create table tblDSIAllowanceRound
--(
--	RoundID				GUIDEx,--补助轮次ID。
--	RoundName			nvarchar(128),--轮次名称。
--	RoundTime			datetime default(null),--补助发放日期。	
--	RoundMoney			float default(0),--补助金额。
--	Description			nvarchar(512),--补助描述。
--	PublicityStatus		int default(0),--公示状态（0-不公示，1-公示）。
--	PublicityStartTime	datetime default(null),--起始时间。
--	PublicityEndTime	datetime default(null),--结束时间。
--	OrderNO				int default(0),--排序字段。
--	constraint PK_tblDSIAllowanceRound primary key(RoundID)--主键约束。
--)
--go
--------------------------------------------------------------------------------------------------------------
--补助发放。
--if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIAllowance')
--begin
--	print 'drop table tblDSIAllowance'
--	drop table tblDSIAllowance
--end
--go
--	print 'create table tblDSIAllowance'
--go
--create table tblDSIAllowance
--(
--	RequestID		GUIDEx,--申报ID。
--	RoundID			GUIDEx,--补助轮次ID。
--	GrantTime		datetime default(getdate()),--发放时间。	
--	Paid			float default(0),--实收金额。
--	Beneficiary		nvarchar(128),--收款人。
--	Description		nvarchar(512),--补助描述。	
--	EmployeeID		GUIDEx,--发放人ID。
--	EmployeeName	nvarchar(32),--发放人名称。	
--	constraint PK_tblDSIAllowance primary key(RequestID,RoundID),--主键约束。	
--	constraint FK_tblDSIAllowance_tblDSIStaffRequest_RequestID foreign key(RequestID) references tblDSIStaffRequest(RequestID),--外键约束。
--	constraint FK_tblDSIAllowance_tblDSIAllowanceRound_RoundID foreign key(RoundID) references tblDSIAllowanceRound(RoundID)--外键约束。
--)
--go
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
	
	constraint PK_tblDSIEmployeeUnit primary key(EmployeeID,UnitID),--主键约束。				
	constraint FK_tblDSIEmployeeUnit_tblDSIEmployee_EmployeeID foreign key(EmployeeID) references tblDSIEmployee(EmployeeID),--用户ID外键约束。
	constraint FK_tblDSIEmployeeUnit_tblDSIUnit_UnitID foreign key(UnitID) references tblDSIUnit(UnitID)--单位ID外键约束。
)
go
------------------------------------------------------------------------------------------------------------------------