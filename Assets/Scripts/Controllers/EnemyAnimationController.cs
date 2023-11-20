using Enums;
using UnityEngine;

namespace Controllers
{
    public class EnemyAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
     
        private EnemyAnimStates _animStates;
        
        private void ChangeAnimData(EnemyAnimStates animStates)
        {
            _animStates = animStates;
        }

        public void IdleAnim()
        {
            ChangeAnimData(EnemyAnimStates.Idle);
            animator.Play("Idle");
        }
         public void WalkAnim()
        {
            ChangeAnimData(EnemyAnimStates.Walk);
            animator.Play("Walk");
        }
        
    }
}