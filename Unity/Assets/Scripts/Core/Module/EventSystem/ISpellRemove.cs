using System;

namespace ET
{
    public interface ISpellRemove
    {
    }
	
    public interface ISpellRemoveSystem: ISystemType
    {
        void Run(Entity o);
    }

    [ObjectSystem]
    public abstract class SpellRemoveSystem<T> : ISpellRemoveSystem where T: Entity, ISpellRemove
    {
        void ISpellRemoveSystem.Run(Entity o)
        {
            this.SpellRemove((T)o);
        }

        Type ISystemType.SystemType()
        {
            return typeof(ISpellRemoveSystem);
        }

        int ISystemType.GetInstanceQueueIndex()
        {
            return InstanceQueueIndex.SpellRemove;
        }

        Type ISystemType.Type()
        {
            return typeof(T);
        }

        protected abstract void SpellRemove(T self);
    }
}