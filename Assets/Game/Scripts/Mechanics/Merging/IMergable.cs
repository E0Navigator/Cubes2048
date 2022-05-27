namespace Game.Mechanics.Merging
{
    public interface IMergable<TMergable>
    {
        public bool CanMerge(TMergable mergable);
    }
}