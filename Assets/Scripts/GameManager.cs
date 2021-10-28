using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //针
    public GameObject pinPrefab;
    //创建位置
    public Transform createPoint;
    //发射位置
    public Transform startPoint;
    //实例化出来的针
    private GameObject createdPin;
    //游戏结束的动画速度
    public int animationSpeed = 3;
    //游戏是否结束
    private bool isGameOver = false;
    //主摄像机
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        //创建一个针
        CreatePin();
        //获取主摄像机
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //判断游戏是否结束
        if (!isGameOver)
        {
            //没有结束，当玩家按下鼠标左键，发射针
            if (Input.GetMouseButtonDown(0))
            {
                //调用针身上的脚本中的StartFly方法
                createdPin.GetComponent<PinController>().StartFly();
                //再创建一个针
                CreatePin();
            }
        }
        else
        {
            //当游戏结束，镜头慢慢放大
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, 4, animationSpeed * Time.deltaTime);
            //改变背景颜色，由白变成红
            mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, Color.red, animationSpeed * Time.deltaTime);
        }
        
    }

    void CreatePin()
    {
        //生成一个针，在createPoint的位置
        createdPin = Instantiate(pinPrefab, createPoint.position, Quaternion.identity);
    }
    //游戏结束
    public void GameOver()
    {
        //判断游戏是否结束，GameOver方法只调用一次
        if (!isGameOver)
        {
            //停止旋转
            GameObject.Find("Circle").GetComponent<Circle>().enabled = false;
            //延迟2s后调用重新加载界面方法
            Invoke("LoadScene", 2f);
            //设置标志位
            isGameOver = true;
        }
    }
    private void LoadScene()
    {
        //加载当前正处于活动状态的场景（刷新当前场景）
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
