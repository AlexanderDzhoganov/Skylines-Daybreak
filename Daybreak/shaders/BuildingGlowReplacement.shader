Shader "BuildingReplacement" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_XYSMap ("Base (RGB)", 2D) = "white" {}
}
SubShader {
	Tags { "RenderType"="Opaque" "ForceNoShadowCasting"="True" }
	LOD 200

CGPROGRAM
#pragma surface surf Lambert

sampler2D _MainTex;
sampler2D _XYSMap;

struct Input {
	float2 uv_MainTex;
};

void surf (Input IN, inout SurfaceOutput o) {
	o.Albedo = fixed3(0.0, 0.0, 0.0);
	o.Alpha = 1.0;
	fixed3 s = tex2D(_XYSMap, IN.uv_MainTex).rgb;
	o.Emission = fixed3(s.g - s.b, s.g - s.b, s.g - s.b);
}
ENDCG
}

Fallback "Legacy Shaders/VertexLit"
}
