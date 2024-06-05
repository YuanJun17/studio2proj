using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    public Transform[] objectsToMove; // �����Ҫ�ƶ�������
    public float interval = 2f; // �ƶ�����ļ��ʱ��

    private Vector3 centerPosition; // ���ĵ��λ��

    void Start()
    {
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        // �ȴ� 10 ��
        yield return new WaitForSeconds(5f);

        // ��ʼ�ƶ�����
        StartCoroutine(MoveObjects());
    }
    IEnumerator MoveObjects()
    {
        // ����������Ҫ�ƶ�������
        foreach (Transform obj in objectsToMove)
        {
            // �ƶ����嵽 X ����Ϊ 0 ��λ��
            yield return StartCoroutine(MoveObject(obj, new Vector3(0f, obj.position.y, obj.position.z)));

            // �ȴ����ʱ��
            yield return new WaitForSeconds(interval);
        }
    }

    IEnumerator MoveObject(Transform obj, Vector3 targetPosition)
    {
        // �ƶ����嵽Ŀ��λ��
        float elapsedTime = 0f;
        Vector3 startingPos = obj.position;

        while (elapsedTime < 2f) // ��������ƶ�ʱ��Ϊ 1 �룬����Ը�����Ҫ����
        {
            obj.position = Vector3.Lerp(startingPos, targetPosition, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.position = targetPosition;
    }
}
