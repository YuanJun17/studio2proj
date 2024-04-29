using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qteGenerater : MonoBehaviour
{
    public GameObject qtePrefab; // QTE 物体的预制体

    void Start()
    {
        // 开始一个协程，定时生成 QTE 物体
        StartCoroutine(GenerateQTECoroutine());
    }
    IEnumerator GenerateQTECoroutine()
    {
        while (true)
        {
            // 等待2秒
            yield return new WaitForSeconds(2f);

            // 生成 QTE 物体
            GenerateQTE();
        }
    }


    void GenerateQTE()
    {
        // 获取屏幕的宽度和高度
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // 在屏幕范围内生成随机坐标
        Vector3 randomPosition = new Vector3(Random.Range(0, screenWidth), Random.Range(0, screenHeight), 10f);

        // 将随机坐标转换为世界坐标
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(randomPosition);

        // 在随机坐标生成 QTE 物体
        Instantiate(qtePrefab, worldPosition, Quaternion.identity);
    }
}
