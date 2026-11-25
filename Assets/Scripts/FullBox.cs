using UnityEngine;

public class FullBox : Box
{
    private GameObject fruit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fruit = this.gameObject.transform.GetChild(0).gameObject;
        fruit.SetActive(false);
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
            fruit.SetActive(true);
            transform.DetachChildren();
            Destroy(this.gameObject);
        }
    }
}
