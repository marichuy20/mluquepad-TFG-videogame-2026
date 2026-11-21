using UnityEngine;
using UnityEngine.AI;

public class WolfEnemyBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;
    private float x = 0;
    private float y = 0;
    public Transform player;
    public Animator wolfAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        x = agent.transform.position.x;
        y = agent.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        wolfAnimator.SetBool("isMovingLeft", x > agent.transform.position.x);
        wolfAnimator.SetBool("isMovingRight", x < agent.transform.position.x);
        wolfAnimator.SetBool("isOnlyMovingUp", y < agent.transform.position.y && x == agent.transform.position.x);
        wolfAnimator.SetBool("isOnlyMovingDown", y > agent.transform.position.y && x == agent.transform.position.x);
        //Enemy attacks when it's close to the player and it's not moving
        wolfAnimator.SetBool("isAttacking", wolfAnimator.GetBool("isMovingLeft") == false && wolfAnimator.GetBool("isMovingRight") == false && wolfAnimator.GetBool("isOnlyMovingUp") == false && wolfAnimator.GetBool("isOnlyMovingDown") == false);
        x = agent.transform.position.x;
        y = agent.transform.position.y;

        agent.SetDestination(player.position + new Vector3(0.8f, 0, 0));
    }
}
