using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class BossAttackingState : FSMState<BossController>
    {
        public BossAttackingState(BossController controller) : base(controller)
        {
            Transitions.Add(new FSMTransition<BossController>(
                isValid: () =>{
                    return BossController.AttackingEnd;
                },

                getNextState: () =>
                {
                    return new BossIdleState(BossController);
                })
            );
        }

        public override void OnEnter()
        {
            Debug.Log("Entering Attacking State");
            BossController.animator.SetTrigger("Attack");
            BossController.hitBox.gameObject.SetActive(true);

        }

        public override void OnExit()
        {
            Debug.Log("Exiting Attacking State");
            BossController.hitBox.gameObject.SetActive(false);
        }

        public override void Update(float deltaTime)
        { }
    }

}

