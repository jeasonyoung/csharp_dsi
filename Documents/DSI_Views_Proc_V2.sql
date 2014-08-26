-----------------------------------------------------------------------------------------
--views & proceudres
-----------------------------------------------------------------------------------------
--档案附件视图。
if exists(select 0 from sysobjects where xtype = 'v' and name = 'vwDSIStaffAppFormAttachment')
begin
	print 'drop view vwDSIStaffAppFormAttachment'
	drop view vwDSIStaffAppFormAttachment
end
go
	print 'create view vwDSIStaffAppFormAttachment'
go
create view vwDSIStaffAppFormAttachment
as
	select b.StaffID, a.AttachID,a.AttachName,a.ContentType,a.AttachSize,a.AttachPath,a.AttachCreate
	from tblDSIAttachment a
	inner join tblDSIStaffAppFormAttachment b
	on b.AttachID = a.AttachID
go
--------------------------------------------------------------------------------------------
--教职工档案列表视图。
if exists(select 0 from sysobjects where xtype = 'v' and name = 'vwDSIStaffInfoList')
begin
	print 'drop view vwDSIStaffInfoList'
	drop view vwDSIStaffInfoList
end
go
	print 'create view vwDSIStaffInfoList'
go
create view vwDSIStaffInfoList
as
	select	a.StaffID,a.StaffCode,a.StaffName,a.Gender,
	datediff(year,a.Birthday,getdate()) as Age,a.IDCard,a.UnitID,b.UnitName,
	a.Theidentity,a.Maritalstatus,
	a.HardCategory,a.HealthStatus,a.HardBecause,a.CreateTime,a.CreateUserName
	from tblDSIStaffAppForm a
	left outer join tblDSIUnit b
	on b.UnitID = a.UnitID
go
--------------------------------------------------------------------------------------------
--教育局教职工档案列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIEduStaffInfoListView')
begin
	print 'drop procedure spDSIEduStaffInfoListView'
	drop procedure spDSIEduStaffInfoListView
end
go
	print 'create procedure spDSIEduStaffInfoListView'
go
create procedure spDSIEduStaffInfoListView
(
	@UnitName	nvarchar(64),--工作单位。
	@StaffCodeNameCard	nvarchar(32)--教职工编号/姓名/身份证号。
)
as
begin
	select	StaffID,StaffCode,StaffName,Gender,Age,IDCard,UnitName,Theidentity,Maritalstatus,
	HardCategory,HealthStatus,HardBecause,CreateTime,CreateUserName
	from vwDSIStaffInfoList
	where (UnitName like '%' + @UnitName + '%')
		and (StaffCode like '%' + @StaffCodeNameCard + '%' 
			or StaffName like '%' + @StaffCodeNameCard + '%' 
			or IDCard like '%' + @StaffCodeNameCard + '%')
	order by CreateTime desc,StaffName
end
go
----------------------------------------------------------------------------------------------
--学校教职工档案列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSISchoolStaffInfoListView')
begin
	print 'drop procedure spDSISchoolStaffInfoListView'
	drop procedure spDSISchoolStaffInfoListView
end
go
	print 'create procedure spDSISchoolStaffInfoListView'
go
create procedure spDSISchoolStaffInfoListView
(
	@UnitName			nvarchar(64),--工作单位
	@StaffCodeNameCard	nvarchar(32),--教职工编号/姓名/身份证号。
	@CurrentEmployeeID	GUIDEx--当前用户ID。
)
as
begin
	select StaffID,StaffCode,StaffName,Gender,Age,IDCard,UnitName,Theidentity,Maritalstatus,
	HardCategory,HealthStatus,HardBecause,CreateTime,CreateUserName
	from vwDSIStaffInfoList
	where (UnitID in (select UnitID from tblDSIEmployeeUnit where EmployeeID = @CurrentEmployeeID))
	and (UnitName like '%' + @UnitName + '%')
	and (StaffCode like '%'+@StaffCodeNameCard+'%'
		 or StaffID like '%' + @StaffCodeNameCard + '%'
		 or StaffName like '%'+ @StaffCodeNameCard + '%' 
		 or IDCard like '%' + @StaffCodeNameCard + '%')
	order by CreateTime desc,StaffName
