using Game.Mechanics.Merging;
using Zenject;

namespace Game
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        public override void InstallBindings()
        {
            MergablesInstaller.Install(Container);
        }
    }
}