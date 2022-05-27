
namespace Game.Mechanics.Merging
{
    public interface IMergingService<TMergable1, TMergable2, TResult>
        where TMergable1 : IMergable<TMergable2>
    {
        public TResult Merge(TMergable1 mergable1, TMergable2 mergable2);
    }
}