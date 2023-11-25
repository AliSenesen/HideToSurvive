using System;
using UnityEngine;
using System.Collections.Generic;
using Datas.ParticleData;
using Enums;
using Events;

namespace Managers
{
    public class ParticleManager : MonoBehaviour
    {
        public static ParticleManager Instance;

        [SerializeField] private List<ParticleSystemData> particleSystemDataList;

        private Dictionary<ParticleTypes, GameObject> _particlePrefabs;
        private List<GameObject> _activeParticles; 

       
        #region EventSubscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameEvents.Instance.onWin += OnClearAllParticles;
            CoreGameEvents.Instance.onFail += OnClearAllParticles;
        }

        private void UnsubscribeEvents()
        {
            CoreGameEvents.Instance.onWin -= OnClearAllParticles;
            CoreGameEvents.Instance.onFail -= OnClearAllParticles;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        private void Start()
        {
            InitializeParticlePrefabs();
            _activeParticles = new List<GameObject>();
        }

        private void InitializeParticlePrefabs()
        {
            _particlePrefabs = new Dictionary<ParticleTypes, GameObject>();

            foreach (var data in particleSystemDataList)
            {
                _particlePrefabs[data.ParticleType] = data.ParticlePrefab;
            }
        }

        public void SpawnParticle(ParticleTypes particleType, Transform spawnTransform)
        {
            if (_particlePrefabs.TryGetValue(particleType, out GameObject particlePrefab))
            {
                GameObject particleInstance = Instantiate(particlePrefab, spawnTransform.position, spawnTransform.rotation);
                  
                _activeParticles.Add(particleInstance); 

                if (particleType == ParticleTypes.Explosion)
                {
                    Destroy(particleInstance, 2f);
                }
              
            }
        }

        private void OnClearAllParticles()
        {
            foreach (var particle in _activeParticles)
            {
                if (particle != null)
                {
                    Destroy(particle);
                }
            }

            _activeParticles.Clear();
        }
    }
}
