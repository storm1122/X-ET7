using TrueSync;

namespace ET.Client
{
    public class AI_Attack: AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            // long sec = TimeHelper.ClientNow() / 1000 % 15;
            // if (sec >= 10)
            // {
            //     return 0;
            // }
            
            Scene currentScene = aiComponent.DomainScene();
            var target = CreatureHelper.GetRole(currentScene);
            
            if (target == null)
            {
                return 1;
            }

            var creature = aiComponent.GetParent<Creature>();

            if (TSVector.Distance(target.Position, creature.Position) < ConstValue.AtkRange)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Scene currentScene = aiComponent.DomainScene();


            var creature = aiComponent.GetParent<Creature>();
            
            creature.MoveStop();
            
            
            // Log.Debug("开始攻击");
            
            
            var target = CreatureHelper.GetRole(currentScene);


            var targetInstanceId = target.InstanceId;

            for (int i = 0; i < 100000; ++i)
            {
                if (targetInstanceId != target.InstanceId)
                {
                    continue;
                }
                
                // Log.Debug($"攻击: {i}次");

                // 因为协程可能被中断，任何协程都要传入cancellationToken，判断如果是中断则要返回
                
                await TimerComponent.Instance.WaitAsync(1000, cancellationToken);

                if (creature.IsDisposed)
                {
                    return;
                }
                
                creature.TestSpell2(target);
                
                if (cancellationToken.IsCancel())
                {
                    return;
                }
                
                if (target == null)
                {
                    return;
                }

            }
        }
    }
}