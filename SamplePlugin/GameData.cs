using FFXIVClientStructs.FFXIV.Client.Game.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVAutoTankStance
{
 

    public class GameData
    {
       public enum JobClass
        {
            Paladin,
            None
        }

        public unsafe JobClass getCurrentJobClass()
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
    }
}
