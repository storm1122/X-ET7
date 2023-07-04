using ET.Client.BattleEvent;
using TrueSync;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class DropComponent : Entity, IAwake, IDestroy
    {
    }

    [ChildOf(typeof(DropComponent))]
    public class Drop: Entity, IAwake<int>, IDestroy , IUpdate
    {
        public int ConfigId;

        private TSVector position;
        
        public TSVector Position
        {
            get => position;
            set
            {
                var oldPos = this.position;
                this.position = value;
                // EventSystem.Instance.Publish(this.DomainScene(), new Evt_ChangePos { Creature = this, OldPos = oldPos });
            }
        }
        
        public BattleDropConfig Config => BattleDropConfigCatefory.Instance.Get(this.ConfigId);
    }
}