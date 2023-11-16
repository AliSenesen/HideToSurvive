using System;
using Events;
using UnityEngine;

namespace Controllers
{
    public class PlayerPhysicController : MonoBehaviour
    {
        private int keyCount = 0;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Key"))
            {
                keyCount += 1;
                Destroy(other.gameObject);
            }

            if (other.TryGetComponent(out DoorController door) && keyCount > 0 && !door.IsOpened)
            {
                door.AnimateDoor();
                keyCount--;
            }

            if (other.CompareTag("Finish"))
            {
                CoreGameEvents.Instance.onWin?.Invoke();
            }

            if (other.CompareTag("Enemy"))
            {
                CoreGameEvents.Instance.onFail?.Invoke();
            }
        }
    }
}