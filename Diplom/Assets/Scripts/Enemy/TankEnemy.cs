using System;
using UnityEngine;

namespace Enemy
{
    public class TankEnemy : BaseEnemy
    {
        public event Action<BaseEnemy> OnRepairRequested;

        public void ShootAt(Vector3 targetPosition)
        {
            Debug.Log("Выстрел танк");
        }

        public void ActivateShield()
        {
            Debug.Log("Щит танк");
        }

        public void PerformDash(Vector3 dashTarget)
        {
            Debug.Log("Рывок танк");
        }

        public void RequestRepair()
        {
            Debug.Log("Запроса ремонта танк");
            OnRepairRequested?.Invoke(this);
        }
    }
}