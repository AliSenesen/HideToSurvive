using System;
using System.Collections;
using Datas.ZombieData;
using DG.Tweening;
using UnityEngine;

namespace Controllers
{
    public class EnemyBehaviourController : MonoBehaviour
    {
        [SerializeField] private EnemyType type;
        [SerializeField] private EnemyAnimationController animationController;
        [SerializeField] private Transform startPos;
        [SerializeField] private Transform targetPos;

        private bool _movingTowardsTarget = true;


        private void Update()
        {
            if (type.CanMove)
            {
                PaceMovement();
            }

            if (!type.CanMove)
            {
                animationController.IdleAnim();
            }
        }

        private void PaceMovement()
        {
            float step = type.MoveSpeed * Time.deltaTime;

            if (_movingTowardsTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos.position, step);
                transform.LookAt(targetPos.position);

                if (Vector3.Distance(transform.position, targetPos.position) < 0.4f)
                {
                    _movingTowardsTarget = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos.position, step);
                transform.LookAt(startPos.position);

                if (Vector3.Distance(transform.position, startPos.position) < 0.4f)
                {
                    _movingTowardsTarget = true;
                }
            }

            animationController.WalkAnim();
        }
    }
}