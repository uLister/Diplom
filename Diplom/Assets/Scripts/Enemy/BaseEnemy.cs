using System;
using UnityEngine;

namespace Enemy
{
    public struct EnemyNeeds
    {
        public const int Cover = 0;  
        public const int Repair = 1; 
    }

    public abstract class BaseEnemy : MonoBehaviour
    {
        public event Action<int, int> OnEnemyNeeds;

        [Header("Базовые характеристики (BaseEnemy)")]
        [SerializeField] protected float _maxHealth = 100f;
        protected float _currentHealth;

        protected int _enemyInstanceId;

        protected virtual void Awake()
        {
            _enemyInstanceId = gameObject.GetInstanceID();
            
            _currentHealth = _maxHealth;
        }

        public virtual void MoveToPoint(Vector3 targetPoint)
        {
            
        }

        public virtual void ReceiveHealing(float amount)
        {
            _currentHealth += amount;
            
            _currentHealth = Mathf.Min(_currentHealth, _maxHealth);
        }

        protected void RequestCover()
        {
            OnEnemyNeeds?.Invoke(EnemyNeeds.Cover, _enemyInstanceId);
        }

        protected void RequestRepair()
        {
            OnEnemyNeeds?.Invoke(EnemyNeeds.Repair, _enemyInstanceId);
        }
    }
}