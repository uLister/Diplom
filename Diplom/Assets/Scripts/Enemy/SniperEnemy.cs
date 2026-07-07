using System;
using UnityEngine;

namespace Enemy
{
    public class SniperEnemy : BaseEnemy
    {
        public event Action<BaseEnemy> OnCoverRequested;
        public event Action<BaseEnemy> OnRepairRequested;

        public void FireLaser(Vector3 targetPosition)
        {
            Debug.Log("Выстрел снайпер");
        }

        public void PerformDash(Vector3 dodgeDirection)
        {
            Debug.Log("Уворот снайпер");
        }

        public void RequestCover()
        {
            Debug.Log("Запрос прикрытия снайпер");
            OnCoverRequested?.Invoke(this);
        }

        public void RequestRepair()
        {
            Debug.Log("Запроса ремонта снайпер");
            OnRepairRequested?.Invoke(this);
        }
    }
}