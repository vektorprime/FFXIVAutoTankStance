using Dalamud.Game.Command;
using Dalamud.IoC;
using Dalamud.Plugin;
using System.IO;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin.Services;
using FFXIVAutoTankStance.Windows;



namespace FFXIVAutoTankStance;

public sealed class Plugin : IDalamudPlugin
{
    private const string CommandName = "/autotank";

    private DalamudPluginInterface PluginInterface { get; init; }
    private ICommandManager CommandManager { get; init; }
    public Configuration Configuration { get; init; }

    public readonly WindowSystem WindowSystem = new("Auto Tank Stance");
    private ConfigWindow ConfigWindow { get; init; }
    private MainWindow MainWindow { get; init; }

  

    public Plugin(
        [RequiredVersion("1.0")] DalamudPluginInterface pluginInterface,
        [RequiredVersion("1.0")] ICommandManager commandManager,
        [RequiredVersion("1.0")] ITextureProvider textureProvider)
    {
        PluginInterface = pluginInterface;
        CommandManager = commandManager;

        //Creating service is critical for getting it to work
        PluginInterface.Create<Service>();
    
        Configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
        Configuration.Initialize(PluginInterface);

        // you might normally want to embed resources and load them from the manifest stream
        var file = new FileInfo(Path.Combine(PluginInterface.AssemblyLocation.Directory?.FullName!, "goat.png"));

        // ITextureProvider takes care of the image caching and dispose
        var goatImage = textureProvider.GetTextureFromFile(file);

        ConfigWindow = new ConfigWindow(this);
        MainWindow = new MainWindow(this, goatImage);

        WindowSystem.AddWindow(ConfigWindow);
        WindowSystem.AddWindow(MainWindow);
        
        //TODO figoure out best way to sync this object to the window
        //Static or pass it in via something
        //GameData gameData = new GameData();
        //if (GameData.getCurrentJobClass() == GameData.JobClass.Paladin)
        //{
        //    // unsafe
        //    // {
        //    //ActionMgr actionMgr = new ActionMgr();
        //    //ActionType ironWillType = ActionType.Action;
        //    // ActionMgr.DoAction(ActionType.Action, 28);
        //    // }
        //    //ActionManager->Instance()->UseAction()

           
        //}

        

        CommandManager.AddHandler(CommandName, new CommandInfo(OnCommand)
        {
            HelpMessage = "A useful message to display in /xlhelp"
        });

        PluginInterface.UiBuilder.Draw += DrawUI;

        // This adds a button to the plugin installer entry of this plugin which allows
        // to toggle the display status of the configuration ui
        PluginInterface.UiBuilder.OpenConfigUi += ToggleConfigUI;

        // Adds another button that is doing the same but for the main ui of the plugin
        PluginInterface.UiBuilder.OpenMainUi += ToggleMainUI;

        Service.Framework.Update += OnFrameworkUpdate;

    }

    private void OnFrameworkUpdate(IFramework framework)
    {
        if (Service.ClientState.IsLoggedIn)
        {
           // if (GameData.getCurrentJobClass() == GameData.JobClass.Paladin)
           // {

                //test code that should always run if we're a Pali
                if (GameData.getCurrentJobClass() == GameData.JobClass.Paladin)
                {
                    LocalPlayer tankPlayer = new LocalPlayer();
                    if (!tankPlayer.isTankStanceOn() && !tankPlayer.isWatchingCutscene())
                    {
                        ActionMgr.UseIronWillSkill();
                    }

               // }
                

                //code to use when only using tank stance in duty/dungeon
                //if (Service.DutyState.IsDutyStarted)
                //{
                //    if (GameData.getCurrentJobClass() == GameData.JobClass.Paladin)
                //    {
                //        LocalPlayer tankPlayer = new LocalPlayer();
                //        if (!tankPlayer.isTankStanceOn())
                //        {
                //            ActionMgr.UseIronWillSkill();
                //        }

                //    }
                //}

            }


        }

    }

    public void Dispose()
    {
        WindowSystem.RemoveAllWindows();

        ConfigWindow.Dispose();
        MainWindow.Dispose();

        CommandManager.RemoveHandler(CommandName);
        Service.Framework.Update -= OnFrameworkUpdate;
    }

    private void OnCommand(string command, string args)
    {
        // in response to the slash command, just toggle the display status of our main ui
        ToggleMainUI();
    }

    private void DrawUI() => WindowSystem.Draw();

    public void ToggleConfigUI() => ConfigWindow.Toggle();
    public void ToggleMainUI() => MainWindow.Toggle();
}
