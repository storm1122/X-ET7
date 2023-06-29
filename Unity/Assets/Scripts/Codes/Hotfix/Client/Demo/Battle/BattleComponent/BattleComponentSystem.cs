using System.Collections.Generic;
using TrueSync;

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
   public class BattleComponentUpdateSystem: UpdateSystem<BattleComponent>
   {
      protected override void Update(BattleComponent self)
      {
      }
   }
    [FriendOfAttribute(typeof(ET.Client.BattleComponent))]
    public static class BattleComponentSystem
    {

        public static void BattleAwake(this BattleComponent self)
        {
            var currentScene = self.DomainScene();
            self.BattleState = BattleState.Awake;
            
            // 设置关卡
            int startFootHoldIdx = 0; //从哪个落脚点开始，默认为0， SL的话，可能会从后面的序号开始
            var footHoldComponent = currentScene.AddComponent<FootHoldComponent, int, int>(ConstValue.BattleLevelConfigId, startFootHoldIdx);

            // 创建城堡
            var creatureComponent = currentScene.AddComponent<CreatureComponent>();
            var castle = creatureComponent.CreateCreature(1001, Camp.A);
            castle.Position = footHoldComponent.GetChild<FootHold>(0).Pos;

            creatureComponent.Castle = castle;
        }

        public static void BattleStart(this BattleComponent self)
        {
            self.BattleState = BattleState.Start;
            
            self.DomainScene().GetComponent<FootHoldComponent>().Next();
        }
        
        


    }
}