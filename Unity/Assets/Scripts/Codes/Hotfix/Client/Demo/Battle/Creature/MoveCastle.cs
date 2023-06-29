using System.Collections.Generic;
using TrueSync;

namespace ET.Client
{
    [FriendOfAttribute(typeof(ET.Client.FootHoldComponent))]
    public static class MoveCastle
    {
        public static void StartMove(Scene scene)
        {
            var castle = scene.GetComponent<CreatureComponent>().Castle;

            var footHoldComponent = scene.GetComponent<FootHoldComponent>();

            // 设置城堡移动路径（初始是停止状态）
            var move = castle.GetComponent<MoveComponent>();
            
            // 设置路径
            var count = footHoldComponent.Config.PosXList.Length;
            if (count != footHoldComponent.Config.PosYList.Length || count != footHoldComponent.Config.PosYList.Length)
            {
                Log.Error($"BattleLevelConfig配置不正确，坐标数量不符.ConfigId:{footHoldComponent.ConfigId}");
                return;
            }

            var i = footHoldComponent.CurPathIdx + 1;

            if (i >= footHoldComponent.Config.PosXList.Length)
            {
                Log.Console("到达最后一个据点， 无法继续移动城堡");
                return;
            }
            
            int x = footHoldComponent.Config.PosXList[i];
            int y = footHoldComponent.Config.PosYList[i];
            int z = footHoldComponent.Config.PosZList[i];

            List<TSVector> list = new List<TSVector>();
            list.Add(castle.Position);
            list.Add(new TSVector(x, y, z));
            Log.Console($"设置下一个路径 {new TSVector(x, y, z).ToString()}");
           
            move.MoveToAsync(list, castle.GetAttr().GetAsLong(AttrType.MoveSpeed)).Coroutine();
        }

        public static void StopMove(Scene scene)
        {
            var castle = scene.GetComponent<CreatureComponent>().Castle;
            var move = castle.GetComponent<MoveComponent>();
            move.Stop(false);
        }
    }
}