using UnityEngine;
using System.Collections;

public class ParchmentBehaviour : MonoBehaviour
{
    [SerializeField] private CanvasGroup parchmentMessageCanvasGroup;
    [SerializeField] private GameObject storyTellingBoxCanvasGroup;
    [SerializeField] private GameObject wrappedParchment;
    [SerializeField] private AudioSource pageTurnSound;
    private bool openParchment = false;
    private bool closeParchment = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parchmentMessageCanvasGroup.gameObject.SetActive(false);
        parchmentMessageCanvasGroup.alpha = 0;
        storyTellingBoxCanvasGroup.gameObject.SetActive(false);
    }

    private void OnMouseDown() {
        parchmentMessageCanvasGroup.gameObject.SetActive(true);
        pageTurnSound.Play();
        openParchment = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(openParchment)
        {
            parchmentMessageCanvasGroup.alpha += Time.deltaTime;
            if (parchmentMessageCanvasGroup.alpha == 1)
            {
                openParchment = false;
            }
        }

        if(Input.GetKeyDown("space") && parchmentMessageCanvasGroup.alpha == 1) {
            closeParchment = true;
            pageTurnSound.Play();
        }

        if(closeParchment)
        {
            parchmentMessageCanvasGroup.alpha -= Time.deltaTime;
            if (parchmentMessageCanvasGroup.alpha == 0)
            {
                closeParchment = false;
                parchmentMessageCanvasGroup.gameObject.SetActive(false);
                wrappedParchment.SetActive(false);
                storyTellingBoxCanvasGroup.gameObject.SetActive(true);
            }
        }
    }
}