end
go
----------------------------------------------------------------------------------------------
--申报项目附件视图。
if exists(select 0 from sysobjects where xtype = 'v' and name = 'vwDSIProjectAttachment')
begin
	print 'drop view vwDSIProjectAttachment'
	drop view vwDSIProjectAttachment
end
go
	print 'create view vwDSIProjectAttachment'
go
create view vwDSIProjectAttachment
as
	select b.ProjectID, a.AttachID,a.AttachName,a.ContentType,a.AttachSize,a.AttachPath,a.AttachCreate
	from tblDSIAttachment a
	inner join tblDSIProjectAttachment b
	on b.AttachID = a.AttachID
go
----------------------------------------------------------------------------------------------
--职工项目申报视图。
if exists(select 0 from sysobjects where xtype = 'v' and name = 'vwDSIStaffAppFormReq')
begin
	print 'drop view vwDSIStaffAppFormReq'
	drop view vwDSIStaffAppFormReq
end
go
	print 'create view vwDSIStaffAppFormReq'
go
create view vwDSIStaffAppFormReq
as
	select a.ProjectID,b.ProjectName,c.UnitID,d.UnitName,
	a.StaffID,c.StaffName,
	isnull(c.Gender,0x00) as Gender,
	c.IDCard,datediff(year,c.Birthday,getdate()) as Age,
	isnull(c.HardCategory,0x03) as HardCategory,
	isnull(c.HardBecause,0x01) as HardBecause,
	isnull(c.Theidentity,0x01) as Theidentity,
	isnull(c.Maritalstatus,0x01) as Maritalstatus,
	a.PrimaryAllowance,a.FinalAllowance,
	convert(nvarchar(4),a.CreateTime,121) as CreateYear,a.CreateTime,
	isnull(a.Status,0x00) as Status,
	a.CreateUserID,a.CreateUserName
	from tblDSIStaffAppFormReq a
	left outer join tblDSIProject b
	on b.ProjectID = a.ProjectID
	left outer join tblDSIStaffAppForm c
	on c.StaffID = a.StaffID
	left outer join tblDSIUnit d
	on d.UnitID = c.UnitID
go
----------------------------------------------------------------------------------------------
--单位公示职工申报视图。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIPublicityStaffRequestListView')
begin
	print 'drop procedure spDSIPublicityStaffRequestListView'
	drop procedure spDSIPublicityStaffRequestListView
end
go
	print 'create procedure spDSIPublicityStaffRequestListView'
go
create procedure spDSIPublicityStaffRequestListView
(
	@ProjectName	nvarchar(128),--项目名称。
	@StaffName		nvarchar(32),--职工姓名。
	@CurrentUserID	nvarchar(64)--当前用户ID。
)
as
begin
	select ProjectName,StaffName,Gender,Age,HardCategory,HardBecause,Theidentity,Maritalstatus,
	PrimaryAllowance,FinalAllowance,Status,CreateTime,CreateUserName
	from vwDSIStaffAppFormReq
	where (UnitID in (select UnitID from tblDSIEmployeeUnit where EmployeeID = @CurrentUserID))
	and ProjectName like '%'+@ProjectName+'%'
	and StaffName like '%'+@StaffName+'%'
	order by CreateTime desc,Status
end
go
----------------------------------------------------------------------------------------------
--职工项目申报数据列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIPersonalStaffAppFormReqListView')
begin
	print 'drop procedure spDSIPersonalStaffAppFormReqListView'
	drop procedure spDSIPersonalStaffAppFormReqListView
end
go
	print 'create procedure spDSIPersonalStaffAppFormReqListView'
go
create procedure spDSIPersonalStaffAppFormReqListView
(
	@ProjectName	nvarchar(128),--项目名称。
	@CurrentUserID	nvarchar(64)--当前用户ID。
)
as
begin
	select ProjectID,ProjectName,UnitName,StaffID,StaffName,Gender,Age,HardCategory,HardBecause,
	Theidentity,Maritalstatus,
	PrimaryAllowance,FinalAllowance,Status,CreateTime,CreateUserName
	from vwDSIStaffAppFormReq
	where CreateUserID = @CurrentUserID
	and ProjectName like '%'+@ProjectName+'%'
	order by CreateTime desc,Status
