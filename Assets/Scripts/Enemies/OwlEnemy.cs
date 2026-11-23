using UnityEngine;

public class OwlEnemy : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.init();
    }

    // Update is called once per frame
    void Update()
    {
        enemyAnimator.SetBool("isDead", health <= 0f);
        UpdateHealthBar();
        StartCoroutine(Dead());
    }
}
