using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenManager : MonoBehaviour
{
    public static LoadingScreenManager Instance;
    public GameObject loadingScreen;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SwitchScene(int id)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsync(id));
    }

    IEnumerator LoadSceneAsync(int id)
    {
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(id);

        while (!operation.isDone)
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        loadingScreen.SetActive(false);
    }
}
