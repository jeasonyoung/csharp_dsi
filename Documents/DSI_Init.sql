/*
//==========================================================================
//	FileName:DSI_Procedure.sql
//	Desc:
//
//	Called by
//
//	Auth:����
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
--��������
declare @EnumName nvarchar(256)
----------------------------------------------------------------------------
--�Ա�ö��
set	 @EnumName='Yaesoft.DSI.Engine.Persistence.EnumGender'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Male','��',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Female','Ů',0x02,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Unknown','δ֪',0x00,3)
----------------------------------------------------------------------------
--������òö��
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumPoliticalFace'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'CpcMember','�й���Ա',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'YouthLeague','������Ա',0x03,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'People','Ⱥ��',0x04,3)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Democracy','��������',0x05,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Other','����',0x06,5)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Unknown','δ֪',0x01,6)
---------------------------------------------------------------------------
--����״��ö��
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumHealthStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Good','����',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Cancer','��֢',0x02,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Cardiovascular','��Ѫ�ܲ�',0x03,3)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Uremic','��֢',0x04,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Mental','����',0x05,5)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Liver','�β�',0x06,6)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Blood','ѪҺ��',0x07,7)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Diabetes','����',0x08,8)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Tumor','������',0x09,9)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Cervical','����׵��',0x10,10)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'HighBlood','��Ѫѹ��',0x11,11)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Lung','�β�',0x12,12)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Other','һ�㼲��',0x13,13)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Disability','�м�',0x14,14)
----------------------------------------------------------------------------
--ְ����λö��
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumStaffStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'ThePost','�ڸ�',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Retired','������',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'LaidOff','��(��)��',0x04,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Unemployment','ʧ(��)ҵ',0x08,3) 
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'InRetirement','����',0x10,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Farmer','ũ��',0x20,5)
------------------------------------------------------------------------------
--ס�����͡�
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumHouseType'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'RentUnitHouse','���ⵥλ����',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'LowCostHouse','�������ⷿ',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'SelfHouse','�Թ���',0x02,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Other','����',0x03,3)
------------------------------------------------------------------------------
--��Ա���ö��
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumMemberTheidentity'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'ThePost','�ڸ�',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'LaidOff','��(��)��',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Unemployment','ʧ(��)ҵ',0x03,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Retirement','����',0x04,3)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'InRetirement','����',0x05,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Farmer','ũ��',0x06,5)

insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Graduate','�о���',0x07,6)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Unstudent','��ѧ��',0x08,7)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Secondary','��ְ�м�',0x09,8)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'HSchool','����',0x010,9)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'School','����',0x011,10)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Prischool','Сѧ',0x012,11)
----------------------------------------------------------------------------
--��ģ����ö��
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumLaborModelType'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'CountryModelWorkers','ȫ����ģ',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'ProvinceModelWorkers','ʡ����ģ',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'CityModelWorkers','���м���ģ',0x03,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Other','����',0x04,3)
-----------------------------------------------------------------------------
--����״��ö��
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumMaritalStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Married','�ѻ�',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Unmarried','δ��',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Divorced','����',0x03,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Widowed','ɥż',0x04,3)
---------------------------------------------------------------------------------
--��������ö��
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumResidenceType'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Nonagricultural','��ũҵ',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Agriculture','ũҵ',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'AgrCity','ũת��',0x02,2)
---------------------------------------------------------------------------------
--��λ����
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumUnitNature'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Institutions','���л���/��ҵ��λ',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'CountryEnterprise','������ҵ',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'CollectiveEnterprises','������ҵ',0x03,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Private','��Ӫ/˽Ӫ/������ҵ',0x04,3)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'HKMC','��۰�̨����/����',0x05,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'JointVenture','�������/����',0x06,5)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Other','����',0x07,6)
---------------------------------------------------------------------------------
--��ҵ״��
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumUnitStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Deficit','������ҵ',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Restructuring','������ҵ',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Bankruptcy','�ر��Ʋ���ҵ',0x03,2)
---------------------------------------------------------------------------------
--�Ƿ���
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumIsWhethersingle'
delete from tblCommonEnums where EnumName  = @EnumName 
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'SingleYes','��',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'SingleNo','��',0x00,0)
---------------------------------------------------------------------------------
--�Ƿ����ҽ��
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumMedicareStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'MedicareYes','��',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'MedicareNo','��',0x02,1)
---------------------------------------------------------------------------------
--��Ա��ϵ
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumRelation'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Father','����',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Mother','ĸ��',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Husband','�ɷ�',0x03,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Wife','����',0x04,3)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Son','����',0x05,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Daughter','Ů��',0x06,5)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Other','����',0x07,6)
---------------------------------------------------------------------------------
--�������
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumHardCategory'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'SubUp','�ͱ���Ե��',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Sub','���ܵͱ�',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'SubUn','����������',0x02,2)
----------------------------------------------------------------------------------
----��λ״̬��
--set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumStaffStatus'
--delete from tblCommonEnums where EnumName  = @EnumName
--insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Retired','������',0x01,2)
--insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'InPost','�ڸ�',0x02,1)
----------------------------------------------------------------------------------
--�Ƿ����Ծ�����
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumSelfHelp'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'SelfHelpYes','��',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'SelfHelpNo','��',0x01,1)
-----------------------------------------------------------------------------------
--�Ƿ����ҵ
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumZeroEmployment'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'EmployYes','��',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'EmployNo','��',0x02,1)
-----------------------------------------------------------------------------------
--������Ҫԭ��
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumHardBecause'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Disease','���˴�',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'RelativesDisease','����ֱϵ������',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Accident','�����ֺ�',0x04,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Disability','�м�',0x08,3)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'LowIncome','������޷�ά�ֻ�������',0x10,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Unemployment','�¸�ʧҵ',0x20,5)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Other','����',0x40,6)
-------------------------------------------------------------------------------------
--��ѡ�ִ�״̬
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumFilterRoundStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Stop','ͣ��',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Enable','����',0x01,1)
--------------------------------------------------------------------------------------
--��ʾ״̬
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumPublicityStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'NoPublicity','����ʾ',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Publicity','��ʾ',0x01,1)
--------------------------------------------------------------------------------------
--����״̬��
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumAllowanceStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'None','δȷ��',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Confirm','��ȷ��',0x01,1)
--------------------------------------------------------------------------------------
--����״̬ö�١�
set @EnumName='Yaesoft.DSI.Engine.Persistence.EnumArchiveStatus'
delete from tblCommonEnums where EnumName  = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'None','����',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Out','ת��',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Hide','����',0x02,2)
--------------------------------------------------------------------------------------
																								   