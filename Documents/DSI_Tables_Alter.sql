/*
//================================================================================
//  FileName: DSI_Tables_Alter.sql
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/2/27
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
--下载附件。
------------------------------------------------------------------------------------
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblDSIDownload')
begin
	print 'drop table tblDSIDownload'
	drop table tblDSIDownload
end
go
create table tblDSIDownload
(
	DownloadID		GUIDEx,--下载ID。
	DownloadName	nvarchar(64),--下载名称。
	[Size]			float default(0),--附件大小。
	Extension		nvarchar(10),--附件后缀名。
	Status			int	default(0),--状态(0-不显示，1-显示)。
	CheckCode		nvarchar(32),--校验码。
	
	CreateEmployeeID	GUIDEx null,--创建用户ID。
	CreateEmployeeName	nvarchar(64),--创建用户名称。
	LastModifyTime		datetime default(getdate()),--最后更新时间。
	
	constraint PK_tblDSIDownload_DownloadID primary key(DownloadID)--主键约束。
)
go
------------------------------------------------------------------------------------
