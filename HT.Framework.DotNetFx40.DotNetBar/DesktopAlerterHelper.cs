using DevComponents.DotNetBar.Controls;

namespace HT.Framework.DotNetFx40.DotNetBar
{
    public sealed class DesktopAlertHelper
    {
        /// <summary>
        /// TestMethod:
        /// DesktopAlertHelper.H4("sdf");
        /// DesktopAlertHelper.H3("sdf");
        /// DesktopAlertHelper.H2("sdf");
        /// DesktopAlertHelper.H1("sdf");
        /// </summary>
        /// <param name="key"></param>
        public static void H4(string key)
        {
            DesktopAlert.Show(string.Format("<h4>{0}</h4>", key));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public static void H3(string key)
        {
            DesktopAlert.Show(string.Format("<h3>{0}</h3>", key));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public static void H2(string key)
        {
            DesktopAlert.Show(string.Format("<h2>{0}</h2>", key));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public static void H1(string key)
        {
            DesktopAlert.Show(string.Format("<h1>{0}</h1>", key));
        }
    }
}