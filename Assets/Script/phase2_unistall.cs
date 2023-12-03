using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phase2_unistall : StateMachineBehaviour
{
    Bossmouse mouse;
    float speed = 8.0f; // �̵� �ӵ�
    float step; // �����Ӵ� �̵� �Ÿ�
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mouse = GameObject.FindGameObjectWithTag("Bossrat").GetComponent<Bossmouse>();
        step = speed * Time.deltaTime; // �����Ӵ� �̵� �Ÿ�
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mouse.transform.position = Vector3.MoveTowards(mouse.transform.position, mouse.initialPosition, step);

        // �ʱ� ��ġ�� �����ϸ� ���ϴ� �۾� ����
        if (mouse.transform.position == mouse.initialPosition)
        {

            animator.SetTrigger("bottom_all");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
