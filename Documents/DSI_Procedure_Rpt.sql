/*
//================================================================================
//  FileName: DSI_Procedure_Rpt.sql
//  Desc:用户报表的存储过程。
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/12/23
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
-----------------------------------------------------------------------------------------------
--按个人统计—分申报轮次。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIRptPersonalAllowanceByRequestBound')
begin
	print 'drop procedure spDSIRptPersonalAllowanceByRequestBound'
	drop procedure spDSIRptPersonalAllowanceByRequestBound
end
go
	print 'create procedure spDSIRptPersonalAllowanceByRequestBound'
go
create procedure spDSIRptPersonalAllowanceByRequestBound
(
	@RequestBoundID		GUIDEx,--申报轮次。
	@StaffStatus		int--岗位状态。
)
as
begin
	select d.StaffCode,d.StaffName,d.Gender,d.IDCard,e.UnitName,d.StaffStatus,
	b.RoundName as AllowanceRoundName,a.Paid
	from tblDSIAllowance a
	inner join tblDSIAllowanceRound b
	on b.RoundID = a.RoundID
	inner join tblDSIStaffRequest c
	on c.RequestID = a.RequestID
	inner join tblDSIStaffInfo d
	on d.StaffID = c.StaffID
	left outer join tblDSIUnit e
	on e.UnitID = d.UnitID
	where (c.RoundID = @RequestBoundID)
	and (d.StaffStatus & @StaffStatus = d.StaffStatus)
	order by e.UnitCode, d.StaffCode,b.OrderNO
end
go
-----------------------------------------------------------------------------------------------
--按个人统计-分补助发放时间段。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIRptPersonalAllowanceByTime')
begin
	print 'drop procedure spDSIRptPersonalAllowanceByTime'
	drop procedure spDSIRptPersonalAllowanceByTime
end
go
	print 'create procedure spDSIRptPersonalAllowanceByTime'
go
create procedure spDSIRptPersonalAllowanceByTime
(
	@StartTime		datetime,--开始时间。
	@EndTime		datetime,--结束时间。
	@StaffStatus	int--岗位状态。
)
as
begin
	select d.StaffCode,d.StaffName,d.Gender,d.IDCard,e.UnitName,d.StaffStatus,
	b.RoundName as AllowanceRoundName,a.Paid
	from tblDSIAllowance a
	inner join tblDSIAllowanceRound b
	on b.RoundID = a.RoundID
	inner join tblDSIStaffRequest c
	on c.RequestID = a.RequestID
	inner join tblDSIStaffInfo d
	on d.StaffID = c.StaffID
	left outer join tblDSIUnit e
	on e.UnitID = d.UnitID
	where (a.GrantTime between @StartTime and @EndTime)
	and (d.StaffStatus & @StaffStatus = d.StaffStatus)
	order by e.UnitCode, d.StaffCode,b.OrderNO
end
go
-----------------------------------------------------------------------------------------------
--按单位统计-分申报轮次。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIRptUnitAllowanceByRequestBound')
begin
	print 'drop procedure spDSIRptUnitAllowanceByRequestBound'
	drop procedure spDSIRptUnitAllowanceByRequestBound
end
go
	print 'create procedure spDSIRptUnitAllowanceByRequestBound'
go
create procedure spDSIRptUnitAllowanceByRequestBound
(
	@RequestBoundID		GUIDEx,--申报轮次。
	@StaffStatus		int--岗位状态。
)
as
begin
   select UnitCode,UnitName,StaffCount,AllowanceRoundName,Paid
   from (
		select e.UnitCode,e.UnitName,
		count(d.StaffCode) as StaffCount,
		b.RoundName as AllowanceRoundName,
		sum(isnull(a.Paid,0)) as Paid,
		b.OrderNO
		from tblDSIAllowance a
		inner join tblDSIAllowanceRound b
		on b.RoundID = a.RoundID
		inner join tblDSIStaffRequest c
		on c.RequestID = a.RequestID
		inner join tblDSIStaffInfo d
		on d.StaffID = c.StaffID
		left outer join tblDSIUnit e
		on e.UnitID = d.UnitID
		where (c.RoundID = @RequestBoundID)
		and (d.StaffStatus & @StaffStatus = d.StaffStatus)
		group by e.UnitCode,e.UnitName,b.OrderNO,b.RoundName
	) data
	order by UnitCode,UnitName,OrderNO,AllowanceRoundName
end
go
-----------------------------------------------------------------------------------------------
--按单位统计-分补助发放时间段。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIRptUnitAllowanceByTime')
begin
	print 'drop procedure spDSIRptUnitAllowanceByTime'
	drop procedure spDSIRptUnitAllowanceByTime
end
go
	print 'create procedure spDSIRptUnitAllowanceByTime'
go
create procedure spDSIRptUnitAllowanceByTime
(
	@StartTime		datetime,--开始时间。
	@EndTime		datetime,--结束时间。
	@StaffStatus	int--岗位状态。
)
as
begin
	select UnitCode,UnitName,StaffCount,AllowanceRoundName,Paid
	from (
		select e.UnitCode,e.UnitName,
		count(d.StaffCode) as StaffCount,
		b.RoundName as AllowanceRoundName,
		sum(isnull(a.Paid,0)) as Paid,
		b.OrderNO
		from tblDSIAllowance a
		inner join tblDSIAllowanceRound b
		on b.RoundID = a.RoundID
		inner join tblDSIStaffRequest c
		on c.RequestID = a.RequestID
		inner join tblDSIStaffInfo d
		on d.StaffID = c.StaffID
		left outer join tblDSIUnit e
		on e.UnitID = d.UnitID
		where (a.GrantTime between @StartTime and @EndTime)
		and (d.StaffStatus & @StaffStatus = d.StaffStatus)
		group by e.UnitCode,e.UnitName,b.OrderNO,b.RoundName
	) data
	order by UnitCode,UnitName,OrderNO,AllowanceRoundName
end
go
-----------------------------------------------------------------------------------------------