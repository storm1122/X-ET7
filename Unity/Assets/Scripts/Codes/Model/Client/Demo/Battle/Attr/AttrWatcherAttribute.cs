using System;

namespace ET.Client
{
	[AttributeUsage(AttributeTargets.Class)]
	public class AttrWatcherAttribute : BaseAttribute
	{
		public SceneType SceneType { get; }
		
		public int AttrType { get; }

		public AttrWatcherAttribute(SceneType sceneType, int type)
		{
			this.SceneType = sceneType;
			this.AttrType = type;
		}
	}
}