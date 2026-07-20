using UnityEngine;

namespace Enemy
{
    public class ScoutBlindState : BaseState
    {
        public override void Enter()
        {
            Debug.Log("Скаут: Запуск протокола ослепления!");
        }

        public override void Update()
        {
            // Логика работы вспышки
        }

        public override void Exit()
        {
            Debug.Log("Скаут: Прекращаю ослепление.");
        }
    }
}