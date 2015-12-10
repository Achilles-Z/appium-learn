# Failed log DAY 1 


---


## Mac OS X EI Capitan 10.11 上搭建环境踩坑记录


### Step1. 安装homebrew

打开终端 输入下面的东东

>ruby -e "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install)"

安装完成之后 输入brew -v 如果有版本号出来就OK拉

>ZeckTang-MacBook-Air:~ zecktang$ brew -v
Homebrew 0.9.5 (git revision 18cf; last commit 2015-12-09)

### Step2. 安装node

在终端 输入下面的东东

>brew install node

安装完成之后 

输入node -v 如果有版本号出来就OK拉

ZeckTang-MacBook-Air:~ zecktang$ node -v

v5.1.1

--这个过程中有可能会失败，多试几次就好了

### Step3. 安装 appium

还是在终端 输入下面的东东

npm install －g appium

装好之后呢 可以输入 appium-doctor 试下是否OK,睁大眼睛appium后面没跟空格。

--安装过程还是有可能会失败，retry吧少年

### Step4. 检查xCode

在终端 输入下面的东东

>appium-doctor 

会出来下面的东西
```
Running iOS Checks
✔ Xcode is installed at /Applications/Xcode.app/Contents/Developer
✔ Xcode Command Line Tools are installed.
✔ DevToolsSecurity is enabled.
✔ The Authorization DB is set up properly.
✔ Node binary found at /usr/local/bin/node
✔ iOS Checks were successful.

Running Android Checks
✖ ANDROID_HOME is not set
Appium-Doctor detected problems. Please fix and rerun Appium-Doctor.
```
iOS Checks 都通过打钩就表示OK了，如果有没通过的 输入y安装好就行了



### 遇到的坑

好了到了坑了

去https://github.com/appium/sample-code  git下来个sample
然后在终端进入 git的目录，找到
>samplecode-master/sample-code/apps/TestApp，

进到这个目录在终端输入下面的东东：
>xcodebuild -sdk iphonesimulator 

会冒出来很大一堆东西

>/usr/bin/touch -c /Users/zecktang/Documents/autotest/sample-code/apps/TestApp/build/Release-iphonesimulator/TestApp.app
** BUILD SUCCEEDED **
ZeckTang-MacBook-Air:TestApp zecktang$ 

最后当看到**BUILD SUCCEEDED**则说明编译成功
编译成功之后 进入如下目录
>cd /samplecode-master/sample-code/examples/python

然后 运行 ios_simple.py 
即进到上面那个目录后 在终端输入 
>python ios_simple.py

OK，good，遇到一号坑了

提示appium 的 webdriver 找不到！
妈蛋的，去贱贱的搜了一下，找到了可能的答案
是mac的自带的 python版本问题
**需要把系统的python替换成appium的python**

在终端git 这个 地址
>https://github.com/appium/python-client

拉完之后 
>sudo python setup.py 

等着搞完就好了
恩，感觉妥妥的编译OK。

于是二号坑来了
出来了下面这一大段，于是仔细看看：

```
WebDriverException: Message: A new session could not be created.
(Original error: Could not find a device to launch. You requested 'iPhone 6 (8.3)',but the available devices were: ["iPad 2 (9.1)[B1793443-557C-4DAE-B5E5-371CC1ABBC18]",
"iPad Air (9.1) [81E1548D-268D-46C6-BE55-2F8B2CF7961D]",
"iPad Air 2 (9.1) [B765AEEB-D5C7-49DF-A48F-BA4D82658948]",
"iPad Pro (9.1) [B208F3B6-7A8E-4BB9-B3E2-968743D45984]",
"iPad Retina (9.1)[DEC5F328-E5B5-4AF4-BD71-8FB96EA20972]",
"iPhone 4s (9.1)[465AD1F7-E85D-4652-BD61-0651DBA18477]",
"iPhone 5 (9.1) [A6A8206D-6859-4FA4-8467-36AFC724244C]",
"iPhone 5s (9.1) [C6146A03-4771-4169-9F8E-6AE1754D109C]",
"iPhone 6 (9.1) [15015DE0-3BFF-4D13-A61D-C9AE3F152898]",
"iPhone 6 Plus (9.1)[A07AA020-2CE6-49A6-B166-BE33C7E2FF78]",
"iPhone 6s (9.1) [C57980BD-976C-4208-AB02-8DCBBF2B6E2F]",
"iPhone 6s (9.1) + Apple Watch - 38mm (2.0)+ +[DC4C72A3-34A1-4517-89AD-FFEC1EAD03A4]",
"iPhone 6s Plus (9.1) [652484FC-B7F0-4995-B930-924C95586976]",
"iPhone 6s Plus (9.1)+ Apple Watch - 42mm(2.0)[822F1F24-043D-46FA-AF22-9EB47BCC8222]"])
----------------------------------------------------------------------

Ran 2 tests in 6.220s
FAILED (errors=2)
ZeckTang-MacBook-Air:python zecktang$ 
```
对了，就是
>Original error: Could not find a device to launch. You requested 'iPhone 6 (8.3)

这一行，说的就是脚本指定的是iPhone 6
**iOS版本是8.3的，但是本地全是iOS版本 9.1的。**
所以 
>vi ios_simple.py

找到       
>'platformVersion': '8.3',

这一行 改成       
>'platformVersion': '9.1'

然后
>ESC  :wq 

搞定！
恩，然后就没然后了。
如果还是没编译OK，检查下appium 是否有启动
就是在终端输入 
>appium & 

就可以看出来的[X]aaaaa  X是不是1就可以了

>ZeckTang-MacBook-Air:TestApp zecktang$ appium &
[2] 12291

这个表示有2个了
OK. DAY 1 的记录到这了







