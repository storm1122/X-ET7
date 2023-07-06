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

public sealed partial class CreatureConfig: Bright.Config.BeanBase
{
    public CreatureConfig(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Type = (CreatureType)_buf.ReadInt();
        Name = _buf.ReadString();
        {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);Attrs = new System.Collections.Generic.Dictionary<EnAttr, int>(n0 * 3 / 2);for(var i0 = 0 ; i0 < n0 ; i0++) { EnAttr _k0;  _k0 = (EnAttr)_buf.ReadInt(); int _v0;  _v0 = _buf.ReadInt();     Attrs.Add(_k0, _v0);}}
        DropScript = _buf.ReadInt();
        {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);DropArg = new System.Collections.Generic.List<int>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { int _e0;  _e0 = _buf.ReadInt(); DropArg.Add(_e0);}}
        {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);PowerSpeed = new System.Collections.Generic.List<int>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { int _e0;  _e0 = _buf.ReadInt(); PowerSpeed.Add(_e0);}}
        {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);PowerSpeedVal = new System.Collections.Generic.List<int>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { int _e0;  _e0 = _buf.ReadInt(); PowerSpeedVal.Add(_e0);}}
        {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);SpellIds = new System.Collections.Generic.List<int>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { int _e0;  _e0 = _buf.ReadInt(); SpellIds.Add(_e0);}}
        PostInit();
    }

    public static CreatureConfig DeserializeCreatureConfig(ByteBuf _buf)
    {
        return new CreatureConfig(_buf);
    }

    public int Id { get; private set; }
    /// <summary>
    /// 类型
    /// </summary>
    public CreatureType Type { get; private set; }
    /// <summary>
    /// 名字
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// 属性
    /// </summary>
    public System.Collections.Generic.Dictionary<EnAttr, int> Attrs { get; private set; }
    /// <summary>
    /// 掉落脚本（暂时只有1）
    /// </summary>
    public int DropScript { get; private set; }
    /// <summary>
    /// 掉落参数(掉落id,概率)
    /// </summary>
    public System.Collections.Generic.List<int> DropArg { get; private set; }
    /// <summary>
    /// 能量移速加成档位
    /// </summary>
    public System.Collections.Generic.List<int> PowerSpeed { get; private set; }
    /// <summary>
    /// 能量移速加成数值
    /// </summary>
    public System.Collections.Generic.List<int> PowerSpeedVal { get; private set; }
    public System.Collections.Generic.List<int> SpellIds { get; private set; }

    public const int __ID__ = -714052479;
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
        + "Type:" + Type + ","
        + "Name:" + Name + ","
        + "Attrs:" + Bright.Common.StringUtil.CollectionToString(Attrs) + ","
        + "DropScript:" + DropScript + ","
        + "DropArg:" + Bright.Common.StringUtil.CollectionToString(DropArg) + ","
        + "PowerSpeed:" + Bright.Common.StringUtil.CollectionToString(PowerSpeed) + ","
        + "PowerSpeedVal:" + Bright.Common.StringUtil.CollectionToString(PowerSpeedVal) + ","
        + "SpellIds:" + Bright.Common.StringUtil.CollectionToString(SpellIds) + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}