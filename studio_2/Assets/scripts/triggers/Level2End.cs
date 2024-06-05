using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Level2End : MonoBehaviour
{
    public FruitUI fruitUI; // ����FruitUI�ű�
    public PlayableDirector timelineDirector; // ����PlayableDirector������Timeline
    public MonoBehaviour script1; // ���ýű�1
    public MonoBehaviour script2; // ���ýű�2
    public int testTargetNum;

    private void Start()
    {
        // ȷ��Timelineһ��ʼ��ֹͣ��
        if (timelineDirector != null)
        {
            timelineDirector.Stop();
        }
        else
        {
            Debug.LogError("Timeline Director is not assigned!");
        }
    }
    private void Update()
    {
        if (fruitUI.fruitCount >= testTargetNum)
        {
            StopScriptsAndPlayTimeline();
        }
    }

    // ֹͣ�ű�������Timeline
    private void StopScriptsAndPlayTimeline()
    {
        script1.enabled = false; // ֹͣ�ű�1
        script2.enabled = false; // ֹͣ�ű�2

        if (timelineDirector != null)
        {
            timelineDirector.Play(); // ����Timeline
        }
        else
        {
            Debug.LogError("Timeline Director is not assigned!");
        }

        // ���������Է�ֹ�ظ�����
        this.enabled = false;
    }
}
