/*
//================================================================================
//  FileName: DSI_Procedure_AutoFilter.sql
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/12/6
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
------------------------------------------------------------------------------------------------------------
--初选自动筛选申报数据。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spDSIAutoFilterRequest')
begin
	print 'drop procedure spDSIAutoFilterRequest'
	drop procedure spDSIAutoFilterRequest
end
go
	print 'create procedure spDSIAutoFilterRequest'
go
create procedure spDSIAutoFilterRequest
(
	@FilterRoundID	  GUIDEx,--初选轮次ID。
	@RoundID		  GUIDEx,--申报轮次ID。
	@EmployeeID		  GUIDEx,--当前用户ID。
	@EmployeeName	  nvarchar(50)--当前用户名称。
)
as
begin
	declare @resultCode int
	declare @result nvarchar(50)
	set @resultCode = 0
	set @result = '已筛选完成！'
	-------------------------------------------------------
	--定义临时表存储申请数据。
	declare @req_data table(RequestID nvarchar(32),
							StaffID	  nvarchar(32))
	--获取申报轮次下的数据。
	insert into @req_data(RequestID,StaffID)
	select RequestID,StaffID
	from tblDSIStaffRequest 
	where RoundID = @RoundID
	--定义临时表存储筛选条件。
	declare @filter_data table(TableName nvarchar(128),
							   FieldName nvarchar(128),
							   TargetValue	nvarchar(128),
							   SettingName	nvarchar(128))
	--获取筛选条件设置。
	insert into @filter_data(TableName,FieldName,TargetValue,SettingName)
	select TableName,FieldName,TargetValue,SettingName
	from tblDSIFilterRoundSettings
	where FilterRoundID = @FilterRoundID
	-------------------------------------------------------
	--没有申请数据。
	if not exists(select 0 from @req_data)
	begin
		set @resultCode = -1
		set @result = '该轮次下没有申请数据！'
	end
	-------------------------------------------------------
	--没有筛选条件。
	if((@resultCode = 0) and (not exists(select 0 from @filter_data)))
	begin
		set @resultCode = 1
		set @result = '没有设置筛选条件，所有数据通过筛选。'
		--清空本筛选轮次且未在审核结果表中的数据。
		delete tblDSIFilterResult 
		where FilterRoundID = @FilterRoundID
		--插入筛选数据。
		insert into tblDSIFilterResult(RequestID,FilterRoundID,FilterTime,EmployeeID,EmployeeName)
		select RequestID,@FilterRoundID,getdate(),@EmployeeID,@EmployeeName
		from @req_data
	end
	-------------------------------------------------------
	--一般情况下的筛选。
	if(@resultCode = 0)
	begin
		--定义变量。
		declare @SettingName nvarchar(128)
		declare @TableName	nvarchar(128)
		declare @FieldName	nvarchar(128)
		declare @TargetValue	nvarchar(128)
		--定义游标。
		declare filter_cursor cursor for
		select TableName,FieldName,TargetValue,SettingName
		from @filter_data
		order by TableName,FieldName,TargetValue
		------------------------------------------------------------------
		--创建临时表存储中间数据。
		create table #tmp_request(ID nvarchar(32))
		------------------------------------------------------------------
		--打开游标。
		open filter_cursor
		fetch next from filter_cursor 
		into @TableName,@FieldName,@TargetValue,@SettingName
		while((@@fetch_status = 0) and (@resultCode = 0))
		begin
			 --------------------------------------------------------------------
			 --定义运算符。
			 declare @BeginOperator nvarchar(10),@EndOperator nvarchar(10)
			 set @BeginOperator = '='''
			 set @EndOperator = ''''
			 if((left(@TargetValue,1) = '>') or (left(@TargetValue,1) = '<') or (left(@TargetValue,1) = '='))
			 begin
				set @BeginOperator = ''
				set @EndOperator = ''
			 end
			 --------------------------------------------------------------------
			 if(@TableName = 'tblDSIStaffInfo')--教职工基本。
			 begin
			 --------------------------------------------------------------------
				 if(exists(select 0 from syscolumns where id = object_id(@TableName) and name = @FieldName))
				 begin
				 ------------------------------------------------------------------------------------------------
					 --清空临时表数据。
					 delete from #tmp_request
					 --装载临时表数据。
					  if(@FieldName = 'HardBecause')
					  begin
						--需进行位运算。
						declare @HardBecause int
					    set @HardBecause = cast(@TargetValue as int)
					    
					    insert into #tmp_request(ID)
					    select distinct a.StaffID
					    from @req_data a
					    inner join tblDSIStaffInfo b
					    on b.StaffID = a.StaffID
					    where (b.HardBecause & @HardBecause) = @HardBecause
					  					    
					  end else begin
					    --根据查询条件。
						insert into #tmp_request(ID)
						exec('select a.StaffID from tblDSIStaffInfo a inner join tblDSIStaffRequest b on b.StaffID = a.StaffID where (b.RoundID = '''+ @RoundID +''') and a.'+ @FieldName + @BeginOperator + @TargetValue + @EndOperator)
												
					  end
					  --处理满足筛选的数据。
					  if(not exists(select 0 from #tmp_request))
					  begin--没有满足条件的数据。
							delete from @req_data
							set @resultCode = -4
							set @result = '没有满足筛选条件['+ @SettingName + ']目标值为['+@TargetValue+']的数据。'
					  end else begin
							--删除没有满足条件的数据。
							delete from @req_data where StaffID not in(select ID from #tmp_request)
					  end
				 ------------------------------------------------------------------------------------------------
				 end else begin
					set @resultCode = -2
					set @result = '条件配置表['+ @TableName + ']不含有字段['+ @FieldName + ']。'
				 end						
			 --------------------------------------------------------------------
			 end else begin --不在规定表中。
			 --------------------------------------------------------------------
				set @resultCode = -3
				set @result = '条件配置表['+ @TableName + ']不是有效筛选目标表。'
			 --------------------------------------------------------------------
			 end
			 --------------------------------------------------------------------
			 if(exists(select 0 from @req_data))
			 begin
			 --------------------------------------------------------------------
				 fetch next from filter_cursor 
				 into @TableName,@FieldName,@TargetValue,@SettingName
			 --------------------------------------------------------------------
			 end else begin
				 set @resultCode = -5
				 set @result = '没有满足条件的数据进行筛选'
			 end
			 --------------------------------------------------------------------
		end
		--关闭游标。
		close filter_cursor
		-------------------------------------------------------------------------
		--删除游标。
		deallocate filter_cursor
		--------------------------------------------------------------------------
		--删除临时表。
		drop table #tmp_request
		--------------------------------------------------------------------------
	end
	-------------------------------------------------------
	--筛选完成写入筛选表。
	if(@resultCode = 0)
	begin
		--清空本筛选轮次的数据。
		delete tblDSIFilterResult 
		where (FilterRoundID = @FilterRoundID)
	
		if(exists(select 0 from @req_data))
		begin
			--插入筛选数据。
			insert into tblDSIFilterResult(RequestID,FilterRoundID,FilterTime,EmployeeID,EmployeeName)
			select RequestID,@FilterRoundID,getdate(),@EmployeeID,@EmployeeName
			from @req_data
		end
	end
	-------------------------------------------------------
	--返回结果。
	select cast(@resultCode as nvarchar(2)) + '|' + @result
end
go
------------------------------------------------------------------------------------------------------------
