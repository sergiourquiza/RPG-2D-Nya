using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class BossMovingState : FSMState<BossController>
    {
        private Vector3 mDirection;
        public BossMovingState(BossController controller) : base(controller)
        {
            
            Transitions.Add(new FSMTransition<BossController>(
                isValid: () =>
                {
                    return Vector3.Distance(
                        BossController.transform.position,
                        BossController.Player.transform.position
                    ) >= 5;

                },
                getNextState: () =>
                {
                    return new BossIdleState(BossController);
                })
            );

            Transitions.Add(new FSMTransition<BossController>(
                isValid: () =>
                {
                    return Vector3.Distance(
                        BossController.transform.position,
                        BossController.Player.transform.position
                    ) <= BossController.AttackDistance;

                },
                getNextState: () =>
                {
                    return new BossAttackingState(BossController);
                })
            );
        }

        public override void OnEnter()
        {
            Debug.Log("OnEnter MovingState");
            BossController.animator.SetBool("IsMoving", true);
        }

        public override void OnExit()
        {
            Debug.Log("OnExit MovingState");

        }

        public override void Update(float deltaTime)
        {
            var playerPosition = BossController.Player.transform.position;
            var bossPosition = BossController.transform.position;
            mDirection  = (playerPosition - bossPosition).normalized;

            if(mDirection != Vector3.zero)
            {
                BossController.animator.SetFloat("Horizontal", mDirection.x);
                BossController.animator.SetFloat("Vertical", mDirection.y);
            }

            BossController.rb.MovePosition(
                BossController.transform.position + (mDirection * BossController.Speed * deltaTime)
            );
        }
    }

}
