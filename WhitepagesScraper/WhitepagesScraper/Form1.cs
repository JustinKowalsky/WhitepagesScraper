using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Remote;

namespace WhitepagesScraper
{
    public partial class Form1 : Form
    {
        static IWebDriver driverGC;
        public Form1()
        {
            var caps = DesiredCapabilities.Chrome();
            var options = new ChromeOptions();
            options.AddArgument(@"--incognito");
            options.AddArgument(@"--start-maximized");
            caps.SetCapability(ChromeOptions.Capability, options);
            var driverGC = new ChromeDriver(options);
            driverGC.Navigate().GoToUrl("http://www.whitepages.com/business");
            driverGC.Manage().Window.Maximize();

            //driverGC = new ChromeDriver(@"C:\Users\Justin\Documents\Visual Studio 2015\chromedriver_win32");
            //driverGC.Navigate().GoToUrl("http://www.whitepages.com/business");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            driverGC.FindElement(By.CssSelector(".business")).Click();
            IWebElement myBusinessSpot = driverGC.FindElement(By.CssSelector("#key"));
            myBusinessSpot.SendKeys(businessBox.Text);
            IWebElement myLocationSpot = driverGC.FindElement(By.CssSelector("#where"));
            myLocationSpot.SendKeys(locationBox.Text);
            driverGC.FindElement(By.CssSelector(".new-search")).Click();
        }
    }
}
