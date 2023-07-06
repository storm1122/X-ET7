namespace ET.Client
{
    [ObjectSystem]
    public class SpellComponentAwakeSystem: AwakeSystem<SpellComponent>
    {
        protected override void Awake(SpellComponent self)
        {
        }
    }

    [ObjectSystem]
    public class SpellComponentDestorySystem: DestroySystem<SpellComponent>
    {
        protected override void Destroy(SpellComponent self)
        {
            self.multiMap.Clear();
        }
    }
    [FriendOfAttribute(typeof(ET.Client.SpellComponent))]
    public static class SpellComponentSystem
    {
        public static void Add(this SpellComponent self, int spellId, Creature owner)
        {
            var spell = self.AddChild<Spell, int>(spellId);

            self.multiMap.Add(spellId, spell);

            spell.OnAdd(owner);
        }

    }
}