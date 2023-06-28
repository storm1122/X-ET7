namespace ET.Client
{
    // 这个可弄个配置表生成
    public static class AttrType
    {
        public const int Max = 10000;
        public const int Hp = 10001;
        
        public const int MoveSpeed = (int)EnAttr.MoveSpeed;
        public const int SpeedBase = MoveSpeed * 10 + 1;
        public const int SpeedAdd = MoveSpeed * 10 + 2;
        public const int SpeedPct = MoveSpeed * 10 + 3;
        public const int SpeedFinalAdd = MoveSpeed * 10 + 4;
        public const int SpeedFinalPct = MoveSpeed * 10 + 5;

        public const int MaxHp = (int)EnAttr.MaxHp;
        public const int MaxHpBase = MaxHp * 10 + 1;
        public const int MaxHpAdd = MaxHp * 10 + 2;
        public const int MaxHpPct = MaxHp * 10 + 3;
        public const int MaxHpFinalAdd = MaxHp * 10 + 4;
        public const int MaxHpFinalPct = MaxHp * 10 + 5;
        
        public const int Atk = (int)EnAttr.Atk;
        public const int AtkBase = Atk * 10 + 1;
        public const int AtkAdd = Atk * 10 + 2;
        public const int AtkPct = Atk * 10 + 3;
        public const int AtkFinalAdd = Atk * 10 + 4;
        public const int AtkFinalPct = Atk * 10 + 5;
        
        public const int Radius = (int)EnAttr.Radius;
        public const int RadiusBase = Radius * 10 + 1;
        public const int RadiusAdd = Radius * 10 + 2;
        public const int RadiusPct = Radius * 10 + 3;
        public const int RadiusFinalAdd = Radius * 10 + 4;
        public const int RadiusFinalPct = Radius * 10 + 5;

    }
}