using System.Collections;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class CatEnemy : MonoBehaviour
{
    private Animator catAnimator;
    public Animator smoke;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        catAnimator = GetComponent<Animator>();
        catAnimator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            catAnimator.enabled = true;
            Invoke(nameof(ActivateSmoke), 2f);
        }
    }

    private void ActivateSmoke()
    {
        smoke.gameObject.SetActive(true);
    }
}
