using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    public Transform target; // 目标
    public float searchSpeed; // 瞄准速度
    public float shootTime; // 射击速度
    public float shootSize; // 射击大小

    enum AimState : byte
    {
        none = 0,
        search = 1,
        shoot = 2,

    }
    AimState aimState;
    Vector3 shootScale;


    // Start is called before the first frame update
    void Start()
    {
        aimState = AimState.none;
        shootScale = Vector3.one* shootSize;

        InitAim();
    }

    // Update is called once per frame
    void Update()
    {
        if(aimState == AimState.search)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, searchSpeed * Time.deltaTime);

            // 如果到达目标位置，停止移动
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                aimState = AimState.shoot;
                StartCoroutine(ShootEffect());//创建协程
            }
        }
    }

    //重置
    void InitAim()
    {
        transform.localScale = new Vector3(1,1,1);

        Vector3 posAim = target.position;
        posAim.x += (Random.value * 2 - 1 > 0 ? 1 : -1) * 60;
        posAim.y += 30;
        transform.position = posAim;

        aimState = AimState.search;
    }

    IEnumerator ShootEffect()
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < shootTime)
        {
            // 计算当前的缩放比例
            float t = elapsedTime / shootTime;
            transform.localScale = Vector3.Lerp(transform.localScale, shootScale, t);

            elapsedTime += Time.deltaTime;
            yield return null; // 暂停一帧继续执行
        }

        // 确保最终达到目标大小
        transform.localScale = shootScale;

        //判断是否命中
        CircleCollider2D cc = GetComponent<CircleCollider2D>();
        CapsuleCollider2D tc = target.GetComponent<CapsuleCollider2D>();
        if(cc.IsTouching(tc))
        {
            target.GetComponent<charactercontroller>().Die();
        }
        //重置
        InitAim();
    }
}
