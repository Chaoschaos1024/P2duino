# P2 ROM Monitor 实战手册（入门篇）

你现在已经有 TAQOZ 环境了，下一步玩 Monitor 非常适合理解 P2 的底层结构。

先明确：

P2 上电后，ROM 会加载一套工具到 HUB RAM，包括：

* Bootloader
* ROM Monitor / Debugger
* TAQOZ

其中：

* 输入 `> ` + **ESC** → TAQOZ
* 输入 `> ` + **Ctrl+D** → ROM Monitor

Monitor 使用串口连接 P62/P63。它本质是一个低级调试器，可以直接操作 COG RAM、LUT RAM、HUB RAM，启动 COG 等。([Parallax 论坛][1])

---

# 一、进入 Monitor

你现在：

```
TAQOZ#
```

输入：

```
Ctrl+D
```

应该进入：

```
*
```

这个 `*` 就是 Monitor 提示符。

返回 TAQZ：

```
ESC
```

或者：

```
ESC + 回车
```

([Parallax 论坛][2])

---

# 二、Monitor 核心概念

P2 的地址空间不是统一的。

它有三类主要内存：

```
             P2

        +------------+
        |  HUB RAM   |
        | 512KB      |
        +------------+

        +------------+
        | COG RAM    |
        | 每核512L   |
        +------------+

        +------------+
        | LUT RAM    |
        | 每核512L   |
        +------------+
```

PASM 程序通常：

```
COG RAM
   |
   +--> 高速执行
```

Spin2：

```
HUB RAM
   |
   +--> 解释执行
```

([AlexRP 文档][3])

---

# 三、查看内存

Monitor 最核心功能。

格式：

```
地址 - 地址
```

例如：

查看低地址：

```
000-010
```

查看 HUB：

```
10000-10020
```

---

如果加：

```
L
```

表示 long：

例如：

```
000-010 L
```

显示：

```
000: xxxxxxxx
001: xxxxxxxx
...
```

官方格式：

```
xxxxxx - [xxxxxx] L
```

用于 LIST 内存。([Parallax 论坛][2])

---

# 四、理解地址判断规则

Monitor 很聪明：

地址：

```
< $400
```

默认认为：

```
COG/LUT 地址
```

例如：

```
010
```

表示：

```
COG RAM $010
```

如果你想看 HUB 低地址：

需要写：

```
000010
```

因为 HUB 地址范围更大。

([Parallax 论坛][1])

---

# 五、查看 COG RAM

例如：

进入 Monitor：

```
*
```

输入：

```
000-020 L
```

你会看到：

```
000:
001:
002:
...
```

这里就是当前 COG 的寄存器 RAM。

P2 每个 COG：

```
$000-$1FF
```

512 longs。

---

# 六、查看 LUT RAM

LUT：

```
$200-$3FF
```

所以：

输入：

```
200-220 L
```

查看：

```
LUT RAM
```

---

# 七、查看所有 COG

输入：

```
M
```

显示 COG 状态。

例如：

```
COG0 RUN
COG1 STOP
COG2 STOP
...
```

这个对于你之前研究“8核怎么分配任务”非常重要。

---

# 八、修改内存

Monitor 可以直接写。

格式：

```
地址: 数据
```

例如：

```
1000:12345678
```

表示：

HUB：

```
$1000 = $12345678
```

---

例如：

写 COG RAM：

```
010:FFFFFFFF
```

然后：

```
010-010 L
```

查看。

---

# 九、执行代码（GOTO）

Monitor 可以跳过去执行。

格式：

```
地址 G
```

例如：

```
000 G
```

意思：

跳转 COG 地址 0 执行。

官方：

```
xxxxxx G
```

= GOTO address。([Parallax 论坛][4])

---

# 十、启动 COG

Monitor 支持：

```
cog+地址
```

启动 COG。

例如：

```
0+100
```

含义：

启动 COG，从地址：

```
$100
```

开始执行。

停止：

```
cog-
```

---

# 十一、运行 SD 文件

Monitor 可以直接加载 SD：

格式：

```
Rfilename.ext
```

例如：

```
RTEST.BIX
```

运行 SD 文件。

([Parallax 论坛][4])

---

# 十二、下载数据

格式：

```
地址: 数据 数据 数据
```

例如：

```
1000:11223344 55667788
```

写入：

```
$1000
$1004
```

两个 long。

这相当于一个简易 loader。

---

# 十三、退出 Monitor

输入：

```
Q
```

返回用户程序。

([Parallax 论坛][4])

---

# 十四、几个非常推荐的实验

## 实验1：看看你的 COG

进入 Monitor：

```
000-010 L
```

观察。

---

## 实验2：看看 LUT

```
200-210 L
```

---

## 实验3：查看 HUB RAM

```
000000-000100 L
```

---

## 实验4：看 COG 状态

```
M
```

---

# 十五、Monitor 和 Spin2/PASM 的关系

你之前问：

> 为什么程序不是全部机器码？

Monitor 正好展示这个层次：

```
Spin2源码
   |
   v
编译器
   |
   v
机器码/PASM
   |
   v
COG RAM
        ↑
        |
     Monitor观察
```

Monitor 是站在最底层看：

```
寄存器
内存
指令
```

---

# 十六、和 STM32 调试器类比

如果你熟悉 STM32：

| STM32        | P2          |
| ------------ | ----------- |
| JTAG/SWD     | ROM Monitor |
| SRAM         | HUB RAM     |
| Core RAM     | COG RAM     |
| CPU寄存器    | COG寄存器   |
| Flash Loader | Boot ROM    |

区别：

P2 的 Monitor 是**芯片自带串口调试器**，不需要 SWD/JTAG。([Parallax 论坛][1])

---

# 下一篇建议：

你现在最值得继续研究的是：

**《P2 Monitor 实战篇（二）：手写第一段 PASM，在 COG RAM 运行，并用 Monitor 启动它》**

因为这一步会真正解释：

* COG 怎么启动
* HUB 如何给 COG 加载程序
* PASM 如何裸跑
* 多核通信为什么依赖 HUB RAM

这也是 P2 和 STM32/RP2040 最大的区别。

[1]: https://forums.parallax.com/discussion/170638/p2-rom-monitor-debugger-rev-1-rev-2-silicon?utm_source=chatgpt.com "P2 ROM Monitor/Debugger (rev 1 & rev 2 silicon)"
[2]: https://forums.parallax.com/discussion/173000/propeller-2-users-get-started-here?utm_source=chatgpt.com "Propeller 2 Users: Get Started Here!"
[3]: https://docs.alexrp.com/propeller/propeller_2_arch.pdf?utm_source=chatgpt.com "Propeller 2 P2X8C4M64P Hardware Manual Nov 1, 2022 release"
[4]: https://forums.parallax.com/discussion/168502/p2-rom-booter-serial-flash-sd-card-monitor-and-taqoz-features-and-operation/p1?utm_source=chatgpt.com "P2-ROM:  Booter, Serial, Flash, SD card, Monitor and TAQOZ features and operation"
