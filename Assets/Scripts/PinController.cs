using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinController : MonoBehaviour
{
    //发射的位置
    public Transform startPoint;
    //创建的位置
    public Transform createPoint;
    //目标位置
    private Vector3 targetPoint;
    //圆的位置
    private Transform circle;
    //发射的速度
    private int speed = 30;
    //当前是否处于发射状态
    private bool isFly = false;
    //是否到达
    private bool isReach = false;
    //分数
    private Text scoreText;
    private int score=0;
    void Start()
    {
        //获取组件
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        startPoint = GameObject.Find("StartPoint").GetComponent<Transform>();
        createPoint = GameObject.Find("CreatePoint").GetComponent<Transform>();
        circle = GameObject.Find("Circle").GetComponent<Transform>();
        targetPoint = circle.position;
        targetPoint.y -= 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //如果处于发射状态
        if (isFly)
        {
            //将针移动到目标位置
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPoint) <= 0.01f)
            {
                //当针到达目标位置，设置针的父物体为圆，那么针就会跟着圆旋转
                transform.SetParent(circle);
                //分数
                score = int.Parse(scoreText.text);
                score++;
                scoreText.text = score.ToString();
                //取消发射状态
                isFly = false;
                //设置到达
                isReach = true;
            }
        }
        else//当针不处于发射状态，就会执行这里
        {
            //判断针是否到达
            if (!isReach)
            {
                //这里就说明针还没有发射，那么针就从创建的位置移动到发射的位置，判断是否到达发射的位置
                if (Vector3.Distance(transform.position, startPoint.position) > 0.01f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);
                }
            }
        }
    }
    //发射方法，设置针的发射状态
    public void StartFly()
    {
        isFly = true;
    }
    
}
