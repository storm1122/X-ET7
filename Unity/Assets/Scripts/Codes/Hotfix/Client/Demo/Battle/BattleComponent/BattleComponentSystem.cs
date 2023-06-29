﻿using System.Collections.Generic;
using ET.Client.BattleEvent;
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
    [FriendOfAttribute(typeof(ET.Client.FootHoldComponent))]
    [FriendOfAttribute(typeof(ET.Client.BattleData))]
    public static class BattleComponentSystem
    {

        public static void BattleAwake(this BattleComponent self)
        {
            var battleData = self.ClientScene().GetComponent<BattleData>();

            Log.Console($"开始战斗，关卡id:{battleData.BattleLevelConfigId} , 起始idx:{battleData.BattleLevelStartIdx}");

            var currentScene = self.DomainScene();
            self.BattleState = BattleState.Awake;

            // 设置关卡
            // 参数1：关卡id， 参数2：从哪个落脚点开始，默认为0， SL的话，可能会从后面的序号开始
            var footHoldComponent =
                    currentScene.AddComponent<FootHoldComponent, int, int>(battleData.BattleLevelConfigId, battleData.BattleLevelStartIdx);

            var creatureComponent = currentScene.AddComponent<CreatureComponent>();

            // 创建城堡
            var castle = creatureComponent.CreateCreature(ConstValue.CastleCreatureId, Camp.A);
            castle.Position = footHoldComponent.GetChild<FootHold>(footHoldComponent.CurPathIdx).Pos;
            creatureComponent.Castle = castle;

            // 创建小人
            var role = creatureComponent.CreateCreature(ConstValue.RoleCreatureId, Camp.A);
            creatureComponent.Role = role;
            
        }

        public static void BattleStart(this BattleComponent self)
        {
            self.BattleState = BattleState.Start;

            self.DomainScene().GetComponent<FootHoldComponent>().Start();
        }

        public static void BattleEnd(this BattleComponent self)
        {
            EventSystem.Instance.Publish(self.DomainScene(), new Evt_BattleEnd { });
        }

    }
}