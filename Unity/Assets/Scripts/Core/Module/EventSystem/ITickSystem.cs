using System;

namespace ET
{
	public interface ITick
	{
	}
	
	public interface ITickSystem: ISystemType
	{
		void Run(Entity o);
	}

	[ObjectSystem]
	public abstract class TickSystem<T> : ITickSystem where T: Entity, ITick
	{
		void ITickSystem.Run(Entity o)
		{
			this.Tick((T)o);
		}

		Type ISystemType.Type()
		{
			return typeof(T);
		}

		Type ISystemType.SystemType()
		{
			return typeof(ITickSystem);
		}

		int ISystemType.GetInstanceQueueIndex()
		{
			return InstanceQueueIndex.Tick;
		}

		protected abstract void Tick(T self);
	}
}
