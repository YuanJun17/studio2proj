using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterPu : MonoBehaviour
{
    public Transform landingPoint; // 落点位置

    // 在动画事件中调用的方法
    public void MoveCharacterToLandingPoint()
    {
        if (landingPoint != null)
        {
            // 移动角色到落点位置
            transform.position = landingPoint.position;
        }
        else
        {
            Debug.LogWarning("未设置落点位置！");
        }
    }
}
