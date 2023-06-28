using System.Collections.Generic;
using TrueSync;

namespace ET.Client
{
    [ChildOf(typeof(FootHoldComponent))]
    public class FootHold : Entity , IAwake<int> , IDestroy
    {
        public int ConfigId;
        public TSVector Pos;
    }

 
}