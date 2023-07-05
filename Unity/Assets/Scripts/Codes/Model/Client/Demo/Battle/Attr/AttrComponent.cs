using System.Collections.Generic;
using TrueSync;

namespace ET.Client
{
    [FriendOf(typeof (AttrComponent))]
    public static class AttrComponentSystem
    {
        public static FP GetAsFloat(this AttrComponent self, int attrType)
        {
            return (FP)self.GetByKey(attrType) / 10000;
        }

        public static int GetAsInt(this AttrComponent self, int attrType)
        {
            return (int)self.GetByKey(attrType);
        }

        public static long GetAsLong(this AttrComponent self, int attrType)
        {
            return self.GetByKey(attrType);
        }

        public static void Set(this AttrComponent self, int nt, FP value)
        {
            self[nt] = (long)(value * 10000);
        }

        public static void Set(this AttrComponent self, int nt, int value)
        {
            self[nt] = value;
        }

        public static void Set(this AttrComponent self, int nt, long value)
        {
            self[nt] = value;
        }

        public static void SetNoEvent(this AttrComponent self, int attrType, long value)
        {
            self.Insert(attrType, value, false);
        }

        public static void Insert(this AttrComponent self, int attrType, long value, bool isPublicEvent = true)
        {
            long oldValue = self.GetByKey(attrType);
            if (oldValue == value)
            {
                return;
            }

            self.AttrDic[attrType] = value;

            if (attrType >= AttrType.Max)
            {
                self.Update(attrType, isPublicEvent);
                return;
            }

            if (isPublicEvent)
            {
                EventSystem.Instance.Publish(self.DomainScene(),
                    new AttrChange() { Creature = self.GetParent<Creature>(), New = value, Old = oldValue, AttrType = attrType });
            }
        }

        public static long GetByKey(this AttrComponent self, int key)
        {
            long value = 0;
            self.AttrDic.TryGetValue(key, out value);
            return value;
        }

        public static void Update(this AttrComponent self, int attrType, bool isPublicEvent)
        {
            int final = (int)attrType / 10;
            int bas = final * 10 + 1;
            int add = final * 10 + 2;
            int pct = final * 10 + 3;
            int finalAdd = final * 10 + 4;
            int finalPct = final * 10 + 5;

            // 一个数值可能会多种情况影响，比如速度,加个buff可能增加速度绝对值100，也有些buff增加10%速度，所以一个值可以由5个值进行控制其最终结果
            // final = (((base + add) * (100 + pct) / 100) + finalAdd) * (100 + finalPct) / 100;
            long result = (long)(((self.GetByKey(bas) + self.GetByKey(add)) * (100 + self.GetAsFloat(pct)) / 100f + self.GetByKey(finalAdd)) *
                (100 + self.GetAsFloat(finalPct)) / 100f);
            self.Insert(final, result, isPublicEvent);
        }
    }
    
    public struct AttrChange
    {
        public Creature Creature;
        public int AttrType;
        public long Old;
        public long New;
    }

    [ComponentOf(typeof (Creature))]
    public class AttrComponent: Entity, IAwake, ITransfer
    {
        public Dictionary<int, long> AttrDic = new Dictionary<int, long>();

        public long this[int attrType]
        {
            get
            {
                return this.GetByKey(attrType);
            }
            set
            {
                this.Insert(attrType, value);
            }
        }
    }
    
    [Event(SceneType.All)]
    public class NumericChangeEvent_NotifyWatcher2: AEvent<Scene, AttrChange>
    {
        protected override async ETTask Run(Scene scene, AttrChange args)
        {
            AttrWatcherComponent.Instance.Run(args.Creature, args);
            await ETTask.CompletedTask;
        }
    }
}