using TrueSync;

namespace ET.Client
{
    namespace BattleEvent
    {
        public interface Evt_Battle
        {
            
        }
        public struct Evt_SceneAwake : IBattleEvt
        {
        }
        public struct Evt_SceneEnter : IBattleEvt
        {
        }
        public struct Evt_BattleEnd : IBattleEvt
        {
        }

        public struct Evt_CreateCreature : IBattleEvt
        {
            public Creature Creature;
        }
       
        public struct Evt_RemoveCreature : IBattleEvt
        {
            public Creature Creature;
        }

        public struct Evt_CreateFootHold
        {
            public FootHold FootHold;
        }
        
        public struct Evt_CreateDrop : IBattleEvt
        {
            public Drop Drop;
        }
        public struct Evt_RmoveDrop : IBattleEvt
        {
            public Drop Drop;
        }
        
        public struct Evt_CreatureTakeDamage : IBattleEvt
        {
            public Creature Creature;
            public long Damage;
        }
        
        public struct Evt_ChangePos
        {
            public Creature Creature;
            public TSVector OldPos;
        }
        public struct Evt_ChangeRotation
        {
            public Creature Creature;
        }
        public struct Evt_MoveStart : IBattleEvt
        {
            public Creature Creature;
        }
        public struct Evt_MoveStop : IBattleEvt
        {
            public Creature Creature;
        }
        public struct Evt_MovePathEnd
        {
            public Creature Creature;
            public int N;
        }
    }
}