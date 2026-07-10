using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFOV : MonoBehaviour
{
    [Header("Настройки зрения")]
    [SerializeField] private float _viewRadius = 10f;
    [SerializeField, Range(0, 360)] private float _viewAngle = 90f;

    [Header("Фильтры слоев")]
    [SerializeField] private LayerMask _targetMask;   // Укажем здесь слой Enemy
    [SerializeField] private LayerMask _obstacleMask; // Укажем здесь слой Obstacle

    // Список, чтобы помнить, кого мы сейчас видим
    private List<EnemyVisibility> _visibleEnemies = new List<EnemyVisibility>();

    private void Start()
    {
        // Запускаем оптимизированный цикл проверки (не каждый кадр!)
        StartCoroutine(FindTargetsWithDelay(0.2f)); 
    }

    private IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    private void FindVisibleTargets()
    {
        // 1. Сначала "закрываем глаза" - делаем невидимыми всех, кого видели до этого
        foreach (var enemy in _visibleEnemies)
        {
            if (enemy != null) enemy.SetVisible(false);
        }
        _visibleEnemies.Clear();

        // 2. Ищем все коллайдеры врагов в радиусе шара
        Collider[] targetsInRadius = Physics.OverlapSphere(transform.position, _viewRadius, _targetMask);

        // 3. Перебираем каждого найденного врага
        foreach (var targetCollider in targetsInRadius)
        {
            Transform target = targetCollider.transform;
            
            // Вектор направления от игрока до конкретного врага
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            // 4. Проверяем, попадает ли враг в угол обзора
            if (Vector3.Angle(transform.forward, dirToTarget) < _viewAngle / 2f)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                // 5. Пускаем луч до врага. Если луч НЕ ударился в стену — мы его видим!
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, _obstacleMask))
                {
                    if (target.TryGetComponent(out EnemyVisibility enemyVisibility))
                    {
                        enemyVisibility.SetVisible(true);
                        _visibleEnemies.Add(enemyVisibility);
                    }
                }
            }
        }
    }
}