using UnityEngine;

namespace Enemy
{
    public class CoverPoint : MonoBehaviour
    {
        public bool IsOccupied { get; set; } = false;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, 0.4f); 
        }
    }
}