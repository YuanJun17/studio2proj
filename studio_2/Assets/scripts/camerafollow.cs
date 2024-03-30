using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform target; // 玩家的Transform
    public Vector2 offset; // 相机与玩家之间的偏移量
    public Vector2 minPosition; // 相机移动的最小位置
    public Vector2 maxPosition; // 相机移动的最大位置

    void LateUpdate()
    {
        if (target != null)
        {
            // 计算相机的目标位置
            Vector3 targetPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);

            // 限制相机移动范围
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            // 移动相机
            transform.position = targetPosition;
        }
    }
}
