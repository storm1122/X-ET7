using System.Collections.Generic;
using TrueSync;
using Unity.Mathematics;

namespace ET.Client
{

    [ObjectSystem]
    public class CreatureAwakeSystem: AwakeSystem<Creature, int>
    {
        protected override void Awake(Creature self, int configId)
        {
            self.ConfigId = configId;
            
            self.CreatureType = self.Config.Type;

            var attrComponent = self.AddComponent<AttrComponent>();
            foreach (var attr in self.Config.Attrs)
            {
                int bas = (int)attr.Key * 10 + 1;
                
                attrComponent.Set(bas,attr.Value);
            }

            attrComponent[AttrType.Hp] = attrComponent[AttrType.MaxHp];

            if (attrComponent[AttrType.MoveSpeed] > 0)
            {
                self.AddComponent<MoveComponent>();
            }

        }
    }

    [ObjectSystem]
    public class CreatureDestorySystem: DestroySystem<Creature>
    {
        protected override void Destroy(Creature self)
        {
        }
    }

    public static class CreatureSystem
    {
        public static AttrComponent GetAttr(this Creature self)
        {
            return self.GetComponent<AttrComponent>();
        }

        public static void TakeDamage(this Creature self, long dmg)
        {
            var attr = self.GetComponent<AttrComponent>();

            var hp = attr[AttrType.Hp];

            var minusHp = dmg;

            attr[AttrType.Hp] = math.max(0, hp -= minusHp);

            if (attr[AttrType.Hp] <= 0)
            {
                self.Dead();
            }
        }

        public static void Dead(this Creature self)
        {
            self.GetParent<CreatureComponent>().CreatureDead(self);
        }

        public static void TestSpell1(this Creature self)
        {
            var enemys = CreatureHelper.GetCreature(self.DomainScene(), Camp.B);

            foreach (var creature in enemys)
            {
                // creature.TakeDamage(self.GetComponent<AttrComponent>().GetAsLong(AttrType.Atk));

                creature.TakeDamage(99999);
            }

        }

        public static void Move(this Creature self, FP h, FP v)
        {
            TSVector targetPos = self.Position + new TSVector(h, 0, v);
            
            List<TSVector> list = new List<TSVector>();
            list.Add(self.Position);
            list.Add(targetPos);
            self.GetComponent<MoveComponent>().MoveToAsync(list, self.GetAttr().GetAsLong(AttrType.MoveSpeed)).Coroutine();
        }

        public static float ToFloat(this FP self)
        {
            float val = (float)self;
            return val;
        }
        
        public static void Set(this TSVector self, float3 val)
        {
            self = new TSVector(val.x, val.y, val.z);
        }

        public static void Set(this TSQuaternion self, quaternion val)
        {
            self = new TSQuaternion(val.value.x, val.value.y, val.value.z, val.value.w);
        }
        
        public static float3 ToFloat3(this TSVector self)
        {
            var val = new float3((float)self.x, (float)self.y, (float)self.z);
            return val;
        }
        public static quaternion ToQuaternion(this TSQuaternion self)
        {
            var val = new quaternion((float)self.x, (float)self.y, (float)self.z, (float)self.w);
            return val;
        }
        
    }
    
    
}