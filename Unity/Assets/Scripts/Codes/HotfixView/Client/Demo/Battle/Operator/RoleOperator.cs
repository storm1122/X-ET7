using UnityEngine;

namespace ET.Client
{
  
    
    public class ViewComponentUpdateSystem: UpdateSystem<CreatureViewComponent>
    {
        protected override void Update(CreatureViewComponent self)
        {
            if (Input.GetKeyUp(KeyCode.Q))
            {
                CreatureHelper.GetCastle(self.DomainScene()).TestSpell1();
            }
        }
    }
    
    public class RoleOperator: UpdateSystem<CreatureViewComponent>
    {
        protected override void Update(CreatureViewComponent self)
        {
        
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            if (h != 0 || v != 0)
            {
                self.Idx++;

                if (self.Idx < 10)
                {
                    return;
                }

                self.Idx = 0;
                
                var role = CreatureHelper.GetRole(self.DomainScene());

                role.Move(h, v);
                // Log.Console($"h:{h} , v:{v}");

            }

        }
    }
}