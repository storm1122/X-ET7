﻿using System.Collections.Generic;
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

    }
    
}