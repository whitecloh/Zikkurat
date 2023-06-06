namespace Game.Plugins.Input
{
    public static class InputLocator
    {
        private static IInputProvider NullService { get; } = new NullInputProvider();
        public static IInputProvider Service { get; private set; } = NullService;


        public static void Provide(IInputProvider value)
        {
            Service = value != null ? value : NullService;
        }
    }
}