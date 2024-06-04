using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonLogic : MonoBehaviour
{
    public event Action<bool> OnButtonPressed; // 定义按钮按下事件

    public void ButtonPressed(bool isYesButton)
    {
        OnButtonPressed?.Invoke(isYesButton); // 触发按钮按下事件，并传递按钮类型（true为yes，false为no）
    }
}
