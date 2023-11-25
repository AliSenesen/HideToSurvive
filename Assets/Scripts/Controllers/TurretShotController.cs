using System;
using Lean.Common;
using Lean.Pool;
using UnityEngine;

namespace Controllers
{
    public class TurretShotController : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform barrel;
        [SerializeField] private float speed = 20;

        [SerializeField] private float shootInterval;


        private void Start()
        {
            InvokeRepeating(nameof(Shoot), 0f, shootInterval);
        }


        public void Shoot()
        {
            GameObject ammo = LeanPool.Spawn(bulletPrefab, barrel.position, barrel.rotation);
            ammo.GetComponent<Rigidbody>().velocity = barrel.forward * speed;

            LeanPool.Despawn(ammo, .5f);
        }
    }
}