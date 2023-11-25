using System;
using Controllers;
using Enums;
using Events;
using UnityEngine;

namespace Managers
{
    public class TurretManager : MonoBehaviour
    {
        public bool isBroke;

        [SerializeField] private TurretShotController shotController;

        public void StopShoot()
        {
            shotController.CancelInvoke(nameof(shotController.Shoot));
            ParticleManager.Instance.SpawnParticle(ParticleTypes.Explosion, transform);
            ParticleManager.Instance.SpawnParticle(ParticleTypes.BrokeEffect, transform);
        }
    }
}