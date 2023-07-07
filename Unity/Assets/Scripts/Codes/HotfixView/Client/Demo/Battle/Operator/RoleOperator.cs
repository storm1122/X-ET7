using UnityEngine;

namespace ET.Client
{
    [FriendOfAttribute(typeof(ET.Client.SpellComponent))]
    [FriendOfAttribute(typeof(ET.Client.Spell))]
    public class ViewComponentUpdateSystem : UpdateSystem<CreatureViewComponent>
    {
        protected override void Update(CreatureViewComponent self)
        {
            if (Input.GetKeyUp(KeyCode.Q))
            {
                CreatureHelper.GetCastle(self.DomainScene()).TestSpell1();
            }

            if (Input.GetKeyUp(KeyCode.R))
            {
                var role = CreatureHelper.GetCastle(self.DomainScene());

                var spellComponent = role.GetComponent<SpellComponent>();
                Log.Error("add spell 2 ");
                spellComponent.Add(2, role);
            }

            // var panelLogic = self.DomainScene().GetComponent<FUIComponent>()?.GetPanelLogic<DemoBattleInfo>();
            // if (panelLogic != null)
            // {
            //     var label = panelLogic.FUIDemoBattleInfo.txtDebug;
            //     label.text = "";
            //
            //     var enemys = CreatureHelper.GetCreature(self.DomainScene(), Camp.B);
            //
            //     if (enemys != null)
            //     {
            //         foreach (var enemy in enemys)
            //         {
            //             var spell = enemy.GetComponent<SpellComponent>().multiMap.GetOne(1003);
            //             if (spell != null)
            //             {
            //                 var str = $"cd:{spell.Cd} , nextCd:{spell.NextCd} , wait:{spell.NextCd - spell.Cd}\n";
            //                 label.text += str;
            //             }
            //         }
            //     }
            // }
          
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