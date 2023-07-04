using Cinemachine;
using UnityEngine;

namespace ET.Client
{
    [ObjectSystem]
    public class DropViewAwakeSystem: AwakeSystem<DropView>
    {
        protected override void Awake(DropView self)
        {
        }
    }

    [ObjectSystem]
    public class DropViewDestorySystem: DestroySystem<DropView>
    {
        protected override void Destroy(DropView self)
        {   
            if (self.GameObject != null)
            {
                UnityEngine.Object.DestroyImmediate(self.GameObject);
                
                self.GameObject = null;
            }
        }
    }
    [FriendOfAttribute(typeof(ET.Client.DropView))]
    public static class DropViewSystem
    {
        public static void OnCreate(this DropView self, Drop data)
        {
            self.Data = data;

            var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);

            go.transform.position = new Vector3((float)data.Position.x, (float)data.Position.y, (float)data.Position.z);

            go.transform.localScale = Vector3.one * 0.2f;

            self.GameObject = go;

        }
        public static void OnRemove(this DropView self)
        {
            self.Dispose();
        }

    }
}