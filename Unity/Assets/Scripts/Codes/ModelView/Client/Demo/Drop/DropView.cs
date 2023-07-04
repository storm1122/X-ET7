using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class DropViewComponent : Entity , IAwake , IDestroy
    {
        
    }
    
    [ChildOf(typeof(DropViewComponent))]
    public class DropView : Entity , IAwake , IDestroy
    {
        private EntityRef<Drop> data;
        
        public Drop Data
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