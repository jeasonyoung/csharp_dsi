//================================================================================
//  FileName: SyncService.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/12/4
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
using System;
using System.Collections.Generic;
using System.Text;

using iPower;
using iPower.Data.ORM;

using iPower.WinService;
using iPower.WinService.Jobs;

using Yaesoft.Furong;
using Yaesoft.SFIT.DataSync;
namespace Yaesoft.DSI.Sync
{
    /// <summary>
    /// 同步Windows服务。
    /// </summary>
    public class SyncServiceJob :Job<ModuleConfiguration>, IJobFunction
    {
        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override string JobName
        {
            get { return "困难教职工信息系统数据同步服务"; }
        }
        /// <summary>
        /// 
        /// </summary>
        protected override ModuleConfiguration JobConfig
        {
            get { return new ModuleConfiguration(); }
        }
        /// <summary>
        /// 
        /// </summary>
        protected override IJobFunction JobFunction
        {
            get { return this; }
        }
        #endregion

        #region IJobFunction 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public void Run(params string[] args)
        {
            this.JobLog.ContentLog("准备开始同步数据...");
            IDataSync dataSync = new DataSyncFactory();
            #region 同步单位数据。
            try
            {
                this.JobLog.ContentLog("开始同步单位数据...");
                this.SyncAllUnits(dataSync);
            }
            catch (Exception e)
            {
                string err = "同步单位数据时发生异常：" + e.Message;
                this.JobLog.ContentLog(err);
                this.JobLog.ErrorLog(new Exception(err, e));
            }
            finally
            {
                this.JobLog.ContentLog("同步单位数据完成！");
            }
            #endregion

            #region 同步教师数据。
            try
            {
                this.JobLog.ContentLog("开始同步教师数据...");
                this.SyncAllTeachers(dataSync);
            }
            catch (Exception e)
            {
                string err = "同步教师数据时发生异常：" + e.Message;
                this.JobLog.ContentLog(err);
                this.JobLog.ErrorLog(new Exception(err, e));
            }
            finally
            {
                this.JobLog.ContentLog("同步教师数据完成！");
            }
            #endregion
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 同步单位数据。
        /// </summary>
        /// <param name="sync"></param>
        private void SyncAllUnits(IDataSync sync)
        {
            SyncUnits units = sync.SyncAllUnit();
            if (units == null || units.Count == 0)
            {
                this.JobLog.ContentLog("没有获得单位数据！");
                return;
            }

            DSIUnitEntity unitEntity = new DSIUnitEntity();
            unitEntity.DbEntityDataChangeLogEvent += new DbEntityDataChangeLogHandler(delegate(string head, string content)
            {
                this.JobLog.ContentLog(string.Format("head:{0}#content:{1}", head, content));
            });

            for (int i = 0; i < units.Count; i++)
            {
                try
                {
                    DSIUnit data = unitEntity.LoadData(units[i].UnitCode);
                    if (data == null)
                    {
                        data = new DSIUnit();
                        data.UnitID = GUIDEx.New;
                        data.UnitCode = units[i].UnitCode;
                    }
                    data.UnitName = units[i].UnitName;
                    bool result = unitEntity.UpdateRecord(data);
                    this.JobLog.ContentLog(string.Format("同步单位[{0},{1}]数据：{2}", i + 1, data, result));
                }
                catch (Exception e)
                {
                    string err = string.Format("同步单位[{0},{1}]时发生异常：{2}", i + 1, units[i], e.Message);
                    this.JobLog.ContentLog(err);
                    this.JobLog.ErrorLog(new Exception(err, e));
                }
            }
        }
        /// <summary>
        /// 同步教师数据。
        /// </summary>
        /// <param name="sync"></param>
        private void SyncAllTeachers(IDataSync sync)
        {
            DSIUnitEntity unitEntity = new DSIUnitEntity();
            List<DSIUnit> units = unitEntity.LoadAllRecords();
            if (units == null || units.Count == 0)
            {
                this.JobLog.ContentLog("没有获得单位数据！");
                return;
            }

            DSIEmployeeEntity employeeEntity = new DSIEmployeeEntity(this.JobConfig.TeaUserRoleID);
            employeeEntity.DbEntityDataChangeLogEvent += new DbEntityDataChangeLogHandler(delegate(string head, string content)
            {
                this.JobLog.ContentLog(string.Format("head:{0}#content:{1}", head, content));
            });
            DSIEmployeeUnitEntity employeeUnitEntity = new DSIEmployeeUnitEntity();
            employeeUnitEntity.DbEntityDataChangeLogEvent += new DbEntityDataChangeLogHandler(delegate(string head, string content)
            {
                this.JobLog.ContentLog(string.Format("head:{0}#content:{1}", head, content));
            });

            for (int i = 0; i < units.Count; i++)
            {
                try
                {
                    this.JobLog.ContentLog(string.Format("[{0}]同步单位[{1}]下教师数据：", i + 1, units[i].UnitName));

                    SyncTeachers teachers = sync.SyncAllTeachers(units[i].UnitName);
                    if (teachers == null || teachers.Count == 0)
                    {
                        this.JobLog.ContentLog(string.Format("单位[{0},{1}]下没有找到教师数据！", i + 1, units[i].UnitName));
                        continue;
                    }
                    for (int j = 0; j < teachers.Count; j++)
                    {
                        try
                        {
                            DSIEmployee data = employeeEntity.LoadData(teachers[j].TeaCode);
                            if (data == null)
                            {
                                data = new DSIEmployee();
                                data.EmployeeID = GUIDEx.New;
                                data.EmployeeCode = teachers[j].TeaCode;
                            }
                            data.EmployeeName = teachers[j].TeaName;
                            bool result = employeeEntity.UpdateRecord(data);
                            this.JobLog.ContentLog(string.Format("同步教师[{0},{1}]数据：{2}", j + 1, data, result));

                            DSIEmployeeUnit empUnit = new DSIEmployeeUnit();
                            empUnit.UnitID = units[i].UnitID;
                            empUnit.EmployeeID = data.EmployeeID;
                            if (result = employeeUnitEntity.UpdateRecord(empUnit))
                            {
                                this.JobLog.ContentLog(string.Format("更新教师单位[{0},{1}]", data.EmployeeName, units[i].UnitName));
                            }
                        }
                        catch (Exception ex)
                        {
                            string err = string.Format("同步教师[{0},{1}]数据时发生异常：{2},{3}", j + 1, teachers[j], ex.Message, ex.Source);
                            this.JobLog.ContentLog(err);
                            this.JobLog.ErrorLog(new Exception(err, ex));
                        }
                    }
                }
                catch (Exception e)
                {
                    string err = string.Format("同步单位[{0},{1}]下教师数据时发生异常：{2},{3}", i + 1, units[i], e.Message, e.Source);
                    this.JobLog.ContentLog(err);
                    this.JobLog.ErrorLog(new Exception(err, e));
                }
                finally
                {
                    this.JobLog.ContentLog(string.Format("[{0}]同步单位[{1}]下教师数据完成。", i + 1, units[i].UnitName));
                }
            }
        }
        #endregion
    }
}