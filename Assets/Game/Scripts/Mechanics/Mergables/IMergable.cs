namespace Game.Mechanics.Mergables
{
    public interface IMergable<TMergable>
    {
        public bool CanMerge(TMergable mergable);
    }
}