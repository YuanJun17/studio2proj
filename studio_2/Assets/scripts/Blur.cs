using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blur : MonoBehaviour
{
    public Shader blurShader; // 模糊效果的 Shader
    private Material blurMaterial; // 模糊效果的材质
    private float blurStrength = 5.0f; // 初始模糊强度
    private float blurTime = 0.0f; // 初始模糊时间参数
    private bool mouseClicked = false; // 鼠标点击状态
    public float timespeed = 0.05f;
    void Start()
    {
        // 创建模糊效果的材质
        blurMaterial = new Material(blurShader);
    }

    void Update()
    {
        // 更新模糊时间参数为当前时间
        blurTime += timespeed * Time.deltaTime;

        // 检测鼠标左键是否点击
        if (Input.GetMouseButtonDown(0))
        {
            // 鼠标点击时，修改鼠标点击状态为真
            mouseClicked = true;
        }
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        qteDestory.OnQTEDestroyed += HandleQTEDestroyed;
        
        // 设置着色器参数
        blurMaterial.SetFloat("_BlurStrength", blurStrength);
        blurMaterial.SetFloat("_BlurTime", blurTime);
        Graphics.Blit(src, dest, blurMaterial);
    }
    void HandleQTEDestroyed()
    {
        // 减小模糊强度
        blurTime -= 1.0f;
        blurTime = Mathf.Max(blurTime, 0.0f); // 确保模糊强度不小于0
    }
}
