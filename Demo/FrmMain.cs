using DevComponents.DotNetBar;
using HT.Framework.DotNetFx40.DotNetBar;
using HT.Framework.DotNetFx40.Encrypt;
using HT.Framework.DotNetFx40.Encrypt.DESEncrypt;
using System;

namespace Demo
{
    public partial class FrmMain : Office2007Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, System.EventArgs e)
        {
            string encryptString = EncryptHelper.Encrypt("77052301", "1234567890");
            string decryptString = EncryptHelper.Decrypt( "77052300", encryptString);
            Console.WriteLine(encryptString);
            Console.WriteLine(decryptString);
        }
    }
}
