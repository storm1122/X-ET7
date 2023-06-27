namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class BattleComponent : Entity, IAwake, IDestroy, ITick
    {
        public int Tick  => Game.Tick;
        public int Delta => Game.Delta;
    }
}