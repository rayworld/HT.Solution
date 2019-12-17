using HT.Framework.DotNetFx40.AutoUpdate;
using HT.Framework.DotNetFx40.DotNetBar;
using System;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace Demo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AutoUpdater au = new AutoUpdater();
            try
            {
                au.Update();
            }
            catch (WebException exp)
            {
                DesktopAlertHelper.H2(String.Format("无法找到指定资源\n\n{0}", exp.Message));
            }
            catch (XmlException exp)
            {
                DesktopAlertHelper.H2(String.Format("下载的升级文件有错误\n\n{0}", exp.Message));
            }
            catch (NotSupportedException exp)
            {
                DesktopAlertHelper.H2(String.Format("升级地址配置错误\n\n{0}", exp.Message));
            }
            catch (ArgumentException exp)
            {
                DesktopAlertHelper.H2(String.Format("下载的升级文件有错误\n\n{0}", exp.Message));
            }
            catch (Exception exp)
            {
                DesktopAlertHelper.H2(String.Format("升级过程中发生错误\n\n{0}", exp.Message));
            }

            //string modelName = ConfigHelper.ReadValueByKey(ConfigHelper.ConfigurationFile.AppConfig, "Modules");

            //if (CommonProcess.ModuleIsExist("checkmailstate") == true)
            //{
            //    Application.Run(new FrmCheckQRCodeState());
            //}
            //else
            //{
            //    Application.Run(new FrmMain());
            //}

            Application.Run(new FrmMain());
        }
    }
}
