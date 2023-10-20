using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class LifeSystem : MonoBehaviour
{
    private int value;
    private Slider slider;

    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        ResetLife();
    }

    private void FixedUpdate()
    {        
        if(slider.value <= 0)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    public void ResetLife()
    {
        slider.value = 100;
        Debug.Log("Reset Life: " + slider.value);
    }

    public void LoseLife()
    {

        Debug.Log("Lose Life: " + slider.value);
        slider.value -= 10;

    }
}
