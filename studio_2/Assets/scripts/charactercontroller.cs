using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontroller : MonoBehaviour
{
    public float walkspeed;
    public Rigidbody2D myrigidbody;
    public Animator myanim;
    public Transform characterRootBone; // 角色模型中的骨骼，用于确定落点位置

    

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
       
        if (Input.GetKeyDown(KeyCode.K))
        {
            // 触发动画的Trigger
            myanim.SetTrigger("pu");
            //hasPlayedFeipu = true; // 将标记设为true，表示飞扑动画已经播放过
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
            // 获取落点骨骼的位置，并只使用其 X 值
            float landingXPosition = characterRootBone.position.x;

            // 移动角色到落点位置的X值
            Vector3 newPosition = transform.position;
            newPosition.x = landingXPosition;
            transform.position = newPosition;
        }
        else
        {
            Debug.LogWarning("未设置Animator组件或落点骨骼！");
        }
    }
}
