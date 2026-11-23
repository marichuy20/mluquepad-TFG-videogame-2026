using UnityEngine;

public class WolfEnemy : ShortDistanceEnemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.init();
    }

    // Update is called once per frame
    void Update()
    {
        SetStates();
        HarmPlayer();
        UpdateHealthBar();
        StartCoroutine(Dead());

        //TODO: Enemy is placed right in front the player
        agent.SetDestination(player.transform.position + new Vector3(0.8f, 0, 0));
        //TODO: Change destination if player already has something in front of it
    }
}