<p align="center">
  <img src="AutoFateGrind/Images/Icon.png" width="160" alt="FATE Autopilot 图标" />
</p>

# FATEAutopilot 国服特供版

面向《最终幻想 XIV》国服 Dalamud 的 FATE 自动化插件兼容版。基于 FATE Autopilot 2.22.0.0，针对国服 Lumina 数据可能返回 `Language.None` 的情况进行了稳健处理。

> 本项目是社区维护的非官方兼容版本，与盛趣游戏、Square Enix、Dalamud、原作者均无隶属或背书关系。使用自动化插件可能违反游戏规则，请自行判断风险并承担后果。

## 国服兼容修复

- 修复 `Lumina.Excel.Exceptions.UnsupportedLanguageException`：FATE 名称读取失败时回退为 `FATE #编号`，不会中断自动流程。
- 修复图形界面、紧凑状态栏、Mini Player、收集型 FATE 和节奏控制中的同类名称崩溃。
- 修复自动传送前解析传送点名称导致的 `Language.None` 异常。
- 绕开 `clib.Coords` 内部对本地化表的读取，使用稳定的传送点 ID 和坐标完成传送。
- 区域名、传送点名和调试信息均提供数字 ID 回退。

## 主要功能

- 自动选择、传送、飞行前往并完成 FATE。
- 支持多地图轮换、双色宝石目标、共享 FATE、遗物素材与妖怪手表等目标。
- 支持 vnavmesh 寻路，以及 BossMod/BossMod Reborn 战斗逻辑。
- 支持收集型 FATE、自动修理、自动食药、职业队列和运行限制。
- 命令前缀：`/fta` 或 `/fateautopilot`。

## 安装方法

1. 从仓库的 **Releases** 页面下载 `FATEAutopilot-2.22.0-CN-LanguageNone-fix.zip`。
2. 完整解压到固定目录，例如 `C:\DalamudPlugins\FATEAutopilot-CN\`。不要只取 DLL，依赖文件必须保留。
3. 游戏内输入 `/xlsettings`，打开“实验性功能”。
4. 在“开发插件位置”中添加解压目录里的 `FateAutopilot.dll`。
5. 打开 `/xlplugins`，扫描开发插件并启用 **FATE Autopilot**。
6. 不要同时启用其他同名版本。

建议同时安装并启用：

- **vnavmesh**：路径规划和移动。
- **BossMod** 或 **BossMod Reborn**：战斗、目标选择和躲避。
- **TextAdvance**：收集型 FATE 交付时跳过对话。

## 常用命令

| 命令 | 作用 |
| --- | --- |
| `/fta` | 打开或关闭主窗口 |
| `/fta start` | 按当前计划开始 |
| `/fta stop` | 停止运行 |
| `/fta pause` | 暂停或继续 |
| `/fta config` | 打开设置 |
| `/fta deps` | 查看依赖状态 |
| `/fta log` | 打开插件日志页 |

## 编译

需要 .NET 10 SDK 和 Dalamud API 15 开发文件：

```powershell
$env:DALAMUD_HOME = '你的 Dalamud Hooks\dev 路径'
dotnet build AutoFateGrind/AutoFateGrind.csproj -c Release
```

生成的插件包位于 `AutoFateGrind/bin/Release/FateAutopilot/latest.zip`。

## 验证状态

- 已使用国服 XIVLauncherCN 的 Dalamud API 15 完成 Release 编译。
- 已验证安装包可解压，且其中 DLL 与编译产物校验一致。
- 已在实际国服客户端加载插件并针对 `Language.None` 报错进行调试。
- 游戏版本、Dalamud、依赖插件更新后仍可能需要继续适配。

## 反馈问题

提交 Issue 时请附上：

- FATE Autopilot、Dalamud 和游戏版本。
- `/xllog` 中从异常类型开始的完整调用栈。
- 触发报错时所在地图和正在执行的操作。

请先删除角色名、账号信息和本机隐私路径。

## 来源与许可证

本项目基于 Sojiroh 的 FATE Autopilot，以及更早的 XeldarAlz / Auto FATE Grind。保留原项目版权、NOTICE 和商标说明。

代码采用 **AGPL-3.0-or-later**，详情见 [LICENSE.md](LICENSE.md)、[NOTICE](NOTICE) 和 [TRADEMARK.md](TRADEMARK.md)。
