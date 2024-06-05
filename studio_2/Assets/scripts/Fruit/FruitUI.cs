using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitUI : MonoBehaviour
{
    public Text fruitCountText; // ����UI�ı�����
    public int fruitCount = -1;
    public int targetFruitCount = 50; // Ŀ��ˮ������

    private void Start()
    {

        FruitController.OnFruitEaten += OnFruitEaten;
        FruitController_2.OnGoldenFruitEaten += OnGoldenFruitEaten;
        UpdateFruitCountText(); // ��ʼ�� UI �ı���ʾ
       
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
        fruitCountText.text = fruitCount + "/" + targetFruitCount; // ����UI�ı���ʾ
    }

    private void OnDestroy()
    {
        // ȡ������ˮ�����Ե����¼�
        FruitController.OnFruitEaten -= OnFruitEaten;
        FruitController_2.OnGoldenFruitEaten -= OnGoldenFruitEaten;
    }
}
