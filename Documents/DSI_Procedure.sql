/*
//==========================================================================
//	FileName:DSI_Procedure.sql
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
------------------------------------------------------------------------------

--困难教职工档案列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIStaffInfoListView')
begin
	print 'drop procedure spDSIStaffInfoListView'
	drop procedure spDSIStaffInfoListView
end
go
	print 'create procedure spDSIStaffInfoListView'
go
create procedure spDSIStaffInfoListView
(
	@StaffCodeNameCard	nvarchar(32),--教职工编号/姓名/身份证号。
	@ArchiveStatus		int,--档案状态。
	@CurrentEmployeeID	GUIDEx--当前用户ID。
)
as
begin
	if(isnull(@CurrentEmployeeID,'') <> '')
	begin
		select	a.StaffID,a.StaffCode,a.StaffName,a.Gender,a.IDCard, b.UnitName,
		a.HardCategory,a.StaffStatus,isnull(a.ArchiveStatus,0) as ArchiveStatus
		from tblDSIStaffInfo a
		left outer join tblDSIUnit b
		on b.UnitID = a.UnitID
		where a.UnitID in (select UnitID from tblDSIEmployeeUnit where EmployeeID = @CurrentEmployeeID)
		and (isnull(a.ArchiveStatus,0) = @ArchiveStatus)
		and (a.StaffCode like '%'+@StaffCodeNameCard+'%' or
			 a.StaffName like '%'+@StaffCodeNameCard+'%' or
			 a.IDCard like '%'+@StaffCodeNameCard+'%')
		order by a.CreateDateTime desc,a.StaffCode
	end else begin
		select	a.StaffID,a.StaffCode,a.StaffName,a.Gender,a.IDCard, b.UnitName,
		a.HardCategory,a.StaffStatus,isnull(a.ArchiveStatus,0) as ArchiveStatus
		from tblDSIStaffInfo a
		left outer join tblDSIUnit b
		on b.UnitID = a.UnitID
		where --a.UnitID in (select UnitID from tblDSIEmployeeUnit where EmployeeID = @CurrentEmployeeID)
		--and 
		(isnull(a.ArchiveStatus,0) = @ArchiveStatus)
		and (a.StaffCode like '%'+@StaffCodeNameCard+'%' or
			 a.StaffName like '%'+@StaffCodeNameCard+'%' or
			 a.IDCard like '%'+@StaffCodeNameCard+'%')
		order by a.CreateDateTime desc,a.StaffCode
	end
end
go
----------------------------------------------------------------------------
--删除困难教职工档案。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIDeleteStaffInfo')
begin
	print 'drop procedure spDSIDeleteStaffInfo'
	drop procedure spDSIDeleteStaffInfo
end
go
	print 'create procedure spDSIDeleteStaffInfo'
go
create procedure spDSIDeleteStaffInfo
(
	@StaffID	GUIDEx--教职工ID。
)
as
begin
	declare @result nvarchar(256)
	declare @StaffName nvarchar(256)
	declare  @resultCode int
	set @resultCode = 0
	set @result = ''
	-----------------------------------------
	select top 1 @StaffName = StaffName
	from tblDSIStaffInfo
	where StaffID = @StaffID
	-----------------------------------------
	if exists(select 0 from tblDSIStaffRequest where StaffID = @StaffID)
	begin
		set @resultCode = -1
		set @result = '['+ @StaffName + ']已申请困难教职工，不允许删除!'
	end
	-----------------------------------------
	if(@resultCode = 0)
	begin
		--删除附件。
		delete from tblDSIStaffAttachment where StaffID = @StaffID
		--删除家庭成员。
		delete from tblDSIStaffFamilyMember where StaffID = @StaffID
		--删除教职工档案。
		delete from tblDSIStaffInfo where StaffID = @StaffID
	end
	-----------------------------------------
	select cast(@resultCode as nvarchar(2)) + '|' + @result	
end
go
----------------------------------------------------------------------------
--删除主要困难情况。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIDeleteHardSituation')
begin
	print 'drop procedure spDSIDeleteHardSituation'
	drop procedure spDSIDeleteHardSituation
end
go
	print 'create procedure spDSIDeleteHardSituation'
go
create procedure spDSIDeleteHardSituation
(
	@HardSituationID	GUIDEx--主要困难情况ID。
)
as
begin
	declare @result nvarchar(256)
	declare @HardSituationName nvarchar(256)
	declare  @resultCode int
	set @resultCode = 0
	set @result = ''
	-----------------------------------------
	select top 1 @HardSituationName = HardSituationName
	from tblDSIHardSituation
	where HardSituationID = @HardSituationID
	-----------------------------------------
	if exists(select 0 from tblDSIStaffInfo where HardSituation = @HardSituationID)
	begin
		set @resultCode = -1
		set @result = '['+@HardSituationName+']' + '已经在困难教师档案中被使用,不允许删除！'
	end
	-----------------------------------------
	if(@resultCode = 0)
	begin
		--删除数据。
		delete from tblDSIHardSituation
		where HardSituationID = @HardSituationID
	end
	-----------------------------------------
	select cast(@resultCode as nvarchar(2)) + '|' + @result	
end
go
----------------------------------------------------------------------------
--删除申报轮次。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIDeleteRequestRound' )
begin
	print 'drop procedure spDSIDeleteRequestRound '
	drop procedure spDSIDeleteRequestRound
end
	print 'cerate peocedure spDSIDeleteRequestRound'
go
create procedure spDSIDeleteRequestRound
(
	  @RoundID		GUIDEx--轮次ID。
)
as
begin
	declare @result nvarchar(256)
	declare @RoundName nvarchar(256)
	declare  @resultCode int
	set @resultCode = 0
	set @result = ''
	-----------------------------------------
	select top 1 @RoundName = RoundName
	from tblDSIRequestRound
	where RoundID = @RoundID
	-----------------------------------------
	--tblDSIStaffRequest(职工申报)。
	if exists(select 0 from tblDSIStaffRequest where RoundID = @RoundID )
	begin
		set @resultCode = -1
		set @result = '在申报困难教职工信息中包含['+ @RoundName +']的信息，请先将其删除！'
	end
	-------------------------------------------------------------------
	if(@resultCode = 0)
	begin
		--删除申报轮次。
		delete from tblDSIRequestRound where RoundID = @RoundID
	end
	--
	select cast(@resultCode as nvarchar(2)) + '|' + @result	
end
go
--------------------------------------------------------------------
--申报困难教职工列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIStaffRequestListView')
begin
	print 'drop procedure spDSIStaffRequestListView'
	drop procedure spDSIStaffRequestListView
end
go
	print 'create procedure spDSIStaffRequestListView'
go
create procedure spDSIStaffRequestListView
(
	@RequestRoundID		GUIDEx,--申报轮次ID。
	@StaffNameCodeCard	nvarchar(32),--教职工名字/编号/身份证号。
	@CurrentEmployeeID	GUIDEx--当前用户ID。
)
as
begin
	if(isnull(@RequestRoundID,'') = '')
	begin
	
		select a.RequestID,b.RoundName as RequestRoundName,
		a.StaffID,c.StaffCode,c.StaffName,c.Gender,c.IDCard,d.UnitName,c.HardCategory,c.StaffStatus,
		dbo.fnDSIGetStaffRequestStatus(a.RequestID) as RequestStatus
		from tblDSIStaffRequest a
		inner join tblDSIRequestRound b
		on  b.RoundID = a.RoundID
		inner join tblDSIStaffInfo c
		on c.StaffID = a.StaffID
		left outer join tblDSIUnit d
		on d.UnitID = c.UnitID
		where (c.StaffCode like '%'+@StaffNameCodeCard+'%' or c.StaffName like '%'+@StaffNameCodeCard+'%' or c.IDCard like '%'+@StaffNameCodeCard+'%')
		and (c.UnitID in (select UnitID from tblDSIEmployeeUnit where EmployeeID = @CurrentEmployeeID))
		order by a.CreateRequestTime desc

	end else begin
		
		select a.RequestID,b.RoundName as RequestRoundName,
		a.StaffID,c.StaffCode,c.StaffName,c.Gender,c.IDCard,d.UnitName,c.HardCategory,c.StaffStatus,
		dbo.fnDSIGetStaffRequestStatus(a.RequestID) as RequestStatus
		from tblDSIStaffRequest a
		inner join tblDSIRequestRound b
		on  b.RoundID = a.RoundID
		inner join tblDSIStaffInfo c
		on c.StaffID = a.StaffID
		left outer join tblDSIUnit d
		on d.UnitID = c.UnitID
		where (a.RoundID = @RequestRoundID)
		and (c.StaffCode like '%'+@StaffNameCodeCard+'%' or c.StaffName like '%'+@StaffNameCodeCard+'%' or c.IDCard like '%'+@StaffNameCodeCard+'%')
		and (c.UnitID in (select UnitID from tblDSIEmployeeUnit where EmployeeID = @CurrentEmployeeID))
		order by a.CreateRequestTime desc
	
	end
	
end
go
-------------------------------------------------------------------
--申报困难教职工候选人员列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIStaffRequestEditView')
begin
	print 'drop procedure spDSIStaffRequestEditView'
	drop procedure spDSIStaffRequestEditView
end
go
	print 'create procedure spDSIStaffRequestEditView'
go
create procedure spDSIStaffRequestEditView
(
	@UnitID				GUIDEx,--所属单位ID。
	@StaffCodeNameCard	nvarchar(32),--教职工编号/姓名/身份证号。
	@CurrentEmployeeID	GUIDEx--当前用户ID。
)
as
begin
	 
	if(isnull(@UnitID,'') = '') --所属单位为空。
	begin
	
		select a.StaffID,a.StaffCode,a.StaffName,a.Gender,a.IDCard,b.UnitName,a.HardCategory,a.StaffStatus,dbo.fnDSIGetStaffRequestRound(a.StaffID) as RequestRound
		from tblDSIStaffInfo a
		inner join tblDSIUnit b
		on b.UnitID = a.UnitID
		where (a.ArchiveStatus = 0)
		and (a.UnitID in (select UnitID from tblDSIEmployeeUnit where EmployeeID = @CurrentEmployeeID))
		and (a.StaffCode like '%'+@StaffCodeNameCard+'%' or a.StaffName like '%'+@StaffCodeNameCard+'%' or a.IDCard like '%'+@StaffCodeNameCard+'%')
		order by a.StaffCode
	 
	end else begin--所属单位不为空。
	 
		select a.StaffID,a.StaffCode,a.StaffName,a.Gender,a.IDCard,b.UnitName,a.HardCategory,a.StaffStatus,dbo.fnDSIGetStaffRequestRound(a.StaffID) as RequestRound
		from tblDSIStaffInfo a
		inner join tblDSIUnit b
		on b.UnitID = a.UnitID
		where (a.ArchiveStatus = 0)
		and (a.UnitID = @UnitID)
		and (a.StaffCode like '%'+@StaffCodeNameCard+'%' or a.StaffName like '%'+@StaffCodeNameCard+'%' or a.IDCard like '%'+@StaffCodeNameCard+'%')
		order by a.StaffCode
	end
	
end
go
-------------------------------------------------------------------
--复制申报候选数据。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIStaffRequestCopyView')
begin
	print 'drop procedure spDSIStaffRequestCopyView'
	drop procedure spDSIStaffRequestCopyView
end
go
	print 'create procedure spDSIStaffRequestCopyView'
go
create procedure spDSIStaffRequestCopyView
(
	@SourceRequestRoundID	GUIDEx,--源申报轮次。
	@TargetRequestRoundID	GUIDEx,--目标申报轮次。
	@CurrentEmployeeID		GUIDEx--当前用户。
)
as
begin
	--定义临时候选数据存储。
	declare @tmp_Staff table(StaffID	nvarchar(32),
						 StaffCode	nvarchar(32),
						 StaffName	nvarchar(32),
						 Gender		int default(0),
						 IDCard		nvarchar(32),
						 UnitName	nvarchar(128),
						 HardCategory	int default(0),
						 StaffStatus	int default(1))
	if(isnull(@CurrentEmployeeID,'') = '')--当前用户为空。
	begin
	
		insert into @tmp_Staff(StaffID,StaffCode,StaffName,Gender,IDCard,UnitName,HardCategory,StaffStatus)
		select a.StaffID,b.StaffCode,b.StaffName,b.Gender,b.IDCard,c.UnitName,b.HardCategory,b.StaffStatus
		from tblDSIStaffRequest a
		inner join tblDSIStaffInfo b
		on b.StaffID = a.StaffID
		left outer join tblDSIUnit c
		on c.UnitID = b.UnitID 
		where a.RoundID = @SourceRequestRoundID
		
	end else begin--当前用户不为空。
	
		insert into @tmp_Staff(StaffID,StaffCode,StaffName,Gender,IDCard,UnitName,HardCategory,StaffStatus)
		select a.StaffID,b.StaffCode,b.StaffName,b.Gender,b.IDCard,c.UnitName,b.HardCategory,b.StaffStatus
		from tblDSIStaffRequest a
		inner join tblDSIStaffInfo b
		on b.StaffID = a.StaffID
		left outer join tblDSIUnit c
		on c.UnitID = b.UnitID 
		where (a.RoundID = @SourceRequestRoundID)
		and (b.UnitID in (select UnitID from tblDSIEmployeeUnit where EmployeeID = @CurrentEmployeeID))
		
	end
	--目标申报轮次不为空。
	if(isnull(@TargetRequestRoundID,'') <> '')
	begin
		--删除目标申报轮次已申报过的教职工。
		delete from @tmp_Staff where StaffID in (select StaffID from tblDSIStaffRequest where RoundID = @TargetRequestRoundID)
	end
	--返回数据。
	select StaffID,StaffCode,StaffName,Gender,IDCard,UnitName,HardCategory,StaffStatus
	from @tmp_Staff
	order by StaffCode
end
go
-------------------------------------------------------------------
--删除申报信息。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIDeleteStaffRequest')
begin
	print 'drop procedure spDSIDeleteStaffRequest'
	drop procedure spDSIDeleteStaffRequest
end
go
	print 'create procedure spDSIDeleteStaffRequest'
go
create procedure spDSIDeleteStaffRequest
(
	@RequestID			GUIDEx--申报ID。
)
as
begin
	declare @result nvarchar(256)
	declare @StaffName nvarchar(256)
	declare @RequestRoundName nvarchar(256)
	declare @resultCode int
	set @resultCode = 0
	set @result = ''
	-----------------------------
	--获取数据。
	select top 1 @RequestRoundName = b.RoundName,@StaffName = c.StaffName
	from tblDSIStaffRequest a
	inner join tblDSIRequestRound b
	on b.RoundID = a.RoundID
	inner join tblDSIStaffInfo c
	on c.StaffID = a.StaffID
	where a.RequestID = @RequestID
	
	-----------------------------------------------------------
	--tblDSIFilterResult(系统初选结果)。
	if exists(select 0 from tblDSIFilterResult where RequestID = @RequestID )
	begin
		set @resultCode = -1
		set @result = '在系统初选结果包含['+ @StaffName +']在['+@RequestRoundName+']的信息，不允许将其删除！'
	end
	-----------------------------------------------------------
	--tblDSIEduAuditResult(教育局审核结果)。
	if exists(select 0 from tblDSIEduAuditResult where RequestID = @RequestID )
	begin
		set @resultCode = -1
		set @result = '在教育局审核结果包含['+ @StaffName +']在['+@RequestRoundName+']的信息，不允许将其删除！'
	end
	---------------------------------------------------------
	--tblDSIAllowance(补助发放)。
	if exists(select 0 from tblDSIAllowance where RequestID = @RequestID)
	begin
		set @resultCode = -1
		set @result = '在补助发放中包含['+ @StaffName +']在['+@RequestRoundName+']的信息，不允许将其删除！'
	end
	--------------------------------------------------------
	if(@resultCode = 0)
	begin
		--删除申报信息。
		delete from tblDSIStaffRequest where RequestID = @RequestID
	end
	--
	select cast(@resultCode as nvarchar(2)) + '|' + @result
end
go
---------------------------------------------------------------------------------
--删除初选轮次
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIDeleteFilterRound' )
begin
	print 'drop procedure spDSIDeleteFilterRound'
	drop procedure spDSIDeleteFilterRound
end
go
	print 'create procedure spDSIDeleteFilterRound'
go
create procedure spDSIDeleteFilterRound
(
	@RoundID		GUIDEx--轮次ID。
)
as
begin
	declare @result nvarchar(256)
	declare @RoundName nvarchar(256)
	declare @resultCode int
	set @resultCode = 0
	set @result = ''
	-----------------------------
	select top 1 @RoundName = RoundName
	from tblDSIFilterRound where RoundID = @RoundID
	--------------------------------------------------------------------------
	--tblDSIFilterResult(初选结果)。
	if exists(select 0 from tblDSIFilterResult where FilterRoundID = @RoundID)
	begin
		set @resultCode = -1
		set @result = '在初选结果中包含['+ @RoundName +']轮次下的数据，不允许将其删除！'
	end
	--------------------------------------------------------------------------
	if(@resultCode = 0)
	begin
		--删除初选轮次下的条件。
		delete from tblDSIFilterRoundSettings where FilterRoundID = @RoundID
		--删除初选轮次。
		delete from tblDSIFilterRound where RoundID = @RoundID
	end
	--
	select cast(@resultCode as nvarchar(2)) + '|' + @result	
end
go
----------------------------------------------------------------------------------------------
--系统初选结果列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIFilterResultListView')
begin
	print 'drop procedure spDSIFilterResultListView'
	drop procedure spDSIFilterResultListView
end
go
	print 'create procedure spDSIFilterResultListView'
go
create procedure spDSIFilterResultListView
(
	@FilterRoundID		GUIDEx--初选轮次ID。
)
as
begin
	if(isnull(@FilterRoundID,'') = '') --初选轮次ID为空。
	begin
		
		select a.RequestID,e.RoundName as FilterRoundName,c.RoundName as RequestRoundName,
		b.StaffID,d.StaffCode,d.StaffName,d.Gender,d.IDCard,f.UnitName,d.HardCategory,d.StaffStatus,
		dbo.fnDSIGetStaffRequestStatus(a.RequestID) as RequestStatus,
		b.CreateRequestTime as RequestTime,a.FilterTime,a.EmployeeName
		from tblDSIFilterResult a
		inner join tblDSIStaffRequest b
		on b.RequestID = a.RequestID
		inner join tblDSIRequestRound c
		on c.RoundID = b.RoundID
		inner join tblDSIStaffInfo d
		on d.StaffID = b.StaffID
		inner join tblDSIFilterRound e
		on e.RoundID = a.FilterRoundID
		left outer join tblDSIUnit f
		on f.UnitID = d.UnitID
		order by e.RoundName, a.FilterTime desc,c.RoundName,f.UnitCode, b.CreateRequestTime desc, d.StaffCode
			
	end else begin--初选轮次ID不为空。
	
		select a.RequestID,e.RoundName as FilterRoundName,c.RoundName as RequestRoundName,
		b.StaffID,d.StaffCode,d.StaffName,d.Gender,d.IDCard,f.UnitName,d.HardCategory,d.StaffStatus,
		dbo.fnDSIGetStaffRequestStatus(a.RequestID) as RequestStatus,
		b.CreateRequestTime as RequestTime,a.FilterTime,a.EmployeeName
		from tblDSIFilterResult a
		inner join tblDSIStaffRequest b
		on b.RequestID = a.RequestID
		inner join tblDSIRequestRound c
		on c.RoundID = b.RoundID
		inner join tblDSIStaffInfo d
		on d.StaffID = b.StaffID
		inner join tblDSIFilterRound e
		on e.RoundID = a.FilterRoundID
		left outer join tblDSIUnit f
		on f.UnitID = d.UnitID
		where a.FilterRoundID = @FilterRoundID
		order by e.RoundName, a.FilterTime desc,c.RoundName,f.UnitCode, b.CreateRequestTime desc, d.StaffCode
				
	end
end
go
-------------------------------------------------------------------------------------------
--教育局确认审核候选数据。
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
	@RequestRoundID		GUIDEx,--申报轮次ID。
	@FilterRoundID		GUIDEx,--初选轮次ID。
	@StaffCodeNameCard	nvarchar(32),--职工姓名。
	@IsNoFilter			int = 1--是否包含未筛选数据。
)
as
begin

	if(@IsNoFilter = 0)--不包含未筛选数据。
	begin
		if(isnull(@RequestRoundID,'') = '')--申报轮次为空。
		begin
			if(isnull(@FilterRoundID,'') = '')--初选轮次为空。
			begin
			
				select a.RequestID,e.RoundName as RequestRoundName, c.RoundName as FilterRoundName,
				b.StaffID,d.StaffCode,d.StaffName,d.Gender,d.IDCard,f.UnitName,d.HardCategory,d.StaffStatus,
				b.CreateRequestTime as RequestTime
				from tblDSIFilterResult a
				inner join tblDSIStaffRequest b
				on b.RequestID = a.RequestID
				inner join tblDSIRequestRound e
				on e.RoundID = b.RoundID
				inner join tblDSIFilterRound c
				on c.RoundID = a.FilterRoundID
				inner join tblDSIStaffInfo d
				on d.StaffID = b.StaffID
				left outer join tblDSIUnit f
				on f.UnitID = d.UnitID
				where (a.RequestID not in (select RequestID from tblDSIEduAuditResult))
				and (d.StaffCode like '%'+@StaffCodeNameCard+'%' or d.StaffName like '%'+@StaffCodeNameCard+'%' or d.IDCard like '%'+@StaffCodeNameCard+'%')
				order by e.StartTime desc,a.FilterTime desc,f.UnitCode, d.StaffCode
				
			end else begin--初选轮次不为空。
			
				select a.RequestID,e.RoundName as RequestRoundName, c.RoundName as FilterRoundName,
				b.StaffID,d.StaffCode,d.StaffName,d.Gender,d.IDCard,f.UnitName,d.HardCategory,d.StaffStatus,
				b.CreateRequestTime as RequestTime
				from tblDSIFilterResult a
				inner join tblDSIStaffRequest b
				on b.RequestID = a.RequestID
				inner join tblDSIRequestRound e
				on e.RoundID = b.RoundID
				inner join tblDSIFilterRound c
				on c.RoundID = a.FilterRoundID
				inner join tblDSIStaffInfo d
				on d.StaffID = b.StaffID
				left outer join tblDSIUnit f
				on f.UnitID = d.UnitID
				where (a.FilterRoundID = @FilterRoundID) and (a.RequestID not in (select RequestID from tblDSIEduAuditResult))
				and (d.StaffCode like '%'+@StaffCodeNameCard+'%' or d.StaffName like '%'+@StaffCodeNameCard+'%' or d.IDCard like '%'+@StaffCodeNameCard+'%')
				order by e.StartTime desc,a.FilterTime desc,f.UnitCode, d.StaffCode
				
			end
		end else begin--申报轮次不为空。
		
			if(isnull(@FilterRoundID,'') = '')--初选轮次为空。
			begin
			
				select a.RequestID,e.RoundName as RequestRoundName, c.RoundName as FilterRoundName,
				b.StaffID,d.StaffCode,d.StaffName,d.Gender,d.IDCard,f.UnitName,d.HardCategory,d.StaffStatus,
				b.CreateRequestTime as RequestTime
				from tblDSIFilterResult a
				inner join tblDSIStaffRequest b
				on b.RequestID = a.RequestID
				inner join tblDSIRequestRound e
				on e.RoundID = b.RoundID
				inner join tblDSIFilterRound c
				on c.RoundID = a.FilterRoundID
				inner join tblDSIStaffInfo d
				on d.StaffID = b.StaffID
				left outer join tblDSIUnit f
				on f.UnitID = d.UnitID
				where (b.RoundID = @RequestRoundID) and (a.RequestID not in (select RequestID from tblDSIEduAuditResult))
				and (d.StaffCode like '%'+@StaffCodeNameCard+'%' or d.StaffName like '%'+@StaffCodeNameCard+'%' or d.IDCard like '%'+@StaffCodeNameCard+'%')
				order by e.StartTime desc,a.FilterTime desc,f.UnitCode, d.StaffCode
				
			end else begin--初选轮次不为空。
			
				select a.RequestID,e.RoundName as RequestRoundName, c.RoundName as FilterRoundName,
				b.StaffID,d.StaffCode,d.StaffName,d.Gender,d.IDCard,f.UnitName,d.HardCategory,d.StaffStatus,
				b.CreateRequestTime as RequestTime
				from tblDSIFilterResult a
				inner join tblDSIStaffRequest b
				on b.RequestID = a.RequestID
				inner join tblDSIRequestRound e
				on e.RoundID = b.RoundID
				inner join tblDSIFilterRound c
				on c.RoundID = a.FilterRoundID
				inner join tblDSIStaffInfo d
				on d.StaffID = b.StaffID
				left outer join tblDSIUnit f
				on f.UnitID = d.UnitID
				where (a.FilterRoundID = @FilterRoundID) and (b.RoundID = @RequestRoundID) and (a.RequestID not in (select RequestID from tblDSIEduAuditResult))
				and (d.StaffCode like '%'+@StaffCodeNameCard+'%' or d.StaffName like '%'+@StaffCodeNameCard+'%' or d.IDCard like '%'+@StaffCodeNameCard+'%')
				order by e.StartTime desc,a.FilterTime desc,f.UnitCode, d.StaffCode
				
			end
		end
	end else begin--包含未筛选数据。
		if(isnull(@RequestRoundID,'') = '')--申报轮次为空。
		begin
			if(isnull(@FilterRoundID,'') = '')--初选轮次为空。
			begin
			
				select a.RequestID,e.RoundName as RequestRoundName,c.RoundName as FilterRoundName,
				a.StaffID,d.StaffCode,d.StaffName,d.Gender,d.IDCard,f.UnitName,d.HardCategory,d.StaffStatus,
				a.CreateRequestTime as RequestTime
				from tblDSIStaffRequest a
				inner join tblDSIRequestRound e
				on e.RoundID = a.RoundID
				left outer join tblDSIFilterResult b
				on b.RequestID = a.RequestID
				left outer join tblDSIFilterRound c
				on c.RoundID = b.FilterRoundID
				inner join tblDSIStaffInfo d
				on d.StaffID = a.StaffID
				left outer join tblDSIUnit f
				on f.UnitID = d.UnitID
				where (a.RequestID not in (select RequestID from tblDSIEduAuditResult))
				and (d.StaffCode like '%'+@StaffCodeNameCard+'%' or d.StaffName like '%'+@StaffCodeNameCard+'%' or d.IDCard like '%'+@StaffCodeNameCard+'%')
				order by e.StartTime desc,b.FilterTime desc,f.UnitCode, d.StaffCode
				
			end else begin--初选轮次不为空。
				
				select a.RequestID,e.RoundName as RequestRoundName,c.RoundName as FilterRoundName,
				a.StaffID,d.StaffCode,d.StaffName,d.Gender,d.IDCard,f.UnitName,d.HardCategory,d.StaffStatus,
				a.CreateRequestTime as RequestTime
				from tblDSIStaffRequest a
				inner join tblDSIRequestRound e
				on e.RoundID = a.RoundID
				left outer join tblDSIFilterResult b
				on b.RequestID = a.RequestID
				left outer join tblDSIFilterRound c
				on c.RoundID = b.FilterRoundID
				inner join tblDSIStaffInfo d
				on d.StaffID = a.StaffID
				left outer join tblDSIUnit f
				on f.UnitID = d.UnitID
				where (isnull(b.FilterRoundID,@FilterRoundID) = @FilterRoundID) and (a.RequestID not in (select RequestID from tblDSIEduAuditResult))
				and (d.StaffCode like '%'+@StaffCodeNameCard+'%' or d.StaffName like '%'+@StaffCodeNameCard+'%' or d.IDCard like '%'+@StaffCodeNameCard+'%')
				order by e.StartTime desc,b.FilterTime desc,f.UnitCode, d.StaffCode
				
			end
		end else begin--申报轮次不为空。
			if(isnull(@FilterRoundID,'') = '')--初选轮次为空。
			begin
			
				select a.RequestID,e.RoundName as RequestRoundName,c.RoundName as FilterRoundName,
				a.StaffID,d.StaffCode,d.StaffName,d.Gender,d.IDCard,f.UnitName,d.HardCategory,d.StaffStatus,
				a.CreateRequestTime as RequestTime
				from tblDSIStaffRequest a
				inner join tblDSIRequestRound e
				on e.RoundID = a.RoundID
				left outer join tblDSIFilterResult b
				on b.RequestID = a.RequestID
				left outer join tblDSIFilterRound c
				on c.RoundID = b.FilterRoundID
				inner join tblDSIStaffInfo d
				on d.StaffID = a.StaffID
				left outer join tblDSIUnit f
				on f.UnitID = d.UnitID
				where (a.RoundID = @RequestRoundID) and (a.RequestID not in (select RequestID from tblDSIEduAuditResult))
				and (d.StaffCode like '%'+@StaffCodeNameCard+'%' or d.StaffName like '%'+@StaffCodeNameCard+'%' or d.IDCard like '%'+@StaffCodeNameCard+'%')
				order by e.StartTime desc,b.FilterTime desc,f.UnitCode, d.StaffCode
				
			end else begin--初选轮次不为空。
				
				select a.RequestID,e.RoundName as RequestRoundName,c.RoundName as FilterRoundName,
				a.StaffID,d.StaffCode,d.StaffName,d.Gender,d.IDCard,f.UnitName,d.HardCategory,d.StaffStatus,
				a.CreateRequestTime as RequestTime
				from tblDSIStaffRequest a
				inner join tblDSIRequestRound e
				on e.RoundID = a.RoundID
				left outer join tblDSIFilterResult b
				on b.RequestID = a.RequestID
				left outer join tblDSIFilterRound c
				on c.RoundID = b.FilterRoundID
				inner join tblDSIStaffInfo d
				on d.StaffID = a.StaffID
				left outer join tblDSIUnit f
				on f.UnitID = d.UnitID
				where (a.RoundID = @RequestRoundID) and (isnull(b.FilterRoundID,@FilterRoundID) = @FilterRoundID)
				and (a.RequestID not in (select RequestID from tblDSIEduAuditResult))
				and (d.StaffCode like '%'+@StaffCodeNameCard+'%' or d.StaffName like '%'+@StaffCodeNameCard+'%' or d.IDCard like '%'+@StaffCodeNameCard+'%')
				order by e.StartTime desc,b.FilterTime desc,f.UnitCode, d.StaffCode
				
			end
		end
	end
end
go
------------------------------------------------------------------------------------------
--教育局审核结果列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIEduAuditResultListView')
begin
	print 'drop procedure spDSIEduAuditResultListView'
	drop procedure spDSIEduAuditResultListView
end
go
	print 'create procedure spDSIEduAuditResultListView'
go
create procedure spDSIEduAuditResultListView
(
	@RequestRoundID			GUIDEx,--申报轮次ID。
	@StaffCodeNameCard		nvarchar(32)--职工编号/姓名/身份证号。
)
as
begin
	select a.RequestID,c.RoundName as RequestRoundName,
	b.StaffID,d.StaffCode,d.StaffName,d.Gender,d.IDCard,e.UnitName,--d.HardCategory,d.StaffStatus,
	b.CreateRequestTime as RequestTime, a.AuditTime,dbo.fnDSIGetStaffRequestStatus(a.RequestID) as StatusName--a.EmployeeName as AuditEmployeeName
	from tblDSIEduAuditResult a
	inner join tblDSIStaffRequest b
	on b.RequestID = a.RequestID
	inner join tblDSIRequestRound c
	on c.RoundID = b.RoundID
	inner join tblDSIStaffInfo d
	on d.StaffID = b.StaffID
	left outer join tblDSIUnit e
	on e.UnitID = d.UnitID
	where (b.RoundID like @RequestRoundID + '%')
	and (d.StaffCode like '%'+@StaffCodeNameCard+'%' or d.StaffName like '%'+@StaffCodeNameCard+'%' or d.IDCard like '%'+@StaffCodeNameCard+'%')
	order by c.StartTime desc, e.UnitCode,b.CreateRequestTime desc,d.StaffCode
end
go
------------------------------------------------------------------------------------------
--删除教育局审核结果。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIDeleteEduAuditResult')
begin
	print 'drop procedure spDSIDeleteEduAuditResult'
	drop procedure spDSIDeleteEduAuditResult
end
go
	print 'create procedure spDSIDeleteEduAuditResult'
go
create procedure spDSIDeleteEduAuditResult
(
	@RequestID	GUIDEx--申报ID。
)
as
begin
	declare @result		nvarchar(256)
	declare @StaffName	nvarchar(256)
	declare @RequestRoundName	nvarchar(256)
	declare @resultCode int
	set @resultCode = 0
	set @result = ''
	-----------------------------------------------------------
	select top 1 @RequestRoundName = c.RoundName, @StaffName = d.StaffName
	from tblDSIEduAuditResult a
	inner join tblDSIStaffRequest b
	on b.RequestID = a.RequestID
	inner join tblDSIRequestRound c
	on c.RoundID = b.RoundID
	inner join tblDSIStaffInfo d
	on d.StaffID = b.StaffID
	where a.RequestID = @RequestID
	-----------------------------------------------------------
	--tblDSIAllowance(补助发放)
	if exists(select 0 from tblDSIAllowance where RequestID = @RequestID)
	begin
		set @resultCode = -1
		set @result = '补助发放中已存在['+@StaffName+'('+@RequestRoundName+')]的记录，不允许将其删除！'
	end
	-----------------------------------------------------------
	if(@resultCode = 0)
	begin
		--删除教育局审核结果。
		delete from tblDSIEduAuditResult where RequestID = @RequestID
	end
	--
	select cast(@resultCode as nvarchar(2)) + '|' + @result
end
go
------------------------------------------------------------------------------------------
--补助轮次设置列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIAllowanceRoundListView')
begin
	print 'drop procedure spDSIAllowanceRoundListView'
	drop procedure spDSIAllowanceRoundListView
end
go
	print 'create procedure spDSIAllowanceRoundListView'
go
create procedure spDSIAllowanceRoundListView
(
	@RoundName	nvarchar(64)
)
as
begin
	select RoundID,RoundName,RoundTime,PublicityStatus,
	dbo.fnDSIGetAllowanceSubsidies(RoundID) as Subsidies,PublicityStartTime,PublicityEndTime
	from tblDSIAllowanceRound
	where RoundName like '%'+@RoundName+'%'
	order by OrderNO
end
go
------------------------------------------------------------------------------------------
--删除补助轮次
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIDeleteAllowanceRound')
begin
	print 'drop procedure spDSIDeleteAllowanceRound '
	drop procedure spDSIDeleteAllowanceRound
end
go
	print 'create procedure spDSIDeleteAllowanceRound'
go
create procedure spDSIDeleteAllowanceRound
(
	@RoundID		GUIDEx--补助轮次ID。
)
as
begin
	declare @result nvarchar(256)
	declare @RoundName nvarchar(256)
	declare @resultCode int
	set @resultCode = 0
	set @result = ''
	-----------------------------
	select top 1 @RoundName = RoundName
	from tblDSIAllowanceRound
	where RoundID = @RoundID
	-----------------------------------------------------------------------------------------
	--tblDSIAllowance(补助发放)。
	if exists(select 0 from tblDSIAllowance where RoundID = @RoundID )
	begin
		set @resultCode = -1
		set @result = '在补助发放中包含['+ @RoundName +']信息，请先将其删除！'
	end
	----------------------------------------------------------------------------------------
	if(@resultCode = 0)
	begin
		--删除补助档次。
		delete from tblDSIAllowanceRoundSubsidies where RoundID = @RoundID
		--删除补助轮次。
		delete from tblDSIAllowanceRound where RoundID = @RoundID
	end
	--
	select cast(@resultCode as nvarchar(2)) + '|' + @result
end
go
--------------------------------------------------------------------------------------------
--补助发放列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIAllowanceListView')
begin
	print 'drop procedure spDSIAllowanceListView '
	drop procedure spDSIAllowanceListView
end
go
	print 'create peocedure spDSIAllowanceListView'
go
create procedure spDSIAllowanceListView
(
	@AllowanceRoundID	GUIDEx,--补助轮次ID。
	@Status				nvarchar(5),--补助状态。
	@StaffCodeNameCard	nvarchar(256)--教职工编号/姓名身份证号。
)
as
begin

	if(isnull(@Status,'') = '')
	begin

		select a.RequestID,a.RoundID as AllowanceRoundID,b.RoundName as AllowanceRoundName,
		c.StaffID,d.StaffCode,d.StaffName,d.Gender,d.IDCard,a.UnitName,a.Paid,a.GrantTime,isnull(a.Status,0) as Status,a.Description
		from tblDSIAllowance a
		inner join tblDSIAllowanceRound b
		on b.RoundID = a.RoundID
		inner join tblDSIStaffRequest c
		on c.RequestID = a.RequestID
		inner join tblDSIStaffInfo d
		on d.StaffID = c.StaffID
		where (a.RoundID like '%'+@AllowanceRoundID+'%') 
		and (d.StaffCode like '%'+@StaffCodeNameCard+'%' or d.StaffName like '%'+@StaffCodeNameCard+'%' or d.IDCard like '%'+@StaffCodeNameCard+'%')
		order by a.GrantTime desc,a.UnitName,d.StaffName

	end else begin

		select a.RequestID,a.RoundID as AllowanceRoundID,b.RoundName as AllowanceRoundName,
		c.StaffID,d.StaffCode,d.StaffName,d.Gender,d.IDCard,a.UnitName,a.Paid,a.GrantTime,isnull(a.Status,0) as Status,a.Description
		from tblDSIAllowance a
		inner join tblDSIAllowanceRound b
		on b.RoundID = a.RoundID
		inner join tblDSIStaffRequest c
		on c.RequestID = a.RequestID
		inner join tblDSIStaffInfo d
		on d.StaffID = c.StaffID
		where a.Status = @Status
		and (a.RoundID like '%'+@AllowanceRoundID+'%') 
		and (d.StaffCode like '%'+@StaffCodeNameCard+'%' or d.StaffName like '%'+@StaffCodeNameCard+'%' or d.IDCard like '%'+@StaffCodeNameCard+'%')
		order by a.GrantTime desc,a.UnitName,d.StaffName

	end
end
go
------------------------------------------------------------------------------------------------
--补助批量发放。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIBatchAllowance')
begin
	print 'drop procedure spDSIBatchAllowance '
	drop procedure spDSIBatchAllowance
end
go
	print 'create peocedure spDSIBatchAllowance'
go
create procedure spDSIBatchAllowance
(
	@RequestRoundID		GUIDEx,--申报轮次ID。
	@AllowanceRoundID	GUIDEx,--补助轮次ID。
	@StaffCodeNameCard	nvarchar(32)--教职工编号/姓名/身份证号。
)
as
begin
	declare @tmp_result table(RequestID		nvarchar(32),
							  StaffID		nvarchar(32),
							  StaffCode		nvarchar(32),
							  StaffName		nvarchar(128),
							  Gender		int,
							  IDCard		nvarchar(32),
							  UnitName		nvarchar(128),
							  Paid			float default(0),
							  Beneficiary	nvarchar(128),
							  Description	nvarchar(512))
	--写入候选人员数据。
	insert into @tmp_result(RequestID,StaffID,StaffCode,StaffName,Gender,IDCard,UnitName)
	select a.RequestID,b.StaffID,c.StaffCode,c.StaffName,c.Gender,c.IDCard,d.UnitName
	from tblDSIEduAuditResult a
	inner join tblDSIStaffRequest b
	on b.RequestID = a.RequestID
	inner join tblDSIStaffInfo c
	on c.StaffID = b.StaffID
	left outer join tblDSIUnit d
	on d.UnitID = c.UnitID
	where b.RoundID = @RequestRoundID
	and (c.StaffCode like '%'+@StaffCodeNameCard+'%' or c.StaffName like '%'+@StaffCodeNameCard+'%' or c.IDCard like '%'+@StaffCodeNameCard+'%')
	--插入补助数据。
	if(isnull(@AllowanceRoundID,'') <> '')
	begin
		update @tmp_result set Paid = a.RoundMoney,Beneficiary = StaffName,Description = a.Description
		from tblDSIAllowanceRound a
		where a.RoundID = @AllowanceRoundID
	end
	------------------------------------------------------------------------------------------------
	select RequestID,StaffID,StaffCode,StaffName,Gender,IDCard,UnitName,Paid,Beneficiary,Description
	from @tmp_result
	order by UnitName,StaffCode
end
go
-----------------------------------------------------------------------------------------------------
--用户单位列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIEmployeeUnitListView')
begin
	print 'drop procedure spDSIEmployeeUnitListView'
	drop procedure spDSIEmployeeUnitListView
end
go
	print 'create procedure spDSIEmployeeUnitListView'
go
create procedure spDSIEmployeeUnitListView
(
	@EmployeeName	nvarchar(32)--用户名。
)
as
begin
	select a.EmployeeID,b.EmployeeCode, b.EmployeeName,c.UnitName
	from tblDSIEmployeeUnit a
	inner join tblDSIEmployee b
	on b.EmployeeID = a.EmployeeID
	left outer join tblDSIUnit c
	on c.UnitID = a.UnitID
	where (b.EmployeeCode like '%'+@EmployeeName+'%' or b.EmployeeName like '%'+@EmployeeName+'%')
	order by a.EmployeeID,b.EmployeeCode,c.UnitCode
end
go
---------------------------------------------------------------------------------------------------
--公示信息列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIPublicityListView')
begin
	print 'drop procedure spDSIPublicityListView'
	drop procedure spDSIPublicityListView
end
go
	print 'create procedure spDSIPublicityListView'
go
create procedure spDSIPublicityListView
as
begin
	--初选轮次公示。
	select RoundID,RoundName,'Filter' as Type,PublicityStartTime as [Time]
	from tblDSIFilterRound
	where (PublicityStatus = 1)
	and (getdate() between PublicityStartTime and PublicityEndTime)

	union
	
	--补助轮次公示。
	select RoundID,RoundName,'Allowance' as Type,PublicityStartTime as [Time]
	from tblDSIAllowanceRound
	where (PublicityStatus = 1)
	and (getdate() between PublicityStartTime and PublicityEndTime)
	
	union
	
	--下载附件。
	select DownloadID as RoundID,DownloadName as RoundName,'Down' as Type, LastModifyTime as [Time]
	from tblDSIDownload 
	where Status = 1
	
	order by [Time] desc
end
go
----------------------------------------------------------------------------------------
--初选公示明细数据。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIPublicityFilterDetails')
begin
	print 'drop procedure spDSIPublicityFilterDetails'
	drop procedure spDSIPublicityFilterDetails
end
go
	print 'create procedure spDSIPublicityFilterDetails'
go
create procedure spDSIPublicityFilterDetails
(
	@FilterRoundID	GUIDEx--筛选轮次ID。
)
as
begin
	select c.RoundName as RequestRoundName,
	d.StaffCode,d.StaffName,d.Gender,d.IDCard,e.UnitName,a.FilterTime
	from tblDSIFilterResult a
	inner join tblDSIStaffRequest b
	on b.RequestID = a.RequestID
	inner join tblDSIRequestRound c
	on c.RoundID = b.RoundID
	inner join tblDSIStaffInfo d
	on d.StaffID = b.StaffID
	left outer join tblDSIUnit e
	on e.UnitID = d.UnitID
	where a.FilterRoundID = @FilterRoundID
	order by c.StartTime desc,e.UnitCode,d.StaffCode
end
go
-----------------------------------------------------------------------------------------------------
--补助公示明细数据。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIPublicityAllowanceDetails')
begin
	print 'drop procedure spDSIPublicityAllowanceDetails'
	drop procedure spDSIPublicityAllowanceDetails
end
go
	print 'create procedure spDSIPublicityAllowanceDetails'
go
create procedure spDSIPublicityAllowanceDetails
(
	@AllowanceRoundID	GUIDEx--补助轮次ID。
)
as
begin
	select c.RoundName as RequestRoundName,
	d.StaffCode,d.StaffName,d.Gender,d.IDCard,e.UnitName,
	a.GrantTime,a.Paid,a.Beneficiary
	from tblDSIAllowance a
	inner join tblDSIStaffRequest b
	on b.RequestID = a.RequestID
	inner join tblDSIRequestRound c
	on c.RoundID = b.RoundID
	inner join tblDSIStaffInfo d
	on d.StaffID = b.StaffID
	left outer join tblDSIUnit e
	on e.UnitID = d.UnitID
	where a.RoundID = @AllowanceRoundID
	and a.Status = 1
	order by c.StartTime desc,e.UnitCode,d.StaffCode
end
go
-----------------------------------------------------------------------------------------------------