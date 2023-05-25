using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Boss
{
    public class BossIdleState : FSMState<BossController>
    {
        public BossIdleState(BossController controller) : base(controller)
        {
            Transitions.Add(new FSMTransition<BossController>(
                isValid: () =>
                {
                    return Vector3.Distance(
                        BossController.transform.position,
                        BossController.Player.transform.position
                    ) < BossController.WakeUpDistance;

                },
                getNextState: () =>
                {
                    return new BossMovingState(BossController);
                })
            );


        }


        public override void OnEnter()
        {
            Debug.Log("Entering Idle State");
            BossController.animator.SetBool("IsMoving", false);
            BossController.AttackingEnd = false;
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

