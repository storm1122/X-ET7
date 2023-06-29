using UnityEngine;

namespace ET.Client
{

    [ComponentOf(typeof(Scene))]
    public class CreatureViewComponent : Entity, IAwake, IDestroy, IUpdate
    {
        public int Timer;
    }
 
    
    [ChildOf(typeof(CreatureViewComponent))]
    public class CreatureView : Entity, IAwake, IDestroy
    {
        private EntityRef<Creature> data;
        
        public Creature Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        public GameObject GameObject;
    }
}