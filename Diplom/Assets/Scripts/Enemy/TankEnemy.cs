using System;
using UnityEngine;

namespace Enemy
{
    public class TankEnemy : BaseEnemy
    {
        public event Action<BaseEnemy> OnRepairRequested;

        public void ShootAt(Vector3 targetPosition)
        {
            Debug.Log("Выстрел");
        }

        public void ActivateShield()
        {
            Debug.Log("Щит");
        }

        public void PerformDash(Vector3 dashTarget)
        {
            Debug.Log("Рывок");
        }

        public void RequestRepair()
        {
            Debug.Log("Запроса ремонта");
            OnRepairRequested?.Invoke(this);
        }
    }
}