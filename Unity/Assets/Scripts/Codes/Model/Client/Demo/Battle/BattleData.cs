using System.Collections.Generic;
using TrueSync;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class BattleData : Entity ,IAwake
    {
        public FP Width = 40;
        public FP Height = 80;

        public int CurPathIdx = 0;

        public List<TSVector> Path = new List<TSVector>()
        {
            new TSVector(20, 0, -40),
            new TSVector(0, 0, -40 / 2),
            new TSVector(20, 0, 0),
            new TSVector(0, 0, 40 / 2),
            new TSVector(20, 0, 40),
        };

      
        
        private List<List<List<int>>> BornInfo = new List<List<List<int>>>()
        {
            new List<List<int>>()
            {
                new List<int>(){1003,1003,1003,1003,1003,1003},
                new List<int>(){1003,1003,1003,1003,1003,1003},
                new List<int>(){1003,1003,1003,1003,1003,1003},
            },
            
            new List<List<int>>()
            {
                new List<int>(){1003,1003,1003,1003,1003,1003},
                new List<int>(){1003,1003,1003,1003,1003,1003},
                new List<int>(){1003,1003,1003,1003,1003,1003},
            },
            
            new List<List<int>>()
            {
                new List<int>(){1003,1003,1003,1003,1003,1003},
                new List<int>(){1003,1003,1003,1003,1003,1003},
                new List<int>(){1003,1003,1003,1003,1003,1003},
            },
        };


    }
    
}