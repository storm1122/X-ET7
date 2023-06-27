namespace ET.Client
{

    [ObjectSystem]
    public class CreatureAwakeSystem: AwakeSystem<Creature, int>
    {
        protected override void Awake(Creature self, int configId)
        {
            self.ConfigId = configId;
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