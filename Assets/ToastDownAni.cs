using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastDownAni : StateMachineBehaviour
{
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Toast toast = animator.GetComponent<Toast>();
        toast._isToastShown = false;
        toast._isToasting = false;
        if (toast._objectCollistion._interact)
            toast._objectCollistion.ShowText();

        if (toast._end)
            toast._button.gameObject.SetActive(true);
    }
}
