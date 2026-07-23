// MovementState.cs
using UnityEngine;

namespace Enemy
{
    public class MovementState : BaseState
    {
        public override void Enter()
        {
            Debug.Log("начало движения.");
        }

        public override void LogicUpdate()
        {
            //NavMeshAgent
            Debug.Log("иду.");
        }

        public override void Exit()
        {
            Debug.Log("конец движения.");
        }
    }
}