using System;
using UnityEngine;

namespace Datas.PlayerMovementData
{
    [CreateAssetMenu(fileName = "MovementData", menuName = "Player/Movement", order = 0)]
    
    public class MovementData : ScriptableObject
    {
        public float Speed;

    }
}