using System.Collections;
using System.Collections.Generic;
using System.IO;
using TrueSync;
using UnityEngine;
using UnityEngine.Analytics;
namespace ET
{
    public class BattleDataJson
    {
        public FP Width;
        public FP Height;
        public List<TSVector2> Path;
    }
  
    
    public class BattleMapScene : MonoBehaviour
    {

        public Transform Map;
        public Transform Path;


        public void Gen()
        {

            var battleData = new BattleDataJson();
            
            var localScale = this.Map.localScale;
            battleData.Width = localScale.x;
            battleData.Height = localScale.z;

            battleData.Path = new List<TSVector2>();

            for (int i = 0; i < this.Path.childCount; i++)
            {
                var child = this.Path.GetChild(i);
                var position = child.transform.position;
                battleData.Path.Add(new TSVector2(position.x, position.z));
            }

            var json = JsonUtility.ToJson(battleData);

            var savePath = Application.dataPath + "/Bundles/Config/GameConfig/BattleData.json";
            
            if (!File.Exists(savePath))
            {
                File.Create(savePath);
            }
            
            File.WriteAllText(savePath, json);
            
            Debug.Log("保存成功");

        }

        
        
    }
}
