using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    public Transform target; // Ŀ��
    public float searchSpeed; // ��׼�ٶ�
    public float shootTime; // ����ٶ�
    public float shootSize; // �����С

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

            // �������Ŀ��λ�ã�ֹͣ�ƶ�
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                aimState = AimState.shoot;
                StartCoroutine(ShootEffect());//����Э��
            }
        }
    }

    //����
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
            // ���㵱ǰ�����ű���
            float t = elapsedTime / shootTime;
            transform.localScale = Vector3.Lerp(transform.localScale, shootScale, t);

            elapsedTime += Time.deltaTime;
            yield return null; // ��ͣһ֡����ִ��
        }

        // ȷ�����մﵽĿ���С
        transform.localScale = shootScale;

        //�ж��Ƿ�����
        CircleCollider2D cc = GetComponent<CircleCollider2D>();
        CapsuleCollider2D tc = target.GetComponent<CapsuleCollider2D>();
        if(cc.IsTouching(tc))
        {
            target.GetComponent<charactercontroller>().Die();
        }
        //����
        InitAim();
    }
}
