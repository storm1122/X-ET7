using TrueSync;

namespace ET.Client
{
      public struct Evt_SceneAwake 
      {
      }
      public struct Evt_SceneEnter
      {
      }
      public struct Evt_BattleEnd
      {
      }

      public struct Evt_CreateCreature 
      {
          public Creature Creature;
      }
     
      public struct Evt_RemoveCreature 
      {
          public Creature Creature;
      }
      
      
      public struct Evt_CreatureDead
      {
          public Creature Creature;
      }
      

      public struct Evt_CreateFootHold
      {
          public FootHold FootHold;
      }
      
      public struct Evt_CreateDrop 
      {
          public Drop Drop;
      }
      public struct Evt_RmoveDrop 
      {
          public Drop Drop;
      }
      
      public struct Evt_CreatureTakeDamage
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
      public struct Evt_MoveStart
      {
          public Creature Creature;
      }
      public struct Evt_MoveStop 
      {
          public Creature Creature;
      }
      public struct Evt_MovePathEnd
      {
          public Creature Creature;
          public int N;
      }
}