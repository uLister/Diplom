using System;
using UnityEngine;

namespace Enemy
{
    public class RepairmanEnemy : BaseEnemy
    {
        public event Action<BaseEnemy> OnCoverRequested;

        public void HealTarget(BaseEnemy targetEnemy)
        {
            Debug.Log("Ремон");
            targetEnemy.TakeDamage(-20); 
        }

        public void RequestCover()
        {
            Debug.Log("Запроса прикрытия ремонтник");
            OnCoverRequested?.Invoke(this);
        }
    }
}