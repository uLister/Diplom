using System;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3.5f;
    [SerializeField] private int _maxHealth = 100;

    private int _currentHealth;

    public event Action OnDeath;

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void MoveTowards(Vector3 destination)
    {
        Vector3 direction = (destination - transform.position).normalized;
        transform.position += direction * _moveSpeed * Time.deltaTime;
    }

    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}