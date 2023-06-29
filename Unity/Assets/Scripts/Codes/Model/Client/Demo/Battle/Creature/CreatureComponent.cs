namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class CreatureComponent : Entity, IAwake, IDestroy, IUpdate
    {
           
        private EntityRef<Creature> castle;
        
        public Creature Castle
        {
            get
            {
                return this.castle;
            }
            set
            {
                this.castle = value;
            }
        }
        
        private EntityRef<Creature> role;
        
        public Creature Role
        {
            get
            {
                return this.role;
            }
            set
            {
                this.role = value;
            }
        }
    }
}