-----------------------------------------------------------------------------------------------------------------------
--补助档次设置表。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIAllowanceRoundSubsidies')
begin
	print 'drop table tblDSIAllowanceRoundSubsidies'
	drop table tblDSIAllowanceRoundSubsidies
end
go
	print 'create table tblDSIAllowanceRoundSubsidies'
go
create table tblDSIAllowanceRoundSubsidies
(
	RoundID			GUIDEx,--补助轮次ID。
	Subsidies		float default(0),--档次值。
	Description		nvarchar(128),--描述信息。
	
	constraint PK_tblDSIAllowanceRoundSubsidies primary key(RoundID,Subsidies)--主键约束。
)
go
-----------------------------------------------------------------------------------------------------------------------
--tblDSIAllowance添加字段.
if not exists(select 0 from syscolumns a inner join sysobjects b on b.id = a.id  and b.xtype = 'u' where b.name = 'tblDSIAllowance' and a.name = 'UnitID')
begin
	print 'tblDSIAllowance表中添加单位ID字段'
	alter table tblDSIAllowance add UnitID GUIDEx null
end
go
if not exists(select 0 from syscolumns a inner join sysobjects b on b.id = a.id  and b.xtype = 'u' where b.name = 'tblDSIAllowance' and a.name = 'UnitName')
begin
	print 'tblDSIAllowance表中添加单位名称字段'
	alter table tblDSIAllowance add UnitName nvarchar(128)
end
go
if not exists(select 0 from syscolumns a inner join sysobjects b on b.id = a.id  and b.xtype = 'u' where b.name = 'tblDSIAllowance' and a.name = 'Status')
begin
	print 'tblDSIAllowance表中添加状态字段'
	alter table tblDSIAllowance add Status int default(0)
end
go
-----------------------------------------------------------------------------------------------------------------------
--职工基本信息添加档案状态。
if not exists(select 0 from syscolumns a inner join sysobjects b on b.id = a.id  and b.xtype = 'u' where b.name = 'tblDSIStaffInfo' and a.name = 'ArchiveStatus')
begin
	print 'tblDSIStaffInfo表中添加档案状态名称字段'
	alter table tblDSIStaffInfo add ArchiveStatus int default(0)
end
go
-----------------------------------------------------------------------------------------------------------------------
--职工档案调度表。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIStaffArchiveInvoke')
begin
	print 'drop table tblDSIStaffArchiveInvoke'
	drop table tblDSIStaffArchiveInvoke
end
go
	print 'create table tblDSIStaffArchiveInvoke'
go
create table tblDSIStaffArchiveInvoke
(
	InvokeID		GUIDEx,--档案调动ID。
	
	StaffID			GUIDEx,--教职工ID。
	
	FromUnitID		GUIDEx,--转出单位ID。
	FromUnitName	nvarchar(128),--转出单位名称。
	FromTime		datetime default(getdate()),--转出时间。
	
	ToUnitID		GUIDEx null,--转入单位ID。
	ToUnitName		nvarchar(128),--转入单位名称。
	ToTime			datetime default(null),--转入时间。
	
	ArchiveStatus	int default(0),--处理状态。
	
	constraint PK_tblDSIStaffArchiveInvoke primary key(InvokeID)--主键约束。
)
go
-----------------------------------------------------------------------------------------------------------------------
--职工档案调度列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIStaffArchiveInvokeListView')
begin
	print 'drop procedure spDSIStaffArchiveInvokeListView'
	drop procedure spDSIStaffArchiveInvokeListView
end
go
	print 'create procedure spDSIStaffArchiveInvokeListView'
go
create procedure spDSIStaffArchiveInvokeListView
(
	@EmployeeID	GUIDEx--当前用户ID。
)
as
begin
	select a.InvokeID,a.StaffID,b.StaffCode,b.StaffName,b.Gender,b.IDCard,
	a.FromUnitName,a.FromTime,a.ToUnitName
	from tblDSIStaffArchiveInvoke a
	inner join tblDSIStaffInfo b
	on b.StaffID = a.StaffID
	where (a.ArchiveStatus = 1)
	and (a.ToUnitID in (select UnitID from tblDSIEmployeeUnit where EmployeeID = @EmployeeID))
end
go
-----------------------------------------------------------------------------------------------------------------------
--查看教职工补助明细。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIStaffAllowanceDetailView')
begin
	print 'drop procedure spDSIStaffAllowanceDetailView'
	drop procedure spDSIStaffAllowanceDetailView
end
go
	print 'create procedure spDSIStaffAllowanceDetailView'
