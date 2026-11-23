using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //TODO: Do all enemies have the same health levels?
    protected float health = 100f;
    protected Player player;
    protected Animator enemyAnimator;
    public UnityEngine.UI.Image fillBar;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void init()
    {
        enemyAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    protected IEnumerator Dead()
    {
        if(health <= 0f)
        {
            //Wait for death animation to finish
            yield return new WaitForSeconds(enemyAnimator.GetCurrentAnimatorClipInfo(0).Length * 1.5f);
            Destroy(this.transform.parent.gameObject);
        }
    }

    protected void UpdateHealthBar()
    {
        if(health >= 0)
        {
            fillBar.fillAmount = health/100f;
        }
    }

    public void DecreaseHealth(float impact)
    {
        if(health >=0 )
        {
           health -= impact; 
        }
    }

    public float GetHealth()
    {
        return health;
    }
}
