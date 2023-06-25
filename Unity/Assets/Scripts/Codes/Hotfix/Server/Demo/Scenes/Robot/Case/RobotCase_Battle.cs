namespace ET.Server
{
    [Invoke(RobotCaseType.BattleCase)]
    public class RobotCase_Battle: ARobotCase
    {
        protected override async ETTask Run(RobotCase robotCase)
        {
            using ListComponent<Scene> robots = ListComponent<Scene>.Create();
            
            await robotCase.Battle(robots);
        }
    }
}