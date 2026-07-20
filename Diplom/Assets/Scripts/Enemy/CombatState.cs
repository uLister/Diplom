using UnityEngine;

namespace Enemy
{
    public class CombatState : BaseState
    {
        private EnemyAI enemy;

        public CombatState(EnemyAI enemyAI)
        {
            this.enemy = enemyAI;
        }

        public override void Enter()
        {
            Debug.Log("Вошел в состояние: Бой");
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
            Debug.Log("Вышел из состояния: Бой");
        }
    }
}