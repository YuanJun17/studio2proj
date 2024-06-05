using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class backgroundfollow : MonoBehaviour
{
    public Transform target; // ��ҵ�Transform
    public float rotationSpeed = 1.0f; // ��ת�ٶ�
    public Vector3 offset; // ��������֮���ƫ����
    public float delayTime = 10.0f; // �ӳٿ�ʼ��ת��ʱ��
    public float stopInputDelay = 2.0f; // ��ת��180�Ⱥ�ֹͣ������ӳ�ʱ��

    private float timer = 0.0f;
    private bool canRotate = false;
    private float totalRotation = 0f; // ���ڸ�����ת���ܽǶ�
    private bool stopInput = false;
    private float stopInputTimer = 0.0f;

    public PlayableDirector timelineDirector;

    public charactercontroller charactercontroller;
    public FruitUI fruitUI;
    private void Start()
    {
        timelineDirector.Pause();
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delayTime)
        {
            canRotate = true;
        }
        if (stopInput)
        {
            stopInputTimer += Time.deltaTime;
            if (stopInputTimer >= stopInputDelay || fruitUI.fruitCount == fruitUI.targetFruitCount)
            {
                charactercontroller.myanim.SetTrigger("stop");
                charactercontroller.enabled = false;
                // �ڴ˴����ֹͣ������߼��������ֹ�ƶ���
                // ���磺playerController.enabled = false;
                // ע�⣺����Ҫȷ�� playerController ������������ȷ�Ľ�ɫ������
                PlayTimeline();

            }
        }
        

    }
    void LateUpdate()
    {
        if (target != null)
        {
            // �������
            transform.position = target.position + offset;

            if (canRotate && !stopInput)
            {
                // �����ת�Ƕ��Ƿ�ﵽ180��
                if (totalRotation < 180f)
                {
                    // ������ʱ����ת
                    transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
                    totalRotation += rotationSpeed * Time.deltaTime;
                }
                else
                {
                    // ��ת��ɺ�ʼ��ʱ�ȴ�ֹͣ����
                    stopInput = true;
                }
            }
        }
    }
    void PlayTimeline()
    {
        if (timelineDirector != null)
        {
            timelineDirector.Play();
            
        }
    }
}
