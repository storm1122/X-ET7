using System.Collections.Generic;

namespace ET.Client
{
    [ChildOf]
    public class SpawnComponent : Entity, IAwake<int> , IDestroy
    {
        public int ConfigId;
        public long Timer;
        public SpawnConfig Config => SpawnConfigCategory.Instance.Get(this.ConfigId);
        public ETCancellationToken CancelInterval;
    }
}