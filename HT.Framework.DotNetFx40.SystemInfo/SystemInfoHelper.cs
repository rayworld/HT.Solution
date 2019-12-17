﻿using System;
using System.Linq;
using System.Management;
using HT.Framework.DotNetFx40.SystemInfo.Config;

namespace HT.Framework.DotNetFx40.SystemInfo
{
    public sealed class SystemInfoHelper
    {
        /// <summary>
        /// 描述:获取硬盘容量汇总
        /// 范例:SystemInfoHelper.GetTotalDiskSize()
        /// </summary>
        public static long GetTotalDiskSize()
        {
            var diskDriveManagement = new ManagementClass(WmiPath.DiskDrive);
            var diskDriveManagementInstances = diskDriveManagement.GetInstances();

            return diskDriveManagementInstances.OfType<ManagementObject>()
                .Select(x => Convert.ToInt64(x[ManagementObjectPropertyName.Size]))
                .Aggregate<long, long>(0, (current, diskSize) => diskSize + current);
        }


        /// <summary>
        /// 描述:显示处理器信息
        /// 范例:SystemInfoHelper.GetProcessorInfo()
        /// </summary>
        /// <returns></returns>
        public static string GetProcessorInfo()
        {
            ManagementClass mcpu = new ManagementClass("Win32_Processor");
            ManagementObjectCollection mncpu = mcpu.GetInstances();
            string cpuCount = mncpu.Count.ToString();
            string[] cpuHz = new string[mncpu.Count];
            int count = 0;
            ManagementObjectSearcher MySearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject MyObject in MySearcher.Get())
            {
                cpuHz[count] = MyObject.Properties["CurrentClockSpeed"].Value.ToString();
                count++;
            }

            return $"cpuCount: {cpuCount}; cpuHz:{string.Join(",", cpuHz)}";
        }
    }
}
