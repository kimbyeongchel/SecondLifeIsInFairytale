using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangedMonster : Enemy
{
    public GameObject arrowPrefab;
    private bool isAttacking = false;
    private bool takeAttack = false;

    public AudioSource arrowLoad;
    public AudioSource arrowShot;
    void Start()
    {
        OnEnable();
    }

    void Update()
    {
        if (dead) return;

        yDis = target.position.y - transform.position.y;

        if(Mathf.Abs(yDis) > 2f)
        {
            ani.SetBool("isFollow", false);
            return;
        }    

        DirectionEnemy();

        float distance = Vector2.Distance(transform.position, target.position);

        if (!isAttacking && distance < 14f && distance > 8f)
        {
            ani.SetBool("isFollow", true);
            Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, monsterSpeed * Time.deltaTime);
        }
        else if (distance >= 14f)
        {
            ani.SetBool("isFollow", false);
        }
        else if (distance <= 8f && !isAttacking&& !takeAttack)
        {
            ani.SetBool("isFollow", false);
            StartCoroutine(AttackRoutine());
        }

    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true;
        ani.SetTrigger("attack");
        yield return new WaitForSeconds(0.5f);
        SpawnArrow();
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }

    public override void TakeDamage(int damage)
    {
        if (dead) return;

        takeAttack = true;
        textOut(damage);
        ani.SetTrigger("Hit"); 

        if (HP <= 0)
        {
            Die();
        }
    }

    void SpawnArrow() // ȭ�� �߻�
    {
        Instantiate(arrowPrefab, transform.position + new Vector3(0f, -0.564207f, 0f), Quaternion.identity);
    }

    IEnumerator reset_attack() // hit �� ���� �������� ��� �ð�
    {
        yield return new WaitForSeconds(1.5f);
        isAttacking = false;
        takeAttack = false;
    }

    public void ArrowLoadSound()
    {
        arrowLoad.Play();
    }
    public void ArrowLoadStop()
    {
        arrowLoad.Stop();
    }
    public void ArrowShotSound()
    {
        arrowShot.Play();
    }
}