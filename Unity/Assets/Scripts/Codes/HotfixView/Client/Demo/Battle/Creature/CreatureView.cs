using Cinemachine;
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
    
    
    public class TempOperator: UpdateSystem<CreatureViewComponent>
    {
        protected override void Update(CreatureViewComponent self)
        {
        
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            if (h != 0 || v != 0)
            {
                self.Idx++;

                if (self.Idx < 10)
                {
                    return;
                }

                self.Idx = 0;
                
                var role = CreatureHelper.GetRole(self.DomainScene());

                role.Move(h, v);
                // Log.Console($"h:{h} , v:{v}");

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

            if (create.Config.Type == CreatureType.Role)
            {
                go.name = "Role";
                
                var vcamObj = GameObject.Find("CM vcam1");
                
                CinemachineVirtualCameraBase vcam = vcamObj.GetComponent<CinemachineVirtualCameraBase>();
                
                vcam.Follow = go.transform;
                
            }


            await ETTask.CompletedTask;
        }
    }


    [Event(SceneType.Current)]
    [FriendOfAttribute(typeof (ET.Client.CreatureView))]
    public class Evt_RemoveCreatureHandler: AEvent<Scene, Evt_RemoveCreature>
    {
        protected override async ETTask Run(Scene currentScene, Evt_RemoveCreature a)
        {
            var create = a.Creature;

            var viewComponent = currentScene.GetComponent<CreatureViewComponent>();

            var view = viewComponent.GetChild<CreatureView>(create.Id);

            if (view == null)
            {
                Log.Error($"找不到对应的CreatureView , id:{create.Id}");
                return;
            }
            
            if (view.GameObject != null)
            {
                UnityEngine.Object.DestroyImmediate(view.GameObject);
                view.GameObject = null;
            }
            
            view.Dispose();
            
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