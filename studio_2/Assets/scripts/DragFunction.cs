using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFunction : MonoBehaviour
{
    private bool isDragging = false; // 标志是否正在拖动物体
    private Vector3 offset; // 鼠标点击位置和物体位置的偏移量
    public Transform rotationCenter; // 旋转中心
    public float rotationSpeed = 50f; // 旋转速度

    private void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos(); // 计算偏移量
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 targetPos = GetMouseWorldPos() + offset; // 计算目标位置
            transform.position = targetPos; // 更新物体位置
        }
        RotateAroundPoint();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void RotateAroundPoint()
    {
        if (rotationCenter != null)
        {
            Vector3 offset = transform.position - rotationCenter.position;
            Quaternion rotation = Quaternion.Euler(0f, 0f, rotationSpeed * Time.deltaTime);
            offset = rotation * offset;
            transform.position = rotationCenter.position + offset;
        }
    }
}
