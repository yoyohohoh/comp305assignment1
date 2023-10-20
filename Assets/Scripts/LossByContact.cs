using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class LossByContact : MonoBehaviour
{


    private LifeSystem lifeSystem;

    void Start()
    {



        lifeSystem = GameObject.Find("LifeSystem").GetComponent<LifeSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player touch " + gameObject.name);
            lifeSystem.LoseLife();
        }
    }
}
