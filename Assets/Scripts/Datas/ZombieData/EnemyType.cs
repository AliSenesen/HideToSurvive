using UnityEngine;

namespace Datas.ZombieData
{
    [CreateAssetMenu(fileName = "ZombieDataType", menuName = "ZombieTypes", order = 0)]
    public class EnemyType : ScriptableObject
    {
        public bool CanMove;
        public float MoveSpeed;
    }
}