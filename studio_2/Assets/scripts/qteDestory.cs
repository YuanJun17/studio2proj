using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qteDestory : MonoBehaviour
{
    public delegate void QTEDestroyedAction();
    public static event QTEDestroyedAction OnQTEDestroyed;
    void OnMouseEnter()
    {
        // 当鼠标滑过 QTE 物体时销毁它
        Destroy(gameObject);
    }
    void OnDestroy()
    {
        // 在物体被销毁时触发事件
        OnQTEDestroyed?.Invoke();
    }
}
