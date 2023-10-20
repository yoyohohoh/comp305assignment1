using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public int level;
    private bool isDoor = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) && isDoor)
        {
            Debug.Log("Open Door");
            SceneManager.LoadScene(level);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isDoor = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isDoor = false;
    }

}
