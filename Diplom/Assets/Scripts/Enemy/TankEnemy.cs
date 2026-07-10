using UnityEngine;

namespace Enemy
{
    public class Tank : BaseEnemy
    {
        protected override void Awake()
        {
            _maxHealth = 500f; 
            
            base.Awake(); 
        }

        public override void MoveToPoint(Vector3 targetPoint)
        {
            base.MoveToPoint(targetPoint);
        }

        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);

            if (_currentHealth > 0 && _currentHealth < 100f)
            {
                RequestRepair();
            }
        }
    }
}