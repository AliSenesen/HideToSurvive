using System;
using Events;
using UnityEngine;

namespace Controllers
{
    public class PlayerPhysicController : MonoBehaviour
    {
        private bool gotKey;
      

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Key"))
            {
                gotKey = true;
                Destroy(other.gameObject);
            }

            if (other.TryGetComponent(out DoorController door) && gotKey)
            {
                door.AnimateDoor();
               
                gotKey = false;
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