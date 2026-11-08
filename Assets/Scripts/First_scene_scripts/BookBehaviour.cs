using UnityEngine;

public class BookBehaviour : MonoBehaviour
{
    [SerializeField] private CanvasGroup bookCanvasGroup;
    [SerializeField] private CanvasGroup firstPageSetCanvasGroup;
    [SerializeField] private CanvasGroup secondPageSetCanvasGroup;
    [SerializeField] private CanvasGroup thirdPageSetCanvasGroup;
    [SerializeField] private AudioSource pageTurnSound;
    private bool newPageFadedIn = false;
    private bool oldPageFadedOut = false;
    private int currentPagesSet = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firstPageSetCanvasGroup.alpha = 1;
        secondPageSetCanvasGroup.alpha = 0;
        thirdPageSetCanvasGroup.alpha = 0;
    }

    public void movePage() {
    
        currentPagesSet++;
        oldPageFadedOut = true;
        pageTurnSound.Play();

        if(currentPagesSet == 4)
        {
            Camera.main.gameObject.transform.Translate(0,-3,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPagesSet == 2) 
        {
            if (oldPageFadedOut)
            {
               firstPageSetCanvasGroup.alpha -= Time.deltaTime;
               if (firstPageSetCanvasGroup.alpha == 0)
               {
                firstPageSetCanvasGroup.gameObject.SetActive(false);
                secondPageSetCanvasGroup.gameObject.SetActive(true);
                newPageFadedIn = true;
                oldPageFadedOut = false;
                } 
            }

            if(newPageFadedIn)
            {
                secondPageSetCanvasGroup.alpha += Time.deltaTime;
                if (secondPageSetCanvasGroup.alpha == 1)
                {
                    newPageFadedIn = false;
                }
            }

        }else if(currentPagesSet == 3)
        {
            if (oldPageFadedOut)
            {
               secondPageSetCanvasGroup.alpha -= Time.deltaTime;
               if (secondPageSetCanvasGroup.alpha == 0)
               {
                secondPageSetCanvasGroup.gameObject.SetActive(false);
                thirdPageSetCanvasGroup.gameObject.SetActive(true);
                newPageFadedIn = true;
                oldPageFadedOut = false;
                } 
            }

            if(newPageFadedIn)
            {
                thirdPageSetCanvasGroup.alpha += Time.deltaTime;
                if (thirdPageSetCanvasGroup.alpha == 1)
                {
                    newPageFadedIn = false;
                }
            }
            
        }else if(currentPagesSet > 3)
        {
            if (oldPageFadedOut && bookCanvasGroup.alpha > 0)
            {
               bookCanvasGroup.alpha -= Time.deltaTime;
               if (bookCanvasGroup.alpha == 0)
               {
                bookCanvasGroup.gameObject.SetActive(false);
                oldPageFadedOut = false;
                } 
            }
        }
    }
}
 