using TrueSync;

namespace ET.Client
{
    public enum SpellState
    {
        None = 0,
        Cast,
        Launch,
    }
    
    [ChildOf(typeof(SpellComponent))]
    public class Spell : Entity, IAwake<int>, IDestroy, IUpdate
    {
        public int ConfigId;

        public long Cd;
        public long MaxCd;

        public long NextCd;

        public bool InCD
        {
            get => this.Cd < this.NextCd;
        }

        // public SpellState SpellState;

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
    public class Script_AddAttr: Entity, IAwake<int>, IDestroy, IUpdate, ISpellAdd , ISpellRemove
    {
        public int Idx;
    }
    [ChildOf(typeof(Spell))]
    public class Script_EnemyAtk: Entity, IAwake<int>, IDestroy, IUpdate, ISpellLaunch
    {
        public int Idx;
    }
    [ChildOf(typeof(Spell))]
    public class Script_NormalBullet: Entity, IAwake<int>, IDestroy, IUpdate, ISpellAdd
    {
        public int Idx;
    }


    [ComponentOf(typeof (Scene))]
    public class DamageComponent: Entity, IAwake
    {
        
    }

    
    [ChildOf]
    public class Damage: Entity, IAwake
    {
        private EntityRef<Creature> owner;

        public long DmgAdd;

        public long DmgPct;
        
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
}