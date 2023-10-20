using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Animator anim;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        counter = 0;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            counter++;
            Debug.Log("Player touch " + gameObject.name + " Time: " + counter);
            if (counter == 3)
            {
                //destroy parent game object
                Destroy(transform.parent.gameObject);
            }
            
        }
    }
}
