using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Enemy enemy;
    private int startHealth;

    public Image fill;
    public Gradient colorGradient;

    private Camera cam;

    public void Initialize(Enemy enemy)
    {
        this.enemy = enemy;
        startHealth = enemy.health;

        cam = Camera.main;
    }

    void Update()
    {
        if (enemy != null)
        {
            fill.fillAmount = (float)enemy.health / (float)startHealth;
            fill.color = colorGradient.Evaluate(fill.fillAmount);

            transform.position = cam.WorldToScreenPoint(enemy.transform.position) +new Vector3(0, Screen.height / 30.0f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
