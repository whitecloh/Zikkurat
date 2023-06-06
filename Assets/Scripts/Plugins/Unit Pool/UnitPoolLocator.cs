namespace Game.Plugins.UnitPool
{
    public static class UnitPoolLocator
    {
        private static IUnitPool NullService { get; } = new NullUnitPool();
        public static IUnitPool Service { get; private set; } = NullService;


        public static void Provide(IUnitPool value)
        {
            Service = value != null ? value : NullService;
        }
    }
}