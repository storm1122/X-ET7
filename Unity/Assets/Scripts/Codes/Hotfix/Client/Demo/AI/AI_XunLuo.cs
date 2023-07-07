using TrueSync;
using Unity.Mathematics;

namespace ET.Client
{
    public class AI_XunLuo: AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            long sec = TimeHelper.ClientNow() / 1000 % 15;
            // if (sec < 10)
            // {
            //     return 0;
            // }
            //
                
            Scene currentScene = aiComponent.DomainScene();
            var target = CreatureHelper.GetRole(currentScene);
            
            if (target == null)
            {
                return 1;
            }

            var creature = aiComponent.GetParent<Creature>();

            
            
            if (creature.Distance(target) > FP.Zero)
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

            var creatureComponent = currentScene.GetComponent<CreatureComponent>();

            if (creatureComponent == null)
            {
                return;
            }

            var creature = aiComponent.GetParent<Creature>();

            var target = CreatureHelper.GetRole(currentScene);
            
            // Log.Debug("开始巡逻");
            var targetInstanceId = target.InstanceId;

            while (true)
            {   
                
                if (targetInstanceId != target.InstanceId)
                {
                    continue;
                }
                
                // await creature.MoveToTarget(target);
                creature.MoveToTarget(target).Coroutine();
                
                await TimerComponent.Instance.WaitAsync(1000, cancellationToken);
                
                if (cancellationToken.IsCancel())
                {
                    return;
                }
            }
        }
    }
}