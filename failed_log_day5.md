DAY 5 

终于有点时间了

今天摸索摸索的 总算把.app文件用appium GUI工具在模拟器里面run起来，并且启动了Inspector 了

就在Advance Setting 里面勾选了第一个选项 Use Native Instrument Library ,前面困扰了我好久的

Instruments crashed on startup不能Launch的问题迎刃而解

不能Launch的问题描述如下：
```
info: Launching instruments

info: [debug] Attempting to run app on iPad Air (9.2)
info: [debug] Spawning instruments with command: /Applications/Xcode.app/Contents/Developer/usr/bin/instruments -t /Applications/Xcode.app/Contents/Applications/Instruments.app/Contents/PlugIns/AutomationInstrument.xrplugin/Contents/Resources/Automation.tracetemplate -D /tmp/appium-instruments/instrumentscli0.trace -w "iPad Air (9.2)" /Users/zecktang/Documents/autotest/ImgoTV-ipad.app -e UIASCRIPT "/Users/zecktang/Library/Application Support/appium/bootstrap/bootstrap-f062718992d59810.js" -e UIARESULTSPATH /tmp/appium-instruments
info: [debug] And extra without-delay env: {"DYLD_INSERT_LIBRARIES":"/Applications/Appium.app/Contents/Resources/node_modules/appium/submodules/appium-instruments/thirdparty/iwd7/InstrumentsShim.dylib","LIB_PATH":"/Applications/Appium.app/Contents/Resources/node_modules/appium/submodules/appium-instruments/thirdparty/iwd7"}
info: [debug] And launch timeouts (in ms): {"global":90000}
info: [debug] [INSTSERVER] Instruments exited with code null
info: [debug] Killall instruments
info: [debug] Instruments crashed on startup
info: [debug] We exceeded the number of retries allowed for instruments to successfully start; failing launch
info: [debug] Stopping iOS log capture
info: [debug] Running ios sim reset flow
info: [debug] Killing the simulator process
info: [debug] Killing any other simulator daemons

error: Could not pre-launch appium: Error: Instruments crashed on startup
```



有了Inspector了，简单的自动化脚本基本就可以完成了，这个时候就可以依赖文档中的基础语言API写初步的脚本了。

或者使用Inspector 里面的简单的生成脚本也OK(里面有个Record玩过按键精灵的小伙伴就知道录制这个东东怎么玩了)，关键是可以获取界面上各个 控件的xpath等等关键参数

好了，今天就到这了，要不还在公司玩，老婆会生气的！


