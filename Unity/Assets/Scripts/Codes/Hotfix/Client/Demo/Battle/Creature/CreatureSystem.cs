namespace ET.Client
{

    [ObjectSystem]
    public class CreatureAwakeSystem: AwakeSystem<Creature, int>
    {
        protected override void Awake(Creature self, int configId)
        {
            self.ConfigId = configId;

            var attrComponent = self.AddComponent<AttrComponent>();
            foreach (var attr in self.Config.Attrs)
            {
                int bas = (int)attr.Key * 10 + 1;
                
                attrComponent.Set(bas,attr.Value);
                
                Log.Console($"{attr.Key}:{attrComponent[(int)attr.Key]}");
            }
       

            
        }
    }

    [ObjectSystem]
    public class CreatureDestorySystem: DestroySystem<Creature>
    {
        protected override void Destroy(Creature self)
        {
        }
    }

    public static class CreatureSystem
    {
        
    }
}