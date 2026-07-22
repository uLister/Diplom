// MovementState.cs
using UnityEngine;

namespace Enemy
{
    public class MovementState : BaseState
    {
        public override void Enter() => Debug.Log("Движение: Старт");
        public override void LogicUpdate() { /* NavMeshAgent */ }
        public override void Exit() => Debug.Log("Движение: Стоп");
    }
}