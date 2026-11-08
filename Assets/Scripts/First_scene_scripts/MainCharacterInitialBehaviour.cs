using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacterInitialBehaviour: MonoBehaviour
{
    private bool heroRuns = false;
    [SerializeField] private GameObject mainHero;
    public Animator mainHeroAnimator;
    public GameObject loadingScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainHero = this.gameObject;
        mainHeroAnimator = GetComponent<Animator>();
    }

    public void MoveHero(GameObject textBox) {
        textBox.SetActive(false);
        heroRuns = true;
        mainHeroAnimator.Play("bunny_walk_animation");
    }

    // Update is called once per frame
    void Update()
    {
        if(heroRuns)
        {
            mainHero.transform.position = new Vector3(mainHero.transform.position.x+Time.deltaTime*5, mainHero.transform.position.y, mainHero.transform.position.z);
            if (mainHero.transform.position.x >= 10)
            {
                heroRuns = false;
                SceneManager.LoadScene("BunnyBurrow");
            }
        }
    }
}
