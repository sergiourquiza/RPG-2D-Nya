using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class AttackingState : FSMState<EnemyController>
    {
        public AttackingState(EnemyController controller) : base(controller)
        {
            Transitions.Add(new FSMTransition<EnemyController>(
                isValid: () =>{
                    return mEnemyController.AttackingEnd;
                },

                getNextState: () =>
                {
                    return new IdleState(mEnemyController);
                })
            );
        }

        public override void OnEnter()
        {
            Debug.Log("Entering Attacking State");
            mEnemyController.animator.SetTrigger("Attack");
            mEnemyController.hitBox.gameObject.SetActive(true);

        }

        public override void OnExit()
        {
            Debug.Log("Exiting Attacking State");
            mEnemyController.hitBox.gameObject.SetActive(false);
        }

        public override void Update(float deltaTime)
        { }
    }

}


