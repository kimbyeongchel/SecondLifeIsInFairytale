using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    public static Canvas instance;
    public Rollpaper_ui rollpaper;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ������Ʈ�� �� ��ȯ �ÿ��� �ı����� �ʵ��� ����
        }
        else
        {
            // �̹� �ν��Ͻ��� �����ϸ� �ߺ� ������ ���̹Ƿ� �� ������Ʈ�� �ı�
            Destroy(gameObject);
        }
    }
}
