using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class artillery : MonoBehaviour
{
    public GameObject bullet;//子弹
    public GameObject attackPoint;//发射点

    public float bulletNum = 3;
    public float moveSpeed;//速度
    public float maxMoveSpeed = 10f;//最大速度

    public Slider speedSlider;//速度条
    public Text speedText;//速度条上的字


    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0;//初始设定为0
        UIManager.instanse.UpdateBulletNum(bulletNum);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))//鼠标检测
        {
            
            if (EventSystem.current.IsPointerOverGameObject())//检测鼠标是否在GUI上
            {
                if(moveSpeed < maxMoveSpeed)
                {
                    moveSpeed += Time.deltaTime * 10f;//每秒自增
                    speedSlider.value = moveSpeed;//蓄力条
                    speedText.text = moveSpeed.ToString("F2");//蓄力数字
                }
                else
                {
                    moveSpeed = maxMoveSpeed;//最大速度值
                }
                return;
            }
            else
            {
                FollowMouseRotate();//旋转炮筒
            }
        }

    }


    private void FollowMouseRotate()//有bug
    {
        //获取鼠标的坐标，鼠标是屏幕坐标，Z轴为0，这里不做转换  
        Vector3 mouse = Input.mousePosition;
        //获取物体坐标，物体坐标是世界坐标，将其转换成屏幕坐标，和鼠标一直  
        Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
        //屏幕坐标向量相减，得到指向鼠标点的目标向量，即黄色线段  
        Vector3 direction = mouse - obj;
        //将Z轴置0,保持在2D平面内  
        direction.z = 0f;
        //将目标向量长度变成1，即单位向量，这里的目的是只使用向量的方向，不需要长度，所以变成1  
        direction = direction.normalized;
        //物体自身的Y轴和目标向量保持一直，这个过程XY轴都会变化数值  
        transform.up = direction;
    }

    public void Attack()
    {
        Debug.Log("生成子弹");
        bullet = Instantiate(bullet, attackPoint.transform.position, attackPoint.transform.rotation);// 生成子弹
        bullet.GetComponent<Bullet>().moveSpeed = this.moveSpeed;//将速度赋值给子弹的速度
        this.moveSpeed = 0;//发射完速度为0
        
        bulletNum--;
        UIManager.instanse.UpdateBulletNum(bulletNum);

    }




}
