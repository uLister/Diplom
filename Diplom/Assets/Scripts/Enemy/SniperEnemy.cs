using UnityEngine;

namespace Enemy
{
    public class Sniper : BaseEnemy
    {
        private float _health = 100f;

        public override void MoveToPoint(Vector3 targetPoint)
        {
            base.MoveToPoint(targetPoint);
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;
            
            if (_health < 30f)
            {
                RequestCover();
            }
        }
    }
}