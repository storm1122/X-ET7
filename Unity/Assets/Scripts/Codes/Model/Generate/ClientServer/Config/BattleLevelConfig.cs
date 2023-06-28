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

public sealed partial class BattleLevelConfig: Bright.Config.BeanBase
{
    public BattleLevelConfig(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Name = _buf.ReadString();
        {int __n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);PosXList = new int[__n0];for(var __index0 = 0 ; __index0 < __n0 ; __index0++) { int __e0;__e0 = _buf.ReadInt(); PosXList[__index0] = __e0;}}
        {int __n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);PosYList = new int[__n0];for(var __index0 = 0 ; __index0 < __n0 ; __index0++) { int __e0;__e0 = _buf.ReadInt(); PosYList[__index0] = __e0;}}
        {int __n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);PosZList = new int[__n0];for(var __index0 = 0 ; __index0 < __n0 ; __index0++) { int __e0;__e0 = _buf.ReadInt(); PosZList[__index0] = __e0;}}
        {int __n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);SpawnInfos = new System.Collections.Generic.List<int>[__n0];for(var __index0 = 0 ; __index0 < __n0 ; __index0++) { System.Collections.Generic.List<int> __e0;{int n1 = System.Math.Min(_buf.ReadSize(), _buf.Size);__e0 = new System.Collections.Generic.List<int>(n1);for(var i1 = 0 ; i1 < n1 ; i1++) { int _e1;  _e1 = _buf.ReadInt(); __e0.Add(_e1);}} SpawnInfos[__index0] = __e0;}}
        PostInit();
    }

    public static BattleLevelConfig DeserializeBattleLevelConfig(ByteBuf _buf)
    {
        return new BattleLevelConfig(_buf);
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    /// <summary>
    /// X坐标
    /// </summary>
    public int[] PosXList { get; private set; }
    /// <summary>
    /// Y坐标
    /// </summary>
    public int[] PosYList { get; private set; }
    /// <summary>
    /// Z坐标
    /// </summary>
    public int[] PosZList { get; private set; }
    /// <summary>
    /// SpawnConfig中的Id
    /// </summary>
    public System.Collections.Generic.List<int>[] SpawnInfos { get; private set; }

    public const int __ID__ = -1369519122;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, IConfigSingleton> _tables)
    {
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "Name:" + Name + ","
        + "PosXList:" + Bright.Common.StringUtil.CollectionToString(PosXList) + ","
        + "PosYList:" + Bright.Common.StringUtil.CollectionToString(PosYList) + ","
        + "PosZList:" + Bright.Common.StringUtil.CollectionToString(PosZList) + ","
        + "SpawnInfos:" + Bright.Common.StringUtil.CollectionToString(SpawnInfos) + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}