end
go
----------------------------------------------------------------------------------------------
--学校职工项目申报数据列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSISchoolStaffAppFormReqListView')
begin
	print 'drop procedure spDSISchoolStaffAppFormReqListView'
	drop procedure spDSISchoolStaffAppFormReqListView
end
go
	print 'create procedure spDSISchoolStaffAppFormReqListView'
go
create procedure spDSISchoolStaffAppFormReqListView
(
	@ProjectName	nvarchar(128),--项目名称。
	@CurrentUserID	nvarchar(64),--当前用户ID。
	@StaffName		nvarchar(32)--教职工姓名。
)
as
begin
	select ProjectID,ProjectName,UnitName,StaffID,StaffName,Gender,Age,HardCategory,HardBecause,Theidentity,Maritalstatus,
	PrimaryAllowance,FinalAllowance,Status,CreateTime,CreateUserName
	from vwDSIStaffAppFormReq
	where (UnitID in (select UnitID from tblDSIEmployeeUnit where EmployeeID = @CurrentUserID))
	and ProjectName like '%'+@ProjectName+'%'
	and StaffName like '%'+@StaffName+'%'
	order by CreateTime desc,Status
end
go
----------------------------------------------------------------------------------------------
--教育局职工项目申报数据列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIEduStaffAppFormReqListView')
begin
	print 'drop procedure spDSIEduStaffAppFormReqListView'
	drop procedure spDSIEduStaffAppFormReqListView
end
go
	print 'create procedure spDSIEduStaffAppFormReqListView'
go
create procedure spDSIEduStaffAppFormReqListView
(
	@UnitName		nvarchar(32),--单位名称。
	@ProjectName	nvarchar(128),--项目名称。
	@StaffName		nvarchar(32)--教职工姓名。
)
as
begin
	select ProjectID,ProjectName,UnitName,StaffID,StaffName,Gender,Age,HardCategory,HardBecause,Theidentity,Maritalstatus,
	PrimaryAllowance,FinalAllowance,Status,CreateTime,CreateUserName
	from vwDSIStaffAppFormReq
	where UnitName like '%'+@UnitName+'%'
	and ProjectName like '%'+@ProjectName+'%'
	and StaffName like '%'+@StaffName+'%'
	order by CreateTime desc,Status
end
go
----------------------------------------------------------------------------------------------
--学校初审申报补助列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSISchoolAuditListView')
begin
	print 'drop procedure spDSISchoolAuditListView'
	drop procedure spDSISchoolAuditListView
end
go
	print 'create procedure spDSISchoolAuditListView'
go
create procedure spDSISchoolAuditListView
(
	@ProjectName	nvarchar(128),--项目名称。
	@CurrentUserID	nvarchar(64),--当前用户ID。
	@StaffName		nvarchar(32)--教职工姓名。
)
as
begin
	select ProjectID,ProjectName,UnitName,StaffID,StaffName,Gender,Age,HardCategory,HardBecause,
	Theidentity,Maritalstatus,
	PrimaryAllowance,FinalAllowance,Status,CreateTime,CreateUserName
	from vwDSIStaffAppFormReq
	where (Status >= 0 and Status < 2)
	and (UnitID in (select UnitID from tblDSIEmployeeUnit where EmployeeID = @CurrentUserID))
	and ProjectName like '%'+@ProjectName+'%'
	and StaffName like '%'+@StaffName+'%'
	order by Status,CreateTime desc
end
go
----------------------------------------------------------------------------------------------
--教育局终审申报补助列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIEduAuditListView')
begin
	print 'drop procedure spDSIEduAuditListView'
	drop procedure spDSIEduAuditListView
end
go
	print 'create procedure spDSIEduAuditListView'
go
create procedure spDSIEduAuditListView
(
	@Year			nvarchar(4),--年度。
	@UnitName		nvarchar(32),--单位名称。
	@ProjectID		nvarchar(32),--项目名称。
	@StaffName		nvarchar(32)--教职工姓名。
)
as
begin
	select ProjectID,ProjectName,UnitName,StaffID,StaffName,Gender,Age,HardCategory,HardBecause,Theidentity,Maritalstatus,
	PrimaryAllowance,FinalAllowance,Status,CreateTime,CreateUserName
	from vwDSIStaffAppFormReq
	where  (Status >= 1 and Status < 3)
	and (CreateYear like @Year + '%')
	and (UnitName like '%'+@UnitName+'%')
	and (ProjectID like @ProjectID + '%')
	and (StaffName like '%'+@StaffName+'%')
	order by Status,CreateTime desc
