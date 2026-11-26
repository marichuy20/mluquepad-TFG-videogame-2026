using UnityEngine;

public class Buttons : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause(GameObject pauseScreen)
    {
        if(Time.timeScale == 1f)
        {
            //Pause if game is playing
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }else if(Time.timeScale == 0f)
        {
            //Play if game is paused
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Exit()
    {
        //TODO: Quit game or generate a new map
        Debug.Log("Game quits");
        Application.Quit();
    }

    public void Restart()
    {
        Debug.Log("Game restart");
        //TODO:
        //Restart condition: Bunny recovers health, but its taken to the
        //first room and all the progress is erased
        //Question: is the map new or a new map is generated?
    }
}
