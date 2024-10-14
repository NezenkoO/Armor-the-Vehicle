using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleRandom : StateMachineBehaviour
{
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        animator.SetInteger("IdleID", Random.Range(0, 2));
    }
}
