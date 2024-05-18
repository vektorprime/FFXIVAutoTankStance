using System;
using System.IO;
using System.Reflection;
using Dalamud.Data;
using Dalamud.Game;
using Dalamud.Game.ClientState;
using Dalamud.Game.ClientState.Buddy;
using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.JobGauge;
using Dalamud.Game.ClientState.Objects;
using Dalamud.Game.ClientState.Party;
using Dalamud.Game.Command;
using Dalamud.Game.Gui;
using Dalamud.Plugin;
using Dalamud.IoC;
using Dalamud.Plugin.Services;
using Dalamud.Plugin.Ipc;
using System.Collections.Generic;

namespace FFXIVAutoTankStance
{
    internal class Service
    {



        [PluginService]
        public static IFramework Framework { get; private set; } = null!;

        [PluginService]
        public static IDutyState DutyState { get; private set; } = null!;

        [PluginService]
        public static IClientState ClientState { get; private set; } = null!;

        [PluginService] 
        public static IObjectTable ObjectTable { get; private set; }

        [PluginService]
        public static ICondition Condition { get; private set; } = null!;
    }
}
