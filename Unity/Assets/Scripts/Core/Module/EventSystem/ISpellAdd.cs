using System;

namespace ET
{
    public interface ISpellAdd
    {
    }
	
    public interface ISpellAddSystem: ISystemType
    {
        void Run(Entity o);
    }

    [ObjectSystem]
    public abstract class SpellAddSystem<T> : ISpellAddSystem where T: Entity, ISpellAdd
    {
        void ISpellAddSystem.Run(Entity o)
        {
            this.SpellAdd((T)o);
        }

        Type ISystemType.SystemType()
        {
            return typeof(ISpellAddSystem);
        }

        int ISystemType.GetInstanceQueueIndex()
        {
            return InstanceQueueIndex.SpellAdd;
        }

        Type ISystemType.Type()
        {
            return typeof(T);
        }

        protected abstract void SpellAdd(T self);
    }
}