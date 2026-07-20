using UnityEngine;

namespace Enemy
{
    public class ScoutAI : MonoBehaviour
    {
        private StateMachine stateMachine;

        private MovementState movementState;
        private ScoutBlindState blindState;

        void Start()
        {
            stateMachine = new StateMachine();
            movementState = new MovementState();
            blindState = new ScoutBlindState();

            // Настройка правил перехода
            stateMachine.AddTransition(movementState, EnemySignal.PlayerSpotted, blindState);
            stateMachine.AddTransition(blindState, EnemySignal.PlayerLost, movementState);

            stateMachine.Initialize(movementState);
        }

        void Update()
        {
            stateMachine.Update();
            CheckVision();
        }

        private void CheckVision()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.SendSignal(EnemySignal.PlayerSpotted);
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                stateMachine.SendSignal(EnemySignal.PlayerLost);
            }
        }
    }
}