using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updown_rollback : StateMachineBehaviour
{
    Bossmouse mouse;
    float step; // �����Ӵ� �̵� �Ÿ�
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mouse = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Bossmouse>();
        mouse.monsterSpeed = 8f;
        step = mouse.monsterSpeed * Time.deltaTime; // �����Ӵ� �̵� �Ÿ�
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mouse.transform.position = Vector3.MoveTowards(mouse.transform.position, mouse.initialPosition, step);
        // �ʱ� ��ġ�� �����ϸ� ���ϴ� �۾� ����
        if (mouse.transform.position == mouse.initialPosition)
        {
            animator.SetTrigger("bottom_all");
        }
    }
}
