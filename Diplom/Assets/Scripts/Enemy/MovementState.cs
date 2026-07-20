using UnityEngine;

namespace Enemy
{
    public class MovementState : BaseState
    {
        public override void Enter()
        {
            Debug.Log("Движение начато. Ищу случайную точку.");
        }

        public override void Update()
        {
            // проверка  навмеш
        }

        public override void Exit()
        {
            Debug.Log("Движение остановлено.");
        }
    }
}