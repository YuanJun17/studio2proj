using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundfollow : MonoBehaviour
{
    public Transform target; // 玩家的Transform
    public float rotationSpeed = 1.0f; // 旋转速度
    public Vector3 offset; // 相机与玩家之间的偏移量
    public float delayTime = 10.0f; // 延迟开始旋转的时间

    private float timer = 0.0f;
    private bool canRotate = false;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delayTime)
        {
            canRotate = true;
        }
    }
    void LateUpdate()
    {
        if (target != null)
        {
            
            // 跟随玩家
            transform.position = target.position + offset;

            if (canRotate)
            {
                // 自身逆时针旋转
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
