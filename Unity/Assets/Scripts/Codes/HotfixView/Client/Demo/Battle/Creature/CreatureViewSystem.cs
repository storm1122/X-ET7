using Cinemachine;
using ET.Client.BattleEvent;
using UnityEngine;

namespace ET.Client
{
    [ObjectSystem]
    public class CreatureViewAwakeSystem: AwakeSystem<CreatureView>
    {
        protected override void Awake(CreatureView self)
        {
        }
    }

    [ObjectSystem]
    public class CreatureViewDestorySystem: DestroySystem<CreatureView>
    {
        protected override void Destroy(CreatureView self)
        { 
            if (self.GameObject != null)
            {
                UnityEngine.Object.DestroyImmediate(self.GameObject);
                
                self.GameObject = null;
            }
        }
    }
    [FriendOfAttribute(typeof(ET.Client.CreatureView))]
    public static class CreatureViewSystem
    {
        public static void OnCreate(this CreatureView self, Creature data)
        {
            self.Data = data;

            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);

            go.transform.position = new Vector3((float)data.Position.x, (float)data.Position.y, (float)data.Position.z);

            self.GameObject = go;

            if (data.Config.Type == CreatureType.Role)
            {
                go.name = "Role";

                var vcamObj = GameObject.Find("CM vcam1");

                CinemachineVirtualCameraBase vcam = vcamObj.GetComponent<CinemachineVirtualCameraBase>();

                vcam.Follow = go.transform;
            }
        }

        public static void OnRemove(this CreatureView self, Creature data)
        {
            self.Dispose();
        }
        
        public static void OnChangePos(this CreatureView self, Creature data)
        {
            if (self.GameObject != null)
            {
                self.GameObject.transform.position = new Vector3((float)self.Data.Position.x, (float)self.Data.Position.y, (float)self.Data.Position.z);
            }
        }
        
        public static void OnChangeRotation(this CreatureView self, Creature data)
        {
            if (self.GameObject != null)
            {
                var r = self.Data.Rotation;
                self.GameObject.transform.rotation.Set((float)r.x, (float)r.y, (float)r.z, (float)r.w);
            }
        }

    }


}