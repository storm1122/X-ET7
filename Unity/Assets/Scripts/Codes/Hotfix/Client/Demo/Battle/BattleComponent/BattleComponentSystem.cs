namespace ET.Client
{
   [ObjectSystem]
   public class BattleComponentAwakeSystem: AwakeSystem<BattleComponent>
   {
      protected override void Awake(BattleComponent self)
      {
      }
   }

   [ObjectSystem]
   public class BattleComponentDestorySystem: DestroySystem<BattleComponent>
   {
      protected override void Destroy(BattleComponent self)
      {
      }
   }

   [ObjectSystem]
   public class BattleComponentTickSystem: TickSystem<BattleComponent>
   {
      protected override void Tick(BattleComponent self)
      {
         
      }
   }
   
   public static class BattleComponentSystem
   {

      public static void Awake(this BattleComponent self)
      {
         
      }
      
      public static void Enter(this BattleComponent self)
      {
         
      }


   }
}