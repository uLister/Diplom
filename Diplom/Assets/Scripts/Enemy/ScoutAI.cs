// ScoutAI.cs
using UnityEngine;

namespace Enemy
{
    public class ScoutAI : MonoBehaviour
    {
        private SignalBus signalBus;
        private StateMachine stateMachine;

        private MovementState movementState;
        private ScoutBlindState blindState;

        void Start()
        {
            signalBus = new SignalBus();

            stateMachine = new StateMachine(signalBus);
            
            movementState = new MovementState();
            blindState = new ScoutBlindState();

            stateMachine.AddTransition<PlayerSpottedSignal>(movementState, blindState);
            stateMachine.AddTransition<PlayerLostSignal>(blindState, movementState);

            stateMachine.Initialize(movementState);
        }

        void Update()
        {
            stateMachine.Tick(); //  LogicUpdate текущего состояния
            CheckVision();       // зрение
        }

        private void CheckVision()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                signalBus.Fire(new PlayerSpottedSignal());
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                signalBus.Fire(new PlayerLostSignal());
            }
        }
    }
}