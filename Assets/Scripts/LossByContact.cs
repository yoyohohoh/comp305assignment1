using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class LossByContact : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Animator anim;
    private LifeSystem lifeSystem;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        lifeSystem = GameObject.Find("LifeSystem").GetComponent<LifeSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player touch " + gameObject.name);
            lifeSystem.LoseLife();
        }
    }
}
