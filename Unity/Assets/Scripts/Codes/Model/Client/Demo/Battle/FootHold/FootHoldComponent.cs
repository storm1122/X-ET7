namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class FootHoldComponent : Entity , IAwake , IDestroy
    {
        public int CurPathIdx;
    }
}