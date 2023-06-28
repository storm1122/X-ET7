namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class FootHoldComponent : Entity , IAwake<int> , IDestroy
    {
        public int ConfigId;
        public int CurPathIdx;
        
        public BattleLevelConfig Config => BattleLevelConfigCategory.Instance.Get(this.ConfigId);
    }
}