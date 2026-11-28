using System.Collections;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    //TODO: Turn private
    public GameObject bunny;
    public GameObject[] wolfEnemies;
    public GameObject[] owlEnemies;
    public GameObject[] catEnemies;
    public GameObject[] boxes;
    public GameObject key;
    public GameObject InstructionsCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //TODO: Deattach bunny sprite from game object in UI
        bunny = GameObject.FindGameObjectWithTag("Player");
        key = GameObject.FindGameObjectWithTag("Key");
        key.SetActive(false);
        //Only shown for first room
        StartCoroutine(ShowInitialInstructions());
        GetCurrentEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        EnemiesControl();
        GetCurrentEnemies();
    }

    private void GetCurrentEnemies()
    {
        wolfEnemies = GameObject.FindGameObjectsWithTag("Wolf");
        catEnemies = GameObject.FindGameObjectsWithTag("Cat");
        owlEnemies = GameObject.FindGameObjectsWithTag("Owl");
        boxes = GameObject.FindGameObjectsWithTag("Box");
    }

    private void EnemiesControl()
    {
        //TODO: Boxes too?
        if(wolfEnemies.Length == 0 && owlEnemies.Length == 0 && catEnemies.Length == 0 && boxes.Length == 0)
        {
            //Show key sprite that would unlock the next room
            key.SetActive(true);
            InstructionsCanvas.SetActive(true);
            InstructionsCanvas.GetComponentInChildren<Text>().text = "Congratulations, you cleared your first room!! Pick the key, go to the next room and explore again";
        }
    }

    //Only shown for first room
    private IEnumerator ShowInitialInstructions()
    {
        InstructionsCanvas.SetActive(true);
        InstructionsCanvas.GetComponentInChildren<Text>().text = "Hurry!! Defeat all the enemies to move to the next room. Press Z when an enemy is close";
        yield return new WaitForSeconds(5);
        InstructionsCanvas.GetComponentInChildren<Text>().text = "Make sure to open all the boxes for surprises!";
        yield return new WaitForSeconds(5);
        InstructionsCanvas.SetActive(false);
    }

}
