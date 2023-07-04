using TrueSync;

namespace ET
{
    public static class ConstValue
    {
        public const string RouterHttpHost = "127.0.0.1";
        public const int RouterHttpPort = 30300;
        public const int SessionTimeoutTime = 30 * 1000;

        public const bool RobotBattleCase = true;

        public const string BattleSceneName = "Battle";
        public const string LobbySceneName = "Lobby";

        public const int BattleLevelConfigId = 1;
        public const int BattleLevelStartIdx = 0;
        public const int CastleCreatureId = 9001;
        public const int RoleCreatureId = 8001;

        public const float AtkRange = 2;
        public const float DropRange = 1;
        
        public const int SpawnMaxRadius = 30;
        public const int SpawnMinRadius = 20;
    }
}