Shader "Custom/blur"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlurStrength ("Blur Strength", Range(0, 10)) = 1.0
        
        _TimeSpeed ("Time Speed", Float) = 1.0 // 时间速度参数
   
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        // 在这里定义渲染模型的着色代码
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            // 包括Unity提供的着色库
            #include "UnityCG.cginc"

            // 传递从顶点着色器到片段着色器的结构体
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            // 标准顶点着色器
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            // 标准片段着色器，实现上下左右高斯模糊
            sampler2D _MainTex;
            float _BlurStrength;
            float _BlurTime;


            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = fixed4(0, 0, 0, 0);
                float blurSize = _BlurStrength * 0.005*_BlurTime*0.1;

                for(int x = -4; x <= 4; x++)
                {
                    for(int y = -4; y <= 4; y++)
                    {
                        float2 offset = float2(x, y) * blurSize;
                        col += tex2D(_MainTex, i.uv + offset);
                    }
                }

                col /= 81; // 模糊核的大小，这里是 9x9 的核

                // 让模糊效果随时间变暗
                col *= (1.0 - (_BlurTime * 0.02)); // 使用时间参数控制模糊效果

                return col;
            }
            ENDCG
        }
    }
}