go
create procedure spDSIStaffAllowanceDetailView
(
	@RequestRoundID		GUIDEx,--申报轮次名称。
	@UnitID				GUIDEx,--工作单位。
	@StaffName			nvarchar(64),--教职工名称。
	@EmployeeID			GUIDEx --当前用户ID。
)
as
begin
	select c.RoundName,b.StaffID,d.StaffCode,d.StaffName,d.Gender,d.IDCard,e.UnitName,
	a.GrantTime,a.Paid,
	a.UnitName as AllowanceUnitName
	from tblDSIAllowance a
	inner join tblDSIStaffRequest b
	on b.RequestID = a.RequestID
	inner join tblDSIRequestRound c 
	on c.RoundID = b.RoundID
	inner join tblDSIStaffInfo d
	on d.StaffID = b.StaffID
	left outer join tblDSIUnit e
	on e.UnitID = d.UnitID
	where (a.Status = 1)
	and (d.UnitID in (select UnitID from tblDSIEmployeeUnit where EmployeeID = @EmployeeID))
	and (b.RoundID like @RequestRoundID+'%')
	and (d.UnitID like @UnitID + '%')
	and ((d.StaffCode like '%'+@StaffName+'%') or (d.StaffName like '%'+@StaffName+'%'))
	order by a.GrantTime desc,e.UnitName,d.StaffName
end
go
-----------------------------------------------------------------------------------------------------------------------
--分单位按年份统计的左边单位年份。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIStatisticsUnitPointYearLeft')
begin
	print 'drop procedure spDSIStatisticsUnitPointYearLeft'
	drop procedure spDSIStatisticsUnitPointYearLeft
end
go
	print 'create procedure spDSIStatisticsUnitPointYearLeft'
go
create procedure spDSIStatisticsUnitPointYearLeft
(
	@EmployeeID	GUIDEx--当前用户ID。
)
as
begin
	declare @result table(PID		nvarchar(128),--父ID。
						  ID		nvarchar(128) primary key,--当前ID（格式：单位ID-年度）。
						  [Name]	nvarchar(64))
	-----------------------------------------------------------------------------------------------------	
	--插入部门				  
	insert into @result(PID,ID,[Name])
	select null,UnitID,UnitName
	from tblDSIUnit
	where (UnitID in (select UnitID from tblDSIEmployeeUnit where EmployeeID = @EmployeeID))
	--插入年度。
	insert into @result(PID,ID,[Name])
	select data.ID, data.ID + '-' + dd.GrantTime, dd.GrantTime
	from @result data
	inner join (
		select convert(nvarchar(4), a.GrantTime,121) as GrantTime,c.UnitID
		from tblDSIAllowance a
		inner join tblDSIStaffRequest b
		on b.RequestID = a.RequestID
		inner join tblDSIStaffInfo c
		on c.StaffID = b.StaffID
		where (a.Status = 1)
		group by convert(nvarchar(4), a.GrantTime,121),c.UnitID
	) dd
	on dd.UnitID = data.ID
	where isnull(dd.GrantTime,'') <> ''
	-----------------------------------------------------------------------------------------------------
	---输出结果。
	select PID,ID,[Name]
	from @result
end
go
-----------------------------------------------------------------------------------------------------------------------
--分单位按年份统计的报表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIStatisticsUnitPointYearView')
begin
	print 'drop procedure spDSIStatisticsUnitPointYearView'
	drop procedure spDSIStatisticsUnitPointYearView
end
go
	print 'create procedure spDSIStatisticsUnitPointYearView'
go
create procedure spDSIStatisticsUnitPointYearView
(
	@UnitID		GUIDEx,--工作单位ID。
	@Year		nvarchar(4),--年度信息。
	@EmployeeID	GUIDEx--当前用户ID。
)
as
begin
	----------------------------------------------------------------------------------------------------
	declare @EmpUnit table(UnitID	nvarchar(32),
						   UnitName	nvarchar(128))
	--插入用户管理单位数据。
	insert into @EmpUnit(UnitID,UnitName)
	select UnitID,UnitName
	from tblDSIUnit
	where (UnitID in (select UnitID from tblDSIEmployeeUnit where EmployeeID = @EmployeeID))
    -----------------------------------------------------------------------------------------------------
     
	select data.UnitID,data.UnitName,isnull(dd.PT,0) as PT,isnull(dd.SumPaid,0) as SumPaid, 
		   dd.minTime as MinTime, dd.maxTime as MaxTime,isnull(@Year,'') as YearValue
	from @EmpUnit data
	left outer join
	   (select c.UnitID,count(a.RequestID) as PT, sum(a.Paid) as SumPaid,min(a.GrantTime) as minTime, max(a.GrantTime) as maxTime
		from tblDSIAllowance a
		inner join tblDSIStaffRequest b
		on b.RequestID = a.RequestID
		inner join tblDSIStaffInfo c
		on c.StaffID = b.StaffID
		where (a.Status = 1)
		and (convert(nvarchar(4), a.GrantTime,121) like @Year + '%')
		group by c.UnitID) dd
    on dd.UnitID = data.UnitID
    where (data.UnitID like @UnitID + '%')
    order by dd.SumPaid desc,data.UnitName
