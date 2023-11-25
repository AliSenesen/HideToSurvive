using Managers;
using UnityEngine;

namespace Controllers
{
    public class RedButtonController : MonoBehaviour
    {
        [SerializeField] private TurretManager turretManager;

        public void BrokeTurret()
        {
            if (turretManager.isBroke == false)
            {
                turretManager.StopShoot();
                turretManager.isBroke = true;
            }
        }
        
    }
}