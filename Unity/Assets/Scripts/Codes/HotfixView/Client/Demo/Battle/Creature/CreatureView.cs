using ET.Client.BattleEvent;
using UnityEngine;

namespace ET.Client
{

    [Event(SceneType.Current)]
    public class Evt_CreateCreatureHandler : AEvent<Scene, Evt_CreateCreature>
    {
        protected override async ETTask Run(Scene currentScene, Evt_CreateCreature a)
        {
            Log.Error("recv create !!! ");
            
            var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);

            go.name = "aaa";

            go.transform.position = new Vector3((float)a.Creature.Position.x, (float)a.Creature.Position.y, (float)a.Creature.Position.z);
            
            await ETTask.CompletedTask;
        }
    }
    
    [Event(SceneType.Current)]
    public class Evt_ChangePosHandler : AEvent<Scene, Evt_ChangePos>
    {
        protected override async ETTask Run(Scene currentScene, Evt_ChangePos a)
        {
            var go = GameObject.Find("aaa");
            if (go != null)
            {
                go.transform.position = new Vector3((float)a.Creature.Position.x, (float)a.Creature.Position.y, (float)a.Creature.Position.z);
            }
            await ETTask.CompletedTask;
        }
    }
}