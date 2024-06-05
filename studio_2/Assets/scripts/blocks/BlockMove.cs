using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    public Transform[] objectsToMove; // 存放需要移动的物体
    public float interval = 2f; // 移动物体的间隔时间

    private Vector3 centerPosition; // 中心点的位置

    void Start()
    {
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        // 等待 10 秒
        yield return new WaitForSeconds(5f);

        // 开始移动物体
        StartCoroutine(MoveObjects());
    }
    IEnumerator MoveObjects()
    {
        // 遍历所有需要移动的物体
        foreach (Transform obj in objectsToMove)
        {
            // 移动物体到 X 坐标为 0 的位置
            yield return StartCoroutine(MoveObject(obj, new Vector3(0f, obj.position.y, obj.position.z)));

            // 等待间隔时间
            yield return new WaitForSeconds(interval);
        }
    }

    IEnumerator MoveObject(Transform obj, Vector3 targetPosition)
    {
        // 移动物体到目标位置
        float elapsedTime = 0f;
        Vector3 startingPos = obj.position;

        while (elapsedTime < 2f) // 这里假设移动时间为 1 秒，你可以根据需要调整
        {
            obj.position = Vector3.Lerp(startingPos, targetPosition, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.position = targetPosition;
    }
}
