using System;
using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(AttrWatcherComponent))]
    public static class AttrWatcherComponentSystem
    {
        [ObjectSystem]
        public class AttrWatcherComponentAwakeSystem : AwakeSystem<AttrWatcherComponent>
        {
            protected override void Awake(AttrWatcherComponent self)
            {
                AttrWatcherComponent.Instance = self;
                self.Init();
            }
        }

	
        public class AttrWatcherComponentLoadSystem : LoadSystem<AttrWatcherComponent>
        {
            protected override void Load(AttrWatcherComponent self)
            {
                self.Init();
            }
        }

        private static void Init(this AttrWatcherComponent self)
        {
            self.allWatchers = new Dictionary<int, List<AttrWatcherInfo>>();

            HashSet<Type> types = EventSystem.Instance.GetTypes(typeof(AttrWatcherAttribute));
            foreach (Type type in types)
            {
                object[] attrs = type.GetCustomAttributes(typeof(AttrWatcherAttribute), false);

                foreach (object attr in attrs)
                {
                    AttrWatcherAttribute attrWatcherAttribute = (AttrWatcherAttribute)attr;
                    IAttrWatcher obj = (IAttrWatcher)Activator.CreateInstance(type);
                    AttrWatcherInfo attrWatcherInfo = new AttrWatcherInfo(attrWatcherAttribute.SceneType, obj);
                    if (!self.allWatchers.ContainsKey(attrWatcherAttribute.AttrType))
                    {
                        self.allWatchers.Add(attrWatcherAttribute.AttrType, new List<AttrWatcherInfo>());
                    }
                    self.allWatchers[attrWatcherAttribute.AttrType].Add(attrWatcherInfo);
                }
            }
        }

        public static void Run(this AttrWatcherComponent self, Creature creature, AttrChange args)
        {
            List<AttrWatcherInfo> list;
            if (!self.allWatchers.TryGetValue(args.AttrType, out list))
            {
                return;
            }

            SceneType creatureDomainSceneType = creature.Domain.SceneType;
            foreach (AttrWatcherInfo attrWatcher in list)
            {
                if (!attrWatcher.SceneType.HasSameFlag(creatureDomainSceneType))
                {
                    continue;
                }
                attrWatcher.IAttrWatcher.Run(creature, args);
            }
        }
    }

    public class AttrWatcherInfo
    {
        public SceneType SceneType { get; }
        public IAttrWatcher IAttrWatcher { get; }

        public AttrWatcherInfo(SceneType sceneType, IAttrWatcher attrWatcher)
        {
            this.SceneType = sceneType;
            this.IAttrWatcher = attrWatcher;
        }
    }
    
    
    /// <summary>
    /// 监视数值变化组件,分发监听
    /// </summary>
    [ComponentOf(typeof(Scene))]
    public class AttrWatcherComponent : Entity, IAwake, ILoad
    {
        public static AttrWatcherComponent Instance { get; set; }
		
        public Dictionary<int, List<AttrWatcherInfo>> allWatchers;
    }
}