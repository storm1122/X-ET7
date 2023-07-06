namespace ET.Client
{
    [ChildOf(typeof(SpellComponent))]
    public class Spell : Entity, IAwake<int>, IDestroy, IUpdate
    {
        public int ConfigId;
        
        public SpellConfig Config => SpellConfigCategory.Instance.Get(this.ConfigId);
        
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
    public class Script_AddAttr: Entity, IAwake<int>, IDestroy, IUpdate, ISpellAdd
    {
        public int Idx;
    }
    [ChildOf(typeof(Spell))]
    public class Script_EnemyAtk: Entity, IAwake<int>, IDestroy, IUpdate, ISpellAdd
    {
        public int Idx;
    }
    [ChildOf(typeof(Spell))]
    public class Script_NormalBullet: Entity, IAwake<int>, IDestroy, IUpdate, ISpellAdd
    {
        public int Idx;
    }
}