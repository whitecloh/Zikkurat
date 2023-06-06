namespace Game.Entities.Unit
{
    public interface IUnitState
    {
        //TODO: State changed event
        event System.Action StateChanged;

        UnitActionState ActionState { get; set; }

        int Health { get; set; }

        bool LockPosition { get; set; }
        bool LockDirection { get; set; }
    }
}