using UnityEngine;

namespace Enemy
{
    public class ScoutEnemy : BaseEnemy
    {
        public void BlindPlayer()
        {
            Debug.Log("Разведчик применил световую вспышку и ослепил игрока!");
        }

        public void EmitRadarScan()
        {
            Debug.Log("Разведчик просканировал местность и передал данные!");
        }
    }
}