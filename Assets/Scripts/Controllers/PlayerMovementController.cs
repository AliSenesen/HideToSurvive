using Datas.PlayerMovementData;
using UnityEngine;

namespace Controllers
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private MovementData data;
        [SerializeField] private PlayerAnimationController animationController;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private FloatingJoystick joystick;

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            rb.velocity = new Vector3(joystick.Horizontal * data.Speed, rb.velocity.y, joystick.Vertical * data.Speed);

            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(rb.velocity);
                animationController.StartWalkAnim();
            }
            else
            {
                animationController.StartIdleAnim();
            }
        }
    }
}