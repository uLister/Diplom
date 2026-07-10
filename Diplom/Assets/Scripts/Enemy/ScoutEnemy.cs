using UnityEngine;

namespace Enemy
{
    public class Scout : BaseEnemy
    {
        [Header("Настройки побега")]
        [SerializeField] private float _fleeDistance = 15f;

        public override void MoveToPoint(Vector3 targetPoint)
        {
            base.MoveToPoint(targetPoint);
        }

        public void OnSpottedByPlayer(Transform playerTransform)
        {
            BlindPlayer();
            FleeFromPlayer(playerTransform);
        }

        private void BlindPlayer()
        {
            Debug.Log($"Скаут {gameObject.name} Ослепление");
        }

        private void FleeFromPlayer(Transform playerTransform)
        {
            Vector3 directionAwayFromPlayer = (transform.position - playerTransform.position);
            
            Vector3 normalizedDirection = directionAwayFromPlayer.normalized;

            Vector3 targetFleePoint = transform.position + (normalizedDirection * _fleeDistance);

            MoveToPoint(targetFleePoint);
        }
    }
}