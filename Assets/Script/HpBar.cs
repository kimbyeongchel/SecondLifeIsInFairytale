using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Slider healthSlider; // Unity Inspector���� �Ҵ��� �����̴�
    public Text text;

    public float maxHealth;
    private float currentHealth;

    void Start()
    {
        maxHealth = Player.instance.MAXHP;
        currentHealth = Player.instance.HP;
    }

    private void Update()
    {
        maxHealth = Player.instance.MAXHP;
        currentHealth = Player.instance.HP;
        text.text = currentHealth.ToString();
        UpdateHealthBar(); // ü�� �� ������Ʈ
    }
    void UpdateHealthBar()
    {
        float healthPercentage = currentHealth / maxHealth; // ü���� ����� ���
        healthSlider.value = healthPercentage; // �����̴� �� ����
    }
}
