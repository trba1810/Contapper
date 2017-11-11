using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsForms;
using System.Diagnostics;
using Microsoft.Win32;

namespace Contapper
{
    public partial class Map : Form
    {
        public Map(string city,string address)
        {
            InitializeComponent();            
            InitializeMap(city,address);

        }

        

        private void InitializeMap(string city,string address)
        {
            int BrowserVer, RegVal;
            BrowserVer = webBrowser1.Version.Major;

            // set the appropriate IE version
            if (BrowserVer >= 11)
                RegVal = 11001;
            else if (BrowserVer == 10)
                RegVal = 10001;
            else if (BrowserVer == 9)
                RegVal = 9999;
            else if (BrowserVer == 8)
                RegVal = 8888;
            else
                RegVal = 7000;

            // set the actual key
            using (RegistryKey Key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", RegistryKeyPermissionCheck.ReadWriteSubTree))
                if (Key.GetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe") == null)
                    Key.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe", RegVal, RegistryValueKind.DWord);


            var strBuilder = new StringBuilder("http://maps.google.com/maps?q=");

            strBuilder.Append(city);
            //strBuilder.Append(",");
            strBuilder.Append(address);
            webBrowser1.Navigate(strBuilder.ToString());


        }

    }
}
