namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class BattleComponent : Entity, IAwake, IDestroy, IUpdate
    {
        public int Tick  => Game.Tick;
        public int Delta => Game.Delta;

        public BattleState BattleState;
        
    }

    public enum BattleState
    {
        None,
        Awake,
        Start,
    }
}