end
go
-----------------------------------------------------------------------------------------------------------------------
--分年份按单位统计左边年份单位。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIStatisticsYearPointUnitLeft')
begin
	print 'drop procedure spDSIStatisticsYearPointUnitLeft'
	drop procedure spDSIStatisticsYearPointUnitLeft
end
go
	print 'create procedure spDSIStatisticsYearPointUnitLeft'
go
create procedure spDSIStatisticsYearPointUnitLeft
(
	@EmployeeID	GUIDEx--当前用户ID。
)
as
begin
	-----------------------------------------------------------------------------------------------------
	declare @EmpUnit table(UnitID	nvarchar(32),
						   UnitName	nvarchar(128))
	--插入用户管理单位数据。
	insert into @EmpUnit(UnitID,UnitName)
	select UnitID,UnitName
	from tblDSIUnit
	where (UnitID in (select UnitID from tblDSIEmployeeUnit where EmployeeID = @EmployeeID))
	-----------------------------------------------------------------------------------------------------
	declare @result table(PID		nvarchar(128),--父ID。
						  ID		nvarchar(128) primary key,--当前ID（格式：单位ID-年度）。
						  [Name]	nvarchar(64))
	-----------------------------------------------------------------------------------------------------
	declare @tmp table(YearValue nvarchar(10),
					   UnitID    nvarchar(32))
	--插入数据。
	insert into @tmp(YearValue,UnitID)
	select convert(nvarchar(4), a.GrantTime,121),c.UnitID
	from tblDSIAllowance a
	inner join tblDSIStaffRequest b
	on b.RequestID = a.RequestID
	inner join tblDSIStaffInfo c
	on c.StaffID = b.StaffID
	where (a.Status = 1)
	and (c.UnitID in (select UnitID from tblDSIEmployeeUnit where EmployeeID = @EmployeeID))
	group by convert(nvarchar(4), a.GrantTime,121),c.UnitID
	order by convert(nvarchar(4), a.GrantTime,121) desc
	-----------------------------------------------------------------------------------------------------
	--定义游标。
	declare @YearValue nvarchar(10),@UnitID nvarchar(32)
	declare tmp_cursor cursor for
	select YearValue,UnitID
	from @tmp
	order by YearValue desc
	---------------------------------
	--打开游标。
	open tmp_cursor
	fetch next from tmp_cursor into @YearValue,@UnitID
	-----------------------------------------------------
	while(@@fetch_status = 0)
	begin
		if not exists(select 0 from @result where ID = @YearValue)
		begin
			--插入年度
			insert into @result(PID,ID,[Name]) values(null,@YearValue,@YearValue)
		end
		--插入年度下的工作单位。
		insert into @result(PID,ID,[Name])
		select @YearValue,@YearValue + '-' + UnitID,UnitName
		from @EmpUnit
		where UnitID = @UnitID
		--下一数据。
		fetch next from tmp_cursor into @YearValue,@UnitID
	end
	--关闭游标。
	close tmp_cursor
	deallocate tmp_cursor
	-----------------------------------------------------------------------------------------------------
	---输出结果。
	select PID,ID,[Name]
	from @result
end
go
-----------------------------------------------------------------------------------------------------------------------
--查看统计明细。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIStatisticsDetailView')
begin
	print 'drop procedure spDSIStatisticsDetailView'
	drop procedure spDSIStatisticsDetailView
end
go
	print 'create procedure spDSIStatisticsDetailView'
go
create procedure spDSIStatisticsDetailView
(
	@UnitID		GUIDEx,--单位ID。
	@YearValue	nvarchar(10) = ''--年份值。
)
as
begin
	select c.RoundName,b.StaffID,d.StaffCode,d.StaffName,d.Gender,d.IDCard,e.UnitName,
	a.GrantTime,a.Paid,
	a.UnitName as AllowanceUnitName
	from tblDSIAllowance a
	inner join tblDSIStaffRequest b
	on b.RequestID = a.RequestID
	inner join tblDSIRequestRound c 
	on c.RoundID = b.RoundID
	inner join tblDSIStaffInfo d
	on d.StaffID = b.StaffID
	left outer join tblDSIUnit e
	on e.UnitID = d.UnitID
	where (a.Status = 1)
	and (d.UnitID = @UnitID)
	and (convert(nvarchar(4), a.GrantTime,121) like @YearValue +'%')
	order by a.GrantTime desc,e.UnitName,d.StaffName
end
go
-----------------------------------------------------------------------------------------------------------------------

