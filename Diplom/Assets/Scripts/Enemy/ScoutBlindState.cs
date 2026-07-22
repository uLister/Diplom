// ScoutBlindState.cs
using UnityEngine;

namespace Enemy
{
    public class ScoutBlindState : BaseState
    {
        public override void Enter() => Debug.Log("Вспышка: Старт");
        public override void LogicUpdate() { /* ослепление */ }
        public override void Exit() => Debug.Log("Вспышка: Стоп");
    }
}