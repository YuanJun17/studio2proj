using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin_enemy : MonoBehaviour
{
    public float walkspeed;
    public Rigidbody2D myrigidbody;
    public Animator myanim;
    public Transform characterRootBone; // 角色模型中的骨骼，用于确定落点位置

    private Vector3 Target;

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myanim = GetComponent<Animator>();

        Target = new Vector3(Random.Range(-140, 140), transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Target);
        if(distance < 1)
        {
            setTarget();
        }
        move();
    }

    //随机目标位置
    void setTarget()
    {
        Target.Set(Random.Range(-140,140), transform.position.y, transform.position.z);
        return ;
    }

    void move()
    {
        float moveDir = Target.x - transform.position.x;
        Vector2 playerVel = new Vector2((moveDir>0? 1: -1) * walkspeed, myrigidbody.velocity.y);
        myrigidbody.velocity = playerVel;
        bool playerHasXAxisSpeed = Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon;
        myanim.SetBool("run", playerHasXAxisSpeed);

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
