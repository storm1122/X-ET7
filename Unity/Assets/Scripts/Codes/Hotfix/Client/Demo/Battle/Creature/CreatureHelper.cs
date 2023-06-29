using System.Collections.Generic;

namespace ET.Client
{
    [FriendOfAttribute(typeof(ET.Client.Creature))]
    public static class CreatureHelper
    {
        public static Creature GetCaster(Scene currentScene)
        {
            return currentScene.GetComponent<CreatureComponent>()?.Castle;
        }

        public static List<Creature> GetCreature(Scene currentScene, CreatureType type)
        {
            List<Creature> list = new List<Creature>();

            foreach ((long key, Entity value) in currentScene.GetComponent<CreatureComponent>().Children)
            {
                Creature creature = (Creature)value;
                
                if (creature.CreatureType == type)
                {
                    list.Add(creature);
                }
            }
            return list;
        }
        
        public static List<Creature> GetCreature(Scene currentScene, Camp camp)
        {
            // using ListComponent<Creature> list = ListComponent<Creature>.Create();

            List<Creature> list = new List<Creature>();

            foreach ((long key, Entity value) in currentScene.GetComponent<CreatureComponent>().Children)
            {
                Creature creature = (Creature)value;
                
                if (creature.Camp == camp)
                {
                    list.Add(creature);
                }
            }
            return list;
        }
    }
}