using UnityEngine;

public class Box : MonoBehaviour
{
    protected float damage = 5f;
    protected bool playerIsAttacking;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Player is attacking
        if (Input.GetKeyDown(KeyCode.Z))
        {
            UpdateDamage();
        }

        if(damage <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //TODO: Check box colliders to only allow hit from the sides
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsAttacking = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsAttacking = false;
        }
    }

    protected void UpdateDamage()
    {
        if(playerIsAttacking)
        {
            if(damage >= 0f)
            {
                damage--;
            }
        }
    }
}
