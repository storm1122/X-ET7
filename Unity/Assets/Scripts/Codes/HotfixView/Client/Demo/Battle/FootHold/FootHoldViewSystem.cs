using UnityEngine;

namespace ET.Client
{
    [ObjectSystem]
    public class FootHoldViewAwakeSystem: AwakeSystem<FootHoldView>
    {
        protected override void Awake(FootHoldView self)
        {
        }
    }

    [ObjectSystem]
    public class FootHoldViewDestorySystem: DestroySystem<FootHoldView>
    {
        protected override void Destroy(FootHoldView self)
        {    
            if (self.GameObject != null)
            {
                UnityEngine.Object.DestroyImmediate(self.GameObject);
                
                self.GameObject = null;
            }
        }
    }
    [FriendOfAttribute(typeof(ET.Client.FootHoldView))]
    public static class FootHoldViewSystem
    {
        public static void OnCreate(this FootHoldView self, FootHold data)
        {
            self.Data = data;

            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);

            go.transform.position = new Vector3((float)data.Pos.x, (float)data.Pos.y, (float)data.Pos.z);
            
            go.transform.localScale = Vector3.one * 3f;

            self.GameObject = go;

        }
        
        public static void OnRemove(this FootHoldView self)
        {
            self.Dispose();
        }
        
    }
}