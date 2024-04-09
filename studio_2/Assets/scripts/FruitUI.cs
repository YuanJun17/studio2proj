using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitUI : MonoBehaviour
{
    public Text fruitCountText; // 引用UI文本对象
    private int fruitCount = -1;
    private int targetFruitCount = 50; // 目标水果数量

    private void Start()
    {
        
        FruitController.OnFruitEaten += UpdateFruitCountText; // 订阅水果被吃掉的事件
        UpdateFruitCountText(); // 初始化 UI 文本显示
    }

    private void UpdateFruitCountText()
    {
        fruitCount++;
        fruitCountText.text = fruitCount + "/" + targetFruitCount; // 更新UI文本显示
    }

    private void OnDestroy()
    {
        FruitController.OnFruitEaten -= UpdateFruitCountText; // 取消订阅水果被吃掉的事件
    }
}
