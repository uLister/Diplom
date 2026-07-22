using UnityEngine;

namespace Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        private SignalBus signalBus; // 1. Добавляем переменную для шины сигналов
        private StateMachine stateMachine;

        public PatrolState patrolState;
        public CombatState combatState;

        void Start()
        {
            // 2. Сначала физически создаем шину (почтовое отделение)
            signalBus = new SignalBus(); 

            // 3. Теперь создаем машину и отдаем ей эту шину (ошибка на 14 строке исчезнет)
            stateMachine = new StateMachine(signalBus);

            patrolState = new PatrolState(this);
            combatState = new CombatState(this);

            stateMachine.Initialize(patrolState);
        }

        void Update()
        {
            // 4. Машина состояний "тикает", а не обновляет логику сама (ошибка на 24 строке исчезнет)
            stateMachine.Tick();
        }

        public void SwitchState(BaseState newState)
        {
            // Обрати внимание: при архитектуре SignalBus ручное переключение (ChangeState) 
            // обычно делают приватным, чтобы состояния переключались ТОЛЬКО по сигналам.
            // Но пока можно оставить этот метод закомментированным, как у тебя.
            // stateMachine.ChangeState(newState); 
        }
    }
}