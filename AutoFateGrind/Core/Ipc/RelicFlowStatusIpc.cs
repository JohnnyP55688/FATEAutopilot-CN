using System;
using AutoFateGrind.Core.Tasks;
using Dalamud.Plugin;
using Dalamud.Plugin.Ipc;

namespace AutoFateGrind.Core.Ipc;

/// <summary>Small, read-only status surface for RelicFlow and other progress dashboards.</summary>
internal sealed class RelicFlowStatusIpc : IDisposable
{
    private readonly ICallGateProvider<int> apiVersion;
    private readonly ICallGateProvider<bool> isRunning;
    private readonly ICallGateProvider<string> getStatus;
    private readonly ICallGateProvider<string> getPhase;

    public RelicFlowStatusIpc(IDalamudPluginInterface pi, AutoFateController controller)
    {
        apiVersion = pi.GetIpcProvider<int>("FateAutopilot.ApiVersion");
        isRunning = pi.GetIpcProvider<bool>("FateAutopilot.IsRunning");
        getStatus = pi.GetIpcProvider<string>("FateAutopilot.GetStatus");
        getPhase = pi.GetIpcProvider<string>("FateAutopilot.GetPhase");
        apiVersion.RegisterFunc(() => 1);
        isRunning.RegisterFunc(() => controller.Running);
        getStatus.RegisterFunc(() => controller.Status);
        getPhase.RegisterFunc(() => controller.Phase.ToString());
    }

    public void Dispose()
    {
        apiVersion.UnregisterFunc();
        isRunning.UnregisterFunc();
        getStatus.UnregisterFunc();
        getPhase.UnregisterFunc();
    }
}
