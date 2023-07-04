using Cinemachine;
using ET.Client.BattleEvent;
using UnityEngine;

namespace ET.Client
{
    [FriendOfAttribute(typeof(ET.Client.CreatureView))]
    public static class CreatureViewHelper
    {
        public static void Create(Scene currentScene, Evt_CreateCreature a)
        {
            var create = a.Creature;

            var viewComponent = currentScene.GetComponent<CreatureViewComponent>();

            var view = viewComponent.AddChildWithId<CreatureView>(create.Id);
            
            view.OnCreate(a.Creature);

        }

        public static CreatureView GetView(Scene currentScene, long id)
        {
            var viewComponent = currentScene.GetComponent<CreatureViewComponent>();

            var view = viewComponent.GetChild<CreatureView>(id);

            if (view == null)
            {
                Log.Error($"找不到对应的CreatureView , id:{id}");
            }

            return view;
        }
    }
}