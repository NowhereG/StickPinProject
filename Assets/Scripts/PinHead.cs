using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Head")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
        }
    }
}
