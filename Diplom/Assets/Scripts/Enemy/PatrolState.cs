using UnityEngine;

namespace Enemy
{
    public class PatrolState : BaseState
    {
        private EnemyAI enemy;

        public PatrolState(EnemyAI enemyAI)
        {
            this.enemy = enemyAI;
        }

        public override void Enter()
        {
            Debug.Log("патруль");
        }

        public override void Update()
        {
            bool playerDetected = CheckIfPlayerDetected();

            if (playerDetected)
            {
                enemy.SwitchState(enemy.combatState);
            }
        }

        public override void Exit()
        {
            Debug.Log("выход из патруля");
        }

        private bool CheckIfPlayerDetected()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }
}