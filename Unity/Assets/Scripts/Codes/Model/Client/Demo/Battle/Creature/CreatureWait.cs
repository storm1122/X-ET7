namespace ET.Client
{
    public struct Wait_KillAllCampB: IWaitType
    {
        public int Error
        {
            get;
            set;
        }
    }
    
    //击杀守关boss
    public struct Wait_KillGuard: IWaitType
    {
        public int Error
        {
            get;
            set;
        }
    }
}