// ScoutBlindState.cs
using UnityEngine;

namespace Enemy
{
    public class ScoutBlindState : BaseState
    {
        public override void Enter()
        {
            Debug.Log("ослепление");
        }

        public override void LogicUpdate()
        {
            
        }

        public override void Exit()
        {
            Debug.Log("выход из ослепление");
        }
    }
}