---------------------------------------------------------------------------------------
--函数
---------------------------------------------------------------------------------------
--获取困难教职工申请状态。
if exists(select 0 from sysobjects where xtype = 'fn' and name ='fnDSIGetStaffRequestStatus')
begin
	print 'drop function fnDSIGetStaffRequestStatus'
	drop function fnDSIGetStaffRequestStatus
end
go
	print 'create function fnDSIGetStaffRequestStatus'
go
create function fnDSIGetStaffRequestStatus
(
	@RequestID	GUIDEx--申请困难教职工ID。
)
returns nvarchar(64)
as
begin
	declare @Status nvarchar(64)
	--已申请。
	if exists(select 0 from tblDSIStaffRequest where RequestID = @RequestID)
	begin
		set @Status = '已申请'
	end
	--已初选。
	if exists(select 0 from tblDSIFilterResult where RequestID = @RequestID)
	begin
		set @Status = '已初选'
	end
	--已审核。
	if exists(select 0 from tblDSIEduAuditResult where RequestID = @RequestID)
	begin
		set @Status = '已审核'
	end
	--已发补助。
	if exists(select 0 from tblDSIAllowance where RequestID = @RequestID)
	begin
		declare @Count int
		select @Count = count(0) from tblDSIAllowance where RequestID = @RequestID
		set @Status = '已补助('+ cast(@Count as nvarchar(32)) +')'
	end
	
	return(@Status)
end
go
---------------------------------------------------------------------------------------
--获取教职工申报的轮次数据。
if exists(select 0 from sysobjects where xtype = 'fn' and name = 'fnDSIGetStaffRequestRound')
begin
	print 'drop function fnDSIGetStaffRequestRound'
	drop function fnDSIGetStaffRequestRound
end
go
	print 'create function fnDSIGetStaffRequestRound'
go
create function fnDSIGetStaffRequestRound
(
	@StaffID	GUIDEx--困难教职工ID。
)
returns int
as
begin
	declare @result int
	select @result = count(requestID)
	from tblDSIStaffRequest
	where staffID = @StaffID
	
	return(@result)
		
		/*
		declare @result	nvarchar(2048)--定义结果字符串。
		declare @strRoundName	nvarchar(128)
		--定义游标。
		declare StaffRequest_cursor cursor for
		select b.RoundName
		from tblDSIStaffRequest a
		inner join tblDSIRequestRound b
		on b.RoundID = a.RoundID
		where a.StaffID = @StaffID
		order by a.CreateRequestTime desc
		--打开游标。
		open StaffRequest_cursor
		fetch next from StaffRequest_cursor into @strRoundName
		--叠加数据。
		while(@@fetch_status = 0)
		begin
			if(isnull(@result,'') = '')
				set @result = @strRoundName
			else
				set @result = @result + ',' + @strRoundName
			--下一数据。
			fetch next from StaffRequest_cursor into @strRoundName
		end
		--关闭游标。
		close StaffRequest_cursor
		deallocate StaffRequest_cursor
		--返回数据。
		return(@result)
		**/
end
go
---------------------------------------------------------------------------------------
--根据补助轮次获取补助档次。
if exists(select 0 from sysobjects where xtype = 'fn' and name = 'fnDSIGetAllowanceSubsidies')
begin
	print 'drop function fnDSIGetAllowanceSubsidies'
	drop function fnDSIGetAllowanceSubsidies
end
go
create function fnDSIGetAllowanceSubsidies
(
	@RoundID	GUIDEx--补助轮次ID。
)
returns nvarchar(2048)
as
begin
	declare @result	nvarchar(2048)--定义结果字符串。
	declare @floatSubsidiesValue float
	--定义游标。
	declare Subsidies_cursor cursor for
	select Subsidies
	from tblDSIAllowanceRoundSubsidies
	where RoundID = @RoundID
	--打开游标。
	open Subsidies_cursor
	fetch next from Subsidies_cursor into @floatSubsidiesValue
	--叠加数据。
	while(@@fetch_status = 0)
	begin
		if(isnull(@result,'') = '')
			set @result = cast(@floatSubsidiesValue as nvarchar(50))
		else
			set @result = @result + ',' + cast(@floatSubsidiesValue as nvarchar(50))
		--下一数据。
		fetch next from Subsidies_cursor into @floatSubsidiesValue
	end
	--关闭游标。
	close Subsidies_cursor
	deallocate Subsidies_cursor
	--返回数据。
	return(@result)
end
go
---------------------------------------------------------------------------------------
