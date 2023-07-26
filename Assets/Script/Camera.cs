using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera : MonoBehaviour
{
    public Transform playerTransform; // ī�޶� ����ٴ� �÷��̾��� Transform ������Ʈ

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // sceneLoaded �̺�Ʈ�� OnSceneLoaded �޼ҵ带 ����
        FindPlayerObject(); // ���� �ε�� ������ Player ������Ʈ�� ã�Ƽ� ����
    }

    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 playerVector = playerTransform.position;
            playerVector.z = transform.position.z; // ī�޶��� Z�� ��ġ�� �����Ͽ� 2D ȭ���� ����

            transform.position = playerVector;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindPlayerObject(); // ���� �ε�� ������ Player ������Ʈ�� ã�Ƽ� ����
    }

    private void FindPlayerObject()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // �±׸� �̿��� Player ������Ʈ�� ã��

        if (player != null)
        {
            playerTransform = player.transform; // Player ������Ʈ�� Transform�� ������ ����
        }
        else
        {
            Debug.LogWarning("Player ������Ʈ�� ã�� �� �����ϴ�. Player ������Ʈ�� 'Player' �±׸� �߰��ϼ���.");
        }
    }
}