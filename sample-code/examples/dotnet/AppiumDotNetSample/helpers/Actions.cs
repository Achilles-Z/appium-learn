﻿using System;
using System.Collections.Generic;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Appium.Samples.Helpers
{
	public class Actions
	{
		public static ITouchAction Swipe(IPerformsTouchActions driver, int startX, int startY, int endX, int endY, 
				int duration) {
			ITouchAction touchAction = new TouchAction(driver) 
				.Press (startX, startY)
				.Wait (duration)
				.MoveTo (endX, endY)
				.Release ();
			return touchAction;
		}
	}
}

