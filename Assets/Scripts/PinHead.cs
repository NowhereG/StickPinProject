using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Head")
        {
            //当针的头发生碰撞，就结束游戏
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
        }
    }
}