end
go
----------------------------------------------------------------------------------------------
--教职工补助视图。
if exists(select 0 from sysobjects where xtype = 'v' and name = 'vwDSIAllowance')
begin
	print 'drop view vwDSIAllowance'
	drop view vwDSIAllowance
end
go
	print 'create view vwDSIAllowance'
go
create view vwDSIAllowance
as
	select ProjectID,ProjectName,UnitID,UnitName,StaffID,StaffName,Gender,IDCard,Age,
	HardCategory,HardBecause,Theidentity,Maritalstatus,
	FinalAllowance as [Money],CreateYear,CreateTime as [Time]
	from vwDSIStaffAppFormReq
	where Status >= 2
go
----------------------------------------------------------------------------------------------
--教职工补助报表视图。
if exists(select 0 from sysobjects where xtype = 'v' and name = 'vwDSIRptAllowance')
begin
	print 'drop view vwDSIRptAllowance'
	drop view vwDSIRptAllowance
end
go
	print 'create view vwDSIRptAllowance'
go
create view vwDSIRptAllowance
as
	select isnull(a.ProjectID,'') as ProjectID,
	isnull(a.ProjectName,'') as ProjectName,
	b.UnitID,b.UnitName,
	a.StaffID,
	a.StaffName,
	isnull(a.Gender,0) as Gender,
	isnull(a.Age,0) as Age,
	--困难类别
	(case when isnull(a.HardCategory,0) = 1 then 1 else 0 end) as HardCategory_Disaster,--困难类别_因天灾人祸致困
	(case when isnull(a.HardCategory,0) = 2 then 1 else 0 end) as HardCategory_Disease,--困难类别_因病致困
	(case when isnull(a.HardCategory,0) = 3 then 1 else 0 end) as HardCategory_Other,--困难类别_其他特殊情况
	--致困主要原因
	(case when isnull(a.HardBecause,0) = 1 then 1 else 0 end) as HardBecause_Disaster3_5,--致困主要原因_因天灾人祸致困造成损失3-5万
	(case when isnull(a.HardBecause,0) = 2 then 1 else 0 end) as HardBecause_Disaster5_10,--致困主要原因_因天灾人祸致困造成损失5-10万
	(case when isnull(a.HardBecause,0) = 3 then 1 else 0 end) as HardBecause_Disaster10_,--致困主要原因_因天灾人祸致困造成损失10万以上
	(case when isnull(a.HardBecause,0) = 4 then 1 else 0 end) as HardBecause_Disease,--致困主要原因_因病致困年度自付金额1万元以上
	(case when isnull(a.HardBecause,0) = 5 then 1 else 0 end) as HardBecause_Other3_5,--致困主要原因_其他特殊情况致家庭负债3-5万
	(case when isnull(a.HardBecause,0) = 6 then 1 else 0 end) as HardBecause_Other5_10,--致困主要原因_其他特殊情况致家庭负债5-10万
	(case when isnull(a.HardBecause,0) = 7 then 1 else 0 end) as HardBecause_Other10_,--致困主要原因_其他特殊情况致家庭负债10万以上
	(case when isnull(a.HardBecause,0) = 8 then 1 else 0 end) as HardBecause_Children,--致困主要原因_子女读大学
	--身份
	(case when isnull(a.Theidentity,0) = 1 then 1 else 0 end) as Theidentity_InService,--身份_在职
	(case when isnull(a.Theidentity,0) = 2 then 1 else 0 end) as Theidentity_Retirement,--身份_退休
	(case when isnull(a.Theidentity,0) = 3 then 1 else 0 end) as Theidentity_Retired,--身份_离休
	(case when isnull(a.Theidentity,0) = 4 then 1 else 0 end) as Theidentity_Illness,--身份_病休
	(case when isnull(a.Theidentity,0) = 5 then 1 else 0 end) as Theidentity_Temporary,--身份_临时聘用
	--婚姻状况
	(case when isnull(a.Maritalstatus,0) = 1 then 1 else 0 end) as Maritalstatus_Married,--婚姻状况_已婚
	(case when isnull(a.Maritalstatus,0) = 2 then 1 else 0 end) as Maritalstatus_Unmarried,--婚姻状况_未婚
	(case when isnull(a.Maritalstatus,0) = 3 then 1 else 0 end) as Maritalstatus_Divorced,--婚姻状况_离异
	(case when isnull(a.Maritalstatus,0) = 4 then 1 else 0 end) as Maritalstatus_Widowed,--婚姻状况_丧偶
		
	isnull(a.Money,0) as [Money],
	isnull(a.CreateYear,'') as CreateYear,
	isnull(a.Time,'') as [Time]
	from tblDSIUnit b 
	left outer join vwDSIAllowance a
	on a.UnitID = b.UnitID
