using UnityEngine;

public class Fruit : MonoBehaviour
{
    private float powerUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //TODO: Different fruits with different power ups or they have the same
        if(this.gameObject.tag == "Apple")
        {
            powerUp = 30f;
        }else if(this.gameObject.tag == "Watermelon")
        {
            powerUp = 50f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().IncreaseHealth(powerUp);
            Destroy(this.gameObject);
        }
    }
}
