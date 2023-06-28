using System.Collections.Generic;
using TrueSync;

namespace ET.Client
{
    [ChildOf(typeof(FootHoldComponent))]
    public class FootHold : Entity , IAwake<int> , IDestroy
    {
        public int Idx;
        public TSVector Pos { get; set; }
        
        public List<int> SpawnConfigIds;
        
        public BattleLevelConfig LvConfig => this.GetParent<FootHoldComponent>().Config;

    }

 
}