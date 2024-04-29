using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousefollow : MonoBehaviour
{
    void Update()
    {
        // 获取鼠标当前位置
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 保持 z 轴不变
        mousePosition.z = 0f;
        // 将物体位置设置为鼠标位置
        transform.position = mousePosition;
    }
}
