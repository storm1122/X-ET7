using System.Collections.Generic;
using TrueSync;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class BattleData : Entity ,IAwake
    {
        public FP Width = 40;
        public FP Height = 80;

        public int CurPath = 0;

        public List<TSVector2> Path = new List<TSVector2>()
        {
            new TSVector2(0, -40),
            new TSVector2(0, -40 / 2),
            new TSVector2(0, 0),
            new TSVector2(0, 40 / 2),
            new TSVector2(0, 40),
        };
        
    }
    
}