using DG.Tweening;
using UnityEngine;

namespace Controllers
{
    public class DoorController : MonoBehaviour
    {
        public bool IsOpened;
       
        [SerializeField] private GameObject leftDoor;
        [SerializeField] private GameObject rightDoor;
       
        


        public void AnimateDoor()
        {
            leftDoor.transform.DOLocalMoveX(0.95f, .25f).SetEase(Ease.Linear);
            rightDoor.transform.DOLocalMoveX(-0.75f, .25f).SetEase(Ease.Linear);
            IsOpened = true;
        }
    }
}