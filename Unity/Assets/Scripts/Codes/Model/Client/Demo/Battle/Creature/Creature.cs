using ET.Client.BattleEvent;
using TrueSync;
using Unity.Mathematics;

namespace ET.Client
{
    [ChildOf(typeof(CreatureComponent))]
    public class Creature : Entity , IAwake<int>, IDestroy
    {
        public int ConfigId;

        private TSVector position;

        public CreatureType CreatureType;
        
        public TSVector Position
        {
            get => position;
            set
            {
                var oldPos = this.position;
                this.position = value;
                EventSystem.Instance.Publish(this.DomainScene(), new Evt_ChangePos { Creature = this, OldPos = oldPos });
            }
        }

        private TSQuaternion rotation;

        public TSQuaternion Rotation
        {
            get => this.rotation;
            set
            {
                this.rotation = value;
                EventSystem.Instance.Publish(this.DomainScene(), new Evt_ChangeRotation { Creature = this });

            }
        }

        public TSVector Forward
        {
            get => this.Rotation * TSVector.forward;
            set => this.Rotation = TSQuaternion.LookRotation(value, TSVector.up);
        }
        
    }
}