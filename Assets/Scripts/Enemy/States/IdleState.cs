using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Enemy
{
    public class IdleState : FSMState<EnemyController>
    {
        public IdleState(EnemyController controller) : base(controller)
        {
            Transitions.Add(new FSMTransition<EnemyController>(
                isValid: () =>
                {
                    return Vector3.Distance(
                        mEnemyController.transform.position,
                        mEnemyController.Player.transform.position
                    ) < mEnemyController.WakeUpDistance;

                },
                getNextState: () =>
                {
                    return new MovingState(mEnemyController);
                })
            );


        }


        public override void OnEnter()
        {
            Debug.Log("Entering Idle State");
            mEnemyController.animator.SetBool("IsMoving", false);
            mEnemyController.AttackingEnd = false;
        }

        public override void OnExit()
        {
            Debug.Log("Exiting Idle State");
        }

        public override void Update(float deltaTime)
        {

        }
    }

}