go
----------------------------------------------------------------------------------------------
--查看教职工个人补助。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIStaffAllowance')
begin
	print 'drop procedure spDSIStaffAllowance'
	drop procedure spDSIStaffAllowance
end
go
create procedure spDSIStaffAllowance
(
	@StaffID	nvarchar(64)--教职工ID。
)
as
begin
	select ProjectName,UnitName,StaffName,Gender,Age,IDCard,[Money],[Time]
	from vwDSIAllowance
	where StaffID = @StaffID
	order by [Time] desc
end
go
----------------------------------------------------------------------------------------------
--查看学校教职工补助。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSISchoolStaffAllowance')
begin
	print 'drop procedure spDSISchoolStaffAllowance'
	drop procedure spDSISchoolStaffAllowance
end
go
	print 'create procedure spDSISchoolStaffAllowance'
go
create procedure spDSISchoolStaffAllowance
(
	@Year	nvarchar(4),--年度。
	@ProjectID	nvarchar(32),--项目名称。
	@CurrentUserID	nvarchar(64),--当前用户ID。
	@StaffName		nvarchar(32)--教职工姓名。
)
as
begin
	select ProjectName,UnitName,StaffID,StaffName,Gender,Age,IDCard,
	HardCategory,HardBecause,Theidentity,Maritalstatus,
	[Money],[Time]
	from vwDSIAllowance
	where (UnitID in (select UnitID from tblDSIEmployeeUnit where EmployeeID = @CurrentUserID))
	and (CreateYear like @Year + '%')
	and (ProjectID like @ProjectID+'%')
	and (StaffName like '%'+@StaffName+'%')
	order by [Time] desc,UnitName,ProjectName
end
go
----------------------------------------------------------------------------------------------
--查看教育局教职工补助。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIEduStaffAllowance')
begin
	print 'drop procedure spDSIEduStaffAllowance'
	drop procedure spDSIEduStaffAllowance
end
go
	print 'create procedure spDSIEduStaffAllowance'
go
create procedure spDSIEduStaffAllowance
(
	@Year			nvarchar(4),--年度。
	@UnitName		nvarchar(32),--单位名称。
	@ProjectID		nvarchar(32),--项目名称。
	@StaffName		nvarchar(32)--教职工姓名。
)
as
begin
	select ProjectName,UnitName,StaffID,StaffName,Gender,Age,IDCard,
	HardCategory,HardBecause,Theidentity,Maritalstatus,
	[Money],[Time]
	from vwDSIAllowance
	where (CreateYear like @Year + '%')
	and (UnitName like '%' + @UnitName + '%')
	and (ProjectID like @ProjectID + '%')
	and (StaffName like '%' + @StaffName + '%')
	order by [Time] desc,UnitName,ProjectName
end
go
----------------------------------------------------------------------------------------------
--按单位和年度显示教职工补助明细。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIRptAllowanceDetail')
begin
	print 'drop procedure spDSIRptAllowanceDetail'
	drop procedure spDSIRptAllowanceDetail
end
go
	print 'create procedure spDSIRptAllowanceDetail'
go
create procedure spDSIRptAllowanceDetail
(	
	@UnitID	nvarchar(32),--单位ID。
	@Year	nvarchar(4) --年度。
)
as
begin
	select ProjectName,UnitName,StaffID,StaffName,Gender,Age,IDCard,
	HardCategory,HardBecause,Theidentity,Maritalstatus,
	[Money],[Time]
	from vwDSIAllowance
	where (CreateYear = @Year)
	and (UnitID = @UnitID)
	order by [Time] desc,ProjectName
