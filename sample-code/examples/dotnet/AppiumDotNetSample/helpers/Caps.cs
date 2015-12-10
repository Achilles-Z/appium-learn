﻿using System;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;

namespace Appium.Samples.Helpers
{
	public class Caps
	{
		public static DesiredCapabilities getIos71Caps (string app) {
			DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, "");
			capabilities.SetCapability(MobileCapabilityType.AppiumVersion, "1.0");
			capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "7.1");
			capabilities.SetCapability(MobileCapabilityType.DeviceName, "iPhone Simulator");
			capabilities.SetCapability(MobileCapabilityType.App, app);
			return capabilities;
		}

		public static DesiredCapabilities getAndroid18Caps (string app) {
			DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, "");
            capabilities.SetCapability(MobileCapabilityType.AppiumVersion, "1.0");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "4.3");
            capabilities.SetCapability(MobileCapabilityType.AppPackage, "io.appium.android.apis");
            capabilities.SetCapability(MobileCapabilityType.AppActivity, ".Apidemos");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "Android Emulator");
            capabilities.SetCapability(MobileCapabilityType.App, app);
			return capabilities;
		}

		public static DesiredCapabilities getAndroid19Caps (string app) {
			DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, "");
            capabilities.SetCapability(MobileCapabilityType.AppiumVersion, "1.0");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "4.4.2");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "Android Emulator");
            capabilities.SetCapability(MobileCapabilityType.App, app);
			return capabilities;
		}

		public static DesiredCapabilities getSelendroid16Caps (string app) {
			DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, "");
			capabilities.SetCapability(MobileCapabilityType.AppiumVersion, "1.0");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "4.1");
			capabilities.SetCapability(MobileCapabilityType.AutomationName, "selendroid");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "Android Emulator");
            capabilities.SetCapability(MobileCapabilityType.App, app);
			return capabilities;
		}
	}
}

