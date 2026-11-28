using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //When player collides with key, it's taken to the next room
            Debug.Log("Touching Key");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            //TODO: Check error for LoadingScreenManager method
            //LoadingScreenManager.Instance.SwitchScene(3);
        }
    }
}
