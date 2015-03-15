// Unlit shader. Simplest possible textured shader.
// - no lighting
// - no lightmap support
// - no per-material color

Shader "BuildingGlowPostProcess" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_BlurDir ("Blur dir", Vector) = (0.0, 0.0, 0.0, 0.0)
}

SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 100
	
	Pass {  
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata_t {
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				half2 texcoord : TEXCOORD0;
				UNITY_FOG_COORDS(1)
			};

			sampler2D _MainTex;
			
			float2 _BlurDir;
			float4 _MainTex_ST;
			
			float2 _MainTex_TexelSize;
			
			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float2 blur = _BlurDir.xy * _MainTex_TexelSize.xy;
				
				fixed4 col = tex2D(_MainTex, i.texcoord - 4.0 * blur) * 0.05;
				col += tex2D(_MainTex, i.texcoord - 3.0*blur) * 0.09;
				col += tex2D(_MainTex, i.texcoord - 2.0*blur) * 0.12;
				col += tex2D(_MainTex, i.texcoord - blur) * 0.15;
				col += tex2D(_MainTex, i.texcoord) * 0.16;
				col += tex2D(_MainTex, i.texcoord + blur) * 0.15;
				col += tex2D(_MainTex, i.texcoord + 2.0*blur) * 0.12;
				col += tex2D(_MainTex, i.texcoord + 3.0*blur) * 0.09;
				col += tex2D(_MainTex, i.texcoord + 4.0*blur) * 0.05;

				UNITY_OPAQUE_ALPHA(col.a);
				return col;
			}
		ENDCG
	}
}

}
