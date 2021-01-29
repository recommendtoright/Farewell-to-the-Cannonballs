using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Trajectory : MonoBehaviour
{
    //线条颜色

    private Color paintColor = Color.red;

    //线条粗细

    private float paintSize = 0.1f;



    //用来存储炮弹位置

    private List<Vector3> paintPos = new List<Vector3>();



    private bool isPressed;//

    private LineRenderer ren;

    private int x = 0;//保留前一次的轨迹

    private Vector3 lastPos;

    //线条材质

    public Material material;
    public void Clear()
    {
        if (transform.childCount > 0)
        {
            int lineCount = transform.childCount;
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))//鼠标检测
        {

            

                //创建一个空物体，给他动态添加LineRenderer组件

                GameObject line = new GameObject();

                line.transform.SetParent(transform);

                ren = line.AddComponent<LineRenderer>();



                ren.material = material;//设置材质

                ren.startColor = paintColor;//设置颜色

                ren.endColor = paintColor;



                ren.startWidth = paintSize;//设置线的宽度

                ren.endWidth = paintSize;



                ren.numCapVertices = 2;//设置端点圆滑度

                ren.numCornerVertices = 2;//设置拐角圆滑度，顶点越多越圆滑



                lastPos = transform.position;//获取鼠标在世界坐标中的位置

                paintPos.Add(lastPos);

                ren.positionCount = paintPos.Count;//设置构成线条的点的数量

                ren.SetPositions(paintPos.ToArray());

                isPressed = true;
             /*   if (x < 2)
                {
                    x++;
                }
                else
                {
                    x = 0;
                    Clear();
                }*/

            
        }
        if (isPressed)

        {

            //鼠标长按开始绘制,两点距离大于0.1开始添加点

            if (Vector3.Distance(lastPos, transform.position) > 0.1f)

            {

                paintPos.Add(transform.position);

                lastPos = transform.position;

            }

            ren.positionCount = paintPos.Count;

            ren.SetPositions(paintPos.ToArray());

        }
    }
}
