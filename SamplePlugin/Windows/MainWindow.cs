using System;
using System.Numerics;
using Dalamud.Interface.Internal;
using Dalamud.Interface.Utility;
using Dalamud.Interface.Windowing;
using FFXIVClientStructs.FFXIV.Client.Game;
using ImGuiNET;


namespace FFXIVAutoTankStance.Windows;

public class MainWindow : Window, IDisposable
{
    private IDalamudTextureWrap? GoatImage;
    private Plugin Plugin;

    // We give this window a hidden ID using ##
    // So that the user will see "My Amazing Window" as window title,
    // but for ImGui the ID is "My Amazing Window##With a hidden ID"
    public MainWindow(Plugin plugin, IDalamudTextureWrap? goatImage)
        : base("AutoTankStance##With a hidden ID", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse)
    {
        SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(375, 330),
            MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
        };

        GoatImage = goatImage;
        Plugin = plugin;
    }

    public void Dispose() { }

    public override void Draw()
    {
        //ImGui.Text($"The random config bool is {Plugin.Configuration.SomePropertyToBeSavedAndWithADefault}");

        //if (ImGui.Button("Show Settings"))
        //{
        //    Plugin.ToggleConfigUI();
        //}
        ImGui.Text("Welcome!");
        ImGui.Text("This plugin works automatically to execute the required skill for tank stance.");
        ImGui.Spacing();
        if (ImGui.Button("Debug"))
        ImGui.Text("DEBUG INFORMATION:");
        ImGui.Text("The below area checks if our class is Paladin and reports back.");
        // GameData gameData = new GameData();
        if (GameData.getCurrentJobClass() == GameData.JobClass.Paladin)
        {
            ImGui.Text("Paladin class detected.");
            //if(ImGui.Button("Test Iron Will"))
            //{
            //    // ActionMgr actionMgr = new ActionMgr();
            //    ActionMgr.UseIronWillSkill();

            //}
           
        }
        else 
        {
            ImGui.Text("Paladin class not detected.");
        }
       
        //if (GoatImage != null)
        //{
        //    ImGuiHelpers.ScaledIndent(55f);
        //    ImGui.Image(GoatImage.ImGuiHandle, new Vector2(GoatImage.Width, GoatImage.Height));
        //    ImGuiHelpers.ScaledIndent(-55f);
        //}
        //else
        //{
        //    ImGui.Text("Image not found.");
        //}
    }
}


