//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;

namespace ET
{
   
[Config]
public partial class SpawnConfigCategory: ConfigSingleton<SpawnConfigCategory>
{
    private readonly Dictionary<int, SpawnConfig> _dataMap;
    private readonly List<SpawnConfig> _dataList;
    
    public SpawnConfigCategory(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, SpawnConfig>();
        _dataList = new List<SpawnConfig>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            SpawnConfig _v;
            _v = SpawnConfig.DeserializeSpawnConfig(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }
    
    public bool Contain(int id)
    {
        return _dataMap.ContainsKey(id);
    }

    public Dictionary<int, SpawnConfig> GetAll()
    {
        return _dataMap;
    }
    
    public List<SpawnConfig> DataList => _dataList;

    public SpawnConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public SpawnConfig Get(int key) => _dataMap[key];
    public SpawnConfig this[int key] => _dataMap[key];

    public override void Resolve(Dictionary<string, IConfigSingleton> _tables)
    {
        foreach(var v in _dataList)
        {
            v.Resolve(_tables);
        }
        PostResolve();
    }

    public override void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var v in _dataList)
        {
            v.TranslateText(translator);
        }
    }
    
    public override void TrimExcess()
    {
        _dataMap.TrimExcess();
        _dataList.TrimExcess();
    }
    
    
    public override string ConfigName()
    {
        return typeof(SpawnConfig).Name;
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}