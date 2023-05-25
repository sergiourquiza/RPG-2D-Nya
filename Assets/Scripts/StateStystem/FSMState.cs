using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState <T>
{
    protected T mEnemyController;
    protected T BossController;
    public List<FSMTransition<T>> Transitions;

    public FSMState(T controller){

        mEnemyController = controller;
        BossController = controller;
        Transitions = new List<FSMTransition<T>>();
    }

    public abstract void OnEnter();
    public abstract void Update(float deltaTime);
    public abstract void OnExit();
    
}
