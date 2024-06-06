using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontroller : MonoBehaviour
{
    public float walkspeed;
    public Rigidbody2D myrigidbody;
    public Animator myanim;
    public Transform characterRootBone; // ��ɫģ���еĹ���������ȷ�����λ��

    

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myanim = GetComponent<Animator>();
       

    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Filp();
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);

        if (Input.GetKeyDown(KeyCode.K))
        {
            // ����������Trigger
            myanim.SetTrigger("pu");
            //hasPlayedFeipu = true; // �������Ϊtrue����ʾ���˶����Ѿ����Ź�
        }
    }
    void Run()
    {
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveDir * walkspeed, myrigidbody.velocity.y);
        myrigidbody.velocity = playerVel;
        bool playerHasXAxisSpeed = Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon;
        myanim.SetBool("run", playerHasXAxisSpeed);


    }
    void Filp()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasXAxisSpeed)
        {
            if (myrigidbody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (myrigidbody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    public void MoveCharacterToLandingBone()
    {
        if (myanim != null && characterRootBone != null)
        {
            // ��ȡ��������λ�ã���ֻʹ���� X ֵ
            float landingXPosition = characterRootBone.position.x;

            // �ƶ���ɫ�����λ�õ�Xֵ
            Vector3 newPosition = transform.position;
            newPosition.x = landingXPosition;
            transform.position = newPosition;
        }
        else
        {
            Debug.LogWarning("δ����Animator�������������");
        }
    }

    public void Die()
    {
        transform.position = new Vector3(0, 0, 0);
    }
}
