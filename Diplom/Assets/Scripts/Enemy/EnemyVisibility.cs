using UnityEngine;

public class EnemyVisibility : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        // Находим компонент, который отвечает за отрисовку 3D-модели
        _renderer = GetComponent<Renderer>();
        
        // По умолчанию враг спавнится невидимым
        SetVisible(false);
    }

    public void SetVisible(bool isVisible)
    {
        if (_renderer != null)
        {
            _renderer.enabled = isVisible;
        }
    }
}