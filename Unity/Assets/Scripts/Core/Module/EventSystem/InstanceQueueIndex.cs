namespace ET
{
    public static class InstanceQueueIndex
    {
        public const int None = -1;
        public const int Update = 0;
        public const int LateUpdate = 1;
        public const int Load = 2;
        public const int Tick = 3;
        public const int SpellAdd = 4;
        public const int SpellLaunch = 5;
        public const int SpellRemove = 6;
        public const int Max = 7;
    }
}