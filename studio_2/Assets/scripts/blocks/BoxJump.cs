using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxJump : MonoBehaviour
{
    public float jumpForce = 10f; // 跳跃力度
    public Transform groundCheck; // 用于检测地面的射线起点
    public LayerMask groundLayer; // 地面所在的图层

    private bool isGrounded; // 是否在地面上
    private Quaternion initialRotation; // 初始旋转角度

    void Start()
    {
        initialRotation = transform.rotation; // 记录初始旋转角度
    }
    void Update()
    {
        transform.rotation = initialRotation;
        // 检测空格键是否被按下
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            
            Jump();
        }
    }
    void FixedUpdate()
    {
        // 检测是否在地面上
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    void Jump()
    {
       
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);

    }
}
