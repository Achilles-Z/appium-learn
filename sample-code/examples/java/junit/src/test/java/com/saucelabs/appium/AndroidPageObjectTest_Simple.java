package com.saucelabs.appium;

import io.appium.java_client.MobileElement;
import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.pagefactory.AppiumFieldDecorator;
import io.appium.java_client.remote.MobileCapabilityType;

import java.io.File;
import java.net.URL;
import java.util.NoSuchElementException;
import java.util.concurrent.TimeUnit;

import org.junit.After;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.support.PageFactory;

import com.saucelabs.appium.page_object.android.ApiDemosListViewScreenSimple;

public class AndroidPageObjectTest_Simple {

	private WebDriver driver;
	private ApiDemosListViewScreenSimple apiDemosPageObject;
	
	@Before
	public void setUp() throws Exception {
	    File appDir = new File("src/test/java/io/appium/java_client");
	    File app = new File(appDir, "ApiDemos-debug.apk");
	    DesiredCapabilities capabilities = new DesiredCapabilities();
	    capabilities.setCapability(MobileCapabilityType.DEVICE_NAME, "Android Emulator");
	    capabilities.setCapability(MobileCapabilityType.APP, app.getAbsolutePath());
	    driver = new AndroidDriver<MobileElement>(new URL("http://127.0.0.1:4723/wd/hub"), capabilities);
        
	    apiDemosPageObject = new ApiDemosListViewScreenSimple();
	    //This time out is set because test can be run on slow Android SDK emulator
		PageFactory.initElements(new AppiumFieldDecorator(driver, 5, TimeUnit.SECONDS), 
				apiDemosPageObject);
	}
	
	@After
	public void tearDown() throws Exception {
		driver.quit();
	}
	
	@Test
	public void findByElementsTest() {
		Assert.assertNotEquals(0, apiDemosPageObject.textVieWs.size());
	}

	@Test
	public void findByElementTest() {
		Assert.assertNotEquals(null, apiDemosPageObject.textView.getAttribute("text"));
	}


	@Test
	public void androidFindByElementsTest(){
		Assert.assertNotEquals(0, apiDemosPageObject.androidTextViews.size());
	}

	@Test
	public void androidFindByElementTest(){
		Assert.assertNotEquals(null, apiDemosPageObject.androidTextView.getAttribute("text"));
	}

	@Test
	public void checkThatElementsWereNotFoundByIOSUIAutomator(){
		Assert.assertEquals(0, apiDemosPageObject.iosTextViews.size());
	}

	@Test
	public void checkThatElementWasNotFoundByIOSUIAutomator(){
		NoSuchElementException nsee = null;
		try{
			apiDemosPageObject.iosTextView.getAttribute("text");
		}
		catch (Exception e){
			nsee = (NoSuchElementException) e;
		}
		Assert.assertNotNull(nsee);
	}

	@Test
	public void androidOrIOSFindByElementsTest(){
		Assert.assertNotEquals(0, apiDemosPageObject.androidOriOsTextViews.size());
	}

	@Test
	public void androidOrIOSFindByElementTest(){
		Assert.assertNotEquals(null, apiDemosPageObject.androidOriOsTextView.getAttribute("text"));
	}

	@Test
	public void androidFindByUIAutomatorElementsTest(){
		Assert.assertNotEquals(0, apiDemosPageObject.androidUIAutomatorViews.size());
	}

	@Test
	public void androidFindByUIAutomatorElementTest(){
		Assert.assertNotEquals(null, apiDemosPageObject.androidUIAutomatorView.getAttribute("text"));
	}

	@Test
	public void areMobileElementsTest(){
		Assert.assertNotEquals(0, apiDemosPageObject.mobileElementViews.size());
	}

	@Test
	public void isMobileElementTest(){
		Assert.assertNotEquals(null, apiDemosPageObject.mobileElementView.getAttribute("text"));
	}

	@Test
	public void areMobileElements_FindByTest(){
		Assert.assertNotEquals(0, apiDemosPageObject.mobiletextVieWs.size());
	}

	@Test
	public void isMobileElement_FindByTest(){
		Assert.assertNotEquals(null, apiDemosPageObject.mobiletextVieW.getAttribute("text"));
	}

	@Test
	public void areRemoteElementsTest(){
		Assert.assertNotEquals(0, apiDemosPageObject.remoteElementViews.size());
	}

	@Test
	public void isRemoteElementTest(){
		Assert.assertNotEquals(null, apiDemosPageObject.remotetextVieW.getAttribute("text"));
	}
}
