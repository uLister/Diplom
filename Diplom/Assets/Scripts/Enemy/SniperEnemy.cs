using UnityEngine;

namespace Enemy
{
    public class Sniper : BaseEnemy
    {
        //private float _health = 100f;

        public override void MoveToPoint(Vector3 targetPoint)
        {
            base.MoveToPoint(targetPoint);
        }

        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);
            
            if (_currentHealth > 0 && _currentHealth < 30f)
            {
                RequestCover();
            }
        }
    }
}