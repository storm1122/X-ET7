using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class FootHoldViewComponent : Entity , IAwake , IDestroy
    {
        
    }
    
    [ChildOf(typeof(FootHoldViewComponent))]
    public class FootHoldView : Entity , IAwake , IDestroy
    {
        private EntityRef<FootHold> data;
        
        public FootHold Data
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