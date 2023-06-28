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
            }

            if (attrComponent[AttrType.MoveSpeed] > 0)
            {
                self.AddComponent<MoveComponent>();
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