// ScoutInstaller.cs
using Zenject;

namespace Enemy
{
    public class ScoutInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<PlayerSpottedSignal>();
            Container.DeclareSignal<PlayerLostSignal>();

            Container.Bind<MovementState>().AsSingle();
            Container.Bind<ScoutBlindState>().AsSingle();

            Container.BindInterfacesAndSelfTo<StateMachine>().AsSingle();
        }
    }
}