end
go
----------------------------------------------------------------------------------------------
--学校补助汇总统计表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSISchoolRptAllowance')
begin
	print 'drop procedure spDSISchoolRptAllowance'
	drop procedure spDSISchoolRptAllowance
end
go
	print 'create procedure spDSISchoolRptAllowance'
go
create procedure spDSISchoolRptAllowance
(
	@Year	nvarchar(4),--年度。
	@ProjectID	nvarchar(128),--项目名称。
	@CurrentUserID	nvarchar(64)--当前用户ID。
)
as
begin
	select ProjectName,UnitName,count(StaffID) as [Count], sum([Money]) as [Money],max([Time]) as [Time]
	from vwDSIAllowance
	where (UnitID in (select UnitID from tblDSIEmployeeUnit where EmployeeID = @CurrentUserID))
	and (CreateYear like @Year + '%')
	and (ProjectID like @ProjectID+'%')
	group by ProjectName,UnitName,StaffID
	order by [Time] desc
end
----------------------------------------------------------------------------------------------
--教育局按单位年度统计。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIEduRptUnitYearAllowanceList')
begin
	print 'drop procedure spDSIEduRptUnitYearAllowanceList'
	drop procedure spDSIEduRptUnitYearAllowanceList
end
go
	print 'create procedure spDSIEduRptUnitYearAllowanceList'
go
create procedure spDSIEduRptUnitYearAllowanceList
(
	@Year			nvarchar(4),--年度
	@ProjectId		nvarchar(32),--项目ID。
	@UnitName		nvarchar(32)--单位名称。
)
as
begin
	select UnitID,UnitName,CreateYear,
			sum(HardCategory_Disaster) as HardCategory_Disaster,
			sum(HardCategory_Disease) as HardCategory_Disease,
			sum(HardCategory_Other) as HardCategory_Other,
			
			sum(HardBecause_Disaster3_5) as HardBecause_Disaster3_5,
			sum(HardBecause_Disaster5_10) as HardBecause_Disaster5_10,
			sum(HardBecause_Disaster10_) as HardBecause_Disaster10_,
			sum(HardBecause_Disease) as HardBecause_Disease,
			sum(HardBecause_Other3_5) as HardBecause_Other3_5,
			sum(HardBecause_Other5_10) as HardBecause_Other5_10,
			sum(HardBecause_Other10_) as HardBecause_Other10_,
			sum(HardBecause_Children) as HardBecause_Children,
			
			sum(Theidentity_InService) as Theidentity_InService,
			sum(Theidentity_Retirement) as Theidentity_Retirement,
			sum(Theidentity_Retired) as Theidentity_Retired,
			sum(Theidentity_Illness) as Theidentity_Illness,
			sum(Theidentity_Temporary) as Theidentity_Temporary,
			
			sum(Maritalstatus_Married) as Maritalstatus_Married,
			sum(Maritalstatus_Unmarried) as Maritalstatus_Unmarried,
			sum(Maritalstatus_Divorced) as Maritalstatus_Divorced,
			sum(Maritalstatus_Widowed) as Maritalstatus_Widowed,
			count(StaffID) as [Count], 
			sum([Money]) as [Money]
	from vwDSIRptAllowance
	where (ProjectID like @ProjectId + '%')
	 and (CreateYear like @Year + '%')
	 and (UnitName like '%'+@UnitName+'%')
	group by UnitID,UnitName,CreateYear
	order by CreateYear desc,[Count] desc,[Money] desc,UnitName
end
go
----------------------------------------------------------------------------------------------
--教育局按年度单位统计。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIEduRptYearAllowance')
begin
	print 'drop procedure spDSIEduRptYearAllowance'
	drop procedure spDSIEduRptYearAllowance
end
go
	print 'create procedure spDSIEduRptYearAllowance'
