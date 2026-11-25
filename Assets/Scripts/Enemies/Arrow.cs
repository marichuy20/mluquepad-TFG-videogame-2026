using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Vector3 target;
    private bool hitsPlayer;
    public GameObject player;
    public GameObject owl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Arrow is placed closed to parent
        this.transform.position = new Vector3(this.transform.parent.position.x,this.transform.parent.position.y,this.transform.parent.position.z);
        //Get Player current position
        target = player.transform.position;
        //Arrow is pointing the direction of the player position
        this.transform.right = player.transform.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(owl.GetComponent<OwlEnemy>().isAttacking)
        {
            ShootArrow();
            HarmPlayer();
            ResetArrow();
        }else if(!owl.GetComponent<OwlEnemy>().isAttacking)
        {
            //TODO
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hitsPlayer = true;
        }
        //TODO: Arrow dissapears when it collides with a box or enemy? It
        //does not reduce player health
    }

    private void HarmPlayer()
    {
        if(hitsPlayer)
        {
            //TODO: Check if param could be better
            player.GetComponent<Player>().DecreaseHealth(0.5f);
        }
    }

    private void ShootArrow()
    {
        //TODO: When player is too close, not shoot?
        //Arrow is directed to the player position
        this.transform.position = Vector2.MoveTowards(this.transform.position, target, 3f * Time.deltaTime);
    }

    private void ResetArrow()
    {
        if (this.transform.position == target || hitsPlayer)
        {
            this.transform.position = new Vector3(this.transform.parent.position.x,this.transform.parent.position.y,this.transform.parent.position.z);
            //Get Player current position
            target = player.transform.position;
            //Arrow is pointing the direction of the player position
            this.transform.right = player.transform.position - this.transform.position;
            hitsPlayer = false;
        }
    }
}
