using System;
using DG.Tweening;
using Events;
using UnityEngine;

namespace Controllers
{
    public class PlayerPhysicController : MonoBehaviour
    {
        private int keyCount = 0;


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out KeyAnimationController key))
            {
                if (key.KeyTween != null && key.KeyTween.IsActive())
                {
                    key.KeyTween.Kill(); 
                }
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