using System;
using DG.Tweening;
using Events;
using UnityEngine;

namespace Controllers
{
    public class PlayerPhysicController : MonoBehaviour
    {
        private int _keyCount;


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out KeyAnimationController key))
            {
                if (key.KeyTween != null && key.KeyTween.IsActive())
                {
                    key.KeyTween.Kill();
                }

                _keyCount += 1;
                Destroy(other.gameObject);
            }

            if (other.TryGetComponent(out DoorController door) && _keyCount > 0 && !door.IsOpened)
            {
                door.AnimateDoor();
                _keyCount -= 1;
            }

            if (other.TryGetComponent(out RedButtonController button))
            {
                button.BrokeTurret();
            }

            if (other.CompareTag("Enemy"))
            {
                _keyCount = 0;
                CoreGameEvents.Instance.onFail?.Invoke();
            }

            if (other.CompareTag("Finish"))
            {
                _keyCount = 0;
                CoreGameEvents.Instance.onWin?.Invoke();
            }
        }
    }
}