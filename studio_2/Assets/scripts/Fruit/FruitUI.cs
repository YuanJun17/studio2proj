using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitUI : MonoBehaviour
{
    public Text fruitCountText; // 引用UI文本对象
    public int fruitCount = -1;
    public int targetFruitCount = 50; // 目标水果数量

    private void Start()
    {

        FruitController.OnFruitEaten += OnFruitEaten;
        FruitController_2.OnGoldenFruitEaten += OnGoldenFruitEaten;
        UpdateFruitCountText(); // 初始化 UI 文本显示
       
    }

    private void OnFruitEaten()
    {
        fruitCount++;
        UpdateFruitCountText();
    }

    private void OnGoldenFruitEaten()
    {
        fruitCount += 5;
        UpdateFruitCountText();
    }

    private void UpdateFruitCountText()
    {
        fruitCountText.text = fruitCount + "/" + targetFruitCount; // 更新UI文本显示
    }

    private void OnDestroy()
    {
        // 取消订阅水果被吃掉的事件
        FruitController.OnFruitEaten -= OnFruitEaten;
        FruitController_2.OnGoldenFruitEaten -= OnGoldenFruitEaten;
    }
}
