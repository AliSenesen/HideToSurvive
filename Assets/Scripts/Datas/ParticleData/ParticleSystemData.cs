using Enums;
using UnityEngine;

namespace Datas.ParticleData
{
    [CreateAssetMenu(fileName = "ParticleData", menuName = "ParticleData/Data", order = 0)]
    public class ParticleSystemData : ScriptableObject
    {
        public ParticleTypes ParticleType;
        public GameObject ParticlePrefab;
    }
}