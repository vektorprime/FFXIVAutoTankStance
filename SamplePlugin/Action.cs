using FFXIVClientStructs.FFXIV.Client.Game;
using Lumina.Excel.GeneratedSheets;
using Lumina.Excel.GeneratedSheets2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//public enum ActionType : byte
//{
//    None = 0x00,
//    Action = 0x01, // Spell, Weaponskill, Ability. Confusing name, I know.
//    Item = 0x02,
//    KeyItem = 0x03,
//    Ability = 0x04, // Not in UseAction (??)
//    GeneralAction = 0x05,
//    BuddyAction = 0x06,
//    MainCommand = 0x07,
//    Companion = 0x08,
//    CraftAction = 0x09,
//    Unk_10 = 0x0A, // Fishing per Sapphire? Something to do with items.
//    PetAction = 0x0B,
//    Unk_12 = 0x0C, // Not in UseAction. Sapphire says CompanyAction, but not actually triggered.
//    Mount = 0x0D,
//    PvPAction = 0x0E,
//    FieldMarker = 0x0F,
//    ChocoboRaceAbility = 0x10,
//    ChocoboRaceItem = 0x11,
//    Unk_18 = 0x12, // Not in UseAction (?)
//    BgcArmyAction = 0x13,
//    Ornament = 0x14,
//}

namespace FFXIVAutoTankStance
{
    public class ActionMgr
    {
        //public static unsafe ActionManager* getInstance()
        //{
        //    return ActionManager.Instance();
        //}

        private static unsafe readonly ActionManager* instance = ActionManager.Instance();
        public static unsafe void DoAction(ActionType actionType, uint actionID, ulong targetID = 0xE000_0000, uint a4 = 0, uint a5 = 0, uint a6 = 0, void* a7 = null)
        {
            instance->UseAction(actionType, actionID, targetID, a4, a5, a6, a7);
        }

        public static unsafe void UseIronWillSkill()
        {
            //ActionMgr actionMgr = new ActionMgr();
            const uint ironWillSkill = 28;
            instance->UseAction(ActionType.Action, ironWillSkill);
        }
    }

}
