using UnityEngine;
using UnityEngine.SceneManagement;

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

    //TODO: Use these function in first scene too if possible
    public void Exit()
    {
        Debug.Log("Game quits");
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        LoadingScreenManager.Instance.SwitchScene(0);
        //SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        Debug.Log("Game restart");
        LoadingScreenManager.Instance.SwitchScene(1); //Room-1
        //TODO:
        //Restart condition: Bunny recovers health, but its taken to the
        //first room and all the progress is erased
        //Question: is the map new or a new map is generated?
    }
}
