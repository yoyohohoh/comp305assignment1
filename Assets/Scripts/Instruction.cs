using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    public GameObject instructionPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player touch " + gameObject.name);
            GameObject guide = Instantiate(instructionPrefab, this.transform.position, Quaternion.identity);
            guide.transform.position = new Vector3(3.55f, 10.00f, 0f);
            guide.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exit " + gameObject.name);
            Destroy(GameObject.Find("instruction(Clone)"));
        }
    }   
}
