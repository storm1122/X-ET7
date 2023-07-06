namespace ET.Client
{
    [ComponentOf(typeof(Creature))]
    public class SpellComponent : Entity, IAwake, IDestroy
    {
        public MultiMap<int, Spell> multiMap = new MultiMap<int, Spell>();
    }
}