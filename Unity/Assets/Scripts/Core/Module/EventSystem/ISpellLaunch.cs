using System;

namespace ET
{
    public interface ISpellLaunch
    {
    }
	
    public interface ISpellLaunchSystem: ISystemType
    {
        void Run(Entity o);
    }

    [ObjectSystem]
    public abstract class SpellLaunchSystem<T> : ISpellLaunchSystem where T: Entity, ISpellLaunch
    {
        void ISpellLaunchSystem.Run(Entity o)
        {
            this.SpellLaunch((T)o);
        }

        Type ISystemType.SystemType()
        {
            return typeof(ISpellLaunchSystem);
        }

        int ISystemType.GetInstanceQueueIndex()
        {
            return InstanceQueueIndex.SpellLaunch;
        }

        Type ISystemType.Type()
        {
            return typeof(T);
        }

        protected abstract void SpellLaunch(T self);
    }
}