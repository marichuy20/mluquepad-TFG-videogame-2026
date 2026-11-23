using Unity.Mathematics;
using UnityEngine;

public class OwlEnemy : MonoBehaviour
{
    public GameObject arrow;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        arrow.transform.position = Vector2.MoveTowards(arrow.transform.position, player.transform.position, 5f * Time.deltaTime);
        arrow.transform.right = player.transform.position - arrow.transform.position;
    }
}
