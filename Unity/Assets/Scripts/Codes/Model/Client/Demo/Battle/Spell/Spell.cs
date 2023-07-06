namespace ET.Client
{
    [ChildOf(typeof(SpellComponent))]
    public class Spell : Entity, IAwake<int>, IDestroy, IUpdate
    {
        public int ConfigId;
        
        private EntityRef<Creature> owner;
        
        public Creature Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }

    }

    [ChildOf(typeof(Spell))]
    public class Script_AddAttr: Entity, IAwake, IDestroy, IUpdate
    {
    }
}