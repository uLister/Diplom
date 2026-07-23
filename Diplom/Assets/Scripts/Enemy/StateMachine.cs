// StateMachine.cs
using System;
using Zenject;

namespace Enemy
{
    public class StateMachine : IInitializable, ITickable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly MovementState _movementState;
        private readonly ScoutBlindState _blindState;

        private BaseState _currentState;

        public StateMachine(SignalBus signalBus, MovementState movement, ScoutBlindState blind)
        {
            _signalBus = signalBus;
            _movementState = movement;
            _blindState = blind;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<PlayerSpottedSignal>(OnPlayerSpotted);
            _signalBus.Subscribe<PlayerLostSignal>(OnPlayerLost);

            ChangeState(_movementState);
        }

        public void Tick()
        {
            _currentState?.LogicUpdate();
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<PlayerSpottedSignal>(OnPlayerSpotted);
            _signalBus.Unsubscribe<PlayerLostSignal>(OnPlayerLost);
        }

        private void OnPlayerSpotted() => ChangeState(_blindState);
        
        private void OnPlayerLost() => ChangeState(_movementState);

        private void ChangeState(BaseState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }
    }
}