using UnityEngine;

public class MainMenuBehaviour : MonoBehaviour
{
    [SerializeField] private CanvasGroup titleScreenCanvasGroup;
    [SerializeField] private CanvasGroup bookCanvasGroup;
    [SerializeField] private bool menuFadeOut = false;
    [SerializeField] private bool bookFadeOut = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        titleScreenCanvasGroup.gameObject.SetActive(true);
        titleScreenCanvasGroup.alpha = 1;
        bookCanvasGroup.gameObject.SetActive(false);
        bookCanvasGroup.alpha = 0;
    }
    
    public void StartGame() {
    
        menuFadeOut = true;
    }

    public void Exit() {
        Application.Quit();
        Debug.Log("El juego se cierra");
    }

    private void Update()
    {
        if (menuFadeOut)
        {
            titleScreenCanvasGroup.alpha -= Time.deltaTime;
            if (titleScreenCanvasGroup.alpha == 0)
            {
                menuFadeOut = false;
                bookFadeOut = true;
                bookCanvasGroup.gameObject.SetActive(true);
            }
        }

        if(bookFadeOut)
        {
            bookCanvasGroup.alpha += Time.deltaTime;
            if (bookCanvasGroup.alpha == 1)
            {
                bookFadeOut = false;
                titleScreenCanvasGroup.gameObject.SetActive(false);
            }
        }
    }
}
