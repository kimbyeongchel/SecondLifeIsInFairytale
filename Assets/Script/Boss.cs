using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public bool isDie;
    public GameObject rewardManager;
    public GameObject cinemachine;

    private void Start()
    {
        isDie = false;

        //GameObject reward = GameObject.Find("Reward");
        rewardManager = GameObject.FindWithTag("RewardManager").gameObject;
        cinemachine = GameObject.FindWithTag("Director").gameObject;

        if (rewardManager != null)
        {
            // Ȱ�� ���¸� �����մϴ�.
            rewardManager.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Reward Manager�� ã�� �� �����ϴ�.");
        }
    }

    private void Update()
    {
        if (isDie)
        {
            StartCoroutine(this.Die());
        }
    }
    public void IsDie()
    {
        isDie = true;
    }

    IEnumerator Die()
    {
        cinemachine.SetActive(true);

        yield return new WaitForSeconds(3f);
        //�״� �ִϸ��̼� ����

        rewardManager.gameObject.SetActive(true);
        //this.gameObject.SetActive(false);
    }

}
