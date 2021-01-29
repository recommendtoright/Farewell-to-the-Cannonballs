using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;//子弹移动速度
    public float power = 20;//子弹的帕瓦

    private Vector3 currentPos;
    private Rigidbody2D rigid;//刚体
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        currentPos = transform.position;
        Debug.Log("开始时方向:" + currentPos);
        rigid.velocity = transform.right * moveSpeed;//子弹移动
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spring"))//弹簧碰撞体
        {
            Debug.Log("碰撞弹簧");
           /* //Vector3 v = (Vector3.zero - transform.position).normalized;
            Vector3 incidenceNum = (transform.position - currentPos).normalized;
            //Debug.Log("碰撞时方向:" + incidenceNum);

            Vector3 nomalVector = new Vector3(0, 1, 0);//法线向量，引为是2d且只有平面方向
            Vector3 projectVector = Vector3.Project(-incidenceNum, nomalVector);//投影向量
            Vector3 m = projectVector - (-incidenceNum);//投影与入射向量的距离向量
            incidenceNum = (projectVector + m).normalized;//反射向量
            //v = Vector3.Reflect(v, nomalVector);
            Debug.Log("反弹时方向:" + incidenceNum);
            rigid.AddForce(incidenceNum * power, ForceMode2D.Impulse);*/


            //取巧 肯定是不对的
            rigid.AddForce(new Vector2(1, 2) * moveSpeed*2, ForceMode2D.Impulse);
        }

        

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Fan"))//风扇碰撞体
        {
            rigid.AddForce(new Vector2(0, 1), ForceMode2D.Impulse);

        }
    }
}
