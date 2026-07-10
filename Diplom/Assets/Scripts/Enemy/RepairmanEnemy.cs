using UnityEngine;

namespace Enemy
{
    public class Repairman : BaseEnemy
    {
        [Header("Настройки ремонта")]
        [SerializeField] private float _healPower = 50f; 

        public override void MoveToPoint(Vector3 targetPoint)
        {
            base.MoveToPoint(targetPoint);
        }

        public void HealTarget(BaseEnemy target)
        {
            if (target == null) return;

            target.ReceiveHealing(_healPower);
            
            Debug.Log($"Ремонтник починил объект {target.gameObject.name} на {_healPower} единиц.");
        }
    }
}