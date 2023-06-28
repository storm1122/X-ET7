using System.Collections.Generic;

namespace ET.Client
{
    [ChildOf]
    public class SpawnComponent : Entity, IAwake<int> , IDestroy
    {
        public int ConfigId;
        public int SpawnTime;
        public long Timer;
        public List<int> CreatureIds = new List<int>();
        public SpawnConfig Config => SpawnConfigCategory.Instance.Get(this.ConfigId);
        public ETCancellationToken CancelInterval;
    }
}