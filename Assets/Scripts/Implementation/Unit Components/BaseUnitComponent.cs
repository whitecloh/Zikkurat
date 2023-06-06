namespace Game.Entities.Unit
{
    public abstract class BaseUnitComponent
    {
        protected IUnit Unit { get; private set; }


        public BaseUnitComponent(IUnit unit)
        {
            this.Unit = unit;
        }
    }
}