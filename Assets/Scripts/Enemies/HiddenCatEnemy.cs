using UnityEngine;

public class HiddenCatEnemy : MonoBehaviour
{
    //TODO: Erase this class and add this to Cat class
    //Use bool isHidden
    private GameObject hiddenCat;
    public GameObject cat;
    public GameObject smoke;
    
    void Awake()
    {
        this.gameObject.SetActive(true);
        this.smoke.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hiddenCat = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hiddenCat.GetComponent<Animator>().enabled = true;
            Invoke(nameof(ActivateSmoke),1.5f);
            Invoke(nameof(activateCat),2f);
            Invoke(nameof(DestroyHiddenCat),2f);
        }
    }

    private void DestroyHiddenCat()
    {
        Destroy(smoke);
        Destroy(hiddenCat);
    }

    private void activateCat()
    {
        cat.SetActive(true);
    }

    private void ActivateSmoke()
    {
        smoke.gameObject.SetActive(true);
    }
}
