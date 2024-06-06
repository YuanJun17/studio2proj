using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;

public class buttonController : MonoBehaviour
{
    public Transform[] objectsToMove; // 需要移动的物体数组
    public float moveDistance = 10f; // 移动的距离
    public float moveSpeed; // 移动的速度
    private bool isMoving = false;

    private int currentIndex = 0;
    private enum LogicValue { True, False, Any }; // 枚举表示true、false和任意值
    private LogicValue[] moveLogicSequence = { LogicValue.True, LogicValue.True, LogicValue.False, LogicValue.False, LogicValue.True}; // 例如：true, true, false, true

    private bool isLogicCompleted = false; // 标记逻辑是否完成一轮
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

            // 判断当前值和按钮按下的值是否匹配
            if ((isYesButton && currentValue == LogicValue.True) || (!isYesButton && currentValue == LogicValue.False))
            {
                Vector3 moveDirection = Vector3.up; // 默认移动方向为向上
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

        // 移动完成后，将已移动的物体从数组中移除
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
