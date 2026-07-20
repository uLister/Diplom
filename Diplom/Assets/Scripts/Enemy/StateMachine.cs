using System.Collections.Generic;

namespace Enemy
{
    public class StateMachine
    {
        public BaseState CurrentState { get; private set; }

        private Dictionary<(BaseState, EnemySignal), BaseState> transitions = new Dictionary<(BaseState, EnemySignal), BaseState>();

        public void Initialize(BaseState startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }

        public void AddTransition(BaseState fromState, EnemySignal signal, BaseState toState)
        {
            transitions.Add((fromState, signal), toState);
        }

        public void SendSignal(EnemySignal signal)
        {
            if (transitions.TryGetValue((CurrentState, signal), out BaseState nextState))
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

        public void Update()
        {
            CurrentState?.Update();
        }
    }
}