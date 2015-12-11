# Failed log DAY 3 


---


### 开始熟悉appium的各个小东西

今天开始弄明白界面上那几个小东东是干嘛的了
(就是直接从网上down下来的那个 dmg安装的，有界面的)
左起往右第三个就是 appium-doctor 同样的左右。
第四个是在Launch成功之后解析界面上的UI元素用的东东
第五个就是Android 的模拟器设置
第六个是iOS的模拟器设置
最后一个就是 启动/停止 

没介绍的都是还没玩过的

重点说下第六个吧，因为只玩了第六个(目前玩过的部分)
| 参数名 | 作用
| --------   | ---------- 
|appPath |就是你app编译成功的那个app所在的直接文件路径(不知道的可以直接点右边的choose)
|bundleid| 就是iOS 应用proj文件里面那个 bundleid
|Force Device |指定设备型号
|Plantform Version |SDK版本
|UIID | 设备id
|Force Orientation | 设备横竖屏指定
|Force Language | 设备语言指定
|Force Calendar | 设备指定日期
|Force Locale | 设备指定位置
|Show Simulator Log | 是否显示模拟器Log
|Show iOS System Log | 是否显示iOS系统Log

然后一直没Luanch 成功，所以界面也没解出来。
错误内容部分如下 说是Instruments crashed on startup 
暂时还没弄明白是咋回事
```
warn: Applications directory /Users/zecktang/Library/Developer/CoreSimulator/Devices/F473143D-5ED9-444B-A25D-197BF0B26C3C/data/Containers/Data/Application doesn't exist. Have you run this simulator before?
warn: Applications directory /Users/zecktang/Library/Developer/CoreSimulator/Devices/F473143D-5ED9-444B-A25D-197BF0B26C3C/data/Containers/Bundle/Application doesn't exist. Have you run this simulator before?
info: Couldn't find app directories to delete. Probably it's not installed

error: Could not pre-launch appium: Error: Instruments crashed on startup
```

然后捣鼓了半天也没啥进展，就换个思路去看pythone的范例脚本了(ios_simple.py)
python 语言刚刚会hello world的我 只能硬着头皮去看了。

```
import unittest
import os
from random import randint
from appium import webdriver
from time import sleep

class SimpleIOSTests(unittest.TestCase):

    def setUp(self):
        # set up appium
        app = os.path.join(os.path.dirname(__file__),
                           '../../apps/TestApp/build/release-iphonesimulator',
                           'TestApp.app')
        app = os.path.abspath(app)
        self.driver = webdriver.Remote(
            command_executor='http://127.0.0.1:4723/wd/hub',
            desired_capabilities={
                'app': app,
                'platformName': 'iOS',
                'platformVersion': '9.1',
                'deviceName': 'iPhone 6'
            })

    def tearDown(self):
        self.driver.quit()

    def _populate(self):
        # populate text fields with two random numbers
        els = [self.driver.find_element_by_name('TextField1'),
               self.driver.find_element_by_name('TextField2')]

        self._sum = 0
        for i in range(2):
            rnd = randint(0, 10)
            els[i].send_keys(rnd)
            self._sum += rnd

    def test_ui_computation(self):
        # populate text fields with values
        self._populate()

        # trigger computation by using the button
        self.driver.find_element_by_accessibility_id('ComputeSumButton').click()

        # is sum equal ?
        # sauce does not handle class name, so get fourth element
        sum = self.driver.find_element_by_name('Answer').text
        self.assertEqual(int(sum), self._sum)

    def test_scroll(self):
        els = self.driver.find_elements_by_class_name('UIAButton')
        els[5].click()

        sleep(1)
        try:
            el = self.driver.find_element_by_accessibility_id('OK')
            el.click()
            sleep(1)
        except:
            pass

        el = self.driver.find_element_by_xpath('//UIAMapView[1]')

        location = el.location
        self.driver.swipe(start_x=location['x'], start_y=location['y'], end_x=0.5, end_y=location['y'], duration=800)


if __name__ == '__main__':
    suite = unittest.TestLoader().loadTestsFromTestCase(SimpleIOSTests)
    unittest.TextTestRunner(verbosity=2).run(suite)
  ```

其实注释都写了，我就再哔哔一遍吧

def setUp 这个部分就是 那些参数的相关设置
def populate  这个部分是 在两个文本里面输入各输入一个随机数
def test_ui_computation 这个部分是点个按钮 求和
def test_scorll 这个部分是点击按钮，和滑动

看完脚本基本了解一个操作是怎么模拟的了。
就是  找到一个UI控件-->做想要的模拟动作(点击啊，赋值啊啥的) --> next
关键是怎么找到这个控件
脚本里面用的是
```
self.driver.find_element_by_xpath
self.driver.find_element_by_name
self.driver.find_element_by_accessibility_id
self.driver.find_elements_by_class_name
```
前三个基本都能明白，就是通过直接的xpath、通过名字、通过id找到控件
最后一个是通过控件类别找到一个数组，然后数组中的第几个
这些都是可用之前可视化界面里面那个搜索一样的按钮可以分析出来的,前提是Luanch成功。。

OK DAY 2就这样了






