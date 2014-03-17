/*
//==========================================================================
//	FileName:DSI_Procedure.sql
//	Desc:
//
//	Called by
//
//	Auth:杨勇
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
--变量定义
declare @EnumName nvarchar(256)
----------------------------------------------------------------------------
--性别枚举
set	 @EnumName='Yaesoft.DSI.Engine.Persistence.EnumGender'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Male','男',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Female','女',0x02,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Unknown','未知',0x00,3)
----------------------------------------------------------------------------
--政治面貌枚举
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumPoliticalFace'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'CpcMember','中共党员',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'YouthLeague','共青团员',0x03,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'People','群众',0x04,3)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Democracy','民主党派',0x05,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Other','其他',0x06,5)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Unknown','未知',0x01,6)
---------------------------------------------------------------------------
--健康状况枚举
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumHealthStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Good','良好',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Cancer','癌症',0x02,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Cardiovascular','心血管病',0x03,3)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Uremic','尿毒症',0x04,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Mental','精神病',0x05,5)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Liver','肝病',0x06,6)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Blood','血液病',0x07,7)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Diabetes','糖尿病',0x08,8)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Tumor','肿瘤病',0x09,9)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Cervical','腰颈椎病',0x10,10)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'HighBlood','高血压病',0x11,11)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Lung','肺病',0x12,12)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Other','一般疾病',0x13,13)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Disability','残疾',0x14,14)
----------------------------------------------------------------------------
--职工岗位枚举
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumStaffStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'ThePost','在岗',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Retired','离退休',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'LaidOff','下(待)岗',0x04,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Unemployment','失(无)业',0x08,3) 
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'InRetirement','内退',0x10,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Farmer','农民工',0x20,5)
------------------------------------------------------------------------------
--住房类型。
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumHouseType'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'RentUnitHouse','承租单位公房',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'LowCostHouse','政府廉租房',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'SelfHouse','自购房',0x02,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Other','其他',0x03,3)
------------------------------------------------------------------------------
--成员身份枚举
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumMemberTheidentity'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'ThePost','在岗',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'LaidOff','下(待)岗',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Unemployment','失(无)业',0x03,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Retirement','退休',0x04,3)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'InRetirement','内退',0x05,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Farmer','农民工',0x06,5)

insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Graduate','研究生',0x07,6)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Unstudent','大学生',0x08,7)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Secondary','中职中技',0x09,8)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'HSchool','高中',0x010,9)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'School','初中',0x011,10)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Prischool','小学',0x012,11)
----------------------------------------------------------------------------
--劳模类型枚举
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumLaborModelType'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'CountryModelWorkers','全国劳模',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'ProvinceModelWorkers','省部劳模',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'CityModelWorkers','地市级劳模',0x03,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Other','其他',0x04,3)
-----------------------------------------------------------------------------
--婚姻状况枚举
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumMaritalStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Married','已婚',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Unmarried','未婚',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Divorced','离异',0x03,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Widowed','丧偶',0x04,3)
---------------------------------------------------------------------------------
--户口类型枚举
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumResidenceType'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Nonagricultural','非农业',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Agriculture','农业',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'AgrCity','农转居',0x02,2)
---------------------------------------------------------------------------------
--单位性质
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumUnitNature'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Institutions','国有机关/事业单位',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'CountryEnterprise','国有企业',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'CollectiveEnterprises','集体企业',0x03,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Private','民营/私营/个体企业',0x04,3)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'HKMC','与港澳台合资/合作',0x05,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'JointVenture','中外合资/合作',0x06,5)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Other','其他',0x07,6)
---------------------------------------------------------------------------------
--企业状况
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumUnitStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Deficit','亏损企业',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Restructuring','改制企业',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Bankruptcy','关闭破产企业',0x03,2)
---------------------------------------------------------------------------------
--是否单亲
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumIsWhethersingle'
delete from tblCommonEnums where EnumName  = @EnumName 
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'SingleYes','是',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'SingleNo','否',0x00,0)
---------------------------------------------------------------------------------
--是否进入医保
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumMedicareStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'MedicareYes','是',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'MedicareNo','否',0x02,1)
---------------------------------------------------------------------------------
--成员关系
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumRelation'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Father','父亲',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Mother','母亲',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Husband','丈夫',0x03,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Wife','妻子',0x04,3)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Son','儿子',0x05,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Daughter','女儿',0x06,5)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Other','其他',0x07,6)
---------------------------------------------------------------------------------
--困难类别
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumHardCategory'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'SubUp','低保边缘户',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Sub','享受低保',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'SubUn','意外致困户',0x02,2)
----------------------------------------------------------------------------------
----岗位状态。
--set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumStaffStatus'
--delete from tblCommonEnums where EnumName  = @EnumName
--insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Retired','离退休',0x01,2)
--insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'InPost','在岗',0x02,1)
----------------------------------------------------------------------------------
--是否有自救能力
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumSelfHelp'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'SelfHelpYes','否',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'SelfHelpNo','是',0x01,1)
-----------------------------------------------------------------------------------
--是否零就业
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumZeroEmployment'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'EmployYes','是',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'EmployNo','否',0x02,1)
-----------------------------------------------------------------------------------
--致困主要原因
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumHardBecause'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Disease','本人大病',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'RelativesDisease','供养直系亲属大病',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Accident','意外灾害',0x04,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Disability','残疾',0x08,3)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'LowIncome','收入低无法维持基本生活',0x10,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Unemployment','下岗失业',0x20,5)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Other','其他',0x40,6)
-------------------------------------------------------------------------------------
--初选轮次状态
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumFilterRoundStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Stop','停用',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Enable','启用',0x01,1)
--------------------------------------------------------------------------------------
--公示状态
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumPublicityStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'NoPublicity','不公示',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Publicity','公示',0x01,1)
--------------------------------------------------------------------------------------
--补助状态。
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumAllowanceStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'None','未确认',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Confirm','已确认',0x01,1)
--------------------------------------------------------------------------------------
--档案状态枚举。
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumArchiveStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'None','正常',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Out','转出',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Hide','隐藏',0x02,2)
--------------------------------------------------------------------------------------
																								   