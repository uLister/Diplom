using UnityEngine;

namespace Enemy
{
    public class ScoutEnemy : BaseEnemy
    {
        public void BlindPlayer()
        {
            Debug.Log("Ослепление");
        }

        public void EmitRadarScan()
        {
            Debug.Log("Назначить точку атаки для снайпера");
        }
    }
}