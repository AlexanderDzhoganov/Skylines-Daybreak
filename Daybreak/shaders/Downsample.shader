Shader "Downsample" {
        SubShader {
            Pass {
            ZTest Always Cull Off ZWrite Off Blend Off //Cull Off ZWrite Off Lighting Off
            Fog { Mode off }
           
                CGPROGRAM
   
                #pragma vertex vert
                #pragma fragment frag
   
                float4 vert(float4 v:POSITION) : SV_POSITION {
                    return mul (UNITY_MATRIX_MVP, v);
                }
   
                fixed4 frag() : COLOR {
                    return fixed4(1.0,0.0,0.0,1.0);
                }
   
                ENDCG
            }
        }
    }