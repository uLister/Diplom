// StateMachine.cs
using System;
using System.Collections.Generic;

namespace Enemy
{
    public class StateMachine
    {
        public BaseState CurrentState { get; private set; }
        
        private SignalBus signalBus;
        
        private HashSet<Type> subscribedSignals = new HashSet<Type>();

        private Dictionary<(BaseState, Type), BaseState> transitions = new Dictionary<(BaseState, Type), BaseState>();

        public StateMachine(SignalBus bus)
        {
            signalBus = bus;
        }

        public void Initialize(BaseState startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }

        public void AddTransition<TSignal>(BaseState fromState, BaseState toState)
        {
            Type signalType = typeof(TSignal);
            transitions.Add((fromState, signalType), toState);

            if (!subscribedSignals.Contains(signalType))
            {
                signalBus.Subscribe<TSignal>(OnSignalReceived);
                subscribedSignals.Add(signalType);
            }
        }

        private void OnSignalReceived<TSignal>(TSignal signal)
        {
            Type signalType = typeof(TSignal);

            if (transitions.TryGetValue((CurrentState, signalType), out BaseState nextState))
            {
                ChangeState(nextState);
            }
        }

        private void ChangeState(BaseState newState)
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }

        public void Tick()
        {
            CurrentState?.LogicUpdate();
        }
    }
}