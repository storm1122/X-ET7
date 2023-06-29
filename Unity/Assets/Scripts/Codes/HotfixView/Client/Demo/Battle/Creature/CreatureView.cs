using ET.Client.BattleEvent;
using UnityEngine;

namespace ET.Client
{

    public class ViewComponentUpdateSystem: UpdateSystem<CreatureViewComponent>
    {
        protected override void Update(CreatureViewComponent self)
        {
            if (Input.GetKeyUp(KeyCode.Q))
            {
                CreatureHelper.GetCaster(self.DomainScene()).TestSpell1();
            }
        }
    }


    [Event(SceneType.Current)]
    [FriendOfAttribute(typeof(ET.Client.CreatureView))]
    public class Evt_CreateCreatureHandler : AEvent<Scene, Evt_CreateCreature>
    {
        protected override async ETTask Run(Scene currentScene, Evt_CreateCreature a)
        {

            var create = a.Creature;

            var viewComponent = currentScene.GetComponent<CreatureViewComponent>();

            var view = viewComponent.AddChildWithId<CreatureView>(create.Id);

            view.Data = create;

            var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);

            go.transform.position = new Vector3((float)a.Creature.Position.x, (float)a.Creature.Position.y, (float)a.Creature.Position.z);
            
            view.GameObject = go;


            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Current)]
    [FriendOfAttribute(typeof(ET.Client.CreatureView))]
    public class Evt_ChangePosHandler : AEvent<Scene, Evt_ChangePos>
    {
        protected override async ETTask Run(Scene currentScene, Evt_ChangePos a)
        {
            var create = a.Creature;

            var viewComponent = currentScene.GetComponent<CreatureViewComponent>();

            var view = viewComponent.GetChild<CreatureView>(create.Id);

            if (view == null)
            {
                Log.Error($"找不到对应的CreatureView , id:{create.Id}");
                return;
            }

            var go = view.GameObject;
            if (go != null)
            {
                go.transform.position = new Vector3((float)a.Creature.Position.x, (float)a.Creature.Position.y, (float)a.Creature.Position.z);
            }
            await ETTask.CompletedTask;
        }
    }
}