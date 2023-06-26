namespace ET.Client
{
    [ChildOf(typeof(FootHoldComponent))]
    public class FootHold : Entity , IAwake<int>
    {
        public int ConfigId;
    }
}