using FFXIVClientStructs.FFXIV.Client.Game.InstanceContent; 
using FFXIVClientStructs.FFXIV.Client.Game.UI;

using Lumina.Excel.GeneratedSheets;
using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Dalamud.Game;
using Dalamud.Game.ClientState.Objects;
using Dalamud.Interface.Windowing;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using Dalamud.Game.ClientState.Objects.SubKinds;
using Dalamud.Game.ClientState.Statuses;

namespace FFXIVAutoTankStance
{

    
 
       //         case 1: return "Gladiator";
       //         case 2: return "Pugilist";
       //         case 3: return "Marauder";
       //         case 4: return "Lancer";
       //         case 5: return "Archer";
       //         case 6: return "Conjurer";
       //         case 7: return "Thaumaturge";
       //         case 8: return "Carpenter";
       //         case 9: return "Blacksmith";
       //         case 10: return "Armorer";
       //         case 11: return "Goldsmith";
       //         case 12: return "Leatherworker";
       //         case 13: return "Weaver";
       //         case 14: return "Alchemist";
       //         case 15: return "Culinarian";
       //         case 16: return "Miner";
       //         case 17: return "Botanist";
       //         case 18: return "Fisher";
       //         case 19: return "Paladin";
       //         case 20: return "Monk";
       //         case 21: return "Warrior";
       //         case 22: return "Dragoon";
       //         case 23: return "Bard";
       //         case 24: return "White Mage";
       //         case 25: return "Black Mage";
       //         case 26: return "Arcanist";
       //         case 27: return "Summoner";
       //         case 28: return "Scholar";
       //         case 29: return "Rogue";
       //         case 30: return "Ninja";
       //         case 31: return "Machinist";
       //         case 32: return "Dark Knight";
       //         case 33: return "Astrologian";
       //         case 34: return "Samurai";
       //         case 35: return "Red Mage";
       //         case 36: return "Blue Mage";
       //         case 37: return "Gunbreaker";
       //         case 38: return "Dancer";
       //         case 39: return "Reaper";
       //         case 40: return "Sage";


    public static class GameData
    {
        
        public static bool tankStanceOn = false;

        public  enum JobClass
        {
            Paladin,
            None
        }

        public static unsafe JobClass getCurrentJobClass()
        {
            var playerStatePointer = PlayerState.Instance();
            if (playerStatePointer != null)
            {
                if (playerStatePointer->CurrentClassJobId == 19)
                {
                    return JobClass.Paladin;
                }
                else
                {
                    return JobClass.None;
                }
            }
            else
            {
                return JobClass.None;
            }

        }



        //public static unsafe bool IsTankStanceOn()
        //{
        //    PlayerState.Instance()
        //}

        //private static unsafe readonly InstanceContentDirector instanceContentDirector = 

    }

  //public class HealthWatcher : IDisposable
  //  {
  //      private int? currentHP;


  //      public HealthWatcher()
  //      {
           
  //      }

  //      public void Dispose()
  //      {
            
  //      }
  //  }
}
