using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class MovingState : FSMState<EnemyController>
    {
        private Vector3 mDirection;
        public MovingState(EnemyController controller) : base(controller)
        {
            
            Transitions.Add(new FSMTransition<EnemyController>(
                isValid: () =>
                {
                    return Vector3.Distance(
                        mEnemyController.transform.position,
                        mEnemyController.Player.transform.position
                    ) >= 5;

                },
                getNextState: () =>
                {
                    return new IdleState(mEnemyController);
                })
            );

            Transitions.Add(new FSMTransition<EnemyController>(
                isValid: () =>
                {
                    return Vector3.Distance(
                        mEnemyController.transform.position,
                        mEnemyController.Player.transform.position
                    ) <= mEnemyController.AttackDistance;

                },
                getNextState: () =>
                {
                    return new AttackingState(mEnemyController);
                })
            );
        }

        public override void OnEnter()
        {
            Debug.Log("OnEnter MovingState");
            mEnemyController.animator.SetBool("IsMoving", true);
        }

        public override void OnExit()
        {
            Debug.Log("OnExit MovingState");

        }

        public override void Update(float deltaTime)
        {
            var playerPosition = mEnemyController.Player.transform.position;
            var enemyPosition = mEnemyController.transform.position;
            mDirection  = (playerPosition - enemyPosition).normalized;

            if(mDirection != Vector3.zero)
            {
                mEnemyController.animator.SetFloat("Horizontal", mDirection.x);
                mEnemyController.animator.SetFloat("Vertical", mDirection.y);
            }

            mEnemyController.rb.MovePosition(
                mEnemyController.transform.position + (mDirection * mEnemyController.Speed * deltaTime)
            );
        }
    }

}
