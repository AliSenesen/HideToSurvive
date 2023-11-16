using Enums;
using UnityEngine;

namespace Controllers
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
       
        private PlayerAnimStates _animStates;
        


        private void ChangeAnimation(PlayerAnimStates animationStates)
        {
            _animStates = animationStates;
        }

        public void StartIdleAnim()
        {
            ChangeAnimation(PlayerAnimStates.Idle);
            animator.SetBool("isWalking",false);
        }

        public void StartWalkAnim()
        {
            ChangeAnimation(PlayerAnimStates.Walk);
            animator.SetBool("isWalking",true);
            
        }
    }
}