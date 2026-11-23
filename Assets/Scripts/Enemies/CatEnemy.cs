using UnityEngine;

public class CatEnemy : ShortDistanceEnemy
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        agent.enabled = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        x = agent.transform.position.x;
        y = agent.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        SetStates();
        HarmPlayer();
        UpdateHealthBar();
        StartCoroutine(Dead());


        //TODO: Enemy is placed right behind the player
        agent.SetDestination(player.transform.position + new Vector3(-0.5f, 0, 0));
        //TODO: Change destination if player already has something in front of it
    }
}
