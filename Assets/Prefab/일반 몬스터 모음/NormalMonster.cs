using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalMonster : Enemy
{ 
    public bool isAttacking = false; // ���� �� ����
    public float idleTime = 2f; // ���� �� idle �ð�
    private bool isIdleAfterAttack = false; // ���� �� idle ���� ����
    private bool takeAttack = false; //��� �� ���̻� ���� ���ϵ��� ����

    public AudioSource attack;
    public AudioSource mouse;
    void Start()
    {
        OnEnable();
        isAttacking = false;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        monsterSpeed = 4f;
    }

    void Update()
    {
        if (dead) return;

        yDis = target.position.y - transform.position.y;

        if (Mathf.Abs(yDis) > 2f) // y��ǥ�� ���̷� ���� ���� ����
        {
            ani.SetBool("isFollow", false); // �޸��� �ִ� �� ����
            return;
        }

        float distance = Vector2.Distance(transform.position, target.position);

        if (!isAttacking && distance < 8f && distance > 1.3f)
        {
            if (!isIdleAfterAttack)
            {
                DirectionEnemy();
                ani.SetBool("isFollow", true);
                Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, monsterSpeed * Time.deltaTime);
            }
        }
        else if (distance >= 8f)
        {
            ani.SetBool("isFollow", false);
        }
        else if (distance <= 1.3f)
        {
            ani.SetBool("isFollow", false);
            if (!isAttacking && !isIdleAfterAttack) // ���� ���̰ų� �̹� idle ���̶�� �������� ����
            {
                DirectionEnemy();
                ani.SetTrigger("attack");
                StartCoroutine(ResumeAttack());
            }
        }
    }

    IEnumerator ResumeAttack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(1f); // ���� �ִϸ��̼� ��� �ð� (1��)
        isAttacking = false;
        StartCoroutine(stop_time());
    }

    IEnumerator stop_time()
    {
        isIdleAfterAttack = true;
        yield return new WaitForSeconds(idleTime);
        isIdleAfterAttack = false;
    }

    public override void TakeDamage(int damage)
    {
        if (dead) return;

        takeAttack = true;
        textOut(damage);

        if (Health.value <= 0)
        {
            Die();
        }
        else
        {
            ani.SetTrigger("Hit");
            StartCoroutine(stop_time());
            takeAttack = false;
        }
    }

    public void AttackSound()
    {
        attack.Play();
    }

    public void mousePlay()
    {
        mouse.Play();
    }
}
