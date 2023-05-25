using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FSMTransition <T>
{

    public FSMTransition(Func<bool> isValid, Func<FSMState<T>> getNextState){
        IsValid = isValid;
        GetNextState = getNextState;
    }
    public Func<bool> IsValid {get; private set;}
    public Func<FSMState<T>> GetNextState {get; private set;}
}

