using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class backgroundfollow : MonoBehaviour
{
    public Transform target; // 玩家的Transform
    public float rotationSpeed = 1.0f; // 旋转速度
    public Vector3 offset; // 相机与玩家之间的偏移量
    public float delayTime = 10.0f; // 延迟开始旋转的时间
    public float stopInputDelay = 2.0f; // 旋转到180度后停止输入的延迟时间

    private float timer = 0.0f;
    private bool canRotate = false;
    private float totalRotation = 0f; // 用于跟踪旋转的总角度
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
                // 在此处添加停止输入的逻辑，例如禁止移动等
                // 例如：playerController.enabled = false;
                // 注意：你需要确保 playerController 变量引用了正确的角色控制器
                PlayTimeline();

            }
        }
        

    }
    void LateUpdate()
    {
        if (target != null)
        {
            // 跟随玩家
            transform.position = target.position + offset;

            if (canRotate && !stopInput)
            {
                // 检查旋转角度是否达到180度
                if (totalRotation < 180f)
                {
                    // 自身逆时针旋转
                    transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
                    totalRotation += rotationSpeed * Time.deltaTime;
                }
                else
                {
                    // 旋转完成后开始计时等待停止输入
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
