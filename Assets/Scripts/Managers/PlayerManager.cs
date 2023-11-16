using System;
using Events;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameEvents.Instance.onLevelChange += OnLevelChange;
            CoreGameEvents.Instance.onRestart += OnLevelChange;
        }


        private void UnSubscribeEvents()
        {
            CoreGameEvents.Instance.onLevelChange -= OnLevelChange;
            CoreGameEvents.Instance.onRestart -= OnLevelChange;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void OnLevelChange()
        {
            Vector3 startPos = new Vector3(0, 0, -10);
           transform.position = startPos;
        }
    }
}