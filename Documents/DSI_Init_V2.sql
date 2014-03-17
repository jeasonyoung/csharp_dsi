/*
//================================================================================
//  FileName: DSI_Init_V2.sql
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-8
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
--枚举初始化。
declare @EnumName nvarchar(256)
--性别枚举
set	 @EnumName='Yaesoft.DSI.Engine.Persistence.EnumGender'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Male','男',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Female','女',0x02,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Unknown','未知',0x00,3)
--政治面貌枚举
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumPoliticalFace'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'CpcMember','中共党员',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'YouthLeague','共青团员',0x03,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'People','群众',0x04,3)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Democracy','民主党派',0x05,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Other','其他',0x06,5)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Unknown','未知',0x01,6)
--健康状况枚举
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumHealthStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Good','良好',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Disease','疾病',0x02,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Disability','残疾',0x03,3)
--住房类型。
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumHouseType'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'RentUnitHouse','承租单位公房',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'LowCostHouse','政府廉租房',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'SelfHouse','自购房',0x03,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Other','其他',0x04,3)
--婚姻状况枚举
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumMaritalStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Married','已婚',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Unmarried','未婚',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Divorced','离异',0x03,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Widowed','丧偶',0x04,3)
--致困主要原因
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumHardBecause'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Disaster3_5','因天灾人祸致困造成损失3-5万',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Disaster5_10','因天灾人祸致困造成损失5-10万',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Disaster10_','因天灾人祸致困造成损失10万以上',0x03,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Disease','因病致困年度自付金额1万元以上',0x04,3)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Other3_5','其他特殊情况致家庭负债3-5万',0x05,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Other5_10','其他特殊情况致家庭负债5-10万',0x06,5)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Other10_','其他特殊情况致家庭负债10万以上',0x07,6)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Children','子女读大学',0x08,7)
--困难类别
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumHardCategory'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Disaster','因天灾人祸致困',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Disease','因病致困',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Other','其他特殊情况',0x03,2)
--是否有自救能力
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumSelfHelp'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'SelfHelpYes','否',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'SelfHelpNo','是',0x01,1)
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
--成员身份枚举
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumMemberTheidentity'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Farmer','农民',0x06,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'ThePost','工人',0x01,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'InRetirement','干部',0x05,3)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Retirement','离退休人员',0x04,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Unemployment','无业(待岗',0x03,5)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'LaidOff','无固定工作人员',0x02,6)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Prischool','小学生',0x012,7)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'School','中学生',0x011,8)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Unstudent','大学生',0x08,9)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Graduate','研究生',0x07,10)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Secondary','留学生',0x09,11)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'HSchool','其他',0x010,12)
--补助申请审批状态。
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumReqAuditStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'None','已申请',0,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Primary','初审通过',1,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'NonPrimary','初审未通过',-1,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Final','终审通过',2,3)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'NonFinal','终审未通过',-2,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Payee','已领款',3,5)
--教职工身份。
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumTheidentity'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'InService','在职',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Retirement','退休',0x02,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Retired','离休',0x03,3)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Illness','病休',0x04,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Temporary','临时聘用',0x05,5)
----------------------------------------------------------------------------------------------