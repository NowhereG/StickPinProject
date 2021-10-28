using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    void Update()
    {
        //中间的球不停的旋转
        transform.Rotate(new Vector3(0, 0, -90 * Time.deltaTime));
    }
}
