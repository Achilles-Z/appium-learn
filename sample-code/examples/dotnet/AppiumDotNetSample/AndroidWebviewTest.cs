﻿using NUnit.Framework;
using System;
using Appium.Samples.Helpers;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Threading;
using System.Drawing;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;

namespace Appium.Samples
{
	[TestFixture ()]
	public class AndroidWebviewTest
	{
		private IWebDriver driver;
		private bool allPassed = true;

		[TestFixtureSetUp]
		public void BeforeAll(){
			DesiredCapabilities capabilities = Env.isSauce () ? 
				Caps.getAndroid18Caps (Apps.get ("selendroidTestApp")) :
				Caps.getAndroid19Caps (Apps.get ("selendroidTestApp"));
			if (Env.isSauce ()) {
				capabilities.SetCapability("username", Env.getEnvVar("SAUCE_USERNAME")); 
				capabilities.SetCapability("accessKey", Env.getEnvVar("SAUCE_ACCESS_KEY"));
				capabilities.SetCapability("name", "android - webview");
				capabilities.SetCapability("tags", new string[]{"sample"});
			}
			Uri serverUri = Env.isSauce () ? AppiumServers.sauceURI : AppiumServers.localURI;
            driver = new AndroidDriver<IWebElement>(serverUri, capabilities, Env.INIT_TIMEOUT_SEC);	
			driver.Manage().Timeouts().ImplicitlyWait(Env.IMPLICIT_TIMEOUT_SEC);
		}

		[TestFixtureTearDown]
		public void AfterAll(){
			try
			{
				if(Env.isSauce())
					((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (allPassed ? "passed" : "failed"));
			}
			finally
			{
				driver.Quit();
			}
		}

		[TearDown]
		public void AfterEach(){
			allPassed = allPassed && (TestContext.CurrentContext.Result.State == TestState.Success);
		}

		[Test ()]
		public void FindElementTestCase ()
		{
			driver.FindElement(By.Name("buttonStartWebviewCD")).Click ();
			Thread.Sleep (5000);
			if (!Env.isSauce ()) {
				// Contexts don't work in android 4.3.3
				var contexts = ((IContextAware) driver).Contexts;
				string webviewContext = null;
				for (int i = 0; i < contexts.Count; i++) {
					Console.WriteLine (contexts [i]);
					if (contexts [i].Contains ("WEBVIEW")) {
						webviewContext = contexts [i]; 
					}
				}
				Assert.IsNotNull (webviewContext);
                ((IContextAware) driver).Context = webviewContext;
				var el = driver.FindElement(By.Id ("name_input"));
                el.Click();
				el.Clear ();
				el.SendKeys ("Appium User");
				el.SendKeys (Keys.Return);
				Assert.IsTrue (driver.PageSource.Contains ("This is my way of saying hello"));
				Assert.IsTrue (driver.PageSource.Contains ("Appium User"));
			}
		}
	}
}