go
create procedure spDSIEduRptYearAllowance
(
	@Year	nvarchar(4),--年度。
	@ProjectId	nvarchar(32)--项目Id。
)
as
begin
	select CreateYear,
	count(UnitID) as UnitCount,
	count(StaffID) as [Count],
	sum(HardCategory_Disaster) as HardCategory_Disaster,
	sum(HardCategory_Disease) as HardCategory_Disease,
	sum(HardCategory_Other) as HardCategory_Other,
	
	sum(HardBecause_Disaster3_5) as HardBecause_Disaster3_5,
	sum(HardBecause_Disaster5_10) as HardBecause_Disaster5_10,
	sum(HardBecause_Disaster10_) as HardBecause_Disaster10_,
	sum(HardBecause_Disease) as HardBecause_Disease,
	sum(HardBecause_Other3_5) as HardBecause_Other3_5,
	sum(HardBecause_Other5_10) as HardBecause_Other5_10,
	sum(HardBecause_Other10_) as HardBecause_Other10_,
	sum(HardBecause_Children) as HardBecause_Children,
	
	sum(Theidentity_InService) as Theidentity_InService,
	sum(Theidentity_Retirement) as Theidentity_Retirement,
	sum(Theidentity_Retired) as Theidentity_Retired,
	sum(Theidentity_Illness) as Theidentity_Illness,
	sum(Theidentity_Temporary) as Theidentity_Temporary,
	
	sum(Maritalstatus_Married) as Maritalstatus_Married,
	sum(Maritalstatus_Unmarried) as Maritalstatus_Unmarried,
	sum(Maritalstatus_Divorced) as Maritalstatus_Divorced,
	sum(Maritalstatus_Widowed) as Maritalstatus_Widowed,
	sum([Money]) as [Money]
	from vwDSIRptAllowance
	where (CreateYear like @Year + '%') and (ProjectID like @ProjectId + '%')
	group by CreateYear
	order by CreateYear desc,UnitCount desc,[Count] desc
end
go
----------------------------------------------------------------------------------------------
--教育局按项目统计。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIEduRptProjectAllowance')
begin
	print 'drop procedure spDSIEduRptProjectAllowance'
	drop procedure spDSIEduRptProjectAllowance
end
go
	print 'create procedure spDSIEduRptProjectAllowance'
go
create procedure spDSIEduRptProjectAllowance
(
	@Year			nvarchar(4),--年度。
	@ProjectId		nvarchar(32)--项目名称。
)
as
begin
	select ProjectName,
	count(UnitID) as UnitCount,
	count(StaffID) as [Count],
	sum(HardCategory_Disaster) as HardCategory_Disaster,
	sum(HardCategory_Disease) as HardCategory_Disease,
	sum(HardCategory_Other) as HardCategory_Other,
	
	sum(HardBecause_Disaster3_5) as HardBecause_Disaster3_5,
	sum(HardBecause_Disaster5_10) as HardBecause_Disaster5_10,
	sum(HardBecause_Disaster10_) as HardBecause_Disaster10_,
	sum(HardBecause_Disease) as HardBecause_Disease,
	sum(HardBecause_Other3_5) as HardBecause_Other3_5,
	sum(HardBecause_Other5_10) as HardBecause_Other5_10,
	sum(HardBecause_Other10_) as HardBecause_Other10_,
	sum(HardBecause_Children) as HardBecause_Children,
	
	sum(Theidentity_InService) as Theidentity_InService,
	sum(Theidentity_Retirement) as Theidentity_Retirement,
	sum(Theidentity_Retired) as Theidentity_Retired,
	sum(Theidentity_Illness) as Theidentity_Illness,
	sum(Theidentity_Temporary) as Theidentity_Temporary,
	
	sum(Maritalstatus_Married) as Maritalstatus_Married,
	sum(Maritalstatus_Unmarried) as Maritalstatus_Unmarried,
	sum(Maritalstatus_Divorced) as Maritalstatus_Divorced,
	sum(Maritalstatus_Widowed) as Maritalstatus_Widowed,
	sum([Money]) as [Money]
	
	from vwDSIRptAllowance
	where (CreateYear like @Year + '%') and (ProjectID like @ProjectId + '%')
	group by ProjectName
	order by [Money] desc,UnitCount desc,[Count] desc
end
go
----------------------------------------------------------------------------------------------
--教育局按时间段统计。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIEduRptTimeAllowance')
begin
	print 'drop procedure spDSIEduRptTimeAllowance'
	drop procedure spDSIEduRptTimeAllowance
