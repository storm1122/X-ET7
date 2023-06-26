namespace ET.Client
{
    public class BattleComponent : Entity, IAwake
    {
        public int Tick  => Game.Tick;
        public int Delta => Game.Delta;
    }
}