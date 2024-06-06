using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;

public class buttonController : MonoBehaviour
{
    public Transform[] objectsToMove; // ��Ҫ�ƶ�����������
    public float moveDistance = 10f; // �ƶ��ľ���
    public float moveSpeed; // �ƶ����ٶ�
    private bool isMoving = false;

    private int currentIndex = 0;
    private enum LogicValue { True, False, Any }; // ö�ٱ�ʾtrue��false������ֵ
    private LogicValue[] moveLogicSequence = { LogicValue.True, LogicValue.True, LogicValue.False, LogicValue.False, LogicValue.True}; // ���磺true, true, false, true

    private bool isLogicCompleted = false; // ����߼��Ƿ����һ��
    public PlayableDirector timelineDirector;
  
    private void Start()
    {
        timelineDirector.Pause();
        yesbutton.OnButtonPressed += HandleButtonPressed;
        nobutton.OnButtonPressed += HandleButtonPressed;
    }
    void HandleButtonPressed(bool isYesButton)
    {
        if (!isMoving && currentIndex < moveLogicSequence.Length && !isLogicCompleted)
        {
            LogicValue currentValue = moveLogicSequence[currentIndex];

            // �жϵ�ǰֵ�Ͱ�ť���µ�ֵ�Ƿ�ƥ��
            if ((isYesButton && currentValue == LogicValue.True) || (!isYesButton && currentValue == LogicValue.False))
            {
                Vector3 moveDirection = Vector3.up; // Ĭ���ƶ�����Ϊ����
                MoveObject(objectsToMove[currentIndex], moveDirection);
            }
        }
    }
    void MoveObject(Transform obj, Vector3 moveDirection)
    {
        if (obj != null)
        {
            Vector3 targetPosition = obj.position + moveDirection * moveDistance;
            StartCoroutine(MoveObjectCoroutine(obj, targetPosition));
        }
    }

    IEnumerator MoveObjectCoroutine(Transform obj, Vector3 targetPosition)
    {
        isMoving = true;

        float elapsedTime = 0f;
        Vector3 startingPosition = obj.position;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * moveSpeed;
            obj.position = Vector3.Lerp(startingPosition, targetPosition, Mathf.SmoothStep(0f, 1f, elapsedTime));
            yield return null;
        }

        isMoving = false;
        currentIndex++;

        // �ƶ���ɺ󣬽����ƶ���������������Ƴ�
        if (currentIndex >= objectsToMove.Length)
        {
            currentIndex = 0;
            isLogicCompleted = true;
            if (timelineDirector != null)
            {
                timelineDirector.Play();
            }
            else
            {
                Debug.LogError("Timeline Director is not assigned!");
            }
        }
    }

}