end
go
	print 'create procedure spDSIEduRptTimeAllowance'
go
create procedure spDSIEduRptTimeAllowance
(
	@ProjectName	nvarchar(128),--项目名称。
	@StartTime		datetime,--开始时间。
	@EndTime		datetime--结束时间。
)
as
begin
	select data.ProjectName,count(data.UnitName) as UnitCount,count(data.StaffID) as [Count], sum(data.Money) as [Money],max(data.Time) as [Time]
	from  
	(
		select ProjectName,UnitName,StaffID,[Money],[Time]
		from vwDSIAllowance
		where ([Time] between @StartTime and @EndTime)
	) data
	where data.ProjectName like '%' + @ProjectName + '%'
	group by data.ProjectName
	order by [Time] desc
end
go
----------------------------------------------------------------------------------------------
--按补助标准统计。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIEduRptAllowance')
begin
	print 'drop procedure spDSIEduRptAllowance'
	drop procedure spDSIEduRptAllowance
end
go
	print 'create procedure spDSIEduRptAllowance'
go
create procedure spDSIEduRptAllowance
(
	@Year		nvarchar(4),--年度。
	@ProjectId	nvarchar(32)--结束时间。
)
as
begin

	select [Money],
	count(ProjectId) as ProjectCount,
	count(UnitID) as UnitCount,
	count(StaffID) as [Count],
	sum(HardCategory_Disaster) as HardCategory_Disaster,
	sum(HardCategory_Disease) as HardCategory_Disease,
	sum(HardCategory_Other) as HardCategory_Other,
	
	sum(HardBecause_Disaster3_5) as HardBecause_Disaster3_5,
	sum(HardBecause_Disaster5_10) as HardBecause_Disaster5_10,
	sum(HardBecause_Disaster10_) as HardBecause_Disaster10_,
	sum(HardBecause_Disease) as HardBecause_Disease,
	sum(HardBecause_Other3_5) as HardBecause_Other3_5,
	sum(HardBecause_Other5_10) as HardBecause_Other5_10,
	sum(HardBecause_Other10_) as HardBecause_Other10_,
	sum(HardBecause_Children) as HardBecause_Children,
	
	sum(Theidentity_InService) as Theidentity_InService,
	sum(Theidentity_Retirement) as Theidentity_Retirement,
	sum(Theidentity_Retired) as Theidentity_Retired,
	sum(Theidentity_Illness) as Theidentity_Illness,
	sum(Theidentity_Temporary) as Theidentity_Temporary,
	
	sum(Maritalstatus_Married) as Maritalstatus_Married,
	sum(Maritalstatus_Unmarried) as Maritalstatus_Unmarried,
	sum(Maritalstatus_Divorced) as Maritalstatus_Divorced,
	sum(Maritalstatus_Widowed) as Maritalstatus_Widowed
	
	from vwDSIRptAllowance
	where (CreateYear like @Year + '%') and (ProjectID like @ProjectId + '%')
	group by [Money]
	order by [Money] desc,UnitCount desc,[Count] desc
end
go
----------------------------------------------------------------------------------------------
--按个人统计
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIEduRptStaffAllowance')
begin
	print 'drop procedure spDSIEduRptStaffAllowance'
	drop procedure spDSIEduRptStaffAllowance
end
go
	print 'create procedure spDSIEduRptStaffAllowance'
go
create procedure spDSIEduRptStaffAllowance
(
	@Year			nvarchar(4),--年度。
	@ProjectId		nvarchar(32),--项目ID。
	@UnitName		nvarchar(32),--单位名称。
	@StaffName		nvarchar(32)--教职工姓名。
)
as
begin
	select UnitName,StaffName,Gender,IDCard,Age,HardCategory,HardBecause,Theidentity,Maritalstatus,
	count(ProjectID) as ProjectCount, sum([Money]) as [Money]
	from vwDSIAllowance
	where (CreateYear like @Year + '%')
	and (ProjectID like @ProjectId + '%')
	and (UnitName like '%'+@UnitName+'%')
	and (StaffName like '%'+@StaffName+'%')
	group by UnitName,StaffName,Gender,IDCard,Age,HardCategory,HardBecause,Theidentity,Maritalstatus
end
go
----------------------------------------------------------------------------------------------
