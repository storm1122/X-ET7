using System.Collections.Generic;
using TrueSync;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class BattleData : Entity ,IAwake
    {
        public int BattleLevelConfigId = 1;
        public int BattleLevelStartIdx = 0;
    }
    
}