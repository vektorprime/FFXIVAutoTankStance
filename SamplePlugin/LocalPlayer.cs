using Dalamud.Game.ClientState.Objects.SubKinds;
using Lumina.Excel.GeneratedSheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVAutoTankStance
{
    internal class LocalPlayer
    {
        private PlayerCharacter localPlayer;
       public  LocalPlayer()
        {
            localPlayer = Service.ClientState.LocalPlayer;
        }


        
        public  bool isTankStanceOn()
        {
            uint ironWillStatusID = 79;
            foreach (Dalamud.Game.ClientState.Statuses.Status stat in localPlayer.StatusList)
            {
                if (stat.StatusId == ironWillStatusID)
                {
                    return true;
                }
            }

            return false;

        }


        public bool isWatchingCutscene()
        {
            Dalamud.Game.ClientState.Conditions.ConditionFlag[] cutScenes  = {
                Dalamud.Game.ClientState.Conditions.ConditionFlag.OccupiedInCutSceneEvent,
                Dalamud.Game.ClientState.Conditions.ConditionFlag.WatchingCutscene,
                Dalamud.Game.ClientState.Conditions.ConditionFlag.WatchingCutscene78
            };


           foreach (var s in cutScenes)
            {
                if (Service.Condition[s])
                {
                    return true;
                }
            }
            return false;
        }


        //public bool isWatchingCutscene()
        //{
        //    var watchingCutscene = Dalamud.Game.ClientState.Conditions.ConditionFlag.WatchingCutscene;
        //    if (Service.Condition.Any())
        //    {

        //        var cutSCeneObject = Dalamud.Game.ClientState.Objects.Enums.ObjectKind.Cutscene;
        //       if (Service.ObjectTable.Any()) 
        //        {

        //          //Service.ObjectTable.Where(x => x.ObjectKind == cutSCeneObject)

        //            foreach (var gobj in Service.ObjectTable)
        //            {

        //            }


        //        }
        //    }
        //    return false; 
        //}
    }
}
