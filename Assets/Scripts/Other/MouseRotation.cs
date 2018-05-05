using UnityEngine;
using System.Collections;

public class MouseRotation : MonoBehaviour
{
    //是否被拖拽
    private bool onDrag = false;
    //旋转速度
    public float speed = 6f;
    //阻尼速度
    private float zSpeed;
    //鼠标沿水平方向拖拽的增量
    private float X;
    //鼠标沿竖直方向拖拽的增量     
    //private float Y;
    //鼠标移动的距离
    private float mXY;

    //接受鼠标按下的事件
    void OnMouseDown()
    {
        X = 0f;
        //Y = 0f;   
    }

    //鼠标拖拽时的操作
    void OnMouseDrag()
    {
        Debug.Log("鼠标拖拽");
        onDrag = true;
        X = -Input.GetAxis("Mouse X");
        //获得鼠标增量 
        //Y = Input.GetAxis ("Mouse Y"); 
        //mXY = Mathf.Sqrt (X * X + Y * Y);
        //计算鼠标移动的长度
        // if(mXY == 0f){ mXY=1f;         }     }  

        //计算鼠标移动的长度//
        mXY = Mathf.Sqrt(X * X);
        if (mXY == 0f)
        {
            mXY = 1f;
        }
    }

    //获取阻尼速度 
    float RiSpeed()
    {
        if (onDrag)
        {
            zSpeed = speed;
        }
        else
        {
            //if (zSpeed> 0) 
            //{ 
            //通过除以鼠标移动长度实现拖拽越长速度减缓越慢 
            //  zSpeed -= speed*2 * Time.deltaTime / mXY; 
            //} 
            //else 
            //{ 
            zSpeed = 0;
            //}        
        }
        return zSpeed;
    }

    void LateUpdate()
    {
        transform.Rotate(new Vector3(0, X, 0) * RiSpeed(), Space.World);
        if (!Input.GetMouseButtonDown(0))
        {
            onDrag = false;
        }
    }

}