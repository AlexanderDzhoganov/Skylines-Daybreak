namespace Daybreak
{
    public static class Shaders
    {

        public static readonly string buildingGlowPPv5 = @"// Compiled shader for all platforms, uncompressed size: 12.2KB

// Skipping shader variants that would not be included into build of current scene.

Shader ""BuildingGlowPostProcess"" {
Properties {
 _MainTex (""Base (RGB)"", 2D) = ""white"" { }
 _GlowTex (""Glow"", 2D) = ""white"" { }
 _GlowColor (""Glow color"", Color) = (1,1,0,1)
 _GlowIntensity (""Glow intensity"", Float) = 0
}
SubShader { 
 LOD 100
 Tags { ""RenderType""=""Opaque"" }


 // Stats for Vertex shader:
 //       d3d11 : 5 math
 //    d3d11_9x : 5 math
 //        d3d9 : 5 math
 //        gles : 4 math, 2 texture
 //       gles3 : 4 math, 2 texture
 //       metal : 3 math
 //      opengl : 4 math, 2 texture
 // Stats for Fragment shader:
 //       d3d11 : 2 math, 2 texture
 //    d3d11_9x : 2 math, 2 texture
 //        d3d9 : 4 math, 2 texture
 //       metal : 4 math, 2 texture
 Pass {
  Tags { ""RenderType""=""Opaque"" }
  GpuProgramID 32527
Program ""vp"" {
SubProgram ""opengl "" {
// Stats: 4 math, 2 textures
""!!GLSL
#ifdef VERTEX

uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
uniform sampler2D _GlowTex;
uniform vec4 _GlowColor;
uniform float _GlowIntensity;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  vec4 col_1;
  col_1.xyz = (texture2D (_MainTex, xlv_TEXCOORD0) + ((texture2D (_GlowTex, xlv_TEXCOORD0).x * _GlowColor) * _GlowIntensity)).xyz;
  col_1.w = 1.0;
  gl_FragData[0] = col_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 5 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_ST]
""vs_2_0
dcl_position v0
dcl_texcoord v1
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
mad oT0.xy, v1, c4, c4.zwzw

""
}
SubProgram ""d3d11 "" {
// Stats: 5 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 144
Vector 128 [_MainTex_ST]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerDraw"" 1
""vs_4_0
eefiecedifeefokjmglbfpcohifihgjdikcggpkeabaaaaaaamacaaaaadaaaaaa
cmaaaaaaiaaaaaaaniaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaa
aaaaaaaaaiaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 4 math, 2 textures
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesMultiTexCoord0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp vec4 _MainTex_ST;
varying mediump vec2 xlv_TEXCOORD0;
void main ()
{
  mediump vec2 tmpvar_1;
  highp vec2 tmpvar_2;
  tmpvar_2 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_2;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform sampler2D _GlowTex;
uniform highp vec4 _GlowColor;
uniform highp float _GlowIntensity;
varying mediump vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 col_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture2D (_MainTex, xlv_TEXCOORD0);
  lowp vec4 tmpvar_3;
  tmpvar_3 = texture2D (_GlowTex, xlv_TEXCOORD0);
  highp vec4 tmpvar_4;
  tmpvar_4 = (tmpvar_2 + ((tmpvar_3.x * _GlowColor) * _GlowIntensity));
  col_1.xyz = tmpvar_4.xyz;
  col_1.w = 1.0;
  gl_FragData[0] = col_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 5 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 144
Vector 128 [_MainTex_ST]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerDraw"" 1
""vs_4_0_level_9_1
eefiecedlnonibommofomijdcpinjibjijgnbhjkabaaaaaapiacaaaaaeaaaaaa
daaaaaaabiabaaaaemacaaaakaacaaaaebgpgodjoaaaaaaaoaaaaaaaaaacpopp
kaaaaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaiaa
abaaabaaaaaaaaaaabaaaaaaaeaaacaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjaaeaaaaaeaaaaadoaabaaoeja
abaaoekaabaaookaafaaaaadaaaaapiaaaaaffjaadaaoekaaeaaaaaeaaaaapia
acaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaeaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiaafaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaa
aaaaaaaaaiaaaaaadoaaaaabejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 4 math, 2 textures
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesMultiTexCoord0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp vec4 _MainTex_ST;
out mediump vec2 xlv_TEXCOORD0;
void main ()
{
  mediump vec2 tmpvar_1;
  highp vec2 tmpvar_2;
  tmpvar_2 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_2;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform sampler2D _GlowTex;
uniform highp vec4 _GlowColor;
uniform highp float _GlowIntensity;
in mediump vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 col_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture (_MainTex, xlv_TEXCOORD0);
  lowp vec4 tmpvar_3;
  tmpvar_3 = texture (_GlowTex, xlv_TEXCOORD0);
  highp vec4 tmpvar_4;
  tmpvar_4 = (tmpvar_2 + ((tmpvar_3.x * _GlowColor) * _GlowIntensity));
  col_1.xyz = tmpvar_4.xyz;
  col_1.w = 1.0;
  _glesFragData[0] = col_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 3 math
Bind ""vertex"" ATTR0
Bind ""texcoord"" ATTR1
ConstBuffer ""$Globals"" 80
Matrix 0 [glstate_matrix_mvp]
Vector 64 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float4 _glesMultiTexCoord0 [[attribute(1)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  half2 xlv_TEXCOORD0;
};
struct xlatMtlShaderUniform {
  float4x4 glstate_matrix_mvp;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half2 tmpvar_1;
  float2 tmpvar_2;
  tmpvar_2 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  tmpvar_1 = half2(tmpvar_2);
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = tmpvar_1;
  return _mtl_o;
}

""
}
}
Program ""fp"" {
SubProgram ""opengl "" {
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 4 math, 2 textures
Vector 0 [_GlowColor]
Float 1 [_GlowIntensity]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_GlowTex] 2D 1
""ps_2_0
def c2, 1, 0, 0, 0
dcl_pp t0.xy
dcl_2d s0
dcl_2d s1
texld r0, t0, s1
texld_pp r1, t0, s0
mul r0.xyz, r0.x, c0
mad_pp r0.xyz, r0, c1.x, r1
mov_pp r0.w, c2.x
mov_pp oC0, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 2 math, 2 textures
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_GlowTex] 2D 1
ConstBuffer ""$Globals"" 144
Vector 96 [_GlowColor]
Float 112 [_GlowIntensity]
BindCB  ""$Globals"" 0
""ps_4_0
eefiecediepmkjkadiillfokimnbpegnipfhcejgabaaaaaaniabaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcbiabaaaa
eaaaaaaaegaaaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaa
abaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaihcaabaaaaaaaaaaa
agaabaaaaaaaaaaaegiccaaaaaaaaaaaagaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaakhccabaaa
aaaaaaaaegacbaaaaaaaaaaaagiacaaaaaaaaaaaahaaaaaaegacbaaaabaaaaaa
dgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab""
}
SubProgram ""gles "" {
""!!GLES""
}
SubProgram ""d3d11_9x "" {
// Stats: 2 math, 2 textures
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_GlowTex] 2D 1
ConstBuffer ""$Globals"" 144
Vector 96 [_GlowColor]
Float 112 [_GlowIntensity]
BindCB  ""$Globals"" 0
""ps_4_0_level_9_1
eefiecedehaldamjfhnkkbpnglmihgjnmmajgppiabaaaaaalmacaaaaaeaaaaaa
daaaaaaabaabaaaadaacaaaaiiacaaaaebgpgodjniaaaaaaniaaaaaaaaacpppp
kaaaaaaadiaaaaaaabaacmaaaaaadiaaaaaadiaaacaaceaaaaaadiaaaaaaaaaa
abababaaaaaaagaaacaaaaaaaaaaaaaaaaacppppfbaaaaafacaaapkaaaaaiadp
aaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaacdlabpaaaaacaaaaaaja
aaaiapkabpaaaaacaaaaaajaabaiapkaecaaaaadaaaaapiaaaaaoelaabaioeka
ecaaaaadabaacpiaaaaaoelaaaaioekaafaaaaadaaaaahiaaaaaaaiaaaaaoeka
aeaaaaaeaaaachiaaaaaoeiaabaaaakaabaaoeiaabaaaaacaaaaciiaacaaaaka
abaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcbiabaaaaeaaaaaaaegaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaa
abaaaaaaaagabaaaabaaaaaadiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaa
egiccaaaaaaaaaaaagaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaakhccabaaaaaaaaaaaegacbaaa
aaaaaaaaagiacaaaaaaaaaaaahaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaiadpdoaaaaabejfdeheofaaaaaaaacaaaaaaaiaaaaaa
diaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaadadaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 4 math, 2 textures
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_GlowTex] 2D 1
ConstBuffer ""$Globals"" 20
Vector 0 [_GlowColor]
Float 16 [_GlowIntensity]
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  half2 xlv_TEXCOORD0;
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
  float4 _GlowColor;
  float _GlowIntensity;
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]]
  ,   texture2d<half> _MainTex [[texture(0)]], sampler _mtlsmp__MainTex [[sampler(0)]]
  ,   texture2d<half> _GlowTex [[texture(1)]], sampler _mtlsmp__GlowTex [[sampler(1)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 col_1;
  half4 tmpvar_2;
  tmpvar_2 = _MainTex.sample(_mtlsmp__MainTex, (float2)(_mtl_i.xlv_TEXCOORD0));
  half4 tmpvar_3;
  tmpvar_3 = _GlowTex.sample(_mtlsmp__GlowTex, (float2)(_mtl_i.xlv_TEXCOORD0));
  float4 tmpvar_4;
  tmpvar_4 = ((float4)tmpvar_2 + (((float)tmpvar_3.x * _mtl_u._GlowColor) * _mtl_u._GlowIntensity));
  col_1.xyz = half3(tmpvar_4.xyz);
  col_1.w = half(1.0);
  _mtl_o._glesFragData_0 = col_1;
  return _mtl_o;
}

""
}
}
 }
}
}";

        public static readonly string buildingGlowPP_Depth = @"// Compiled shader for all platforms, uncompressed size: 9.0KB

// Skipping shader variants that would not be included into build of current scene.

Shader ""BuildingGlowPostProcessDepth"" {
Properties {
 _MainTex (""Base (RGB)"", 2D) = ""white"" { }
 _GlowTex (""Glow"", 2D) = ""white"" { }
 _GlowColor (""Glow color"", Color) = (1,1,0,1)
 _GlowIntensity (""Glow intensity"", Float) = 0
}
SubShader { 
 LOD 100
 Tags { ""RenderType""=""Opaque"" }


 // Stats for Vertex shader:
 //       d3d11 : 5 math
 //    d3d11_9x : 5 math
 //        d3d9 : 7 math
 //        gles : 1 math
 //       gles3 : 1 math
 //       metal : 3 math
 //      opengl : 1 math
 // Stats for Fragment shader:
 //        d3d9 : 3 math
 //       metal : 1 math
 Pass {
  Tags { ""RenderType""=""Opaque"" }
  Fog { Mode Off }
  GpuProgramID 51334
Program ""vp"" {
SubProgram ""opengl "" {
// Stats: 1 math
""!!GLSL
#ifdef VERTEX

uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
void main ()
{
  gl_FragData[0] = vec4(0.0, 0.0, 0.0, 0.0);
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 7 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_ST]
""vs_2_0
dcl_position v0
dcl_texcoord v1
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
mad oT0.xy, v1, c4, c4.zwzw
dp4 r0.z, c2, v0
dp4 r0.w, c3, v0
mov oPos.zw, r0
mov oT1.xy, r0.zwzw

""
}
SubProgram ""d3d11 "" {
// Stats: 5 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 144
Vector 128 [_MainTex_ST]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerDraw"" 1
""vs_4_0
eefiecedkmmldncbmghhlgegjpkhhoaachjnibnmabaaaaaaceacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamapaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaklklklfdeieefccmabaaaaeaaaabaaelaaaaaa
fjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaacabaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaa
doaaaaab""
}
SubProgram ""gles "" {
// Stats: 1 math
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesMultiTexCoord0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp vec4 _MainTex_ST;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec2 xlv_TEXCOORD1;
void main ()
{
  mediump vec2 tmpvar_1;
  highp vec2 tmpvar_2;
  highp vec2 tmpvar_3;
  tmpvar_3 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_3;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_2;
}



#endif
#ifdef FRAGMENT

void main ()
{
  gl_FragData[0] = vec4(0.0, 0.0, 0.0, 0.0);
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 5 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 144
Vector 128 [_MainTex_ST]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerDraw"" 1
""vs_4_0_level_9_1
eefiecedhjdjdihdmlmlbbejnaleaaloeblmclmlabaaaaaabaadaaaaaeaaaaaa
daaaaaaabiabaaaaemacaaaakaacaaaaebgpgodjoaaaaaaaoaaaaaaaaaacpopp
kaaaaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaiaa
abaaabaaaaaaaaaaabaaaaaaaeaaacaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjaaeaaaaaeaaaaadoaabaaoeja
abaaoekaabaaookaafaaaaadaaaaapiaaaaaffjaadaaoekaaeaaaaaeaaaaapia
acaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaeaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiaafaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaa
aaaaaaaaaiaaaaaadoaaaaabejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamapaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 1 math
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesMultiTexCoord0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp vec4 _MainTex_ST;
out mediump vec2 xlv_TEXCOORD0;
out highp vec2 xlv_TEXCOORD1;
void main ()
{
  mediump vec2 tmpvar_1;
  highp vec2 tmpvar_2;
  highp vec2 tmpvar_3;
  tmpvar_3 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_3;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_2;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
void main ()
{
  _glesFragData[0] = vec4(0.0, 0.0, 0.0, 0.0);
}



#endif""
}
SubProgram ""metal "" {
// Stats: 3 math
Bind ""vertex"" ATTR0
Bind ""texcoord"" ATTR1
ConstBuffer ""$Globals"" 80
Matrix 0 [glstate_matrix_mvp]
Vector 64 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float4 _glesMultiTexCoord0 [[attribute(1)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  half2 xlv_TEXCOORD0;
  float2 xlv_TEXCOORD1;
};
struct xlatMtlShaderUniform {
  float4x4 glstate_matrix_mvp;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half2 tmpvar_1;
  float2 tmpvar_2;
  float2 tmpvar_3;
  tmpvar_3 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  tmpvar_1 = half2(tmpvar_3);
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = tmpvar_1;
  _mtl_o.xlv_TEXCOORD1 = tmpvar_2;
  return _mtl_o;
}

""
}
}
Program ""fp"" {
SubProgram ""opengl "" {
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 3 math
""ps_2_0
dcl t1.xy
rcp r0.w, t1.y
mul_pp r0, r0.w, t1.x
mov_pp oC0, r0

""
}
SubProgram ""d3d11 "" {
""ps_4_0
eefiecedbiflgegpckmgpaphhcfpfmnfcmifolcaabaaaaaabaabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdiaaaaaaeaaaaaaaaoaaaaaa
gfaaaaadpccabaaaaaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaadoaaaaab""
}
SubProgram ""gles "" {
""!!GLES""
}
SubProgram ""d3d11_9x "" {
""ps_4_0_level_9_1
eefiecedfndfemipamadjlmifjbednefocpmgiejabaaaaaahiabaaaaaeaaaaaa
daaaaaaajeaaaaaaneaaaaaaeeabaaaaebgpgodjfmaaaaaafmaaaaaaaaacpppp
diaaaaaaceaaaaaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaacpppp
fbaaaaafaaaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaacaaaacpia
aaaaaakaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcdiaaaaaaeaaaaaaa
aoaaaaaagfaaaaadpccabaaaaaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadoaaaaabejfdeheogiaaaaaaadaaaaaa
aiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadaaaaaafmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaabaaaaaaamaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 1 math
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  _mtl_o._glesFragData_0 = half4(float4(0.0, 0.0, 0.0, 0.0));
  return _mtl_o;
}

""
}
}
 }
}
}";

        public static readonly string buildingBlurPP_V3 = @"// Compiled shader for all platforms, uncompressed size: 15.7KB

// Skipping shader variants that would not be included into build of current scene.

Shader ""BuildingGlowPostProcess"" {
Properties {
 _MainTex (""Base (RGB)"", 2D) = ""white"" { }
 _BlurDir (""Blur dir"", Vector) = (0,0,0,0)
}
SubShader { 
 LOD 100
 Tags { ""RenderType""=""Opaque"" }


 // Stats for Vertex shader:
 //       d3d11 : 5 math
 //    d3d11_9x : 5 math
 //        d3d9 : 5 math
 //        gles : 17 math, 5 texture
 //       gles3 : 17 math, 5 texture
 //       metal : 3 math
 //      opengl : 17 math, 5 texture
 // Stats for Fragment shader:
 //       d3d11 : 10 math, 5 texture
 //    d3d11_9x : 10 math, 5 texture
 //        d3d9 : 13 math, 5 texture
 //       metal : 17 math, 5 texture
 Pass {
  Tags { ""RenderType""=""Opaque"" }
  GpuProgramID 38410
Program ""vp"" {
SubProgram ""opengl "" {
// Stats: 17 math, 5 textures
""!!GLSL
#ifdef VERTEX

uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
uniform vec2 _BlurDir;
uniform vec2 _MainTex_TexelSize;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  vec4 col_1;
  vec2 tmpvar_2;
  tmpvar_2 = (_BlurDir * _MainTex_TexelSize);
  col_1.xyz = (((
    ((texture2D (_MainTex, (xlv_TEXCOORD0 - (2.0 * tmpvar_2))) * 0.12) + (texture2D (_MainTex, (xlv_TEXCOORD0 - tmpvar_2)) * 0.2))
   + 
    (texture2D (_MainTex, xlv_TEXCOORD0) * 0.36)
  ) + (texture2D (_MainTex, 
    (xlv_TEXCOORD0 + tmpvar_2)
  ) * 0.2)) + (texture2D (_MainTex, (xlv_TEXCOORD0 + 
    (2.0 * tmpvar_2)
  )) * 0.12)).xyz;
  col_1.w = 1.0;
  gl_FragData[0] = col_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 5 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_ST]
""vs_2_0
dcl_position v0
dcl_texcoord v1
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
mad oT0.xy, v1, c4, c4.zwzw

""
}
SubProgram ""d3d11 "" {
// Stats: 5 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 144
Vector 112 [_MainTex_ST]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerDraw"" 1
""vs_4_0
eefiecediclbinofmafhnpjgnjjnoeonbagdabifabaaaaaaamacaaaaadaaaaaa
cmaaaaaaiaaaaaaaniaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaa
aaaaaaaaahaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 17 math, 5 textures
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesMultiTexCoord0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp vec4 _MainTex_ST;
varying mediump vec2 xlv_TEXCOORD0;
void main ()
{
  mediump vec2 tmpvar_1;
  highp vec2 tmpvar_2;
  tmpvar_2 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_2;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform highp vec2 _BlurDir;
uniform highp vec2 _MainTex_TexelSize;
varying mediump vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 col_1;
  highp vec2 tmpvar_2;
  tmpvar_2 = (_BlurDir * _MainTex_TexelSize);
  highp vec2 P_3;
  P_3 = (xlv_TEXCOORD0 - (2.0 * tmpvar_2));
  highp vec2 P_4;
  P_4 = (xlv_TEXCOORD0 - tmpvar_2);
  highp vec2 P_5;
  P_5 = (xlv_TEXCOORD0 + tmpvar_2);
  highp vec2 P_6;
  P_6 = (xlv_TEXCOORD0 + (2.0 * tmpvar_2));
  col_1.xyz = (((
    ((texture2D (_MainTex, P_3) * 0.12) + (texture2D (_MainTex, P_4) * 0.2))
   + 
    (texture2D (_MainTex, xlv_TEXCOORD0) * 0.36)
  ) + (texture2D (_MainTex, P_5) * 0.2)) + (texture2D (_MainTex, P_6) * 0.12)).xyz;
  col_1.w = 1.0;
  gl_FragData[0] = col_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 5 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 144
Vector 112 [_MainTex_ST]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerDraw"" 1
""vs_4_0_level_9_1
eefiecedklbaenjdmegagpdkcfpdgcpejoanebigabaaaaaapiacaaaaaeaaaaaa
daaaaaaabiabaaaaemacaaaakaacaaaaebgpgodjoaaaaaaaoaaaaaaaaaacpopp
kaaaaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaahaa
abaaabaaaaaaaaaaabaaaaaaaeaaacaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjaaeaaaaaeaaaaadoaabaaoeja
abaaoekaabaaookaafaaaaadaaaaapiaaaaaffjaadaaoekaaeaaaaaeaaaaapia
acaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaeaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiaafaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaa
aaaaaaaaahaaaaaadoaaaaabejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 17 math, 5 textures
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesMultiTexCoord0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp vec4 _MainTex_ST;
out mediump vec2 xlv_TEXCOORD0;
void main ()
{
  mediump vec2 tmpvar_1;
  highp vec2 tmpvar_2;
  tmpvar_2 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_2;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform highp vec2 _BlurDir;
uniform highp vec2 _MainTex_TexelSize;
in mediump vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 col_1;
  highp vec2 tmpvar_2;
  tmpvar_2 = (_BlurDir * _MainTex_TexelSize);
  highp vec2 P_3;
  P_3 = (xlv_TEXCOORD0 - (2.0 * tmpvar_2));
  highp vec2 P_4;
  P_4 = (xlv_TEXCOORD0 - tmpvar_2);
  highp vec2 P_5;
  P_5 = (xlv_TEXCOORD0 + tmpvar_2);
  highp vec2 P_6;
  P_6 = (xlv_TEXCOORD0 + (2.0 * tmpvar_2));
  col_1.xyz = (((
    ((texture (_MainTex, P_3) * 0.12) + (texture (_MainTex, P_4) * 0.2))
   + 
    (texture (_MainTex, xlv_TEXCOORD0) * 0.36)
  ) + (texture (_MainTex, P_5) * 0.2)) + (texture (_MainTex, P_6) * 0.12)).xyz;
  col_1.w = 1.0;
  _glesFragData[0] = col_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 3 math
Bind ""vertex"" ATTR0
Bind ""texcoord"" ATTR1
ConstBuffer ""$Globals"" 80
Matrix 0 [glstate_matrix_mvp]
Vector 64 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float4 _glesMultiTexCoord0 [[attribute(1)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  half2 xlv_TEXCOORD0;
};
struct xlatMtlShaderUniform {
  float4x4 glstate_matrix_mvp;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half2 tmpvar_1;
  float2 tmpvar_2;
  tmpvar_2 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  tmpvar_1 = half2(tmpvar_2);
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = tmpvar_1;
  return _mtl_o;
}

""
}
}
Program ""fp"" {
SubProgram ""opengl "" {
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 13 math, 5 textures
Vector 0 [_BlurDir]
Vector 1 [_MainTex_TexelSize]
SetTexture 0 [_MainTex] 2D 0
""ps_2_0
def c2, 2, 0.200000003, 0.119999997, 0.360000014
def c3, 1, 0, 0, 0
dcl t0.xy
dcl_2d s0
mov r0.xy, c0
mad r1.xy, r0, -c1, t0
mul r0.zw, r0.wzyx, c1.wzyx
mad r2.xy, r0.wzyx, -c2.x, t0
mad r3.xy, r0.wzyx, c2.x, t0
mad r0.xy, r0, c1, t0
texld r1, r1, s0
texld r3, r3, s0
texld r2, r2, s0
texld r4, t0, s0
texld r0, r0, s0
mul r1.xyz, r1, c2.y
mad_pp r1.xyz, r2, c2.z, r1
mad_pp r1.xyz, r4, c2.w, r1
mad_pp r0.xyz, r0, c2.y, r1
mad_pp r0.xyz, r3, c2.z, r0
mov_pp r0.w, c3.x
mov_pp oC0, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 10 math, 5 textures
SetTexture 0 [_MainTex] 2D 0
ConstBuffer ""$Globals"" 144
Vector 96 [_BlurDir] 2
Vector 128 [_MainTex_TexelSize] 2
BindCB  ""$Globals"" 0
""ps_4_0
eefiecedgpkpjkbakijppgcdgbnjlgfonfjgcfioabaaaaaakmadaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcomacaaaa
eaaaaaaallaaaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaadcaaaaamdcaabaaaaaaaaaaa
egiacaiaebaaaaaaaaaaaaaaagaaaaaaegiacaaaaaaaaaaaaiaaaaaaegbabaaa
abaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadiaaaaakhcaabaaaaaaaaaaaegacbaaaaaaaaaaaaceaaaaa
mnmmemdomnmmemdomnmmemdoaaaaaaaadiaaaaajdcaabaaaabaaaaaaegiacaaa
aaaaaaaaagaaaaaaegiacaaaaaaaaaaaaiaaaaaadcaaaaanmcaabaaaabaaaaaa
agaebaiaebaaaaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaeaaaaaaaea
agbebaaaabaaaaaadcaaaaamdcaabaaaabaaaaaaegaabaaaabaaaaaaaceaaaaa
aaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaegbabaaaabaaaaaaefaaaaajpcaabaaa
acaaaaaaegaabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaefaaaaaj
pcaabaaaabaaaaaaogakbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaamhcaabaaaaaaaaaaaegacbaaaabaaaaaaaceaaaaaipmcpfdnipmcpfdn
ipmcpfdnaaaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaamhcaabaaaaaaaaaaa
egacbaaaabaaaaaaaceaaaaaomfblidoomfblidoomfblidoaaaaaaaaegacbaaa
aaaaaaaadcaaaaaldcaabaaaabaaaaaaegiacaaaaaaaaaaaagaaaaaaegiacaaa
aaaaaaaaaiaaaaaaegbabaaaabaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaamhcaabaaaaaaaaaaa
egacbaaaabaaaaaaaceaaaaamnmmemdomnmmemdomnmmemdoaaaaaaaaegacbaaa
aaaaaaaadcaaaaamhccabaaaaaaaaaaaegacbaaaacaaaaaaaceaaaaaipmcpfdn
ipmcpfdnipmcpfdnaaaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaiadpdoaaaaab""
}
SubProgram ""gles "" {
""!!GLES""
}
SubProgram ""d3d11_9x "" {
// Stats: 10 math, 5 textures
SetTexture 0 [_MainTex] 2D 0
ConstBuffer ""$Globals"" 144
Vector 96 [_BlurDir] 2
Vector 128 [_MainTex_TexelSize] 2
BindCB  ""$Globals"" 0
""ps_4_0_level_9_1
eefiecedkphfpnlnikllkhnfbekllofnlmmejhknabaaaaaahmafaaaaaeaaaaaa
daaaaaaapmabaaaapaaeaaaaeiafaaaaebgpgodjmeabaaaameabaaaaaaacpppp
ieabaaaaeaaaaaaaacaaciaaaaaaeaaaaaaaeaaaabaaceaaaaaaeaaaaaaaaaaa
aaaaagaaabaaaaaaaaaaaaaaaaaaaiaaabaaabaaaaaaaaaaaaacppppfbaaaaaf
acaaapkaaaaaaaeamnmmemdoipmcpfdnomfblidofbaaaaafadaaapkaaaaaiadp
aaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaaja
aaaiapkaabaaaaacaaaaadiaaaaaoekaaeaaaaaeabaaadiaaaaaoeiaabaaoekb
aaaaoelaafaaaaadaaaaamiaaaaabliaabaablkaaeaaaaaeacaaadiaaaaablia
acaaaakbaaaaoelaaeaaaaaeadaaadiaaaaabliaacaaaakaaaaaoelaaeaaaaae
aaaaadiaaaaaoeiaabaaoekaaaaaoelaecaaaaadabaaapiaabaaoeiaaaaioeka
ecaaaaadadaaapiaadaaoeiaaaaioekaecaaaaadacaaapiaacaaoeiaaaaioeka
ecaaaaadaeaaapiaaaaaoelaaaaioekaecaaaaadaaaaapiaaaaaoeiaaaaioeka
afaaaaadabaaahiaabaaoeiaacaaffkaaeaaaaaeabaachiaacaaoeiaacaakkka
abaaoeiaaeaaaaaeabaachiaaeaaoeiaacaappkaabaaoeiaaeaaaaaeaaaachia
aaaaoeiaacaaffkaabaaoeiaaeaaaaaeaaaachiaadaaoeiaacaakkkaaaaaoeia
abaaaaacaaaaciiaadaaaakaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefc
omacaaaaeaaaaaaallaaaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafkaaaaad
aagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaadcaaaaamdcaabaaa
aaaaaaaaegiacaiaebaaaaaaaaaaaaaaagaaaaaaegiacaaaaaaaaaaaaiaaaaaa
egbabaaaabaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadiaaaaakhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
aceaaaaamnmmemdomnmmemdomnmmemdoaaaaaaaadiaaaaajdcaabaaaabaaaaaa
egiacaaaaaaaaaaaagaaaaaaegiacaaaaaaaaaaaaiaaaaaadcaaaaanmcaabaaa
abaaaaaaagaebaiaebaaaaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaea
aaaaaaeaagbebaaaabaaaaaadcaaaaamdcaabaaaabaaaaaaegaabaaaabaaaaaa
aceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaegbabaaaabaaaaaaefaaaaaj
pcaabaaaacaaaaaaegaabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
efaaaaajpcaabaaaabaaaaaaogakbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadcaaaaamhcaabaaaaaaaaaaaegacbaaaabaaaaaaaceaaaaaipmcpfdn
ipmcpfdnipmcpfdnaaaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaamhcaabaaa
aaaaaaaaegacbaaaabaaaaaaaceaaaaaomfblidoomfblidoomfblidoaaaaaaaa
egacbaaaaaaaaaaadcaaaaaldcaabaaaabaaaaaaegiacaaaaaaaaaaaagaaaaaa
egiacaaaaaaaaaaaaiaaaaaaegbabaaaabaaaaaaefaaaaajpcaabaaaabaaaaaa
egaabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaamhcaabaaa
aaaaaaaaegacbaaaabaaaaaaaceaaaaamnmmemdomnmmemdomnmmemdoaaaaaaaa
egacbaaaaaaaaaaadcaaaaamhccabaaaaaaaaaaaegacbaaaacaaaaaaaceaaaaa
ipmcpfdnipmcpfdnipmcpfdnaaaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaiadpdoaaaaabejfdeheofaaaaaaaacaaaaaaaiaaaaaa
diaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaadadaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 17 math, 5 textures
SetTexture 0 [_MainTex] 2D 0
ConstBuffer ""$Globals"" 16
Vector 0 [_BlurDir] 2
Vector 8 [_MainTex_TexelSize] 2
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  half2 xlv_TEXCOORD0;
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
  float2 _BlurDir;
  float2 _MainTex_TexelSize;
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]]
  ,   texture2d<half> _MainTex [[texture(0)]], sampler _mtlsmp__MainTex [[sampler(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 col_1;
  float2 tmpvar_2;
  tmpvar_2 = (_mtl_u._BlurDir * _mtl_u._MainTex_TexelSize);
  float2 P_3;
  P_3 = ((float2)_mtl_i.xlv_TEXCOORD0 - (2.0 * tmpvar_2));
  float2 P_4;
  P_4 = ((float2)_mtl_i.xlv_TEXCOORD0 - tmpvar_2);
  float2 P_5;
  P_5 = ((float2)_mtl_i.xlv_TEXCOORD0 + tmpvar_2);
  float2 P_6;
  P_6 = ((float2)_mtl_i.xlv_TEXCOORD0 + (2.0 * tmpvar_2));
  col_1.xyz = (((
    ((_MainTex.sample(_mtlsmp__MainTex, (float2)(P_3)) * (half)0.12) + (_MainTex.sample(_mtlsmp__MainTex, (float2)(P_4)) * (half)0.2))
   + 
    (_MainTex.sample(_mtlsmp__MainTex, (float2)(_mtl_i.xlv_TEXCOORD0)) * (half)0.36)
  ) + (_MainTex.sample(_mtlsmp__MainTex, (float2)(P_5)) * (half)0.2)) + (_MainTex.sample(_mtlsmp__MainTex, (float2)(P_6)) * (half)0.12)).xyz;
  col_1.w = half(1.0);
  _mtl_o._glesFragData_0 = col_1;
  return _mtl_o;
}

""
}
}
 }
}
}";

        public static readonly string buildingBlurPP_V2 = @"// Compiled shader for all platforms, uncompressed size: 24.8KB

// Skipping shader variants that would not be included into build of current scene.

Shader ""BuildingBlurShader"" {
Properties {
 _MainTex (""Base (RGB)"", 2D) = ""white"" { }
 _BlurDir (""Blur dir"", Vector) = (0,0,0,0)
}
SubShader { 
 LOD 100
 Tags { ""RenderType""=""Opaque"" }


 // Stats for Vertex shader:
 //       d3d11 : 8 math
 //    d3d11_9x : 8 math
 //        d3d9 : 11 math
 //        gles : 35 math, 10 texture
 //       gles3 : 35 math, 10 texture
 //       metal : 6 math
 //      opengl : 35 math, 10 texture
 // Stats for Fragment shader:
 //       d3d11 : 19 math, 10 texture
 //    d3d11_9x : 19 math, 10 texture
 //        d3d9 : 23 math, 10 texture
 //       metal : 35 math, 10 texture
 Pass {
  Tags { ""RenderType""=""Opaque"" }
  GpuProgramID 48411
Program ""vp"" {
SubProgram ""opengl "" {
// Stats: 35 math, 10 textures
""!!GLSL
#ifdef VERTEX
uniform vec4 _ProjectionParams;

uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
varying vec4 xlv_TEXCOORD1;
void main ()
{
  vec4 tmpvar_1;
  tmpvar_1 = (gl_ModelViewProjectionMatrix * gl_Vertex);
  vec4 o_2;
  vec4 tmpvar_3;
  tmpvar_3 = (tmpvar_1 * 0.5);
  vec2 tmpvar_4;
  tmpvar_4.x = tmpvar_3.x;
  tmpvar_4.y = (tmpvar_3.y * _ProjectionParams.x);
  o_2.xy = (tmpvar_4 + tmpvar_3.w);
  o_2.zw = tmpvar_1.zw;
  gl_Position = tmpvar_1;
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = o_2;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _CameraDepthTexture;
uniform sampler2D _MainTex;
uniform vec2 _BlurDir;
uniform vec2 _MainTex_TexelSize;
varying vec2 xlv_TEXCOORD0;
varying vec4 xlv_TEXCOORD1;
void main ()
{
  vec4 col_1;
  vec2 tmpvar_2;
  tmpvar_2 = ((_BlurDir * _MainTex_TexelSize) * (1.0 - texture2DProj (_CameraDepthTexture, xlv_TEXCOORD1).x));
  col_1.xyz = (((
    ((((
      ((texture2D (_MainTex, (xlv_TEXCOORD0 - (4.0 * tmpvar_2))) * 0.05) + (texture2D (_MainTex, (xlv_TEXCOORD0 - (3.0 * tmpvar_2))) * 0.09))
     + 
      (texture2D (_MainTex, (xlv_TEXCOORD0 - (2.0 * tmpvar_2))) * 0.12)
    ) + (texture2D (_MainTex, 
      (xlv_TEXCOORD0 - tmpvar_2)
    ) * 0.15)) + (texture2D (_MainTex, xlv_TEXCOORD0) * 0.16)) + (texture2D (_MainTex, (xlv_TEXCOORD0 + tmpvar_2)) * 0.15))
   + 
    (texture2D (_MainTex, (xlv_TEXCOORD0 + (2.0 * tmpvar_2))) * 0.12)
  ) + (texture2D (_MainTex, 
    (xlv_TEXCOORD0 + (3.0 * tmpvar_2))
  ) * 0.09)) + (texture2D (_MainTex, (xlv_TEXCOORD0 + 
    (4.0 * tmpvar_2)
  )) * 0.05)).xyz;
  col_1.w = 1.0;
  gl_FragData[0] = col_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 11 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 6 [_MainTex_ST]
Vector 4 [_ProjectionParams]
Vector 5 [_ScreenParams]
""vs_2_0
def c7, 0.5, 0, 0, 0
dcl_position v0
dcl_texcoord v1
mad oT0.xy, v1, c6, c6.zwzw
dp4 r0.y, c1, v0
mul r1.x, r0.y, c4.x
mul r1.w, r1.x, c7.x
dp4 r0.x, c0, v0
dp4 r0.w, c3, v0
mul r1.xz, r0.xyww, c7.x
mad oT1.xy, r1.z, c5.zwzw, r1.xwzw
dp4 r0.z, c2, v0
mov oPos, r0
mov oT1.zw, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 8 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 144
Vector 112 [_MainTex_ST]
ConstBuffer ""UnityPerCamera"" 144
Vector 80 [_ProjectionParams]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerCamera"" 1
BindCB  ""UnityPerDraw"" 2
""vs_4_0
eefiecedledcnedlocdchabhjfiahbncfgnpbcjaabaaaaaammacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaklklklfdeieefcneabaaaaeaaaabaahfaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaa
fjaaaaaeegiocaaaacaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
dcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaa
ahaaaaaaogikcaaaaaaaaaaaahaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaa
aaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaa
aaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaa
acaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaacaaaaaakgakbaaaabaaaaaa
mgaabaaaabaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 35 math, 10 textures
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesMultiTexCoord0;
uniform highp vec4 _ProjectionParams;
uniform highp mat4 glstate_matrix_mvp;
uniform highp vec4 _MainTex_ST;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec4 xlv_TEXCOORD1;
void main ()
{
  mediump vec2 tmpvar_1;
  highp vec4 tmpvar_2;
  tmpvar_2 = (glstate_matrix_mvp * _glesVertex);
  highp vec2 tmpvar_3;
  tmpvar_3 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_3;
  highp vec4 o_4;
  highp vec4 tmpvar_5;
  tmpvar_5 = (tmpvar_2 * 0.5);
  highp vec2 tmpvar_6;
  tmpvar_6.x = tmpvar_5.x;
  tmpvar_6.y = (tmpvar_5.y * _ProjectionParams.x);
  o_4.xy = (tmpvar_6 + tmpvar_5.w);
  o_4.zw = tmpvar_2.zw;
  gl_Position = tmpvar_2;
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = o_4;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _CameraDepthTexture;
uniform sampler2D _MainTex;
uniform highp vec2 _BlurDir;
uniform highp vec2 _MainTex_TexelSize;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec4 xlv_TEXCOORD1;
void main ()
{
  lowp vec4 col_1;
  highp float depth_2;
  lowp float tmpvar_3;
  tmpvar_3 = texture2DProj (_CameraDepthTexture, xlv_TEXCOORD1).x;
  depth_2 = tmpvar_3;
  highp vec2 tmpvar_4;
  tmpvar_4 = ((_BlurDir * _MainTex_TexelSize) * (1.0 - depth_2));
  highp vec2 P_5;
  P_5 = (xlv_TEXCOORD0 - (4.0 * tmpvar_4));
  highp vec2 P_6;
  P_6 = (xlv_TEXCOORD0 - (3.0 * tmpvar_4));
  highp vec2 P_7;
  P_7 = (xlv_TEXCOORD0 - (2.0 * tmpvar_4));
  highp vec2 P_8;
  P_8 = (xlv_TEXCOORD0 - tmpvar_4);
  highp vec2 P_9;
  P_9 = (xlv_TEXCOORD0 + tmpvar_4);
  highp vec2 P_10;
  P_10 = (xlv_TEXCOORD0 + (2.0 * tmpvar_4));
  highp vec2 P_11;
  P_11 = (xlv_TEXCOORD0 + (3.0 * tmpvar_4));
  highp vec2 P_12;
  P_12 = (xlv_TEXCOORD0 + (4.0 * tmpvar_4));
  col_1.xyz = (((
    ((((
      ((texture2D (_MainTex, P_5) * 0.05) + (texture2D (_MainTex, P_6) * 0.09))
     + 
      (texture2D (_MainTex, P_7) * 0.12)
    ) + (texture2D (_MainTex, P_8) * 0.15)) + (texture2D (_MainTex, xlv_TEXCOORD0) * 0.16)) + (texture2D (_MainTex, P_9) * 0.15))
   + 
    (texture2D (_MainTex, P_10) * 0.12)
  ) + (texture2D (_MainTex, P_11) * 0.09)) + (texture2D (_MainTex, P_12) * 0.05)).xyz;
  col_1.w = 1.0;
  gl_FragData[0] = col_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 8 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 144
Vector 112 [_MainTex_ST]
ConstBuffer ""UnityPerCamera"" 144
Vector 80 [_ProjectionParams]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerCamera"" 1
BindCB  ""UnityPerDraw"" 2
""vs_4_0_level_9_1
eefiecedhgjplcgbmgicmeilgmgmmkllblamaacaabaaaaaaciaeaaaaaeaaaaaa
daaaaaaaiiabaaaageadaaaaliadaaaaebgpgodjfaabaaaafaabaaaaaaacpopp
aeabaaaaemaaaaaaadaaceaaaaaaeiaaaaaaeiaaaaaaceaaabaaeiaaaaaaahaa
abaaabaaaaaaaaaaabaaafaaabaaacaaaaaaaaaaacaaaaaaaeaaadaaaaaaaaaa
aaaaaaaaaaacpoppfbaaaaafahaaapkaaaaaaadpaaaaaaaaaaaaaaaaaaaaaaaa
bpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjaaeaaaaaeaaaaadoa
abaaoejaabaaoekaabaaookaafaaaaadaaaaapiaaaaaffjaaeaaoekaaeaaaaae
aaaaapiaadaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaafaaoekaaaaakkja
aaaaoeiaaeaaaaaeaaaaapiaagaaoekaaaaappjaaaaaoeiaafaaaaadabaaabia
aaaaffiaacaaaakaafaaaaadabaaaiiaabaaaaiaahaaaakaafaaaaadabaaafia
aaaapeiaahaaaakaacaaaaadabaaadoaabaakkiaabaaomiaaeaaaaaeaaaaadma
aaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaacabaaamoa
aaaaoeiappppaaaafdeieefcneabaaaaeaaaabaahfaaaaaafjaaaaaeegiocaaa
aaaaaaaaaiaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaa
acaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
pccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaa
aaaaaaaaahaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaa
abaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaacaaaaaakgaobaaa
aaaaaaaaaaaaaaahdccabaaaacaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
doaaaaabejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklklepfdeheogiaaaaaa
adaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaafmaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 35 math, 10 textures
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesMultiTexCoord0;
uniform highp vec4 _ProjectionParams;
uniform highp mat4 glstate_matrix_mvp;
uniform highp vec4 _MainTex_ST;
out mediump vec2 xlv_TEXCOORD0;
out highp vec4 xlv_TEXCOORD1;
void main ()
{
  mediump vec2 tmpvar_1;
  highp vec4 tmpvar_2;
  tmpvar_2 = (glstate_matrix_mvp * _glesVertex);
  highp vec2 tmpvar_3;
  tmpvar_3 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_3;
  highp vec4 o_4;
  highp vec4 tmpvar_5;
  tmpvar_5 = (tmpvar_2 * 0.5);
  highp vec2 tmpvar_6;
  tmpvar_6.x = tmpvar_5.x;
  tmpvar_6.y = (tmpvar_5.y * _ProjectionParams.x);
  o_4.xy = (tmpvar_6 + tmpvar_5.w);
  o_4.zw = tmpvar_2.zw;
  gl_Position = tmpvar_2;
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = o_4;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _CameraDepthTexture;
uniform sampler2D _MainTex;
uniform highp vec2 _BlurDir;
uniform highp vec2 _MainTex_TexelSize;
in mediump vec2 xlv_TEXCOORD0;
in highp vec4 xlv_TEXCOORD1;
void main ()
{
  lowp vec4 col_1;
  highp float depth_2;
  lowp float tmpvar_3;
  tmpvar_3 = textureProj (_CameraDepthTexture, xlv_TEXCOORD1).x;
  depth_2 = tmpvar_3;
  highp vec2 tmpvar_4;
  tmpvar_4 = ((_BlurDir * _MainTex_TexelSize) * (1.0 - depth_2));
  highp vec2 P_5;
  P_5 = (xlv_TEXCOORD0 - (4.0 * tmpvar_4));
  highp vec2 P_6;
  P_6 = (xlv_TEXCOORD0 - (3.0 * tmpvar_4));
  highp vec2 P_7;
  P_7 = (xlv_TEXCOORD0 - (2.0 * tmpvar_4));
  highp vec2 P_8;
  P_8 = (xlv_TEXCOORD0 - tmpvar_4);
  highp vec2 P_9;
  P_9 = (xlv_TEXCOORD0 + tmpvar_4);
  highp vec2 P_10;
  P_10 = (xlv_TEXCOORD0 + (2.0 * tmpvar_4));
  highp vec2 P_11;
  P_11 = (xlv_TEXCOORD0 + (3.0 * tmpvar_4));
  highp vec2 P_12;
  P_12 = (xlv_TEXCOORD0 + (4.0 * tmpvar_4));
  col_1.xyz = (((
    ((((
      ((texture (_MainTex, P_5) * 0.05) + (texture (_MainTex, P_6) * 0.09))
     + 
      (texture (_MainTex, P_7) * 0.12)
    ) + (texture (_MainTex, P_8) * 0.15)) + (texture (_MainTex, xlv_TEXCOORD0) * 0.16)) + (texture (_MainTex, P_9) * 0.15))
   + 
    (texture (_MainTex, P_10) * 0.12)
  ) + (texture (_MainTex, P_11) * 0.09)) + (texture (_MainTex, P_12) * 0.05)).xyz;
  col_1.w = 1.0;
  _glesFragData[0] = col_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 6 math
Bind ""vertex"" ATTR0
Bind ""texcoord"" ATTR1
ConstBuffer ""$Globals"" 96
Matrix 16 [glstate_matrix_mvp]
Vector 0 [_ProjectionParams]
Vector 80 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float4 _glesMultiTexCoord0 [[attribute(1)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  half2 xlv_TEXCOORD0;
  float4 xlv_TEXCOORD1;
};
struct xlatMtlShaderUniform {
  float4 _ProjectionParams;
  float4x4 glstate_matrix_mvp;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half2 tmpvar_1;
  float4 tmpvar_2;
  tmpvar_2 = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  float2 tmpvar_3;
  tmpvar_3 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  tmpvar_1 = half2(tmpvar_3);
  float4 o_4;
  float4 tmpvar_5;
  tmpvar_5 = (tmpvar_2 * 0.5);
  float2 tmpvar_6;
  tmpvar_6.x = tmpvar_5.x;
  tmpvar_6.y = (tmpvar_5.y * _mtl_u._ProjectionParams.x);
  o_4.xy = (tmpvar_6 + tmpvar_5.w);
  o_4.zw = tmpvar_2.zw;
  _mtl_o.gl_Position = tmpvar_2;
  _mtl_o.xlv_TEXCOORD0 = tmpvar_1;
  _mtl_o.xlv_TEXCOORD1 = o_4;
  return _mtl_o;
}

""
}
}
Program ""fp"" {
SubProgram ""opengl "" {
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 23 math, 10 textures
Vector 0 [_BlurDir]
Vector 1 [_MainTex_TexelSize]
SetTexture 0 [_CameraDepthTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
""ps_2_0
def c2, 0.0500000007, 2, 0.119999997, 0.150000006
def c3, 0.159999996, 0, 0, 0
def c4, 1, 4, 3, 0.0900000036
dcl t0.xy
dcl t1
dcl_2d s0
dcl_2d s1
texldp r0, t1, s0
add r0.x, -r0.x, c4.x
mov r1.xy, c0
mul r0.yz, r1.zxyw, c1.zxyw
mul r1.xy, r0.x, r0.yzxw
mad r2.xy, r1, -c4.z, t0
mad r3.xy, r1, -c4.y, t0
mad r4.xy, r1, -c2.y, t0
mad r5.xy, r0.yzxw, -r0.x, t0
mad r0.xy, r0.yzxw, r0.x, t0
mad r6.xy, r1, c2.y, t0
mad r7.xy, r1, c4.z, t0
mad r1.xy, r1, c4.y, t0
texld r2, r2, s1
texld r3, r3, s1
texld r4, r4, s1
texld r0, r0, s1
texld r5, r5, s1
texld r8, t0, s1
texld r6, r6, s1
texld r1, r1, s1
texld r7, r7, s1
mul r2.xyz, r2, c4.w
mad_pp r2.xyz, r3, c2.x, r2
mad_pp r2.xyz, r4, c2.z, r2
mad_pp r2.xyz, r5, c2.w, r2
mad_pp r2.xyz, r8, c3.x, r2
mad_pp r0.xyz, r0, c2.w, r2
mad_pp r0.xyz, r6, c2.z, r0
mad_pp r0.xyz, r7, c4.w, r0
mad_pp r0.xyz, r1, c2.x, r0
mov_pp r0.w, c4.x
mov_pp oC0, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 19 math, 10 textures
SetTexture 0 [_CameraDepthTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
ConstBuffer ""$Globals"" 144
Vector 96 [_BlurDir] 2
Vector 128 [_MainTex_TexelSize] 2
BindCB  ""$Globals"" 0
""ps_4_0
eefiecedmkafgkjbckmanebdfakeclfpgkjkcodeabaaaaaaamagaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apalaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdeafaaaaeaaaaaaaenabaaaa
fjaaaaaeegiocaaaaaaaaaaaajaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadlcbabaaaacaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaaaoaaaaahdcaabaaaaaaaaaaa
egbabaaaacaaaaaapgbpbaaaacaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaa
aaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaaibcaabaaaaaaaaaaa
akaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpdiaaaaajgcaabaaaaaaaaaaa
agibcaaaaaaaaaaaagaaaaaaagibcaaaaaaaaaaaaiaaaaaadiaaaaahdcaabaaa
abaaaaaaagaabaaaaaaaaaaajgafbaaaaaaaaaaadcaaaaanpcaabaaaacaaaaaa
egaebaiaebaaaaaaabaaaaaaaceaaaaaaaaaiaeaaaaaiaeaaaaaeaeaaaaaeaea
egbebaaaabaaaaaaefaaaaajpcaabaaaadaaaaaaogakbaaaacaaaaaaeghobaaa
abaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaa
eghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaakhcaabaaaadaaaaaaegacbaaa
adaaaaaaaceaaaaaomfblidnomfblidnomfblidnaaaaaaaadcaaaaamhcaabaaa
acaaaaaaegacbaaaacaaaaaaaceaaaaamnmmemdnmnmmemdnmnmmemdnaaaaaaaa
egacbaaaadaaaaaadcaaaaanmcaabaaaabaaaaaaagaebaiaebaaaaaaabaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaaeaaaaaaaeaagbebaaaabaaaaaaefaaaaaj
pcaabaaaadaaaaaaogakbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaa
dcaaaaamhcaabaaaacaaaaaaegacbaaaadaaaaaaaceaaaaaipmcpfdnipmcpfdn
ipmcpfdnaaaaaaaaegacbaaaacaaaaaadcaaaaakmcaabaaaabaaaaaafgajbaia
ebaaaaaaaaaaaaaaagaabaaaaaaaaaaaagbebaaaabaaaaaadcaaaaajdcaabaaa
aaaaaaaajgafbaaaaaaaaaaaagaabaaaaaaaaaaaegbabaaaabaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaa
efaaaaajpcaabaaaadaaaaaaogakbaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
abaaaaaadcaaaaamhcaabaaaacaaaaaaegacbaaaadaaaaaaaceaaaaajkjjbjdo
jkjjbjdojkjjbjdoaaaaaaaaegacbaaaacaaaaaaefaaaaajpcaabaaaadaaaaaa
egbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadcaaaaamhcaabaaa
acaaaaaaegacbaaaadaaaaaaaceaaaaaaknhcddoaknhcddoaknhcddoaaaaaaaa
egacbaaaacaaaaaadcaaaaamhcaabaaaaaaaaaaaegacbaaaaaaaaaaaaceaaaaa
jkjjbjdojkjjbjdojkjjbjdoaaaaaaaaegacbaaaacaaaaaadcaaaaammcaabaaa
abaaaaaaagaebaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaeaaaaaaaea
agbebaaaabaaaaaadcaaaaampcaabaaaacaaaaaaegaebaaaabaaaaaaaceaaaaa
aaaaeaeaaaaaeaeaaaaaiaeaaaaaiaeaegbebaaaabaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadcaaaaam
hcaabaaaaaaaaaaaegacbaaaabaaaaaaaceaaaaaipmcpfdnipmcpfdnipmcpfdn
aaaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaacaaaaaa
eghobaaaabaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaogakbaaa
acaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadcaaaaamhcaabaaaaaaaaaaa
egacbaaaabaaaaaaaceaaaaaomfblidnomfblidnomfblidnaaaaaaaaegacbaaa
aaaaaaaadcaaaaamhccabaaaaaaaaaaaegacbaaaacaaaaaaaceaaaaamnmmemdn
mnmmemdnmnmmemdnaaaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaiadpdoaaaaab""
}
SubProgram ""gles "" {
""!!GLES""
}
SubProgram ""d3d11_9x "" {
// Stats: 19 math, 10 textures
SetTexture 0 [_CameraDepthTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
ConstBuffer ""$Globals"" 144
Vector 96 [_BlurDir] 2
Vector 128 [_MainTex_TexelSize] 2
BindCB  ""$Globals"" 0
""ps_4_0_level_9_1
eefiecedgoapbibboiinfahkghbkadnalnnaekpmabaaaaaadmajaaaaaeaaaaaa
daaaaaaafmadaaaajiaiaaaaaiajaaaaebgpgodjceadaaaaceadaaaaaaacpppp
oaacaaaaeeaaaaaaacaacmaaaaaaeeaaaaaaeeaaacaaceaaaaaaeeaaaaaaaaaa
abababaaaaaaagaaabaaaaaaaaaaaaaaaaaaaiaaabaaabaaaaaaaaaaaaacpppp
fbaaaaafacaaapkaaaaaiadpaaaaiaeaaaaaeaeaomfblidnfbaaaaafadaaapka
mnmmemdnaaaaaaeaipmcpfdnjkjjbjdofbaaaaafaeaaapkaaknhcddoaaaaaaaa
aaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaaiaabaaapla
bpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkaagaaaaacaaaaaiia
abaapplaafaaaaadaaaaadiaaaaappiaabaaoelaecaaaaadaaaaapiaaaaaoeia
aaaioekaacaaaaadaaaaabiaaaaaaaibacaaaakaabaaaaacabaaadiaaaaaoeka
afaaaaadaaaaagiaabaanciaabaanckaafaaaaadabaaadiaaaaaaaiaaaaamjia
aeaaaaaeacaaadiaabaaoeiaacaakkkbaaaaoelaaeaaaaaeadaaadiaabaaoeia
acaaffkbaaaaoelaaeaaaaaeaeaaadiaabaaoeiaadaaffkbaaaaoelaaeaaaaae
afaaadiaaaaamjiaaaaaaaibaaaaoelaaeaaaaaeaaaaadiaaaaamjiaaaaaaaia
aaaaoelaaeaaaaaeagaaadiaabaaoeiaadaaffkaaaaaoelaaeaaaaaeahaaadia
abaaoeiaacaakkkaaaaaoelaaeaaaaaeabaaadiaabaaoeiaacaaffkaaaaaoela
ecaaaaadacaaapiaacaaoeiaabaioekaecaaaaadadaaapiaadaaoeiaabaioeka
ecaaaaadaeaaapiaaeaaoeiaabaioekaecaaaaadaaaaapiaaaaaoeiaabaioeka
ecaaaaadafaaapiaafaaoeiaabaioekaecaaaaadaiaaapiaaaaaoelaabaioeka
ecaaaaadagaaapiaagaaoeiaabaioekaecaaaaadabaaapiaabaaoeiaabaioeka
ecaaaaadahaaapiaahaaoeiaabaioekaafaaaaadacaaahiaacaaoeiaacaappka
aeaaaaaeacaachiaadaaoeiaadaaaakaacaaoeiaaeaaaaaeacaachiaaeaaoeia
adaakkkaacaaoeiaaeaaaaaeacaachiaafaaoeiaadaappkaacaaoeiaaeaaaaae
acaachiaaiaaoeiaaeaaaakaacaaoeiaaeaaaaaeaaaachiaaaaaoeiaadaappka
acaaoeiaaeaaaaaeaaaachiaagaaoeiaadaakkkaaaaaoeiaaeaaaaaeaaaachia
ahaaoeiaacaappkaaaaaoeiaaeaaaaaeaaaachiaabaaoeiaadaaaakaaaaaoeia
abaaaaacaaaaaiiaacaaaakaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefc
deafaaaaeaaaaaaaenabaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafkaaaaad
aagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gcbaaaadlcbabaaaacaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaa
aoaaaaahdcaabaaaaaaaaaaaegbabaaaacaaaaaapgbpbaaaacaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
aaaaaaaibcaabaaaaaaaaaaaakaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadp
diaaaaajgcaabaaaaaaaaaaaagibcaaaaaaaaaaaagaaaaaaagibcaaaaaaaaaaa
aiaaaaaadiaaaaahdcaabaaaabaaaaaaagaabaaaaaaaaaaajgafbaaaaaaaaaaa
dcaaaaanpcaabaaaacaaaaaaegaebaiaebaaaaaaabaaaaaaaceaaaaaaaaaiaea
aaaaiaeaaaaaeaeaaaaaeaeaegbebaaaabaaaaaaefaaaaajpcaabaaaadaaaaaa
ogakbaaaacaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaa
acaaaaaaegaabaaaacaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaak
hcaabaaaadaaaaaaegacbaaaadaaaaaaaceaaaaaomfblidnomfblidnomfblidn
aaaaaaaadcaaaaamhcaabaaaacaaaaaaegacbaaaacaaaaaaaceaaaaamnmmemdn
mnmmemdnmnmmemdnaaaaaaaaegacbaaaadaaaaaadcaaaaanmcaabaaaabaaaaaa
agaebaiaebaaaaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaeaaaaaaaea
agbebaaaabaaaaaaefaaaaajpcaabaaaadaaaaaaogakbaaaabaaaaaaeghobaaa
abaaaaaaaagabaaaabaaaaaadcaaaaamhcaabaaaacaaaaaaegacbaaaadaaaaaa
aceaaaaaipmcpfdnipmcpfdnipmcpfdnaaaaaaaaegacbaaaacaaaaaadcaaaaak
mcaabaaaabaaaaaafgajbaiaebaaaaaaaaaaaaaaagaabaaaaaaaaaaaagbebaaa
abaaaaaadcaaaaajdcaabaaaaaaaaaaajgafbaaaaaaaaaaaagaabaaaaaaaaaaa
egbabaaaabaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaa
abaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaaadaaaaaaogakbaaaabaaaaaa
eghobaaaabaaaaaaaagabaaaabaaaaaadcaaaaamhcaabaaaacaaaaaaegacbaaa
adaaaaaaaceaaaaajkjjbjdojkjjbjdojkjjbjdoaaaaaaaaegacbaaaacaaaaaa
efaaaaajpcaabaaaadaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
abaaaaaadcaaaaamhcaabaaaacaaaaaaegacbaaaadaaaaaaaceaaaaaaknhcddo
aknhcddoaknhcddoaaaaaaaaegacbaaaacaaaaaadcaaaaamhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaaceaaaaajkjjbjdojkjjbjdojkjjbjdoaaaaaaaaegacbaaa
acaaaaaadcaaaaammcaabaaaabaaaaaaagaebaaaabaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaeaaaaaaaeaagbebaaaabaaaaaadcaaaaampcaabaaaacaaaaaa
egaebaaaabaaaaaaaceaaaaaaaaaeaeaaaaaeaeaaaaaiaeaaaaaiaeaegbebaaa
abaaaaaaefaaaaajpcaabaaaabaaaaaaogakbaaaabaaaaaaeghobaaaabaaaaaa
aagabaaaabaaaaaadcaaaaamhcaabaaaaaaaaaaaegacbaaaabaaaaaaaceaaaaa
ipmcpfdnipmcpfdnipmcpfdnaaaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaa
abaaaaaaegaabaaaacaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaaefaaaaaj
pcaabaaaacaaaaaaogakbaaaacaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaa
dcaaaaamhcaabaaaaaaaaaaaegacbaaaabaaaaaaaceaaaaaomfblidnomfblidn
omfblidnaaaaaaaaegacbaaaaaaaaaaadcaaaaamhccabaaaaaaaaaaaegacbaaa
acaaaaaaaceaaaaamnmmemdnmnmmemdnmnmmemdnaaaaaaaaegacbaaaaaaaaaaa
dgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaabejfdeheogiaaaaaa
adaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaafmaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapalaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 35 math, 10 textures
SetTexture 0 [_CameraDepthTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
ConstBuffer ""$Globals"" 16
Vector 0 [_BlurDir] 2
Vector 8 [_MainTex_TexelSize] 2
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  half2 xlv_TEXCOORD0;
  float4 xlv_TEXCOORD1;
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
  float2 _BlurDir;
  float2 _MainTex_TexelSize;
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]]
  ,   texture2d<half> _CameraDepthTexture [[texture(0)]], sampler _mtlsmp__CameraDepthTexture [[sampler(0)]]
  ,   texture2d<half> _MainTex [[texture(1)]], sampler _mtlsmp__MainTex [[sampler(1)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 col_1;
  float depth_2;
  half tmpvar_3;
  tmpvar_3 = _CameraDepthTexture.sample(_mtlsmp__CameraDepthTexture, ((float2)(_mtl_i.xlv_TEXCOORD1).xy / (float)(_mtl_i.xlv_TEXCOORD1).w)).x;
  depth_2 = float(tmpvar_3);
  float2 tmpvar_4;
  tmpvar_4 = ((_mtl_u._BlurDir * _mtl_u._MainTex_TexelSize) * (1.0 - depth_2));
  float2 P_5;
  P_5 = ((float2)_mtl_i.xlv_TEXCOORD0 - (4.0 * tmpvar_4));
  float2 P_6;
  P_6 = ((float2)_mtl_i.xlv_TEXCOORD0 - (3.0 * tmpvar_4));
  float2 P_7;
  P_7 = ((float2)_mtl_i.xlv_TEXCOORD0 - (2.0 * tmpvar_4));
  float2 P_8;
  P_8 = ((float2)_mtl_i.xlv_TEXCOORD0 - tmpvar_4);
  float2 P_9;
  P_9 = ((float2)_mtl_i.xlv_TEXCOORD0 + tmpvar_4);
  float2 P_10;
  P_10 = ((float2)_mtl_i.xlv_TEXCOORD0 + (2.0 * tmpvar_4));
  float2 P_11;
  P_11 = ((float2)_mtl_i.xlv_TEXCOORD0 + (3.0 * tmpvar_4));
  float2 P_12;
  P_12 = ((float2)_mtl_i.xlv_TEXCOORD0 + (4.0 * tmpvar_4));
  col_1.xyz = (((
    ((((
      ((_MainTex.sample(_mtlsmp__MainTex, (float2)(P_5)) * (half)0.05) + (_MainTex.sample(_mtlsmp__MainTex, (float2)(P_6)) * (half)0.09))
     + 
      (_MainTex.sample(_mtlsmp__MainTex, (float2)(P_7)) * (half)0.12)
    ) + (_MainTex.sample(_mtlsmp__MainTex, (float2)(P_8)) * (half)0.15)) + (_MainTex.sample(_mtlsmp__MainTex, (float2)(_mtl_i.xlv_TEXCOORD0)) * (half)0.16)) + (_MainTex.sample(_mtlsmp__MainTex, (float2)(P_9)) * (half)0.15))
   + 
    (_MainTex.sample(_mtlsmp__MainTex, (float2)(P_10)) * (half)0.12)
  ) + (_MainTex.sample(_mtlsmp__MainTex, (float2)(P_11)) * (half)0.09)) + (_MainTex.sample(_mtlsmp__MainTex, (float2)(P_12)) * (half)0.05)).xyz;
  col_1.w = half(1.0);
  _mtl_o._glesFragData_0 = col_1;
  return _mtl_o;
}

""
}
}
 }
}
}";

        public static readonly string buildingReplacementV2 =
            @"// Compiled shader for all platforms, uncompressed size: 342.1KB

// Skipping shader variants that would not be included into build of current scene.

Shader ""BuildingReplacement"" {
Properties {
 _MainTex (""Base (RGB)"", 2D) = ""white"" { }
 _XYSMap (""Base (RGB)"", 2D) = ""white"" { }
}
SubShader { 
 LOD 200
 Tags { ""ForceNoShadowCasting""=""true"" ""DisableBatching""=""true"" ""RenderType""=""Opaque"" }


 // Stats for Vertex shader:
 //       d3d11 : 45 avg math (34..57)
 //    d3d11_9x : 48 avg math (34..62)
 //        d3d9 : 44 avg math (27..61)
 //        gles : 4 math, 1 texture
 //       gles3 : 4 math, 1 texture
 //       metal : 38 avg math (24..53)
 //      opengl : 4 math, 1 texture
 // Stats for Fragment shader:
 //       d3d11 : 1 math, 1 texture
 //    d3d11_9x : 1 math, 1 texture
 //        d3d9 : 3 math, 1 texture
 //       metal : 4 math, 1 texture
 Pass {
  Name ""FORWARD""
  Tags { ""LIGHTMODE""=""ForwardBase"" ""SHADOWSUPPORT""=""true"" ""ForceNoShadowCasting""=""true"" ""DisableBatching""=""true"" ""RenderType""=""Opaque"" }
  GpuProgramID 10370
Program ""vp"" {
SubProgram ""opengl "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLSL
#ifdef VERTEX
uniform vec4 unity_SHAr;
uniform vec4 unity_SHAg;
uniform vec4 unity_SHAb;
uniform vec4 unity_SHBr;
uniform vec4 unity_SHBg;
uniform vec4 unity_SHBb;
uniform vec4 unity_SHC;

uniform mat4 _Object2World;
uniform mat4 _World2Object;
uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
varying vec3 xlv_TEXCOORD2;
varying vec3 xlv_TEXCOORD3;
void main ()
{
  vec4 v_1;
  v_1.x = _World2Object[0].x;
  v_1.y = _World2Object[1].x;
  v_1.z = _World2Object[2].x;
  v_1.w = _World2Object[3].x;
  vec4 v_2;
  v_2.x = _World2Object[0].y;
  v_2.y = _World2Object[1].y;
  v_2.z = _World2Object[2].y;
  v_2.w = _World2Object[3].y;
  vec4 v_3;
  v_3.x = _World2Object[0].z;
  v_3.y = _World2Object[1].z;
  v_3.z = _World2Object[2].z;
  v_3.w = _World2Object[3].z;
  vec3 tmpvar_4;
  tmpvar_4 = normalize(((
    (v_1.xyz * gl_Normal.x)
   + 
    (v_2.xyz * gl_Normal.y)
  ) + (v_3.xyz * gl_Normal.z)));
  vec4 tmpvar_5;
  tmpvar_5.w = 1.0;
  tmpvar_5.xyz = tmpvar_4;
  vec3 x2_6;
  vec3 x1_7;
  x1_7.x = dot (unity_SHAr, tmpvar_5);
  x1_7.y = dot (unity_SHAg, tmpvar_5);
  x1_7.z = dot (unity_SHAb, tmpvar_5);
  vec4 tmpvar_8;
  tmpvar_8 = (tmpvar_4.xyzz * tmpvar_4.yzzx);
  x2_6.x = dot (unity_SHBr, tmpvar_8);
  x2_6.y = dot (unity_SHBg, tmpvar_8);
  x2_6.z = dot (unity_SHBb, tmpvar_8);
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_4;
  xlv_TEXCOORD2 = (_Object2World * gl_Vertex).xyz;
  xlv_TEXCOORD3 = ((x2_6 + (unity_SHC.xyz * 
    ((tmpvar_4.x * tmpvar_4.x) - (tmpvar_4.y * tmpvar_4.y))
  )) + x1_7);
}


#endif
#ifdef FRAGMENT
uniform sampler2D _XYSMap;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  vec4 c_1;
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 27 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
Vector 17 [_MainTex_ST]
Vector 12 [unity_SHAb]
Vector 11 [unity_SHAg]
Vector 10 [unity_SHAr]
Vector 15 [unity_SHBb]
Vector 14 [unity_SHBg]
Vector 13 [unity_SHBr]
Vector 16 [unity_SHC]
""vs_2_0
def c18, 1, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord v2
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
mad oT0.xy, v2, c17, c17.zwzw
dp4 oT2.x, c4, v0
dp4 oT2.y, c5, v0
dp4 oT2.z, c6, v0
mul r0.xyz, v1.y, c8
mad r0.xyz, c7, v1.x, r0
mad r0.xyz, c9, v1.z, r0
nrm r1.xyz, r0
mul r0.x, r1.y, r1.y
mad r0.x, r1.x, r1.x, -r0.x
mul r2, r1.yzzx, r1.xyzz
dp4 r3.x, c13, r2
dp4 r3.y, c14, r2
dp4 r3.z, c15, r2
mad r0.xyz, c16, r0.x, r3
mov r1.w, c18.x
dp4 r2.x, c10, r1
dp4 r2.y, c11, r1
dp4 r2.z, c12, r1
mov oT1.xyz, r1
add oT3.xyz, r0, r2

""
}
SubProgram ""d3d11 "" {
// Stats: 34 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 160
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityLighting"" 1
BindCB  ""UnityPerDraw"" 2
""vs_4_0
eefiecedfoecphckbhjnhbiggajmdcbfdmmfdnaeabaaaaaaaaahaaaaadaaaaaa
cmaaaaaaceabaaaameabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaaimaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklfdeieefcdeafaaaaeaaaabaaenabaaaafjaaaaaeegiocaaaaaaaaaaa
akaaaaaafjaaaaaeegiocaaaabaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaa
bdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaafhccabaaa
acaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaaaaaaaaaa
egiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaa
amaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hccabaaaadaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaa
abaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaa
dcaaaaakbcaabaaaabaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaia
ebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaa
aaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaa
acaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaa
acaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaa
acaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaacmaaaaaaagaabaaa
abaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadp
bbaaaaaibcaabaaaacaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaa
bbaaaaaiccaabaaaacaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaa
bbaaaaaiecaabaaaacaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaa
aaaaaaahhccabaaaaeaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaadoaaaaab
""
}
SubProgram ""gles "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying mediump vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying mediump vec3 xlv_TEXCOORD3;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  lowp vec4 tmpvar_7;
  tmpvar_7.w = 1.0;
  tmpvar_7.xyz = worldNormal_1;
  mediump vec4 normal_8;
  normal_8 = tmpvar_7;
  mediump vec3 x2_9;
  mediump vec3 x1_10;
  x1_10.x = dot (unity_SHAr, normal_8);
  x1_10.y = dot (unity_SHAg, normal_8);
  x1_10.z = dot (unity_SHAb, normal_8);
  mediump vec4 tmpvar_11;
  tmpvar_11 = (normal_8.xyzz * normal_8.yzzx);
  x2_9.x = dot (unity_SHBr, tmpvar_11);
  x2_9.y = dot (unity_SHBg, tmpvar_11);
  x2_9.z = dot (unity_SHBb, tmpvar_11);
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = (_Object2World * _glesVertex).xyz;
  xlv_TEXCOORD3 = ((x2_9 + (unity_SHC.xyz * 
    ((normal_8.x * normal_8.x) - (normal_8.y * normal_8.y))
  )) + x1_10);
}



#endif
#ifdef FRAGMENT

uniform sampler2D _XYSMap;
varying highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 34 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 160
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityLighting"" 1
BindCB  ""UnityPerDraw"" 2
""vs_4_0_level_9_1
eefiecedjoicfdgpffpghenpeofmamkekdfjcacnabaaaaaaaaakaaaaaeaaaaaa
daaaaaaacmadaaaagiaiaaaagaajaaaaebgpgodjpeacaaaapeacaaaaaaacpopp
jmacaaaafiaaaaaaaeaaceaaaaaafeaaaaaafeaaaaaaceaaabaafeaaaaaaajaa
abaaabaaaaaaaaaaabaacgaaahaaacaaaaaaaaaaacaaaaaaaeaaajaaaaaaaaaa
acaaamaaahaaanaaaaaaaaaaaaaaaaaaaaacpoppfbaaaaafbeaaapkaaaaaiadp
aaaaaaaaaaaaaaaaaaaaaaaabpaaaaacafaaaaiaaaaaapjabpaaaaacafaaacia
acaaapjabpaaaaacafaaadiaadaaapjaaeaaaaaeaaaaadoaadaaoejaabaaoeka
abaaookaafaaaaadaaaaahiaaaaaffjaaoaaoekaaeaaaaaeaaaaahiaanaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaahiaapaaoekaaaaakkjaaaaaoeiaaeaaaaae
acaaahoabaaaoekaaaaappjaaaaaoeiaafaaaaadaaaaabiaacaaaajabbaaaaka
afaaaaadaaaaaciaacaaaajabcaaaakaafaaaaadaaaaaeiaacaaaajabdaaaaka
afaaaaadabaaabiaacaaffjabbaaffkaafaaaaadabaaaciaacaaffjabcaaffka
afaaaaadabaaaeiaacaaffjabdaaffkaacaaaaadaaaaahiaaaaaoeiaabaaoeia
afaaaaadabaaabiaacaakkjabbaakkkaafaaaaadabaaaciaacaakkjabcaakkka
afaaaaadabaaaeiaacaakkjabdaakkkaacaaaaadaaaaahiaaaaaoeiaabaaoeia
ceaaaaacabaaahiaaaaaoeiaafaaaaadaaaaabiaabaaffiaabaaffiaaeaaaaae
aaaaabiaabaaaaiaabaaaaiaaaaaaaibafaaaaadacaaapiaabaacjiaabaakeia
ajaaaaadadaaabiaafaaoekaacaaoeiaajaaaaadadaaaciaagaaoekaacaaoeia
ajaaaaadadaaaeiaahaaoekaacaaoeiaaeaaaaaeaaaaahiaaiaaoekaaaaaaaia
adaaoeiaabaaaaacabaaaiiabeaaaakaajaaaaadacaaabiaacaaoekaabaaoeia
ajaaaaadacaaaciaadaaoekaabaaoeiaajaaaaadacaaaeiaaeaaoekaabaaoeia
abaaaaacabaaahoaabaaoeiaacaaaaadadaaahoaaaaaoeiaacaaoeiaafaaaaad
aaaaapiaaaaaffjaakaaoekaaeaaaaaeaaaaapiaajaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaalaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaamaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiappppaaaafdeieefcdeafaaaaeaaaabaaenabaaaafjaaaaae
egiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaacnaaaaaafjaaaaae
egiocaaaacaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaai
bcaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabaaaaaaadiaaaaai
ccaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabbaaaaaadiaaaaai
ecaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabcaaaaaadiaaaaai
bcaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabaaaaaaadiaaaaai
ccaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabbaaaaaadiaaaaai
ecaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabcaaaaaaaaaaaaah
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaa
abaaaaaackbabaaaacaaaaaackiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaa
abaaaaaackbabaaaacaaaaaackiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaa
abaaaaaackbabaaaacaaaaaackiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaa
dgaaaaafhccabaaaacaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgbfbaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaakhccabaaaadaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaabaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaaaaaaaaaa
bkaabaaaaaaaaaaadcaaaaakbcaabaaaabaaaaaaakaabaaaaaaaaaaaakaabaaa
aaaaaaaaakaabaiaebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaa
aaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaa
cjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaa
ckaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaa
claaaaaaegaobaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaa
cmaaaaaaagaabaaaabaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaaaaaaaaaa
abeaaaaaaaaaiadpbbaaaaaibcaabaaaacaaaaaaegiocaaaabaaaaaacgaaaaaa
egaobaaaaaaaaaaabbaaaaaiccaabaaaacaaaaaaegiocaaaabaaaaaachaaaaaa
egaobaaaaaaaaaaabbaaaaaiecaabaaaacaaaaaaegiocaaaabaaaaaaciaaaaaa
egaobaaaaaaaaaaaaaaaaaahhccabaaaaeaaaaaaegacbaaaabaaaaaaegacbaaa
acaaaaaadoaaaaabejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaa
oaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaaabaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaaadaaaaaa
afaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaaapaaaaaa
ojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdejfeejepeo
aafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaakl
epfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
""
}
SubProgram ""gles3 "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out mediump vec3 xlv_TEXCOORD1;
out highp vec3 xlv_TEXCOORD2;
out mediump vec3 xlv_TEXCOORD3;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  lowp vec4 tmpvar_7;
  tmpvar_7.w = 1.0;
  tmpvar_7.xyz = worldNormal_1;
  mediump vec4 normal_8;
  normal_8 = tmpvar_7;
  mediump vec3 x2_9;
  mediump vec3 x1_10;
  x1_10.x = dot (unity_SHAr, normal_8);
  x1_10.y = dot (unity_SHAg, normal_8);
  x1_10.z = dot (unity_SHAb, normal_8);
  mediump vec4 tmpvar_11;
  tmpvar_11 = (normal_8.xyzz * normal_8.yzzx);
  x2_9.x = dot (unity_SHBr, tmpvar_11);
  x2_9.y = dot (unity_SHBg, tmpvar_11);
  x2_9.z = dot (unity_SHBb, tmpvar_11);
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = (_Object2World * _glesVertex).xyz;
  xlv_TEXCOORD3 = ((x2_9 + (unity_SHC.xyz * 
    ((normal_8.x * normal_8.x) - (normal_8.y * normal_8.y))
  )) + x1_10);
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _XYSMap;
in highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  _glesFragData[0] = c_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 24 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
Bind ""texcoord"" ATTR2
ConstBuffer ""$Globals"" 272
Matrix 64 [glstate_matrix_mvp]
Matrix 128 [_Object2World]
Matrix 192 [_World2Object]
VectorHalf 0 [unity_SHAr] 4
VectorHalf 8 [unity_SHAg] 4
VectorHalf 16 [unity_SHAb] 4
VectorHalf 24 [unity_SHBr] 4
VectorHalf 32 [unity_SHBg] 4
VectorHalf 40 [unity_SHBb] 4
VectorHalf 48 [unity_SHC] 4
Vector 256 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
  float4 _glesMultiTexCoord0 [[attribute(2)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  float2 xlv_TEXCOORD0;
  half3 xlv_TEXCOORD1;
  float3 xlv_TEXCOORD2;
  half3 xlv_TEXCOORD3;
};
struct xlatMtlShaderUniform {
  half4 unity_SHAr;
  half4 unity_SHAg;
  half4 unity_SHAb;
  half4 unity_SHBr;
  half4 unity_SHBg;
  half4 unity_SHBb;
  half4 unity_SHC;
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  float4 v_3;
  v_3.x = _mtl_u._World2Object[0].x;
  v_3.y = _mtl_u._World2Object[1].x;
  v_3.z = _mtl_u._World2Object[2].x;
  v_3.w = _mtl_u._World2Object[3].x;
  float4 v_4;
  v_4.x = _mtl_u._World2Object[0].y;
  v_4.y = _mtl_u._World2Object[1].y;
  v_4.z = _mtl_u._World2Object[2].y;
  v_4.w = _mtl_u._World2Object[3].y;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].z;
  v_5.y = _mtl_u._World2Object[1].z;
  v_5.z = _mtl_u._World2Object[2].z;
  v_5.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _mtl_i._glesNormal.x)
   + 
    (v_4.xyz * _mtl_i._glesNormal.y)
  ) + (v_5.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_6);
  tmpvar_2 = worldNormal_1;
  half4 tmpvar_7;
  tmpvar_7.w = half(1.0);
  tmpvar_7.xyz = worldNormal_1;
  half4 normal_8;
  normal_8 = tmpvar_7;
  half3 x2_9;
  half3 x1_10;
  x1_10.x = dot (_mtl_u.unity_SHAr, normal_8);
  x1_10.y = dot (_mtl_u.unity_SHAg, normal_8);
  x1_10.z = dot (_mtl_u.unity_SHAb, normal_8);
  half4 tmpvar_11;
  tmpvar_11 = (normal_8.xyzz * normal_8.yzzx);
  x2_9.x = dot (_mtl_u.unity_SHBr, tmpvar_11);
  x2_9.y = dot (_mtl_u.unity_SHBg, tmpvar_11);
  x2_9.z = dot (_mtl_u.unity_SHBb, tmpvar_11);
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  _mtl_o.xlv_TEXCOORD1 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD2 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  _mtl_o.xlv_TEXCOORD3 = ((x2_9 + (_mtl_u.unity_SHC.xyz * 
    ((normal_8.x * normal_8.x) - (normal_8.y * normal_8.y))
  )) + x1_10);
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLSL
#ifdef VERTEX
uniform vec4 _ProjectionParams;
uniform vec4 unity_SHAr;
uniform vec4 unity_SHAg;
uniform vec4 unity_SHAb;
uniform vec4 unity_SHBr;
uniform vec4 unity_SHBg;
uniform vec4 unity_SHBb;
uniform vec4 unity_SHC;

uniform mat4 _Object2World;
uniform mat4 _World2Object;
uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
varying vec3 xlv_TEXCOORD2;
varying vec3 xlv_TEXCOORD3;
varying vec4 xlv_TEXCOORD4;
void main ()
{
  vec4 tmpvar_1;
  tmpvar_1 = (gl_ModelViewProjectionMatrix * gl_Vertex);
  vec4 v_2;
  v_2.x = _World2Object[0].x;
  v_2.y = _World2Object[1].x;
  v_2.z = _World2Object[2].x;
  v_2.w = _World2Object[3].x;
  vec4 v_3;
  v_3.x = _World2Object[0].y;
  v_3.y = _World2Object[1].y;
  v_3.z = _World2Object[2].y;
  v_3.w = _World2Object[3].y;
  vec4 v_4;
  v_4.x = _World2Object[0].z;
  v_4.y = _World2Object[1].z;
  v_4.z = _World2Object[2].z;
  v_4.w = _World2Object[3].z;
  vec3 tmpvar_5;
  tmpvar_5 = normalize(((
    (v_2.xyz * gl_Normal.x)
   + 
    (v_3.xyz * gl_Normal.y)
  ) + (v_4.xyz * gl_Normal.z)));
  vec4 tmpvar_6;
  tmpvar_6.w = 1.0;
  tmpvar_6.xyz = tmpvar_5;
  vec3 x2_7;
  vec3 x1_8;
  x1_8.x = dot (unity_SHAr, tmpvar_6);
  x1_8.y = dot (unity_SHAg, tmpvar_6);
  x1_8.z = dot (unity_SHAb, tmpvar_6);
  vec4 tmpvar_9;
  tmpvar_9 = (tmpvar_5.xyzz * tmpvar_5.yzzx);
  x2_7.x = dot (unity_SHBr, tmpvar_9);
  x2_7.y = dot (unity_SHBg, tmpvar_9);
  x2_7.z = dot (unity_SHBb, tmpvar_9);
  vec4 o_10;
  vec4 tmpvar_11;
  tmpvar_11 = (tmpvar_1 * 0.5);
  vec2 tmpvar_12;
  tmpvar_12.x = tmpvar_11.x;
  tmpvar_12.y = (tmpvar_11.y * _ProjectionParams.x);
  o_10.xy = (tmpvar_12 + tmpvar_11.w);
  o_10.zw = tmpvar_1.zw;
  gl_Position = tmpvar_1;
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_5;
  xlv_TEXCOORD2 = (_Object2World * gl_Vertex).xyz;
  xlv_TEXCOORD3 = ((x2_7 + (unity_SHC.xyz * 
    ((tmpvar_5.x * tmpvar_5.x) - (tmpvar_5.y * tmpvar_5.y))
  )) + x1_8);
  xlv_TEXCOORD4 = o_10;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _XYSMap;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  vec4 c_1;
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 33 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
Vector 19 [_MainTex_ST]
Vector 10 [_ProjectionParams]
Vector 11 [_ScreenParams]
Vector 14 [unity_SHAb]
Vector 13 [unity_SHAg]
Vector 12 [unity_SHAr]
Vector 17 [unity_SHBb]
Vector 16 [unity_SHBg]
Vector 15 [unity_SHBr]
Vector 18 [unity_SHC]
""vs_2_0
def c20, 1, 0.5, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord v2
mad oT0.xy, v2, c19, c19.zwzw
dp4 oT2.x, c4, v0
dp4 oT2.y, c5, v0
dp4 oT2.z, c6, v0
mul r0.xyz, v1.y, c8
mad r0.xyz, c7, v1.x, r0
mad r0.xyz, c9, v1.z, r0
nrm r1.xyz, r0
mul r0.x, r1.y, r1.y
mad r0.x, r1.x, r1.x, -r0.x
mul r2, r1.yzzx, r1.xyzz
dp4 r3.x, c15, r2
dp4 r3.y, c16, r2
dp4 r3.z, c17, r2
mad r0.xyz, c18, r0.x, r3
mov r1.w, c20.x
dp4 r2.x, c12, r1
dp4 r2.y, c13, r1
dp4 r2.z, c14, r1
mov oT1.xyz, r1
add oT3.xyz, r0, r2
dp4 r0.y, c1, v0
mul r1.x, r0.y, c10.x
mul r1.w, r1.x, c20.y
dp4 r0.x, c0, v0
dp4 r0.w, c3, v0
mul r1.xz, r0.xyww, c20.y
mad oT4.xy, r1.z, c11.zwzw, r1.xwzw
dp4 r0.z, c2, v0
mov oPos, r0
mov oT4.zw, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 37 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 160
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityPerCamera"" 144
Vector 80 [_ProjectionParams]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerCamera"" 1
BindCB  ""UnityLighting"" 2
BindCB  ""UnityPerDraw"" 3
""vs_4_0
eefiecedjonafkmjhnpbgppmfjepnokichfceaipabaaaaaamaahaaaaadaaaaaa
cmaaaaaaceabaaaanmabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
apaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
nmafaaaaeaaaabaahhabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaae
egiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaacnaaaaaafjaaaaae
egiocaaaadaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaagiaaaaac
afaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
pccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaai
bcaabaaaabaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabaaaaaaadiaaaaai
ccaabaaaabaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabbaaaaaadiaaaaai
ecaabaaaabaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabcaaaaaadiaaaaai
bcaabaaaacaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabaaaaaaadiaaaaai
ccaabaaaacaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabbaaaaaadiaaaaai
ecaabaaaacaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabcaaaaaaaaaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaadiaaaaaibcaabaaa
acaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaa
acaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaa
acaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabcaaaaaaaaaaaaahhcaabaaa
abaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaaabaaaaaa
egacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaabaaaaaadkaabaaa
abaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaa
dgaaaaafhccabaaaacaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaa
fgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaa
egiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaacaaaaaadcaaaaak
hcaabaaaacaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
acaaaaaadcaaaaakhccabaaaadaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaacaaaaaadiaaaaahbcaabaaaacaaaaaabkaabaaaabaaaaaa
bkaabaaaabaaaaaadcaaaaakbcaabaaaacaaaaaaakaabaaaabaaaaaaakaabaaa
abaaaaaaakaabaiaebaaaaaaacaaaaaadiaaaaahpcaabaaaadaaaaaajgacbaaa
abaaaaaaegakbaaaabaaaaaabbaaaaaibcaabaaaaeaaaaaaegiocaaaacaaaaaa
cjaaaaaaegaobaaaadaaaaaabbaaaaaiccaabaaaaeaaaaaaegiocaaaacaaaaaa
ckaaaaaaegaobaaaadaaaaaabbaaaaaiecaabaaaaeaaaaaaegiocaaaacaaaaaa
claaaaaaegaobaaaadaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaa
cmaaaaaaagaabaaaacaaaaaaegacbaaaaeaaaaaadgaaaaaficaabaaaabaaaaaa
abeaaaaaaaaaiadpbbaaaaaibcaabaaaadaaaaaaegiocaaaacaaaaaacgaaaaaa
egaobaaaabaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaacaaaaaachaaaaaa
egaobaaaabaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaacaaaaaaciaaaaaa
egaobaaaabaaaaaaaaaaaaahhccabaaaaeaaaaaaegacbaaaacaaaaaaegacbaaa
adaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaa
afaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaafaaaaaakgaobaaaaaaaaaaa
aaaaaaahdccabaaaafaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaab
""
}
SubProgram ""gles "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying mediump vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying mediump vec3 xlv_TEXCOORD3;
varying mediump vec4 xlv_TEXCOORD4;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  mediump vec4 tmpvar_3;
  highp vec4 v_4;
  v_4.x = _World2Object[0].x;
  v_4.y = _World2Object[1].x;
  v_4.z = _World2Object[2].x;
  v_4.w = _World2Object[3].x;
  highp vec4 v_5;
  v_5.x = _World2Object[0].y;
  v_5.y = _World2Object[1].y;
  v_5.z = _World2Object[2].y;
  v_5.w = _World2Object[3].y;
  highp vec4 v_6;
  v_6.x = _World2Object[0].z;
  v_6.y = _World2Object[1].z;
  v_6.z = _World2Object[2].z;
  v_6.w = _World2Object[3].z;
  highp vec3 tmpvar_7;
  tmpvar_7 = normalize(((
    (v_4.xyz * _glesNormal.x)
   + 
    (v_5.xyz * _glesNormal.y)
  ) + (v_6.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_7;
  tmpvar_2 = worldNormal_1;
  lowp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = worldNormal_1;
  mediump vec4 normal_9;
  normal_9 = tmpvar_8;
  mediump vec3 x2_10;
  mediump vec3 x1_11;
  x1_11.x = dot (unity_SHAr, normal_9);
  x1_11.y = dot (unity_SHAg, normal_9);
  x1_11.z = dot (unity_SHAb, normal_9);
  mediump vec4 tmpvar_12;
  tmpvar_12 = (normal_9.xyzz * normal_9.yzzx);
  x2_10.x = dot (unity_SHBr, tmpvar_12);
  x2_10.y = dot (unity_SHBg, tmpvar_12);
  x2_10.z = dot (unity_SHBb, tmpvar_12);
  highp vec4 tmpvar_13;
  highp vec4 cse_14;
  cse_14 = (_Object2World * _glesVertex);
  tmpvar_13 = (unity_World2Shadow[0] * cse_14);
  tmpvar_3 = tmpvar_13;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = cse_14.xyz;
  xlv_TEXCOORD3 = ((x2_10 + (unity_SHC.xyz * 
    ((normal_9.x * normal_9.x) - (normal_9.y * normal_9.y))
  )) + x1_11);
  xlv_TEXCOORD4 = tmpvar_3;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _XYSMap;
varying highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""opengl "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
""!!GLSL
#ifdef VERTEX
uniform vec4 unity_4LightPosX0;
uniform vec4 unity_4LightPosY0;
uniform vec4 unity_4LightPosZ0;
uniform vec4 unity_4LightAtten0;
uniform vec4 unity_LightColor[8];
uniform vec4 unity_SHAr;
uniform vec4 unity_SHAg;
uniform vec4 unity_SHAb;
uniform vec4 unity_SHBr;
uniform vec4 unity_SHBg;
uniform vec4 unity_SHBb;
uniform vec4 unity_SHC;

uniform mat4 _Object2World;
uniform mat4 _World2Object;
uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
varying vec3 xlv_TEXCOORD2;
varying vec3 xlv_TEXCOORD3;
void main ()
{
  vec3 tmpvar_1;
  tmpvar_1 = (_Object2World * gl_Vertex).xyz;
  vec4 v_2;
  v_2.x = _World2Object[0].x;
  v_2.y = _World2Object[1].x;
  v_2.z = _World2Object[2].x;
  v_2.w = _World2Object[3].x;
  vec4 v_3;
  v_3.x = _World2Object[0].y;
  v_3.y = _World2Object[1].y;
  v_3.z = _World2Object[2].y;
  v_3.w = _World2Object[3].y;
  vec4 v_4;
  v_4.x = _World2Object[0].z;
  v_4.y = _World2Object[1].z;
  v_4.z = _World2Object[2].z;
  v_4.w = _World2Object[3].z;
  vec3 tmpvar_5;
  tmpvar_5 = normalize(((
    (v_2.xyz * gl_Normal.x)
   + 
    (v_3.xyz * gl_Normal.y)
  ) + (v_4.xyz * gl_Normal.z)));
  vec4 tmpvar_6;
  tmpvar_6.w = 1.0;
  tmpvar_6.xyz = tmpvar_5;
  vec3 x2_7;
  vec3 x1_8;
  x1_8.x = dot (unity_SHAr, tmpvar_6);
  x1_8.y = dot (unity_SHAg, tmpvar_6);
  x1_8.z = dot (unity_SHAb, tmpvar_6);
  vec4 tmpvar_9;
  tmpvar_9 = (tmpvar_5.xyzz * tmpvar_5.yzzx);
  x2_7.x = dot (unity_SHBr, tmpvar_9);
  x2_7.y = dot (unity_SHBg, tmpvar_9);
  x2_7.z = dot (unity_SHBb, tmpvar_9);
  vec4 tmpvar_10;
  tmpvar_10 = (unity_4LightPosX0 - tmpvar_1.x);
  vec4 tmpvar_11;
  tmpvar_11 = (unity_4LightPosY0 - tmpvar_1.y);
  vec4 tmpvar_12;
  tmpvar_12 = (unity_4LightPosZ0 - tmpvar_1.z);
  vec4 tmpvar_13;
  tmpvar_13 = (((tmpvar_10 * tmpvar_10) + (tmpvar_11 * tmpvar_11)) + (tmpvar_12 * tmpvar_12));
  vec4 tmpvar_14;
  tmpvar_14 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_10 * tmpvar_5.x) + (tmpvar_11 * tmpvar_5.y)) + (tmpvar_12 * tmpvar_5.z))
   * 
    inversesqrt(tmpvar_13)
  )) * (1.0/((1.0 + 
    (tmpvar_13 * unity_4LightAtten0)
  ))));
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_5;
  xlv_TEXCOORD2 = tmpvar_1;
  xlv_TEXCOORD3 = (((x2_7 + 
    (unity_SHC.xyz * ((tmpvar_5.x * tmpvar_5.x) - (tmpvar_5.y * tmpvar_5.y)))
  ) + x1_8) + ((
    ((unity_LightColor[0].xyz * tmpvar_14.x) + (unity_LightColor[1].xyz * tmpvar_14.y))
   + 
    (unity_LightColor[2].xyz * tmpvar_14.z)
  ) + (unity_LightColor[3].xyz * tmpvar_14.w)));
}


#endif
#ifdef FRAGMENT
uniform sampler2D _XYSMap;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  vec4 c_1;
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 55 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
Matrix 8 [_Object2World] 3
Matrix 11 [_World2Object] 3
Matrix 4 [glstate_matrix_mvp]
Vector 25 [_MainTex_ST]
Vector 17 [unity_4LightAtten0]
Vector 14 [unity_4LightPosX0]
Vector 15 [unity_4LightPosY0]
Vector 16 [unity_4LightPosZ0]
Vector 0 [unity_LightColor0]
Vector 1 [unity_LightColor1]
Vector 2 [unity_LightColor2]
Vector 3 [unity_LightColor3]
Vector 20 [unity_SHAb]
Vector 19 [unity_SHAg]
Vector 18 [unity_SHAr]
Vector 23 [unity_SHBb]
Vector 22 [unity_SHBg]
Vector 21 [unity_SHBr]
Vector 24 [unity_SHC]
""vs_2_0
def c26, 1, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord v2
dp4 oPos.x, c4, v0
dp4 oPos.y, c5, v0
dp4 oPos.z, c6, v0
dp4 oPos.w, c7, v0
mad oT0.xy, v2, c25, c25.zwzw
mul r0.xyz, v1.y, c12
mad r0.xyz, c11, v1.x, r0
mad r0.xyz, c13, v1.z, r0
nrm r1.xyz, r0
mul r0.x, r1.y, r1.y
mad r0.x, r1.x, r1.x, -r0.x
mul r2, r1.yzzx, r1.xyzz
dp4 r3.x, c21, r2
dp4 r3.y, c22, r2
dp4 r3.z, c23, r2
mad r0.xyz, c24, r0.x, r3
mov r1.w, c26.x
dp4 r2.x, c18, r1
dp4 r2.y, c19, r1
dp4 r2.z, c20, r1
add r0.xyz, r0, r2
dp4 r2.y, c9, v0
add r3, -r2.y, c15
mul r4, r1.y, r3
mul r3, r3, r3
dp4 r2.x, c8, v0
add r5, -r2.x, c14
mad r4, r5, r1.x, r4
mad r3, r5, r5, r3
dp4 r2.z, c10, v0
add r5, -r2.z, c16
mov oT2.xyz, r2
mad r2, r5, r1.z, r4
mov oT1.xyz, r1
mad r1, r5, r5, r3
rsq r3.x, r1.x
rsq r3.y, r1.y
rsq r3.z, r1.z
rsq r3.w, r1.w
mov r4.x, c26.x
mad r1, r1, c17, r4.x
mul r2, r2, r3
max r2, r2, c26.y
rcp r3.x, r1.x
rcp r3.y, r1.y
rcp r3.z, r1.z
rcp r3.w, r1.w
mul r1, r2, r3
mul r2.xyz, r1.y, c1
mad r2.xyz, c0, r1.x, r2
mad r1.xyz, c2, r1.z, r2
mad r1.xyz, c3, r1.w, r1
add oT3.xyz, r0, r1

""
}
SubProgram ""d3d11 "" {
// Stats: 54 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 160
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityLighting"" 720
Vector 32 [unity_4LightPosX0]
Vector 48 [unity_4LightPosY0]
Vector 64 [unity_4LightPosZ0]
Vector 80 [unity_4LightAtten0]
Vector 96 [unity_LightColor0]
Vector 112 [unity_LightColor1]
Vector 128 [unity_LightColor2]
Vector 144 [unity_LightColor3]
Vector 160 [unity_LightColor4]
Vector 176 [unity_LightColor5]
Vector 192 [unity_LightColor6]
Vector 208 [unity_LightColor7]
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityLighting"" 1
BindCB  ""UnityPerDraw"" 2
""vs_4_0
eefiecedcfcgpdcfnebddimbmmnfccgkfhooohgpabaaaaaammajaaaaadaaaaaa
cmaaaaaaceabaaaameabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaaimaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklfdeieefcaaaiaaaaeaaaabaaaaacaaaafjaaaaaeegiocaaaaaaaaaaa
akaaaaaafjaaaaaeegiocaaaabaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaa
bdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagiaaaaacagaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaafhccabaaa
acaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaaaaaaaaaa
egiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaa
amaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaa
abaaaaaadgaaaaafhccabaaaadaaaaaaegacbaaaabaaaaaadiaaaaahicaabaaa
abaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakicaabaaaabaaaaaa
akaabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaiaebaaaaaaabaaaaaadiaaaaah
pcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaa
adaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaa
adaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaa
adaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaaacaaaaaadcaaaaakhcaabaaa
acaaaaaaegiccaaaabaaaaaacmaaaaaapgapbaaaabaaaaaaegacbaaaadaaaaaa
dgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaadaaaaaa
egiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaadaaaaaa
egiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaadaaaaaa
egiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaaaaaaaaahhcaabaaaacaaaaaa
egacbaaaacaaaaaaegacbaaaadaaaaaaaaaaaaajpcaabaaaadaaaaaafgafbaia
ebaaaaaaabaaaaaaegiocaaaabaaaaaaadaaaaaadiaaaaahpcaabaaaaeaaaaaa
fgafbaaaaaaaaaaaegaobaaaadaaaaaadiaaaaahpcaabaaaadaaaaaaegaobaaa
adaaaaaaegaobaaaadaaaaaaaaaaaaajpcaabaaaafaaaaaaagaabaiaebaaaaaa
abaaaaaaegiocaaaabaaaaaaacaaaaaaaaaaaaajpcaabaaaabaaaaaakgakbaia
ebaaaaaaabaaaaaaegiocaaaabaaaaaaaeaaaaaadcaaaaajpcaabaaaaeaaaaaa
egaobaaaafaaaaaaagaabaaaaaaaaaaaegaobaaaaeaaaaaadcaaaaajpcaabaaa
aaaaaaaaegaobaaaabaaaaaakgakbaaaaaaaaaaaegaobaaaaeaaaaaadcaaaaaj
pcaabaaaadaaaaaaegaobaaaafaaaaaaegaobaaaafaaaaaaegaobaaaadaaaaaa
dcaaaaajpcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaaabaaaaaaegaobaaa
adaaaaaaeeaaaaafpcaabaaaadaaaaaaegaobaaaabaaaaaadcaaaaanpcaabaaa
abaaaaaaegaobaaaabaaaaaaegiocaaaabaaaaaaafaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaiadpaaaaiadpaoaaaaakpcaabaaaabaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaiadpaaaaiadpegaobaaaabaaaaaadiaaaaahpcaabaaaaaaaaaaa
egaobaaaaaaaaaaaegaobaaaadaaaaaadeaaaaakpcaabaaaaaaaaaaaegaobaaa
aaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaahpcaabaaa
aaaaaaaaegaobaaaabaaaaaaegaobaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgafbaaaaaaaaaaaegiccaaaabaaaaaaahaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaabaaaaaaagaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaabaaaaaaaiaaaaaakgakbaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaajaaaaaapgapbaaa
aaaaaaaaegacbaaaaaaaaaaaaaaaaaahhccabaaaaeaaaaaaegacbaaaaaaaaaaa
egacbaaaacaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform highp vec4 unity_4LightPosX0;
uniform highp vec4 unity_4LightPosY0;
uniform highp vec4 unity_4LightPosZ0;
uniform mediump vec4 unity_4LightAtten0;
uniform mediump vec4 unity_LightColor[8];
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying mediump vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying mediump vec3 xlv_TEXCOORD3;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec3 tmpvar_4;
  tmpvar_4 = (_Object2World * _glesVertex).xyz;
  highp vec4 v_5;
  v_5.x = _World2Object[0].x;
  v_5.y = _World2Object[1].x;
  v_5.z = _World2Object[2].x;
  v_5.w = _World2Object[3].x;
  highp vec4 v_6;
  v_6.x = _World2Object[0].y;
  v_6.y = _World2Object[1].y;
  v_6.z = _World2Object[2].y;
  v_6.w = _World2Object[3].y;
  highp vec4 v_7;
  v_7.x = _World2Object[0].z;
  v_7.y = _World2Object[1].z;
  v_7.z = _World2Object[2].z;
  v_7.w = _World2Object[3].z;
  highp vec3 tmpvar_8;
  tmpvar_8 = normalize(((
    (v_5.xyz * _glesNormal.x)
   + 
    (v_6.xyz * _glesNormal.y)
  ) + (v_7.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_8;
  tmpvar_2 = worldNormal_1;
  lowp vec4 tmpvar_9;
  tmpvar_9.w = 1.0;
  tmpvar_9.xyz = worldNormal_1;
  mediump vec3 tmpvar_10;
  mediump vec4 normal_11;
  normal_11 = tmpvar_9;
  mediump vec3 x2_12;
  mediump vec3 x1_13;
  x1_13.x = dot (unity_SHAr, normal_11);
  x1_13.y = dot (unity_SHAg, normal_11);
  x1_13.z = dot (unity_SHAb, normal_11);
  mediump vec4 tmpvar_14;
  tmpvar_14 = (normal_11.xyzz * normal_11.yzzx);
  x2_12.x = dot (unity_SHBr, tmpvar_14);
  x2_12.y = dot (unity_SHBg, tmpvar_14);
  x2_12.z = dot (unity_SHBb, tmpvar_14);
  tmpvar_10 = ((x2_12 + (unity_SHC.xyz * 
    ((normal_11.x * normal_11.x) - (normal_11.y * normal_11.y))
  )) + x1_13);
  highp vec3 lightColor0_15;
  lightColor0_15 = unity_LightColor[0].xyz;
  highp vec3 lightColor1_16;
  lightColor1_16 = unity_LightColor[1].xyz;
  highp vec3 lightColor2_17;
  lightColor2_17 = unity_LightColor[2].xyz;
  highp vec3 lightColor3_18;
  lightColor3_18 = unity_LightColor[3].xyz;
  highp vec4 lightAttenSq_19;
  lightAttenSq_19 = unity_4LightAtten0;
  highp vec3 normal_20;
  normal_20 = worldNormal_1;
  highp vec4 tmpvar_21;
  tmpvar_21 = (unity_4LightPosX0 - tmpvar_4.x);
  highp vec4 tmpvar_22;
  tmpvar_22 = (unity_4LightPosY0 - tmpvar_4.y);
  highp vec4 tmpvar_23;
  tmpvar_23 = (unity_4LightPosZ0 - tmpvar_4.z);
  highp vec4 tmpvar_24;
  tmpvar_24 = (((tmpvar_21 * tmpvar_21) + (tmpvar_22 * tmpvar_22)) + (tmpvar_23 * tmpvar_23));
  highp vec4 tmpvar_25;
  tmpvar_25 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_21 * normal_20.x) + (tmpvar_22 * normal_20.y)) + (tmpvar_23 * normal_20.z))
   * 
    inversesqrt(tmpvar_24)
  )) * (1.0/((1.0 + 
    (tmpvar_24 * lightAttenSq_19)
  ))));
  highp vec3 tmpvar_26;
  tmpvar_26 = (tmpvar_10 + ((
    ((lightColor0_15 * tmpvar_25.x) + (lightColor1_16 * tmpvar_25.y))
   + 
    (lightColor2_17 * tmpvar_25.z)
  ) + (lightColor3_18 * tmpvar_25.w)));
  tmpvar_3 = tmpvar_26;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = tmpvar_4;
  xlv_TEXCOORD3 = tmpvar_3;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _XYSMap;
varying highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 54 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 160
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityLighting"" 720
Vector 32 [unity_4LightPosX0]
Vector 48 [unity_4LightPosY0]
Vector 64 [unity_4LightPosZ0]
Vector 80 [unity_4LightAtten0]
Vector 96 [unity_LightColor0]
Vector 112 [unity_LightColor1]
Vector 128 [unity_LightColor2]
Vector 144 [unity_LightColor3]
Vector 160 [unity_LightColor4]
Vector 176 [unity_LightColor5]
Vector 192 [unity_LightColor6]
Vector 208 [unity_LightColor7]
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityLighting"" 1
BindCB  ""UnityPerDraw"" 2
""vs_4_0_level_9_1
eefiecedhfiabgpadipjpkbkpinjgdeiokinbjbcabaaaaaajaaoaaaaaeaaaaaa
daaaaaaapaaeaaaapiamaaaapaanaaaaebgpgodjliaeaaaaliaeaaaaaaacpopp
feaeaaaageaaaaaaafaaceaaaaaagaaaaaaagaaaaaaaceaaabaagaaaaaaaajaa
abaaabaaaaaaaaaaabaaacaaaiaaacaaaaaaaaaaabaacgaaahaaakaaaaaaaaaa
acaaaaaaaeaabbaaaaaaaaaaacaaamaaahaabfaaaaaaaaaaaaaaaaaaaaacpopp
fbaaaaafbmaaapkaaaaaiadpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacafaaaaia
aaaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjaaeaaaaae
aaaaadoaadaaoejaabaaoekaabaaookaafaaaaadaaaaabiaacaaaajabjaaaaka
afaaaaadaaaaaciaacaaaajabkaaaakaafaaaaadaaaaaeiaacaaaajablaaaaka
afaaaaadabaaabiaacaaffjabjaaffkaafaaaaadabaaaciaacaaffjabkaaffka
afaaaaadabaaaeiaacaaffjablaaffkaacaaaaadaaaaahiaaaaaoeiaabaaoeia
afaaaaadabaaabiaacaakkjabjaakkkaafaaaaadabaaaciaacaakkjabkaakkka
afaaaaadabaaaeiaacaakkjablaakkkaacaaaaadaaaaahiaaaaaoeiaabaaoeia
ceaaaaacabaaahiaaaaaoeiaafaaaaadaaaaabiaabaaffiaabaaffiaaeaaaaae
aaaaabiaabaaaaiaabaaaaiaaaaaaaibafaaaaadacaaapiaabaacjiaabaakeia
ajaaaaadadaaabiaanaaoekaacaaoeiaajaaaaadadaaaciaaoaaoekaacaaoeia
ajaaaaadadaaaeiaapaaoekaacaaoeiaaeaaaaaeaaaaahiabaaaoekaaaaaaaia
adaaoeiaabaaaaacabaaaiiabmaaaakaajaaaaadacaaabiaakaaoekaabaaoeia
ajaaaaadacaaaciaalaaoekaabaaoeiaajaaaaadacaaaeiaamaaoekaabaaoeia
acaaaaadaaaaahiaaaaaoeiaacaaoeiaafaaaaadacaaahiaaaaaffjabgaaoeka
aeaaaaaeacaaahiabfaaoekaaaaaaajaacaaoeiaaeaaaaaeacaaahiabhaaoeka
aaaakkjaacaaoeiaaeaaaaaeacaaahiabiaaoekaaaaappjaacaaoeiaacaaaaad
adaaapiaacaaffibadaaoekaafaaaaadaeaaapiaabaaffiaadaaoeiaafaaaaad
adaaapiaadaaoeiaadaaoeiaacaaaaadafaaapiaacaaaaibacaaoekaaeaaaaae
aeaaapiaafaaoeiaabaaaaiaaeaaoeiaaeaaaaaeadaaapiaafaaoeiaafaaoeia
adaaoeiaacaaaaadafaaapiaacaakkibaeaaoekaabaaaaacacaaahoaacaaoeia
aeaaaaaeacaaapiaafaaoeiaabaakkiaaeaaoeiaabaaaaacabaaahoaabaaoeia
aeaaaaaeabaaapiaafaaoeiaafaaoeiaadaaoeiaahaaaaacadaaabiaabaaaaia
ahaaaaacadaaaciaabaaffiaahaaaaacadaaaeiaabaakkiaahaaaaacadaaaiia
abaappiaabaaaaacaeaaabiabmaaaakaaeaaaaaeabaaapiaabaaoeiaafaaoeka
aeaaaaiaafaaaaadacaaapiaacaaoeiaadaaoeiaalaaaaadacaaapiaacaaoeia
bmaaffkaagaaaaacadaaabiaabaaaaiaagaaaaacadaaaciaabaaffiaagaaaaac
adaaaeiaabaakkiaagaaaaacadaaaiiaabaappiaafaaaaadabaaapiaacaaoeia
adaaoeiaafaaaaadacaaahiaabaaffiaahaaoekaaeaaaaaeacaaahiaagaaoeka
abaaaaiaacaaoeiaaeaaaaaeabaaahiaaiaaoekaabaakkiaacaaoeiaaeaaaaae
abaaahiaajaaoekaabaappiaabaaoeiaacaaaaadadaaahoaaaaaoeiaabaaoeia
afaaaaadaaaaapiaaaaaffjabcaaoekaaeaaaaaeaaaaapiabbaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaapiabdaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapia
beaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeia
abaaaaacaaaaammaaaaaoeiappppaaaafdeieefcaaaiaaaaeaaaabaaaaacaaaa
fjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaacnaaaaaa
fjaaaaaeegiocaaaacaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaacagaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaa
egbabaaaadaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaa
diaaaaaibcaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabaaaaaaa
diaaaaaiccaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabbaaaaaa
diaaaaaiecaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabcaaaaaa
diaaaaaibcaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabaaaaaaa
diaaaaaiccaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabbaaaaaa
diaaaaaiecaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabcaaaaaa
aaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaai
bcaabaaaabaaaaaackbabaaaacaaaaaackiacaaaacaaaaaabaaaaaaadiaaaaai
ccaabaaaabaaaaaackbabaaaacaaaaaackiacaaaacaaaaaabbaaaaaadiaaaaai
ecaabaaaabaaaaaackbabaaaacaaaaaackiacaaaacaaaaaabcaaaaaaaaaaaaah
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaa
aaaaaaaadgaaaaafhccabaaaacaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaa
abaaaaaafgbfbaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaadaaaaaaegacbaaa
abaaaaaadiaaaaahicaabaaaabaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaa
dcaaaaakicaabaaaabaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaia
ebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaa
aaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaa
acaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaa
acaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaa
acaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaabaaaaaacmaaaaaapgapbaaa
abaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadp
bbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaa
bbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaa
bbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaa
aaaaaaahhcaabaaaacaaaaaaegacbaaaacaaaaaaegacbaaaadaaaaaaaaaaaaaj
pcaabaaaadaaaaaafgafbaiaebaaaaaaabaaaaaaegiocaaaabaaaaaaadaaaaaa
diaaaaahpcaabaaaaeaaaaaafgafbaaaaaaaaaaaegaobaaaadaaaaaadiaaaaah
pcaabaaaadaaaaaaegaobaaaadaaaaaaegaobaaaadaaaaaaaaaaaaajpcaabaaa
afaaaaaaagaabaiaebaaaaaaabaaaaaaegiocaaaabaaaaaaacaaaaaaaaaaaaaj
pcaabaaaabaaaaaakgakbaiaebaaaaaaabaaaaaaegiocaaaabaaaaaaaeaaaaaa
dcaaaaajpcaabaaaaeaaaaaaegaobaaaafaaaaaaagaabaaaaaaaaaaaegaobaaa
aeaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgakbaaaaaaaaaaa
egaobaaaaeaaaaaadcaaaaajpcaabaaaadaaaaaaegaobaaaafaaaaaaegaobaaa
afaaaaaaegaobaaaadaaaaaadcaaaaajpcaabaaaabaaaaaaegaobaaaabaaaaaa
egaobaaaabaaaaaaegaobaaaadaaaaaaeeaaaaafpcaabaaaadaaaaaaegaobaaa
abaaaaaadcaaaaanpcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaaabaaaaaa
afaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpaoaaaaakpcaabaaa
abaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpegaobaaaabaaaaaa
diaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaaadaaaaaadeaaaaak
pcaabaaaaaaaaaaaegaobaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaabaaaaaaegaobaaaaaaaaaaa
diaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaabaaaaaaahaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaaagaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaaiaaaaaa
kgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
abaaaaaaajaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaahhccabaaa
aeaaaaaaegacbaaaaaaaaaaaegacbaaaacaaaaaadoaaaaabejfdeheopaaaaaaa
aiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaa
nbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapadaaaaoaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaa
oaaaaaaaacaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaa
aaaaaaaaadaaaaaaagaaaaaaapaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
ahaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaa
feeffiedepepfceeaaedepemepfcaaklepfdeheojiaaaaaaafaaaaaaaiaaaaaa
iaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaadamaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaahaiaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaa
imaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform highp vec4 unity_4LightPosX0;
uniform highp vec4 unity_4LightPosY0;
uniform highp vec4 unity_4LightPosZ0;
uniform mediump vec4 unity_4LightAtten0;
uniform mediump vec4 unity_LightColor[8];
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out mediump vec3 xlv_TEXCOORD1;
out highp vec3 xlv_TEXCOORD2;
out mediump vec3 xlv_TEXCOORD3;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec3 tmpvar_4;
  tmpvar_4 = (_Object2World * _glesVertex).xyz;
  highp vec4 v_5;
  v_5.x = _World2Object[0].x;
  v_5.y = _World2Object[1].x;
  v_5.z = _World2Object[2].x;
  v_5.w = _World2Object[3].x;
  highp vec4 v_6;
  v_6.x = _World2Object[0].y;
  v_6.y = _World2Object[1].y;
  v_6.z = _World2Object[2].y;
  v_6.w = _World2Object[3].y;
  highp vec4 v_7;
  v_7.x = _World2Object[0].z;
  v_7.y = _World2Object[1].z;
  v_7.z = _World2Object[2].z;
  v_7.w = _World2Object[3].z;
  highp vec3 tmpvar_8;
  tmpvar_8 = normalize(((
    (v_5.xyz * _glesNormal.x)
   + 
    (v_6.xyz * _glesNormal.y)
  ) + (v_7.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_8;
  tmpvar_2 = worldNormal_1;
  lowp vec4 tmpvar_9;
  tmpvar_9.w = 1.0;
  tmpvar_9.xyz = worldNormal_1;
  mediump vec3 tmpvar_10;
  mediump vec4 normal_11;
  normal_11 = tmpvar_9;
  mediump vec3 x2_12;
  mediump vec3 x1_13;
  x1_13.x = dot (unity_SHAr, normal_11);
  x1_13.y = dot (unity_SHAg, normal_11);
  x1_13.z = dot (unity_SHAb, normal_11);
  mediump vec4 tmpvar_14;
  tmpvar_14 = (normal_11.xyzz * normal_11.yzzx);
  x2_12.x = dot (unity_SHBr, tmpvar_14);
  x2_12.y = dot (unity_SHBg, tmpvar_14);
  x2_12.z = dot (unity_SHBb, tmpvar_14);
  tmpvar_10 = ((x2_12 + (unity_SHC.xyz * 
    ((normal_11.x * normal_11.x) - (normal_11.y * normal_11.y))
  )) + x1_13);
  highp vec3 lightColor0_15;
  lightColor0_15 = unity_LightColor[0].xyz;
  highp vec3 lightColor1_16;
  lightColor1_16 = unity_LightColor[1].xyz;
  highp vec3 lightColor2_17;
  lightColor2_17 = unity_LightColor[2].xyz;
  highp vec3 lightColor3_18;
  lightColor3_18 = unity_LightColor[3].xyz;
  highp vec4 lightAttenSq_19;
  lightAttenSq_19 = unity_4LightAtten0;
  highp vec3 normal_20;
  normal_20 = worldNormal_1;
  highp vec4 tmpvar_21;
  tmpvar_21 = (unity_4LightPosX0 - tmpvar_4.x);
  highp vec4 tmpvar_22;
  tmpvar_22 = (unity_4LightPosY0 - tmpvar_4.y);
  highp vec4 tmpvar_23;
  tmpvar_23 = (unity_4LightPosZ0 - tmpvar_4.z);
  highp vec4 tmpvar_24;
  tmpvar_24 = (((tmpvar_21 * tmpvar_21) + (tmpvar_22 * tmpvar_22)) + (tmpvar_23 * tmpvar_23));
  highp vec4 tmpvar_25;
  tmpvar_25 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_21 * normal_20.x) + (tmpvar_22 * normal_20.y)) + (tmpvar_23 * normal_20.z))
   * 
    inversesqrt(tmpvar_24)
  )) * (1.0/((1.0 + 
    (tmpvar_24 * lightAttenSq_19)
  ))));
  highp vec3 tmpvar_26;
  tmpvar_26 = (tmpvar_10 + ((
    ((lightColor0_15 * tmpvar_25.x) + (lightColor1_16 * tmpvar_25.y))
   + 
    (lightColor2_17 * tmpvar_25.z)
  ) + (lightColor3_18 * tmpvar_25.w)));
  tmpvar_3 = tmpvar_26;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = tmpvar_4;
  xlv_TEXCOORD3 = tmpvar_3;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _XYSMap;
in highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  _glesFragData[0] = c_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 52 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
Bind ""texcoord"" ATTR2
ConstBuffer ""$Globals"" 384
Matrix 176 [glstate_matrix_mvp]
Matrix 240 [_Object2World]
Matrix 304 [_World2Object]
Vector 0 [unity_4LightPosX0]
Vector 16 [unity_4LightPosY0]
Vector 32 [unity_4LightPosZ0]
VectorHalf 48 [unity_4LightAtten0] 4
VectorHalf 56 [unity_LightColor0] 4
VectorHalf 64 [unity_LightColor1] 4
VectorHalf 72 [unity_LightColor2] 4
VectorHalf 80 [unity_LightColor3] 4
VectorHalf 88 [unity_LightColor4] 4
VectorHalf 96 [unity_LightColor5] 4
VectorHalf 104 [unity_LightColor6] 4
VectorHalf 112 [unity_LightColor7] 4
VectorHalf 120 [unity_SHAr] 4
VectorHalf 128 [unity_SHAg] 4
VectorHalf 136 [unity_SHAb] 4
VectorHalf 144 [unity_SHBr] 4
VectorHalf 152 [unity_SHBg] 4
VectorHalf 160 [unity_SHBb] 4
VectorHalf 168 [unity_SHC] 4
Vector 368 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
  float4 _glesMultiTexCoord0 [[attribute(2)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  float2 xlv_TEXCOORD0;
  half3 xlv_TEXCOORD1;
  float3 xlv_TEXCOORD2;
  half3 xlv_TEXCOORD3;
};
struct xlatMtlShaderUniform {
  float4 unity_4LightPosX0;
  float4 unity_4LightPosY0;
  float4 unity_4LightPosZ0;
  half4 unity_4LightAtten0;
  half4 unity_LightColor[8];
  half4 unity_SHAr;
  half4 unity_SHAg;
  half4 unity_SHAb;
  half4 unity_SHBr;
  half4 unity_SHBg;
  half4 unity_SHBb;
  half4 unity_SHC;
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  half3 tmpvar_3;
  float3 tmpvar_4;
  tmpvar_4 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].x;
  v_5.y = _mtl_u._World2Object[1].x;
  v_5.z = _mtl_u._World2Object[2].x;
  v_5.w = _mtl_u._World2Object[3].x;
  float4 v_6;
  v_6.x = _mtl_u._World2Object[0].y;
  v_6.y = _mtl_u._World2Object[1].y;
  v_6.z = _mtl_u._World2Object[2].y;
  v_6.w = _mtl_u._World2Object[3].y;
  float4 v_7;
  v_7.x = _mtl_u._World2Object[0].z;
  v_7.y = _mtl_u._World2Object[1].z;
  v_7.z = _mtl_u._World2Object[2].z;
  v_7.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_8;
  tmpvar_8 = normalize(((
    (v_5.xyz * _mtl_i._glesNormal.x)
   + 
    (v_6.xyz * _mtl_i._glesNormal.y)
  ) + (v_7.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_8);
  tmpvar_2 = worldNormal_1;
  half4 tmpvar_9;
  tmpvar_9.w = half(1.0);
  tmpvar_9.xyz = worldNormal_1;
  half3 tmpvar_10;
  half4 normal_11;
  normal_11 = tmpvar_9;
  half3 x2_12;
  half3 x1_13;
  x1_13.x = dot (_mtl_u.unity_SHAr, normal_11);
  x1_13.y = dot (_mtl_u.unity_SHAg, normal_11);
  x1_13.z = dot (_mtl_u.unity_SHAb, normal_11);
  half4 tmpvar_14;
  tmpvar_14 = (normal_11.xyzz * normal_11.yzzx);
  x2_12.x = dot (_mtl_u.unity_SHBr, tmpvar_14);
  x2_12.y = dot (_mtl_u.unity_SHBg, tmpvar_14);
  x2_12.z = dot (_mtl_u.unity_SHBb, tmpvar_14);
  tmpvar_10 = ((x2_12 + (_mtl_u.unity_SHC.xyz * 
    ((normal_11.x * normal_11.x) - (normal_11.y * normal_11.y))
  )) + x1_13);
  float3 lightColor0_15;
  lightColor0_15 = float3(_mtl_u.unity_LightColor[0].xyz);
  float3 lightColor1_16;
  lightColor1_16 = float3(_mtl_u.unity_LightColor[1].xyz);
  float3 lightColor2_17;
  lightColor2_17 = float3(_mtl_u.unity_LightColor[2].xyz);
  float3 lightColor3_18;
  lightColor3_18 = float3(_mtl_u.unity_LightColor[3].xyz);
  float4 lightAttenSq_19;
  lightAttenSq_19 = float4(_mtl_u.unity_4LightAtten0);
  float3 normal_20;
  normal_20 = float3(worldNormal_1);
  float4 tmpvar_21;
  tmpvar_21 = (_mtl_u.unity_4LightPosX0 - tmpvar_4.x);
  float4 tmpvar_22;
  tmpvar_22 = (_mtl_u.unity_4LightPosY0 - tmpvar_4.y);
  float4 tmpvar_23;
  tmpvar_23 = (_mtl_u.unity_4LightPosZ0 - tmpvar_4.z);
  float4 tmpvar_24;
  tmpvar_24 = (((tmpvar_21 * tmpvar_21) + (tmpvar_22 * tmpvar_22)) + (tmpvar_23 * tmpvar_23));
  float4 tmpvar_25;
  tmpvar_25 = (max (float4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_21 * normal_20.x) + (tmpvar_22 * normal_20.y)) + (tmpvar_23 * normal_20.z))
   * 
    rsqrt(tmpvar_24)
  )) * (1.0/((1.0 + 
    (tmpvar_24 * lightAttenSq_19)
  ))));
  float3 tmpvar_26;
  tmpvar_26 = ((float3)tmpvar_10 + ((
    ((lightColor0_15 * tmpvar_25.x) + (lightColor1_16 * tmpvar_25.y))
   + 
    (lightColor2_17 * tmpvar_25.z)
  ) + (lightColor3_18 * tmpvar_25.w)));
  tmpvar_3 = half3(tmpvar_26);
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  _mtl_o.xlv_TEXCOORD1 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD2 = tmpvar_4;
  _mtl_o.xlv_TEXCOORD3 = tmpvar_3;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
""!!GLSL
#ifdef VERTEX
uniform vec4 _ProjectionParams;
uniform vec4 unity_4LightPosX0;
uniform vec4 unity_4LightPosY0;
uniform vec4 unity_4LightPosZ0;
uniform vec4 unity_4LightAtten0;
uniform vec4 unity_LightColor[8];
uniform vec4 unity_SHAr;
uniform vec4 unity_SHAg;
uniform vec4 unity_SHAb;
uniform vec4 unity_SHBr;
uniform vec4 unity_SHBg;
uniform vec4 unity_SHBb;
uniform vec4 unity_SHC;

uniform mat4 _Object2World;
uniform mat4 _World2Object;
uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
varying vec3 xlv_TEXCOORD2;
varying vec3 xlv_TEXCOORD3;
varying vec4 xlv_TEXCOORD4;
void main ()
{
  vec4 tmpvar_1;
  tmpvar_1 = (gl_ModelViewProjectionMatrix * gl_Vertex);
  vec3 tmpvar_2;
  tmpvar_2 = (_Object2World * gl_Vertex).xyz;
  vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * gl_Normal.x)
   + 
    (v_4.xyz * gl_Normal.y)
  ) + (v_5.xyz * gl_Normal.z)));
  vec4 tmpvar_7;
  tmpvar_7.w = 1.0;
  tmpvar_7.xyz = tmpvar_6;
  vec3 x2_8;
  vec3 x1_9;
  x1_9.x = dot (unity_SHAr, tmpvar_7);
  x1_9.y = dot (unity_SHAg, tmpvar_7);
  x1_9.z = dot (unity_SHAb, tmpvar_7);
  vec4 tmpvar_10;
  tmpvar_10 = (tmpvar_6.xyzz * tmpvar_6.yzzx);
  x2_8.x = dot (unity_SHBr, tmpvar_10);
  x2_8.y = dot (unity_SHBg, tmpvar_10);
  x2_8.z = dot (unity_SHBb, tmpvar_10);
  vec4 tmpvar_11;
  tmpvar_11 = (unity_4LightPosX0 - tmpvar_2.x);
  vec4 tmpvar_12;
  tmpvar_12 = (unity_4LightPosY0 - tmpvar_2.y);
  vec4 tmpvar_13;
  tmpvar_13 = (unity_4LightPosZ0 - tmpvar_2.z);
  vec4 tmpvar_14;
  tmpvar_14 = (((tmpvar_11 * tmpvar_11) + (tmpvar_12 * tmpvar_12)) + (tmpvar_13 * tmpvar_13));
  vec4 tmpvar_15;
  tmpvar_15 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_11 * tmpvar_6.x) + (tmpvar_12 * tmpvar_6.y)) + (tmpvar_13 * tmpvar_6.z))
   * 
    inversesqrt(tmpvar_14)
  )) * (1.0/((1.0 + 
    (tmpvar_14 * unity_4LightAtten0)
  ))));
  vec4 o_16;
  vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_1 * 0.5);
  vec2 tmpvar_18;
  tmpvar_18.x = tmpvar_17.x;
  tmpvar_18.y = (tmpvar_17.y * _ProjectionParams.x);
  o_16.xy = (tmpvar_18 + tmpvar_17.w);
  o_16.zw = tmpvar_1.zw;
  gl_Position = tmpvar_1;
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_6;
  xlv_TEXCOORD2 = tmpvar_2;
  xlv_TEXCOORD3 = (((x2_8 + 
    (unity_SHC.xyz * ((tmpvar_6.x * tmpvar_6.x) - (tmpvar_6.y * tmpvar_6.y)))
  ) + x1_9) + ((
    ((unity_LightColor[0].xyz * tmpvar_15.x) + (unity_LightColor[1].xyz * tmpvar_15.y))
   + 
    (unity_LightColor[2].xyz * tmpvar_15.z)
  ) + (unity_LightColor[3].xyz * tmpvar_15.w)));
  xlv_TEXCOORD4 = o_16;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _XYSMap;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  vec4 c_1;
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 61 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
Matrix 8 [_Object2World] 3
Matrix 11 [_World2Object] 3
Matrix 4 [glstate_matrix_mvp]
Vector 27 [_MainTex_ST]
Vector 14 [_ProjectionParams]
Vector 15 [_ScreenParams]
Vector 19 [unity_4LightAtten0]
Vector 16 [unity_4LightPosX0]
Vector 17 [unity_4LightPosY0]
Vector 18 [unity_4LightPosZ0]
Vector 0 [unity_LightColor0]
Vector 1 [unity_LightColor1]
Vector 2 [unity_LightColor2]
Vector 3 [unity_LightColor3]
Vector 22 [unity_SHAb]
Vector 21 [unity_SHAg]
Vector 20 [unity_SHAr]
Vector 25 [unity_SHBb]
Vector 24 [unity_SHBg]
Vector 23 [unity_SHBr]
Vector 26 [unity_SHC]
""vs_2_0
def c28, 1, 0, 0.5, 0
dcl_position v0
dcl_normal v1
dcl_texcoord v2
mad oT0.xy, v2, c27, c27.zwzw
mul r0.xyz, v1.y, c12
mad r0.xyz, c11, v1.x, r0
mad r0.xyz, c13, v1.z, r0
nrm r1.xyz, r0
mul r0.x, r1.y, r1.y
mad r0.x, r1.x, r1.x, -r0.x
mul r2, r1.yzzx, r1.xyzz
dp4 r3.x, c23, r2
dp4 r3.y, c24, r2
dp4 r3.z, c25, r2
mad r0.xyz, c26, r0.x, r3
mov r1.w, c28.x
dp4 r2.x, c20, r1
dp4 r2.y, c21, r1
dp4 r2.z, c22, r1
add r0.xyz, r0, r2
dp4 r2.y, c9, v0
add r3, -r2.y, c17
mul r4, r1.y, r3
mul r3, r3, r3
dp4 r2.x, c8, v0
add r5, -r2.x, c16
mad r4, r5, r1.x, r4
mad r3, r5, r5, r3
dp4 r2.z, c10, v0
add r5, -r2.z, c18
mov oT2.xyz, r2
mad r2, r5, r1.z, r4
mov oT1.xyz, r1
mad r1, r5, r5, r3
rsq r3.x, r1.x
rsq r3.y, r1.y
rsq r3.z, r1.z
rsq r3.w, r1.w
mov r4.x, c28.x
mad r1, r1, c19, r4.x
mul r2, r2, r3
max r2, r2, c28.y
rcp r3.x, r1.x
rcp r3.y, r1.y
rcp r3.z, r1.z
rcp r3.w, r1.w
mul r1, r2, r3
mul r2.xyz, r1.y, c1
mad r2.xyz, c0, r1.x, r2
mad r1.xyz, c2, r1.z, r2
mad r1.xyz, c3, r1.w, r1
add oT3.xyz, r0, r1
dp4 r0.y, c5, v0
mul r1.x, r0.y, c14.x
mul r1.w, r1.x, c28.z
dp4 r0.x, c4, v0
dp4 r0.w, c7, v0
mul r1.xz, r0.xyww, c28.z
mad oT4.xy, r1.z, c15.zwzw, r1.xwzw
dp4 r0.z, c6, v0
mov oPos, r0
mov oT4.zw, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 57 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 160
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityPerCamera"" 144
Vector 80 [_ProjectionParams]
ConstBuffer ""UnityLighting"" 720
Vector 32 [unity_4LightPosX0]
Vector 48 [unity_4LightPosY0]
Vector 64 [unity_4LightPosZ0]
Vector 80 [unity_4LightAtten0]
Vector 96 [unity_LightColor0]
Vector 112 [unity_LightColor1]
Vector 128 [unity_LightColor2]
Vector 144 [unity_LightColor3]
Vector 160 [unity_LightColor4]
Vector 176 [unity_LightColor5]
Vector 192 [unity_LightColor6]
Vector 208 [unity_LightColor7]
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerCamera"" 1
BindCB  ""UnityLighting"" 2
BindCB  ""UnityPerDraw"" 3
""vs_4_0
eefiecedffmbfnggakpegholkgblahffmcdhddiiabaaaaaaimakaaaaadaaaaaa
cmaaaaaaceabaaaanmabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
apaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
kiaiaaaaeaaaabaackacaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaae
egiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaacnaaaaaafjaaaaae
egiocaaaadaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaagiaaaaac
ahaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
pccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaai
bcaabaaaabaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabaaaaaaadiaaaaai
ccaabaaaabaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabbaaaaaadiaaaaai
ecaabaaaabaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabcaaaaaadiaaaaai
bcaabaaaacaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabaaaaaaadiaaaaai
ccaabaaaacaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabbaaaaaadiaaaaai
ecaabaaaacaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabcaaaaaaaaaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaadiaaaaaibcaabaaa
acaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaa
acaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaa
acaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabcaaaaaaaaaaaaahhcaabaaa
abaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaaabaaaaaa
egacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaabaaaaaadkaabaaa
abaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaa
dgaaaaafhccabaaaacaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaa
fgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaa
egiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaacaaaaaadcaaaaak
hcaabaaaacaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
acaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaacaaaaaadgaaaaafhccabaaaadaaaaaaegacbaaaacaaaaaa
diaaaaahicaabaaaacaaaaaabkaabaaaabaaaaaabkaabaaaabaaaaaadcaaaaak
icaabaaaacaaaaaaakaabaaaabaaaaaaakaabaaaabaaaaaadkaabaiaebaaaaaa
acaaaaaadiaaaaahpcaabaaaadaaaaaajgacbaaaabaaaaaaegakbaaaabaaaaaa
bbaaaaaibcaabaaaaeaaaaaaegiocaaaacaaaaaacjaaaaaaegaobaaaadaaaaaa
bbaaaaaiccaabaaaaeaaaaaaegiocaaaacaaaaaackaaaaaaegaobaaaadaaaaaa
bbaaaaaiecaabaaaaeaaaaaaegiocaaaacaaaaaaclaaaaaaegaobaaaadaaaaaa
dcaaaaakhcaabaaaadaaaaaaegiccaaaacaaaaaacmaaaaaapgapbaaaacaaaaaa
egacbaaaaeaaaaaadgaaaaaficaabaaaabaaaaaaabeaaaaaaaaaiadpbbaaaaai
bcaabaaaaeaaaaaaegiocaaaacaaaaaacgaaaaaaegaobaaaabaaaaaabbaaaaai
ccaabaaaaeaaaaaaegiocaaaacaaaaaachaaaaaaegaobaaaabaaaaaabbaaaaai
ecaabaaaaeaaaaaaegiocaaaacaaaaaaciaaaaaaegaobaaaabaaaaaaaaaaaaah
hcaabaaaadaaaaaaegacbaaaadaaaaaaegacbaaaaeaaaaaaaaaaaaajpcaabaaa
aeaaaaaafgafbaiaebaaaaaaacaaaaaaegiocaaaacaaaaaaadaaaaaadiaaaaah
pcaabaaaafaaaaaafgafbaaaabaaaaaaegaobaaaaeaaaaaadiaaaaahpcaabaaa
aeaaaaaaegaobaaaaeaaaaaaegaobaaaaeaaaaaaaaaaaaajpcaabaaaagaaaaaa
agaabaiaebaaaaaaacaaaaaaegiocaaaacaaaaaaacaaaaaaaaaaaaajpcaabaaa
acaaaaaakgakbaiaebaaaaaaacaaaaaaegiocaaaacaaaaaaaeaaaaaadcaaaaaj
pcaabaaaafaaaaaaegaobaaaagaaaaaaagaabaaaabaaaaaaegaobaaaafaaaaaa
dcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaakgakbaaaabaaaaaaegaobaaa
afaaaaaadcaaaaajpcaabaaaaeaaaaaaegaobaaaagaaaaaaegaobaaaagaaaaaa
egaobaaaaeaaaaaadcaaaaajpcaabaaaacaaaaaaegaobaaaacaaaaaaegaobaaa
acaaaaaaegaobaaaaeaaaaaaeeaaaaafpcaabaaaaeaaaaaaegaobaaaacaaaaaa
dcaaaaanpcaabaaaacaaaaaaegaobaaaacaaaaaaegiocaaaacaaaaaaafaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpaoaaaaakpcaabaaaacaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpegaobaaaacaaaaaadiaaaaah
pcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaaaeaaaaaadeaaaaakpcaabaaa
abaaaaaaegaobaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
diaaaaahpcaabaaaabaaaaaaegaobaaaacaaaaaaegaobaaaabaaaaaadiaaaaai
hcaabaaaacaaaaaafgafbaaaabaaaaaaegiccaaaacaaaaaaahaaaaaadcaaaaak
hcaabaaaacaaaaaaegiccaaaacaaaaaaagaaaaaaagaabaaaabaaaaaaegacbaaa
acaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaaaiaaaaaakgakbaaa
abaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaa
ajaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaaaaaaaaahhccabaaaaeaaaaaa
egacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaa
aaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaa
aaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaa
afaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaafaaaaaakgakbaaaabaaaaaa
mgaabaaaabaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform highp vec4 unity_4LightPosX0;
uniform highp vec4 unity_4LightPosY0;
uniform highp vec4 unity_4LightPosZ0;
uniform mediump vec4 unity_4LightAtten0;
uniform mediump vec4 unity_LightColor[8];
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying mediump vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying mediump vec3 xlv_TEXCOORD3;
varying mediump vec4 xlv_TEXCOORD4;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  mediump vec4 tmpvar_4;
  highp vec4 cse_5;
  cse_5 = (_Object2World * _glesVertex);
  highp vec4 v_6;
  v_6.x = _World2Object[0].x;
  v_6.y = _World2Object[1].x;
  v_6.z = _World2Object[2].x;
  v_6.w = _World2Object[3].x;
  highp vec4 v_7;
  v_7.x = _World2Object[0].y;
  v_7.y = _World2Object[1].y;
  v_7.z = _World2Object[2].y;
  v_7.w = _World2Object[3].y;
  highp vec4 v_8;
  v_8.x = _World2Object[0].z;
  v_8.y = _World2Object[1].z;
  v_8.z = _World2Object[2].z;
  v_8.w = _World2Object[3].z;
  highp vec3 tmpvar_9;
  tmpvar_9 = normalize(((
    (v_6.xyz * _glesNormal.x)
   + 
    (v_7.xyz * _glesNormal.y)
  ) + (v_8.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_9;
  tmpvar_2 = worldNormal_1;
  lowp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = worldNormal_1;
  mediump vec3 tmpvar_11;
  mediump vec4 normal_12;
  normal_12 = tmpvar_10;
  mediump vec3 x2_13;
  mediump vec3 x1_14;
  x1_14.x = dot (unity_SHAr, normal_12);
  x1_14.y = dot (unity_SHAg, normal_12);
  x1_14.z = dot (unity_SHAb, normal_12);
  mediump vec4 tmpvar_15;
  tmpvar_15 = (normal_12.xyzz * normal_12.yzzx);
  x2_13.x = dot (unity_SHBr, tmpvar_15);
  x2_13.y = dot (unity_SHBg, tmpvar_15);
  x2_13.z = dot (unity_SHBb, tmpvar_15);
  tmpvar_11 = ((x2_13 + (unity_SHC.xyz * 
    ((normal_12.x * normal_12.x) - (normal_12.y * normal_12.y))
  )) + x1_14);
  highp vec3 lightColor0_16;
  lightColor0_16 = unity_LightColor[0].xyz;
  highp vec3 lightColor1_17;
  lightColor1_17 = unity_LightColor[1].xyz;
  highp vec3 lightColor2_18;
  lightColor2_18 = unity_LightColor[2].xyz;
  highp vec3 lightColor3_19;
  lightColor3_19 = unity_LightColor[3].xyz;
  highp vec4 lightAttenSq_20;
  lightAttenSq_20 = unity_4LightAtten0;
  highp vec3 normal_21;
  normal_21 = worldNormal_1;
  highp vec4 tmpvar_22;
  tmpvar_22 = (unity_4LightPosX0 - cse_5.x);
  highp vec4 tmpvar_23;
  tmpvar_23 = (unity_4LightPosY0 - cse_5.y);
  highp vec4 tmpvar_24;
  tmpvar_24 = (unity_4LightPosZ0 - cse_5.z);
  highp vec4 tmpvar_25;
  tmpvar_25 = (((tmpvar_22 * tmpvar_22) + (tmpvar_23 * tmpvar_23)) + (tmpvar_24 * tmpvar_24));
  highp vec4 tmpvar_26;
  tmpvar_26 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_22 * normal_21.x) + (tmpvar_23 * normal_21.y)) + (tmpvar_24 * normal_21.z))
   * 
    inversesqrt(tmpvar_25)
  )) * (1.0/((1.0 + 
    (tmpvar_25 * lightAttenSq_20)
  ))));
  highp vec3 tmpvar_27;
  tmpvar_27 = (tmpvar_11 + ((
    ((lightColor0_16 * tmpvar_26.x) + (lightColor1_17 * tmpvar_26.y))
   + 
    (lightColor2_18 * tmpvar_26.z)
  ) + (lightColor3_19 * tmpvar_26.w)));
  tmpvar_3 = tmpvar_27;
  highp vec4 tmpvar_28;
  tmpvar_28 = (unity_World2Shadow[0] * cse_5);
  tmpvar_4 = tmpvar_28;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = cse_5.xyz;
  xlv_TEXCOORD3 = tmpvar_3;
  xlv_TEXCOORD4 = tmpvar_4;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _XYSMap;
varying highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""gles "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLES


#ifdef VERTEX

#extension GL_EXT_shadow_samplers : enable
attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying mediump vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying mediump vec3 xlv_TEXCOORD3;
varying mediump vec4 xlv_TEXCOORD4;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  mediump vec4 tmpvar_3;
  highp vec4 v_4;
  v_4.x = _World2Object[0].x;
  v_4.y = _World2Object[1].x;
  v_4.z = _World2Object[2].x;
  v_4.w = _World2Object[3].x;
  highp vec4 v_5;
  v_5.x = _World2Object[0].y;
  v_5.y = _World2Object[1].y;
  v_5.z = _World2Object[2].y;
  v_5.w = _World2Object[3].y;
  highp vec4 v_6;
  v_6.x = _World2Object[0].z;
  v_6.y = _World2Object[1].z;
  v_6.z = _World2Object[2].z;
  v_6.w = _World2Object[3].z;
  highp vec3 tmpvar_7;
  tmpvar_7 = normalize(((
    (v_4.xyz * _glesNormal.x)
   + 
    (v_5.xyz * _glesNormal.y)
  ) + (v_6.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_7;
  tmpvar_2 = worldNormal_1;
  lowp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = worldNormal_1;
  mediump vec4 normal_9;
  normal_9 = tmpvar_8;
  mediump vec3 x2_10;
  mediump vec3 x1_11;
  x1_11.x = dot (unity_SHAr, normal_9);
  x1_11.y = dot (unity_SHAg, normal_9);
  x1_11.z = dot (unity_SHAb, normal_9);
  mediump vec4 tmpvar_12;
  tmpvar_12 = (normal_9.xyzz * normal_9.yzzx);
  x2_10.x = dot (unity_SHBr, tmpvar_12);
  x2_10.y = dot (unity_SHBg, tmpvar_12);
  x2_10.z = dot (unity_SHBb, tmpvar_12);
  highp vec4 tmpvar_13;
  highp vec4 cse_14;
  cse_14 = (_Object2World * _glesVertex);
  tmpvar_13 = (unity_World2Shadow[0] * cse_14);
  tmpvar_3 = tmpvar_13;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = cse_14.xyz;
  xlv_TEXCOORD3 = ((x2_10 + (unity_SHC.xyz * 
    ((normal_9.x * normal_9.x) - (normal_9.y * normal_9.y))
  )) + x1_11);
  xlv_TEXCOORD4 = tmpvar_3;
}



#endif
#ifdef FRAGMENT

#extension GL_EXT_shadow_samplers : enable
uniform sampler2D _XYSMap;
varying highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 42 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 160
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityShadows"" 416
Matrix 128 [unity_World2Shadow0]
Matrix 192 [unity_World2Shadow1]
Matrix 256 [unity_World2Shadow2]
Matrix 320 [unity_World2Shadow3]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityLighting"" 1
BindCB  ""UnityShadows"" 2
BindCB  ""UnityPerDraw"" 3
""vs_4_0_level_9_1
eefiecedoclpebndggpbjdlkdklalohdoflgfolnabaaaaaaaiamaaaaaeaaaaaa
daaaaaaanaadaaaafiakaaaafaalaaaaebgpgodjjiadaaaajiadaaaaaaacpopp
deadaaaageaaaaaaafaaceaaaaaagaaaaaaagaaaaaaaceaaabaagaaaaaaaajaa
abaaabaaaaaaaaaaabaacgaaahaaacaaaaaaaaaaacaaaiaaaeaaajaaaaaaaaaa
adaaaaaaaeaaanaaaaaaaaaaadaaamaaahaabbaaaaaaaaaaaaaaaaaaaaacpopp
fbaaaaafbiaaapkaaaaaiadpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacafaaaaia
aaaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjaaeaaaaae
aaaaadoaadaaoejaabaaoekaabaaookaafaaaaadaaaaahiaaaaaffjabcaaoeka
aeaaaaaeaaaaahiabbaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahiabdaaoeka
aaaakkjaaaaaoeiaaeaaaaaeacaaahoabeaaoekaaaaappjaaaaaoeiaafaaaaad
aaaaabiaacaaaajabfaaaakaafaaaaadaaaaaciaacaaaajabgaaaakaafaaaaad
aaaaaeiaacaaaajabhaaaakaafaaaaadabaaabiaacaaffjabfaaffkaafaaaaad
abaaaciaacaaffjabgaaffkaafaaaaadabaaaeiaacaaffjabhaaffkaacaaaaad
aaaaahiaaaaaoeiaabaaoeiaafaaaaadabaaabiaacaakkjabfaakkkaafaaaaad
abaaaciaacaakkjabgaakkkaafaaaaadabaaaeiaacaakkjabhaakkkaacaaaaad
aaaaahiaaaaaoeiaabaaoeiaceaaaaacabaaahiaaaaaoeiaafaaaaadaaaaabia
abaaffiaabaaffiaaeaaaaaeaaaaabiaabaaaaiaabaaaaiaaaaaaaibafaaaaad
acaaapiaabaacjiaabaakeiaajaaaaadadaaabiaafaaoekaacaaoeiaajaaaaad
adaaaciaagaaoekaacaaoeiaajaaaaadadaaaeiaahaaoekaacaaoeiaaeaaaaae
aaaaahiaaiaaoekaaaaaaaiaadaaoeiaabaaaaacabaaaiiabiaaaakaajaaaaad
acaaabiaacaaoekaabaaoeiaajaaaaadacaaaciaadaaoekaabaaoeiaajaaaaad
acaaaeiaaeaaoekaabaaoeiaabaaaaacabaaahoaabaaoeiaacaaaaadadaaahoa
aaaaoeiaacaaoeiaafaaaaadaaaaapiaaaaaffjabcaaoekaaeaaaaaeaaaaapia
bbaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiabdaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiabeaaoekaaaaappjaaaaaoeiaafaaaaadabaaapiaaaaaffia
akaaoekaaeaaaaaeabaaapiaajaaoekaaaaaaaiaabaaoeiaaeaaaaaeabaaapia
alaaoekaaaaakkiaabaaoeiaaeaaaaaeaeaaapoaamaaoekaaaaappiaabaaoeia
afaaaaadaaaaapiaaaaaffjaaoaaoekaaeaaaaaeaaaaapiaanaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaapiaapaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapia
baaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeia
abaaaaacaaaaammaaaaaoeiappppaaaafdeieefciaagaaaaeaaaabaakaabaaaa
fjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaacnaaaaaa
fjaaaaaeegiocaaaacaaaaaaamaaaaaafjaaaaaeegiocaaaadaaaaaabdaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaa
adaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaa
gfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaa
aeaaaaaagfaaaaadpccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaai
bcaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabaaaaaaadiaaaaai
ccaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabbaaaaaadiaaaaai
ecaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabcaaaaaadiaaaaai
bcaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabaaaaaaadiaaaaai
ccaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabbaaaaaadiaaaaai
ecaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabcaaaaaaaaaaaaah
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaa
abaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaa
abaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaa
abaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabcaaaaaaaaaaaaahhcaabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaa
dgaaaaafhccabaaaacaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaakhccabaaaadaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaabaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaaaaaaaaaa
bkaabaaaaaaaaaaadcaaaaakbcaabaaaabaaaaaaakaabaaaaaaaaaaaakaabaaa
aaaaaaaaakaabaiaebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaa
aaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaa
cjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaa
ckaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaa
claaaaaaegaobaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaa
cmaaaaaaagaabaaaabaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaaaaaaaaaa
abeaaaaaaaaaiadpbbaaaaaibcaabaaaacaaaaaaegiocaaaabaaaaaacgaaaaaa
egaobaaaaaaaaaaabbaaaaaiccaabaaaacaaaaaaegiocaaaabaaaaaachaaaaaa
egaobaaaaaaaaaaabbaaaaaiecaabaaaacaaaaaaegiocaaaabaaaaaaciaaaaaa
egaobaaaaaaaaaaaaaaaaaahhccabaaaaeaaaaaaegacbaaaabaaaaaaegacbaaa
acaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaa
anaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaamaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaai
pcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaaacaaaaaaajaaaaaadcaaaaak
pcaabaaaabaaaaaaegiocaaaacaaaaaaaiaaaaaaagaabaaaaaaaaaaaegaobaaa
abaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaacaaaaaaakaaaaaakgakbaaa
aaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaafaaaaaaegiocaaaacaaaaaa
alaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaadoaaaaabejfdeheopaaaaaaa
aiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaa
nbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapadaaaaoaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaa
oaaaaaaaacaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaa
aaaaaaaaadaaaaaaagaaaaaaapaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
ahaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaa
feeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaa
jiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaa
keaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaafaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out mediump vec3 xlv_TEXCOORD1;
out highp vec3 xlv_TEXCOORD2;
out mediump vec3 xlv_TEXCOORD3;
out mediump vec4 xlv_TEXCOORD4;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  mediump vec4 tmpvar_3;
  highp vec4 v_4;
  v_4.x = _World2Object[0].x;
  v_4.y = _World2Object[1].x;
  v_4.z = _World2Object[2].x;
  v_4.w = _World2Object[3].x;
  highp vec4 v_5;
  v_5.x = _World2Object[0].y;
  v_5.y = _World2Object[1].y;
  v_5.z = _World2Object[2].y;
  v_5.w = _World2Object[3].y;
  highp vec4 v_6;
  v_6.x = _World2Object[0].z;
  v_6.y = _World2Object[1].z;
  v_6.z = _World2Object[2].z;
  v_6.w = _World2Object[3].z;
  highp vec3 tmpvar_7;
  tmpvar_7 = normalize(((
    (v_4.xyz * _glesNormal.x)
   + 
    (v_5.xyz * _glesNormal.y)
  ) + (v_6.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_7;
  tmpvar_2 = worldNormal_1;
  lowp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = worldNormal_1;
  mediump vec4 normal_9;
  normal_9 = tmpvar_8;
  mediump vec3 x2_10;
  mediump vec3 x1_11;
  x1_11.x = dot (unity_SHAr, normal_9);
  x1_11.y = dot (unity_SHAg, normal_9);
  x1_11.z = dot (unity_SHAb, normal_9);
  mediump vec4 tmpvar_12;
  tmpvar_12 = (normal_9.xyzz * normal_9.yzzx);
  x2_10.x = dot (unity_SHBr, tmpvar_12);
  x2_10.y = dot (unity_SHBg, tmpvar_12);
  x2_10.z = dot (unity_SHBb, tmpvar_12);
  highp vec4 tmpvar_13;
  highp vec4 cse_14;
  cse_14 = (_Object2World * _glesVertex);
  tmpvar_13 = (unity_World2Shadow[0] * cse_14);
  tmpvar_3 = tmpvar_13;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = cse_14.xyz;
  xlv_TEXCOORD3 = ((x2_10 + (unity_SHC.xyz * 
    ((normal_9.x * normal_9.x) - (normal_9.y * normal_9.y))
  )) + x1_11);
  xlv_TEXCOORD4 = tmpvar_3;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _XYSMap;
in highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  _glesFragData[0] = c_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 25 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
Bind ""texcoord"" ATTR2
ConstBuffer ""$Globals"" 528
Matrix 64 [unity_World2Shadow0]
Matrix 128 [unity_World2Shadow1]
Matrix 192 [unity_World2Shadow2]
Matrix 256 [unity_World2Shadow3]
Matrix 320 [glstate_matrix_mvp]
Matrix 384 [_Object2World]
Matrix 448 [_World2Object]
VectorHalf 0 [unity_SHAr] 4
VectorHalf 8 [unity_SHAg] 4
VectorHalf 16 [unity_SHAb] 4
VectorHalf 24 [unity_SHBr] 4
VectorHalf 32 [unity_SHBg] 4
VectorHalf 40 [unity_SHBb] 4
VectorHalf 48 [unity_SHC] 4
Vector 512 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
  float4 _glesMultiTexCoord0 [[attribute(2)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  float2 xlv_TEXCOORD0;
  half3 xlv_TEXCOORD1;
  float3 xlv_TEXCOORD2;
  half3 xlv_TEXCOORD3;
  half4 xlv_TEXCOORD4;
};
struct xlatMtlShaderUniform {
  half4 unity_SHAr;
  half4 unity_SHAg;
  half4 unity_SHAb;
  half4 unity_SHBr;
  half4 unity_SHBg;
  half4 unity_SHBb;
  half4 unity_SHC;
  float4x4 unity_World2Shadow[4];
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  half4 tmpvar_3;
  float4 v_4;
  v_4.x = _mtl_u._World2Object[0].x;
  v_4.y = _mtl_u._World2Object[1].x;
  v_4.z = _mtl_u._World2Object[2].x;
  v_4.w = _mtl_u._World2Object[3].x;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].y;
  v_5.y = _mtl_u._World2Object[1].y;
  v_5.z = _mtl_u._World2Object[2].y;
  v_5.w = _mtl_u._World2Object[3].y;
  float4 v_6;
  v_6.x = _mtl_u._World2Object[0].z;
  v_6.y = _mtl_u._World2Object[1].z;
  v_6.z = _mtl_u._World2Object[2].z;
  v_6.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_7;
  tmpvar_7 = normalize(((
    (v_4.xyz * _mtl_i._glesNormal.x)
   + 
    (v_5.xyz * _mtl_i._glesNormal.y)
  ) + (v_6.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_7);
  tmpvar_2 = worldNormal_1;
  half4 tmpvar_8;
  tmpvar_8.w = half(1.0);
  tmpvar_8.xyz = worldNormal_1;
  half4 normal_9;
  normal_9 = tmpvar_8;
  half3 x2_10;
  half3 x1_11;
  x1_11.x = dot (_mtl_u.unity_SHAr, normal_9);
  x1_11.y = dot (_mtl_u.unity_SHAg, normal_9);
  x1_11.z = dot (_mtl_u.unity_SHAb, normal_9);
  half4 tmpvar_12;
  tmpvar_12 = (normal_9.xyzz * normal_9.yzzx);
  x2_10.x = dot (_mtl_u.unity_SHBr, tmpvar_12);
  x2_10.y = dot (_mtl_u.unity_SHBg, tmpvar_12);
  x2_10.z = dot (_mtl_u.unity_SHBb, tmpvar_12);
  float4 tmpvar_13;
  float4 cse_14;
  cse_14 = (_mtl_u._Object2World * _mtl_i._glesVertex);
  tmpvar_13 = (_mtl_u.unity_World2Shadow[0] * cse_14);
  tmpvar_3 = half4(tmpvar_13);
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  _mtl_o.xlv_TEXCOORD1 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD2 = cse_14.xyz;
  _mtl_o.xlv_TEXCOORD3 = ((x2_10 + (_mtl_u.unity_SHC.xyz * 
    ((normal_9.x * normal_9.x) - (normal_9.y * normal_9.y))
  )) + x1_11);
  _mtl_o.xlv_TEXCOORD4 = tmpvar_3;
  return _mtl_o;
}

""
}
SubProgram ""gles "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
""!!GLES


#ifdef VERTEX

#extension GL_EXT_shadow_samplers : enable
attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform highp vec4 unity_4LightPosX0;
uniform highp vec4 unity_4LightPosY0;
uniform highp vec4 unity_4LightPosZ0;
uniform mediump vec4 unity_4LightAtten0;
uniform mediump vec4 unity_LightColor[8];
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying mediump vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying mediump vec3 xlv_TEXCOORD3;
varying mediump vec4 xlv_TEXCOORD4;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  mediump vec4 tmpvar_4;
  highp vec4 cse_5;
  cse_5 = (_Object2World * _glesVertex);
  highp vec4 v_6;
  v_6.x = _World2Object[0].x;
  v_6.y = _World2Object[1].x;
  v_6.z = _World2Object[2].x;
  v_6.w = _World2Object[3].x;
  highp vec4 v_7;
  v_7.x = _World2Object[0].y;
  v_7.y = _World2Object[1].y;
  v_7.z = _World2Object[2].y;
  v_7.w = _World2Object[3].y;
  highp vec4 v_8;
  v_8.x = _World2Object[0].z;
  v_8.y = _World2Object[1].z;
  v_8.z = _World2Object[2].z;
  v_8.w = _World2Object[3].z;
  highp vec3 tmpvar_9;
  tmpvar_9 = normalize(((
    (v_6.xyz * _glesNormal.x)
   + 
    (v_7.xyz * _glesNormal.y)
  ) + (v_8.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_9;
  tmpvar_2 = worldNormal_1;
  lowp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = worldNormal_1;
  mediump vec3 tmpvar_11;
  mediump vec4 normal_12;
  normal_12 = tmpvar_10;
  mediump vec3 x2_13;
  mediump vec3 x1_14;
  x1_14.x = dot (unity_SHAr, normal_12);
  x1_14.y = dot (unity_SHAg, normal_12);
  x1_14.z = dot (unity_SHAb, normal_12);
  mediump vec4 tmpvar_15;
  tmpvar_15 = (normal_12.xyzz * normal_12.yzzx);
  x2_13.x = dot (unity_SHBr, tmpvar_15);
  x2_13.y = dot (unity_SHBg, tmpvar_15);
  x2_13.z = dot (unity_SHBb, tmpvar_15);
  tmpvar_11 = ((x2_13 + (unity_SHC.xyz * 
    ((normal_12.x * normal_12.x) - (normal_12.y * normal_12.y))
  )) + x1_14);
  highp vec3 lightColor0_16;
  lightColor0_16 = unity_LightColor[0].xyz;
  highp vec3 lightColor1_17;
  lightColor1_17 = unity_LightColor[1].xyz;
  highp vec3 lightColor2_18;
  lightColor2_18 = unity_LightColor[2].xyz;
  highp vec3 lightColor3_19;
  lightColor3_19 = unity_LightColor[3].xyz;
  highp vec4 lightAttenSq_20;
  lightAttenSq_20 = unity_4LightAtten0;
  highp vec3 normal_21;
  normal_21 = worldNormal_1;
  highp vec4 tmpvar_22;
  tmpvar_22 = (unity_4LightPosX0 - cse_5.x);
  highp vec4 tmpvar_23;
  tmpvar_23 = (unity_4LightPosY0 - cse_5.y);
  highp vec4 tmpvar_24;
  tmpvar_24 = (unity_4LightPosZ0 - cse_5.z);
  highp vec4 tmpvar_25;
  tmpvar_25 = (((tmpvar_22 * tmpvar_22) + (tmpvar_23 * tmpvar_23)) + (tmpvar_24 * tmpvar_24));
  highp vec4 tmpvar_26;
  tmpvar_26 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_22 * normal_21.x) + (tmpvar_23 * normal_21.y)) + (tmpvar_24 * normal_21.z))
   * 
    inversesqrt(tmpvar_25)
  )) * (1.0/((1.0 + 
    (tmpvar_25 * lightAttenSq_20)
  ))));
  highp vec3 tmpvar_27;
  tmpvar_27 = (tmpvar_11 + ((
    ((lightColor0_16 * tmpvar_26.x) + (lightColor1_17 * tmpvar_26.y))
   + 
    (lightColor2_18 * tmpvar_26.z)
  ) + (lightColor3_19 * tmpvar_26.w)));
  tmpvar_3 = tmpvar_27;
  highp vec4 tmpvar_28;
  tmpvar_28 = (unity_World2Shadow[0] * cse_5);
  tmpvar_4 = tmpvar_28;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = cse_5.xyz;
  xlv_TEXCOORD3 = tmpvar_3;
  xlv_TEXCOORD4 = tmpvar_4;
}



#endif
#ifdef FRAGMENT

#extension GL_EXT_shadow_samplers : enable
uniform sampler2D _XYSMap;
varying highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 62 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 160
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityLighting"" 720
Vector 32 [unity_4LightPosX0]
Vector 48 [unity_4LightPosY0]
Vector 64 [unity_4LightPosZ0]
Vector 80 [unity_4LightAtten0]
Vector 96 [unity_LightColor0]
Vector 112 [unity_LightColor1]
Vector 128 [unity_LightColor2]
Vector 144 [unity_LightColor3]
Vector 160 [unity_LightColor4]
Vector 176 [unity_LightColor5]
Vector 192 [unity_LightColor6]
Vector 208 [unity_LightColor7]
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityShadows"" 416
Matrix 128 [unity_World2Shadow0]
Matrix 192 [unity_World2Shadow1]
Matrix 256 [unity_World2Shadow2]
Matrix 320 [unity_World2Shadow3]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityLighting"" 1
BindCB  ""UnityShadows"" 2
BindCB  ""UnityPerDraw"" 3
""vs_4_0_level_9_1
eefiecednmahkeobmpalhpiapnkijpkpegbldoboabaaaaaajibaaaaaaeaaaaaa
daaaaaaajeafaaaaoiaoaaaaoaapaaaaebgpgodjfmafaaaafmafaaaaaaacpopp
omaeaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaajaa
abaaabaaaaaaaaaaabaaacaaaiaaacaaaaaaaaaaabaacgaaahaaakaaaaaaaaaa
acaaaiaaaeaabbaaaaaaaaaaadaaaaaaaeaabfaaaaaaaaaaadaaamaaahaabjaa
aaaaaaaaaaaaaaaaaaacpoppfbaaaaafcaaaapkaaaaaiadpaaaaaaaaaaaaaaaa
aaaaaaaabpaaaaacafaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjabpaaaaac
afaaadiaadaaapjaaeaaaaaeaaaaadoaadaaoejaabaaoekaabaaookaafaaaaad
aaaaabiaacaaaajabnaaaakaafaaaaadaaaaaciaacaaaajaboaaaakaafaaaaad
aaaaaeiaacaaaajabpaaaakaafaaaaadabaaabiaacaaffjabnaaffkaafaaaaad
abaaaciaacaaffjaboaaffkaafaaaaadabaaaeiaacaaffjabpaaffkaacaaaaad
aaaaahiaaaaaoeiaabaaoeiaafaaaaadabaaabiaacaakkjabnaakkkaafaaaaad
abaaaciaacaakkjaboaakkkaafaaaaadabaaaeiaacaakkjabpaakkkaacaaaaad
aaaaahiaaaaaoeiaabaaoeiaceaaaaacabaaahiaaaaaoeiaafaaaaadaaaaabia
abaaffiaabaaffiaaeaaaaaeaaaaabiaabaaaaiaabaaaaiaaaaaaaibafaaaaad
acaaapiaabaacjiaabaakeiaajaaaaadadaaabiaanaaoekaacaaoeiaajaaaaad
adaaaciaaoaaoekaacaaoeiaajaaaaadadaaaeiaapaaoekaacaaoeiaaeaaaaae
aaaaahiabaaaoekaaaaaaaiaadaaoeiaabaaaaacabaaaiiacaaaaakaajaaaaad
acaaabiaakaaoekaabaaoeiaajaaaaadacaaaciaalaaoekaabaaoeiaajaaaaad
acaaaeiaamaaoekaabaaoeiaacaaaaadaaaaahiaaaaaoeiaacaaoeiaafaaaaad
acaaahiaaaaaffjabkaaoekaaeaaaaaeacaaahiabjaaoekaaaaaaajaacaaoeia
aeaaaaaeacaaahiablaaoekaaaaakkjaacaaoeiaaeaaaaaeacaaahiabmaaoeka
aaaappjaacaaoeiaacaaaaadadaaapiaacaaffibadaaoekaafaaaaadaeaaapia
abaaffiaadaaoeiaafaaaaadadaaapiaadaaoeiaadaaoeiaacaaaaadafaaapia
acaaaaibacaaoekaaeaaaaaeaeaaapiaafaaoeiaabaaaaiaaeaaoeiaaeaaaaae
adaaapiaafaaoeiaafaaoeiaadaaoeiaacaaaaadafaaapiaacaakkibaeaaoeka
abaaaaacacaaahoaacaaoeiaaeaaaaaeacaaapiaafaaoeiaabaakkiaaeaaoeia
abaaaaacabaaahoaabaaoeiaaeaaaaaeabaaapiaafaaoeiaafaaoeiaadaaoeia
ahaaaaacadaaabiaabaaaaiaahaaaaacadaaaciaabaaffiaahaaaaacadaaaeia
abaakkiaahaaaaacadaaaiiaabaappiaabaaaaacaeaaabiacaaaaakaaeaaaaae
abaaapiaabaaoeiaafaaoekaaeaaaaiaafaaaaadacaaapiaacaaoeiaadaaoeia
alaaaaadacaaapiaacaaoeiacaaaffkaagaaaaacadaaabiaabaaaaiaagaaaaac
adaaaciaabaaffiaagaaaaacadaaaeiaabaakkiaagaaaaacadaaaiiaabaappia
afaaaaadabaaapiaacaaoeiaadaaoeiaafaaaaadacaaahiaabaaffiaahaaoeka
aeaaaaaeacaaahiaagaaoekaabaaaaiaacaaoeiaaeaaaaaeabaaahiaaiaaoeka
abaakkiaacaaoeiaaeaaaaaeabaaahiaajaaoekaabaappiaabaaoeiaacaaaaad
adaaahoaaaaaoeiaabaaoeiaafaaaaadaaaaapiaaaaaffjabkaaoekaaeaaaaae
aaaaapiabjaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiablaaoekaaaaakkja
aaaaoeiaaeaaaaaeaaaaapiabmaaoekaaaaappjaaaaaoeiaafaaaaadabaaapia
aaaaffiabcaaoekaaeaaaaaeabaaapiabbaaoekaaaaaaaiaabaaoeiaaeaaaaae
abaaapiabdaaoekaaaaakkiaabaaoeiaaeaaaaaeaeaaapoabeaaoekaaaaappia
abaaoeiaafaaaaadaaaaapiaaaaaffjabgaaoekaaeaaaaaeaaaaapiabfaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaapiabhaaoekaaaaakkjaaaaaoeiaaeaaaaae
aaaaapiabiaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoeka
aaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefcemajaaaaeaaaabaa
fdacaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaa
cnaaaaaafjaaaaaeegiocaaaacaaaaaaamaaaaaafjaaaaaeegiocaaaadaaaaaa
bdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaagiaaaaacagaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaadaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaa
egbabaaaadaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaa
diaaaaaibcaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabaaaaaaa
diaaaaaiccaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabbaaaaaa
diaaaaaiecaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabcaaaaaa
diaaaaaibcaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabaaaaaaa
diaaaaaiccaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabbaaaaaa
diaaaaaiecaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabcaaaaaa
aaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaai
bcaabaaaabaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabaaaaaaadiaaaaai
ccaabaaaabaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabbaaaaaadiaaaaai
ecaabaaaabaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabcaaaaaaaaaaaaah
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaa
aaaaaaaadgaaaaafhccabaaaacaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaa
abaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaadaaaaaaegacbaaa
abaaaaaadiaaaaahicaabaaaabaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaa
dcaaaaakicaabaaaabaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaia
ebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaa
aaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaa
acaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaa
acaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaa
acaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaabaaaaaacmaaaaaapgapbaaa
abaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadp
bbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaa
bbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaa
bbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaa
aaaaaaahhcaabaaaacaaaaaaegacbaaaacaaaaaaegacbaaaadaaaaaaaaaaaaaj
pcaabaaaadaaaaaafgafbaiaebaaaaaaabaaaaaaegiocaaaabaaaaaaadaaaaaa
diaaaaahpcaabaaaaeaaaaaafgafbaaaaaaaaaaaegaobaaaadaaaaaadiaaaaah
pcaabaaaadaaaaaaegaobaaaadaaaaaaegaobaaaadaaaaaaaaaaaaajpcaabaaa
afaaaaaaagaabaiaebaaaaaaabaaaaaaegiocaaaabaaaaaaacaaaaaaaaaaaaaj
pcaabaaaabaaaaaakgakbaiaebaaaaaaabaaaaaaegiocaaaabaaaaaaaeaaaaaa
dcaaaaajpcaabaaaaeaaaaaaegaobaaaafaaaaaaagaabaaaaaaaaaaaegaobaaa
aeaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgakbaaaaaaaaaaa
egaobaaaaeaaaaaadcaaaaajpcaabaaaadaaaaaaegaobaaaafaaaaaaegaobaaa
afaaaaaaegaobaaaadaaaaaadcaaaaajpcaabaaaabaaaaaaegaobaaaabaaaaaa
egaobaaaabaaaaaaegaobaaaadaaaaaaeeaaaaafpcaabaaaadaaaaaaegaobaaa
abaaaaaadcaaaaanpcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaaabaaaaaa
afaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpaoaaaaakpcaabaaa
abaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpegaobaaaabaaaaaa
diaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaaadaaaaaadeaaaaak
pcaabaaaaaaaaaaaegaobaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaabaaaaaaegaobaaaaaaaaaaa
diaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaabaaaaaaahaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaaagaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaaiaaaaaa
kgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
abaaaaaaajaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaahhccabaaa
aeaaaaaaegacbaaaaaaaaaaaegacbaaaacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaadaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaipcaabaaaabaaaaaafgafbaaaaaaaaaaa
egiocaaaacaaaaaaajaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaacaaaaaa
aiaaaaaaagaabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaa
egiocaaaacaaaaaaakaaaaaakgakbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaak
pccabaaaafaaaaaaegiocaaaacaaaaaaalaaaaaapgapbaaaaaaaaaaaegaobaaa
abaaaaaadoaaaaabejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaa
oaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaaabaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaaadaaaaaa
afaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaaapaaaaaa
ojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdejfeejepeo
aafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaakl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform highp vec4 unity_4LightPosX0;
uniform highp vec4 unity_4LightPosY0;
uniform highp vec4 unity_4LightPosZ0;
uniform mediump vec4 unity_4LightAtten0;
uniform mediump vec4 unity_LightColor[8];
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out mediump vec3 xlv_TEXCOORD1;
out highp vec3 xlv_TEXCOORD2;
out mediump vec3 xlv_TEXCOORD3;
out mediump vec4 xlv_TEXCOORD4;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  mediump vec4 tmpvar_4;
  highp vec4 cse_5;
  cse_5 = (_Object2World * _glesVertex);
  highp vec4 v_6;
  v_6.x = _World2Object[0].x;
  v_6.y = _World2Object[1].x;
  v_6.z = _World2Object[2].x;
  v_6.w = _World2Object[3].x;
  highp vec4 v_7;
  v_7.x = _World2Object[0].y;
  v_7.y = _World2Object[1].y;
  v_7.z = _World2Object[2].y;
  v_7.w = _World2Object[3].y;
  highp vec4 v_8;
  v_8.x = _World2Object[0].z;
  v_8.y = _World2Object[1].z;
  v_8.z = _World2Object[2].z;
  v_8.w = _World2Object[3].z;
  highp vec3 tmpvar_9;
  tmpvar_9 = normalize(((
    (v_6.xyz * _glesNormal.x)
   + 
    (v_7.xyz * _glesNormal.y)
  ) + (v_8.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_9;
  tmpvar_2 = worldNormal_1;
  lowp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = worldNormal_1;
  mediump vec3 tmpvar_11;
  mediump vec4 normal_12;
  normal_12 = tmpvar_10;
  mediump vec3 x2_13;
  mediump vec3 x1_14;
  x1_14.x = dot (unity_SHAr, normal_12);
  x1_14.y = dot (unity_SHAg, normal_12);
  x1_14.z = dot (unity_SHAb, normal_12);
  mediump vec4 tmpvar_15;
  tmpvar_15 = (normal_12.xyzz * normal_12.yzzx);
  x2_13.x = dot (unity_SHBr, tmpvar_15);
  x2_13.y = dot (unity_SHBg, tmpvar_15);
  x2_13.z = dot (unity_SHBb, tmpvar_15);
  tmpvar_11 = ((x2_13 + (unity_SHC.xyz * 
    ((normal_12.x * normal_12.x) - (normal_12.y * normal_12.y))
  )) + x1_14);
  highp vec3 lightColor0_16;
  lightColor0_16 = unity_LightColor[0].xyz;
  highp vec3 lightColor1_17;
  lightColor1_17 = unity_LightColor[1].xyz;
  highp vec3 lightColor2_18;
  lightColor2_18 = unity_LightColor[2].xyz;
  highp vec3 lightColor3_19;
  lightColor3_19 = unity_LightColor[3].xyz;
  highp vec4 lightAttenSq_20;
  lightAttenSq_20 = unity_4LightAtten0;
  highp vec3 normal_21;
  normal_21 = worldNormal_1;
  highp vec4 tmpvar_22;
  tmpvar_22 = (unity_4LightPosX0 - cse_5.x);
  highp vec4 tmpvar_23;
  tmpvar_23 = (unity_4LightPosY0 - cse_5.y);
  highp vec4 tmpvar_24;
  tmpvar_24 = (unity_4LightPosZ0 - cse_5.z);
  highp vec4 tmpvar_25;
  tmpvar_25 = (((tmpvar_22 * tmpvar_22) + (tmpvar_23 * tmpvar_23)) + (tmpvar_24 * tmpvar_24));
  highp vec4 tmpvar_26;
  tmpvar_26 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_22 * normal_21.x) + (tmpvar_23 * normal_21.y)) + (tmpvar_24 * normal_21.z))
   * 
    inversesqrt(tmpvar_25)
  )) * (1.0/((1.0 + 
    (tmpvar_25 * lightAttenSq_20)
  ))));
  highp vec3 tmpvar_27;
  tmpvar_27 = (tmpvar_11 + ((
    ((lightColor0_16 * tmpvar_26.x) + (lightColor1_17 * tmpvar_26.y))
   + 
    (lightColor2_18 * tmpvar_26.z)
  ) + (lightColor3_19 * tmpvar_26.w)));
  tmpvar_3 = tmpvar_27;
  highp vec4 tmpvar_28;
  tmpvar_28 = (unity_World2Shadow[0] * cse_5);
  tmpvar_4 = tmpvar_28;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = cse_5.xyz;
  xlv_TEXCOORD3 = tmpvar_3;
  xlv_TEXCOORD4 = tmpvar_4;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _XYSMap;
in highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  _glesFragData[0] = c_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 53 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
Bind ""texcoord"" ATTR2
ConstBuffer ""$Globals"" 640
Matrix 176 [unity_World2Shadow0]
Matrix 240 [unity_World2Shadow1]
Matrix 304 [unity_World2Shadow2]
Matrix 368 [unity_World2Shadow3]
Matrix 432 [glstate_matrix_mvp]
Matrix 496 [_Object2World]
Matrix 560 [_World2Object]
Vector 0 [unity_4LightPosX0]
Vector 16 [unity_4LightPosY0]
Vector 32 [unity_4LightPosZ0]
VectorHalf 48 [unity_4LightAtten0] 4
VectorHalf 56 [unity_LightColor0] 4
VectorHalf 64 [unity_LightColor1] 4
VectorHalf 72 [unity_LightColor2] 4
VectorHalf 80 [unity_LightColor3] 4
VectorHalf 88 [unity_LightColor4] 4
VectorHalf 96 [unity_LightColor5] 4
VectorHalf 104 [unity_LightColor6] 4
VectorHalf 112 [unity_LightColor7] 4
VectorHalf 120 [unity_SHAr] 4
VectorHalf 128 [unity_SHAg] 4
VectorHalf 136 [unity_SHAb] 4
VectorHalf 144 [unity_SHBr] 4
VectorHalf 152 [unity_SHBg] 4
VectorHalf 160 [unity_SHBb] 4
VectorHalf 168 [unity_SHC] 4
Vector 624 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
  float4 _glesMultiTexCoord0 [[attribute(2)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  float2 xlv_TEXCOORD0;
  half3 xlv_TEXCOORD1;
  float3 xlv_TEXCOORD2;
  half3 xlv_TEXCOORD3;
  half4 xlv_TEXCOORD4;
};
struct xlatMtlShaderUniform {
  float4 unity_4LightPosX0;
  float4 unity_4LightPosY0;
  float4 unity_4LightPosZ0;
  half4 unity_4LightAtten0;
  half4 unity_LightColor[8];
  half4 unity_SHAr;
  half4 unity_SHAg;
  half4 unity_SHAb;
  half4 unity_SHBr;
  half4 unity_SHBg;
  half4 unity_SHBb;
  half4 unity_SHC;
  float4x4 unity_World2Shadow[4];
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  half3 tmpvar_3;
  half4 tmpvar_4;
  float4 cse_5;
  cse_5 = (_mtl_u._Object2World * _mtl_i._glesVertex);
  float4 v_6;
  v_6.x = _mtl_u._World2Object[0].x;
  v_6.y = _mtl_u._World2Object[1].x;
  v_6.z = _mtl_u._World2Object[2].x;
  v_6.w = _mtl_u._World2Object[3].x;
  float4 v_7;
  v_7.x = _mtl_u._World2Object[0].y;
  v_7.y = _mtl_u._World2Object[1].y;
  v_7.z = _mtl_u._World2Object[2].y;
  v_7.w = _mtl_u._World2Object[3].y;
  float4 v_8;
  v_8.x = _mtl_u._World2Object[0].z;
  v_8.y = _mtl_u._World2Object[1].z;
  v_8.z = _mtl_u._World2Object[2].z;
  v_8.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_9;
  tmpvar_9 = normalize(((
    (v_6.xyz * _mtl_i._glesNormal.x)
   + 
    (v_7.xyz * _mtl_i._glesNormal.y)
  ) + (v_8.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_9);
  tmpvar_2 = worldNormal_1;
  half4 tmpvar_10;
  tmpvar_10.w = half(1.0);
  tmpvar_10.xyz = worldNormal_1;
  half3 tmpvar_11;
  half4 normal_12;
  normal_12 = tmpvar_10;
  half3 x2_13;
  half3 x1_14;
  x1_14.x = dot (_mtl_u.unity_SHAr, normal_12);
  x1_14.y = dot (_mtl_u.unity_SHAg, normal_12);
  x1_14.z = dot (_mtl_u.unity_SHAb, normal_12);
  half4 tmpvar_15;
  tmpvar_15 = (normal_12.xyzz * normal_12.yzzx);
  x2_13.x = dot (_mtl_u.unity_SHBr, tmpvar_15);
  x2_13.y = dot (_mtl_u.unity_SHBg, tmpvar_15);
  x2_13.z = dot (_mtl_u.unity_SHBb, tmpvar_15);
  tmpvar_11 = ((x2_13 + (_mtl_u.unity_SHC.xyz * 
    ((normal_12.x * normal_12.x) - (normal_12.y * normal_12.y))
  )) + x1_14);
  float3 lightColor0_16;
  lightColor0_16 = float3(_mtl_u.unity_LightColor[0].xyz);
  float3 lightColor1_17;
  lightColor1_17 = float3(_mtl_u.unity_LightColor[1].xyz);
  float3 lightColor2_18;
  lightColor2_18 = float3(_mtl_u.unity_LightColor[2].xyz);
  float3 lightColor3_19;
  lightColor3_19 = float3(_mtl_u.unity_LightColor[3].xyz);
  float4 lightAttenSq_20;
  lightAttenSq_20 = float4(_mtl_u.unity_4LightAtten0);
  float3 normal_21;
  normal_21 = float3(worldNormal_1);
  float4 tmpvar_22;
  tmpvar_22 = (_mtl_u.unity_4LightPosX0 - cse_5.x);
  float4 tmpvar_23;
  tmpvar_23 = (_mtl_u.unity_4LightPosY0 - cse_5.y);
  float4 tmpvar_24;
  tmpvar_24 = (_mtl_u.unity_4LightPosZ0 - cse_5.z);
  float4 tmpvar_25;
  tmpvar_25 = (((tmpvar_22 * tmpvar_22) + (tmpvar_23 * tmpvar_23)) + (tmpvar_24 * tmpvar_24));
  float4 tmpvar_26;
  tmpvar_26 = (max (float4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_22 * normal_21.x) + (tmpvar_23 * normal_21.y)) + (tmpvar_24 * normal_21.z))
   * 
    rsqrt(tmpvar_25)
  )) * (1.0/((1.0 + 
    (tmpvar_25 * lightAttenSq_20)
  ))));
  float3 tmpvar_27;
  tmpvar_27 = ((float3)tmpvar_11 + ((
    ((lightColor0_16 * tmpvar_26.x) + (lightColor1_17 * tmpvar_26.y))
   + 
    (lightColor2_18 * tmpvar_26.z)
  ) + (lightColor3_19 * tmpvar_26.w)));
  tmpvar_3 = half3(tmpvar_27);
  float4 tmpvar_28;
  tmpvar_28 = (_mtl_u.unity_World2Shadow[0] * cse_5);
  tmpvar_4 = half4(tmpvar_28);
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  _mtl_o.xlv_TEXCOORD1 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD2 = cse_5.xyz;
  _mtl_o.xlv_TEXCOORD3 = tmpvar_3;
  _mtl_o.xlv_TEXCOORD4 = tmpvar_4;
  return _mtl_o;
}

""
}
}
Program ""fp"" {
SubProgram ""opengl "" {
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 3 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_2_0
def c0, 1, 0, 0, 0
dcl t0.xy
dcl_2d s0
texld_pp r0, t0, s0
add_pp r0.xyz, -r0.z, r0.y
mov_pp r0.w, c0.x
mov_pp oC0, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 1 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0
eefiecedkjakljbjdemcbkdkfpbcablfkldfhgihabaaaaaakiabaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefckaaaaaaaeaaaaaaaciaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacabaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaaihccabaaaaaaaaaaakgakbaia
ebaaaaaaaaaaaaaafgafbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaa
aaaaiadpdoaaaaab""
}
SubProgram ""gles "" {
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
// Stats: 1 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0_level_9_1
eefiecedegnmokjdfhkokapbldoknpjkakkjlggbabaaaaaaemacaaaaaeaaaaaa
daaaaaaanaaaaaaahiabaaaabiacaaaaebgpgodjjiaaaaaajiaaaaaaaaacpppp
haaaaaaaciaaaaaaaaaaciaaaaaaciaaaaaaciaaabaaceaaaaaaciaaaaaaaaaa
aaacppppfbaaaaafaaaaapkaaaaaiadpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaac
aaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapkaecaaaaadaaaacpiaaaaaoela
aaaioekaacaaaaadaaaachiaaaaakkibaaaaffiaabaaaaacaaaaciiaaaaaaaka
abaaaaacaaaicpiaaaaaoeiappppaaaafdeieefckaaaaaaaeaaaaaaaciaaaaaa
fkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacabaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
aaaaaaaihccabaaaaaaaaaaakgakbaiaebaaaaaaaaaaaaaafgafbaaaaaaaaaaa
dgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaabejfdeheojiaaaaaa
afaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
imaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaaimaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahaaaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaaaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float2 xlv_TEXCOORD0;
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]]
  ,   texture2d<half> _XYSMap [[texture(0)]], sampler _mtlsmp__XYSMap [[sampler(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 c_1;
  half4 tmpvar_2;
  tmpvar_2 = _XYSMap.sample(_mtlsmp__XYSMap, (float2)(_mtl_i.xlv_TEXCOORD0));
  half3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = half(1.0);
  _mtl_o._glesFragData_0 = c_1;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 3 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_2_0
def c0, 1, 0, 0, 0
dcl t0.xy
dcl_2d s0
texld_pp r0, t0, s0
add_pp r0.xyz, -r0.z, r0.y
mov_pp r0.w, c0.x
mov_pp oC0, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 1 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0
eefiecedeboijhmnbgdkiflafninheihilbkflofabaaaaaamaabaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefckaaaaaaa
eaaaaaaaciaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
abaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaaaaaaaaaihccabaaaaaaaaaaakgakbaiaebaaaaaaaaaaaaaa
fgafbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab
""
}
SubProgram ""gles "" {
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLES""
}
SubProgram ""gles "" {
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
// Stats: 1 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0_level_9_1
eefiecedjnjffkfjnaiogegdiffkanmfoenlkchdabaaaaaahiacaaaaafaaaaaa
deaaaaaaneaaaaaahmabaaaaimabaaaaeeacaaaaebgpgodjjiaaaaaajiaaaaaa
aaacpppphaaaaaaaciaaaaaaaaaaciaaaaaaciaaaaaaciaaabaaceaaaaaaciaa
aaaaaaaaaaacppppfbaaaaafaaaaapkaaaaaiadpaaaaaaaaaaaaaaaaaaaaaaaa
bpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapkaecaaaaadaaaacpia
aaaaoelaaaaioekaacaaaaadaaaachiaaaaakkibaaaaffiaabaaaaacaaaaciia
aaaaaakaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefckaaaaaaaeaaaaaaa
ciaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
gcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacabaaaaaa
efaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaaaaaaaaaihccabaaaaaaaaaaakgakbaiaebaaaaaaaaaaaaaafgafbaaa
aaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaabfdegejda
aiaaaaaaiaaaaaaaaaaaaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float2 xlv_TEXCOORD0;
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]]
  ,   texture2d<half> _XYSMap [[texture(0)]], sampler _mtlsmp__XYSMap [[sampler(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 c_1;
  half4 tmpvar_2;
  tmpvar_2 = _XYSMap.sample(_mtlsmp__XYSMap, (float2)(_mtl_i.xlv_TEXCOORD0));
  half3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = half(1.0);
  _mtl_o._glesFragData_0 = c_1;
  return _mtl_o;
}

""
}
}
 }


 // Stats for Vertex shader:
 //       d3d11 : 22 math
 //    d3d11_9x : 22 math
 //        d3d9 : 13 math
 //        gles : 2 math
 //       gles3 : 2 math
 //       metal : 8 math
 //      opengl : 2 math
 // Stats for Fragment shader:
 //        d3d9 : 1 math
 //       metal : 2 math
 Pass {
  Name ""FORWARD""
  Tags { ""LIGHTMODE""=""ForwardAdd"" ""ForceNoShadowCasting""=""true"" ""DisableBatching""=""true"" ""RenderType""=""Opaque"" }
  ZWrite Off
  Blend One One
  GpuProgramID 78382
Program ""vp"" {
SubProgram ""opengl "" {
// Stats: 2 math
Keywords { ""POINT"" }
""!!GLSL
#ifdef VERTEX

uniform mat4 _Object2World;
uniform mat4 _World2Object;
varying vec3 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
void main ()
{
  vec4 v_1;
  v_1.x = _World2Object[0].x;
  v_1.y = _World2Object[1].x;
  v_1.z = _World2Object[2].x;
  v_1.w = _World2Object[3].x;
  vec4 v_2;
  v_2.x = _World2Object[0].y;
  v_2.y = _World2Object[1].y;
  v_2.z = _World2Object[2].y;
  v_2.w = _World2Object[3].y;
  vec4 v_3;
  v_3.x = _World2Object[0].z;
  v_3.y = _World2Object[1].z;
  v_3.z = _World2Object[2].z;
  v_3.w = _World2Object[3].z;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = normalize(((
    (v_1.xyz * gl_Normal.x)
   + 
    (v_2.xyz * gl_Normal.y)
  ) + (v_3.xyz * gl_Normal.z)));
  xlv_TEXCOORD1 = (_Object2World * gl_Vertex).xyz;
}


#endif
#ifdef FRAGMENT
void main ()
{
  vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 13 math
Keywords { ""POINT"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
""vs_2_0
dcl_position v0
dcl_normal v1
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
dp4 oT1.x, c4, v0
dp4 oT1.y, c5, v0
dp4 oT1.z, c6, v0
mul r0.xyz, v1.y, c8
mad r0.xyz, c7, v1.x, r0
mad r0.xyz, c9, v1.z, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul oT0.xyz, r0.w, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 22 math
Keywords { ""POINT"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0
eefiecedinidogaapcaihlhlafeaicjabdmdpgobabaaaaaaneaeaaaaadaaaaaa
cmaaaaaaceabaaaajeabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcdiadaaaaeaaaabaa
moaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
hccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hccabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 2 math
Keywords { ""POINT"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
varying mediump vec3 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT

void main ()
{
  lowp vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 22 math
Keywords { ""POINT"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0_level_9_1
eefiecedfimbpiggiminkfbhlgdjijhgmgblgjidabaaaaaaneagaaaaaeaaaaaa
daaaaaaacmacaaaagmafaaaageagaaaaebgpgodjpeabaaaapeabaaaaaaacpopp
leabaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaaaa
aeaaabaaaaaaaaaaaaaaamaaahaaafaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjaafaaaaadaaaaahiaaaaaffja
agaaoekaaeaaaaaeaaaaahiaafaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahia
ahaaoekaaaaakkjaaaaaoeiaaeaaaaaeabaaahoaaiaaoekaaaaappjaaaaaoeia
afaaaaadaaaaabiaacaaaajaajaaaakaafaaaaadaaaaaciaacaaaajaakaaaaka
afaaaaadaaaaaeiaacaaaajaalaaaakaafaaaaadabaaabiaacaaffjaajaaffka
afaaaaadabaaaciaacaaffjaakaaffkaafaaaaadabaaaeiaacaaffjaalaaffka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaafaaaaadabaaabiaacaakkjaajaakkka
afaaaaadabaaaciaacaakkjaakaakkkaafaaaaadabaaaeiaacaakkjaalaakkka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaaiaaaaadaaaaaiiaaaaaoeiaaaaaoeia
ahaaaaacaaaaaiiaaaaappiaafaaaaadaaaaahoaaaaappiaaaaaoeiaafaaaaad
aaaaapiaaaaaffjaacaaoekaaeaaaaaeaaaaapiaabaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaadaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiappppaaaafdeieefcdiadaaaaeaaaabaamoaaaaaafjaaaaae
egiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadhccabaaaabaaaaaa
gfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
aaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaaaaaaaaadoaaaaabejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 2 math
Keywords { ""POINT"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
out mediump vec3 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
void main ()
{
  lowp vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  _glesFragData[0] = c_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 8 math
Keywords { ""POINT"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
ConstBuffer ""$Globals"" 192
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [_Object2World]
Matrix 128 [_World2Object]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  half3 xlv_TEXCOORD0;
  float3 xlv_TEXCOORD1;
};
struct xlatMtlShaderUniform {
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  float4 v_3;
  v_3.x = _mtl_u._World2Object[0].x;
  v_3.y = _mtl_u._World2Object[1].x;
  v_3.z = _mtl_u._World2Object[2].x;
  v_3.w = _mtl_u._World2Object[3].x;
  float4 v_4;
  v_4.x = _mtl_u._World2Object[0].y;
  v_4.y = _mtl_u._World2Object[1].y;
  v_4.z = _mtl_u._World2Object[2].y;
  v_4.w = _mtl_u._World2Object[3].y;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].z;
  v_5.y = _mtl_u._World2Object[1].z;
  v_5.z = _mtl_u._World2Object[2].z;
  v_5.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _mtl_i._glesNormal.x)
   + 
    (v_4.xyz * _mtl_i._glesNormal.y)
  ) + (v_5.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_6);
  tmpvar_2 = worldNormal_1;
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD1 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
// Stats: 2 math
Keywords { ""DIRECTIONAL"" }
""!!GLSL
#ifdef VERTEX

uniform mat4 _Object2World;
uniform mat4 _World2Object;
varying vec3 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
void main ()
{
  vec4 v_1;
  v_1.x = _World2Object[0].x;
  v_1.y = _World2Object[1].x;
  v_1.z = _World2Object[2].x;
  v_1.w = _World2Object[3].x;
  vec4 v_2;
  v_2.x = _World2Object[0].y;
  v_2.y = _World2Object[1].y;
  v_2.z = _World2Object[2].y;
  v_2.w = _World2Object[3].y;
  vec4 v_3;
  v_3.x = _World2Object[0].z;
  v_3.y = _World2Object[1].z;
  v_3.z = _World2Object[2].z;
  v_3.w = _World2Object[3].z;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = normalize(((
    (v_1.xyz * gl_Normal.x)
   + 
    (v_2.xyz * gl_Normal.y)
  ) + (v_3.xyz * gl_Normal.z)));
  xlv_TEXCOORD1 = (_Object2World * gl_Vertex).xyz;
}


#endif
#ifdef FRAGMENT
void main ()
{
  vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 13 math
Keywords { ""DIRECTIONAL"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
""vs_2_0
dcl_position v0
dcl_normal v1
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
dp4 oT1.x, c4, v0
dp4 oT1.y, c5, v0
dp4 oT1.z, c6, v0
mul r0.xyz, v1.y, c8
mad r0.xyz, c7, v1.x, r0
mad r0.xyz, c9, v1.z, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul oT0.xyz, r0.w, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 22 math
Keywords { ""DIRECTIONAL"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0
eefiecedinidogaapcaihlhlafeaicjabdmdpgobabaaaaaaneaeaaaaadaaaaaa
cmaaaaaaceabaaaajeabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcdiadaaaaeaaaabaa
moaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
hccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hccabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 2 math
Keywords { ""DIRECTIONAL"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
varying mediump vec3 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT

void main ()
{
  lowp vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 22 math
Keywords { ""DIRECTIONAL"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0_level_9_1
eefiecedfimbpiggiminkfbhlgdjijhgmgblgjidabaaaaaaneagaaaaaeaaaaaa
daaaaaaacmacaaaagmafaaaageagaaaaebgpgodjpeabaaaapeabaaaaaaacpopp
leabaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaaaa
aeaaabaaaaaaaaaaaaaaamaaahaaafaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjaafaaaaadaaaaahiaaaaaffja
agaaoekaaeaaaaaeaaaaahiaafaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahia
ahaaoekaaaaakkjaaaaaoeiaaeaaaaaeabaaahoaaiaaoekaaaaappjaaaaaoeia
afaaaaadaaaaabiaacaaaajaajaaaakaafaaaaadaaaaaciaacaaaajaakaaaaka
afaaaaadaaaaaeiaacaaaajaalaaaakaafaaaaadabaaabiaacaaffjaajaaffka
afaaaaadabaaaciaacaaffjaakaaffkaafaaaaadabaaaeiaacaaffjaalaaffka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaafaaaaadabaaabiaacaakkjaajaakkka
afaaaaadabaaaciaacaakkjaakaakkkaafaaaaadabaaaeiaacaakkjaalaakkka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaaiaaaaadaaaaaiiaaaaaoeiaaaaaoeia
ahaaaaacaaaaaiiaaaaappiaafaaaaadaaaaahoaaaaappiaaaaaoeiaafaaaaad
aaaaapiaaaaaffjaacaaoekaaeaaaaaeaaaaapiaabaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaadaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiappppaaaafdeieefcdiadaaaaeaaaabaamoaaaaaafjaaaaae
egiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadhccabaaaabaaaaaa
gfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
aaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaaaaaaaaadoaaaaabejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 2 math
Keywords { ""DIRECTIONAL"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
out mediump vec3 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
void main ()
{
  lowp vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  _glesFragData[0] = c_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 8 math
Keywords { ""DIRECTIONAL"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
ConstBuffer ""$Globals"" 192
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [_Object2World]
Matrix 128 [_World2Object]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  half3 xlv_TEXCOORD0;
  float3 xlv_TEXCOORD1;
};
struct xlatMtlShaderUniform {
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  float4 v_3;
  v_3.x = _mtl_u._World2Object[0].x;
  v_3.y = _mtl_u._World2Object[1].x;
  v_3.z = _mtl_u._World2Object[2].x;
  v_3.w = _mtl_u._World2Object[3].x;
  float4 v_4;
  v_4.x = _mtl_u._World2Object[0].y;
  v_4.y = _mtl_u._World2Object[1].y;
  v_4.z = _mtl_u._World2Object[2].y;
  v_4.w = _mtl_u._World2Object[3].y;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].z;
  v_5.y = _mtl_u._World2Object[1].z;
  v_5.z = _mtl_u._World2Object[2].z;
  v_5.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _mtl_i._glesNormal.x)
   + 
    (v_4.xyz * _mtl_i._glesNormal.y)
  ) + (v_5.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_6);
  tmpvar_2 = worldNormal_1;
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD1 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
// Stats: 2 math
Keywords { ""SPOT"" }
""!!GLSL
#ifdef VERTEX

uniform mat4 _Object2World;
uniform mat4 _World2Object;
varying vec3 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
void main ()
{
  vec4 v_1;
  v_1.x = _World2Object[0].x;
  v_1.y = _World2Object[1].x;
  v_1.z = _World2Object[2].x;
  v_1.w = _World2Object[3].x;
  vec4 v_2;
  v_2.x = _World2Object[0].y;
  v_2.y = _World2Object[1].y;
  v_2.z = _World2Object[2].y;
  v_2.w = _World2Object[3].y;
  vec4 v_3;
  v_3.x = _World2Object[0].z;
  v_3.y = _World2Object[1].z;
  v_3.z = _World2Object[2].z;
  v_3.w = _World2Object[3].z;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = normalize(((
    (v_1.xyz * gl_Normal.x)
   + 
    (v_2.xyz * gl_Normal.y)
  ) + (v_3.xyz * gl_Normal.z)));
  xlv_TEXCOORD1 = (_Object2World * gl_Vertex).xyz;
}


#endif
#ifdef FRAGMENT
void main ()
{
  vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 13 math
Keywords { ""SPOT"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
""vs_2_0
dcl_position v0
dcl_normal v1
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
dp4 oT1.x, c4, v0
dp4 oT1.y, c5, v0
dp4 oT1.z, c6, v0
mul r0.xyz, v1.y, c8
mad r0.xyz, c7, v1.x, r0
mad r0.xyz, c9, v1.z, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul oT0.xyz, r0.w, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 22 math
Keywords { ""SPOT"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0
eefiecedinidogaapcaihlhlafeaicjabdmdpgobabaaaaaaneaeaaaaadaaaaaa
cmaaaaaaceabaaaajeabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcdiadaaaaeaaaabaa
moaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
hccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hccabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 2 math
Keywords { ""SPOT"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
varying mediump vec3 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT

void main ()
{
  lowp vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 22 math
Keywords { ""SPOT"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0_level_9_1
eefiecedfimbpiggiminkfbhlgdjijhgmgblgjidabaaaaaaneagaaaaaeaaaaaa
daaaaaaacmacaaaagmafaaaageagaaaaebgpgodjpeabaaaapeabaaaaaaacpopp
leabaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaaaa
aeaaabaaaaaaaaaaaaaaamaaahaaafaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjaafaaaaadaaaaahiaaaaaffja
agaaoekaaeaaaaaeaaaaahiaafaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahia
ahaaoekaaaaakkjaaaaaoeiaaeaaaaaeabaaahoaaiaaoekaaaaappjaaaaaoeia
afaaaaadaaaaabiaacaaaajaajaaaakaafaaaaadaaaaaciaacaaaajaakaaaaka
afaaaaadaaaaaeiaacaaaajaalaaaakaafaaaaadabaaabiaacaaffjaajaaffka
afaaaaadabaaaciaacaaffjaakaaffkaafaaaaadabaaaeiaacaaffjaalaaffka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaafaaaaadabaaabiaacaakkjaajaakkka
afaaaaadabaaaciaacaakkjaakaakkkaafaaaaadabaaaeiaacaakkjaalaakkka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaaiaaaaadaaaaaiiaaaaaoeiaaaaaoeia
ahaaaaacaaaaaiiaaaaappiaafaaaaadaaaaahoaaaaappiaaaaaoeiaafaaaaad
aaaaapiaaaaaffjaacaaoekaaeaaaaaeaaaaapiaabaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaadaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiappppaaaafdeieefcdiadaaaaeaaaabaamoaaaaaafjaaaaae
egiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadhccabaaaabaaaaaa
gfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
aaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaaaaaaaaadoaaaaabejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 2 math
Keywords { ""SPOT"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
out mediump vec3 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
void main ()
{
  lowp vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  _glesFragData[0] = c_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 8 math
Keywords { ""SPOT"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
ConstBuffer ""$Globals"" 192
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [_Object2World]
Matrix 128 [_World2Object]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  half3 xlv_TEXCOORD0;
  float3 xlv_TEXCOORD1;
};
struct xlatMtlShaderUniform {
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  float4 v_3;
  v_3.x = _mtl_u._World2Object[0].x;
  v_3.y = _mtl_u._World2Object[1].x;
  v_3.z = _mtl_u._World2Object[2].x;
  v_3.w = _mtl_u._World2Object[3].x;
  float4 v_4;
  v_4.x = _mtl_u._World2Object[0].y;
  v_4.y = _mtl_u._World2Object[1].y;
  v_4.z = _mtl_u._World2Object[2].y;
  v_4.w = _mtl_u._World2Object[3].y;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].z;
  v_5.y = _mtl_u._World2Object[1].z;
  v_5.z = _mtl_u._World2Object[2].z;
  v_5.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _mtl_i._glesNormal.x)
   + 
    (v_4.xyz * _mtl_i._glesNormal.y)
  ) + (v_5.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_6);
  tmpvar_2 = worldNormal_1;
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD1 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
// Stats: 2 math
Keywords { ""POINT_COOKIE"" }
""!!GLSL
#ifdef VERTEX

uniform mat4 _Object2World;
uniform mat4 _World2Object;
varying vec3 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
void main ()
{
  vec4 v_1;
  v_1.x = _World2Object[0].x;
  v_1.y = _World2Object[1].x;
  v_1.z = _World2Object[2].x;
  v_1.w = _World2Object[3].x;
  vec4 v_2;
  v_2.x = _World2Object[0].y;
  v_2.y = _World2Object[1].y;
  v_2.z = _World2Object[2].y;
  v_2.w = _World2Object[3].y;
  vec4 v_3;
  v_3.x = _World2Object[0].z;
  v_3.y = _World2Object[1].z;
  v_3.z = _World2Object[2].z;
  v_3.w = _World2Object[3].z;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = normalize(((
    (v_1.xyz * gl_Normal.x)
   + 
    (v_2.xyz * gl_Normal.y)
  ) + (v_3.xyz * gl_Normal.z)));
  xlv_TEXCOORD1 = (_Object2World * gl_Vertex).xyz;
}


#endif
#ifdef FRAGMENT
void main ()
{
  vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 13 math
Keywords { ""POINT_COOKIE"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
""vs_2_0
dcl_position v0
dcl_normal v1
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
dp4 oT1.x, c4, v0
dp4 oT1.y, c5, v0
dp4 oT1.z, c6, v0
mul r0.xyz, v1.y, c8
mad r0.xyz, c7, v1.x, r0
mad r0.xyz, c9, v1.z, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul oT0.xyz, r0.w, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 22 math
Keywords { ""POINT_COOKIE"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0
eefiecedinidogaapcaihlhlafeaicjabdmdpgobabaaaaaaneaeaaaaadaaaaaa
cmaaaaaaceabaaaajeabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcdiadaaaaeaaaabaa
moaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
hccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hccabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 2 math
Keywords { ""POINT_COOKIE"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
varying mediump vec3 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT

void main ()
{
  lowp vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 22 math
Keywords { ""POINT_COOKIE"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0_level_9_1
eefiecedfimbpiggiminkfbhlgdjijhgmgblgjidabaaaaaaneagaaaaaeaaaaaa
daaaaaaacmacaaaagmafaaaageagaaaaebgpgodjpeabaaaapeabaaaaaaacpopp
leabaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaaaa
aeaaabaaaaaaaaaaaaaaamaaahaaafaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjaafaaaaadaaaaahiaaaaaffja
agaaoekaaeaaaaaeaaaaahiaafaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahia
ahaaoekaaaaakkjaaaaaoeiaaeaaaaaeabaaahoaaiaaoekaaaaappjaaaaaoeia
afaaaaadaaaaabiaacaaaajaajaaaakaafaaaaadaaaaaciaacaaaajaakaaaaka
afaaaaadaaaaaeiaacaaaajaalaaaakaafaaaaadabaaabiaacaaffjaajaaffka
afaaaaadabaaaciaacaaffjaakaaffkaafaaaaadabaaaeiaacaaffjaalaaffka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaafaaaaadabaaabiaacaakkjaajaakkka
afaaaaadabaaaciaacaakkjaakaakkkaafaaaaadabaaaeiaacaakkjaalaakkka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaaiaaaaadaaaaaiiaaaaaoeiaaaaaoeia
ahaaaaacaaaaaiiaaaaappiaafaaaaadaaaaahoaaaaappiaaaaaoeiaafaaaaad
aaaaapiaaaaaffjaacaaoekaaeaaaaaeaaaaapiaabaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaadaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiappppaaaafdeieefcdiadaaaaeaaaabaamoaaaaaafjaaaaae
egiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadhccabaaaabaaaaaa
gfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
aaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaaaaaaaaadoaaaaabejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 2 math
Keywords { ""POINT_COOKIE"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
out mediump vec3 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
void main ()
{
  lowp vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  _glesFragData[0] = c_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 8 math
Keywords { ""POINT_COOKIE"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
ConstBuffer ""$Globals"" 192
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [_Object2World]
Matrix 128 [_World2Object]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  half3 xlv_TEXCOORD0;
  float3 xlv_TEXCOORD1;
};
struct xlatMtlShaderUniform {
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  float4 v_3;
  v_3.x = _mtl_u._World2Object[0].x;
  v_3.y = _mtl_u._World2Object[1].x;
  v_3.z = _mtl_u._World2Object[2].x;
  v_3.w = _mtl_u._World2Object[3].x;
  float4 v_4;
  v_4.x = _mtl_u._World2Object[0].y;
  v_4.y = _mtl_u._World2Object[1].y;
  v_4.z = _mtl_u._World2Object[2].y;
  v_4.w = _mtl_u._World2Object[3].y;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].z;
  v_5.y = _mtl_u._World2Object[1].z;
  v_5.z = _mtl_u._World2Object[2].z;
  v_5.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _mtl_i._glesNormal.x)
   + 
    (v_4.xyz * _mtl_i._glesNormal.y)
  ) + (v_5.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_6);
  tmpvar_2 = worldNormal_1;
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD1 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
// Stats: 2 math
Keywords { ""DIRECTIONAL_COOKIE"" }
""!!GLSL
#ifdef VERTEX

uniform mat4 _Object2World;
uniform mat4 _World2Object;
varying vec3 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
void main ()
{
  vec4 v_1;
  v_1.x = _World2Object[0].x;
  v_1.y = _World2Object[1].x;
  v_1.z = _World2Object[2].x;
  v_1.w = _World2Object[3].x;
  vec4 v_2;
  v_2.x = _World2Object[0].y;
  v_2.y = _World2Object[1].y;
  v_2.z = _World2Object[2].y;
  v_2.w = _World2Object[3].y;
  vec4 v_3;
  v_3.x = _World2Object[0].z;
  v_3.y = _World2Object[1].z;
  v_3.z = _World2Object[2].z;
  v_3.w = _World2Object[3].z;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = normalize(((
    (v_1.xyz * gl_Normal.x)
   + 
    (v_2.xyz * gl_Normal.y)
  ) + (v_3.xyz * gl_Normal.z)));
  xlv_TEXCOORD1 = (_Object2World * gl_Vertex).xyz;
}


#endif
#ifdef FRAGMENT
void main ()
{
  vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 13 math
Keywords { ""DIRECTIONAL_COOKIE"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
""vs_2_0
dcl_position v0
dcl_normal v1
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
dp4 oT1.x, c4, v0
dp4 oT1.y, c5, v0
dp4 oT1.z, c6, v0
mul r0.xyz, v1.y, c8
mad r0.xyz, c7, v1.x, r0
mad r0.xyz, c9, v1.z, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul oT0.xyz, r0.w, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 22 math
Keywords { ""DIRECTIONAL_COOKIE"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0
eefiecedinidogaapcaihlhlafeaicjabdmdpgobabaaaaaaneaeaaaaadaaaaaa
cmaaaaaaceabaaaajeabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcdiadaaaaeaaaabaa
moaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
hccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hccabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 2 math
Keywords { ""DIRECTIONAL_COOKIE"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
varying mediump vec3 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT

void main ()
{
  lowp vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 22 math
Keywords { ""DIRECTIONAL_COOKIE"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0_level_9_1
eefiecedfimbpiggiminkfbhlgdjijhgmgblgjidabaaaaaaneagaaaaaeaaaaaa
daaaaaaacmacaaaagmafaaaageagaaaaebgpgodjpeabaaaapeabaaaaaaacpopp
leabaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaaaa
aeaaabaaaaaaaaaaaaaaamaaahaaafaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjaafaaaaadaaaaahiaaaaaffja
agaaoekaaeaaaaaeaaaaahiaafaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahia
ahaaoekaaaaakkjaaaaaoeiaaeaaaaaeabaaahoaaiaaoekaaaaappjaaaaaoeia
afaaaaadaaaaabiaacaaaajaajaaaakaafaaaaadaaaaaciaacaaaajaakaaaaka
afaaaaadaaaaaeiaacaaaajaalaaaakaafaaaaadabaaabiaacaaffjaajaaffka
afaaaaadabaaaciaacaaffjaakaaffkaafaaaaadabaaaeiaacaaffjaalaaffka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaafaaaaadabaaabiaacaakkjaajaakkka
afaaaaadabaaaciaacaakkjaakaakkkaafaaaaadabaaaeiaacaakkjaalaakkka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaaiaaaaadaaaaaiiaaaaaoeiaaaaaoeia
ahaaaaacaaaaaiiaaaaappiaafaaaaadaaaaahoaaaaappiaaaaaoeiaafaaaaad
aaaaapiaaaaaffjaacaaoekaaeaaaaaeaaaaapiaabaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaadaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiappppaaaafdeieefcdiadaaaaeaaaabaamoaaaaaafjaaaaae
egiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadhccabaaaabaaaaaa
gfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
aaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaaaaaaaaadoaaaaabejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 2 math
Keywords { ""DIRECTIONAL_COOKIE"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
out mediump vec3 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
void main ()
{
  lowp vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  _glesFragData[0] = c_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 8 math
Keywords { ""DIRECTIONAL_COOKIE"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
ConstBuffer ""$Globals"" 192
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [_Object2World]
Matrix 128 [_World2Object]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  half3 xlv_TEXCOORD0;
  float3 xlv_TEXCOORD1;
};
struct xlatMtlShaderUniform {
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  float4 v_3;
  v_3.x = _mtl_u._World2Object[0].x;
  v_3.y = _mtl_u._World2Object[1].x;
  v_3.z = _mtl_u._World2Object[2].x;
  v_3.w = _mtl_u._World2Object[3].x;
  float4 v_4;
  v_4.x = _mtl_u._World2Object[0].y;
  v_4.y = _mtl_u._World2Object[1].y;
  v_4.z = _mtl_u._World2Object[2].y;
  v_4.w = _mtl_u._World2Object[3].y;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].z;
  v_5.y = _mtl_u._World2Object[1].z;
  v_5.z = _mtl_u._World2Object[2].z;
  v_5.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _mtl_i._glesNormal.x)
   + 
    (v_4.xyz * _mtl_i._glesNormal.y)
  ) + (v_5.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_6);
  tmpvar_2 = worldNormal_1;
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD1 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  return _mtl_o;
}

""
}
}
Program ""fp"" {
SubProgram ""opengl "" {
Keywords { ""POINT"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 1 math
Keywords { ""POINT"" }
""ps_2_0
def c0, 0, 0, 0, 1
mov_pp oC0, c0

""
}
SubProgram ""d3d11 "" {
Keywords { ""POINT"" }
""ps_4_0
eefiecedpdipnlijaafddlnglckhfpnipdngegoeabaaaaaabaabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdiaaaaaaeaaaaaaaaoaaaaaa
gfaaaaadpccabaaaaaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaiadpdoaaaaab""
}
SubProgram ""gles "" {
Keywords { ""POINT"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
Keywords { ""POINT"" }
""ps_4_0_level_9_1
eefiecedpplfmimdfdbfmdimjibnefjkbapfafjlabaaaaaagmabaaaaaeaaaaaa
daaaaaaaiiaaaaaamiaaaaaadiabaaaaebgpgodjfaaaaaaafaaaaaaaaaacpppp
cmaaaaaaceaaaaaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaacpppp
fbaaaaafaaaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpabaaaaacaaaicpia
aaaaoekappppaaaafdeieefcdiaaaaaaeaaaaaaaaoaaaaaagfaaaaadpccabaaa
aaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaiadpdoaaaaabejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaahaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
Keywords { ""POINT"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 2 math
Keywords { ""POINT"" }
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 c_1;
  c_1.xyz = half3(float3(0.0, 0.0, 0.0));
  c_1.w = half(1.0);
  _mtl_o._glesFragData_0 = c_1;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
Keywords { ""DIRECTIONAL"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 1 math
Keywords { ""DIRECTIONAL"" }
""ps_2_0
def c0, 0, 0, 0, 1
mov_pp oC0, c0

""
}
SubProgram ""d3d11 "" {
Keywords { ""DIRECTIONAL"" }
""ps_4_0
eefiecedpdipnlijaafddlnglckhfpnipdngegoeabaaaaaabaabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdiaaaaaaeaaaaaaaaoaaaaaa
gfaaaaadpccabaaaaaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaiadpdoaaaaab""
}
SubProgram ""gles "" {
Keywords { ""DIRECTIONAL"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
Keywords { ""DIRECTIONAL"" }
""ps_4_0_level_9_1
eefiecedpplfmimdfdbfmdimjibnefjkbapfafjlabaaaaaagmabaaaaaeaaaaaa
daaaaaaaiiaaaaaamiaaaaaadiabaaaaebgpgodjfaaaaaaafaaaaaaaaaacpppp
cmaaaaaaceaaaaaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaacpppp
fbaaaaafaaaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpabaaaaacaaaicpia
aaaaoekappppaaaafdeieefcdiaaaaaaeaaaaaaaaoaaaaaagfaaaaadpccabaaa
aaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaiadpdoaaaaabejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaahaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
Keywords { ""DIRECTIONAL"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 2 math
Keywords { ""DIRECTIONAL"" }
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 c_1;
  c_1.xyz = half3(float3(0.0, 0.0, 0.0));
  c_1.w = half(1.0);
  _mtl_o._glesFragData_0 = c_1;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
Keywords { ""SPOT"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 1 math
Keywords { ""SPOT"" }
""ps_2_0
def c0, 0, 0, 0, 1
mov_pp oC0, c0

""
}
SubProgram ""d3d11 "" {
Keywords { ""SPOT"" }
""ps_4_0
eefiecedpdipnlijaafddlnglckhfpnipdngegoeabaaaaaabaabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdiaaaaaaeaaaaaaaaoaaaaaa
gfaaaaadpccabaaaaaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaiadpdoaaaaab""
}
SubProgram ""gles "" {
Keywords { ""SPOT"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
Keywords { ""SPOT"" }
""ps_4_0_level_9_1
eefiecedpplfmimdfdbfmdimjibnefjkbapfafjlabaaaaaagmabaaaaaeaaaaaa
daaaaaaaiiaaaaaamiaaaaaadiabaaaaebgpgodjfaaaaaaafaaaaaaaaaacpppp
cmaaaaaaceaaaaaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaacpppp
fbaaaaafaaaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpabaaaaacaaaicpia
aaaaoekappppaaaafdeieefcdiaaaaaaeaaaaaaaaoaaaaaagfaaaaadpccabaaa
aaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaiadpdoaaaaabejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaahaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
Keywords { ""SPOT"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 2 math
Keywords { ""SPOT"" }
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 c_1;
  c_1.xyz = half3(float3(0.0, 0.0, 0.0));
  c_1.w = half(1.0);
  _mtl_o._glesFragData_0 = c_1;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
Keywords { ""POINT_COOKIE"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 1 math
Keywords { ""POINT_COOKIE"" }
""ps_2_0
def c0, 0, 0, 0, 1
mov_pp oC0, c0

""
}
SubProgram ""d3d11 "" {
Keywords { ""POINT_COOKIE"" }
""ps_4_0
eefiecedpdipnlijaafddlnglckhfpnipdngegoeabaaaaaabaabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdiaaaaaaeaaaaaaaaoaaaaaa
gfaaaaadpccabaaaaaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaiadpdoaaaaab""
}
SubProgram ""gles "" {
Keywords { ""POINT_COOKIE"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
Keywords { ""POINT_COOKIE"" }
""ps_4_0_level_9_1
eefiecedpplfmimdfdbfmdimjibnefjkbapfafjlabaaaaaagmabaaaaaeaaaaaa
daaaaaaaiiaaaaaamiaaaaaadiabaaaaebgpgodjfaaaaaaafaaaaaaaaaacpppp
cmaaaaaaceaaaaaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaacpppp
fbaaaaafaaaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpabaaaaacaaaicpia
aaaaoekappppaaaafdeieefcdiaaaaaaeaaaaaaaaoaaaaaagfaaaaadpccabaaa
aaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaiadpdoaaaaabejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaahaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
Keywords { ""POINT_COOKIE"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 2 math
Keywords { ""POINT_COOKIE"" }
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 c_1;
  c_1.xyz = half3(float3(0.0, 0.0, 0.0));
  c_1.w = half(1.0);
  _mtl_o._glesFragData_0 = c_1;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
Keywords { ""DIRECTIONAL_COOKIE"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 1 math
Keywords { ""DIRECTIONAL_COOKIE"" }
""ps_2_0
def c0, 0, 0, 0, 1
mov_pp oC0, c0

""
}
SubProgram ""d3d11 "" {
Keywords { ""DIRECTIONAL_COOKIE"" }
""ps_4_0
eefiecedpdipnlijaafddlnglckhfpnipdngegoeabaaaaaabaabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdiaaaaaaeaaaaaaaaoaaaaaa
gfaaaaadpccabaaaaaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaiadpdoaaaaab""
}
SubProgram ""gles "" {
Keywords { ""DIRECTIONAL_COOKIE"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
Keywords { ""DIRECTIONAL_COOKIE"" }
""ps_4_0_level_9_1
eefiecedpplfmimdfdbfmdimjibnefjkbapfafjlabaaaaaagmabaaaaaeaaaaaa
daaaaaaaiiaaaaaamiaaaaaadiabaaaaebgpgodjfaaaaaaafaaaaaaaaaacpppp
cmaaaaaaceaaaaaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaacpppp
fbaaaaafaaaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpabaaaaacaaaicpia
aaaaoekappppaaaafdeieefcdiaaaaaaeaaaaaaaaoaaaaaagfaaaaadpccabaaa
aaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaiadpdoaaaaabejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaahaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
Keywords { ""DIRECTIONAL_COOKIE"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 2 math
Keywords { ""DIRECTIONAL_COOKIE"" }
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 c_1;
  c_1.xyz = half3(float3(0.0, 0.0, 0.0));
  c_1.w = half(1.0);
  _mtl_o._glesFragData_0 = c_1;
  return _mtl_o;
}

""
}
}
 }


 // Stats for Vertex shader:
 //       d3d11 : 22 math
 //    d3d11_9x : 22 math
 //        d3d9 : 13 math
 //        gles : 3 math
 //       gles3 : 3 math
 //       metal : 8 math
 //      opengl : 3 math
 // Stats for Fragment shader:
 //       d3d11 : 1 math
 //    d3d11_9x : 1 math
 //        d3d9 : 3 math
 //       metal : 3 math
 Pass {
  Name ""PREPASS""
  Tags { ""LIGHTMODE""=""PrePassBase"" ""ForceNoShadowCasting""=""true"" ""DisableBatching""=""true"" ""RenderType""=""Opaque"" }
  GpuProgramID 149983
Program ""vp"" {
SubProgram ""opengl "" {
// Stats: 3 math
""!!GLSL
#ifdef VERTEX

uniform mat4 _Object2World;
uniform mat4 _World2Object;
varying vec3 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
void main ()
{
  vec4 v_1;
  v_1.x = _World2Object[0].x;
  v_1.y = _World2Object[1].x;
  v_1.z = _World2Object[2].x;
  v_1.w = _World2Object[3].x;
  vec4 v_2;
  v_2.x = _World2Object[0].y;
  v_2.y = _World2Object[1].y;
  v_2.z = _World2Object[2].y;
  v_2.w = _World2Object[3].y;
  vec4 v_3;
  v_3.x = _World2Object[0].z;
  v_3.y = _World2Object[1].z;
  v_3.z = _World2Object[2].z;
  v_3.w = _World2Object[3].z;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = normalize(((
    (v_1.xyz * gl_Normal.x)
   + 
    (v_2.xyz * gl_Normal.y)
  ) + (v_3.xyz * gl_Normal.z)));
  xlv_TEXCOORD1 = (_Object2World * gl_Vertex).xyz;
}


#endif
#ifdef FRAGMENT
varying vec3 xlv_TEXCOORD0;
void main ()
{
  vec4 res_1;
  res_1.xyz = ((xlv_TEXCOORD0 * 0.5) + 0.5);
  res_1.w = 0.0;
  gl_FragData[0] = res_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 13 math
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
""vs_2_0
dcl_position v0
dcl_normal v1
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
dp4 oT1.x, c4, v0
dp4 oT1.y, c5, v0
dp4 oT1.z, c6, v0
mul r0.xyz, v1.y, c8
mad r0.xyz, c7, v1.x, r0
mad r0.xyz, c9, v1.z, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul oT0.xyz, r0.w, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 22 math
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0
eefiecedinidogaapcaihlhlafeaicjabdmdpgobabaaaaaaneaeaaaaadaaaaaa
cmaaaaaaceabaaaajeabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcdiadaaaaeaaaabaa
moaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
hccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hccabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 3 math
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
varying mediump vec3 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT

varying mediump vec3 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 res_1;
  lowp vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD0;
  res_1.xyz = ((tmpvar_2 * 0.5) + 0.5);
  res_1.w = 0.0;
  gl_FragData[0] = res_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 22 math
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0_level_9_1
eefiecedfimbpiggiminkfbhlgdjijhgmgblgjidabaaaaaaneagaaaaaeaaaaaa
daaaaaaacmacaaaagmafaaaageagaaaaebgpgodjpeabaaaapeabaaaaaaacpopp
leabaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaaaa
aeaaabaaaaaaaaaaaaaaamaaahaaafaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjaafaaaaadaaaaahiaaaaaffja
agaaoekaaeaaaaaeaaaaahiaafaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahia
ahaaoekaaaaakkjaaaaaoeiaaeaaaaaeabaaahoaaiaaoekaaaaappjaaaaaoeia
afaaaaadaaaaabiaacaaaajaajaaaakaafaaaaadaaaaaciaacaaaajaakaaaaka
afaaaaadaaaaaeiaacaaaajaalaaaakaafaaaaadabaaabiaacaaffjaajaaffka
afaaaaadabaaaciaacaaffjaakaaffkaafaaaaadabaaaeiaacaaffjaalaaffka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaafaaaaadabaaabiaacaakkjaajaakkka
afaaaaadabaaaciaacaakkjaakaakkkaafaaaaadabaaaeiaacaakkjaalaakkka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaaiaaaaadaaaaaiiaaaaaoeiaaaaaoeia
ahaaaaacaaaaaiiaaaaappiaafaaaaadaaaaahoaaaaappiaaaaaoeiaafaaaaad
aaaaapiaaaaaffjaacaaoekaaeaaaaaeaaaaapiaabaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaadaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiappppaaaafdeieefcdiadaaaaeaaaabaamoaaaaaafjaaaaae
egiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadhccabaaaabaaaaaa
gfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
aaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaaaaaaaaadoaaaaabejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 3 math
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
out mediump vec3 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
in mediump vec3 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 res_1;
  lowp vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD0;
  res_1.xyz = ((tmpvar_2 * 0.5) + 0.5);
  res_1.w = 0.0;
  _glesFragData[0] = res_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 8 math
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
ConstBuffer ""$Globals"" 192
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [_Object2World]
Matrix 128 [_World2Object]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  half3 xlv_TEXCOORD0;
  float3 xlv_TEXCOORD1;
};
struct xlatMtlShaderUniform {
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  float4 v_3;
  v_3.x = _mtl_u._World2Object[0].x;
  v_3.y = _mtl_u._World2Object[1].x;
  v_3.z = _mtl_u._World2Object[2].x;
  v_3.w = _mtl_u._World2Object[3].x;
  float4 v_4;
  v_4.x = _mtl_u._World2Object[0].y;
  v_4.y = _mtl_u._World2Object[1].y;
  v_4.z = _mtl_u._World2Object[2].y;
  v_4.w = _mtl_u._World2Object[3].y;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].z;
  v_5.y = _mtl_u._World2Object[1].z;
  v_5.z = _mtl_u._World2Object[2].z;
  v_5.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _mtl_i._glesNormal.x)
   + 
    (v_4.xyz * _mtl_i._glesNormal.y)
  ) + (v_5.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_6);
  tmpvar_2 = worldNormal_1;
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD1 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  return _mtl_o;
}

""
}
}
Program ""fp"" {
SubProgram ""opengl "" {
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 3 math
""ps_2_0
def c0, 0.5, 0, 0, 0
dcl_pp t0.xyz
mad_pp r0.xyz, t0, c0.x, c0.x
mov_pp r0.w, c0.y
mov_pp oC0, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 1 math
""ps_4_0
eefiecedahndifnccigjgehbcgabbojggkeiepneabaaaaaaemabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcheaaaaaaeaaaaaaabnaaaaaa
gcbaaaadhcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaadcaaaaaphccabaaa
aaaaaaaaegbcbaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaa
aceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaaaaadoaaaaab""
}
SubProgram ""gles "" {
""!!GLES""
}
SubProgram ""d3d11_9x "" {
// Stats: 1 math
""ps_4_0_level_9_1
eefiecedlhbojekhenomcgbelfdkmofngcodlfjbabaaaaaaneabaaaaaeaaaaaa
daaaaaaaleaaaaaadaabaaaakaabaaaaebgpgodjhmaaaaaahmaaaaaaaaacpppp
fiaaaaaaceaaaaaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaacpppp
fbaaaaafaaaaapkaaaaaaadpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaia
aaaachlaaeaaaaaeaaaachiaaaaaoelaaaaaaakaaaaaaakaabaaaaacaaaaciia
aaaaffkaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcheaaaaaaeaaaaaaa
bnaaaaaagcbaaaadhcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaadcaaaaap
hccabaaaaaaaaaaaegbcbaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadp
aaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaaaaadoaaaaabejfdeheogiaaaaaaadaaaaaaaiaaaaaa
faaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaahahaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 3 math
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  half3 xlv_TEXCOORD0;
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 res_1;
  half3 tmpvar_2;
  tmpvar_2 = _mtl_i.xlv_TEXCOORD0;
  res_1.xyz = ((tmpvar_2 * (half)0.5) + (half)0.5);
  res_1.w = half(0.0);
  _mtl_o._glesFragData_0 = res_1;
  return _mtl_o;
}

""
}
}
 }


 // Stats for Vertex shader:
 //       d3d11 : 37 math
 //    d3d11_9x : 37 math
 //        d3d9 : 33 math
 //        gles : 10 avg math (9..11), 2 texture
 //       gles3 : 10 avg math (9..11), 2 texture
 //       metal : 29 math
 //      opengl : 4 math, 1 texture
 // Stats for Fragment shader:
 //       d3d11 : 1 math, 1 texture
 //    d3d11_9x : 1 math, 1 texture
 //        d3d9 : 3 math, 1 texture
 //       metal : 10 avg math (9..11), 2 texture
 Pass {
  Name ""PREPASS""
  Tags { ""LIGHTMODE""=""PrePassFinal"" ""ForceNoShadowCasting""=""true"" ""DisableBatching""=""true"" ""RenderType""=""Opaque"" }
  ZWrite Off
  GpuProgramID 216365
Program ""vp"" {
SubProgram ""opengl "" {
// Stats: 4 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLSL
#ifdef VERTEX
uniform vec4 _ProjectionParams;
uniform vec4 unity_SHAr;
uniform vec4 unity_SHAg;
uniform vec4 unity_SHAb;
uniform vec4 unity_SHBr;
uniform vec4 unity_SHBg;
uniform vec4 unity_SHBb;
uniform vec4 unity_SHC;

uniform mat4 _Object2World;
uniform mat4 _World2Object;
uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
varying vec4 xlv_TEXCOORD2;
varying vec4 xlv_TEXCOORD3;
varying vec3 xlv_TEXCOORD4;
void main ()
{
  vec4 tmpvar_1;
  vec4 tmpvar_2;
  tmpvar_2 = (gl_ModelViewProjectionMatrix * gl_Vertex);
  vec4 o_3;
  vec4 tmpvar_4;
  tmpvar_4 = (tmpvar_2 * 0.5);
  vec2 tmpvar_5;
  tmpvar_5.x = tmpvar_4.x;
  tmpvar_5.y = (tmpvar_4.y * _ProjectionParams.x);
  o_3.xy = (tmpvar_5 + tmpvar_4.w);
  o_3.zw = tmpvar_2.zw;
  tmpvar_1.zw = vec2(0.0, 0.0);
  tmpvar_1.xy = vec2(0.0, 0.0);
  vec4 v_6;
  v_6.x = _World2Object[0].x;
  v_6.y = _World2Object[1].x;
  v_6.z = _World2Object[2].x;
  v_6.w = _World2Object[3].x;
  vec4 v_7;
  v_7.x = _World2Object[0].y;
  v_7.y = _World2Object[1].y;
  v_7.z = _World2Object[2].y;
  v_7.w = _World2Object[3].y;
  vec4 v_8;
  v_8.x = _World2Object[0].z;
  v_8.y = _World2Object[1].z;
  v_8.z = _World2Object[2].z;
  v_8.w = _World2Object[3].z;
  vec3 tmpvar_9;
  tmpvar_9 = normalize(((
    (v_6.xyz * gl_Normal.x)
   + 
    (v_7.xyz * gl_Normal.y)
  ) + (v_8.xyz * gl_Normal.z)));
  vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = tmpvar_9;
  vec3 x2_11;
  vec3 x1_12;
  x1_12.x = dot (unity_SHAr, tmpvar_10);
  x1_12.y = dot (unity_SHAg, tmpvar_10);
  x1_12.z = dot (unity_SHAb, tmpvar_10);
  vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_9.xyzz * tmpvar_9.yzzx);
  x2_11.x = dot (unity_SHBr, tmpvar_13);
  x2_11.y = dot (unity_SHBg, tmpvar_13);
  x2_11.z = dot (unity_SHBb, tmpvar_13);
  gl_Position = tmpvar_2;
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = (_Object2World * gl_Vertex).xyz;
  xlv_TEXCOORD2 = o_3;
  xlv_TEXCOORD3 = tmpvar_1;
  xlv_TEXCOORD4 = ((x2_11 + (unity_SHC.xyz * 
    ((tmpvar_9.x * tmpvar_9.x) - (tmpvar_9.y * tmpvar_9.y))
  )) + x1_12);
}


#endif
#ifdef FRAGMENT
uniform sampler2D _XYSMap;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  vec4 c_1;
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 33 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
Vector 19 [_MainTex_ST]
Vector 10 [_ProjectionParams]
Vector 11 [_ScreenParams]
Vector 14 [unity_SHAb]
Vector 13 [unity_SHAg]
Vector 12 [unity_SHAr]
Vector 17 [unity_SHBb]
Vector 16 [unity_SHBg]
Vector 15 [unity_SHBr]
Vector 18 [unity_SHC]
""vs_2_0
def c20, 0.5, 1, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord v2
mad oT0.xy, v2, c19, c19.zwzw
dp4 oT1.x, c4, v0
dp4 oT1.y, c5, v0
dp4 oT1.z, c6, v0
dp4 r0.y, c1, v0
mul r1.x, r0.y, c10.x
mul r1.w, r1.x, c20.x
dp4 r0.x, c0, v0
dp4 r0.w, c3, v0
mul r1.xz, r0.xyww, c20.x
mad oT2.xy, r1.z, c11.zwzw, r1.xwzw
mul r1.xyz, v1.y, c8
mad r1.xyz, c7, v1.x, r1
mad r1.xyz, c9, v1.z, r1
nrm r2.xyz, r1
mul r1.x, r2.y, r2.y
mad r1.x, r2.x, r2.x, -r1.x
mul r3, r2.yzzx, r2.xyzz
dp4 r4.x, c15, r3
dp4 r4.y, c16, r3
dp4 r4.z, c17, r3
mad r1.xyz, c18, r1.x, r4
mov r2.w, c20.y
dp4 r3.x, c12, r2
dp4 r3.y, c13, r2
dp4 r3.z, c14, r2
add oT4.xyz, r1, r3
dp4 r0.z, c2, v0
mov oPos, r0
mov oT2.zw, r0
mov oT3, c20.z

""
}
SubProgram ""d3d11 "" {
// Stats: 37 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 176
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityPerCamera"" 144
Vector 80 [_ProjectionParams]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerCamera"" 1
BindCB  ""UnityLighting"" 2
BindCB  ""UnityPerDraw"" 3
""vs_4_0
eefiecedgkjhdnfcnbldbbockcppojndemhaflobabaaaaaammahaaaaadaaaaaa
cmaaaaaaceabaaaanmabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
oiafaaaaeaaaabaahkabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaae
egiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaacnaaaaaafjaaaaae
egiocaaaadaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadpccabaaa
adaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaac
aeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
pccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaai
hcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaadaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaiccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaa
agahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaaf
mccabaaaadaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaadaaaaaakgakbaaa
abaaaaaamgaabaaaabaaaaaadgaaaaaipccabaaaaeaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaadaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaadaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
adaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
adaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
adaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaa
aaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaaabaaaaaaakaabaaaaaaaaaaa
akaabaaaaaaaaaaaakaabaiaebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaa
jgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaa
acaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaa
acaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaa
acaaaaaaclaaaaaaegaobaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaa
acaaaaaacmaaaaaaagaabaaaabaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaa
aaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaacaaaaaaegiocaaaacaaaaaa
cgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaacaaaaaaegiocaaaacaaaaaa
chaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaacaaaaaaegiocaaaacaaaaaa
ciaaaaaaegaobaaaaaaaaaaaaaaaaaahhccabaaaafaaaaaaegacbaaaabaaaaaa
egacbaaaacaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 11 math, 2 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform highp vec4 _ProjectionParams;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying highp vec4 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD3;
varying highp vec3 xlv_TEXCOORD4;
void main ()
{
  highp vec4 tmpvar_1;
  highp vec3 tmpvar_2;
  highp vec4 tmpvar_3;
  tmpvar_3 = (glstate_matrix_mvp * _glesVertex);
  highp vec4 o_4;
  highp vec4 tmpvar_5;
  tmpvar_5 = (tmpvar_3 * 0.5);
  highp vec2 tmpvar_6;
  tmpvar_6.x = tmpvar_5.x;
  tmpvar_6.y = (tmpvar_5.y * _ProjectionParams.x);
  o_4.xy = (tmpvar_6 + tmpvar_5.w);
  o_4.zw = tmpvar_3.zw;
  tmpvar_1.zw = vec2(0.0, 0.0);
  tmpvar_1.xy = vec2(0.0, 0.0);
  highp vec4 v_7;
  v_7.x = _World2Object[0].x;
  v_7.y = _World2Object[1].x;
  v_7.z = _World2Object[2].x;
  v_7.w = _World2Object[3].x;
  highp vec4 v_8;
  v_8.x = _World2Object[0].y;
  v_8.y = _World2Object[1].y;
  v_8.z = _World2Object[2].y;
  v_8.w = _World2Object[3].y;
  highp vec4 v_9;
  v_9.x = _World2Object[0].z;
  v_9.y = _World2Object[1].z;
  v_9.z = _World2Object[2].z;
  v_9.w = _World2Object[3].z;
  highp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = normalize(((
    (v_7.xyz * _glesNormal.x)
   + 
    (v_8.xyz * _glesNormal.y)
  ) + (v_9.xyz * _glesNormal.z)));
  mediump vec3 tmpvar_11;
  mediump vec4 normal_12;
  normal_12 = tmpvar_10;
  mediump vec3 x2_13;
  mediump vec3 x1_14;
  x1_14.x = dot (unity_SHAr, normal_12);
  x1_14.y = dot (unity_SHAg, normal_12);
  x1_14.z = dot (unity_SHAb, normal_12);
  mediump vec4 tmpvar_15;
  tmpvar_15 = (normal_12.xyzz * normal_12.yzzx);
  x2_13.x = dot (unity_SHBr, tmpvar_15);
  x2_13.y = dot (unity_SHBg, tmpvar_15);
  x2_13.z = dot (unity_SHBb, tmpvar_15);
  tmpvar_11 = ((x2_13 + (unity_SHC.xyz * 
    ((normal_12.x * normal_12.x) - (normal_12.y * normal_12.y))
  )) + x1_14);
  tmpvar_2 = tmpvar_11;
  gl_Position = tmpvar_3;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
  xlv_TEXCOORD2 = o_4;
  xlv_TEXCOORD3 = tmpvar_1;
  xlv_TEXCOORD4 = tmpvar_2;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _XYSMap;
uniform sampler2D _LightBuffer;
varying highp vec2 xlv_TEXCOORD0;
varying highp vec4 xlv_TEXCOORD2;
varying highp vec3 xlv_TEXCOORD4;
void main ()
{
  lowp vec4 tmpvar_1;
  mediump vec4 c_2;
  mediump vec4 light_3;
  lowp vec4 tmpvar_4;
  tmpvar_4 = texture2D (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_5;
  tmpvar_5.x = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.y = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.z = (tmpvar_4.y - tmpvar_4.z);
  lowp vec4 tmpvar_6;
  tmpvar_6 = texture2DProj (_LightBuffer, xlv_TEXCOORD2);
  light_3 = tmpvar_6;
  mediump vec4 tmpvar_7;
  tmpvar_7 = -(log2(max (light_3, vec4(0.001, 0.001, 0.001, 0.001))));
  light_3.w = tmpvar_7.w;
  highp vec3 tmpvar_8;
  tmpvar_8 = (tmpvar_7.xyz + xlv_TEXCOORD4);
  light_3.xyz = tmpvar_8;
  lowp vec4 c_9;
  c_9.xyz = vec3(0.0, 0.0, 0.0);
  c_9.w = 1.0;
  c_2 = c_9;
  c_2.xyz = (c_2.xyz + tmpvar_5);
  c_2.w = 1.0;
  tmpvar_1 = c_2;
  gl_FragData[0] = tmpvar_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 37 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 176
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityPerCamera"" 144
Vector 80 [_ProjectionParams]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerCamera"" 1
BindCB  ""UnityLighting"" 2
BindCB  ""UnityPerDraw"" 3
""vs_4_0_level_9_1
eefiecedgndkonombofnfgnjocjnddidplmoojhoabaaaaaacealaaaaaeaaaaaa
daaaaaaaieadaaaaheajaaaagmakaaaaebgpgodjemadaaaaemadaaaaaaacpopp
oiacaaaageaaaaaaafaaceaaaaaagaaaaaaagaaaaaaaceaaabaagaaaaaaaajaa
abaaabaaaaaaaaaaabaaafaaabaaacaaaaaaaaaaacaacgaaahaaadaaaaaaaaaa
adaaaaaaaeaaakaaaaaaaaaaadaaamaaahaaaoaaaaaaaaaaaaaaaaaaaaacpopp
fbaaaaafbfaaapkaaaaaaadpaaaaiadpaaaaaaaaaaaaaaaabpaaaaacafaaaaia
aaaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjaaeaaaaae
aaaaadoaadaaoejaabaaoekaabaaookaafaaaaadaaaaahiaaaaaffjaapaaoeka
aeaaaaaeaaaaahiaaoaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahiabaaaoeka
aaaakkjaaaaaoeiaaeaaaaaeabaaahoabbaaoekaaaaappjaaaaaoeiaafaaaaad
aaaaapiaaaaaffjaalaaoekaaeaaaaaeaaaaapiaakaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaamaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaanaaoeka
aaaappjaaaaaoeiaafaaaaadabaaabiaaaaaffiaacaaaakaafaaaaadabaaaiia
abaaaaiabfaaaakaafaaaaadabaaafiaaaaapeiabfaaaakaacaaaaadacaaadoa
abaakkiaabaaomiaafaaaaadabaaabiaacaaaajabcaaaakaafaaaaadabaaacia
acaaaajabdaaaakaafaaaaadabaaaeiaacaaaajabeaaaakaafaaaaadacaaabia
acaaffjabcaaffkaafaaaaadacaaaciaacaaffjabdaaffkaafaaaaadacaaaeia
acaaffjabeaaffkaacaaaaadabaaahiaabaaoeiaacaaoeiaafaaaaadacaaabia
acaakkjabcaakkkaafaaaaadacaaaciaacaakkjabdaakkkaafaaaaadacaaaeia
acaakkjabeaakkkaacaaaaadabaaahiaabaaoeiaacaaoeiaceaaaaacacaaahia
abaaoeiaafaaaaadabaaabiaacaaffiaacaaffiaaeaaaaaeabaaabiaacaaaaia
acaaaaiaabaaaaibafaaaaadadaaapiaacaacjiaacaakeiaajaaaaadaeaaabia
agaaoekaadaaoeiaajaaaaadaeaaaciaahaaoekaadaaoeiaajaaaaadaeaaaeia
aiaaoekaadaaoeiaaeaaaaaeabaaahiaajaaoekaabaaaaiaaeaaoeiaabaaaaac
acaaaiiabfaaffkaajaaaaadadaaabiaadaaoekaacaaoeiaajaaaaadadaaacia
aeaaoekaacaaoeiaajaaaaadadaaaeiaafaaoekaacaaoeiaacaaaaadaeaaahoa
abaaoeiaadaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiaabaaaaacacaaamoaaaaaoeiaabaaaaacadaaapoabfaakkka
ppppaaaafdeieefcoiafaaaaeaaaabaahkabaaaafjaaaaaeegiocaaaaaaaaaaa
akaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaa
cnaaaaaafjaaaaaeegiocaaaadaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaa
gfaaaaadpccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadhccabaaa
afaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
aaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaa
ajaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaa
anaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaaacaaaaaa
egiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaadaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
adaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadgaaaaaipccabaaaaeaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaadaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaadaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaadaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaahbcaabaaa
abaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaaabaaaaaa
akaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaiaebaaaaaaabaaaaaadiaaaaah
pcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaa
adaaaaaaegiocaaaacaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaa
adaaaaaaegiocaaaacaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaa
adaaaaaaegiocaaaacaaaaaaclaaaaaaegaobaaaacaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaacaaaaaacmaaaaaaagaabaaaabaaaaaaegacbaaaadaaaaaa
dgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaacaaaaaa
egiocaaaacaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaacaaaaaa
egiocaaaacaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaacaaaaaa
egiocaaaacaaaaaaciaaaaaaegaobaaaaaaaaaaaaaaaaaahhccabaaaafaaaaaa
egacbaaaabaaaaaaegacbaaaacaaaaaadoaaaaabejfdeheopaaaaaaaaiaaaaaa
aiaaaaaamiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apadaaaaoaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaa
acaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaa
adaaaaaaagaaaaaaapaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaa
apaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffied
epepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 11 math, 2 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform highp vec4 _ProjectionParams;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
out highp vec4 xlv_TEXCOORD2;
out highp vec4 xlv_TEXCOORD3;
out highp vec3 xlv_TEXCOORD4;
void main ()
{
  highp vec4 tmpvar_1;
  highp vec3 tmpvar_2;
  highp vec4 tmpvar_3;
  tmpvar_3 = (glstate_matrix_mvp * _glesVertex);
  highp vec4 o_4;
  highp vec4 tmpvar_5;
  tmpvar_5 = (tmpvar_3 * 0.5);
  highp vec2 tmpvar_6;
  tmpvar_6.x = tmpvar_5.x;
  tmpvar_6.y = (tmpvar_5.y * _ProjectionParams.x);
  o_4.xy = (tmpvar_6 + tmpvar_5.w);
  o_4.zw = tmpvar_3.zw;
  tmpvar_1.zw = vec2(0.0, 0.0);
  tmpvar_1.xy = vec2(0.0, 0.0);
  highp vec4 v_7;
  v_7.x = _World2Object[0].x;
  v_7.y = _World2Object[1].x;
  v_7.z = _World2Object[2].x;
  v_7.w = _World2Object[3].x;
  highp vec4 v_8;
  v_8.x = _World2Object[0].y;
  v_8.y = _World2Object[1].y;
  v_8.z = _World2Object[2].y;
  v_8.w = _World2Object[3].y;
  highp vec4 v_9;
  v_9.x = _World2Object[0].z;
  v_9.y = _World2Object[1].z;
  v_9.z = _World2Object[2].z;
  v_9.w = _World2Object[3].z;
  highp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = normalize(((
    (v_7.xyz * _glesNormal.x)
   + 
    (v_8.xyz * _glesNormal.y)
  ) + (v_9.xyz * _glesNormal.z)));
  mediump vec3 tmpvar_11;
  mediump vec4 normal_12;
  normal_12 = tmpvar_10;
  mediump vec3 x2_13;
  mediump vec3 x1_14;
  x1_14.x = dot (unity_SHAr, normal_12);
  x1_14.y = dot (unity_SHAg, normal_12);
  x1_14.z = dot (unity_SHAb, normal_12);
  mediump vec4 tmpvar_15;
  tmpvar_15 = (normal_12.xyzz * normal_12.yzzx);
  x2_13.x = dot (unity_SHBr, tmpvar_15);
  x2_13.y = dot (unity_SHBg, tmpvar_15);
  x2_13.z = dot (unity_SHBb, tmpvar_15);
  tmpvar_11 = ((x2_13 + (unity_SHC.xyz * 
    ((normal_12.x * normal_12.x) - (normal_12.y * normal_12.y))
  )) + x1_14);
  tmpvar_2 = tmpvar_11;
  gl_Position = tmpvar_3;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
  xlv_TEXCOORD2 = o_4;
  xlv_TEXCOORD3 = tmpvar_1;
  xlv_TEXCOORD4 = tmpvar_2;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _XYSMap;
uniform sampler2D _LightBuffer;
in highp vec2 xlv_TEXCOORD0;
in highp vec4 xlv_TEXCOORD2;
in highp vec3 xlv_TEXCOORD4;
void main ()
{
  lowp vec4 tmpvar_1;
  mediump vec4 c_2;
  mediump vec4 light_3;
  lowp vec4 tmpvar_4;
  tmpvar_4 = texture (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_5;
  tmpvar_5.x = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.y = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.z = (tmpvar_4.y - tmpvar_4.z);
  lowp vec4 tmpvar_6;
  tmpvar_6 = textureProj (_LightBuffer, xlv_TEXCOORD2);
  light_3 = tmpvar_6;
  mediump vec4 tmpvar_7;
  tmpvar_7 = -(log2(max (light_3, vec4(0.001, 0.001, 0.001, 0.001))));
  light_3.w = tmpvar_7.w;
  highp vec3 tmpvar_8;
  tmpvar_8 = (tmpvar_7.xyz + xlv_TEXCOORD4);
  light_3.xyz = tmpvar_8;
  lowp vec4 c_9;
  c_9.xyz = vec3(0.0, 0.0, 0.0);
  c_9.w = 1.0;
  c_2 = c_9;
  c_2.xyz = (c_2.xyz + tmpvar_5);
  c_2.w = 1.0;
  tmpvar_1 = c_2;
  _glesFragData[0] = tmpvar_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 29 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
Bind ""texcoord"" ATTR2
ConstBuffer ""$Globals"" 288
Matrix 80 [glstate_matrix_mvp]
Matrix 144 [_Object2World]
Matrix 208 [_World2Object]
Vector 0 [_ProjectionParams]
VectorHalf 16 [unity_SHAr] 4
VectorHalf 24 [unity_SHAg] 4
VectorHalf 32 [unity_SHAb] 4
VectorHalf 40 [unity_SHBr] 4
VectorHalf 48 [unity_SHBg] 4
VectorHalf 56 [unity_SHBb] 4
VectorHalf 64 [unity_SHC] 4
Vector 272 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
  float4 _glesMultiTexCoord0 [[attribute(2)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  float2 xlv_TEXCOORD0;
  float3 xlv_TEXCOORD1;
  float4 xlv_TEXCOORD2;
  float4 xlv_TEXCOORD3;
  float3 xlv_TEXCOORD4;
};
struct xlatMtlShaderUniform {
  float4 _ProjectionParams;
  half4 unity_SHAr;
  half4 unity_SHAg;
  half4 unity_SHAb;
  half4 unity_SHBr;
  half4 unity_SHBg;
  half4 unity_SHBb;
  half4 unity_SHC;
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  float4 tmpvar_1;
  float3 tmpvar_2;
  float4 tmpvar_3;
  tmpvar_3 = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  float4 o_4;
  float4 tmpvar_5;
  tmpvar_5 = (tmpvar_3 * 0.5);
  float2 tmpvar_6;
  tmpvar_6.x = tmpvar_5.x;
  tmpvar_6.y = (tmpvar_5.y * _mtl_u._ProjectionParams.x);
  o_4.xy = (tmpvar_6 + tmpvar_5.w);
  o_4.zw = tmpvar_3.zw;
  tmpvar_1.zw = float2(0.0, 0.0);
  tmpvar_1.xy = float2(0.0, 0.0);
  float4 v_7;
  v_7.x = _mtl_u._World2Object[0].x;
  v_7.y = _mtl_u._World2Object[1].x;
  v_7.z = _mtl_u._World2Object[2].x;
  v_7.w = _mtl_u._World2Object[3].x;
  float4 v_8;
  v_8.x = _mtl_u._World2Object[0].y;
  v_8.y = _mtl_u._World2Object[1].y;
  v_8.z = _mtl_u._World2Object[2].y;
  v_8.w = _mtl_u._World2Object[3].y;
  float4 v_9;
  v_9.x = _mtl_u._World2Object[0].z;
  v_9.y = _mtl_u._World2Object[1].z;
  v_9.z = _mtl_u._World2Object[2].z;
  v_9.w = _mtl_u._World2Object[3].z;
  float4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = normalize(((
    (v_7.xyz * _mtl_i._glesNormal.x)
   + 
    (v_8.xyz * _mtl_i._glesNormal.y)
  ) + (v_9.xyz * _mtl_i._glesNormal.z)));
  half3 tmpvar_11;
  half4 normal_12;
  normal_12 = half4(tmpvar_10);
  half3 x2_13;
  half3 x1_14;
  x1_14.x = dot (_mtl_u.unity_SHAr, normal_12);
  x1_14.y = dot (_mtl_u.unity_SHAg, normal_12);
  x1_14.z = dot (_mtl_u.unity_SHAb, normal_12);
  half4 tmpvar_15;
  tmpvar_15 = (normal_12.xyzz * normal_12.yzzx);
  x2_13.x = dot (_mtl_u.unity_SHBr, tmpvar_15);
  x2_13.y = dot (_mtl_u.unity_SHBg, tmpvar_15);
  x2_13.z = dot (_mtl_u.unity_SHBb, tmpvar_15);
  tmpvar_11 = ((x2_13 + (_mtl_u.unity_SHC.xyz * 
    ((normal_12.x * normal_12.x) - (normal_12.y * normal_12.y))
  )) + x1_14);
  tmpvar_2 = float3(tmpvar_11);
  _mtl_o.gl_Position = tmpvar_3;
  _mtl_o.xlv_TEXCOORD0 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  _mtl_o.xlv_TEXCOORD1 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  _mtl_o.xlv_TEXCOORD2 = o_4;
  _mtl_o.xlv_TEXCOORD3 = tmpvar_1;
  _mtl_o.xlv_TEXCOORD4 = tmpvar_2;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
// Stats: 4 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLSL
#ifdef VERTEX
uniform vec4 _ProjectionParams;
uniform vec4 unity_SHAr;
uniform vec4 unity_SHAg;
uniform vec4 unity_SHAb;
uniform vec4 unity_SHBr;
uniform vec4 unity_SHBg;
uniform vec4 unity_SHBb;
uniform vec4 unity_SHC;

uniform mat4 _Object2World;
uniform mat4 _World2Object;
uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
varying vec4 xlv_TEXCOORD2;
varying vec4 xlv_TEXCOORD3;
varying vec3 xlv_TEXCOORD4;
void main ()
{
  vec4 tmpvar_1;
  vec4 tmpvar_2;
  tmpvar_2 = (gl_ModelViewProjectionMatrix * gl_Vertex);
  vec4 o_3;
  vec4 tmpvar_4;
  tmpvar_4 = (tmpvar_2 * 0.5);
  vec2 tmpvar_5;
  tmpvar_5.x = tmpvar_4.x;
  tmpvar_5.y = (tmpvar_4.y * _ProjectionParams.x);
  o_3.xy = (tmpvar_5 + tmpvar_4.w);
  o_3.zw = tmpvar_2.zw;
  tmpvar_1.zw = vec2(0.0, 0.0);
  tmpvar_1.xy = vec2(0.0, 0.0);
  vec4 v_6;
  v_6.x = _World2Object[0].x;
  v_6.y = _World2Object[1].x;
  v_6.z = _World2Object[2].x;
  v_6.w = _World2Object[3].x;
  vec4 v_7;
  v_7.x = _World2Object[0].y;
  v_7.y = _World2Object[1].y;
  v_7.z = _World2Object[2].y;
  v_7.w = _World2Object[3].y;
  vec4 v_8;
  v_8.x = _World2Object[0].z;
  v_8.y = _World2Object[1].z;
  v_8.z = _World2Object[2].z;
  v_8.w = _World2Object[3].z;
  vec3 tmpvar_9;
  tmpvar_9 = normalize(((
    (v_6.xyz * gl_Normal.x)
   + 
    (v_7.xyz * gl_Normal.y)
  ) + (v_8.xyz * gl_Normal.z)));
  vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = tmpvar_9;
  vec3 x2_11;
  vec3 x1_12;
  x1_12.x = dot (unity_SHAr, tmpvar_10);
  x1_12.y = dot (unity_SHAg, tmpvar_10);
  x1_12.z = dot (unity_SHAb, tmpvar_10);
  vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_9.xyzz * tmpvar_9.yzzx);
  x2_11.x = dot (unity_SHBr, tmpvar_13);
  x2_11.y = dot (unity_SHBg, tmpvar_13);
  x2_11.z = dot (unity_SHBb, tmpvar_13);
  gl_Position = tmpvar_2;
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = (_Object2World * gl_Vertex).xyz;
  xlv_TEXCOORD2 = o_3;
  xlv_TEXCOORD3 = tmpvar_1;
  xlv_TEXCOORD4 = ((x2_11 + (unity_SHC.xyz * 
    ((tmpvar_9.x * tmpvar_9.x) - (tmpvar_9.y * tmpvar_9.y))
  )) + x1_12);
}


#endif
#ifdef FRAGMENT
uniform sampler2D _XYSMap;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  vec4 c_1;
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 33 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
Vector 19 [_MainTex_ST]
Vector 10 [_ProjectionParams]
Vector 11 [_ScreenParams]
Vector 14 [unity_SHAb]
Vector 13 [unity_SHAg]
Vector 12 [unity_SHAr]
Vector 17 [unity_SHBb]
Vector 16 [unity_SHBg]
Vector 15 [unity_SHBr]
Vector 18 [unity_SHC]
""vs_2_0
def c20, 0.5, 1, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord v2
mad oT0.xy, v2, c19, c19.zwzw
dp4 oT1.x, c4, v0
dp4 oT1.y, c5, v0
dp4 oT1.z, c6, v0
dp4 r0.y, c1, v0
mul r1.x, r0.y, c10.x
mul r1.w, r1.x, c20.x
dp4 r0.x, c0, v0
dp4 r0.w, c3, v0
mul r1.xz, r0.xyww, c20.x
mad oT2.xy, r1.z, c11.zwzw, r1.xwzw
mul r1.xyz, v1.y, c8
mad r1.xyz, c7, v1.x, r1
mad r1.xyz, c9, v1.z, r1
nrm r2.xyz, r1
mul r1.x, r2.y, r2.y
mad r1.x, r2.x, r2.x, -r1.x
mul r3, r2.yzzx, r2.xyzz
dp4 r4.x, c15, r3
dp4 r4.y, c16, r3
dp4 r4.z, c17, r3
mad r1.xyz, c18, r1.x, r4
mov r2.w, c20.y
dp4 r3.x, c12, r2
dp4 r3.y, c13, r2
dp4 r3.z, c14, r2
add oT4.xyz, r1, r3
dp4 r0.z, c2, v0
mov oPos, r0
mov oT2.zw, r0
mov oT3, c20.z

""
}
SubProgram ""d3d11 "" {
// Stats: 37 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 176
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityPerCamera"" 144
Vector 80 [_ProjectionParams]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerCamera"" 1
BindCB  ""UnityLighting"" 2
BindCB  ""UnityPerDraw"" 3
""vs_4_0
eefiecedgkjhdnfcnbldbbockcppojndemhaflobabaaaaaammahaaaaadaaaaaa
cmaaaaaaceabaaaanmabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
oiafaaaaeaaaabaahkabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaae
egiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaacnaaaaaafjaaaaae
egiocaaaadaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadpccabaaa
adaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaac
aeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
pccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaai
hcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaadaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaiccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaa
agahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaaf
mccabaaaadaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaadaaaaaakgakbaaa
abaaaaaamgaabaaaabaaaaaadgaaaaaipccabaaaaeaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaadaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaadaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
adaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
adaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
adaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaa
aaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaaabaaaaaaakaabaaaaaaaaaaa
akaabaaaaaaaaaaaakaabaiaebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaa
jgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaa
acaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaa
acaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaa
acaaaaaaclaaaaaaegaobaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaa
acaaaaaacmaaaaaaagaabaaaabaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaa
aaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaacaaaaaaegiocaaaacaaaaaa
cgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaacaaaaaaegiocaaaacaaaaaa
chaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaacaaaaaaegiocaaaacaaaaaa
ciaaaaaaegaobaaaaaaaaaaaaaaaaaahhccabaaaafaaaaaaegacbaaaabaaaaaa
egacbaaaacaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 9 math, 2 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform highp vec4 _ProjectionParams;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying highp vec4 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD3;
varying highp vec3 xlv_TEXCOORD4;
void main ()
{
  highp vec4 tmpvar_1;
  highp vec3 tmpvar_2;
  highp vec4 tmpvar_3;
  tmpvar_3 = (glstate_matrix_mvp * _glesVertex);
  highp vec4 o_4;
  highp vec4 tmpvar_5;
  tmpvar_5 = (tmpvar_3 * 0.5);
  highp vec2 tmpvar_6;
  tmpvar_6.x = tmpvar_5.x;
  tmpvar_6.y = (tmpvar_5.y * _ProjectionParams.x);
  o_4.xy = (tmpvar_6 + tmpvar_5.w);
  o_4.zw = tmpvar_3.zw;
  tmpvar_1.zw = vec2(0.0, 0.0);
  tmpvar_1.xy = vec2(0.0, 0.0);
  highp vec4 v_7;
  v_7.x = _World2Object[0].x;
  v_7.y = _World2Object[1].x;
  v_7.z = _World2Object[2].x;
  v_7.w = _World2Object[3].x;
  highp vec4 v_8;
  v_8.x = _World2Object[0].y;
  v_8.y = _World2Object[1].y;
  v_8.z = _World2Object[2].y;
  v_8.w = _World2Object[3].y;
  highp vec4 v_9;
  v_9.x = _World2Object[0].z;
  v_9.y = _World2Object[1].z;
  v_9.z = _World2Object[2].z;
  v_9.w = _World2Object[3].z;
  highp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = normalize(((
    (v_7.xyz * _glesNormal.x)
   + 
    (v_8.xyz * _glesNormal.y)
  ) + (v_9.xyz * _glesNormal.z)));
  mediump vec3 tmpvar_11;
  mediump vec4 normal_12;
  normal_12 = tmpvar_10;
  mediump vec3 x2_13;
  mediump vec3 x1_14;
  x1_14.x = dot (unity_SHAr, normal_12);
  x1_14.y = dot (unity_SHAg, normal_12);
  x1_14.z = dot (unity_SHAb, normal_12);
  mediump vec4 tmpvar_15;
  tmpvar_15 = (normal_12.xyzz * normal_12.yzzx);
  x2_13.x = dot (unity_SHBr, tmpvar_15);
  x2_13.y = dot (unity_SHBg, tmpvar_15);
  x2_13.z = dot (unity_SHBb, tmpvar_15);
  tmpvar_11 = ((x2_13 + (unity_SHC.xyz * 
    ((normal_12.x * normal_12.x) - (normal_12.y * normal_12.y))
  )) + x1_14);
  tmpvar_2 = tmpvar_11;
  gl_Position = tmpvar_3;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
  xlv_TEXCOORD2 = o_4;
  xlv_TEXCOORD3 = tmpvar_1;
  xlv_TEXCOORD4 = tmpvar_2;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _XYSMap;
uniform sampler2D _LightBuffer;
varying highp vec2 xlv_TEXCOORD0;
varying highp vec4 xlv_TEXCOORD2;
varying highp vec3 xlv_TEXCOORD4;
void main ()
{
  lowp vec4 tmpvar_1;
  mediump vec4 c_2;
  mediump vec4 light_3;
  lowp vec4 tmpvar_4;
  tmpvar_4 = texture2D (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_5;
  tmpvar_5.x = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.y = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.z = (tmpvar_4.y - tmpvar_4.z);
  lowp vec4 tmpvar_6;
  tmpvar_6 = texture2DProj (_LightBuffer, xlv_TEXCOORD2);
  light_3 = tmpvar_6;
  mediump vec4 tmpvar_7;
  tmpvar_7 = max (light_3, vec4(0.001, 0.001, 0.001, 0.001));
  light_3.w = tmpvar_7.w;
  highp vec3 tmpvar_8;
  tmpvar_8 = (tmpvar_7.xyz + xlv_TEXCOORD4);
  light_3.xyz = tmpvar_8;
  lowp vec4 c_9;
  c_9.xyz = vec3(0.0, 0.0, 0.0);
  c_9.w = 1.0;
  c_2 = c_9;
  c_2.xyz = (c_2.xyz + tmpvar_5);
  c_2.w = 1.0;
  tmpvar_1 = c_2;
  gl_FragData[0] = tmpvar_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 37 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 176
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityPerCamera"" 144
Vector 80 [_ProjectionParams]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerCamera"" 1
BindCB  ""UnityLighting"" 2
BindCB  ""UnityPerDraw"" 3
""vs_4_0_level_9_1
eefiecedgndkonombofnfgnjocjnddidplmoojhoabaaaaaacealaaaaaeaaaaaa
daaaaaaaieadaaaaheajaaaagmakaaaaebgpgodjemadaaaaemadaaaaaaacpopp
oiacaaaageaaaaaaafaaceaaaaaagaaaaaaagaaaaaaaceaaabaagaaaaaaaajaa
abaaabaaaaaaaaaaabaaafaaabaaacaaaaaaaaaaacaacgaaahaaadaaaaaaaaaa
adaaaaaaaeaaakaaaaaaaaaaadaaamaaahaaaoaaaaaaaaaaaaaaaaaaaaacpopp
fbaaaaafbfaaapkaaaaaaadpaaaaiadpaaaaaaaaaaaaaaaabpaaaaacafaaaaia
aaaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjaaeaaaaae
aaaaadoaadaaoejaabaaoekaabaaookaafaaaaadaaaaahiaaaaaffjaapaaoeka
aeaaaaaeaaaaahiaaoaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahiabaaaoeka
aaaakkjaaaaaoeiaaeaaaaaeabaaahoabbaaoekaaaaappjaaaaaoeiaafaaaaad
aaaaapiaaaaaffjaalaaoekaaeaaaaaeaaaaapiaakaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaamaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaanaaoeka
aaaappjaaaaaoeiaafaaaaadabaaabiaaaaaffiaacaaaakaafaaaaadabaaaiia
abaaaaiabfaaaakaafaaaaadabaaafiaaaaapeiabfaaaakaacaaaaadacaaadoa
abaakkiaabaaomiaafaaaaadabaaabiaacaaaajabcaaaakaafaaaaadabaaacia
acaaaajabdaaaakaafaaaaadabaaaeiaacaaaajabeaaaakaafaaaaadacaaabia
acaaffjabcaaffkaafaaaaadacaaaciaacaaffjabdaaffkaafaaaaadacaaaeia
acaaffjabeaaffkaacaaaaadabaaahiaabaaoeiaacaaoeiaafaaaaadacaaabia
acaakkjabcaakkkaafaaaaadacaaaciaacaakkjabdaakkkaafaaaaadacaaaeia
acaakkjabeaakkkaacaaaaadabaaahiaabaaoeiaacaaoeiaceaaaaacacaaahia
abaaoeiaafaaaaadabaaabiaacaaffiaacaaffiaaeaaaaaeabaaabiaacaaaaia
acaaaaiaabaaaaibafaaaaadadaaapiaacaacjiaacaakeiaajaaaaadaeaaabia
agaaoekaadaaoeiaajaaaaadaeaaaciaahaaoekaadaaoeiaajaaaaadaeaaaeia
aiaaoekaadaaoeiaaeaaaaaeabaaahiaajaaoekaabaaaaiaaeaaoeiaabaaaaac
acaaaiiabfaaffkaajaaaaadadaaabiaadaaoekaacaaoeiaajaaaaadadaaacia
aeaaoekaacaaoeiaajaaaaadadaaaeiaafaaoekaacaaoeiaacaaaaadaeaaahoa
abaaoeiaadaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiaabaaaaacacaaamoaaaaaoeiaabaaaaacadaaapoabfaakkka
ppppaaaafdeieefcoiafaaaaeaaaabaahkabaaaafjaaaaaeegiocaaaaaaaaaaa
akaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaa
cnaaaaaafjaaaaaeegiocaaaadaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaa
gfaaaaadpccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadhccabaaa
afaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
aaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaa
ajaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaa
anaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaaacaaaaaa
egiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaadaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
adaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadgaaaaaipccabaaaaeaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaadaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaadaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaadaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaahbcaabaaa
abaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaaabaaaaaa
akaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaiaebaaaaaaabaaaaaadiaaaaah
pcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaa
adaaaaaaegiocaaaacaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaa
adaaaaaaegiocaaaacaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaa
adaaaaaaegiocaaaacaaaaaaclaaaaaaegaobaaaacaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaacaaaaaacmaaaaaaagaabaaaabaaaaaaegacbaaaadaaaaaa
dgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaacaaaaaa
egiocaaaacaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaacaaaaaa
egiocaaaacaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaacaaaaaa
egiocaaaacaaaaaaciaaaaaaegaobaaaaaaaaaaaaaaaaaahhccabaaaafaaaaaa
egacbaaaabaaaaaaegacbaaaacaaaaaadoaaaaabejfdeheopaaaaaaaaiaaaaaa
aiaaaaaamiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apadaaaaoaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaa
acaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaa
adaaaaaaagaaaaaaapaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaa
apaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffied
epepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 9 math, 2 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform highp vec4 _ProjectionParams;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
out highp vec4 xlv_TEXCOORD2;
out highp vec4 xlv_TEXCOORD3;
out highp vec3 xlv_TEXCOORD4;
void main ()
{
  highp vec4 tmpvar_1;
  highp vec3 tmpvar_2;
  highp vec4 tmpvar_3;
  tmpvar_3 = (glstate_matrix_mvp * _glesVertex);
  highp vec4 o_4;
  highp vec4 tmpvar_5;
  tmpvar_5 = (tmpvar_3 * 0.5);
  highp vec2 tmpvar_6;
  tmpvar_6.x = tmpvar_5.x;
  tmpvar_6.y = (tmpvar_5.y * _ProjectionParams.x);
  o_4.xy = (tmpvar_6 + tmpvar_5.w);
  o_4.zw = tmpvar_3.zw;
  tmpvar_1.zw = vec2(0.0, 0.0);
  tmpvar_1.xy = vec2(0.0, 0.0);
  highp vec4 v_7;
  v_7.x = _World2Object[0].x;
  v_7.y = _World2Object[1].x;
  v_7.z = _World2Object[2].x;
  v_7.w = _World2Object[3].x;
  highp vec4 v_8;
  v_8.x = _World2Object[0].y;
  v_8.y = _World2Object[1].y;
  v_8.z = _World2Object[2].y;
  v_8.w = _World2Object[3].y;
  highp vec4 v_9;
  v_9.x = _World2Object[0].z;
  v_9.y = _World2Object[1].z;
  v_9.z = _World2Object[2].z;
  v_9.w = _World2Object[3].z;
  highp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = normalize(((
    (v_7.xyz * _glesNormal.x)
   + 
    (v_8.xyz * _glesNormal.y)
  ) + (v_9.xyz * _glesNormal.z)));
  mediump vec3 tmpvar_11;
  mediump vec4 normal_12;
  normal_12 = tmpvar_10;
  mediump vec3 x2_13;
  mediump vec3 x1_14;
  x1_14.x = dot (unity_SHAr, normal_12);
  x1_14.y = dot (unity_SHAg, normal_12);
  x1_14.z = dot (unity_SHAb, normal_12);
  mediump vec4 tmpvar_15;
  tmpvar_15 = (normal_12.xyzz * normal_12.yzzx);
  x2_13.x = dot (unity_SHBr, tmpvar_15);
  x2_13.y = dot (unity_SHBg, tmpvar_15);
  x2_13.z = dot (unity_SHBb, tmpvar_15);
  tmpvar_11 = ((x2_13 + (unity_SHC.xyz * 
    ((normal_12.x * normal_12.x) - (normal_12.y * normal_12.y))
  )) + x1_14);
  tmpvar_2 = tmpvar_11;
  gl_Position = tmpvar_3;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
  xlv_TEXCOORD2 = o_4;
  xlv_TEXCOORD3 = tmpvar_1;
  xlv_TEXCOORD4 = tmpvar_2;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _XYSMap;
uniform sampler2D _LightBuffer;
in highp vec2 xlv_TEXCOORD0;
in highp vec4 xlv_TEXCOORD2;
in highp vec3 xlv_TEXCOORD4;
void main ()
{
  lowp vec4 tmpvar_1;
  mediump vec4 c_2;
  mediump vec4 light_3;
  lowp vec4 tmpvar_4;
  tmpvar_4 = texture (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_5;
  tmpvar_5.x = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.y = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.z = (tmpvar_4.y - tmpvar_4.z);
  lowp vec4 tmpvar_6;
  tmpvar_6 = textureProj (_LightBuffer, xlv_TEXCOORD2);
  light_3 = tmpvar_6;
  mediump vec4 tmpvar_7;
  tmpvar_7 = max (light_3, vec4(0.001, 0.001, 0.001, 0.001));
  light_3.w = tmpvar_7.w;
  highp vec3 tmpvar_8;
  tmpvar_8 = (tmpvar_7.xyz + xlv_TEXCOORD4);
  light_3.xyz = tmpvar_8;
  lowp vec4 c_9;
  c_9.xyz = vec3(0.0, 0.0, 0.0);
  c_9.w = 1.0;
  c_2 = c_9;
  c_2.xyz = (c_2.xyz + tmpvar_5);
  c_2.w = 1.0;
  tmpvar_1 = c_2;
  _glesFragData[0] = tmpvar_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 29 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
Bind ""texcoord"" ATTR2
ConstBuffer ""$Globals"" 288
Matrix 80 [glstate_matrix_mvp]
Matrix 144 [_Object2World]
Matrix 208 [_World2Object]
Vector 0 [_ProjectionParams]
VectorHalf 16 [unity_SHAr] 4
VectorHalf 24 [unity_SHAg] 4
VectorHalf 32 [unity_SHAb] 4
VectorHalf 40 [unity_SHBr] 4
VectorHalf 48 [unity_SHBg] 4
VectorHalf 56 [unity_SHBb] 4
VectorHalf 64 [unity_SHC] 4
Vector 272 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
  float4 _glesMultiTexCoord0 [[attribute(2)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  float2 xlv_TEXCOORD0;
  float3 xlv_TEXCOORD1;
  float4 xlv_TEXCOORD2;
  float4 xlv_TEXCOORD3;
  float3 xlv_TEXCOORD4;
};
struct xlatMtlShaderUniform {
  float4 _ProjectionParams;
  half4 unity_SHAr;
  half4 unity_SHAg;
  half4 unity_SHAb;
  half4 unity_SHBr;
  half4 unity_SHBg;
  half4 unity_SHBb;
  half4 unity_SHC;
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  float4 tmpvar_1;
  float3 tmpvar_2;
  float4 tmpvar_3;
  tmpvar_3 = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  float4 o_4;
  float4 tmpvar_5;
  tmpvar_5 = (tmpvar_3 * 0.5);
  float2 tmpvar_6;
  tmpvar_6.x = tmpvar_5.x;
  tmpvar_6.y = (tmpvar_5.y * _mtl_u._ProjectionParams.x);
  o_4.xy = (tmpvar_6 + tmpvar_5.w);
  o_4.zw = tmpvar_3.zw;
  tmpvar_1.zw = float2(0.0, 0.0);
  tmpvar_1.xy = float2(0.0, 0.0);
  float4 v_7;
  v_7.x = _mtl_u._World2Object[0].x;
  v_7.y = _mtl_u._World2Object[1].x;
  v_7.z = _mtl_u._World2Object[2].x;
  v_7.w = _mtl_u._World2Object[3].x;
  float4 v_8;
  v_8.x = _mtl_u._World2Object[0].y;
  v_8.y = _mtl_u._World2Object[1].y;
  v_8.z = _mtl_u._World2Object[2].y;
  v_8.w = _mtl_u._World2Object[3].y;
  float4 v_9;
  v_9.x = _mtl_u._World2Object[0].z;
  v_9.y = _mtl_u._World2Object[1].z;
  v_9.z = _mtl_u._World2Object[2].z;
  v_9.w = _mtl_u._World2Object[3].z;
  float4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = normalize(((
    (v_7.xyz * _mtl_i._glesNormal.x)
   + 
    (v_8.xyz * _mtl_i._glesNormal.y)
  ) + (v_9.xyz * _mtl_i._glesNormal.z)));
  half3 tmpvar_11;
  half4 normal_12;
  normal_12 = half4(tmpvar_10);
  half3 x2_13;
  half3 x1_14;
  x1_14.x = dot (_mtl_u.unity_SHAr, normal_12);
  x1_14.y = dot (_mtl_u.unity_SHAg, normal_12);
  x1_14.z = dot (_mtl_u.unity_SHAb, normal_12);
  half4 tmpvar_15;
  tmpvar_15 = (normal_12.xyzz * normal_12.yzzx);
  x2_13.x = dot (_mtl_u.unity_SHBr, tmpvar_15);
  x2_13.y = dot (_mtl_u.unity_SHBg, tmpvar_15);
  x2_13.z = dot (_mtl_u.unity_SHBb, tmpvar_15);
  tmpvar_11 = ((x2_13 + (_mtl_u.unity_SHC.xyz * 
    ((normal_12.x * normal_12.x) - (normal_12.y * normal_12.y))
  )) + x1_14);
  tmpvar_2 = float3(tmpvar_11);
  _mtl_o.gl_Position = tmpvar_3;
  _mtl_o.xlv_TEXCOORD0 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  _mtl_o.xlv_TEXCOORD1 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  _mtl_o.xlv_TEXCOORD2 = o_4;
  _mtl_o.xlv_TEXCOORD3 = tmpvar_1;
  _mtl_o.xlv_TEXCOORD4 = tmpvar_2;
  return _mtl_o;
}

""
}
}
Program ""fp"" {
SubProgram ""opengl "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 3 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_2_0
def c0, 1, 0, 0, 0
dcl t0.xy
dcl_2d s0
texld_pp r0, t0, s0
add_pp r0.xyz, -r0.z, r0.y
mov_pp r0.w, c0.x
mov_pp oC0, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 1 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0
eefiecedoembbkbdgmmpekbpimhkpddomfikdenhabaaaaaamaabaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefckaaaaaaa
eaaaaaaaciaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
abaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaaaaaaaaaihccabaaaaaaaaaaakgakbaiaebaaaaaaaaaaaaaa
fgafbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab
""
}
SubProgram ""gles "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
// Stats: 1 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0_level_9_1
eefiecedcdhjekjackacdgbpdoaeebfjjfigolfjabaaaaaageacaaaaaeaaaaaa
daaaaaaanaaaaaaahiabaaaadaacaaaaebgpgodjjiaaaaaajiaaaaaaaaacpppp
haaaaaaaciaaaaaaaaaaciaaaaaaciaaaaaaciaaabaaceaaaaaaciaaaaaaaaaa
aaacppppfbaaaaafaaaaapkaaaaaiadpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaac
aaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapkaecaaaaadaaaacpiaaaaaoela
aaaioekaacaaaaadaaaachiaaaaakkibaaaaffiaabaaaaacaaaaciiaaaaaaaka
abaaaaacaaaicpiaaaaaoeiappppaaaafdeieefckaaaaaaaeaaaaaaaciaaaaaa
fkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacabaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
aaaaaaaihccabaaaaaaaaaaakgakbaiaebaaaaaaaaaaaaaafgafbaaaaaaaaaaa
dgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaabejfdeheolaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
keaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapaaaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaa
keaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaaaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl""
}
SubProgram ""gles3 "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 11 math, 2 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float2 xlv_TEXCOORD0;
  float4 xlv_TEXCOORD2;
  float3 xlv_TEXCOORD4;
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]]
  ,   texture2d<half> _XYSMap [[texture(0)]], sampler _mtlsmp__XYSMap [[sampler(0)]]
  ,   texture2d<half> _LightBuffer [[texture(1)]], sampler _mtlsmp__LightBuffer [[sampler(1)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 tmpvar_1;
  half4 c_2;
  half4 light_3;
  half4 tmpvar_4;
  tmpvar_4 = _XYSMap.sample(_mtlsmp__XYSMap, (float2)(_mtl_i.xlv_TEXCOORD0));
  half3 tmpvar_5;
  tmpvar_5.x = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.y = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.z = (tmpvar_4.y - tmpvar_4.z);
  half4 tmpvar_6;
  tmpvar_6 = _LightBuffer.sample(_mtlsmp__LightBuffer, ((float2)(_mtl_i.xlv_TEXCOORD2).xy / (float)(_mtl_i.xlv_TEXCOORD2).w));
  light_3 = tmpvar_6;
  half4 tmpvar_7;
  tmpvar_7 = -(log2(max (light_3, (half4)float4(0.001, 0.001, 0.001, 0.001))));
  light_3.w = tmpvar_7.w;
  float3 tmpvar_8;
  tmpvar_8 = ((float3)tmpvar_7.xyz + _mtl_i.xlv_TEXCOORD4);
  light_3.xyz = half3(tmpvar_8);
  half4 c_9;
  c_9.xyz = half3(float3(0.0, 0.0, 0.0));
  c_9.w = half(1.0);
  c_2 = c_9;
  c_2.xyz = (c_2.xyz + tmpvar_5);
  c_2.w = half(1.0);
  tmpvar_1 = c_2;
  _mtl_o._glesFragData_0 = tmpvar_1;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 3 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_2_0
def c0, 1, 0, 0, 0
dcl t0.xy
dcl_2d s0
texld_pp r0, t0, s0
add_pp r0.xyz, -r0.z, r0.y
mov_pp r0.w, c0.x
mov_pp oC0, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 1 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0
eefiecedoembbkbdgmmpekbpimhkpddomfikdenhabaaaaaamaabaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefckaaaaaaa
eaaaaaaaciaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
abaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaaaaaaaaaihccabaaaaaaaaaaakgakbaiaebaaaaaaaaaaaaaa
fgafbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab
""
}
SubProgram ""gles "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
// Stats: 1 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0_level_9_1
eefiecedcdhjekjackacdgbpdoaeebfjjfigolfjabaaaaaageacaaaaaeaaaaaa
daaaaaaanaaaaaaahiabaaaadaacaaaaebgpgodjjiaaaaaajiaaaaaaaaacpppp
haaaaaaaciaaaaaaaaaaciaaaaaaciaaaaaaciaaabaaceaaaaaaciaaaaaaaaaa
aaacppppfbaaaaafaaaaapkaaaaaiadpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaac
aaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapkaecaaaaadaaaacpiaaaaaoela
aaaioekaacaaaaadaaaachiaaaaakkibaaaaffiaabaaaaacaaaaciiaaaaaaaka
abaaaaacaaaicpiaaaaaoeiappppaaaafdeieefckaaaaaaaeaaaaaaaciaaaaaa
fkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacabaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
aaaaaaaihccabaaaaaaaaaaakgakbaiaebaaaaaaaaaaaaaafgafbaaaaaaaaaaa
dgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaabejfdeheolaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
keaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapaaaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaa
keaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaaaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl""
}
SubProgram ""gles3 "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 9 math, 2 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
SetTexture 0 [_XYSMap] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float2 xlv_TEXCOORD0;
  float4 xlv_TEXCOORD2;
  float3 xlv_TEXCOORD4;
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]]
  ,   texture2d<half> _XYSMap [[texture(0)]], sampler _mtlsmp__XYSMap [[sampler(0)]]
  ,   texture2d<half> _LightBuffer [[texture(1)]], sampler _mtlsmp__LightBuffer [[sampler(1)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 tmpvar_1;
  half4 c_2;
  half4 light_3;
  half4 tmpvar_4;
  tmpvar_4 = _XYSMap.sample(_mtlsmp__XYSMap, (float2)(_mtl_i.xlv_TEXCOORD0));
  half3 tmpvar_5;
  tmpvar_5.x = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.y = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.z = (tmpvar_4.y - tmpvar_4.z);
  half4 tmpvar_6;
  tmpvar_6 = _LightBuffer.sample(_mtlsmp__LightBuffer, ((float2)(_mtl_i.xlv_TEXCOORD2).xy / (float)(_mtl_i.xlv_TEXCOORD2).w));
  light_3 = tmpvar_6;
  half4 tmpvar_7;
  tmpvar_7 = max (light_3, (half4)float4(0.001, 0.001, 0.001, 0.001));
  light_3.w = tmpvar_7.w;
  float3 tmpvar_8;
  tmpvar_8 = ((float3)tmpvar_7.xyz + _mtl_i.xlv_TEXCOORD4);
  light_3.xyz = half3(tmpvar_8);
  half4 c_9;
  c_9.xyz = half3(float3(0.0, 0.0, 0.0));
  c_9.w = half(1.0);
  c_2 = c_9;
  c_2.xyz = (c_2.xyz + tmpvar_5);
  c_2.w = half(1.0);
  tmpvar_1 = c_2;
  _mtl_o._glesFragData_0 = tmpvar_1;
  return _mtl_o;
}

""
}
}
 }


 // Stats for Vertex shader:
 //       d3d11 : 34 math
 //    d3d11_9x : 34 math
 //        d3d9 : 28 math
 //        gles : 12 avg math (11..13), 1 texture
 //       gles3 : 12 avg math (11..13), 1 texture
 //       metal : 26 math
 //      opengl : 11 avg math (10..12), 1 texture
 // Stats for Fragment shader:
 //       d3d11 : 2 avg math (2..3), 1 texture
 //    d3d11_9x : 2 avg math (2..3), 1 texture
 //        d3d9 : 9 avg math (9..10), 1 texture
 //       metal : 12 avg math (11..13), 1 texture
 Pass {
  Name ""DEFERRED""
  Tags { ""LIGHTMODE""=""Deferred"" ""ForceNoShadowCasting""=""true"" ""DisableBatching""=""true"" ""RenderType""=""Opaque"" }
  GpuProgramID 300052
Program ""vp"" {
SubProgram ""opengl "" {
// Stats: 12 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLSL
#ifdef VERTEX
uniform vec4 unity_SHAr;
uniform vec4 unity_SHAg;
uniform vec4 unity_SHAb;
uniform vec4 unity_SHBr;
uniform vec4 unity_SHBg;
uniform vec4 unity_SHBb;
uniform vec4 unity_SHC;

uniform mat4 _Object2World;
uniform mat4 _World2Object;
uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
varying vec3 xlv_TEXCOORD2;
varying vec4 xlv_TEXCOORD4;
varying vec3 xlv_TEXCOORD5;
void main ()
{
  vec4 tmpvar_1;
  vec4 v_2;
  v_2.x = _World2Object[0].x;
  v_2.y = _World2Object[1].x;
  v_2.z = _World2Object[2].x;
  v_2.w = _World2Object[3].x;
  vec4 v_3;
  v_3.x = _World2Object[0].y;
  v_3.y = _World2Object[1].y;
  v_3.z = _World2Object[2].y;
  v_3.w = _World2Object[3].y;
  vec4 v_4;
  v_4.x = _World2Object[0].z;
  v_4.y = _World2Object[1].z;
  v_4.z = _World2Object[2].z;
  v_4.w = _World2Object[3].z;
  vec3 tmpvar_5;
  tmpvar_5 = normalize(((
    (v_2.xyz * gl_Normal.x)
   + 
    (v_3.xyz * gl_Normal.y)
  ) + (v_4.xyz * gl_Normal.z)));
  tmpvar_1.zw = vec2(0.0, 0.0);
  tmpvar_1.xy = vec2(0.0, 0.0);
  vec4 tmpvar_6;
  tmpvar_6.w = 1.0;
  tmpvar_6.xyz = tmpvar_5;
  vec3 x2_7;
  vec3 x1_8;
  x1_8.x = dot (unity_SHAr, tmpvar_6);
  x1_8.y = dot (unity_SHAg, tmpvar_6);
  x1_8.z = dot (unity_SHAb, tmpvar_6);
  vec4 tmpvar_9;
  tmpvar_9 = (tmpvar_5.xyzz * tmpvar_5.yzzx);
  x2_7.x = dot (unity_SHBr, tmpvar_9);
  x2_7.y = dot (unity_SHBg, tmpvar_9);
  x2_7.z = dot (unity_SHBb, tmpvar_9);
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_5;
  xlv_TEXCOORD2 = (_Object2World * gl_Vertex).xyz;
  xlv_TEXCOORD4 = tmpvar_1;
  xlv_TEXCOORD5 = ((x2_7 + (unity_SHC.xyz * 
    ((tmpvar_5.x * tmpvar_5.x) - (tmpvar_5.y * tmpvar_5.y))
  )) + x1_8);
}


#endif
#ifdef FRAGMENT
uniform sampler2D _XYSMap;
varying vec2 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
void main ()
{
  vec4 outDiffuse_1;
  vec4 outEmission_2;
  vec4 tmpvar_3;
  tmpvar_3 = texture2D (_XYSMap, xlv_TEXCOORD0);
  vec3 tmpvar_4;
  tmpvar_4.x = (tmpvar_3.y - tmpvar_3.z);
  tmpvar_4.y = (tmpvar_3.y - tmpvar_3.z);
  tmpvar_4.z = (tmpvar_3.y - tmpvar_3.z);
  vec4 emission_5;
  vec4 tmpvar_6;
  tmpvar_6.w = 1.0;
  tmpvar_6.xyz = ((xlv_TEXCOORD1 * 0.5) + 0.5);
  vec4 tmpvar_7;
  tmpvar_7.w = 1.0;
  tmpvar_7.xyz = tmpvar_4;
  emission_5.w = tmpvar_7.w;
  emission_5.xyz = tmpvar_4;
  outDiffuse_1.xyz = vec3(0.0, 0.0, 0.0);
  outEmission_2.w = emission_5.w;
  outDiffuse_1.w = 1.0;
  outEmission_2.xyz = exp2(-(tmpvar_4));
  gl_FragData[0] = outDiffuse_1;
  gl_FragData[1] = vec4(0.0, 0.0, 0.0, 0.0);
  gl_FragData[2] = tmpvar_6;
  gl_FragData[3] = outEmission_2;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 28 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
Vector 17 [_MainTex_ST]
Vector 12 [unity_SHAb]
Vector 11 [unity_SHAg]
Vector 10 [unity_SHAr]
Vector 15 [unity_SHBb]
Vector 14 [unity_SHBg]
Vector 13 [unity_SHBr]
Vector 16 [unity_SHC]
""vs_2_0
def c18, 1, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord v2
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
mad oT0.xy, v2, c17, c17.zwzw
dp4 oT2.x, c4, v0
dp4 oT2.y, c5, v0
dp4 oT2.z, c6, v0
mul r0.xyz, v1.y, c8
mad r0.xyz, c7, v1.x, r0
mad r0.xyz, c9, v1.z, r0
nrm r1.xyz, r0
mul r0.x, r1.y, r1.y
mad r0.x, r1.x, r1.x, -r0.x
mul r2, r1.yzzx, r1.xyzz
dp4 r3.x, c13, r2
dp4 r3.y, c14, r2
dp4 r3.z, c15, r2
mad r0.xyz, c16, r0.x, r3
mov r1.w, c18.x
dp4 r2.x, c10, r1
dp4 r2.y, c11, r1
dp4 r2.z, c12, r1
mov oT1.xyz, r1
add oT5.xyz, r0, r2
mov oT4, c18.y

""
}
SubProgram ""d3d11 "" {
// Stats: 34 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 176
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityLighting"" 1
BindCB  ""UnityPerDraw"" 2
""vs_4_0
eefiecedkmekdkdnlnoileefpmkfciobknnolkmfabaaaaaaeeahaaaaadaaaaaa
cmaaaaaaceabaaaanmabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapaaaaaakeaaaaaaafaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
gaafaaaaeaaaabaafiabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaae
egiocaaaabaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
hccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaaibcaabaaa
aaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaa
aaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaa
aaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabcaaaaaadiaaaaaibcaabaaa
abaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaa
abaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaa
abaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaa
ckbabaaaacaaaaaackiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
ckbabaaaacaaaaaackiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
ckbabaaaacaaaaaackiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaaf
hccabaaaacaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaa
aaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaa
acaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaakhccabaaaadaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaabaaaaaadgaaaaaipccabaaaaeaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaaaaaaaaaabkaabaaa
aaaaaaaadcaaaaakbcaabaaaabaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaa
akaabaiaebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaa
egakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaa
egaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaa
egaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaa
egaobaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaacmaaaaaa
agaabaaaabaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaa
aaaaiadpbbaaaaaibcaabaaaacaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaa
aaaaaaaabbaaaaaiccaabaaaacaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaa
aaaaaaaabbaaaaaiecaabaaaacaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaa
aaaaaaaaaaaaaaahhccabaaaafaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaa
doaaaaab""
}
SubProgram ""gles "" {
// Stats: 13 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying mediump vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD4;
varying mediump vec3 xlv_TEXCOORD5;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 tmpvar_3;
  highp vec4 v_4;
  v_4.x = _World2Object[0].x;
  v_4.y = _World2Object[1].x;
  v_4.z = _World2Object[2].x;
  v_4.w = _World2Object[3].x;
  highp vec4 v_5;
  v_5.x = _World2Object[0].y;
  v_5.y = _World2Object[1].y;
  v_5.z = _World2Object[2].y;
  v_5.w = _World2Object[3].y;
  highp vec4 v_6;
  v_6.x = _World2Object[0].z;
  v_6.y = _World2Object[1].z;
  v_6.z = _World2Object[2].z;
  v_6.w = _World2Object[3].z;
  highp vec3 tmpvar_7;
  tmpvar_7 = normalize(((
    (v_4.xyz * _glesNormal.x)
   + 
    (v_5.xyz * _glesNormal.y)
  ) + (v_6.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_7;
  tmpvar_2 = worldNormal_1;
  tmpvar_3.zw = vec2(0.0, 0.0);
  tmpvar_3.xy = vec2(0.0, 0.0);
  lowp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = worldNormal_1;
  mediump vec4 normal_9;
  normal_9 = tmpvar_8;
  mediump vec3 x2_10;
  mediump vec3 x1_11;
  x1_11.x = dot (unity_SHAr, normal_9);
  x1_11.y = dot (unity_SHAg, normal_9);
  x1_11.z = dot (unity_SHAb, normal_9);
  mediump vec4 tmpvar_12;
  tmpvar_12 = (normal_9.xyzz * normal_9.yzzx);
  x2_10.x = dot (unity_SHBr, tmpvar_12);
  x2_10.y = dot (unity_SHBg, tmpvar_12);
  x2_10.z = dot (unity_SHBb, tmpvar_12);
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = (_Object2World * _glesVertex).xyz;
  xlv_TEXCOORD4 = tmpvar_3;
  xlv_TEXCOORD5 = ((x2_10 + (unity_SHC.xyz * 
    ((normal_9.x * normal_9.x) - (normal_9.y * normal_9.y))
  )) + x1_11);
}



#endif
#ifdef FRAGMENT

#extension GL_EXT_draw_buffers : require
uniform sampler2D _XYSMap;
varying highp vec2 xlv_TEXCOORD0;
varying mediump vec3 xlv_TEXCOORD1;
void main ()
{
  mediump vec4 outDiffuse_1;
  mediump vec4 outEmission_2;
  lowp vec3 tmpvar_3;
  tmpvar_3 = xlv_TEXCOORD1;
  lowp vec4 tmpvar_4;
  tmpvar_4 = texture2D (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_5;
  tmpvar_5.x = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.y = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.z = (tmpvar_4.y - tmpvar_4.z);
  mediump vec4 outDiffuseOcclusion_6;
  mediump vec4 outNormal_7;
  mediump vec4 emission_8;
  lowp vec4 tmpvar_9;
  tmpvar_9.w = 1.0;
  tmpvar_9.xyz = vec3(0.0, 0.0, 0.0);
  outDiffuseOcclusion_6 = tmpvar_9;
  lowp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = ((tmpvar_3 * 0.5) + 0.5);
  outNormal_7 = tmpvar_10;
  lowp vec4 tmpvar_11;
  tmpvar_11.w = 1.0;
  tmpvar_11.xyz = tmpvar_5;
  emission_8 = tmpvar_11;
  emission_8.xyz = emission_8.xyz;
  outDiffuse_1.xyz = outDiffuseOcclusion_6.xyz;
  outEmission_2.w = emission_8.w;
  outDiffuse_1.w = 1.0;
  outEmission_2.xyz = exp2(-(emission_8.xyz));
  gl_FragData[0] = outDiffuse_1;
  gl_FragData[1] = vec4(0.0, 0.0, 0.0, 0.0);
  gl_FragData[2] = outNormal_7;
  gl_FragData[3] = outEmission_2;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 34 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 176
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityLighting"" 1
BindCB  ""UnityPerDraw"" 2
""vs_4_0_level_9_1
eefiecedcncjcibdbckmeihmjeoaadaefdjljinjabaaaaaafaakaaaaaeaaaaaa
daaaaaaadiadaaaakaaiaaaajiajaaaaebgpgodjaaadaaaaaaadaaaaaaacpopp
kiacaaaafiaaaaaaaeaaceaaaaaafeaaaaaafeaaaaaaceaaabaafeaaaaaaajaa
abaaabaaaaaaaaaaabaacgaaahaaacaaaaaaaaaaacaaaaaaaeaaajaaaaaaaaaa
acaaamaaahaaanaaaaaaaaaaaaaaaaaaaaacpoppfbaaaaafbeaaapkaaaaaiadp
aaaaaaaaaaaaaaaaaaaaaaaabpaaaaacafaaaaiaaaaaapjabpaaaaacafaaacia
acaaapjabpaaaaacafaaadiaadaaapjaaeaaaaaeaaaaadoaadaaoejaabaaoeka
abaaookaafaaaaadaaaaahiaaaaaffjaaoaaoekaaeaaaaaeaaaaahiaanaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaahiaapaaoekaaaaakkjaaaaaoeiaaeaaaaae
acaaahoabaaaoekaaaaappjaaaaaoeiaafaaaaadaaaaabiaacaaaajabbaaaaka
afaaaaadaaaaaciaacaaaajabcaaaakaafaaaaadaaaaaeiaacaaaajabdaaaaka
afaaaaadabaaabiaacaaffjabbaaffkaafaaaaadabaaaciaacaaffjabcaaffka
afaaaaadabaaaeiaacaaffjabdaaffkaacaaaaadaaaaahiaaaaaoeiaabaaoeia
afaaaaadabaaabiaacaakkjabbaakkkaafaaaaadabaaaciaacaakkjabcaakkka
afaaaaadabaaaeiaacaakkjabdaakkkaacaaaaadaaaaahiaaaaaoeiaabaaoeia
ceaaaaacabaaahiaaaaaoeiaafaaaaadaaaaabiaabaaffiaabaaffiaaeaaaaae
aaaaabiaabaaaaiaabaaaaiaaaaaaaibafaaaaadacaaapiaabaacjiaabaakeia
ajaaaaadadaaabiaafaaoekaacaaoeiaajaaaaadadaaaciaagaaoekaacaaoeia
ajaaaaadadaaaeiaahaaoekaacaaoeiaaeaaaaaeaaaaahiaaiaaoekaaaaaaaia
adaaoeiaabaaaaacabaaaiiabeaaaakaajaaaaadacaaabiaacaaoekaabaaoeia
ajaaaaadacaaaciaadaaoekaabaaoeiaajaaaaadacaaaeiaaeaaoekaabaaoeia
abaaaaacabaaahoaabaaoeiaacaaaaadaeaaahoaaaaaoeiaacaaoeiaafaaaaad
aaaaapiaaaaaffjaakaaoekaaeaaaaaeaaaaapiaajaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaalaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaamaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiaabaaaaacadaaapoabeaaffkappppaaaafdeieefcgaafaaaa
eaaaabaafiabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaa
abaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaafhccabaaa
acaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaaaaaaaaaa
egiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaa
amaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hccabaaaadaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaa
abaaaaaadgaaaaaipccabaaaaeaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaa
dcaaaaakbcaabaaaabaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaia
ebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaa
aaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaa
acaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaa
acaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaa
acaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaacmaaaaaaagaabaaa
abaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadp
bbaaaaaibcaabaaaacaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaa
bbaaaaaiccaabaaaacaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaa
bbaaaaaiecaabaaaacaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaa
aaaaaaahhccabaaaafaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaadoaaaaab
ejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
njaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaaoaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaaabaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
oaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaaapaaaaaaojaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofe
aaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
keaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaa
keaaaaaaafaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 13 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out mediump vec3 xlv_TEXCOORD1;
out highp vec3 xlv_TEXCOORD2;
out highp vec4 xlv_TEXCOORD4;
out mediump vec3 xlv_TEXCOORD5;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 tmpvar_3;
  highp vec4 v_4;
  v_4.x = _World2Object[0].x;
  v_4.y = _World2Object[1].x;
  v_4.z = _World2Object[2].x;
  v_4.w = _World2Object[3].x;
  highp vec4 v_5;
  v_5.x = _World2Object[0].y;
  v_5.y = _World2Object[1].y;
  v_5.z = _World2Object[2].y;
  v_5.w = _World2Object[3].y;
  highp vec4 v_6;
  v_6.x = _World2Object[0].z;
  v_6.y = _World2Object[1].z;
  v_6.z = _World2Object[2].z;
  v_6.w = _World2Object[3].z;
  highp vec3 tmpvar_7;
  tmpvar_7 = normalize(((
    (v_4.xyz * _glesNormal.x)
   + 
    (v_5.xyz * _glesNormal.y)
  ) + (v_6.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_7;
  tmpvar_2 = worldNormal_1;
  tmpvar_3.zw = vec2(0.0, 0.0);
  tmpvar_3.xy = vec2(0.0, 0.0);
  lowp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = worldNormal_1;
  mediump vec4 normal_9;
  normal_9 = tmpvar_8;
  mediump vec3 x2_10;
  mediump vec3 x1_11;
  x1_11.x = dot (unity_SHAr, normal_9);
  x1_11.y = dot (unity_SHAg, normal_9);
  x1_11.z = dot (unity_SHAb, normal_9);
  mediump vec4 tmpvar_12;
  tmpvar_12 = (normal_9.xyzz * normal_9.yzzx);
  x2_10.x = dot (unity_SHBr, tmpvar_12);
  x2_10.y = dot (unity_SHBg, tmpvar_12);
  x2_10.z = dot (unity_SHBb, tmpvar_12);
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = (_Object2World * _glesVertex).xyz;
  xlv_TEXCOORD4 = tmpvar_3;
  xlv_TEXCOORD5 = ((x2_10 + (unity_SHC.xyz * 
    ((normal_9.x * normal_9.x) - (normal_9.y * normal_9.y))
  )) + x1_11);
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _XYSMap;
in highp vec2 xlv_TEXCOORD0;
in mediump vec3 xlv_TEXCOORD1;
void main ()
{
  mediump vec4 outDiffuse_1;
  mediump vec4 outEmission_2;
  lowp vec3 tmpvar_3;
  tmpvar_3 = xlv_TEXCOORD1;
  lowp vec4 tmpvar_4;
  tmpvar_4 = texture (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_5;
  tmpvar_5.x = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.y = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.z = (tmpvar_4.y - tmpvar_4.z);
  mediump vec4 outDiffuseOcclusion_6;
  mediump vec4 outNormal_7;
  mediump vec4 emission_8;
  lowp vec4 tmpvar_9;
  tmpvar_9.w = 1.0;
  tmpvar_9.xyz = vec3(0.0, 0.0, 0.0);
  outDiffuseOcclusion_6 = tmpvar_9;
  lowp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = ((tmpvar_3 * 0.5) + 0.5);
  outNormal_7 = tmpvar_10;
  lowp vec4 tmpvar_11;
  tmpvar_11.w = 1.0;
  tmpvar_11.xyz = tmpvar_5;
  emission_8 = tmpvar_11;
  emission_8.xyz = emission_8.xyz;
  outDiffuse_1.xyz = outDiffuseOcclusion_6.xyz;
  outEmission_2.w = emission_8.w;
  outDiffuse_1.w = 1.0;
  outEmission_2.xyz = exp2(-(emission_8.xyz));
  _glesFragData[0] = outDiffuse_1;
  _glesFragData[1] = vec4(0.0, 0.0, 0.0, 0.0);
  _glesFragData[2] = outNormal_7;
  _glesFragData[3] = outEmission_2;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 26 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
Bind ""texcoord"" ATTR2
ConstBuffer ""$Globals"" 272
Matrix 64 [glstate_matrix_mvp]
Matrix 128 [_Object2World]
Matrix 192 [_World2Object]
VectorHalf 0 [unity_SHAr] 4
VectorHalf 8 [unity_SHAg] 4
VectorHalf 16 [unity_SHAb] 4
VectorHalf 24 [unity_SHBr] 4
VectorHalf 32 [unity_SHBg] 4
VectorHalf 40 [unity_SHBb] 4
VectorHalf 48 [unity_SHC] 4
Vector 256 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
  float4 _glesMultiTexCoord0 [[attribute(2)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  float2 xlv_TEXCOORD0;
  half3 xlv_TEXCOORD1;
  float3 xlv_TEXCOORD2;
  float4 xlv_TEXCOORD4;
  half3 xlv_TEXCOORD5;
};
struct xlatMtlShaderUniform {
  half4 unity_SHAr;
  half4 unity_SHAg;
  half4 unity_SHAb;
  half4 unity_SHBr;
  half4 unity_SHBg;
  half4 unity_SHBb;
  half4 unity_SHC;
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  float4 tmpvar_3;
  float4 v_4;
  v_4.x = _mtl_u._World2Object[0].x;
  v_4.y = _mtl_u._World2Object[1].x;
  v_4.z = _mtl_u._World2Object[2].x;
  v_4.w = _mtl_u._World2Object[3].x;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].y;
  v_5.y = _mtl_u._World2Object[1].y;
  v_5.z = _mtl_u._World2Object[2].y;
  v_5.w = _mtl_u._World2Object[3].y;
  float4 v_6;
  v_6.x = _mtl_u._World2Object[0].z;
  v_6.y = _mtl_u._World2Object[1].z;
  v_6.z = _mtl_u._World2Object[2].z;
  v_6.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_7;
  tmpvar_7 = normalize(((
    (v_4.xyz * _mtl_i._glesNormal.x)
   + 
    (v_5.xyz * _mtl_i._glesNormal.y)
  ) + (v_6.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_7);
  tmpvar_2 = worldNormal_1;
  tmpvar_3.zw = float2(0.0, 0.0);
  tmpvar_3.xy = float2(0.0, 0.0);
  half4 tmpvar_8;
  tmpvar_8.w = half(1.0);
  tmpvar_8.xyz = worldNormal_1;
  half4 normal_9;
  normal_9 = tmpvar_8;
  half3 x2_10;
  half3 x1_11;
  x1_11.x = dot (_mtl_u.unity_SHAr, normal_9);
  x1_11.y = dot (_mtl_u.unity_SHAg, normal_9);
  x1_11.z = dot (_mtl_u.unity_SHAb, normal_9);
  half4 tmpvar_12;
  tmpvar_12 = (normal_9.xyzz * normal_9.yzzx);
  x2_10.x = dot (_mtl_u.unity_SHBr, tmpvar_12);
  x2_10.y = dot (_mtl_u.unity_SHBg, tmpvar_12);
  x2_10.z = dot (_mtl_u.unity_SHBb, tmpvar_12);
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  _mtl_o.xlv_TEXCOORD1 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD2 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  _mtl_o.xlv_TEXCOORD4 = tmpvar_3;
  _mtl_o.xlv_TEXCOORD5 = ((x2_10 + (_mtl_u.unity_SHC.xyz * 
    ((normal_9.x * normal_9.x) - (normal_9.y * normal_9.y))
  )) + x1_11);
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
// Stats: 10 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLSL
#ifdef VERTEX
uniform vec4 unity_SHAr;
uniform vec4 unity_SHAg;
uniform vec4 unity_SHAb;
uniform vec4 unity_SHBr;
uniform vec4 unity_SHBg;
uniform vec4 unity_SHBb;
uniform vec4 unity_SHC;

uniform mat4 _Object2World;
uniform mat4 _World2Object;
uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
varying vec3 xlv_TEXCOORD2;
varying vec4 xlv_TEXCOORD4;
varying vec3 xlv_TEXCOORD5;
void main ()
{
  vec4 tmpvar_1;
  vec4 v_2;
  v_2.x = _World2Object[0].x;
  v_2.y = _World2Object[1].x;
  v_2.z = _World2Object[2].x;
  v_2.w = _World2Object[3].x;
  vec4 v_3;
  v_3.x = _World2Object[0].y;
  v_3.y = _World2Object[1].y;
  v_3.z = _World2Object[2].y;
  v_3.w = _World2Object[3].y;
  vec4 v_4;
  v_4.x = _World2Object[0].z;
  v_4.y = _World2Object[1].z;
  v_4.z = _World2Object[2].z;
  v_4.w = _World2Object[3].z;
  vec3 tmpvar_5;
  tmpvar_5 = normalize(((
    (v_2.xyz * gl_Normal.x)
   + 
    (v_3.xyz * gl_Normal.y)
  ) + (v_4.xyz * gl_Normal.z)));
  tmpvar_1.zw = vec2(0.0, 0.0);
  tmpvar_1.xy = vec2(0.0, 0.0);
  vec4 tmpvar_6;
  tmpvar_6.w = 1.0;
  tmpvar_6.xyz = tmpvar_5;
  vec3 x2_7;
  vec3 x1_8;
  x1_8.x = dot (unity_SHAr, tmpvar_6);
  x1_8.y = dot (unity_SHAg, tmpvar_6);
  x1_8.z = dot (unity_SHAb, tmpvar_6);
  vec4 tmpvar_9;
  tmpvar_9 = (tmpvar_5.xyzz * tmpvar_5.yzzx);
  x2_7.x = dot (unity_SHBr, tmpvar_9);
  x2_7.y = dot (unity_SHBg, tmpvar_9);
  x2_7.z = dot (unity_SHBb, tmpvar_9);
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_5;
  xlv_TEXCOORD2 = (_Object2World * gl_Vertex).xyz;
  xlv_TEXCOORD4 = tmpvar_1;
  xlv_TEXCOORD5 = ((x2_7 + (unity_SHC.xyz * 
    ((tmpvar_5.x * tmpvar_5.x) - (tmpvar_5.y * tmpvar_5.y))
  )) + x1_8);
}


#endif
#ifdef FRAGMENT
uniform sampler2D _XYSMap;
varying vec2 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
void main ()
{
  vec4 outDiffuse_1;
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  vec4 emission_4;
  vec4 tmpvar_5;
  tmpvar_5.w = 1.0;
  tmpvar_5.xyz = ((xlv_TEXCOORD1 * 0.5) + 0.5);
  vec4 tmpvar_6;
  tmpvar_6.w = 1.0;
  tmpvar_6.xyz = tmpvar_3;
  emission_4.w = tmpvar_6.w;
  emission_4.xyz = tmpvar_3;
  outDiffuse_1.xyz = vec3(0.0, 0.0, 0.0);
  outDiffuse_1.w = 1.0;
  gl_FragData[0] = outDiffuse_1;
  gl_FragData[1] = vec4(0.0, 0.0, 0.0, 0.0);
  gl_FragData[2] = tmpvar_5;
  gl_FragData[3] = emission_4;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 28 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
Vector 17 [_MainTex_ST]
Vector 12 [unity_SHAb]
Vector 11 [unity_SHAg]
Vector 10 [unity_SHAr]
Vector 15 [unity_SHBb]
Vector 14 [unity_SHBg]
Vector 13 [unity_SHBr]
Vector 16 [unity_SHC]
""vs_2_0
def c18, 1, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord v2
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
mad oT0.xy, v2, c17, c17.zwzw
dp4 oT2.x, c4, v0
dp4 oT2.y, c5, v0
dp4 oT2.z, c6, v0
mul r0.xyz, v1.y, c8
mad r0.xyz, c7, v1.x, r0
mad r0.xyz, c9, v1.z, r0
nrm r1.xyz, r0
mul r0.x, r1.y, r1.y
mad r0.x, r1.x, r1.x, -r0.x
mul r2, r1.yzzx, r1.xyzz
dp4 r3.x, c13, r2
dp4 r3.y, c14, r2
dp4 r3.z, c15, r2
mad r0.xyz, c16, r0.x, r3
mov r1.w, c18.x
dp4 r2.x, c10, r1
dp4 r2.y, c11, r1
dp4 r2.z, c12, r1
mov oT1.xyz, r1
add oT5.xyz, r0, r2
mov oT4, c18.y

""
}
SubProgram ""d3d11 "" {
// Stats: 34 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 176
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityLighting"" 1
BindCB  ""UnityPerDraw"" 2
""vs_4_0
eefiecedkmekdkdnlnoileefpmkfciobknnolkmfabaaaaaaeeahaaaaadaaaaaa
cmaaaaaaceabaaaanmabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapaaaaaakeaaaaaaafaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
gaafaaaaeaaaabaafiabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaae
egiocaaaabaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
hccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaaibcaabaaa
aaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaa
aaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaa
aaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabcaaaaaadiaaaaaibcaabaaa
abaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaa
abaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaa
abaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaa
ckbabaaaacaaaaaackiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
ckbabaaaacaaaaaackiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
ckbabaaaacaaaaaackiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaaf
hccabaaaacaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaa
aaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaa
acaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaakhccabaaaadaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaabaaaaaadgaaaaaipccabaaaaeaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaaaaaaaaaabkaabaaa
aaaaaaaadcaaaaakbcaabaaaabaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaa
akaabaiaebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaa
egakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaa
egaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaa
egaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaa
egaobaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaacmaaaaaa
agaabaaaabaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaa
aaaaiadpbbaaaaaibcaabaaaacaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaa
aaaaaaaabbaaaaaiccaabaaaacaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaa
aaaaaaaabbaaaaaiecaabaaaacaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaa
aaaaaaaaaaaaaaahhccabaaaafaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaa
doaaaaab""
}
SubProgram ""gles "" {
// Stats: 11 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying mediump vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD4;
varying mediump vec3 xlv_TEXCOORD5;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 tmpvar_3;
  highp vec4 v_4;
  v_4.x = _World2Object[0].x;
  v_4.y = _World2Object[1].x;
  v_4.z = _World2Object[2].x;
  v_4.w = _World2Object[3].x;
  highp vec4 v_5;
  v_5.x = _World2Object[0].y;
  v_5.y = _World2Object[1].y;
  v_5.z = _World2Object[2].y;
  v_5.w = _World2Object[3].y;
  highp vec4 v_6;
  v_6.x = _World2Object[0].z;
  v_6.y = _World2Object[1].z;
  v_6.z = _World2Object[2].z;
  v_6.w = _World2Object[3].z;
  highp vec3 tmpvar_7;
  tmpvar_7 = normalize(((
    (v_4.xyz * _glesNormal.x)
   + 
    (v_5.xyz * _glesNormal.y)
  ) + (v_6.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_7;
  tmpvar_2 = worldNormal_1;
  tmpvar_3.zw = vec2(0.0, 0.0);
  tmpvar_3.xy = vec2(0.0, 0.0);
  lowp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = worldNormal_1;
  mediump vec4 normal_9;
  normal_9 = tmpvar_8;
  mediump vec3 x2_10;
  mediump vec3 x1_11;
  x1_11.x = dot (unity_SHAr, normal_9);
  x1_11.y = dot (unity_SHAg, normal_9);
  x1_11.z = dot (unity_SHAb, normal_9);
  mediump vec4 tmpvar_12;
  tmpvar_12 = (normal_9.xyzz * normal_9.yzzx);
  x2_10.x = dot (unity_SHBr, tmpvar_12);
  x2_10.y = dot (unity_SHBg, tmpvar_12);
  x2_10.z = dot (unity_SHBb, tmpvar_12);
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = (_Object2World * _glesVertex).xyz;
  xlv_TEXCOORD4 = tmpvar_3;
  xlv_TEXCOORD5 = ((x2_10 + (unity_SHC.xyz * 
    ((normal_9.x * normal_9.x) - (normal_9.y * normal_9.y))
  )) + x1_11);
}



#endif
#ifdef FRAGMENT

#extension GL_EXT_draw_buffers : require
uniform sampler2D _XYSMap;
varying highp vec2 xlv_TEXCOORD0;
varying mediump vec3 xlv_TEXCOORD1;
void main ()
{
  mediump vec4 outDiffuse_1;
  lowp vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp vec4 tmpvar_3;
  tmpvar_3 = texture2D (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_4;
  tmpvar_4.x = (tmpvar_3.y - tmpvar_3.z);
  tmpvar_4.y = (tmpvar_3.y - tmpvar_3.z);
  tmpvar_4.z = (tmpvar_3.y - tmpvar_3.z);
  mediump vec4 outDiffuseOcclusion_5;
  mediump vec4 outNormal_6;
  mediump vec4 emission_7;
  lowp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = vec3(0.0, 0.0, 0.0);
  outDiffuseOcclusion_5 = tmpvar_8;
  lowp vec4 tmpvar_9;
  tmpvar_9.w = 1.0;
  tmpvar_9.xyz = ((tmpvar_2 * 0.5) + 0.5);
  outNormal_6 = tmpvar_9;
  lowp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = tmpvar_4;
  emission_7 = tmpvar_10;
  emission_7.xyz = emission_7.xyz;
  outDiffuse_1.xyz = outDiffuseOcclusion_5.xyz;
  outDiffuse_1.w = 1.0;
  gl_FragData[0] = outDiffuse_1;
  gl_FragData[1] = vec4(0.0, 0.0, 0.0, 0.0);
  gl_FragData[2] = outNormal_6;
  gl_FragData[3] = emission_7;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 34 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 176
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityLighting"" 1
BindCB  ""UnityPerDraw"" 2
""vs_4_0_level_9_1
eefiecedcncjcibdbckmeihmjeoaadaefdjljinjabaaaaaafaakaaaaaeaaaaaa
daaaaaaadiadaaaakaaiaaaajiajaaaaebgpgodjaaadaaaaaaadaaaaaaacpopp
kiacaaaafiaaaaaaaeaaceaaaaaafeaaaaaafeaaaaaaceaaabaafeaaaaaaajaa
abaaabaaaaaaaaaaabaacgaaahaaacaaaaaaaaaaacaaaaaaaeaaajaaaaaaaaaa
acaaamaaahaaanaaaaaaaaaaaaaaaaaaaaacpoppfbaaaaafbeaaapkaaaaaiadp
aaaaaaaaaaaaaaaaaaaaaaaabpaaaaacafaaaaiaaaaaapjabpaaaaacafaaacia
acaaapjabpaaaaacafaaadiaadaaapjaaeaaaaaeaaaaadoaadaaoejaabaaoeka
abaaookaafaaaaadaaaaahiaaaaaffjaaoaaoekaaeaaaaaeaaaaahiaanaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaahiaapaaoekaaaaakkjaaaaaoeiaaeaaaaae
acaaahoabaaaoekaaaaappjaaaaaoeiaafaaaaadaaaaabiaacaaaajabbaaaaka
afaaaaadaaaaaciaacaaaajabcaaaakaafaaaaadaaaaaeiaacaaaajabdaaaaka
afaaaaadabaaabiaacaaffjabbaaffkaafaaaaadabaaaciaacaaffjabcaaffka
afaaaaadabaaaeiaacaaffjabdaaffkaacaaaaadaaaaahiaaaaaoeiaabaaoeia
afaaaaadabaaabiaacaakkjabbaakkkaafaaaaadabaaaciaacaakkjabcaakkka
afaaaaadabaaaeiaacaakkjabdaakkkaacaaaaadaaaaahiaaaaaoeiaabaaoeia
ceaaaaacabaaahiaaaaaoeiaafaaaaadaaaaabiaabaaffiaabaaffiaaeaaaaae
aaaaabiaabaaaaiaabaaaaiaaaaaaaibafaaaaadacaaapiaabaacjiaabaakeia
ajaaaaadadaaabiaafaaoekaacaaoeiaajaaaaadadaaaciaagaaoekaacaaoeia
ajaaaaadadaaaeiaahaaoekaacaaoeiaaeaaaaaeaaaaahiaaiaaoekaaaaaaaia
adaaoeiaabaaaaacabaaaiiabeaaaakaajaaaaadacaaabiaacaaoekaabaaoeia
ajaaaaadacaaaciaadaaoekaabaaoeiaajaaaaadacaaaeiaaeaaoekaabaaoeia
abaaaaacabaaahoaabaaoeiaacaaaaadaeaaahoaaaaaoeiaacaaoeiaafaaaaad
aaaaapiaaaaaffjaakaaoekaaeaaaaaeaaaaapiaajaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaalaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaamaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiaabaaaaacadaaapoabeaaffkappppaaaafdeieefcgaafaaaa
eaaaabaafiabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaa
abaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaafhccabaaa
acaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaaaaaaaaaa
egiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaa
amaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hccabaaaadaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaa
abaaaaaadgaaaaaipccabaaaaeaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaa
dcaaaaakbcaabaaaabaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaia
ebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaa
aaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaa
acaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaa
acaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaa
acaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaacmaaaaaaagaabaaa
abaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadp
bbaaaaaibcaabaaaacaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaa
bbaaaaaiccaabaaaacaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaa
bbaaaaaiecaabaaaacaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaa
aaaaaaahhccabaaaafaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaadoaaaaab
ejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
njaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaaoaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaaabaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
oaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaaapaaaaaaojaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofe
aaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
keaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaa
keaaaaaaafaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 11 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out mediump vec3 xlv_TEXCOORD1;
out highp vec3 xlv_TEXCOORD2;
out highp vec4 xlv_TEXCOORD4;
out mediump vec3 xlv_TEXCOORD5;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 tmpvar_3;
  highp vec4 v_4;
  v_4.x = _World2Object[0].x;
  v_4.y = _World2Object[1].x;
  v_4.z = _World2Object[2].x;
  v_4.w = _World2Object[3].x;
  highp vec4 v_5;
  v_5.x = _World2Object[0].y;
  v_5.y = _World2Object[1].y;
  v_5.z = _World2Object[2].y;
  v_5.w = _World2Object[3].y;
  highp vec4 v_6;
  v_6.x = _World2Object[0].z;
  v_6.y = _World2Object[1].z;
  v_6.z = _World2Object[2].z;
  v_6.w = _World2Object[3].z;
  highp vec3 tmpvar_7;
  tmpvar_7 = normalize(((
    (v_4.xyz * _glesNormal.x)
   + 
    (v_5.xyz * _glesNormal.y)
  ) + (v_6.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_7;
  tmpvar_2 = worldNormal_1;
  tmpvar_3.zw = vec2(0.0, 0.0);
  tmpvar_3.xy = vec2(0.0, 0.0);
  lowp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = worldNormal_1;
  mediump vec4 normal_9;
  normal_9 = tmpvar_8;
  mediump vec3 x2_10;
  mediump vec3 x1_11;
  x1_11.x = dot (unity_SHAr, normal_9);
  x1_11.y = dot (unity_SHAg, normal_9);
  x1_11.z = dot (unity_SHAb, normal_9);
  mediump vec4 tmpvar_12;
  tmpvar_12 = (normal_9.xyzz * normal_9.yzzx);
  x2_10.x = dot (unity_SHBr, tmpvar_12);
  x2_10.y = dot (unity_SHBg, tmpvar_12);
  x2_10.z = dot (unity_SHBb, tmpvar_12);
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = (_Object2World * _glesVertex).xyz;
  xlv_TEXCOORD4 = tmpvar_3;
  xlv_TEXCOORD5 = ((x2_10 + (unity_SHC.xyz * 
    ((normal_9.x * normal_9.x) - (normal_9.y * normal_9.y))
  )) + x1_11);
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _XYSMap;
in highp vec2 xlv_TEXCOORD0;
in mediump vec3 xlv_TEXCOORD1;
void main ()
{
  mediump vec4 outDiffuse_1;
  lowp vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp vec4 tmpvar_3;
  tmpvar_3 = texture (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_4;
  tmpvar_4.x = (tmpvar_3.y - tmpvar_3.z);
  tmpvar_4.y = (tmpvar_3.y - tmpvar_3.z);
  tmpvar_4.z = (tmpvar_3.y - tmpvar_3.z);
  mediump vec4 outDiffuseOcclusion_5;
  mediump vec4 outNormal_6;
  mediump vec4 emission_7;
  lowp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = vec3(0.0, 0.0, 0.0);
  outDiffuseOcclusion_5 = tmpvar_8;
  lowp vec4 tmpvar_9;
  tmpvar_9.w = 1.0;
  tmpvar_9.xyz = ((tmpvar_2 * 0.5) + 0.5);
  outNormal_6 = tmpvar_9;
  lowp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = tmpvar_4;
  emission_7 = tmpvar_10;
  emission_7.xyz = emission_7.xyz;
  outDiffuse_1.xyz = outDiffuseOcclusion_5.xyz;
  outDiffuse_1.w = 1.0;
  _glesFragData[0] = outDiffuse_1;
  _glesFragData[1] = vec4(0.0, 0.0, 0.0, 0.0);
  _glesFragData[2] = outNormal_6;
  _glesFragData[3] = emission_7;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 26 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
Bind ""texcoord"" ATTR2
ConstBuffer ""$Globals"" 272
Matrix 64 [glstate_matrix_mvp]
Matrix 128 [_Object2World]
Matrix 192 [_World2Object]
VectorHalf 0 [unity_SHAr] 4
VectorHalf 8 [unity_SHAg] 4
VectorHalf 16 [unity_SHAb] 4
VectorHalf 24 [unity_SHBr] 4
VectorHalf 32 [unity_SHBg] 4
VectorHalf 40 [unity_SHBb] 4
VectorHalf 48 [unity_SHC] 4
Vector 256 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
  float4 _glesMultiTexCoord0 [[attribute(2)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  float2 xlv_TEXCOORD0;
  half3 xlv_TEXCOORD1;
  float3 xlv_TEXCOORD2;
  float4 xlv_TEXCOORD4;
  half3 xlv_TEXCOORD5;
};
struct xlatMtlShaderUniform {
  half4 unity_SHAr;
  half4 unity_SHAg;
  half4 unity_SHAb;
  half4 unity_SHBr;
  half4 unity_SHBg;
  half4 unity_SHBb;
  half4 unity_SHC;
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  float4 tmpvar_3;
  float4 v_4;
  v_4.x = _mtl_u._World2Object[0].x;
  v_4.y = _mtl_u._World2Object[1].x;
  v_4.z = _mtl_u._World2Object[2].x;
  v_4.w = _mtl_u._World2Object[3].x;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].y;
  v_5.y = _mtl_u._World2Object[1].y;
  v_5.z = _mtl_u._World2Object[2].y;
  v_5.w = _mtl_u._World2Object[3].y;
  float4 v_6;
  v_6.x = _mtl_u._World2Object[0].z;
  v_6.y = _mtl_u._World2Object[1].z;
  v_6.z = _mtl_u._World2Object[2].z;
  v_6.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_7;
  tmpvar_7 = normalize(((
    (v_4.xyz * _mtl_i._glesNormal.x)
   + 
    (v_5.xyz * _mtl_i._glesNormal.y)
  ) + (v_6.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_7);
  tmpvar_2 = worldNormal_1;
  tmpvar_3.zw = float2(0.0, 0.0);
  tmpvar_3.xy = float2(0.0, 0.0);
  half4 tmpvar_8;
  tmpvar_8.w = half(1.0);
  tmpvar_8.xyz = worldNormal_1;
  half4 normal_9;
  normal_9 = tmpvar_8;
  half3 x2_10;
  half3 x1_11;
  x1_11.x = dot (_mtl_u.unity_SHAr, normal_9);
  x1_11.y = dot (_mtl_u.unity_SHAg, normal_9);
  x1_11.z = dot (_mtl_u.unity_SHAb, normal_9);
  half4 tmpvar_12;
  tmpvar_12 = (normal_9.xyzz * normal_9.yzzx);
  x2_10.x = dot (_mtl_u.unity_SHBr, tmpvar_12);
  x2_10.y = dot (_mtl_u.unity_SHBg, tmpvar_12);
  x2_10.z = dot (_mtl_u.unity_SHBb, tmpvar_12);
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  _mtl_o.xlv_TEXCOORD1 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD2 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  _mtl_o.xlv_TEXCOORD4 = tmpvar_3;
  _mtl_o.xlv_TEXCOORD5 = ((x2_10 + (_mtl_u.unity_SHC.xyz * 
    ((normal_9.x * normal_9.x) - (normal_9.y * normal_9.y))
  )) + x1_11);
  return _mtl_o;
}

""
}
}
Program ""fp"" {
SubProgram ""opengl "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 10 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_2_0
def c0, 0, 0, 0, 1
def c1, 0.5, 0, 0, 0
dcl t0.xy
dcl_pp t1.xyz
dcl_2d s0
texld_pp r0, t0, s0
mov_pp oC0, c0
mov_pp r1, c0.x
mov_pp oC1, r1
mad_pp r1.xyz, t1, c1.x, c1.x
mov_pp r1.w, c0.w
mov_pp oC2, r1
add_pp r0.x, -r0.z, r0.y
exp_pp r0.xyz, -r0.x
mov_pp r0.w, c0.w
mov_pp oC3, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 3 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0
eefiecednmoagjgbjohekfmoboaefjeconbpepfkabaaaaaaoaacaaaaadaaaaaa
cmaaaaaaoeaaaaaagaabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaaafaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheoheaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaagiaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
apaaaaaagiaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaagiaaaaaa
adaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefchiabaaaaeaaaaaaafoaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadhcbabaaa
acaaaaaagfaaaaadpccabaaaaaaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
pccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagiaaaaacabaaaaaadgaaaaai
pccabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpdgaaaaai
pccabaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadcaaaaap
hccabaaaacaaaaaaegbcbaaaacaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadp
aaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaaficcabaaa
acaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaaibcaabaaaaaaaaaaackaabaia
ebaaaaaaaaaaaaaabkaabaaaaaaaaaaabjaaaaaghccabaaaadaaaaaaagaabaia
ebaaaaaaaaaaaaaadgaaaaaficcabaaaadaaaaaaabeaaaaaaaaaiadpdoaaaaab
""
}
SubProgram ""gles "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
// Stats: 3 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0_level_9_1
eefiecedncegoipdnbipmokidheeanadahidbaobabaaaaaaaeaeaaaaaeaaaaaa
daaaaaaafaabaaaanaacaaaaiiadaaaaebgpgodjbiabaaaabiabaaaaaaacpppp
paaaaaaaciaaaaaaaaaaciaaaaaaciaaaaaaciaaabaaceaaaaaaciaaaaaaaaaa
aaacppppfbaaaaafaaaaapkaaaaaaaaaaaaaaadpaaaaiadpaaaaaaaafbaaaaaf
abaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpbpaaaaacaaaaaaiaaaaaadla
bpaaaaacaaaaaaiaabaachlabpaaaaacaaaaaajaaaaiapkaecaaaaadaaaacpia
aaaaoelaaaaioekaabaaaaacabaacpiaaaaaaakaabaaaaacabaicpiaabaaoeia
aeaaaaaeabaachiaabaaoelaaaaaffkaaaaaffkaabaaaaacabaaciiaaaaakkka
abaaaaacacaicpiaabaaoeiaacaaaaadaaaacbiaaaaakkibaaaaffiaaoaaaaac
aaaachiaaaaaaaibabaaaaacaaaaciiaaaaakkkaabaaaaacadaicpiaaaaaoeia
abaaaaacaaaicpiaabaaoekappppaaaafdeieefchiabaaaaeaaaaaaafoaaaaaa
fkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagfaaaaadpccabaaaaaaaaaaa
gfaaaaadpccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaa
adaaaaaagiaaaaacabaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaiadpdgaaaaaipccabaaaabaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaadcaaaaaphccabaaaacaaaaaaegbcbaaaacaaaaaa
aceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaaaceaaaaaaaaaaadpaaaaaadp
aaaaaadpaaaaaaaadgaaaaaficcabaaaacaaaaaaabeaaaaaaaaaiadpefaaaaaj
pcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
aaaaaaaibcaabaaaaaaaaaaackaabaiaebaaaaaaaaaaaaaabkaabaaaaaaaaaaa
bjaaaaaghccabaaaadaaaaaaagaabaiaebaaaaaaaaaaaaaadgaaaaaficcabaaa
adaaaaaaabeaaaaaaaaaiadpdoaaaaabejfdeheolaaaaaaaagaaaaaaaiaaaaaa
jiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaahahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaa
keaaaaaaaeaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaaafaaaaaa
aaaaaaaaadaaaaaaafaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklklepfdeheoheaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaagiaaaaaaabaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaagiaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaa
giaaaaaaadaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl""
}
SubProgram ""gles3 "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 13 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float2 xlv_TEXCOORD0;
  half3 xlv_TEXCOORD1;
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
  half4 _glesFragData_1 [[color(1)]];
  half4 _glesFragData_2 [[color(2)]];
  half4 _glesFragData_3 [[color(3)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]]
  ,   texture2d<half> _XYSMap [[texture(0)]], sampler _mtlsmp__XYSMap [[sampler(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 outDiffuse_1;
  half4 outEmission_2;
  half3 tmpvar_3;
  tmpvar_3 = _mtl_i.xlv_TEXCOORD1;
  half4 tmpvar_4;
  tmpvar_4 = _XYSMap.sample(_mtlsmp__XYSMap, (float2)(_mtl_i.xlv_TEXCOORD0));
  half3 tmpvar_5;
  tmpvar_5.x = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.y = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.z = (tmpvar_4.y - tmpvar_4.z);
  half4 outDiffuseOcclusion_6;
  half4 outNormal_7;
  half4 emission_8;
  half4 tmpvar_9;
  tmpvar_9.w = half(1.0);
  tmpvar_9.xyz = half3(float3(0.0, 0.0, 0.0));
  outDiffuseOcclusion_6 = tmpvar_9;
  half4 tmpvar_10;
  tmpvar_10.w = half(1.0);
  tmpvar_10.xyz = ((tmpvar_3 * (half)0.5) + (half)0.5);
  outNormal_7 = tmpvar_10;
  half4 tmpvar_11;
  tmpvar_11.w = half(1.0);
  tmpvar_11.xyz = tmpvar_5;
  emission_8 = tmpvar_11;
  emission_8.xyz = emission_8.xyz;
  outDiffuse_1.xyz = outDiffuseOcclusion_6.xyz;
  outEmission_2.w = emission_8.w;
  outDiffuse_1.w = half(1.0);
  outEmission_2.xyz = exp2(-(emission_8.xyz));
  _mtl_o._glesFragData_0 = outDiffuse_1;
  _mtl_o._glesFragData_1 = half4(float4(0.0, 0.0, 0.0, 0.0));
  _mtl_o._glesFragData_2 = outNormal_7;
  _mtl_o._glesFragData_3 = outEmission_2;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 9 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_2_0
def c0, 0, 0, 0, 1
def c1, 0.5, 0, 0, 0
dcl t0.xy
dcl_pp t1.xyz
dcl_2d s0
texld_pp r0, t0, s0
mov_pp oC0, c0
mov_pp r1, c0.x
mov_pp oC1, r1
mad_pp r1.xyz, t1, c1.x, c1.x
mov_pp r1.w, c0.w
mov_pp oC2, r1
add_pp r0.xyz, -r0.z, r0.y
mov_pp r0.w, c0.w
mov_pp oC3, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 2 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0
eefiecedinmnkindfjbgllkmlecdhlcdfmnfdaeeabaaaaaamiacaaaaadaaaaaa
cmaaaaaaoeaaaaaagaabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaaafaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheoheaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaagiaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
apaaaaaagiaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaagiaaaaaa
adaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefcgaabaaaaeaaaaaaafiaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadhcbabaaa
acaaaaaagfaaaaadpccabaaaaaaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
pccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagiaaaaacabaaaaaadgaaaaai
pccabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpdgaaaaai
pccabaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadcaaaaap
hccabaaaacaaaaaaegbcbaaaacaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadp
aaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaaficcabaaa
acaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaaihccabaaaadaaaaaakgakbaia
ebaaaaaaaaaaaaaafgafbaaaaaaaaaaadgaaaaaficcabaaaadaaaaaaabeaaaaa
aaaaiadpdoaaaaab""
}
SubProgram ""gles "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
// Stats: 2 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0_level_9_1
eefiecedemimnnepoocfpbaakbiekjohhgojioidabaaaaaaoaadaaaaaeaaaaaa
daaaaaaaeeabaaaakmacaaaageadaaaaebgpgodjamabaaaaamabaaaaaaacpppp
oeaaaaaaciaaaaaaaaaaciaaaaaaciaaaaaaciaaabaaceaaaaaaciaaaaaaaaaa
aaacppppfbaaaaafaaaaapkaaaaaaaaaaaaaaadpaaaaiadpaaaaaaaafbaaaaaf
abaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpbpaaaaacaaaaaaiaaaaaadla
bpaaaaacaaaaaaiaabaachlabpaaaaacaaaaaajaaaaiapkaecaaaaadaaaacpia
aaaaoelaaaaioekaabaaaaacabaacpiaaaaaaakaabaaaaacabaicpiaabaaoeia
aeaaaaaeabaachiaabaaoelaaaaaffkaaaaaffkaabaaaaacabaaciiaaaaakkka
abaaaaacacaicpiaabaaoeiaacaaaaadaaaachiaaaaakkibaaaaffiaabaaaaac
aaaaciiaaaaakkkaabaaaaacadaicpiaaaaaoeiaabaaaaacaaaicpiaabaaoeka
ppppaaaafdeieefcgaabaaaaeaaaaaaafiaaaaaafkaaaaadaagabaaaaaaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaad
hcbabaaaacaaaaaagfaaaaadpccabaaaaaaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagiaaaaacabaaaaaa
dgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadp
dgaaaaaipccabaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
dcaaaaaphccabaaaacaaaaaaegbcbaaaacaaaaaaaceaaaaaaaaaaadpaaaaaadp
aaaaaadpaaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaaf
iccabaaaacaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaaaaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaaihccabaaaadaaaaaa
kgakbaiaebaaaaaaaaaaaaaafgafbaaaaaaaaaaadgaaaaaficcabaaaadaaaaaa
abeaaaaaaaaaiadpdoaaaaabejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaaafaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheoheaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaagiaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
apaaaaaagiaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaagiaaaaaa
adaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
""
}
SubProgram ""gles3 "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 11 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
SetTexture 0 [_XYSMap] 2D 0
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float2 xlv_TEXCOORD0;
  half3 xlv_TEXCOORD1;
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
  half4 _glesFragData_1 [[color(1)]];
  half4 _glesFragData_2 [[color(2)]];
  half4 _glesFragData_3 [[color(3)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]]
  ,   texture2d<half> _XYSMap [[texture(0)]], sampler _mtlsmp__XYSMap [[sampler(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 outDiffuse_1;
  half3 tmpvar_2;
  tmpvar_2 = _mtl_i.xlv_TEXCOORD1;
  half4 tmpvar_3;
  tmpvar_3 = _XYSMap.sample(_mtlsmp__XYSMap, (float2)(_mtl_i.xlv_TEXCOORD0));
  half3 tmpvar_4;
  tmpvar_4.x = (tmpvar_3.y - tmpvar_3.z);
  tmpvar_4.y = (tmpvar_3.y - tmpvar_3.z);
  tmpvar_4.z = (tmpvar_3.y - tmpvar_3.z);
  half4 outDiffuseOcclusion_5;
  half4 outNormal_6;
  half4 emission_7;
  half4 tmpvar_8;
  tmpvar_8.w = half(1.0);
  tmpvar_8.xyz = half3(float3(0.0, 0.0, 0.0));
  outDiffuseOcclusion_5 = tmpvar_8;
  half4 tmpvar_9;
  tmpvar_9.w = half(1.0);
  tmpvar_9.xyz = ((tmpvar_2 * (half)0.5) + (half)0.5);
  outNormal_6 = tmpvar_9;
  half4 tmpvar_10;
  tmpvar_10.w = half(1.0);
  tmpvar_10.xyz = tmpvar_4;
  emission_7 = tmpvar_10;
  emission_7.xyz = emission_7.xyz;
  outDiffuse_1.xyz = outDiffuseOcclusion_5.xyz;
  outDiffuse_1.w = half(1.0);
  _mtl_o._glesFragData_0 = outDiffuse_1;
  _mtl_o._glesFragData_1 = half4(float4(0.0, 0.0, 0.0, 0.0));
  _mtl_o._glesFragData_2 = outNormal_6;
  _mtl_o._glesFragData_3 = emission_7;
  return _mtl_o;
}

""
}
}
 }
}
Fallback ""Legacy Shaders/VertexLit""
}";

        public static readonly string glowBlurPP = @"// Compiled shader for all platforms, uncompressed size: 19.9KB

// Skipping shader variants that would not be included into build of current scene.

Shader ""BuildingGlowPostProcess"" {
Properties {
 _MainTex (""Base (RGB)"", 2D) = ""white"" { }
 _BlurDir (""Blur dir"", Vector) = (0,0,0,0)
}
SubShader { 
 LOD 100
 Tags { ""RenderType""=""Opaque"" }


 // Stats for Vertex shader:
 //       d3d11 : 5 math
 //    d3d11_9x : 5 math
 //        d3d9 : 5 math
 //        gles : 33 math, 9 texture
 //       gles3 : 33 math, 9 texture
 //       metal : 3 math
 //      opengl : 33 math, 9 texture
 // Stats for Fragment shader:
 //       d3d11 : 16 math, 9 texture
 //    d3d11_9x : 16 math, 9 texture
 //        d3d9 : 21 math, 9 texture
 //       metal : 33 math, 9 texture
 Pass {
  Tags { ""RenderType""=""Opaque"" }
  GpuProgramID 27092
Program ""vp"" {
SubProgram ""opengl "" {
// Stats: 33 math, 9 textures
""!!GLSL
#ifdef VERTEX

uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
uniform vec2 _BlurDir;
uniform vec2 _MainTex_TexelSize;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  vec4 col_1;
  vec2 tmpvar_2;
  tmpvar_2 = (_BlurDir * _MainTex_TexelSize);
  col_1.xyz = (((
    ((((
      ((texture2D (_MainTex, (xlv_TEXCOORD0 - (4.0 * tmpvar_2))) * 0.05) + (texture2D (_MainTex, (xlv_TEXCOORD0 - (3.0 * tmpvar_2))) * 0.09))
     + 
      (texture2D (_MainTex, (xlv_TEXCOORD0 - (2.0 * tmpvar_2))) * 0.12)
    ) + (texture2D (_MainTex, 
      (xlv_TEXCOORD0 - tmpvar_2)
    ) * 0.15)) + (texture2D (_MainTex, xlv_TEXCOORD0) * 0.16)) + (texture2D (_MainTex, (xlv_TEXCOORD0 + tmpvar_2)) * 0.15))
   + 
    (texture2D (_MainTex, (xlv_TEXCOORD0 + (2.0 * tmpvar_2))) * 0.12)
  ) + (texture2D (_MainTex, 
    (xlv_TEXCOORD0 + (3.0 * tmpvar_2))
  ) * 0.09)) + (texture2D (_MainTex, (xlv_TEXCOORD0 + 
    (4.0 * tmpvar_2)
  )) * 0.05)).xyz;
  col_1.w = 1.0;
  gl_FragData[0] = col_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 5 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_ST]
""vs_2_0
dcl_position v0
dcl_texcoord v1
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
mad oT0.xy, v1, c4, c4.zwzw

""
}
SubProgram ""d3d11 "" {
// Stats: 5 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 144
Vector 112 [_MainTex_ST]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerDraw"" 1
""vs_4_0
eefiecediclbinofmafhnpjgnjjnoeonbagdabifabaaaaaaamacaaaaadaaaaaa
cmaaaaaaiaaaaaaaniaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaa
aaaaaaaaahaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 33 math, 9 textures
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesMultiTexCoord0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp vec4 _MainTex_ST;
varying mediump vec2 xlv_TEXCOORD0;
void main ()
{
  mediump vec2 tmpvar_1;
  highp vec2 tmpvar_2;
  tmpvar_2 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_2;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform highp vec2 _BlurDir;
uniform highp vec2 _MainTex_TexelSize;
varying mediump vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 col_1;
  highp vec2 tmpvar_2;
  tmpvar_2 = (_BlurDir * _MainTex_TexelSize);
  highp vec2 P_3;
  P_3 = (xlv_TEXCOORD0 - (4.0 * tmpvar_2));
  highp vec2 P_4;
  P_4 = (xlv_TEXCOORD0 - (3.0 * tmpvar_2));
  highp vec2 P_5;
  P_5 = (xlv_TEXCOORD0 - (2.0 * tmpvar_2));
  highp vec2 P_6;
  P_6 = (xlv_TEXCOORD0 - tmpvar_2);
  highp vec2 P_7;
  P_7 = (xlv_TEXCOORD0 + tmpvar_2);
  highp vec2 P_8;
  P_8 = (xlv_TEXCOORD0 + (2.0 * tmpvar_2));
  highp vec2 P_9;
  P_9 = (xlv_TEXCOORD0 + (3.0 * tmpvar_2));
  highp vec2 P_10;
  P_10 = (xlv_TEXCOORD0 + (4.0 * tmpvar_2));
  col_1.xyz = (((
    ((((
      ((texture2D (_MainTex, P_3) * 0.05) + (texture2D (_MainTex, P_4) * 0.09))
     + 
      (texture2D (_MainTex, P_5) * 0.12)
    ) + (texture2D (_MainTex, P_6) * 0.15)) + (texture2D (_MainTex, xlv_TEXCOORD0) * 0.16)) + (texture2D (_MainTex, P_7) * 0.15))
   + 
    (texture2D (_MainTex, P_8) * 0.12)
  ) + (texture2D (_MainTex, P_9) * 0.09)) + (texture2D (_MainTex, P_10) * 0.05)).xyz;
  col_1.w = 1.0;
  gl_FragData[0] = col_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 5 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 144
Vector 112 [_MainTex_ST]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerDraw"" 1
""vs_4_0_level_9_1
eefiecedklbaenjdmegagpdkcfpdgcpejoanebigabaaaaaapiacaaaaaeaaaaaa
daaaaaaabiabaaaaemacaaaakaacaaaaebgpgodjoaaaaaaaoaaaaaaaaaacpopp
kaaaaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaahaa
abaaabaaaaaaaaaaabaaaaaaaeaaacaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjaaeaaaaaeaaaaadoaabaaoeja
abaaoekaabaaookaafaaaaadaaaaapiaaaaaffjaadaaoekaaeaaaaaeaaaaapia
acaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaeaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiaafaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaa
aaaaaaaaahaaaaaadoaaaaabejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 33 math, 9 textures
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesMultiTexCoord0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp vec4 _MainTex_ST;
out mediump vec2 xlv_TEXCOORD0;
void main ()
{
  mediump vec2 tmpvar_1;
  highp vec2 tmpvar_2;
  tmpvar_2 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_2;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform highp vec2 _BlurDir;
uniform highp vec2 _MainTex_TexelSize;
in mediump vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 col_1;
  highp vec2 tmpvar_2;
  tmpvar_2 = (_BlurDir * _MainTex_TexelSize);
  highp vec2 P_3;
  P_3 = (xlv_TEXCOORD0 - (4.0 * tmpvar_2));
  highp vec2 P_4;
  P_4 = (xlv_TEXCOORD0 - (3.0 * tmpvar_2));
  highp vec2 P_5;
  P_5 = (xlv_TEXCOORD0 - (2.0 * tmpvar_2));
  highp vec2 P_6;
  P_6 = (xlv_TEXCOORD0 - tmpvar_2);
  highp vec2 P_7;
  P_7 = (xlv_TEXCOORD0 + tmpvar_2);
  highp vec2 P_8;
  P_8 = (xlv_TEXCOORD0 + (2.0 * tmpvar_2));
  highp vec2 P_9;
  P_9 = (xlv_TEXCOORD0 + (3.0 * tmpvar_2));
  highp vec2 P_10;
  P_10 = (xlv_TEXCOORD0 + (4.0 * tmpvar_2));
  col_1.xyz = (((
    ((((
      ((texture (_MainTex, P_3) * 0.05) + (texture (_MainTex, P_4) * 0.09))
     + 
      (texture (_MainTex, P_5) * 0.12)
    ) + (texture (_MainTex, P_6) * 0.15)) + (texture (_MainTex, xlv_TEXCOORD0) * 0.16)) + (texture (_MainTex, P_7) * 0.15))
   + 
    (texture (_MainTex, P_8) * 0.12)
  ) + (texture (_MainTex, P_9) * 0.09)) + (texture (_MainTex, P_10) * 0.05)).xyz;
  col_1.w = 1.0;
  _glesFragData[0] = col_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 3 math
Bind ""vertex"" ATTR0
Bind ""texcoord"" ATTR1
ConstBuffer ""$Globals"" 80
Matrix 0 [glstate_matrix_mvp]
Vector 64 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float4 _glesMultiTexCoord0 [[attribute(1)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  half2 xlv_TEXCOORD0;
};
struct xlatMtlShaderUniform {
  float4x4 glstate_matrix_mvp;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half2 tmpvar_1;
  float2 tmpvar_2;
  tmpvar_2 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  tmpvar_1 = half2(tmpvar_2);
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = tmpvar_1;
  return _mtl_o;
}

""
}
}
Program ""fp"" {
SubProgram ""opengl "" {
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 21 math, 9 textures
Vector 0 [_BlurDir]
Vector 1 [_MainTex_TexelSize]
SetTexture 0 [_MainTex] 2D 0
""ps_2_0
def c2, 4, 3, 0.0900000036, 0.0500000007
def c3, 2, 0.119999997, 0.150000006, 0.159999996
def c4, 1, 0, 0, 0
dcl t0.xy
dcl_2d s0
mov r0.xy, c0
mad r1.xy, r0, -c1, t0
mul r0.zw, r0.wzyx, c1.wzyx
mad r2.xy, r0.wzyx, -c2.y, t0
mad r3.xy, r0.wzyx, -c2.x, t0
mad r4.xy, r0.wzyx, -c3.x, t0
mad r0.xy, r0, c1, t0
mad r5.xy, r0.wzyx, c3.x, t0
mad r6.xy, r0.wzyx, c2.y, t0
mad r7.xy, r0.wzyx, c2.x, t0
texld r1, r1, s0
texld r2, r2, s0
texld r3, r3, s0
texld r4, r4, s0
texld r8, t0, s0
texld r0, r0, s0
texld r5, r5, s0
texld r7, r7, s0
texld r6, r6, s0
mul r2.xyz, r2, c2.z
mad_pp r2.xyz, r3, c2.w, r2
mad_pp r2.xyz, r4, c3.y, r2
mad_pp r1.xyz, r1, c3.z, r2
mad_pp r1.xyz, r8, c3.w, r1
mad_pp r0.xyz, r0, c3.z, r1
mad_pp r0.xyz, r5, c3.y, r0
mad_pp r0.xyz, r6, c2.z, r0
mad_pp r0.xyz, r7, c2.w, r0
mov_pp r0.w, c4.x
mov_pp oC0, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 16 math, 9 textures
SetTexture 0 [_MainTex] 2D 0
ConstBuffer ""$Globals"" 144
Vector 96 [_BlurDir] 2
Vector 128 [_MainTex_TexelSize] 2
BindCB  ""$Globals"" 0
""ps_4_0
eefiecedganimeookoifpialbmmiaacnmgkmbjoiabaaaaaagaafaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefckaaeaaaa
eaaaaaaaciabaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaadiaaaaajdcaabaaaaaaaaaaa
egiacaaaaaaaaaaaagaaaaaaegiacaaaaaaaaaaaaiaaaaaadcaaaaanpcaabaaa
abaaaaaaegaebaiaebaaaaaaaaaaaaaaaceaaaaaaaaaiaeaaaaaiaeaaaaaeaea
aaaaeaeaegbebaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaogakbaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaakhcaabaaaacaaaaaa
egacbaaaacaaaaaaaceaaaaaomfblidnomfblidnomfblidnaaaaaaaadcaaaaam
hcaabaaaabaaaaaaegacbaaaabaaaaaaaceaaaaamnmmemdnmnmmemdnmnmmemdn
aaaaaaaaegacbaaaacaaaaaadcaaaaanmcaabaaaaaaaaaaaagaebaiaebaaaaaa
aaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaeaaaaaaaeaagbebaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadcaaaaamhcaabaaaabaaaaaaegacbaaaacaaaaaaaceaaaaaipmcpfdn
ipmcpfdnipmcpfdnaaaaaaaaegacbaaaabaaaaaadcaaaaammcaabaaaaaaaaaaa
agiecaiaebaaaaaaaaaaaaaaagaaaaaaagiecaaaaaaaaaaaaiaaaaaaagbebaaa
abaaaaaaefaaaaajpcaabaaaacaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadcaaaaamhcaabaaaabaaaaaaegacbaaaacaaaaaaaceaaaaa
jkjjbjdojkjjbjdojkjjbjdoaaaaaaaaegacbaaaabaaaaaaefaaaaajpcaabaaa
acaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaam
hcaabaaaabaaaaaaegacbaaaacaaaaaaaceaaaaaaknhcddoaknhcddoaknhcddo
aaaaaaaaegacbaaaabaaaaaadcaaaaalmcaabaaaaaaaaaaaagiecaaaaaaaaaaa
agaaaaaaagiecaaaaaaaaaaaaiaaaaaaagbebaaaabaaaaaaefaaaaajpcaabaaa
acaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaam
hcaabaaaabaaaaaaegacbaaaacaaaaaaaceaaaaajkjjbjdojkjjbjdojkjjbjdo
aaaaaaaaegacbaaaabaaaaaadcaaaaammcaabaaaaaaaaaaaagaebaaaaaaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaaeaaaaaaaeaagbebaaaabaaaaaadcaaaaam
pcaabaaaacaaaaaaegaebaaaaaaaaaaaaceaaaaaaaaaeaeaaaaaeaeaaaaaiaea
aaaaiaeaegbebaaaabaaaaaaefaaaaajpcaabaaaaaaaaaaaogakbaaaaaaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaamhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaaceaaaaaipmcpfdnipmcpfdnipmcpfdnaaaaaaaaegacbaaaabaaaaaa
efaaaaajpcaabaaaabaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaaefaaaaajpcaabaaaacaaaaaaogakbaaaacaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadcaaaaamhcaabaaaaaaaaaaaegacbaaaabaaaaaaaceaaaaa
omfblidnomfblidnomfblidnaaaaaaaaegacbaaaaaaaaaaadcaaaaamhccabaaa
aaaaaaaaegacbaaaacaaaaaaaceaaaaamnmmemdnmnmmemdnmnmmemdnaaaaaaaa
egacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab
""
}
SubProgram ""gles "" {
""!!GLES""
}
SubProgram ""d3d11_9x "" {
// Stats: 16 math, 9 textures
SetTexture 0 [_MainTex] 2D 0
ConstBuffer ""$Globals"" 144
Vector 96 [_BlurDir] 2
Vector 128 [_MainTex_TexelSize] 2
BindCB  ""$Globals"" 0
""ps_4_0_level_9_1
eefiecednflfphlhpgjmpabffjfdmdcaldgjilmgabaaaaaaciaiaaaaaeaaaaaa
daaaaaaapeacaaaajmahaaaapeahaaaaebgpgodjlmacaaaalmacaaaaaaacpppp
hmacaaaaeaaaaaaaacaaciaaaaaaeaaaaaaaeaaaabaaceaaaaaaeaaaaaaaaaaa
aaaaagaaabaaaaaaaaaaaaaaaaaaaiaaabaaabaaaaaaaaaaaaacppppfbaaaaaf
acaaapkaaaaaiaeaaaaaeaeaomfblidnmnmmemdnfbaaaaafadaaapkaaaaaaaea
ipmcpfdnjkjjbjdoaknhcddofbaaaaafaeaaapkaaaaaiadpaaaaaaaaaaaaaaaa
aaaaaaaabpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapkaabaaaaac
aaaaadiaaaaaoekaaeaaaaaeabaaadiaaaaaoeiaabaaoekbaaaaoelaafaaaaad
aaaaamiaaaaabliaabaablkaaeaaaaaeacaaadiaaaaabliaacaaffkbaaaaoela
aeaaaaaeadaaadiaaaaabliaacaaaakbaaaaoelaaeaaaaaeaeaaadiaaaaablia
adaaaakbaaaaoelaaeaaaaaeaaaaadiaaaaaoeiaabaaoekaaaaaoelaaeaaaaae
afaaadiaaaaabliaadaaaakaaaaaoelaaeaaaaaeagaaadiaaaaabliaacaaffka
aaaaoelaaeaaaaaeahaaadiaaaaabliaacaaaakaaaaaoelaecaaaaadabaaapia
abaaoeiaaaaioekaecaaaaadacaaapiaacaaoeiaaaaioekaecaaaaadadaaapia
adaaoeiaaaaioekaecaaaaadaeaaapiaaeaaoeiaaaaioekaecaaaaadaiaaapia
aaaaoelaaaaioekaecaaaaadaaaaapiaaaaaoeiaaaaioekaecaaaaadafaaapia
afaaoeiaaaaioekaecaaaaadahaaapiaahaaoeiaaaaioekaecaaaaadagaaapia
agaaoeiaaaaioekaafaaaaadacaaahiaacaaoeiaacaakkkaaeaaaaaeacaachia
adaaoeiaacaappkaacaaoeiaaeaaaaaeacaachiaaeaaoeiaadaaffkaacaaoeia
aeaaaaaeabaachiaabaaoeiaadaakkkaacaaoeiaaeaaaaaeabaachiaaiaaoeia
adaappkaabaaoeiaaeaaaaaeaaaachiaaaaaoeiaadaakkkaabaaoeiaaeaaaaae
aaaachiaafaaoeiaadaaffkaaaaaoeiaaeaaaaaeaaaachiaagaaoeiaacaakkka
aaaaoeiaaeaaaaaeaaaachiaahaaoeiaacaappkaaaaaoeiaabaaaaacaaaaciia
aeaaaakaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefckaaeaaaaeaaaaaaa
ciabaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafkaaaaadaagabaaaaaaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacadaaaaaadiaaaaajdcaabaaaaaaaaaaaegiacaaa
aaaaaaaaagaaaaaaegiacaaaaaaaaaaaaiaaaaaadcaaaaanpcaabaaaabaaaaaa
egaebaiaebaaaaaaaaaaaaaaaceaaaaaaaaaiaeaaaaaiaeaaaaaeaeaaaaaeaea
egbebaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaogakbaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaakhcaabaaaacaaaaaaegacbaaa
acaaaaaaaceaaaaaomfblidnomfblidnomfblidnaaaaaaaadcaaaaamhcaabaaa
abaaaaaaegacbaaaabaaaaaaaceaaaaamnmmemdnmnmmemdnmnmmemdnaaaaaaaa
egacbaaaacaaaaaadcaaaaanmcaabaaaaaaaaaaaagaebaiaebaaaaaaaaaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaaeaaaaaaaeaagbebaaaabaaaaaaefaaaaaj
pcaabaaaacaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaamhcaabaaaabaaaaaaegacbaaaacaaaaaaaceaaaaaipmcpfdnipmcpfdn
ipmcpfdnaaaaaaaaegacbaaaabaaaaaadcaaaaammcaabaaaaaaaaaaaagiecaia
ebaaaaaaaaaaaaaaagaaaaaaagiecaaaaaaaaaaaaiaaaaaaagbebaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadcaaaaamhcaabaaaabaaaaaaegacbaaaacaaaaaaaceaaaaajkjjbjdo
jkjjbjdojkjjbjdoaaaaaaaaegacbaaaabaaaaaaefaaaaajpcaabaaaacaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaamhcaabaaa
abaaaaaaegacbaaaacaaaaaaaceaaaaaaknhcddoaknhcddoaknhcddoaaaaaaaa
egacbaaaabaaaaaadcaaaaalmcaabaaaaaaaaaaaagiecaaaaaaaaaaaagaaaaaa
agiecaaaaaaaaaaaaiaaaaaaagbebaaaabaaaaaaefaaaaajpcaabaaaacaaaaaa
ogakbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaamhcaabaaa
abaaaaaaegacbaaaacaaaaaaaceaaaaajkjjbjdojkjjbjdojkjjbjdoaaaaaaaa
egacbaaaabaaaaaadcaaaaammcaabaaaaaaaaaaaagaebaaaaaaaaaaaaceaaaaa
aaaaaaaaaaaaaaaaaaaaaaeaaaaaaaeaagbebaaaabaaaaaadcaaaaampcaabaaa
acaaaaaaegaebaaaaaaaaaaaaceaaaaaaaaaeaeaaaaaeaeaaaaaiaeaaaaaiaea
egbebaaaabaaaaaaefaaaaajpcaabaaaaaaaaaaaogakbaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadcaaaaamhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
aceaaaaaipmcpfdnipmcpfdnipmcpfdnaaaaaaaaegacbaaaabaaaaaaefaaaaaj
pcaabaaaabaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
efaaaaajpcaabaaaacaaaaaaogakbaaaacaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadcaaaaamhcaabaaaaaaaaaaaegacbaaaabaaaaaaaceaaaaaomfblidn
omfblidnomfblidnaaaaaaaaegacbaaaaaaaaaaadcaaaaamhccabaaaaaaaaaaa
egacbaaaacaaaaaaaceaaaaamnmmemdnmnmmemdnmnmmemdnaaaaaaaaegacbaaa
aaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaabejfdeheo
faaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 33 math, 9 textures
SetTexture 0 [_MainTex] 2D 0
ConstBuffer ""$Globals"" 16
Vector 0 [_BlurDir] 2
Vector 8 [_MainTex_TexelSize] 2
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  half2 xlv_TEXCOORD0;
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
  float2 _BlurDir;
  float2 _MainTex_TexelSize;
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]]
  ,   texture2d<half> _MainTex [[texture(0)]], sampler _mtlsmp__MainTex [[sampler(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 col_1;
  float2 tmpvar_2;
  tmpvar_2 = (_mtl_u._BlurDir * _mtl_u._MainTex_TexelSize);
  float2 P_3;
  P_3 = ((float2)_mtl_i.xlv_TEXCOORD0 - (4.0 * tmpvar_2));
  float2 P_4;
  P_4 = ((float2)_mtl_i.xlv_TEXCOORD0 - (3.0 * tmpvar_2));
  float2 P_5;
  P_5 = ((float2)_mtl_i.xlv_TEXCOORD0 - (2.0 * tmpvar_2));
  float2 P_6;
  P_6 = ((float2)_mtl_i.xlv_TEXCOORD0 - tmpvar_2);
  float2 P_7;
  P_7 = ((float2)_mtl_i.xlv_TEXCOORD0 + tmpvar_2);
  float2 P_8;
  P_8 = ((float2)_mtl_i.xlv_TEXCOORD0 + (2.0 * tmpvar_2));
  float2 P_9;
  P_9 = ((float2)_mtl_i.xlv_TEXCOORD0 + (3.0 * tmpvar_2));
  float2 P_10;
  P_10 = ((float2)_mtl_i.xlv_TEXCOORD0 + (4.0 * tmpvar_2));
  col_1.xyz = (((
    ((((
      ((_MainTex.sample(_mtlsmp__MainTex, (float2)(P_3)) * (half)0.05) + (_MainTex.sample(_mtlsmp__MainTex, (float2)(P_4)) * (half)0.09))
     + 
      (_MainTex.sample(_mtlsmp__MainTex, (float2)(P_5)) * (half)0.12)
    ) + (_MainTex.sample(_mtlsmp__MainTex, (float2)(P_6)) * (half)0.15)) + (_MainTex.sample(_mtlsmp__MainTex, (float2)(_mtl_i.xlv_TEXCOORD0)) * (half)0.16)) + (_MainTex.sample(_mtlsmp__MainTex, (float2)(P_7)) * (half)0.15))
   + 
    (_MainTex.sample(_mtlsmp__MainTex, (float2)(P_8)) * (half)0.12)
  ) + (_MainTex.sample(_mtlsmp__MainTex, (float2)(P_9)) * (half)0.09)) + (_MainTex.sample(_mtlsmp__MainTex, (float2)(P_10)) * (half)0.05)).xyz;
  col_1.w = half(1.0);
  _mtl_o._glesFragData_0 = col_1;
  return _mtl_o;
}

""
}
}
 }
}
}";

        public static readonly string buildingsGlowPPv2 = @"// Compiled shader for all platforms, uncompressed size: 12.2KB

// Skipping shader variants that would not be included into build of current scene.

Shader ""BuildingGlowPostProcess"" {
Properties {
 _MainTex (""Base (RGB)"", 2D) = ""white"" { }
 _GlowTex (""Glow"", 2D) = ""white"" { }
 _GlowColor (""Glow color"", Color) = (1,1,0,1)
 _GlowIntensity (""Glow intensity"", Float) = 0
}
SubShader { 
 LOD 100
 Tags { ""RenderType""=""Opaque"" }


 // Stats for Vertex shader:
 //       d3d11 : 5 math
 //    d3d11_9x : 5 math
 //        d3d9 : 5 math
 //        gles : 4 math, 2 texture
 //       gles3 : 4 math, 2 texture
 //       metal : 3 math
 //      opengl : 4 math, 2 texture
 // Stats for Fragment shader:
 //       d3d11 : 2 math, 2 texture
 //    d3d11_9x : 2 math, 2 texture
 //        d3d9 : 4 math, 2 texture
 //       metal : 4 math, 2 texture
 Pass {
  Tags { ""RenderType""=""Opaque"" }
  GpuProgramID 16961
Program ""vp"" {
SubProgram ""opengl "" {
// Stats: 4 math, 2 textures
""!!GLSL
#ifdef VERTEX

uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
uniform sampler2D _GlowTex;
uniform vec4 _GlowColor;
uniform float _GlowIntensity;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  vec4 col_1;
  col_1.xyz = (texture2D (_MainTex, xlv_TEXCOORD0) + ((texture2D (_GlowTex, xlv_TEXCOORD0).x * _GlowColor) * _GlowIntensity)).xyz;
  col_1.w = 1.0;
  gl_FragData[0] = col_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 5 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_ST]
""vs_2_0
dcl_position v0
dcl_texcoord v1
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
mad oT0.xy, v1, c4, c4.zwzw

""
}
SubProgram ""d3d11 "" {
// Stats: 5 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 144
Vector 128 [_MainTex_ST]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerDraw"" 1
""vs_4_0
eefiecedifeefokjmglbfpcohifihgjdikcggpkeabaaaaaaamacaaaaadaaaaaa
cmaaaaaaiaaaaaaaniaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaa
aaaaaaaaaiaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 4 math, 2 textures
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesMultiTexCoord0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp vec4 _MainTex_ST;
varying mediump vec2 xlv_TEXCOORD0;
void main ()
{
  mediump vec2 tmpvar_1;
  highp vec2 tmpvar_2;
  tmpvar_2 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_2;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform sampler2D _GlowTex;
uniform highp vec4 _GlowColor;
uniform highp float _GlowIntensity;
varying mediump vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 col_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture2D (_MainTex, xlv_TEXCOORD0);
  lowp vec4 tmpvar_3;
  tmpvar_3 = texture2D (_GlowTex, xlv_TEXCOORD0);
  highp vec4 tmpvar_4;
  tmpvar_4 = (tmpvar_2 + ((tmpvar_3.x * _GlowColor) * _GlowIntensity));
  col_1.xyz = tmpvar_4.xyz;
  col_1.w = 1.0;
  gl_FragData[0] = col_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 5 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 144
Vector 128 [_MainTex_ST]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerDraw"" 1
""vs_4_0_level_9_1
eefiecedlnonibommofomijdcpinjibjijgnbhjkabaaaaaapiacaaaaaeaaaaaa
daaaaaaabiabaaaaemacaaaakaacaaaaebgpgodjoaaaaaaaoaaaaaaaaaacpopp
kaaaaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaiaa
abaaabaaaaaaaaaaabaaaaaaaeaaacaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjaaeaaaaaeaaaaadoaabaaoeja
abaaoekaabaaookaafaaaaadaaaaapiaaaaaffjaadaaoekaaeaaaaaeaaaaapia
acaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaeaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiaafaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaa
aaaaaaaaaiaaaaaadoaaaaabejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 4 math, 2 textures
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesMultiTexCoord0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp vec4 _MainTex_ST;
out mediump vec2 xlv_TEXCOORD0;
void main ()
{
  mediump vec2 tmpvar_1;
  highp vec2 tmpvar_2;
  tmpvar_2 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_2;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform sampler2D _GlowTex;
uniform highp vec4 _GlowColor;
uniform highp float _GlowIntensity;
in mediump vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 col_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture (_MainTex, xlv_TEXCOORD0);
  lowp vec4 tmpvar_3;
  tmpvar_3 = texture (_GlowTex, xlv_TEXCOORD0);
  highp vec4 tmpvar_4;
  tmpvar_4 = (tmpvar_2 + ((tmpvar_3.x * _GlowColor) * _GlowIntensity));
  col_1.xyz = tmpvar_4.xyz;
  col_1.w = 1.0;
  _glesFragData[0] = col_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 3 math
Bind ""vertex"" ATTR0
Bind ""texcoord"" ATTR1
ConstBuffer ""$Globals"" 80
Matrix 0 [glstate_matrix_mvp]
Vector 64 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float4 _glesMultiTexCoord0 [[attribute(1)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  half2 xlv_TEXCOORD0;
};
struct xlatMtlShaderUniform {
  float4x4 glstate_matrix_mvp;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half2 tmpvar_1;
  float2 tmpvar_2;
  tmpvar_2 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  tmpvar_1 = half2(tmpvar_2);
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = tmpvar_1;
  return _mtl_o;
}

""
}
}
Program ""fp"" {
SubProgram ""opengl "" {
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 4 math, 2 textures
Vector 0 [_GlowColor]
Float 1 [_GlowIntensity]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_GlowTex] 2D 1
""ps_2_0
def c2, 1, 0, 0, 0
dcl_pp t0.xy
dcl_2d s0
dcl_2d s1
texld r0, t0, s1
texld_pp r1, t0, s0
mul r0.xyz, r0.x, c0
mad_pp r0.xyz, r0, c1.x, r1
mov_pp r0.w, c2.x
mov_pp oC0, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 2 math, 2 textures
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_GlowTex] 2D 1
ConstBuffer ""$Globals"" 144
Vector 96 [_GlowColor]
Float 112 [_GlowIntensity]
BindCB  ""$Globals"" 0
""ps_4_0
eefiecediepmkjkadiillfokimnbpegnipfhcejgabaaaaaaniabaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcbiabaaaa
eaaaaaaaegaaaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaa
abaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaihcaabaaaaaaaaaaa
agaabaaaaaaaaaaaegiccaaaaaaaaaaaagaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaakhccabaaa
aaaaaaaaegacbaaaaaaaaaaaagiacaaaaaaaaaaaahaaaaaaegacbaaaabaaaaaa
dgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab""
}
SubProgram ""gles "" {
""!!GLES""
}
SubProgram ""d3d11_9x "" {
// Stats: 2 math, 2 textures
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_GlowTex] 2D 1
ConstBuffer ""$Globals"" 144
Vector 96 [_GlowColor]
Float 112 [_GlowIntensity]
BindCB  ""$Globals"" 0
""ps_4_0_level_9_1
eefiecedehaldamjfhnkkbpnglmihgjnmmajgppiabaaaaaalmacaaaaaeaaaaaa
daaaaaaabaabaaaadaacaaaaiiacaaaaebgpgodjniaaaaaaniaaaaaaaaacpppp
kaaaaaaadiaaaaaaabaacmaaaaaadiaaaaaadiaaacaaceaaaaaadiaaaaaaaaaa
abababaaaaaaagaaacaaaaaaaaaaaaaaaaacppppfbaaaaafacaaapkaaaaaiadp
aaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaacdlabpaaaaacaaaaaaja
aaaiapkabpaaaaacaaaaaajaabaiapkaecaaaaadaaaaapiaaaaaoelaabaioeka
ecaaaaadabaacpiaaaaaoelaaaaioekaafaaaaadaaaaahiaaaaaaaiaaaaaoeka
aeaaaaaeaaaachiaaaaaoeiaabaaaakaabaaoeiaabaaaaacaaaaciiaacaaaaka
abaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcbiabaaaaeaaaaaaaegaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaa
abaaaaaaaagabaaaabaaaaaadiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaa
egiccaaaaaaaaaaaagaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaakhccabaaaaaaaaaaaegacbaaa
aaaaaaaaagiacaaaaaaaaaaaahaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaiadpdoaaaaabejfdeheofaaaaaaaacaaaaaaaiaaaaaa
diaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaadadaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 4 math, 2 textures
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_GlowTex] 2D 1
ConstBuffer ""$Globals"" 20
Vector 0 [_GlowColor]
Float 16 [_GlowIntensity]
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  half2 xlv_TEXCOORD0;
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
  float4 _GlowColor;
  float _GlowIntensity;
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]]
  ,   texture2d<half> _MainTex [[texture(0)]], sampler _mtlsmp__MainTex [[sampler(0)]]
  ,   texture2d<half> _GlowTex [[texture(1)]], sampler _mtlsmp__GlowTex [[sampler(1)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 col_1;
  half4 tmpvar_2;
  tmpvar_2 = _MainTex.sample(_mtlsmp__MainTex, (float2)(_mtl_i.xlv_TEXCOORD0));
  half4 tmpvar_3;
  tmpvar_3 = _GlowTex.sample(_mtlsmp__GlowTex, (float2)(_mtl_i.xlv_TEXCOORD0));
  float4 tmpvar_4;
  tmpvar_4 = ((float4)tmpvar_2 + (((float)tmpvar_3.x * _mtl_u._GlowColor) * _mtl_u._GlowIntensity));
  col_1.xyz = half3(tmpvar_4.xyz);
  col_1.w = half(1.0);
  _mtl_o._glesFragData_0 = col_1;
  return _mtl_o;
}

""
}
}
 }
}
}";

        public static readonly string buildingsGlowPP = @"// Compiled shader for all platforms, uncompressed size: 10.9KB

// Skipping shader variants that would not be included into build of current scene.

Shader ""BuildingGlowPostProcess"" {
Properties {
 _MainTex (""Base (RGB)"", 2D) = ""white"" { }
 _GlowTex (""Glow"", 2D) = ""white"" { }
}
SubShader { 
 LOD 100
 Tags { ""RenderType""=""Opaque"" }


 // Stats for Vertex shader:
 //       d3d11 : 5 math
 //    d3d11_9x : 5 math
 //        d3d9 : 5 math
 //        gles : 3 math, 2 texture
 //       gles3 : 3 math, 2 texture
 //       metal : 3 math
 //      opengl : 3 math, 2 texture
 // Stats for Fragment shader:
 //       d3d11 : 1 math, 2 texture
 //    d3d11_9x : 1 math, 2 texture
 //        d3d9 : 3 math, 2 texture
 //       metal : 3 math, 2 texture
 Pass {
  Tags { ""RenderType""=""Opaque"" }
  GpuProgramID 54535
Program ""vp"" {
SubProgram ""opengl "" {
// Stats: 3 math, 2 textures
""!!GLSL
#ifdef VERTEX

uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
uniform sampler2D _GlowTex;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  vec4 col_1;
  col_1.xyz = (texture2D (_MainTex, xlv_TEXCOORD0) + (texture2D (_GlowTex, xlv_TEXCOORD0).x * vec4(1.0, 1.0, 0.0, 1.0))).xyz;
  col_1.w = 1.0;
  gl_FragData[0] = col_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 5 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_ST]
""vs_2_0
dcl_position v0
dcl_texcoord v1
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
mad oT0.xy, v1, c4, c4.zwzw

""
}
SubProgram ""d3d11 "" {
// Stats: 5 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 112
Vector 96 [_MainTex_ST]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerDraw"" 1
""vs_4_0
eefiecedgonlkjgafniaclaedpnpgjnkochaoaljabaaaaaaamacaaaaadaaaaaa
cmaaaaaaiaaaaaaaniaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaagaaaaaaogikcaaa
aaaaaaaaagaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 3 math, 2 textures
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesMultiTexCoord0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp vec4 _MainTex_ST;
varying mediump vec2 xlv_TEXCOORD0;
void main ()
{
  mediump vec2 tmpvar_1;
  highp vec2 tmpvar_2;
  tmpvar_2 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_2;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform sampler2D _GlowTex;
varying mediump vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 col_1;
  col_1.xyz = (texture2D (_MainTex, xlv_TEXCOORD0) + (texture2D (_GlowTex, xlv_TEXCOORD0).x * vec4(1.0, 1.0, 0.0, 1.0))).xyz;
  col_1.w = 1.0;
  gl_FragData[0] = col_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 5 math
Bind ""vertex"" Vertex
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 112
Vector 96 [_MainTex_ST]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerDraw"" 1
""vs_4_0_level_9_1
eefiecedbnncplheoiflngccngahdmicfmebkclcabaaaaaapiacaaaaaeaaaaaa
daaaaaaabiabaaaaemacaaaakaacaaaaebgpgodjoaaaaaaaoaaaaaaaaaacpopp
kaaaaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaagaa
abaaabaaaaaaaaaaabaaaaaaaeaaacaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjaaeaaaaaeaaaaadoaabaaoeja
abaaoekaabaaookaafaaaaadaaaaapiaaaaaffjaadaaoekaaeaaaaaeaaaaapia
acaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaeaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiaafaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaagaaaaaaogikcaaa
aaaaaaaaagaaaaaadoaaaaabejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 3 math, 2 textures
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesMultiTexCoord0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp vec4 _MainTex_ST;
out mediump vec2 xlv_TEXCOORD0;
void main ()
{
  mediump vec2 tmpvar_1;
  highp vec2 tmpvar_2;
  tmpvar_2 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_2;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform sampler2D _GlowTex;
in mediump vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 col_1;
  col_1.xyz = (texture (_MainTex, xlv_TEXCOORD0) + (texture (_GlowTex, xlv_TEXCOORD0).x * vec4(1.0, 1.0, 0.0, 1.0))).xyz;
  col_1.w = 1.0;
  _glesFragData[0] = col_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 3 math
Bind ""vertex"" ATTR0
Bind ""texcoord"" ATTR1
ConstBuffer ""$Globals"" 80
Matrix 0 [glstate_matrix_mvp]
Vector 64 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float4 _glesMultiTexCoord0 [[attribute(1)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  half2 xlv_TEXCOORD0;
};
struct xlatMtlShaderUniform {
  float4x4 glstate_matrix_mvp;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half2 tmpvar_1;
  float2 tmpvar_2;
  tmpvar_2 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  tmpvar_1 = half2(tmpvar_2);
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = tmpvar_1;
  return _mtl_o;
}

""
}
}
Program ""fp"" {
SubProgram ""opengl "" {
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 3 math, 2 textures
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_GlowTex] 2D 1
""ps_2_0
def c0, 1, 1, 0, 0
dcl_pp t0.xy
dcl_2d s0
dcl_2d s1
texld_pp r0, t0, s0
texld r1, t0, s1
mad_pp r0.xyz, r1.x, c0, r0
mov_pp r0.w, c0.x
mov_pp oC0, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 1 math, 2 textures
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_GlowTex] 2D 1
""ps_4_0
eefiecedmadacknonifgaafkichcaicmhcmiifekabaaaaaalaabaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcpaaaaaaa
eaaaaaaadmaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaa
gcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaa
efaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaa
aagabaaaabaaaaaadcaaaaamhccabaaaaaaaaaaaagaabaaaabaaaaaaaceaaaaa
aaaaiadpaaaaiadpaaaaaaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaiadpdoaaaaab""
}
SubProgram ""gles "" {
""!!GLES""
}
SubProgram ""d3d11_9x "" {
// Stats: 1 math, 2 textures
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_GlowTex] 2D 1
""ps_4_0_level_9_1
eefiecedbnolmakglcdgfhhpaepgmgiclkdlpldfabaaaaaahiacaaaaaeaaaaaa
daaaaaaapeaaaaaaomabaaaaeeacaaaaebgpgodjlmaaaaaalmaaaaaaaaacpppp
jaaaaaaacmaaaaaaaaaacmaaaaaacmaaaaaacmaaacaaceaaaaaacmaaaaaaaaaa
abababaaaaacppppfbaaaaafaaaaapkaaaaaiadpaaaaiadpaaaaaaaaaaaaaaaa
bpaaaaacaaaaaaiaaaaacdlabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaaja
abaiapkaecaaaaadaaaacpiaaaaaoelaaaaioekaecaaaaadabaaapiaaaaaoela
abaioekaaeaaaaaeaaaachiaabaaaaiaaaaaoekaaaaaoeiaabaaaaacaaaaciia
aaaaaakaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcpaaaaaaaeaaaaaaa
dmaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
abaaaaaadcaaaaamhccabaaaaaaaaaaaagaabaaaabaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaaaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaiadpdoaaaaabejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 3 math, 2 textures
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_GlowTex] 2D 1
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  half2 xlv_TEXCOORD0;
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]]
  ,   texture2d<half> _MainTex [[texture(0)]], sampler _mtlsmp__MainTex [[sampler(0)]]
  ,   texture2d<half> _GlowTex [[texture(1)]], sampler _mtlsmp__GlowTex [[sampler(1)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 col_1;
  col_1.xyz = (_MainTex.sample(_mtlsmp__MainTex, (float2)(_mtl_i.xlv_TEXCOORD0)) + (_GlowTex.sample(_mtlsmp__GlowTex, (float2)(_mtl_i.xlv_TEXCOORD0)).x * (half4)float4(1.0, 1.0, 0.0, 1.0))).xyz;
  col_1.w = half(1.0);
  _mtl_o._glesFragData_0 = col_1;
  return _mtl_o;
}

""
}
}
 }
}
}";

        public static readonly string buildingsWindowReplacement = @"// Compiled shader for all platforms, uncompressed size: 342.0KB

// Skipping shader variants that would not be included into build of current scene.

Shader ""BuildingReplacement"" {
Properties {
 _MainTex (""Base (RGB)"", 2D) = ""white"" { }
 _XYSMap (""Base (RGB)"", 2D) = ""white"" { }
 _ACIMap (""Base (RGB)"", 2D) = ""white"" { }
 _SpecMap (""SpecMap"", 2D) = ""white"" { }
}
SubShader { 
 LOD 200
 Tags { ""ForceNoShadowCasting""=""true"" ""RenderType""=""Opaque"" }


 // Stats for Vertex shader:
 //       d3d11 : 45 avg math (34..57)
 //    d3d11_9x : 48 avg math (34..62)
 //        d3d9 : 44 avg math (27..61)
 //        gles : 4 math, 1 texture
 //       gles3 : 4 math, 1 texture
 //       metal : 38 avg math (24..53)
 //      opengl : 4 math, 1 texture
 // Stats for Fragment shader:
 //       d3d11 : 1 math, 1 texture
 //    d3d11_9x : 1 math, 1 texture
 //        d3d9 : 3 math, 1 texture
 //       metal : 4 math, 1 texture
 Pass {
  Name ""FORWARD""
  Tags { ""LIGHTMODE""=""ForwardBase"" ""SHADOWSUPPORT""=""true"" ""ForceNoShadowCasting""=""true"" ""RenderType""=""Opaque"" }
  GpuProgramID 2170
Program ""vp"" {
SubProgram ""opengl "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLSL
#ifdef VERTEX
uniform vec4 unity_SHAr;
uniform vec4 unity_SHAg;
uniform vec4 unity_SHAb;
uniform vec4 unity_SHBr;
uniform vec4 unity_SHBg;
uniform vec4 unity_SHBb;
uniform vec4 unity_SHC;

uniform mat4 _Object2World;
uniform mat4 _World2Object;
uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
varying vec3 xlv_TEXCOORD2;
varying vec3 xlv_TEXCOORD3;
void main ()
{
  vec4 v_1;
  v_1.x = _World2Object[0].x;
  v_1.y = _World2Object[1].x;
  v_1.z = _World2Object[2].x;
  v_1.w = _World2Object[3].x;
  vec4 v_2;
  v_2.x = _World2Object[0].y;
  v_2.y = _World2Object[1].y;
  v_2.z = _World2Object[2].y;
  v_2.w = _World2Object[3].y;
  vec4 v_3;
  v_3.x = _World2Object[0].z;
  v_3.y = _World2Object[1].z;
  v_3.z = _World2Object[2].z;
  v_3.w = _World2Object[3].z;
  vec3 tmpvar_4;
  tmpvar_4 = normalize(((
    (v_1.xyz * gl_Normal.x)
   + 
    (v_2.xyz * gl_Normal.y)
  ) + (v_3.xyz * gl_Normal.z)));
  vec4 tmpvar_5;
  tmpvar_5.w = 1.0;
  tmpvar_5.xyz = tmpvar_4;
  vec3 x2_6;
  vec3 x1_7;
  x1_7.x = dot (unity_SHAr, tmpvar_5);
  x1_7.y = dot (unity_SHAg, tmpvar_5);
  x1_7.z = dot (unity_SHAb, tmpvar_5);
  vec4 tmpvar_8;
  tmpvar_8 = (tmpvar_4.xyzz * tmpvar_4.yzzx);
  x2_6.x = dot (unity_SHBr, tmpvar_8);
  x2_6.y = dot (unity_SHBg, tmpvar_8);
  x2_6.z = dot (unity_SHBb, tmpvar_8);
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_4;
  xlv_TEXCOORD2 = (_Object2World * gl_Vertex).xyz;
  xlv_TEXCOORD3 = ((x2_6 + (unity_SHC.xyz * 
    ((tmpvar_4.x * tmpvar_4.x) - (tmpvar_4.y * tmpvar_4.y))
  )) + x1_7);
}


#endif
#ifdef FRAGMENT
uniform sampler2D _XYSMap;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  vec4 c_1;
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 27 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
Vector 17 [_MainTex_ST]
Vector 12 [unity_SHAb]
Vector 11 [unity_SHAg]
Vector 10 [unity_SHAr]
Vector 15 [unity_SHBb]
Vector 14 [unity_SHBg]
Vector 13 [unity_SHBr]
Vector 16 [unity_SHC]
""vs_2_0
def c18, 1, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord v2
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
mad oT0.xy, v2, c17, c17.zwzw
dp4 oT2.x, c4, v0
dp4 oT2.y, c5, v0
dp4 oT2.z, c6, v0
mul r0.xyz, v1.y, c8
mad r0.xyz, c7, v1.x, r0
mad r0.xyz, c9, v1.z, r0
nrm r1.xyz, r0
mul r0.x, r1.y, r1.y
mad r0.x, r1.x, r1.x, -r0.x
mul r2, r1.yzzx, r1.xyzz
dp4 r3.x, c13, r2
dp4 r3.y, c14, r2
dp4 r3.z, c15, r2
mad r0.xyz, c16, r0.x, r3
mov r1.w, c18.x
dp4 r2.x, c10, r1
dp4 r2.y, c11, r1
dp4 r2.z, c12, r1
mov oT1.xyz, r1
add oT3.xyz, r0, r2

""
}
SubProgram ""d3d11 "" {
// Stats: 34 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 160
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityLighting"" 1
BindCB  ""UnityPerDraw"" 2
""vs_4_0
eefiecedfoecphckbhjnhbiggajmdcbfdmmfdnaeabaaaaaaaaahaaaaadaaaaaa
cmaaaaaaceabaaaameabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaaimaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklfdeieefcdeafaaaaeaaaabaaenabaaaafjaaaaaeegiocaaaaaaaaaaa
akaaaaaafjaaaaaeegiocaaaabaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaa
bdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaafhccabaaa
acaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaaaaaaaaaa
egiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaa
amaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hccabaaaadaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaa
abaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaa
dcaaaaakbcaabaaaabaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaia
ebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaa
aaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaa
acaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaa
acaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaa
acaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaacmaaaaaaagaabaaa
abaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadp
bbaaaaaibcaabaaaacaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaa
bbaaaaaiccaabaaaacaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaa
bbaaaaaiecaabaaaacaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaa
aaaaaaahhccabaaaaeaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaadoaaaaab
""
}
SubProgram ""gles "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying mediump vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying mediump vec3 xlv_TEXCOORD3;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  lowp vec4 tmpvar_7;
  tmpvar_7.w = 1.0;
  tmpvar_7.xyz = worldNormal_1;
  mediump vec4 normal_8;
  normal_8 = tmpvar_7;
  mediump vec3 x2_9;
  mediump vec3 x1_10;
  x1_10.x = dot (unity_SHAr, normal_8);
  x1_10.y = dot (unity_SHAg, normal_8);
  x1_10.z = dot (unity_SHAb, normal_8);
  mediump vec4 tmpvar_11;
  tmpvar_11 = (normal_8.xyzz * normal_8.yzzx);
  x2_9.x = dot (unity_SHBr, tmpvar_11);
  x2_9.y = dot (unity_SHBg, tmpvar_11);
  x2_9.z = dot (unity_SHBb, tmpvar_11);
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = (_Object2World * _glesVertex).xyz;
  xlv_TEXCOORD3 = ((x2_9 + (unity_SHC.xyz * 
    ((normal_8.x * normal_8.x) - (normal_8.y * normal_8.y))
  )) + x1_10);
}



#endif
#ifdef FRAGMENT

uniform sampler2D _XYSMap;
varying highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 34 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 160
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityLighting"" 1
BindCB  ""UnityPerDraw"" 2
""vs_4_0_level_9_1
eefiecedjoicfdgpffpghenpeofmamkekdfjcacnabaaaaaaaaakaaaaaeaaaaaa
daaaaaaacmadaaaagiaiaaaagaajaaaaebgpgodjpeacaaaapeacaaaaaaacpopp
jmacaaaafiaaaaaaaeaaceaaaaaafeaaaaaafeaaaaaaceaaabaafeaaaaaaajaa
abaaabaaaaaaaaaaabaacgaaahaaacaaaaaaaaaaacaaaaaaaeaaajaaaaaaaaaa
acaaamaaahaaanaaaaaaaaaaaaaaaaaaaaacpoppfbaaaaafbeaaapkaaaaaiadp
aaaaaaaaaaaaaaaaaaaaaaaabpaaaaacafaaaaiaaaaaapjabpaaaaacafaaacia
acaaapjabpaaaaacafaaadiaadaaapjaaeaaaaaeaaaaadoaadaaoejaabaaoeka
abaaookaafaaaaadaaaaahiaaaaaffjaaoaaoekaaeaaaaaeaaaaahiaanaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaahiaapaaoekaaaaakkjaaaaaoeiaaeaaaaae
acaaahoabaaaoekaaaaappjaaaaaoeiaafaaaaadaaaaabiaacaaaajabbaaaaka
afaaaaadaaaaaciaacaaaajabcaaaakaafaaaaadaaaaaeiaacaaaajabdaaaaka
afaaaaadabaaabiaacaaffjabbaaffkaafaaaaadabaaaciaacaaffjabcaaffka
afaaaaadabaaaeiaacaaffjabdaaffkaacaaaaadaaaaahiaaaaaoeiaabaaoeia
afaaaaadabaaabiaacaakkjabbaakkkaafaaaaadabaaaciaacaakkjabcaakkka
afaaaaadabaaaeiaacaakkjabdaakkkaacaaaaadaaaaahiaaaaaoeiaabaaoeia
ceaaaaacabaaahiaaaaaoeiaafaaaaadaaaaabiaabaaffiaabaaffiaaeaaaaae
aaaaabiaabaaaaiaabaaaaiaaaaaaaibafaaaaadacaaapiaabaacjiaabaakeia
ajaaaaadadaaabiaafaaoekaacaaoeiaajaaaaadadaaaciaagaaoekaacaaoeia
ajaaaaadadaaaeiaahaaoekaacaaoeiaaeaaaaaeaaaaahiaaiaaoekaaaaaaaia
adaaoeiaabaaaaacabaaaiiabeaaaakaajaaaaadacaaabiaacaaoekaabaaoeia
ajaaaaadacaaaciaadaaoekaabaaoeiaajaaaaadacaaaeiaaeaaoekaabaaoeia
abaaaaacabaaahoaabaaoeiaacaaaaadadaaahoaaaaaoeiaacaaoeiaafaaaaad
aaaaapiaaaaaffjaakaaoekaaeaaaaaeaaaaapiaajaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaalaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaamaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiappppaaaafdeieefcdeafaaaaeaaaabaaenabaaaafjaaaaae
egiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaacnaaaaaafjaaaaae
egiocaaaacaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaai
bcaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabaaaaaaadiaaaaai
ccaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabbaaaaaadiaaaaai
ecaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabcaaaaaadiaaaaai
bcaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabaaaaaaadiaaaaai
ccaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabbaaaaaadiaaaaai
ecaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabcaaaaaaaaaaaaah
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaa
abaaaaaackbabaaaacaaaaaackiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaa
abaaaaaackbabaaaacaaaaaackiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaa
abaaaaaackbabaaaacaaaaaackiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaa
dgaaaaafhccabaaaacaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgbfbaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaakhccabaaaadaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaabaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaaaaaaaaaa
bkaabaaaaaaaaaaadcaaaaakbcaabaaaabaaaaaaakaabaaaaaaaaaaaakaabaaa
aaaaaaaaakaabaiaebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaa
aaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaa
cjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaa
ckaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaa
claaaaaaegaobaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaa
cmaaaaaaagaabaaaabaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaaaaaaaaaa
abeaaaaaaaaaiadpbbaaaaaibcaabaaaacaaaaaaegiocaaaabaaaaaacgaaaaaa
egaobaaaaaaaaaaabbaaaaaiccaabaaaacaaaaaaegiocaaaabaaaaaachaaaaaa
egaobaaaaaaaaaaabbaaaaaiecaabaaaacaaaaaaegiocaaaabaaaaaaciaaaaaa
egaobaaaaaaaaaaaaaaaaaahhccabaaaaeaaaaaaegacbaaaabaaaaaaegacbaaa
acaaaaaadoaaaaabejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaa
oaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaaabaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaaadaaaaaa
afaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaaapaaaaaa
ojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdejfeejepeo
aafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaakl
epfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
""
}
SubProgram ""gles3 "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out mediump vec3 xlv_TEXCOORD1;
out highp vec3 xlv_TEXCOORD2;
out mediump vec3 xlv_TEXCOORD3;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  lowp vec4 tmpvar_7;
  tmpvar_7.w = 1.0;
  tmpvar_7.xyz = worldNormal_1;
  mediump vec4 normal_8;
  normal_8 = tmpvar_7;
  mediump vec3 x2_9;
  mediump vec3 x1_10;
  x1_10.x = dot (unity_SHAr, normal_8);
  x1_10.y = dot (unity_SHAg, normal_8);
  x1_10.z = dot (unity_SHAb, normal_8);
  mediump vec4 tmpvar_11;
  tmpvar_11 = (normal_8.xyzz * normal_8.yzzx);
  x2_9.x = dot (unity_SHBr, tmpvar_11);
  x2_9.y = dot (unity_SHBg, tmpvar_11);
  x2_9.z = dot (unity_SHBb, tmpvar_11);
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = (_Object2World * _glesVertex).xyz;
  xlv_TEXCOORD3 = ((x2_9 + (unity_SHC.xyz * 
    ((normal_8.x * normal_8.x) - (normal_8.y * normal_8.y))
  )) + x1_10);
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _XYSMap;
in highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  _glesFragData[0] = c_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 24 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
Bind ""texcoord"" ATTR2
ConstBuffer ""$Globals"" 272
Matrix 64 [glstate_matrix_mvp]
Matrix 128 [_Object2World]
Matrix 192 [_World2Object]
VectorHalf 0 [unity_SHAr] 4
VectorHalf 8 [unity_SHAg] 4
VectorHalf 16 [unity_SHAb] 4
VectorHalf 24 [unity_SHBr] 4
VectorHalf 32 [unity_SHBg] 4
VectorHalf 40 [unity_SHBb] 4
VectorHalf 48 [unity_SHC] 4
Vector 256 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
  float4 _glesMultiTexCoord0 [[attribute(2)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  float2 xlv_TEXCOORD0;
  half3 xlv_TEXCOORD1;
  float3 xlv_TEXCOORD2;
  half3 xlv_TEXCOORD3;
};
struct xlatMtlShaderUniform {
  half4 unity_SHAr;
  half4 unity_SHAg;
  half4 unity_SHAb;
  half4 unity_SHBr;
  half4 unity_SHBg;
  half4 unity_SHBb;
  half4 unity_SHC;
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  float4 v_3;
  v_3.x = _mtl_u._World2Object[0].x;
  v_3.y = _mtl_u._World2Object[1].x;
  v_3.z = _mtl_u._World2Object[2].x;
  v_3.w = _mtl_u._World2Object[3].x;
  float4 v_4;
  v_4.x = _mtl_u._World2Object[0].y;
  v_4.y = _mtl_u._World2Object[1].y;
  v_4.z = _mtl_u._World2Object[2].y;
  v_4.w = _mtl_u._World2Object[3].y;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].z;
  v_5.y = _mtl_u._World2Object[1].z;
  v_5.z = _mtl_u._World2Object[2].z;
  v_5.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _mtl_i._glesNormal.x)
   + 
    (v_4.xyz * _mtl_i._glesNormal.y)
  ) + (v_5.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_6);
  tmpvar_2 = worldNormal_1;
  half4 tmpvar_7;
  tmpvar_7.w = half(1.0);
  tmpvar_7.xyz = worldNormal_1;
  half4 normal_8;
  normal_8 = tmpvar_7;
  half3 x2_9;
  half3 x1_10;
  x1_10.x = dot (_mtl_u.unity_SHAr, normal_8);
  x1_10.y = dot (_mtl_u.unity_SHAg, normal_8);
  x1_10.z = dot (_mtl_u.unity_SHAb, normal_8);
  half4 tmpvar_11;
  tmpvar_11 = (normal_8.xyzz * normal_8.yzzx);
  x2_9.x = dot (_mtl_u.unity_SHBr, tmpvar_11);
  x2_9.y = dot (_mtl_u.unity_SHBg, tmpvar_11);
  x2_9.z = dot (_mtl_u.unity_SHBb, tmpvar_11);
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  _mtl_o.xlv_TEXCOORD1 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD2 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  _mtl_o.xlv_TEXCOORD3 = ((x2_9 + (_mtl_u.unity_SHC.xyz * 
    ((normal_8.x * normal_8.x) - (normal_8.y * normal_8.y))
  )) + x1_10);
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLSL
#ifdef VERTEX
uniform vec4 _ProjectionParams;
uniform vec4 unity_SHAr;
uniform vec4 unity_SHAg;
uniform vec4 unity_SHAb;
uniform vec4 unity_SHBr;
uniform vec4 unity_SHBg;
uniform vec4 unity_SHBb;
uniform vec4 unity_SHC;

uniform mat4 _Object2World;
uniform mat4 _World2Object;
uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
varying vec3 xlv_TEXCOORD2;
varying vec3 xlv_TEXCOORD3;
varying vec4 xlv_TEXCOORD4;
void main ()
{
  vec4 tmpvar_1;
  tmpvar_1 = (gl_ModelViewProjectionMatrix * gl_Vertex);
  vec4 v_2;
  v_2.x = _World2Object[0].x;
  v_2.y = _World2Object[1].x;
  v_2.z = _World2Object[2].x;
  v_2.w = _World2Object[3].x;
  vec4 v_3;
  v_3.x = _World2Object[0].y;
  v_3.y = _World2Object[1].y;
  v_3.z = _World2Object[2].y;
  v_3.w = _World2Object[3].y;
  vec4 v_4;
  v_4.x = _World2Object[0].z;
  v_4.y = _World2Object[1].z;
  v_4.z = _World2Object[2].z;
  v_4.w = _World2Object[3].z;
  vec3 tmpvar_5;
  tmpvar_5 = normalize(((
    (v_2.xyz * gl_Normal.x)
   + 
    (v_3.xyz * gl_Normal.y)
  ) + (v_4.xyz * gl_Normal.z)));
  vec4 tmpvar_6;
  tmpvar_6.w = 1.0;
  tmpvar_6.xyz = tmpvar_5;
  vec3 x2_7;
  vec3 x1_8;
  x1_8.x = dot (unity_SHAr, tmpvar_6);
  x1_8.y = dot (unity_SHAg, tmpvar_6);
  x1_8.z = dot (unity_SHAb, tmpvar_6);
  vec4 tmpvar_9;
  tmpvar_9 = (tmpvar_5.xyzz * tmpvar_5.yzzx);
  x2_7.x = dot (unity_SHBr, tmpvar_9);
  x2_7.y = dot (unity_SHBg, tmpvar_9);
  x2_7.z = dot (unity_SHBb, tmpvar_9);
  vec4 o_10;
  vec4 tmpvar_11;
  tmpvar_11 = (tmpvar_1 * 0.5);
  vec2 tmpvar_12;
  tmpvar_12.x = tmpvar_11.x;
  tmpvar_12.y = (tmpvar_11.y * _ProjectionParams.x);
  o_10.xy = (tmpvar_12 + tmpvar_11.w);
  o_10.zw = tmpvar_1.zw;
  gl_Position = tmpvar_1;
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_5;
  xlv_TEXCOORD2 = (_Object2World * gl_Vertex).xyz;
  xlv_TEXCOORD3 = ((x2_7 + (unity_SHC.xyz * 
    ((tmpvar_5.x * tmpvar_5.x) - (tmpvar_5.y * tmpvar_5.y))
  )) + x1_8);
  xlv_TEXCOORD4 = o_10;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _XYSMap;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  vec4 c_1;
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 33 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
Vector 19 [_MainTex_ST]
Vector 10 [_ProjectionParams]
Vector 11 [_ScreenParams]
Vector 14 [unity_SHAb]
Vector 13 [unity_SHAg]
Vector 12 [unity_SHAr]
Vector 17 [unity_SHBb]
Vector 16 [unity_SHBg]
Vector 15 [unity_SHBr]
Vector 18 [unity_SHC]
""vs_2_0
def c20, 1, 0.5, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord v2
mad oT0.xy, v2, c19, c19.zwzw
dp4 oT2.x, c4, v0
dp4 oT2.y, c5, v0
dp4 oT2.z, c6, v0
mul r0.xyz, v1.y, c8
mad r0.xyz, c7, v1.x, r0
mad r0.xyz, c9, v1.z, r0
nrm r1.xyz, r0
mul r0.x, r1.y, r1.y
mad r0.x, r1.x, r1.x, -r0.x
mul r2, r1.yzzx, r1.xyzz
dp4 r3.x, c15, r2
dp4 r3.y, c16, r2
dp4 r3.z, c17, r2
mad r0.xyz, c18, r0.x, r3
mov r1.w, c20.x
dp4 r2.x, c12, r1
dp4 r2.y, c13, r1
dp4 r2.z, c14, r1
mov oT1.xyz, r1
add oT3.xyz, r0, r2
dp4 r0.y, c1, v0
mul r1.x, r0.y, c10.x
mul r1.w, r1.x, c20.y
dp4 r0.x, c0, v0
dp4 r0.w, c3, v0
mul r1.xz, r0.xyww, c20.y
mad oT4.xy, r1.z, c11.zwzw, r1.xwzw
dp4 r0.z, c2, v0
mov oPos, r0
mov oT4.zw, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 37 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 160
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityPerCamera"" 144
Vector 80 [_ProjectionParams]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerCamera"" 1
BindCB  ""UnityLighting"" 2
BindCB  ""UnityPerDraw"" 3
""vs_4_0
eefiecedjonafkmjhnpbgppmfjepnokichfceaipabaaaaaamaahaaaaadaaaaaa
cmaaaaaaceabaaaanmabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
apaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
nmafaaaaeaaaabaahhabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaae
egiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaacnaaaaaafjaaaaae
egiocaaaadaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaagiaaaaac
afaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
pccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaai
bcaabaaaabaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabaaaaaaadiaaaaai
ccaabaaaabaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabbaaaaaadiaaaaai
ecaabaaaabaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabcaaaaaadiaaaaai
bcaabaaaacaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabaaaaaaadiaaaaai
ccaabaaaacaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabbaaaaaadiaaaaai
ecaabaaaacaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabcaaaaaaaaaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaadiaaaaaibcaabaaa
acaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaa
acaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaa
acaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabcaaaaaaaaaaaaahhcaabaaa
abaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaaabaaaaaa
egacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaabaaaaaadkaabaaa
abaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaa
dgaaaaafhccabaaaacaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaa
fgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaa
egiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaacaaaaaadcaaaaak
hcaabaaaacaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
acaaaaaadcaaaaakhccabaaaadaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaacaaaaaadiaaaaahbcaabaaaacaaaaaabkaabaaaabaaaaaa
bkaabaaaabaaaaaadcaaaaakbcaabaaaacaaaaaaakaabaaaabaaaaaaakaabaaa
abaaaaaaakaabaiaebaaaaaaacaaaaaadiaaaaahpcaabaaaadaaaaaajgacbaaa
abaaaaaaegakbaaaabaaaaaabbaaaaaibcaabaaaaeaaaaaaegiocaaaacaaaaaa
cjaaaaaaegaobaaaadaaaaaabbaaaaaiccaabaaaaeaaaaaaegiocaaaacaaaaaa
ckaaaaaaegaobaaaadaaaaaabbaaaaaiecaabaaaaeaaaaaaegiocaaaacaaaaaa
claaaaaaegaobaaaadaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaa
cmaaaaaaagaabaaaacaaaaaaegacbaaaaeaaaaaadgaaaaaficaabaaaabaaaaaa
abeaaaaaaaaaiadpbbaaaaaibcaabaaaadaaaaaaegiocaaaacaaaaaacgaaaaaa
egaobaaaabaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaacaaaaaachaaaaaa
egaobaaaabaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaacaaaaaaciaaaaaa
egaobaaaabaaaaaaaaaaaaahhccabaaaaeaaaaaaegacbaaaacaaaaaaegacbaaa
adaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaa
afaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaafaaaaaakgaobaaaaaaaaaaa
aaaaaaahdccabaaaafaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaab
""
}
SubProgram ""gles "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying mediump vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying mediump vec3 xlv_TEXCOORD3;
varying mediump vec4 xlv_TEXCOORD4;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  mediump vec4 tmpvar_3;
  highp vec4 v_4;
  v_4.x = _World2Object[0].x;
  v_4.y = _World2Object[1].x;
  v_4.z = _World2Object[2].x;
  v_4.w = _World2Object[3].x;
  highp vec4 v_5;
  v_5.x = _World2Object[0].y;
  v_5.y = _World2Object[1].y;
  v_5.z = _World2Object[2].y;
  v_5.w = _World2Object[3].y;
  highp vec4 v_6;
  v_6.x = _World2Object[0].z;
  v_6.y = _World2Object[1].z;
  v_6.z = _World2Object[2].z;
  v_6.w = _World2Object[3].z;
  highp vec3 tmpvar_7;
  tmpvar_7 = normalize(((
    (v_4.xyz * _glesNormal.x)
   + 
    (v_5.xyz * _glesNormal.y)
  ) + (v_6.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_7;
  tmpvar_2 = worldNormal_1;
  lowp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = worldNormal_1;
  mediump vec4 normal_9;
  normal_9 = tmpvar_8;
  mediump vec3 x2_10;
  mediump vec3 x1_11;
  x1_11.x = dot (unity_SHAr, normal_9);
  x1_11.y = dot (unity_SHAg, normal_9);
  x1_11.z = dot (unity_SHAb, normal_9);
  mediump vec4 tmpvar_12;
  tmpvar_12 = (normal_9.xyzz * normal_9.yzzx);
  x2_10.x = dot (unity_SHBr, tmpvar_12);
  x2_10.y = dot (unity_SHBg, tmpvar_12);
  x2_10.z = dot (unity_SHBb, tmpvar_12);
  highp vec4 tmpvar_13;
  highp vec4 cse_14;
  cse_14 = (_Object2World * _glesVertex);
  tmpvar_13 = (unity_World2Shadow[0] * cse_14);
  tmpvar_3 = tmpvar_13;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = cse_14.xyz;
  xlv_TEXCOORD3 = ((x2_10 + (unity_SHC.xyz * 
    ((normal_9.x * normal_9.x) - (normal_9.y * normal_9.y))
  )) + x1_11);
  xlv_TEXCOORD4 = tmpvar_3;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _XYSMap;
varying highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""opengl "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
""!!GLSL
#ifdef VERTEX
uniform vec4 unity_4LightPosX0;
uniform vec4 unity_4LightPosY0;
uniform vec4 unity_4LightPosZ0;
uniform vec4 unity_4LightAtten0;
uniform vec4 unity_LightColor[8];
uniform vec4 unity_SHAr;
uniform vec4 unity_SHAg;
uniform vec4 unity_SHAb;
uniform vec4 unity_SHBr;
uniform vec4 unity_SHBg;
uniform vec4 unity_SHBb;
uniform vec4 unity_SHC;

uniform mat4 _Object2World;
uniform mat4 _World2Object;
uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
varying vec3 xlv_TEXCOORD2;
varying vec3 xlv_TEXCOORD3;
void main ()
{
  vec3 tmpvar_1;
  tmpvar_1 = (_Object2World * gl_Vertex).xyz;
  vec4 v_2;
  v_2.x = _World2Object[0].x;
  v_2.y = _World2Object[1].x;
  v_2.z = _World2Object[2].x;
  v_2.w = _World2Object[3].x;
  vec4 v_3;
  v_3.x = _World2Object[0].y;
  v_3.y = _World2Object[1].y;
  v_3.z = _World2Object[2].y;
  v_3.w = _World2Object[3].y;
  vec4 v_4;
  v_4.x = _World2Object[0].z;
  v_4.y = _World2Object[1].z;
  v_4.z = _World2Object[2].z;
  v_4.w = _World2Object[3].z;
  vec3 tmpvar_5;
  tmpvar_5 = normalize(((
    (v_2.xyz * gl_Normal.x)
   + 
    (v_3.xyz * gl_Normal.y)
  ) + (v_4.xyz * gl_Normal.z)));
  vec4 tmpvar_6;
  tmpvar_6.w = 1.0;
  tmpvar_6.xyz = tmpvar_5;
  vec3 x2_7;
  vec3 x1_8;
  x1_8.x = dot (unity_SHAr, tmpvar_6);
  x1_8.y = dot (unity_SHAg, tmpvar_6);
  x1_8.z = dot (unity_SHAb, tmpvar_6);
  vec4 tmpvar_9;
  tmpvar_9 = (tmpvar_5.xyzz * tmpvar_5.yzzx);
  x2_7.x = dot (unity_SHBr, tmpvar_9);
  x2_7.y = dot (unity_SHBg, tmpvar_9);
  x2_7.z = dot (unity_SHBb, tmpvar_9);
  vec4 tmpvar_10;
  tmpvar_10 = (unity_4LightPosX0 - tmpvar_1.x);
  vec4 tmpvar_11;
  tmpvar_11 = (unity_4LightPosY0 - tmpvar_1.y);
  vec4 tmpvar_12;
  tmpvar_12 = (unity_4LightPosZ0 - tmpvar_1.z);
  vec4 tmpvar_13;
  tmpvar_13 = (((tmpvar_10 * tmpvar_10) + (tmpvar_11 * tmpvar_11)) + (tmpvar_12 * tmpvar_12));
  vec4 tmpvar_14;
  tmpvar_14 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_10 * tmpvar_5.x) + (tmpvar_11 * tmpvar_5.y)) + (tmpvar_12 * tmpvar_5.z))
   * 
    inversesqrt(tmpvar_13)
  )) * (1.0/((1.0 + 
    (tmpvar_13 * unity_4LightAtten0)
  ))));
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_5;
  xlv_TEXCOORD2 = tmpvar_1;
  xlv_TEXCOORD3 = (((x2_7 + 
    (unity_SHC.xyz * ((tmpvar_5.x * tmpvar_5.x) - (tmpvar_5.y * tmpvar_5.y)))
  ) + x1_8) + ((
    ((unity_LightColor[0].xyz * tmpvar_14.x) + (unity_LightColor[1].xyz * tmpvar_14.y))
   + 
    (unity_LightColor[2].xyz * tmpvar_14.z)
  ) + (unity_LightColor[3].xyz * tmpvar_14.w)));
}


#endif
#ifdef FRAGMENT
uniform sampler2D _XYSMap;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  vec4 c_1;
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 55 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
Matrix 8 [_Object2World] 3
Matrix 11 [_World2Object] 3
Matrix 4 [glstate_matrix_mvp]
Vector 25 [_MainTex_ST]
Vector 17 [unity_4LightAtten0]
Vector 14 [unity_4LightPosX0]
Vector 15 [unity_4LightPosY0]
Vector 16 [unity_4LightPosZ0]
Vector 0 [unity_LightColor0]
Vector 1 [unity_LightColor1]
Vector 2 [unity_LightColor2]
Vector 3 [unity_LightColor3]
Vector 20 [unity_SHAb]
Vector 19 [unity_SHAg]
Vector 18 [unity_SHAr]
Vector 23 [unity_SHBb]
Vector 22 [unity_SHBg]
Vector 21 [unity_SHBr]
Vector 24 [unity_SHC]
""vs_2_0
def c26, 1, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord v2
dp4 oPos.x, c4, v0
dp4 oPos.y, c5, v0
dp4 oPos.z, c6, v0
dp4 oPos.w, c7, v0
mad oT0.xy, v2, c25, c25.zwzw
mul r0.xyz, v1.y, c12
mad r0.xyz, c11, v1.x, r0
mad r0.xyz, c13, v1.z, r0
nrm r1.xyz, r0
mul r0.x, r1.y, r1.y
mad r0.x, r1.x, r1.x, -r0.x
mul r2, r1.yzzx, r1.xyzz
dp4 r3.x, c21, r2
dp4 r3.y, c22, r2
dp4 r3.z, c23, r2
mad r0.xyz, c24, r0.x, r3
mov r1.w, c26.x
dp4 r2.x, c18, r1
dp4 r2.y, c19, r1
dp4 r2.z, c20, r1
add r0.xyz, r0, r2
dp4 r2.y, c9, v0
add r3, -r2.y, c15
mul r4, r1.y, r3
mul r3, r3, r3
dp4 r2.x, c8, v0
add r5, -r2.x, c14
mad r4, r5, r1.x, r4
mad r3, r5, r5, r3
dp4 r2.z, c10, v0
add r5, -r2.z, c16
mov oT2.xyz, r2
mad r2, r5, r1.z, r4
mov oT1.xyz, r1
mad r1, r5, r5, r3
rsq r3.x, r1.x
rsq r3.y, r1.y
rsq r3.z, r1.z
rsq r3.w, r1.w
mov r4.x, c26.x
mad r1, r1, c17, r4.x
mul r2, r2, r3
max r2, r2, c26.y
rcp r3.x, r1.x
rcp r3.y, r1.y
rcp r3.z, r1.z
rcp r3.w, r1.w
mul r1, r2, r3
mul r2.xyz, r1.y, c1
mad r2.xyz, c0, r1.x, r2
mad r1.xyz, c2, r1.z, r2
mad r1.xyz, c3, r1.w, r1
add oT3.xyz, r0, r1

""
}
SubProgram ""d3d11 "" {
// Stats: 54 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 160
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityLighting"" 720
Vector 32 [unity_4LightPosX0]
Vector 48 [unity_4LightPosY0]
Vector 64 [unity_4LightPosZ0]
Vector 80 [unity_4LightAtten0]
Vector 96 [unity_LightColor0]
Vector 112 [unity_LightColor1]
Vector 128 [unity_LightColor2]
Vector 144 [unity_LightColor3]
Vector 160 [unity_LightColor4]
Vector 176 [unity_LightColor5]
Vector 192 [unity_LightColor6]
Vector 208 [unity_LightColor7]
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityLighting"" 1
BindCB  ""UnityPerDraw"" 2
""vs_4_0
eefiecedcfcgpdcfnebddimbmmnfccgkfhooohgpabaaaaaammajaaaaadaaaaaa
cmaaaaaaceabaaaameabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaaimaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklfdeieefcaaaiaaaaeaaaabaaaaacaaaafjaaaaaeegiocaaaaaaaaaaa
akaaaaaafjaaaaaeegiocaaaabaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaa
bdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagiaaaaacagaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaafhccabaaa
acaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaaaaaaaaaa
egiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaa
amaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaa
abaaaaaadgaaaaafhccabaaaadaaaaaaegacbaaaabaaaaaadiaaaaahicaabaaa
abaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakicaabaaaabaaaaaa
akaabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaiaebaaaaaaabaaaaaadiaaaaah
pcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaa
adaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaa
adaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaa
adaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaaacaaaaaadcaaaaakhcaabaaa
acaaaaaaegiccaaaabaaaaaacmaaaaaapgapbaaaabaaaaaaegacbaaaadaaaaaa
dgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaadaaaaaa
egiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaadaaaaaa
egiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaadaaaaaa
egiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaaaaaaaaahhcaabaaaacaaaaaa
egacbaaaacaaaaaaegacbaaaadaaaaaaaaaaaaajpcaabaaaadaaaaaafgafbaia
ebaaaaaaabaaaaaaegiocaaaabaaaaaaadaaaaaadiaaaaahpcaabaaaaeaaaaaa
fgafbaaaaaaaaaaaegaobaaaadaaaaaadiaaaaahpcaabaaaadaaaaaaegaobaaa
adaaaaaaegaobaaaadaaaaaaaaaaaaajpcaabaaaafaaaaaaagaabaiaebaaaaaa
abaaaaaaegiocaaaabaaaaaaacaaaaaaaaaaaaajpcaabaaaabaaaaaakgakbaia
ebaaaaaaabaaaaaaegiocaaaabaaaaaaaeaaaaaadcaaaaajpcaabaaaaeaaaaaa
egaobaaaafaaaaaaagaabaaaaaaaaaaaegaobaaaaeaaaaaadcaaaaajpcaabaaa
aaaaaaaaegaobaaaabaaaaaakgakbaaaaaaaaaaaegaobaaaaeaaaaaadcaaaaaj
pcaabaaaadaaaaaaegaobaaaafaaaaaaegaobaaaafaaaaaaegaobaaaadaaaaaa
dcaaaaajpcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaaabaaaaaaegaobaaa
adaaaaaaeeaaaaafpcaabaaaadaaaaaaegaobaaaabaaaaaadcaaaaanpcaabaaa
abaaaaaaegaobaaaabaaaaaaegiocaaaabaaaaaaafaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaiadpaaaaiadpaoaaaaakpcaabaaaabaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaiadpaaaaiadpegaobaaaabaaaaaadiaaaaahpcaabaaaaaaaaaaa
egaobaaaaaaaaaaaegaobaaaadaaaaaadeaaaaakpcaabaaaaaaaaaaaegaobaaa
aaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaahpcaabaaa
aaaaaaaaegaobaaaabaaaaaaegaobaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgafbaaaaaaaaaaaegiccaaaabaaaaaaahaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaabaaaaaaagaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaabaaaaaaaiaaaaaakgakbaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaajaaaaaapgapbaaa
aaaaaaaaegacbaaaaaaaaaaaaaaaaaahhccabaaaaeaaaaaaegacbaaaaaaaaaaa
egacbaaaacaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform highp vec4 unity_4LightPosX0;
uniform highp vec4 unity_4LightPosY0;
uniform highp vec4 unity_4LightPosZ0;
uniform mediump vec4 unity_4LightAtten0;
uniform mediump vec4 unity_LightColor[8];
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying mediump vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying mediump vec3 xlv_TEXCOORD3;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec3 tmpvar_4;
  tmpvar_4 = (_Object2World * _glesVertex).xyz;
  highp vec4 v_5;
  v_5.x = _World2Object[0].x;
  v_5.y = _World2Object[1].x;
  v_5.z = _World2Object[2].x;
  v_5.w = _World2Object[3].x;
  highp vec4 v_6;
  v_6.x = _World2Object[0].y;
  v_6.y = _World2Object[1].y;
  v_6.z = _World2Object[2].y;
  v_6.w = _World2Object[3].y;
  highp vec4 v_7;
  v_7.x = _World2Object[0].z;
  v_7.y = _World2Object[1].z;
  v_7.z = _World2Object[2].z;
  v_7.w = _World2Object[3].z;
  highp vec3 tmpvar_8;
  tmpvar_8 = normalize(((
    (v_5.xyz * _glesNormal.x)
   + 
    (v_6.xyz * _glesNormal.y)
  ) + (v_7.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_8;
  tmpvar_2 = worldNormal_1;
  lowp vec4 tmpvar_9;
  tmpvar_9.w = 1.0;
  tmpvar_9.xyz = worldNormal_1;
  mediump vec3 tmpvar_10;
  mediump vec4 normal_11;
  normal_11 = tmpvar_9;
  mediump vec3 x2_12;
  mediump vec3 x1_13;
  x1_13.x = dot (unity_SHAr, normal_11);
  x1_13.y = dot (unity_SHAg, normal_11);
  x1_13.z = dot (unity_SHAb, normal_11);
  mediump vec4 tmpvar_14;
  tmpvar_14 = (normal_11.xyzz * normal_11.yzzx);
  x2_12.x = dot (unity_SHBr, tmpvar_14);
  x2_12.y = dot (unity_SHBg, tmpvar_14);
  x2_12.z = dot (unity_SHBb, tmpvar_14);
  tmpvar_10 = ((x2_12 + (unity_SHC.xyz * 
    ((normal_11.x * normal_11.x) - (normal_11.y * normal_11.y))
  )) + x1_13);
  highp vec3 lightColor0_15;
  lightColor0_15 = unity_LightColor[0].xyz;
  highp vec3 lightColor1_16;
  lightColor1_16 = unity_LightColor[1].xyz;
  highp vec3 lightColor2_17;
  lightColor2_17 = unity_LightColor[2].xyz;
  highp vec3 lightColor3_18;
  lightColor3_18 = unity_LightColor[3].xyz;
  highp vec4 lightAttenSq_19;
  lightAttenSq_19 = unity_4LightAtten0;
  highp vec3 normal_20;
  normal_20 = worldNormal_1;
  highp vec4 tmpvar_21;
  tmpvar_21 = (unity_4LightPosX0 - tmpvar_4.x);
  highp vec4 tmpvar_22;
  tmpvar_22 = (unity_4LightPosY0 - tmpvar_4.y);
  highp vec4 tmpvar_23;
  tmpvar_23 = (unity_4LightPosZ0 - tmpvar_4.z);
  highp vec4 tmpvar_24;
  tmpvar_24 = (((tmpvar_21 * tmpvar_21) + (tmpvar_22 * tmpvar_22)) + (tmpvar_23 * tmpvar_23));
  highp vec4 tmpvar_25;
  tmpvar_25 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_21 * normal_20.x) + (tmpvar_22 * normal_20.y)) + (tmpvar_23 * normal_20.z))
   * 
    inversesqrt(tmpvar_24)
  )) * (1.0/((1.0 + 
    (tmpvar_24 * lightAttenSq_19)
  ))));
  highp vec3 tmpvar_26;
  tmpvar_26 = (tmpvar_10 + ((
    ((lightColor0_15 * tmpvar_25.x) + (lightColor1_16 * tmpvar_25.y))
   + 
    (lightColor2_17 * tmpvar_25.z)
  ) + (lightColor3_18 * tmpvar_25.w)));
  tmpvar_3 = tmpvar_26;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = tmpvar_4;
  xlv_TEXCOORD3 = tmpvar_3;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _XYSMap;
varying highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 54 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 160
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityLighting"" 720
Vector 32 [unity_4LightPosX0]
Vector 48 [unity_4LightPosY0]
Vector 64 [unity_4LightPosZ0]
Vector 80 [unity_4LightAtten0]
Vector 96 [unity_LightColor0]
Vector 112 [unity_LightColor1]
Vector 128 [unity_LightColor2]
Vector 144 [unity_LightColor3]
Vector 160 [unity_LightColor4]
Vector 176 [unity_LightColor5]
Vector 192 [unity_LightColor6]
Vector 208 [unity_LightColor7]
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityLighting"" 1
BindCB  ""UnityPerDraw"" 2
""vs_4_0_level_9_1
eefiecedhfiabgpadipjpkbkpinjgdeiokinbjbcabaaaaaajaaoaaaaaeaaaaaa
daaaaaaapaaeaaaapiamaaaapaanaaaaebgpgodjliaeaaaaliaeaaaaaaacpopp
feaeaaaageaaaaaaafaaceaaaaaagaaaaaaagaaaaaaaceaaabaagaaaaaaaajaa
abaaabaaaaaaaaaaabaaacaaaiaaacaaaaaaaaaaabaacgaaahaaakaaaaaaaaaa
acaaaaaaaeaabbaaaaaaaaaaacaaamaaahaabfaaaaaaaaaaaaaaaaaaaaacpopp
fbaaaaafbmaaapkaaaaaiadpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacafaaaaia
aaaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjaaeaaaaae
aaaaadoaadaaoejaabaaoekaabaaookaafaaaaadaaaaabiaacaaaajabjaaaaka
afaaaaadaaaaaciaacaaaajabkaaaakaafaaaaadaaaaaeiaacaaaajablaaaaka
afaaaaadabaaabiaacaaffjabjaaffkaafaaaaadabaaaciaacaaffjabkaaffka
afaaaaadabaaaeiaacaaffjablaaffkaacaaaaadaaaaahiaaaaaoeiaabaaoeia
afaaaaadabaaabiaacaakkjabjaakkkaafaaaaadabaaaciaacaakkjabkaakkka
afaaaaadabaaaeiaacaakkjablaakkkaacaaaaadaaaaahiaaaaaoeiaabaaoeia
ceaaaaacabaaahiaaaaaoeiaafaaaaadaaaaabiaabaaffiaabaaffiaaeaaaaae
aaaaabiaabaaaaiaabaaaaiaaaaaaaibafaaaaadacaaapiaabaacjiaabaakeia
ajaaaaadadaaabiaanaaoekaacaaoeiaajaaaaadadaaaciaaoaaoekaacaaoeia
ajaaaaadadaaaeiaapaaoekaacaaoeiaaeaaaaaeaaaaahiabaaaoekaaaaaaaia
adaaoeiaabaaaaacabaaaiiabmaaaakaajaaaaadacaaabiaakaaoekaabaaoeia
ajaaaaadacaaaciaalaaoekaabaaoeiaajaaaaadacaaaeiaamaaoekaabaaoeia
acaaaaadaaaaahiaaaaaoeiaacaaoeiaafaaaaadacaaahiaaaaaffjabgaaoeka
aeaaaaaeacaaahiabfaaoekaaaaaaajaacaaoeiaaeaaaaaeacaaahiabhaaoeka
aaaakkjaacaaoeiaaeaaaaaeacaaahiabiaaoekaaaaappjaacaaoeiaacaaaaad
adaaapiaacaaffibadaaoekaafaaaaadaeaaapiaabaaffiaadaaoeiaafaaaaad
adaaapiaadaaoeiaadaaoeiaacaaaaadafaaapiaacaaaaibacaaoekaaeaaaaae
aeaaapiaafaaoeiaabaaaaiaaeaaoeiaaeaaaaaeadaaapiaafaaoeiaafaaoeia
adaaoeiaacaaaaadafaaapiaacaakkibaeaaoekaabaaaaacacaaahoaacaaoeia
aeaaaaaeacaaapiaafaaoeiaabaakkiaaeaaoeiaabaaaaacabaaahoaabaaoeia
aeaaaaaeabaaapiaafaaoeiaafaaoeiaadaaoeiaahaaaaacadaaabiaabaaaaia
ahaaaaacadaaaciaabaaffiaahaaaaacadaaaeiaabaakkiaahaaaaacadaaaiia
abaappiaabaaaaacaeaaabiabmaaaakaaeaaaaaeabaaapiaabaaoeiaafaaoeka
aeaaaaiaafaaaaadacaaapiaacaaoeiaadaaoeiaalaaaaadacaaapiaacaaoeia
bmaaffkaagaaaaacadaaabiaabaaaaiaagaaaaacadaaaciaabaaffiaagaaaaac
adaaaeiaabaakkiaagaaaaacadaaaiiaabaappiaafaaaaadabaaapiaacaaoeia
adaaoeiaafaaaaadacaaahiaabaaffiaahaaoekaaeaaaaaeacaaahiaagaaoeka
abaaaaiaacaaoeiaaeaaaaaeabaaahiaaiaaoekaabaakkiaacaaoeiaaeaaaaae
abaaahiaajaaoekaabaappiaabaaoeiaacaaaaadadaaahoaaaaaoeiaabaaoeia
afaaaaadaaaaapiaaaaaffjabcaaoekaaeaaaaaeaaaaapiabbaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaapiabdaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapia
beaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeia
abaaaaacaaaaammaaaaaoeiappppaaaafdeieefcaaaiaaaaeaaaabaaaaacaaaa
fjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaacnaaaaaa
fjaaaaaeegiocaaaacaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaacagaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaa
egbabaaaadaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaa
diaaaaaibcaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabaaaaaaa
diaaaaaiccaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabbaaaaaa
diaaaaaiecaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabcaaaaaa
diaaaaaibcaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabaaaaaaa
diaaaaaiccaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabbaaaaaa
diaaaaaiecaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabcaaaaaa
aaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaai
bcaabaaaabaaaaaackbabaaaacaaaaaackiacaaaacaaaaaabaaaaaaadiaaaaai
ccaabaaaabaaaaaackbabaaaacaaaaaackiacaaaacaaaaaabbaaaaaadiaaaaai
ecaabaaaabaaaaaackbabaaaacaaaaaackiacaaaacaaaaaabcaaaaaaaaaaaaah
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaa
aaaaaaaadgaaaaafhccabaaaacaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaa
abaaaaaafgbfbaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaadaaaaaaegacbaaa
abaaaaaadiaaaaahicaabaaaabaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaa
dcaaaaakicaabaaaabaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaia
ebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaa
aaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaa
acaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaa
acaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaa
acaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaabaaaaaacmaaaaaapgapbaaa
abaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadp
bbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaa
bbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaa
bbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaa
aaaaaaahhcaabaaaacaaaaaaegacbaaaacaaaaaaegacbaaaadaaaaaaaaaaaaaj
pcaabaaaadaaaaaafgafbaiaebaaaaaaabaaaaaaegiocaaaabaaaaaaadaaaaaa
diaaaaahpcaabaaaaeaaaaaafgafbaaaaaaaaaaaegaobaaaadaaaaaadiaaaaah
pcaabaaaadaaaaaaegaobaaaadaaaaaaegaobaaaadaaaaaaaaaaaaajpcaabaaa
afaaaaaaagaabaiaebaaaaaaabaaaaaaegiocaaaabaaaaaaacaaaaaaaaaaaaaj
pcaabaaaabaaaaaakgakbaiaebaaaaaaabaaaaaaegiocaaaabaaaaaaaeaaaaaa
dcaaaaajpcaabaaaaeaaaaaaegaobaaaafaaaaaaagaabaaaaaaaaaaaegaobaaa
aeaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgakbaaaaaaaaaaa
egaobaaaaeaaaaaadcaaaaajpcaabaaaadaaaaaaegaobaaaafaaaaaaegaobaaa
afaaaaaaegaobaaaadaaaaaadcaaaaajpcaabaaaabaaaaaaegaobaaaabaaaaaa
egaobaaaabaaaaaaegaobaaaadaaaaaaeeaaaaafpcaabaaaadaaaaaaegaobaaa
abaaaaaadcaaaaanpcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaaabaaaaaa
afaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpaoaaaaakpcaabaaa
abaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpegaobaaaabaaaaaa
diaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaaadaaaaaadeaaaaak
pcaabaaaaaaaaaaaegaobaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaabaaaaaaegaobaaaaaaaaaaa
diaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaabaaaaaaahaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaaagaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaaiaaaaaa
kgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
abaaaaaaajaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaahhccabaaa
aeaaaaaaegacbaaaaaaaaaaaegacbaaaacaaaaaadoaaaaabejfdeheopaaaaaaa
aiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaa
nbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapadaaaaoaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaa
oaaaaaaaacaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaa
aaaaaaaaadaaaaaaagaaaaaaapaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
ahaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaa
feeffiedepepfceeaaedepemepfcaaklepfdeheojiaaaaaaafaaaaaaaiaaaaaa
iaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaadamaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaahaiaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaa
imaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform highp vec4 unity_4LightPosX0;
uniform highp vec4 unity_4LightPosY0;
uniform highp vec4 unity_4LightPosZ0;
uniform mediump vec4 unity_4LightAtten0;
uniform mediump vec4 unity_LightColor[8];
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out mediump vec3 xlv_TEXCOORD1;
out highp vec3 xlv_TEXCOORD2;
out mediump vec3 xlv_TEXCOORD3;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec3 tmpvar_4;
  tmpvar_4 = (_Object2World * _glesVertex).xyz;
  highp vec4 v_5;
  v_5.x = _World2Object[0].x;
  v_5.y = _World2Object[1].x;
  v_5.z = _World2Object[2].x;
  v_5.w = _World2Object[3].x;
  highp vec4 v_6;
  v_6.x = _World2Object[0].y;
  v_6.y = _World2Object[1].y;
  v_6.z = _World2Object[2].y;
  v_6.w = _World2Object[3].y;
  highp vec4 v_7;
  v_7.x = _World2Object[0].z;
  v_7.y = _World2Object[1].z;
  v_7.z = _World2Object[2].z;
  v_7.w = _World2Object[3].z;
  highp vec3 tmpvar_8;
  tmpvar_8 = normalize(((
    (v_5.xyz * _glesNormal.x)
   + 
    (v_6.xyz * _glesNormal.y)
  ) + (v_7.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_8;
  tmpvar_2 = worldNormal_1;
  lowp vec4 tmpvar_9;
  tmpvar_9.w = 1.0;
  tmpvar_9.xyz = worldNormal_1;
  mediump vec3 tmpvar_10;
  mediump vec4 normal_11;
  normal_11 = tmpvar_9;
  mediump vec3 x2_12;
  mediump vec3 x1_13;
  x1_13.x = dot (unity_SHAr, normal_11);
  x1_13.y = dot (unity_SHAg, normal_11);
  x1_13.z = dot (unity_SHAb, normal_11);
  mediump vec4 tmpvar_14;
  tmpvar_14 = (normal_11.xyzz * normal_11.yzzx);
  x2_12.x = dot (unity_SHBr, tmpvar_14);
  x2_12.y = dot (unity_SHBg, tmpvar_14);
  x2_12.z = dot (unity_SHBb, tmpvar_14);
  tmpvar_10 = ((x2_12 + (unity_SHC.xyz * 
    ((normal_11.x * normal_11.x) - (normal_11.y * normal_11.y))
  )) + x1_13);
  highp vec3 lightColor0_15;
  lightColor0_15 = unity_LightColor[0].xyz;
  highp vec3 lightColor1_16;
  lightColor1_16 = unity_LightColor[1].xyz;
  highp vec3 lightColor2_17;
  lightColor2_17 = unity_LightColor[2].xyz;
  highp vec3 lightColor3_18;
  lightColor3_18 = unity_LightColor[3].xyz;
  highp vec4 lightAttenSq_19;
  lightAttenSq_19 = unity_4LightAtten0;
  highp vec3 normal_20;
  normal_20 = worldNormal_1;
  highp vec4 tmpvar_21;
  tmpvar_21 = (unity_4LightPosX0 - tmpvar_4.x);
  highp vec4 tmpvar_22;
  tmpvar_22 = (unity_4LightPosY0 - tmpvar_4.y);
  highp vec4 tmpvar_23;
  tmpvar_23 = (unity_4LightPosZ0 - tmpvar_4.z);
  highp vec4 tmpvar_24;
  tmpvar_24 = (((tmpvar_21 * tmpvar_21) + (tmpvar_22 * tmpvar_22)) + (tmpvar_23 * tmpvar_23));
  highp vec4 tmpvar_25;
  tmpvar_25 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_21 * normal_20.x) + (tmpvar_22 * normal_20.y)) + (tmpvar_23 * normal_20.z))
   * 
    inversesqrt(tmpvar_24)
  )) * (1.0/((1.0 + 
    (tmpvar_24 * lightAttenSq_19)
  ))));
  highp vec3 tmpvar_26;
  tmpvar_26 = (tmpvar_10 + ((
    ((lightColor0_15 * tmpvar_25.x) + (lightColor1_16 * tmpvar_25.y))
   + 
    (lightColor2_17 * tmpvar_25.z)
  ) + (lightColor3_18 * tmpvar_25.w)));
  tmpvar_3 = tmpvar_26;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = tmpvar_4;
  xlv_TEXCOORD3 = tmpvar_3;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _XYSMap;
in highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  _glesFragData[0] = c_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 52 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
Bind ""texcoord"" ATTR2
ConstBuffer ""$Globals"" 384
Matrix 176 [glstate_matrix_mvp]
Matrix 240 [_Object2World]
Matrix 304 [_World2Object]
Vector 0 [unity_4LightPosX0]
Vector 16 [unity_4LightPosY0]
Vector 32 [unity_4LightPosZ0]
VectorHalf 48 [unity_4LightAtten0] 4
VectorHalf 56 [unity_LightColor0] 4
VectorHalf 64 [unity_LightColor1] 4
VectorHalf 72 [unity_LightColor2] 4
VectorHalf 80 [unity_LightColor3] 4
VectorHalf 88 [unity_LightColor4] 4
VectorHalf 96 [unity_LightColor5] 4
VectorHalf 104 [unity_LightColor6] 4
VectorHalf 112 [unity_LightColor7] 4
VectorHalf 120 [unity_SHAr] 4
VectorHalf 128 [unity_SHAg] 4
VectorHalf 136 [unity_SHAb] 4
VectorHalf 144 [unity_SHBr] 4
VectorHalf 152 [unity_SHBg] 4
VectorHalf 160 [unity_SHBb] 4
VectorHalf 168 [unity_SHC] 4
Vector 368 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
  float4 _glesMultiTexCoord0 [[attribute(2)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  float2 xlv_TEXCOORD0;
  half3 xlv_TEXCOORD1;
  float3 xlv_TEXCOORD2;
  half3 xlv_TEXCOORD3;
};
struct xlatMtlShaderUniform {
  float4 unity_4LightPosX0;
  float4 unity_4LightPosY0;
  float4 unity_4LightPosZ0;
  half4 unity_4LightAtten0;
  half4 unity_LightColor[8];
  half4 unity_SHAr;
  half4 unity_SHAg;
  half4 unity_SHAb;
  half4 unity_SHBr;
  half4 unity_SHBg;
  half4 unity_SHBb;
  half4 unity_SHC;
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  half3 tmpvar_3;
  float3 tmpvar_4;
  tmpvar_4 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].x;
  v_5.y = _mtl_u._World2Object[1].x;
  v_5.z = _mtl_u._World2Object[2].x;
  v_5.w = _mtl_u._World2Object[3].x;
  float4 v_6;
  v_6.x = _mtl_u._World2Object[0].y;
  v_6.y = _mtl_u._World2Object[1].y;
  v_6.z = _mtl_u._World2Object[2].y;
  v_6.w = _mtl_u._World2Object[3].y;
  float4 v_7;
  v_7.x = _mtl_u._World2Object[0].z;
  v_7.y = _mtl_u._World2Object[1].z;
  v_7.z = _mtl_u._World2Object[2].z;
  v_7.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_8;
  tmpvar_8 = normalize(((
    (v_5.xyz * _mtl_i._glesNormal.x)
   + 
    (v_6.xyz * _mtl_i._glesNormal.y)
  ) + (v_7.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_8);
  tmpvar_2 = worldNormal_1;
  half4 tmpvar_9;
  tmpvar_9.w = half(1.0);
  tmpvar_9.xyz = worldNormal_1;
  half3 tmpvar_10;
  half4 normal_11;
  normal_11 = tmpvar_9;
  half3 x2_12;
  half3 x1_13;
  x1_13.x = dot (_mtl_u.unity_SHAr, normal_11);
  x1_13.y = dot (_mtl_u.unity_SHAg, normal_11);
  x1_13.z = dot (_mtl_u.unity_SHAb, normal_11);
  half4 tmpvar_14;
  tmpvar_14 = (normal_11.xyzz * normal_11.yzzx);
  x2_12.x = dot (_mtl_u.unity_SHBr, tmpvar_14);
  x2_12.y = dot (_mtl_u.unity_SHBg, tmpvar_14);
  x2_12.z = dot (_mtl_u.unity_SHBb, tmpvar_14);
  tmpvar_10 = ((x2_12 + (_mtl_u.unity_SHC.xyz * 
    ((normal_11.x * normal_11.x) - (normal_11.y * normal_11.y))
  )) + x1_13);
  float3 lightColor0_15;
  lightColor0_15 = float3(_mtl_u.unity_LightColor[0].xyz);
  float3 lightColor1_16;
  lightColor1_16 = float3(_mtl_u.unity_LightColor[1].xyz);
  float3 lightColor2_17;
  lightColor2_17 = float3(_mtl_u.unity_LightColor[2].xyz);
  float3 lightColor3_18;
  lightColor3_18 = float3(_mtl_u.unity_LightColor[3].xyz);
  float4 lightAttenSq_19;
  lightAttenSq_19 = float4(_mtl_u.unity_4LightAtten0);
  float3 normal_20;
  normal_20 = float3(worldNormal_1);
  float4 tmpvar_21;
  tmpvar_21 = (_mtl_u.unity_4LightPosX0 - tmpvar_4.x);
  float4 tmpvar_22;
  tmpvar_22 = (_mtl_u.unity_4LightPosY0 - tmpvar_4.y);
  float4 tmpvar_23;
  tmpvar_23 = (_mtl_u.unity_4LightPosZ0 - tmpvar_4.z);
  float4 tmpvar_24;
  tmpvar_24 = (((tmpvar_21 * tmpvar_21) + (tmpvar_22 * tmpvar_22)) + (tmpvar_23 * tmpvar_23));
  float4 tmpvar_25;
  tmpvar_25 = (max (float4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_21 * normal_20.x) + (tmpvar_22 * normal_20.y)) + (tmpvar_23 * normal_20.z))
   * 
    rsqrt(tmpvar_24)
  )) * (1.0/((1.0 + 
    (tmpvar_24 * lightAttenSq_19)
  ))));
  float3 tmpvar_26;
  tmpvar_26 = ((float3)tmpvar_10 + ((
    ((lightColor0_15 * tmpvar_25.x) + (lightColor1_16 * tmpvar_25.y))
   + 
    (lightColor2_17 * tmpvar_25.z)
  ) + (lightColor3_18 * tmpvar_25.w)));
  tmpvar_3 = half3(tmpvar_26);
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  _mtl_o.xlv_TEXCOORD1 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD2 = tmpvar_4;
  _mtl_o.xlv_TEXCOORD3 = tmpvar_3;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
""!!GLSL
#ifdef VERTEX
uniform vec4 _ProjectionParams;
uniform vec4 unity_4LightPosX0;
uniform vec4 unity_4LightPosY0;
uniform vec4 unity_4LightPosZ0;
uniform vec4 unity_4LightAtten0;
uniform vec4 unity_LightColor[8];
uniform vec4 unity_SHAr;
uniform vec4 unity_SHAg;
uniform vec4 unity_SHAb;
uniform vec4 unity_SHBr;
uniform vec4 unity_SHBg;
uniform vec4 unity_SHBb;
uniform vec4 unity_SHC;

uniform mat4 _Object2World;
uniform mat4 _World2Object;
uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
varying vec3 xlv_TEXCOORD2;
varying vec3 xlv_TEXCOORD3;
varying vec4 xlv_TEXCOORD4;
void main ()
{
  vec4 tmpvar_1;
  tmpvar_1 = (gl_ModelViewProjectionMatrix * gl_Vertex);
  vec3 tmpvar_2;
  tmpvar_2 = (_Object2World * gl_Vertex).xyz;
  vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * gl_Normal.x)
   + 
    (v_4.xyz * gl_Normal.y)
  ) + (v_5.xyz * gl_Normal.z)));
  vec4 tmpvar_7;
  tmpvar_7.w = 1.0;
  tmpvar_7.xyz = tmpvar_6;
  vec3 x2_8;
  vec3 x1_9;
  x1_9.x = dot (unity_SHAr, tmpvar_7);
  x1_9.y = dot (unity_SHAg, tmpvar_7);
  x1_9.z = dot (unity_SHAb, tmpvar_7);
  vec4 tmpvar_10;
  tmpvar_10 = (tmpvar_6.xyzz * tmpvar_6.yzzx);
  x2_8.x = dot (unity_SHBr, tmpvar_10);
  x2_8.y = dot (unity_SHBg, tmpvar_10);
  x2_8.z = dot (unity_SHBb, tmpvar_10);
  vec4 tmpvar_11;
  tmpvar_11 = (unity_4LightPosX0 - tmpvar_2.x);
  vec4 tmpvar_12;
  tmpvar_12 = (unity_4LightPosY0 - tmpvar_2.y);
  vec4 tmpvar_13;
  tmpvar_13 = (unity_4LightPosZ0 - tmpvar_2.z);
  vec4 tmpvar_14;
  tmpvar_14 = (((tmpvar_11 * tmpvar_11) + (tmpvar_12 * tmpvar_12)) + (tmpvar_13 * tmpvar_13));
  vec4 tmpvar_15;
  tmpvar_15 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_11 * tmpvar_6.x) + (tmpvar_12 * tmpvar_6.y)) + (tmpvar_13 * tmpvar_6.z))
   * 
    inversesqrt(tmpvar_14)
  )) * (1.0/((1.0 + 
    (tmpvar_14 * unity_4LightAtten0)
  ))));
  vec4 o_16;
  vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_1 * 0.5);
  vec2 tmpvar_18;
  tmpvar_18.x = tmpvar_17.x;
  tmpvar_18.y = (tmpvar_17.y * _ProjectionParams.x);
  o_16.xy = (tmpvar_18 + tmpvar_17.w);
  o_16.zw = tmpvar_1.zw;
  gl_Position = tmpvar_1;
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_6;
  xlv_TEXCOORD2 = tmpvar_2;
  xlv_TEXCOORD3 = (((x2_8 + 
    (unity_SHC.xyz * ((tmpvar_6.x * tmpvar_6.x) - (tmpvar_6.y * tmpvar_6.y)))
  ) + x1_9) + ((
    ((unity_LightColor[0].xyz * tmpvar_15.x) + (unity_LightColor[1].xyz * tmpvar_15.y))
   + 
    (unity_LightColor[2].xyz * tmpvar_15.z)
  ) + (unity_LightColor[3].xyz * tmpvar_15.w)));
  xlv_TEXCOORD4 = o_16;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _XYSMap;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  vec4 c_1;
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 61 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
Matrix 8 [_Object2World] 3
Matrix 11 [_World2Object] 3
Matrix 4 [glstate_matrix_mvp]
Vector 27 [_MainTex_ST]
Vector 14 [_ProjectionParams]
Vector 15 [_ScreenParams]
Vector 19 [unity_4LightAtten0]
Vector 16 [unity_4LightPosX0]
Vector 17 [unity_4LightPosY0]
Vector 18 [unity_4LightPosZ0]
Vector 0 [unity_LightColor0]
Vector 1 [unity_LightColor1]
Vector 2 [unity_LightColor2]
Vector 3 [unity_LightColor3]
Vector 22 [unity_SHAb]
Vector 21 [unity_SHAg]
Vector 20 [unity_SHAr]
Vector 25 [unity_SHBb]
Vector 24 [unity_SHBg]
Vector 23 [unity_SHBr]
Vector 26 [unity_SHC]
""vs_2_0
def c28, 1, 0, 0.5, 0
dcl_position v0
dcl_normal v1
dcl_texcoord v2
mad oT0.xy, v2, c27, c27.zwzw
mul r0.xyz, v1.y, c12
mad r0.xyz, c11, v1.x, r0
mad r0.xyz, c13, v1.z, r0
nrm r1.xyz, r0
mul r0.x, r1.y, r1.y
mad r0.x, r1.x, r1.x, -r0.x
mul r2, r1.yzzx, r1.xyzz
dp4 r3.x, c23, r2
dp4 r3.y, c24, r2
dp4 r3.z, c25, r2
mad r0.xyz, c26, r0.x, r3
mov r1.w, c28.x
dp4 r2.x, c20, r1
dp4 r2.y, c21, r1
dp4 r2.z, c22, r1
add r0.xyz, r0, r2
dp4 r2.y, c9, v0
add r3, -r2.y, c17
mul r4, r1.y, r3
mul r3, r3, r3
dp4 r2.x, c8, v0
add r5, -r2.x, c16
mad r4, r5, r1.x, r4
mad r3, r5, r5, r3
dp4 r2.z, c10, v0
add r5, -r2.z, c18
mov oT2.xyz, r2
mad r2, r5, r1.z, r4
mov oT1.xyz, r1
mad r1, r5, r5, r3
rsq r3.x, r1.x
rsq r3.y, r1.y
rsq r3.z, r1.z
rsq r3.w, r1.w
mov r4.x, c28.x
mad r1, r1, c19, r4.x
mul r2, r2, r3
max r2, r2, c28.y
rcp r3.x, r1.x
rcp r3.y, r1.y
rcp r3.z, r1.z
rcp r3.w, r1.w
mul r1, r2, r3
mul r2.xyz, r1.y, c1
mad r2.xyz, c0, r1.x, r2
mad r1.xyz, c2, r1.z, r2
mad r1.xyz, c3, r1.w, r1
add oT3.xyz, r0, r1
dp4 r0.y, c5, v0
mul r1.x, r0.y, c14.x
mul r1.w, r1.x, c28.z
dp4 r0.x, c4, v0
dp4 r0.w, c7, v0
mul r1.xz, r0.xyww, c28.z
mad oT4.xy, r1.z, c15.zwzw, r1.xwzw
dp4 r0.z, c6, v0
mov oPos, r0
mov oT4.zw, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 57 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 160
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityPerCamera"" 144
Vector 80 [_ProjectionParams]
ConstBuffer ""UnityLighting"" 720
Vector 32 [unity_4LightPosX0]
Vector 48 [unity_4LightPosY0]
Vector 64 [unity_4LightPosZ0]
Vector 80 [unity_4LightAtten0]
Vector 96 [unity_LightColor0]
Vector 112 [unity_LightColor1]
Vector 128 [unity_LightColor2]
Vector 144 [unity_LightColor3]
Vector 160 [unity_LightColor4]
Vector 176 [unity_LightColor5]
Vector 192 [unity_LightColor6]
Vector 208 [unity_LightColor7]
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerCamera"" 1
BindCB  ""UnityLighting"" 2
BindCB  ""UnityPerDraw"" 3
""vs_4_0
eefiecedffmbfnggakpegholkgblahffmcdhddiiabaaaaaaimakaaaaadaaaaaa
cmaaaaaaceabaaaanmabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
apaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
kiaiaaaaeaaaabaackacaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaae
egiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaacnaaaaaafjaaaaae
egiocaaaadaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaagiaaaaac
ahaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
pccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaai
bcaabaaaabaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabaaaaaaadiaaaaai
ccaabaaaabaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabbaaaaaadiaaaaai
ecaabaaaabaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabcaaaaaadiaaaaai
bcaabaaaacaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabaaaaaaadiaaaaai
ccaabaaaacaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabbaaaaaadiaaaaai
ecaabaaaacaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabcaaaaaaaaaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaadiaaaaaibcaabaaa
acaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaa
acaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaa
acaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabcaaaaaaaaaaaaahhcaabaaa
abaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaaabaaaaaa
egacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaabaaaaaadkaabaaa
abaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaa
dgaaaaafhccabaaaacaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaa
fgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaa
egiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaacaaaaaadcaaaaak
hcaabaaaacaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
acaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaacaaaaaadgaaaaafhccabaaaadaaaaaaegacbaaaacaaaaaa
diaaaaahicaabaaaacaaaaaabkaabaaaabaaaaaabkaabaaaabaaaaaadcaaaaak
icaabaaaacaaaaaaakaabaaaabaaaaaaakaabaaaabaaaaaadkaabaiaebaaaaaa
acaaaaaadiaaaaahpcaabaaaadaaaaaajgacbaaaabaaaaaaegakbaaaabaaaaaa
bbaaaaaibcaabaaaaeaaaaaaegiocaaaacaaaaaacjaaaaaaegaobaaaadaaaaaa
bbaaaaaiccaabaaaaeaaaaaaegiocaaaacaaaaaackaaaaaaegaobaaaadaaaaaa
bbaaaaaiecaabaaaaeaaaaaaegiocaaaacaaaaaaclaaaaaaegaobaaaadaaaaaa
dcaaaaakhcaabaaaadaaaaaaegiccaaaacaaaaaacmaaaaaapgapbaaaacaaaaaa
egacbaaaaeaaaaaadgaaaaaficaabaaaabaaaaaaabeaaaaaaaaaiadpbbaaaaai
bcaabaaaaeaaaaaaegiocaaaacaaaaaacgaaaaaaegaobaaaabaaaaaabbaaaaai
ccaabaaaaeaaaaaaegiocaaaacaaaaaachaaaaaaegaobaaaabaaaaaabbaaaaai
ecaabaaaaeaaaaaaegiocaaaacaaaaaaciaaaaaaegaobaaaabaaaaaaaaaaaaah
hcaabaaaadaaaaaaegacbaaaadaaaaaaegacbaaaaeaaaaaaaaaaaaajpcaabaaa
aeaaaaaafgafbaiaebaaaaaaacaaaaaaegiocaaaacaaaaaaadaaaaaadiaaaaah
pcaabaaaafaaaaaafgafbaaaabaaaaaaegaobaaaaeaaaaaadiaaaaahpcaabaaa
aeaaaaaaegaobaaaaeaaaaaaegaobaaaaeaaaaaaaaaaaaajpcaabaaaagaaaaaa
agaabaiaebaaaaaaacaaaaaaegiocaaaacaaaaaaacaaaaaaaaaaaaajpcaabaaa
acaaaaaakgakbaiaebaaaaaaacaaaaaaegiocaaaacaaaaaaaeaaaaaadcaaaaaj
pcaabaaaafaaaaaaegaobaaaagaaaaaaagaabaaaabaaaaaaegaobaaaafaaaaaa
dcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaakgakbaaaabaaaaaaegaobaaa
afaaaaaadcaaaaajpcaabaaaaeaaaaaaegaobaaaagaaaaaaegaobaaaagaaaaaa
egaobaaaaeaaaaaadcaaaaajpcaabaaaacaaaaaaegaobaaaacaaaaaaegaobaaa
acaaaaaaegaobaaaaeaaaaaaeeaaaaafpcaabaaaaeaaaaaaegaobaaaacaaaaaa
dcaaaaanpcaabaaaacaaaaaaegaobaaaacaaaaaaegiocaaaacaaaaaaafaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpaoaaaaakpcaabaaaacaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpegaobaaaacaaaaaadiaaaaah
pcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaaaeaaaaaadeaaaaakpcaabaaa
abaaaaaaegaobaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
diaaaaahpcaabaaaabaaaaaaegaobaaaacaaaaaaegaobaaaabaaaaaadiaaaaai
hcaabaaaacaaaaaafgafbaaaabaaaaaaegiccaaaacaaaaaaahaaaaaadcaaaaak
hcaabaaaacaaaaaaegiccaaaacaaaaaaagaaaaaaagaabaaaabaaaaaaegacbaaa
acaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaaaiaaaaaakgakbaaa
abaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaa
ajaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaaaaaaaaahhccabaaaaeaaaaaa
egacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaa
aaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaa
aaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaa
afaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaafaaaaaakgakbaaaabaaaaaa
mgaabaaaabaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform highp vec4 unity_4LightPosX0;
uniform highp vec4 unity_4LightPosY0;
uniform highp vec4 unity_4LightPosZ0;
uniform mediump vec4 unity_4LightAtten0;
uniform mediump vec4 unity_LightColor[8];
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying mediump vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying mediump vec3 xlv_TEXCOORD3;
varying mediump vec4 xlv_TEXCOORD4;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  mediump vec4 tmpvar_4;
  highp vec4 cse_5;
  cse_5 = (_Object2World * _glesVertex);
  highp vec4 v_6;
  v_6.x = _World2Object[0].x;
  v_6.y = _World2Object[1].x;
  v_6.z = _World2Object[2].x;
  v_6.w = _World2Object[3].x;
  highp vec4 v_7;
  v_7.x = _World2Object[0].y;
  v_7.y = _World2Object[1].y;
  v_7.z = _World2Object[2].y;
  v_7.w = _World2Object[3].y;
  highp vec4 v_8;
  v_8.x = _World2Object[0].z;
  v_8.y = _World2Object[1].z;
  v_8.z = _World2Object[2].z;
  v_8.w = _World2Object[3].z;
  highp vec3 tmpvar_9;
  tmpvar_9 = normalize(((
    (v_6.xyz * _glesNormal.x)
   + 
    (v_7.xyz * _glesNormal.y)
  ) + (v_8.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_9;
  tmpvar_2 = worldNormal_1;
  lowp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = worldNormal_1;
  mediump vec3 tmpvar_11;
  mediump vec4 normal_12;
  normal_12 = tmpvar_10;
  mediump vec3 x2_13;
  mediump vec3 x1_14;
  x1_14.x = dot (unity_SHAr, normal_12);
  x1_14.y = dot (unity_SHAg, normal_12);
  x1_14.z = dot (unity_SHAb, normal_12);
  mediump vec4 tmpvar_15;
  tmpvar_15 = (normal_12.xyzz * normal_12.yzzx);
  x2_13.x = dot (unity_SHBr, tmpvar_15);
  x2_13.y = dot (unity_SHBg, tmpvar_15);
  x2_13.z = dot (unity_SHBb, tmpvar_15);
  tmpvar_11 = ((x2_13 + (unity_SHC.xyz * 
    ((normal_12.x * normal_12.x) - (normal_12.y * normal_12.y))
  )) + x1_14);
  highp vec3 lightColor0_16;
  lightColor0_16 = unity_LightColor[0].xyz;
  highp vec3 lightColor1_17;
  lightColor1_17 = unity_LightColor[1].xyz;
  highp vec3 lightColor2_18;
  lightColor2_18 = unity_LightColor[2].xyz;
  highp vec3 lightColor3_19;
  lightColor3_19 = unity_LightColor[3].xyz;
  highp vec4 lightAttenSq_20;
  lightAttenSq_20 = unity_4LightAtten0;
  highp vec3 normal_21;
  normal_21 = worldNormal_1;
  highp vec4 tmpvar_22;
  tmpvar_22 = (unity_4LightPosX0 - cse_5.x);
  highp vec4 tmpvar_23;
  tmpvar_23 = (unity_4LightPosY0 - cse_5.y);
  highp vec4 tmpvar_24;
  tmpvar_24 = (unity_4LightPosZ0 - cse_5.z);
  highp vec4 tmpvar_25;
  tmpvar_25 = (((tmpvar_22 * tmpvar_22) + (tmpvar_23 * tmpvar_23)) + (tmpvar_24 * tmpvar_24));
  highp vec4 tmpvar_26;
  tmpvar_26 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_22 * normal_21.x) + (tmpvar_23 * normal_21.y)) + (tmpvar_24 * normal_21.z))
   * 
    inversesqrt(tmpvar_25)
  )) * (1.0/((1.0 + 
    (tmpvar_25 * lightAttenSq_20)
  ))));
  highp vec3 tmpvar_27;
  tmpvar_27 = (tmpvar_11 + ((
    ((lightColor0_16 * tmpvar_26.x) + (lightColor1_17 * tmpvar_26.y))
   + 
    (lightColor2_18 * tmpvar_26.z)
  ) + (lightColor3_19 * tmpvar_26.w)));
  tmpvar_3 = tmpvar_27;
  highp vec4 tmpvar_28;
  tmpvar_28 = (unity_World2Shadow[0] * cse_5);
  tmpvar_4 = tmpvar_28;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = cse_5.xyz;
  xlv_TEXCOORD3 = tmpvar_3;
  xlv_TEXCOORD4 = tmpvar_4;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _XYSMap;
varying highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""gles "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLES


#ifdef VERTEX

#extension GL_EXT_shadow_samplers : enable
attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying mediump vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying mediump vec3 xlv_TEXCOORD3;
varying mediump vec4 xlv_TEXCOORD4;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  mediump vec4 tmpvar_3;
  highp vec4 v_4;
  v_4.x = _World2Object[0].x;
  v_4.y = _World2Object[1].x;
  v_4.z = _World2Object[2].x;
  v_4.w = _World2Object[3].x;
  highp vec4 v_5;
  v_5.x = _World2Object[0].y;
  v_5.y = _World2Object[1].y;
  v_5.z = _World2Object[2].y;
  v_5.w = _World2Object[3].y;
  highp vec4 v_6;
  v_6.x = _World2Object[0].z;
  v_6.y = _World2Object[1].z;
  v_6.z = _World2Object[2].z;
  v_6.w = _World2Object[3].z;
  highp vec3 tmpvar_7;
  tmpvar_7 = normalize(((
    (v_4.xyz * _glesNormal.x)
   + 
    (v_5.xyz * _glesNormal.y)
  ) + (v_6.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_7;
  tmpvar_2 = worldNormal_1;
  lowp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = worldNormal_1;
  mediump vec4 normal_9;
  normal_9 = tmpvar_8;
  mediump vec3 x2_10;
  mediump vec3 x1_11;
  x1_11.x = dot (unity_SHAr, normal_9);
  x1_11.y = dot (unity_SHAg, normal_9);
  x1_11.z = dot (unity_SHAb, normal_9);
  mediump vec4 tmpvar_12;
  tmpvar_12 = (normal_9.xyzz * normal_9.yzzx);
  x2_10.x = dot (unity_SHBr, tmpvar_12);
  x2_10.y = dot (unity_SHBg, tmpvar_12);
  x2_10.z = dot (unity_SHBb, tmpvar_12);
  highp vec4 tmpvar_13;
  highp vec4 cse_14;
  cse_14 = (_Object2World * _glesVertex);
  tmpvar_13 = (unity_World2Shadow[0] * cse_14);
  tmpvar_3 = tmpvar_13;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = cse_14.xyz;
  xlv_TEXCOORD3 = ((x2_10 + (unity_SHC.xyz * 
    ((normal_9.x * normal_9.x) - (normal_9.y * normal_9.y))
  )) + x1_11);
  xlv_TEXCOORD4 = tmpvar_3;
}



#endif
#ifdef FRAGMENT

#extension GL_EXT_shadow_samplers : enable
uniform sampler2D _XYSMap;
varying highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 42 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 160
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityShadows"" 416
Matrix 128 [unity_World2Shadow0]
Matrix 192 [unity_World2Shadow1]
Matrix 256 [unity_World2Shadow2]
Matrix 320 [unity_World2Shadow3]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityLighting"" 1
BindCB  ""UnityShadows"" 2
BindCB  ""UnityPerDraw"" 3
""vs_4_0_level_9_1
eefiecedoclpebndggpbjdlkdklalohdoflgfolnabaaaaaaaiamaaaaaeaaaaaa
daaaaaaanaadaaaafiakaaaafaalaaaaebgpgodjjiadaaaajiadaaaaaaacpopp
deadaaaageaaaaaaafaaceaaaaaagaaaaaaagaaaaaaaceaaabaagaaaaaaaajaa
abaaabaaaaaaaaaaabaacgaaahaaacaaaaaaaaaaacaaaiaaaeaaajaaaaaaaaaa
adaaaaaaaeaaanaaaaaaaaaaadaaamaaahaabbaaaaaaaaaaaaaaaaaaaaacpopp
fbaaaaafbiaaapkaaaaaiadpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacafaaaaia
aaaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjaaeaaaaae
aaaaadoaadaaoejaabaaoekaabaaookaafaaaaadaaaaahiaaaaaffjabcaaoeka
aeaaaaaeaaaaahiabbaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahiabdaaoeka
aaaakkjaaaaaoeiaaeaaaaaeacaaahoabeaaoekaaaaappjaaaaaoeiaafaaaaad
aaaaabiaacaaaajabfaaaakaafaaaaadaaaaaciaacaaaajabgaaaakaafaaaaad
aaaaaeiaacaaaajabhaaaakaafaaaaadabaaabiaacaaffjabfaaffkaafaaaaad
abaaaciaacaaffjabgaaffkaafaaaaadabaaaeiaacaaffjabhaaffkaacaaaaad
aaaaahiaaaaaoeiaabaaoeiaafaaaaadabaaabiaacaakkjabfaakkkaafaaaaad
abaaaciaacaakkjabgaakkkaafaaaaadabaaaeiaacaakkjabhaakkkaacaaaaad
aaaaahiaaaaaoeiaabaaoeiaceaaaaacabaaahiaaaaaoeiaafaaaaadaaaaabia
abaaffiaabaaffiaaeaaaaaeaaaaabiaabaaaaiaabaaaaiaaaaaaaibafaaaaad
acaaapiaabaacjiaabaakeiaajaaaaadadaaabiaafaaoekaacaaoeiaajaaaaad
adaaaciaagaaoekaacaaoeiaajaaaaadadaaaeiaahaaoekaacaaoeiaaeaaaaae
aaaaahiaaiaaoekaaaaaaaiaadaaoeiaabaaaaacabaaaiiabiaaaakaajaaaaad
acaaabiaacaaoekaabaaoeiaajaaaaadacaaaciaadaaoekaabaaoeiaajaaaaad
acaaaeiaaeaaoekaabaaoeiaabaaaaacabaaahoaabaaoeiaacaaaaadadaaahoa
aaaaoeiaacaaoeiaafaaaaadaaaaapiaaaaaffjabcaaoekaaeaaaaaeaaaaapia
bbaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiabdaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiabeaaoekaaaaappjaaaaaoeiaafaaaaadabaaapiaaaaaffia
akaaoekaaeaaaaaeabaaapiaajaaoekaaaaaaaiaabaaoeiaaeaaaaaeabaaapia
alaaoekaaaaakkiaabaaoeiaaeaaaaaeaeaaapoaamaaoekaaaaappiaabaaoeia
afaaaaadaaaaapiaaaaaffjaaoaaoekaaeaaaaaeaaaaapiaanaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaapiaapaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapia
baaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeia
abaaaaacaaaaammaaaaaoeiappppaaaafdeieefciaagaaaaeaaaabaakaabaaaa
fjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaacnaaaaaa
fjaaaaaeegiocaaaacaaaaaaamaaaaaafjaaaaaeegiocaaaadaaaaaabdaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaa
adaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaa
gfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaa
aeaaaaaagfaaaaadpccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaai
bcaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabaaaaaaadiaaaaai
ccaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabbaaaaaadiaaaaai
ecaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabcaaaaaadiaaaaai
bcaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabaaaaaaadiaaaaai
ccaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabbaaaaaadiaaaaai
ecaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabcaaaaaaaaaaaaah
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaa
abaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaa
abaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaa
abaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabcaaaaaaaaaaaaahhcaabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaa
dgaaaaafhccabaaaacaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaakhccabaaaadaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaabaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaaaaaaaaaa
bkaabaaaaaaaaaaadcaaaaakbcaabaaaabaaaaaaakaabaaaaaaaaaaaakaabaaa
aaaaaaaaakaabaiaebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaa
aaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaa
cjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaa
ckaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaa
claaaaaaegaobaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaa
cmaaaaaaagaabaaaabaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaaaaaaaaaa
abeaaaaaaaaaiadpbbaaaaaibcaabaaaacaaaaaaegiocaaaabaaaaaacgaaaaaa
egaobaaaaaaaaaaabbaaaaaiccaabaaaacaaaaaaegiocaaaabaaaaaachaaaaaa
egaobaaaaaaaaaaabbaaaaaiecaabaaaacaaaaaaegiocaaaabaaaaaaciaaaaaa
egaobaaaaaaaaaaaaaaaaaahhccabaaaaeaaaaaaegacbaaaabaaaaaaegacbaaa
acaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaa
anaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaamaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaai
pcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaaacaaaaaaajaaaaaadcaaaaak
pcaabaaaabaaaaaaegiocaaaacaaaaaaaiaaaaaaagaabaaaaaaaaaaaegaobaaa
abaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaacaaaaaaakaaaaaakgakbaaa
aaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaafaaaaaaegiocaaaacaaaaaa
alaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaadoaaaaabejfdeheopaaaaaaa
aiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaa
nbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapadaaaaoaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaa
oaaaaaaaacaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaa
aaaaaaaaadaaaaaaagaaaaaaapaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
ahaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaa
feeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaa
jiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaa
keaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaafaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out mediump vec3 xlv_TEXCOORD1;
out highp vec3 xlv_TEXCOORD2;
out mediump vec3 xlv_TEXCOORD3;
out mediump vec4 xlv_TEXCOORD4;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  mediump vec4 tmpvar_3;
  highp vec4 v_4;
  v_4.x = _World2Object[0].x;
  v_4.y = _World2Object[1].x;
  v_4.z = _World2Object[2].x;
  v_4.w = _World2Object[3].x;
  highp vec4 v_5;
  v_5.x = _World2Object[0].y;
  v_5.y = _World2Object[1].y;
  v_5.z = _World2Object[2].y;
  v_5.w = _World2Object[3].y;
  highp vec4 v_6;
  v_6.x = _World2Object[0].z;
  v_6.y = _World2Object[1].z;
  v_6.z = _World2Object[2].z;
  v_6.w = _World2Object[3].z;
  highp vec3 tmpvar_7;
  tmpvar_7 = normalize(((
    (v_4.xyz * _glesNormal.x)
   + 
    (v_5.xyz * _glesNormal.y)
  ) + (v_6.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_7;
  tmpvar_2 = worldNormal_1;
  lowp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = worldNormal_1;
  mediump vec4 normal_9;
  normal_9 = tmpvar_8;
  mediump vec3 x2_10;
  mediump vec3 x1_11;
  x1_11.x = dot (unity_SHAr, normal_9);
  x1_11.y = dot (unity_SHAg, normal_9);
  x1_11.z = dot (unity_SHAb, normal_9);
  mediump vec4 tmpvar_12;
  tmpvar_12 = (normal_9.xyzz * normal_9.yzzx);
  x2_10.x = dot (unity_SHBr, tmpvar_12);
  x2_10.y = dot (unity_SHBg, tmpvar_12);
  x2_10.z = dot (unity_SHBb, tmpvar_12);
  highp vec4 tmpvar_13;
  highp vec4 cse_14;
  cse_14 = (_Object2World * _glesVertex);
  tmpvar_13 = (unity_World2Shadow[0] * cse_14);
  tmpvar_3 = tmpvar_13;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = cse_14.xyz;
  xlv_TEXCOORD3 = ((x2_10 + (unity_SHC.xyz * 
    ((normal_9.x * normal_9.x) - (normal_9.y * normal_9.y))
  )) + x1_11);
  xlv_TEXCOORD4 = tmpvar_3;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _XYSMap;
in highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  _glesFragData[0] = c_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 25 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
Bind ""texcoord"" ATTR2
ConstBuffer ""$Globals"" 528
Matrix 64 [unity_World2Shadow0]
Matrix 128 [unity_World2Shadow1]
Matrix 192 [unity_World2Shadow2]
Matrix 256 [unity_World2Shadow3]
Matrix 320 [glstate_matrix_mvp]
Matrix 384 [_Object2World]
Matrix 448 [_World2Object]
VectorHalf 0 [unity_SHAr] 4
VectorHalf 8 [unity_SHAg] 4
VectorHalf 16 [unity_SHAb] 4
VectorHalf 24 [unity_SHBr] 4
VectorHalf 32 [unity_SHBg] 4
VectorHalf 40 [unity_SHBb] 4
VectorHalf 48 [unity_SHC] 4
Vector 512 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
  float4 _glesMultiTexCoord0 [[attribute(2)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  float2 xlv_TEXCOORD0;
  half3 xlv_TEXCOORD1;
  float3 xlv_TEXCOORD2;
  half3 xlv_TEXCOORD3;
  half4 xlv_TEXCOORD4;
};
struct xlatMtlShaderUniform {
  half4 unity_SHAr;
  half4 unity_SHAg;
  half4 unity_SHAb;
  half4 unity_SHBr;
  half4 unity_SHBg;
  half4 unity_SHBb;
  half4 unity_SHC;
  float4x4 unity_World2Shadow[4];
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  half4 tmpvar_3;
  float4 v_4;
  v_4.x = _mtl_u._World2Object[0].x;
  v_4.y = _mtl_u._World2Object[1].x;
  v_4.z = _mtl_u._World2Object[2].x;
  v_4.w = _mtl_u._World2Object[3].x;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].y;
  v_5.y = _mtl_u._World2Object[1].y;
  v_5.z = _mtl_u._World2Object[2].y;
  v_5.w = _mtl_u._World2Object[3].y;
  float4 v_6;
  v_6.x = _mtl_u._World2Object[0].z;
  v_6.y = _mtl_u._World2Object[1].z;
  v_6.z = _mtl_u._World2Object[2].z;
  v_6.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_7;
  tmpvar_7 = normalize(((
    (v_4.xyz * _mtl_i._glesNormal.x)
   + 
    (v_5.xyz * _mtl_i._glesNormal.y)
  ) + (v_6.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_7);
  tmpvar_2 = worldNormal_1;
  half4 tmpvar_8;
  tmpvar_8.w = half(1.0);
  tmpvar_8.xyz = worldNormal_1;
  half4 normal_9;
  normal_9 = tmpvar_8;
  half3 x2_10;
  half3 x1_11;
  x1_11.x = dot (_mtl_u.unity_SHAr, normal_9);
  x1_11.y = dot (_mtl_u.unity_SHAg, normal_9);
  x1_11.z = dot (_mtl_u.unity_SHAb, normal_9);
  half4 tmpvar_12;
  tmpvar_12 = (normal_9.xyzz * normal_9.yzzx);
  x2_10.x = dot (_mtl_u.unity_SHBr, tmpvar_12);
  x2_10.y = dot (_mtl_u.unity_SHBg, tmpvar_12);
  x2_10.z = dot (_mtl_u.unity_SHBb, tmpvar_12);
  float4 tmpvar_13;
  float4 cse_14;
  cse_14 = (_mtl_u._Object2World * _mtl_i._glesVertex);
  tmpvar_13 = (_mtl_u.unity_World2Shadow[0] * cse_14);
  tmpvar_3 = half4(tmpvar_13);
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  _mtl_o.xlv_TEXCOORD1 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD2 = cse_14.xyz;
  _mtl_o.xlv_TEXCOORD3 = ((x2_10 + (_mtl_u.unity_SHC.xyz * 
    ((normal_9.x * normal_9.x) - (normal_9.y * normal_9.y))
  )) + x1_11);
  _mtl_o.xlv_TEXCOORD4 = tmpvar_3;
  return _mtl_o;
}

""
}
SubProgram ""gles "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
""!!GLES


#ifdef VERTEX

#extension GL_EXT_shadow_samplers : enable
attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform highp vec4 unity_4LightPosX0;
uniform highp vec4 unity_4LightPosY0;
uniform highp vec4 unity_4LightPosZ0;
uniform mediump vec4 unity_4LightAtten0;
uniform mediump vec4 unity_LightColor[8];
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying mediump vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying mediump vec3 xlv_TEXCOORD3;
varying mediump vec4 xlv_TEXCOORD4;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  mediump vec4 tmpvar_4;
  highp vec4 cse_5;
  cse_5 = (_Object2World * _glesVertex);
  highp vec4 v_6;
  v_6.x = _World2Object[0].x;
  v_6.y = _World2Object[1].x;
  v_6.z = _World2Object[2].x;
  v_6.w = _World2Object[3].x;
  highp vec4 v_7;
  v_7.x = _World2Object[0].y;
  v_7.y = _World2Object[1].y;
  v_7.z = _World2Object[2].y;
  v_7.w = _World2Object[3].y;
  highp vec4 v_8;
  v_8.x = _World2Object[0].z;
  v_8.y = _World2Object[1].z;
  v_8.z = _World2Object[2].z;
  v_8.w = _World2Object[3].z;
  highp vec3 tmpvar_9;
  tmpvar_9 = normalize(((
    (v_6.xyz * _glesNormal.x)
   + 
    (v_7.xyz * _glesNormal.y)
  ) + (v_8.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_9;
  tmpvar_2 = worldNormal_1;
  lowp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = worldNormal_1;
  mediump vec3 tmpvar_11;
  mediump vec4 normal_12;
  normal_12 = tmpvar_10;
  mediump vec3 x2_13;
  mediump vec3 x1_14;
  x1_14.x = dot (unity_SHAr, normal_12);
  x1_14.y = dot (unity_SHAg, normal_12);
  x1_14.z = dot (unity_SHAb, normal_12);
  mediump vec4 tmpvar_15;
  tmpvar_15 = (normal_12.xyzz * normal_12.yzzx);
  x2_13.x = dot (unity_SHBr, tmpvar_15);
  x2_13.y = dot (unity_SHBg, tmpvar_15);
  x2_13.z = dot (unity_SHBb, tmpvar_15);
  tmpvar_11 = ((x2_13 + (unity_SHC.xyz * 
    ((normal_12.x * normal_12.x) - (normal_12.y * normal_12.y))
  )) + x1_14);
  highp vec3 lightColor0_16;
  lightColor0_16 = unity_LightColor[0].xyz;
  highp vec3 lightColor1_17;
  lightColor1_17 = unity_LightColor[1].xyz;
  highp vec3 lightColor2_18;
  lightColor2_18 = unity_LightColor[2].xyz;
  highp vec3 lightColor3_19;
  lightColor3_19 = unity_LightColor[3].xyz;
  highp vec4 lightAttenSq_20;
  lightAttenSq_20 = unity_4LightAtten0;
  highp vec3 normal_21;
  normal_21 = worldNormal_1;
  highp vec4 tmpvar_22;
  tmpvar_22 = (unity_4LightPosX0 - cse_5.x);
  highp vec4 tmpvar_23;
  tmpvar_23 = (unity_4LightPosY0 - cse_5.y);
  highp vec4 tmpvar_24;
  tmpvar_24 = (unity_4LightPosZ0 - cse_5.z);
  highp vec4 tmpvar_25;
  tmpvar_25 = (((tmpvar_22 * tmpvar_22) + (tmpvar_23 * tmpvar_23)) + (tmpvar_24 * tmpvar_24));
  highp vec4 tmpvar_26;
  tmpvar_26 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_22 * normal_21.x) + (tmpvar_23 * normal_21.y)) + (tmpvar_24 * normal_21.z))
   * 
    inversesqrt(tmpvar_25)
  )) * (1.0/((1.0 + 
    (tmpvar_25 * lightAttenSq_20)
  ))));
  highp vec3 tmpvar_27;
  tmpvar_27 = (tmpvar_11 + ((
    ((lightColor0_16 * tmpvar_26.x) + (lightColor1_17 * tmpvar_26.y))
   + 
    (lightColor2_18 * tmpvar_26.z)
  ) + (lightColor3_19 * tmpvar_26.w)));
  tmpvar_3 = tmpvar_27;
  highp vec4 tmpvar_28;
  tmpvar_28 = (unity_World2Shadow[0] * cse_5);
  tmpvar_4 = tmpvar_28;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = cse_5.xyz;
  xlv_TEXCOORD3 = tmpvar_3;
  xlv_TEXCOORD4 = tmpvar_4;
}



#endif
#ifdef FRAGMENT

#extension GL_EXT_shadow_samplers : enable
uniform sampler2D _XYSMap;
varying highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 62 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 160
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityLighting"" 720
Vector 32 [unity_4LightPosX0]
Vector 48 [unity_4LightPosY0]
Vector 64 [unity_4LightPosZ0]
Vector 80 [unity_4LightAtten0]
Vector 96 [unity_LightColor0]
Vector 112 [unity_LightColor1]
Vector 128 [unity_LightColor2]
Vector 144 [unity_LightColor3]
Vector 160 [unity_LightColor4]
Vector 176 [unity_LightColor5]
Vector 192 [unity_LightColor6]
Vector 208 [unity_LightColor7]
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityShadows"" 416
Matrix 128 [unity_World2Shadow0]
Matrix 192 [unity_World2Shadow1]
Matrix 256 [unity_World2Shadow2]
Matrix 320 [unity_World2Shadow3]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityLighting"" 1
BindCB  ""UnityShadows"" 2
BindCB  ""UnityPerDraw"" 3
""vs_4_0_level_9_1
eefiecednmahkeobmpalhpiapnkijpkpegbldoboabaaaaaajibaaaaaaeaaaaaa
daaaaaaajeafaaaaoiaoaaaaoaapaaaaebgpgodjfmafaaaafmafaaaaaaacpopp
omaeaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaajaa
abaaabaaaaaaaaaaabaaacaaaiaaacaaaaaaaaaaabaacgaaahaaakaaaaaaaaaa
acaaaiaaaeaabbaaaaaaaaaaadaaaaaaaeaabfaaaaaaaaaaadaaamaaahaabjaa
aaaaaaaaaaaaaaaaaaacpoppfbaaaaafcaaaapkaaaaaiadpaaaaaaaaaaaaaaaa
aaaaaaaabpaaaaacafaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjabpaaaaac
afaaadiaadaaapjaaeaaaaaeaaaaadoaadaaoejaabaaoekaabaaookaafaaaaad
aaaaabiaacaaaajabnaaaakaafaaaaadaaaaaciaacaaaajaboaaaakaafaaaaad
aaaaaeiaacaaaajabpaaaakaafaaaaadabaaabiaacaaffjabnaaffkaafaaaaad
abaaaciaacaaffjaboaaffkaafaaaaadabaaaeiaacaaffjabpaaffkaacaaaaad
aaaaahiaaaaaoeiaabaaoeiaafaaaaadabaaabiaacaakkjabnaakkkaafaaaaad
abaaaciaacaakkjaboaakkkaafaaaaadabaaaeiaacaakkjabpaakkkaacaaaaad
aaaaahiaaaaaoeiaabaaoeiaceaaaaacabaaahiaaaaaoeiaafaaaaadaaaaabia
abaaffiaabaaffiaaeaaaaaeaaaaabiaabaaaaiaabaaaaiaaaaaaaibafaaaaad
acaaapiaabaacjiaabaakeiaajaaaaadadaaabiaanaaoekaacaaoeiaajaaaaad
adaaaciaaoaaoekaacaaoeiaajaaaaadadaaaeiaapaaoekaacaaoeiaaeaaaaae
aaaaahiabaaaoekaaaaaaaiaadaaoeiaabaaaaacabaaaiiacaaaaakaajaaaaad
acaaabiaakaaoekaabaaoeiaajaaaaadacaaaciaalaaoekaabaaoeiaajaaaaad
acaaaeiaamaaoekaabaaoeiaacaaaaadaaaaahiaaaaaoeiaacaaoeiaafaaaaad
acaaahiaaaaaffjabkaaoekaaeaaaaaeacaaahiabjaaoekaaaaaaajaacaaoeia
aeaaaaaeacaaahiablaaoekaaaaakkjaacaaoeiaaeaaaaaeacaaahiabmaaoeka
aaaappjaacaaoeiaacaaaaadadaaapiaacaaffibadaaoekaafaaaaadaeaaapia
abaaffiaadaaoeiaafaaaaadadaaapiaadaaoeiaadaaoeiaacaaaaadafaaapia
acaaaaibacaaoekaaeaaaaaeaeaaapiaafaaoeiaabaaaaiaaeaaoeiaaeaaaaae
adaaapiaafaaoeiaafaaoeiaadaaoeiaacaaaaadafaaapiaacaakkibaeaaoeka
abaaaaacacaaahoaacaaoeiaaeaaaaaeacaaapiaafaaoeiaabaakkiaaeaaoeia
abaaaaacabaaahoaabaaoeiaaeaaaaaeabaaapiaafaaoeiaafaaoeiaadaaoeia
ahaaaaacadaaabiaabaaaaiaahaaaaacadaaaciaabaaffiaahaaaaacadaaaeia
abaakkiaahaaaaacadaaaiiaabaappiaabaaaaacaeaaabiacaaaaakaaeaaaaae
abaaapiaabaaoeiaafaaoekaaeaaaaiaafaaaaadacaaapiaacaaoeiaadaaoeia
alaaaaadacaaapiaacaaoeiacaaaffkaagaaaaacadaaabiaabaaaaiaagaaaaac
adaaaciaabaaffiaagaaaaacadaaaeiaabaakkiaagaaaaacadaaaiiaabaappia
afaaaaadabaaapiaacaaoeiaadaaoeiaafaaaaadacaaahiaabaaffiaahaaoeka
aeaaaaaeacaaahiaagaaoekaabaaaaiaacaaoeiaaeaaaaaeabaaahiaaiaaoeka
abaakkiaacaaoeiaaeaaaaaeabaaahiaajaaoekaabaappiaabaaoeiaacaaaaad
adaaahoaaaaaoeiaabaaoeiaafaaaaadaaaaapiaaaaaffjabkaaoekaaeaaaaae
aaaaapiabjaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiablaaoekaaaaakkja
aaaaoeiaaeaaaaaeaaaaapiabmaaoekaaaaappjaaaaaoeiaafaaaaadabaaapia
aaaaffiabcaaoekaaeaaaaaeabaaapiabbaaoekaaaaaaaiaabaaoeiaaeaaaaae
abaaapiabdaaoekaaaaakkiaabaaoeiaaeaaaaaeaeaaapoabeaaoekaaaaappia
abaaoeiaafaaaaadaaaaapiaaaaaffjabgaaoekaaeaaaaaeaaaaapiabfaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaapiabhaaoekaaaaakkjaaaaaoeiaaeaaaaae
aaaaapiabiaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoeka
aaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefcemajaaaaeaaaabaa
fdacaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaa
cnaaaaaafjaaaaaeegiocaaaacaaaaaaamaaaaaafjaaaaaeegiocaaaadaaaaaa
bdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaagiaaaaacagaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaadaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaa
egbabaaaadaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaa
diaaaaaibcaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabaaaaaaa
diaaaaaiccaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabbaaaaaa
diaaaaaiecaabaaaaaaaaaaaakbabaaaacaaaaaaakiacaaaadaaaaaabcaaaaaa
diaaaaaibcaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabaaaaaaa
diaaaaaiccaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabbaaaaaa
diaaaaaiecaabaaaabaaaaaabkbabaaaacaaaaaabkiacaaaadaaaaaabcaaaaaa
aaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaai
bcaabaaaabaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabaaaaaaadiaaaaai
ccaabaaaabaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabbaaaaaadiaaaaai
ecaabaaaabaaaaaackbabaaaacaaaaaackiacaaaadaaaaaabcaaaaaaaaaaaaah
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaa
aaaaaaaadgaaaaafhccabaaaacaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaa
abaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaadaaaaaaegacbaaa
abaaaaaadiaaaaahicaabaaaabaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaa
dcaaaaakicaabaaaabaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaia
ebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaa
aaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaa
acaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaa
acaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaa
acaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaabaaaaaacmaaaaaapgapbaaa
abaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadp
bbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaa
bbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaa
bbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaa
aaaaaaahhcaabaaaacaaaaaaegacbaaaacaaaaaaegacbaaaadaaaaaaaaaaaaaj
pcaabaaaadaaaaaafgafbaiaebaaaaaaabaaaaaaegiocaaaabaaaaaaadaaaaaa
diaaaaahpcaabaaaaeaaaaaafgafbaaaaaaaaaaaegaobaaaadaaaaaadiaaaaah
pcaabaaaadaaaaaaegaobaaaadaaaaaaegaobaaaadaaaaaaaaaaaaajpcaabaaa
afaaaaaaagaabaiaebaaaaaaabaaaaaaegiocaaaabaaaaaaacaaaaaaaaaaaaaj
pcaabaaaabaaaaaakgakbaiaebaaaaaaabaaaaaaegiocaaaabaaaaaaaeaaaaaa
dcaaaaajpcaabaaaaeaaaaaaegaobaaaafaaaaaaagaabaaaaaaaaaaaegaobaaa
aeaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgakbaaaaaaaaaaa
egaobaaaaeaaaaaadcaaaaajpcaabaaaadaaaaaaegaobaaaafaaaaaaegaobaaa
afaaaaaaegaobaaaadaaaaaadcaaaaajpcaabaaaabaaaaaaegaobaaaabaaaaaa
egaobaaaabaaaaaaegaobaaaadaaaaaaeeaaaaafpcaabaaaadaaaaaaegaobaaa
abaaaaaadcaaaaanpcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaaabaaaaaa
afaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpaoaaaaakpcaabaaa
abaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpegaobaaaabaaaaaa
diaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaaadaaaaaadeaaaaak
pcaabaaaaaaaaaaaegaobaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaabaaaaaaegaobaaaaaaaaaaa
diaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaabaaaaaaahaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaaagaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaaiaaaaaa
kgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
abaaaaaaajaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaahhccabaaa
aeaaaaaaegacbaaaaaaaaaaaegacbaaaacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaadaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaipcaabaaaabaaaaaafgafbaaaaaaaaaaa
egiocaaaacaaaaaaajaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaacaaaaaa
aiaaaaaaagaabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaa
egiocaaaacaaaaaaakaaaaaakgakbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaak
pccabaaaafaaaaaaegiocaaaacaaaaaaalaaaaaapgapbaaaaaaaaaaaegaobaaa
abaaaaaadoaaaaabejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaa
oaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaaabaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaaadaaaaaa
afaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaaapaaaaaa
ojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdejfeejepeo
aafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaakl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform highp vec4 unity_4LightPosX0;
uniform highp vec4 unity_4LightPosY0;
uniform highp vec4 unity_4LightPosZ0;
uniform mediump vec4 unity_4LightAtten0;
uniform mediump vec4 unity_LightColor[8];
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out mediump vec3 xlv_TEXCOORD1;
out highp vec3 xlv_TEXCOORD2;
out mediump vec3 xlv_TEXCOORD3;
out mediump vec4 xlv_TEXCOORD4;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  mediump vec4 tmpvar_4;
  highp vec4 cse_5;
  cse_5 = (_Object2World * _glesVertex);
  highp vec4 v_6;
  v_6.x = _World2Object[0].x;
  v_6.y = _World2Object[1].x;
  v_6.z = _World2Object[2].x;
  v_6.w = _World2Object[3].x;
  highp vec4 v_7;
  v_7.x = _World2Object[0].y;
  v_7.y = _World2Object[1].y;
  v_7.z = _World2Object[2].y;
  v_7.w = _World2Object[3].y;
  highp vec4 v_8;
  v_8.x = _World2Object[0].z;
  v_8.y = _World2Object[1].z;
  v_8.z = _World2Object[2].z;
  v_8.w = _World2Object[3].z;
  highp vec3 tmpvar_9;
  tmpvar_9 = normalize(((
    (v_6.xyz * _glesNormal.x)
   + 
    (v_7.xyz * _glesNormal.y)
  ) + (v_8.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_9;
  tmpvar_2 = worldNormal_1;
  lowp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = worldNormal_1;
  mediump vec3 tmpvar_11;
  mediump vec4 normal_12;
  normal_12 = tmpvar_10;
  mediump vec3 x2_13;
  mediump vec3 x1_14;
  x1_14.x = dot (unity_SHAr, normal_12);
  x1_14.y = dot (unity_SHAg, normal_12);
  x1_14.z = dot (unity_SHAb, normal_12);
  mediump vec4 tmpvar_15;
  tmpvar_15 = (normal_12.xyzz * normal_12.yzzx);
  x2_13.x = dot (unity_SHBr, tmpvar_15);
  x2_13.y = dot (unity_SHBg, tmpvar_15);
  x2_13.z = dot (unity_SHBb, tmpvar_15);
  tmpvar_11 = ((x2_13 + (unity_SHC.xyz * 
    ((normal_12.x * normal_12.x) - (normal_12.y * normal_12.y))
  )) + x1_14);
  highp vec3 lightColor0_16;
  lightColor0_16 = unity_LightColor[0].xyz;
  highp vec3 lightColor1_17;
  lightColor1_17 = unity_LightColor[1].xyz;
  highp vec3 lightColor2_18;
  lightColor2_18 = unity_LightColor[2].xyz;
  highp vec3 lightColor3_19;
  lightColor3_19 = unity_LightColor[3].xyz;
  highp vec4 lightAttenSq_20;
  lightAttenSq_20 = unity_4LightAtten0;
  highp vec3 normal_21;
  normal_21 = worldNormal_1;
  highp vec4 tmpvar_22;
  tmpvar_22 = (unity_4LightPosX0 - cse_5.x);
  highp vec4 tmpvar_23;
  tmpvar_23 = (unity_4LightPosY0 - cse_5.y);
  highp vec4 tmpvar_24;
  tmpvar_24 = (unity_4LightPosZ0 - cse_5.z);
  highp vec4 tmpvar_25;
  tmpvar_25 = (((tmpvar_22 * tmpvar_22) + (tmpvar_23 * tmpvar_23)) + (tmpvar_24 * tmpvar_24));
  highp vec4 tmpvar_26;
  tmpvar_26 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_22 * normal_21.x) + (tmpvar_23 * normal_21.y)) + (tmpvar_24 * normal_21.z))
   * 
    inversesqrt(tmpvar_25)
  )) * (1.0/((1.0 + 
    (tmpvar_25 * lightAttenSq_20)
  ))));
  highp vec3 tmpvar_27;
  tmpvar_27 = (tmpvar_11 + ((
    ((lightColor0_16 * tmpvar_26.x) + (lightColor1_17 * tmpvar_26.y))
   + 
    (lightColor2_18 * tmpvar_26.z)
  ) + (lightColor3_19 * tmpvar_26.w)));
  tmpvar_3 = tmpvar_27;
  highp vec4 tmpvar_28;
  tmpvar_28 = (unity_World2Shadow[0] * cse_5);
  tmpvar_4 = tmpvar_28;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = cse_5.xyz;
  xlv_TEXCOORD3 = tmpvar_3;
  xlv_TEXCOORD4 = tmpvar_4;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _XYSMap;
in highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  _glesFragData[0] = c_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 53 math
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""VERTEXLIGHT_ON"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
Bind ""texcoord"" ATTR2
ConstBuffer ""$Globals"" 640
Matrix 176 [unity_World2Shadow0]
Matrix 240 [unity_World2Shadow1]
Matrix 304 [unity_World2Shadow2]
Matrix 368 [unity_World2Shadow3]
Matrix 432 [glstate_matrix_mvp]
Matrix 496 [_Object2World]
Matrix 560 [_World2Object]
Vector 0 [unity_4LightPosX0]
Vector 16 [unity_4LightPosY0]
Vector 32 [unity_4LightPosZ0]
VectorHalf 48 [unity_4LightAtten0] 4
VectorHalf 56 [unity_LightColor0] 4
VectorHalf 64 [unity_LightColor1] 4
VectorHalf 72 [unity_LightColor2] 4
VectorHalf 80 [unity_LightColor3] 4
VectorHalf 88 [unity_LightColor4] 4
VectorHalf 96 [unity_LightColor5] 4
VectorHalf 104 [unity_LightColor6] 4
VectorHalf 112 [unity_LightColor7] 4
VectorHalf 120 [unity_SHAr] 4
VectorHalf 128 [unity_SHAg] 4
VectorHalf 136 [unity_SHAb] 4
VectorHalf 144 [unity_SHBr] 4
VectorHalf 152 [unity_SHBg] 4
VectorHalf 160 [unity_SHBb] 4
VectorHalf 168 [unity_SHC] 4
Vector 624 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
  float4 _glesMultiTexCoord0 [[attribute(2)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  float2 xlv_TEXCOORD0;
  half3 xlv_TEXCOORD1;
  float3 xlv_TEXCOORD2;
  half3 xlv_TEXCOORD3;
  half4 xlv_TEXCOORD4;
};
struct xlatMtlShaderUniform {
  float4 unity_4LightPosX0;
  float4 unity_4LightPosY0;
  float4 unity_4LightPosZ0;
  half4 unity_4LightAtten0;
  half4 unity_LightColor[8];
  half4 unity_SHAr;
  half4 unity_SHAg;
  half4 unity_SHAb;
  half4 unity_SHBr;
  half4 unity_SHBg;
  half4 unity_SHBb;
  half4 unity_SHC;
  float4x4 unity_World2Shadow[4];
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  half3 tmpvar_3;
  half4 tmpvar_4;
  float4 cse_5;
  cse_5 = (_mtl_u._Object2World * _mtl_i._glesVertex);
  float4 v_6;
  v_6.x = _mtl_u._World2Object[0].x;
  v_6.y = _mtl_u._World2Object[1].x;
  v_6.z = _mtl_u._World2Object[2].x;
  v_6.w = _mtl_u._World2Object[3].x;
  float4 v_7;
  v_7.x = _mtl_u._World2Object[0].y;
  v_7.y = _mtl_u._World2Object[1].y;
  v_7.z = _mtl_u._World2Object[2].y;
  v_7.w = _mtl_u._World2Object[3].y;
  float4 v_8;
  v_8.x = _mtl_u._World2Object[0].z;
  v_8.y = _mtl_u._World2Object[1].z;
  v_8.z = _mtl_u._World2Object[2].z;
  v_8.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_9;
  tmpvar_9 = normalize(((
    (v_6.xyz * _mtl_i._glesNormal.x)
   + 
    (v_7.xyz * _mtl_i._glesNormal.y)
  ) + (v_8.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_9);
  tmpvar_2 = worldNormal_1;
  half4 tmpvar_10;
  tmpvar_10.w = half(1.0);
  tmpvar_10.xyz = worldNormal_1;
  half3 tmpvar_11;
  half4 normal_12;
  normal_12 = tmpvar_10;
  half3 x2_13;
  half3 x1_14;
  x1_14.x = dot (_mtl_u.unity_SHAr, normal_12);
  x1_14.y = dot (_mtl_u.unity_SHAg, normal_12);
  x1_14.z = dot (_mtl_u.unity_SHAb, normal_12);
  half4 tmpvar_15;
  tmpvar_15 = (normal_12.xyzz * normal_12.yzzx);
  x2_13.x = dot (_mtl_u.unity_SHBr, tmpvar_15);
  x2_13.y = dot (_mtl_u.unity_SHBg, tmpvar_15);
  x2_13.z = dot (_mtl_u.unity_SHBb, tmpvar_15);
  tmpvar_11 = ((x2_13 + (_mtl_u.unity_SHC.xyz * 
    ((normal_12.x * normal_12.x) - (normal_12.y * normal_12.y))
  )) + x1_14);
  float3 lightColor0_16;
  lightColor0_16 = float3(_mtl_u.unity_LightColor[0].xyz);
  float3 lightColor1_17;
  lightColor1_17 = float3(_mtl_u.unity_LightColor[1].xyz);
  float3 lightColor2_18;
  lightColor2_18 = float3(_mtl_u.unity_LightColor[2].xyz);
  float3 lightColor3_19;
  lightColor3_19 = float3(_mtl_u.unity_LightColor[3].xyz);
  float4 lightAttenSq_20;
  lightAttenSq_20 = float4(_mtl_u.unity_4LightAtten0);
  float3 normal_21;
  normal_21 = float3(worldNormal_1);
  float4 tmpvar_22;
  tmpvar_22 = (_mtl_u.unity_4LightPosX0 - cse_5.x);
  float4 tmpvar_23;
  tmpvar_23 = (_mtl_u.unity_4LightPosY0 - cse_5.y);
  float4 tmpvar_24;
  tmpvar_24 = (_mtl_u.unity_4LightPosZ0 - cse_5.z);
  float4 tmpvar_25;
  tmpvar_25 = (((tmpvar_22 * tmpvar_22) + (tmpvar_23 * tmpvar_23)) + (tmpvar_24 * tmpvar_24));
  float4 tmpvar_26;
  tmpvar_26 = (max (float4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_22 * normal_21.x) + (tmpvar_23 * normal_21.y)) + (tmpvar_24 * normal_21.z))
   * 
    rsqrt(tmpvar_25)
  )) * (1.0/((1.0 + 
    (tmpvar_25 * lightAttenSq_20)
  ))));
  float3 tmpvar_27;
  tmpvar_27 = ((float3)tmpvar_11 + ((
    ((lightColor0_16 * tmpvar_26.x) + (lightColor1_17 * tmpvar_26.y))
   + 
    (lightColor2_18 * tmpvar_26.z)
  ) + (lightColor3_19 * tmpvar_26.w)));
  tmpvar_3 = half3(tmpvar_27);
  float4 tmpvar_28;
  tmpvar_28 = (_mtl_u.unity_World2Shadow[0] * cse_5);
  tmpvar_4 = half4(tmpvar_28);
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  _mtl_o.xlv_TEXCOORD1 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD2 = cse_5.xyz;
  _mtl_o.xlv_TEXCOORD3 = tmpvar_3;
  _mtl_o.xlv_TEXCOORD4 = tmpvar_4;
  return _mtl_o;
}

""
}
}
Program ""fp"" {
SubProgram ""opengl "" {
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 3 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_2_0
def c0, 1, 0, 0, 0
dcl t0.xy
dcl_2d s0
texld_pp r0, t0, s0
add_pp r0.xyz, -r0.z, r0.y
mov_pp r0.w, c0.x
mov_pp oC0, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 1 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0
eefiecedkjakljbjdemcbkdkfpbcablfkldfhgihabaaaaaakiabaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefckaaaaaaaeaaaaaaaciaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacabaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaaihccabaaaaaaaaaaakgakbaia
ebaaaaaaaaaaaaaafgafbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaa
aaaaiadpdoaaaaab""
}
SubProgram ""gles "" {
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
// Stats: 1 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0_level_9_1
eefiecedegnmokjdfhkokapbldoknpjkakkjlggbabaaaaaaemacaaaaaeaaaaaa
daaaaaaanaaaaaaahiabaaaabiacaaaaebgpgodjjiaaaaaajiaaaaaaaaacpppp
haaaaaaaciaaaaaaaaaaciaaaaaaciaaaaaaciaaabaaceaaaaaaciaaaaaaaaaa
aaacppppfbaaaaafaaaaapkaaaaaiadpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaac
aaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapkaecaaaaadaaaacpiaaaaaoela
aaaioekaacaaaaadaaaachiaaaaakkibaaaaffiaabaaaaacaaaaciiaaaaaaaka
abaaaaacaaaicpiaaaaaoeiappppaaaafdeieefckaaaaaaaeaaaaaaaciaaaaaa
fkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacabaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
aaaaaaaihccabaaaaaaaaaaakgakbaiaebaaaaaaaaaaaaaafgafbaaaaaaaaaaa
dgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaabejfdeheojiaaaaaa
afaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
imaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaaimaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahaaaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaaaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_OFF"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float2 xlv_TEXCOORD0;
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]]
  ,   texture2d<half> _XYSMap [[texture(0)]], sampler _mtlsmp__XYSMap [[sampler(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 c_1;
  half4 tmpvar_2;
  tmpvar_2 = _XYSMap.sample(_mtlsmp__XYSMap, (float2)(_mtl_i.xlv_TEXCOORD0));
  half3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = half(1.0);
  _mtl_o._glesFragData_0 = c_1;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 3 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_2_0
def c0, 1, 0, 0, 0
dcl t0.xy
dcl_2d s0
texld_pp r0, t0, s0
add_pp r0.xyz, -r0.z, r0.y
mov_pp r0.w, c0.x
mov_pp oC0, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 1 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0
eefiecedeboijhmnbgdkiflafninheihilbkflofabaaaaaamaabaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefckaaaaaaa
eaaaaaaaciaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
abaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaaaaaaaaaihccabaaaaaaaaaaakgakbaiaebaaaaaaaaaaaaaa
fgafbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab
""
}
SubProgram ""gles "" {
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLES""
}
SubProgram ""gles "" {
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
// Stats: 1 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0_level_9_1
eefiecedjnjffkfjnaiogegdiffkanmfoenlkchdabaaaaaahiacaaaaafaaaaaa
deaaaaaaneaaaaaahmabaaaaimabaaaaeeacaaaaebgpgodjjiaaaaaajiaaaaaa
aaacpppphaaaaaaaciaaaaaaaaaaciaaaaaaciaaaaaaciaaabaaceaaaaaaciaa
aaaaaaaaaaacppppfbaaaaafaaaaapkaaaaaiadpaaaaaaaaaaaaaaaaaaaaaaaa
bpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapkaecaaaaadaaaacpia
aaaaoelaaaaioekaacaaaaadaaaachiaaaaakkibaaaaffiaabaaaaacaaaaciia
aaaaaakaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefckaaaaaaaeaaaaaaa
ciaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
gcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacabaaaaaa
efaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaaaaaaaaaihccabaaaaaaaaaaakgakbaiaebaaaaaaaaaaaaaafgafbaaa
aaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaabfdegejda
aiaaaaaaiaaaaaaaaaaaaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 4 math, 1 textures
Keywords { ""DIRECTIONAL"" ""SHADOWS_SCREEN"" ""SHADOWS_NATIVE"" ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float2 xlv_TEXCOORD0;
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]]
  ,   texture2d<half> _XYSMap [[texture(0)]], sampler _mtlsmp__XYSMap [[sampler(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 c_1;
  half4 tmpvar_2;
  tmpvar_2 = _XYSMap.sample(_mtlsmp__XYSMap, (float2)(_mtl_i.xlv_TEXCOORD0));
  half3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = half(1.0);
  _mtl_o._glesFragData_0 = c_1;
  return _mtl_o;
}

""
}
}
 }


 // Stats for Vertex shader:
 //       d3d11 : 22 math
 //    d3d11_9x : 22 math
 //        d3d9 : 13 math
 //        gles : 2 math
 //       gles3 : 2 math
 //       metal : 8 math
 //      opengl : 2 math
 // Stats for Fragment shader:
 //        d3d9 : 1 math
 //       metal : 2 math
 Pass {
  Name ""FORWARD""
  Tags { ""LIGHTMODE""=""ForwardAdd"" ""ForceNoShadowCasting""=""true"" ""RenderType""=""Opaque"" }
  ZWrite Off
  Blend One One
  GpuProgramID 91185
Program ""vp"" {
SubProgram ""opengl "" {
// Stats: 2 math
Keywords { ""POINT"" }
""!!GLSL
#ifdef VERTEX

uniform mat4 _Object2World;
uniform mat4 _World2Object;
varying vec3 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
void main ()
{
  vec4 v_1;
  v_1.x = _World2Object[0].x;
  v_1.y = _World2Object[1].x;
  v_1.z = _World2Object[2].x;
  v_1.w = _World2Object[3].x;
  vec4 v_2;
  v_2.x = _World2Object[0].y;
  v_2.y = _World2Object[1].y;
  v_2.z = _World2Object[2].y;
  v_2.w = _World2Object[3].y;
  vec4 v_3;
  v_3.x = _World2Object[0].z;
  v_3.y = _World2Object[1].z;
  v_3.z = _World2Object[2].z;
  v_3.w = _World2Object[3].z;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = normalize(((
    (v_1.xyz * gl_Normal.x)
   + 
    (v_2.xyz * gl_Normal.y)
  ) + (v_3.xyz * gl_Normal.z)));
  xlv_TEXCOORD1 = (_Object2World * gl_Vertex).xyz;
}


#endif
#ifdef FRAGMENT
void main ()
{
  vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 13 math
Keywords { ""POINT"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
""vs_2_0
dcl_position v0
dcl_normal v1
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
dp4 oT1.x, c4, v0
dp4 oT1.y, c5, v0
dp4 oT1.z, c6, v0
mul r0.xyz, v1.y, c8
mad r0.xyz, c7, v1.x, r0
mad r0.xyz, c9, v1.z, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul oT0.xyz, r0.w, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 22 math
Keywords { ""POINT"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0
eefiecedinidogaapcaihlhlafeaicjabdmdpgobabaaaaaaneaeaaaaadaaaaaa
cmaaaaaaceabaaaajeabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcdiadaaaaeaaaabaa
moaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
hccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hccabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 2 math
Keywords { ""POINT"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
varying mediump vec3 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT

void main ()
{
  lowp vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 22 math
Keywords { ""POINT"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0_level_9_1
eefiecedfimbpiggiminkfbhlgdjijhgmgblgjidabaaaaaaneagaaaaaeaaaaaa
daaaaaaacmacaaaagmafaaaageagaaaaebgpgodjpeabaaaapeabaaaaaaacpopp
leabaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaaaa
aeaaabaaaaaaaaaaaaaaamaaahaaafaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjaafaaaaadaaaaahiaaaaaffja
agaaoekaaeaaaaaeaaaaahiaafaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahia
ahaaoekaaaaakkjaaaaaoeiaaeaaaaaeabaaahoaaiaaoekaaaaappjaaaaaoeia
afaaaaadaaaaabiaacaaaajaajaaaakaafaaaaadaaaaaciaacaaaajaakaaaaka
afaaaaadaaaaaeiaacaaaajaalaaaakaafaaaaadabaaabiaacaaffjaajaaffka
afaaaaadabaaaciaacaaffjaakaaffkaafaaaaadabaaaeiaacaaffjaalaaffka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaafaaaaadabaaabiaacaakkjaajaakkka
afaaaaadabaaaciaacaakkjaakaakkkaafaaaaadabaaaeiaacaakkjaalaakkka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaaiaaaaadaaaaaiiaaaaaoeiaaaaaoeia
ahaaaaacaaaaaiiaaaaappiaafaaaaadaaaaahoaaaaappiaaaaaoeiaafaaaaad
aaaaapiaaaaaffjaacaaoekaaeaaaaaeaaaaapiaabaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaadaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiappppaaaafdeieefcdiadaaaaeaaaabaamoaaaaaafjaaaaae
egiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadhccabaaaabaaaaaa
gfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
aaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaaaaaaaaadoaaaaabejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 2 math
Keywords { ""POINT"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
out mediump vec3 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
void main ()
{
  lowp vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  _glesFragData[0] = c_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 8 math
Keywords { ""POINT"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
ConstBuffer ""$Globals"" 192
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [_Object2World]
Matrix 128 [_World2Object]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  half3 xlv_TEXCOORD0;
  float3 xlv_TEXCOORD1;
};
struct xlatMtlShaderUniform {
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  float4 v_3;
  v_3.x = _mtl_u._World2Object[0].x;
  v_3.y = _mtl_u._World2Object[1].x;
  v_3.z = _mtl_u._World2Object[2].x;
  v_3.w = _mtl_u._World2Object[3].x;
  float4 v_4;
  v_4.x = _mtl_u._World2Object[0].y;
  v_4.y = _mtl_u._World2Object[1].y;
  v_4.z = _mtl_u._World2Object[2].y;
  v_4.w = _mtl_u._World2Object[3].y;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].z;
  v_5.y = _mtl_u._World2Object[1].z;
  v_5.z = _mtl_u._World2Object[2].z;
  v_5.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _mtl_i._glesNormal.x)
   + 
    (v_4.xyz * _mtl_i._glesNormal.y)
  ) + (v_5.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_6);
  tmpvar_2 = worldNormal_1;
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD1 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
// Stats: 2 math
Keywords { ""DIRECTIONAL"" }
""!!GLSL
#ifdef VERTEX

uniform mat4 _Object2World;
uniform mat4 _World2Object;
varying vec3 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
void main ()
{
  vec4 v_1;
  v_1.x = _World2Object[0].x;
  v_1.y = _World2Object[1].x;
  v_1.z = _World2Object[2].x;
  v_1.w = _World2Object[3].x;
  vec4 v_2;
  v_2.x = _World2Object[0].y;
  v_2.y = _World2Object[1].y;
  v_2.z = _World2Object[2].y;
  v_2.w = _World2Object[3].y;
  vec4 v_3;
  v_3.x = _World2Object[0].z;
  v_3.y = _World2Object[1].z;
  v_3.z = _World2Object[2].z;
  v_3.w = _World2Object[3].z;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = normalize(((
    (v_1.xyz * gl_Normal.x)
   + 
    (v_2.xyz * gl_Normal.y)
  ) + (v_3.xyz * gl_Normal.z)));
  xlv_TEXCOORD1 = (_Object2World * gl_Vertex).xyz;
}


#endif
#ifdef FRAGMENT
void main ()
{
  vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 13 math
Keywords { ""DIRECTIONAL"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
""vs_2_0
dcl_position v0
dcl_normal v1
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
dp4 oT1.x, c4, v0
dp4 oT1.y, c5, v0
dp4 oT1.z, c6, v0
mul r0.xyz, v1.y, c8
mad r0.xyz, c7, v1.x, r0
mad r0.xyz, c9, v1.z, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul oT0.xyz, r0.w, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 22 math
Keywords { ""DIRECTIONAL"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0
eefiecedinidogaapcaihlhlafeaicjabdmdpgobabaaaaaaneaeaaaaadaaaaaa
cmaaaaaaceabaaaajeabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcdiadaaaaeaaaabaa
moaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
hccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hccabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 2 math
Keywords { ""DIRECTIONAL"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
varying mediump vec3 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT

void main ()
{
  lowp vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 22 math
Keywords { ""DIRECTIONAL"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0_level_9_1
eefiecedfimbpiggiminkfbhlgdjijhgmgblgjidabaaaaaaneagaaaaaeaaaaaa
daaaaaaacmacaaaagmafaaaageagaaaaebgpgodjpeabaaaapeabaaaaaaacpopp
leabaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaaaa
aeaaabaaaaaaaaaaaaaaamaaahaaafaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjaafaaaaadaaaaahiaaaaaffja
agaaoekaaeaaaaaeaaaaahiaafaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahia
ahaaoekaaaaakkjaaaaaoeiaaeaaaaaeabaaahoaaiaaoekaaaaappjaaaaaoeia
afaaaaadaaaaabiaacaaaajaajaaaakaafaaaaadaaaaaciaacaaaajaakaaaaka
afaaaaadaaaaaeiaacaaaajaalaaaakaafaaaaadabaaabiaacaaffjaajaaffka
afaaaaadabaaaciaacaaffjaakaaffkaafaaaaadabaaaeiaacaaffjaalaaffka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaafaaaaadabaaabiaacaakkjaajaakkka
afaaaaadabaaaciaacaakkjaakaakkkaafaaaaadabaaaeiaacaakkjaalaakkka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaaiaaaaadaaaaaiiaaaaaoeiaaaaaoeia
ahaaaaacaaaaaiiaaaaappiaafaaaaadaaaaahoaaaaappiaaaaaoeiaafaaaaad
aaaaapiaaaaaffjaacaaoekaaeaaaaaeaaaaapiaabaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaadaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiappppaaaafdeieefcdiadaaaaeaaaabaamoaaaaaafjaaaaae
egiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadhccabaaaabaaaaaa
gfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
aaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaaaaaaaaadoaaaaabejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 2 math
Keywords { ""DIRECTIONAL"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
out mediump vec3 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
void main ()
{
  lowp vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  _glesFragData[0] = c_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 8 math
Keywords { ""DIRECTIONAL"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
ConstBuffer ""$Globals"" 192
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [_Object2World]
Matrix 128 [_World2Object]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  half3 xlv_TEXCOORD0;
  float3 xlv_TEXCOORD1;
};
struct xlatMtlShaderUniform {
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  float4 v_3;
  v_3.x = _mtl_u._World2Object[0].x;
  v_3.y = _mtl_u._World2Object[1].x;
  v_3.z = _mtl_u._World2Object[2].x;
  v_3.w = _mtl_u._World2Object[3].x;
  float4 v_4;
  v_4.x = _mtl_u._World2Object[0].y;
  v_4.y = _mtl_u._World2Object[1].y;
  v_4.z = _mtl_u._World2Object[2].y;
  v_4.w = _mtl_u._World2Object[3].y;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].z;
  v_5.y = _mtl_u._World2Object[1].z;
  v_5.z = _mtl_u._World2Object[2].z;
  v_5.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _mtl_i._glesNormal.x)
   + 
    (v_4.xyz * _mtl_i._glesNormal.y)
  ) + (v_5.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_6);
  tmpvar_2 = worldNormal_1;
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD1 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
// Stats: 2 math
Keywords { ""SPOT"" }
""!!GLSL
#ifdef VERTEX

uniform mat4 _Object2World;
uniform mat4 _World2Object;
varying vec3 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
void main ()
{
  vec4 v_1;
  v_1.x = _World2Object[0].x;
  v_1.y = _World2Object[1].x;
  v_1.z = _World2Object[2].x;
  v_1.w = _World2Object[3].x;
  vec4 v_2;
  v_2.x = _World2Object[0].y;
  v_2.y = _World2Object[1].y;
  v_2.z = _World2Object[2].y;
  v_2.w = _World2Object[3].y;
  vec4 v_3;
  v_3.x = _World2Object[0].z;
  v_3.y = _World2Object[1].z;
  v_3.z = _World2Object[2].z;
  v_3.w = _World2Object[3].z;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = normalize(((
    (v_1.xyz * gl_Normal.x)
   + 
    (v_2.xyz * gl_Normal.y)
  ) + (v_3.xyz * gl_Normal.z)));
  xlv_TEXCOORD1 = (_Object2World * gl_Vertex).xyz;
}


#endif
#ifdef FRAGMENT
void main ()
{
  vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 13 math
Keywords { ""SPOT"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
""vs_2_0
dcl_position v0
dcl_normal v1
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
dp4 oT1.x, c4, v0
dp4 oT1.y, c5, v0
dp4 oT1.z, c6, v0
mul r0.xyz, v1.y, c8
mad r0.xyz, c7, v1.x, r0
mad r0.xyz, c9, v1.z, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul oT0.xyz, r0.w, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 22 math
Keywords { ""SPOT"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0
eefiecedinidogaapcaihlhlafeaicjabdmdpgobabaaaaaaneaeaaaaadaaaaaa
cmaaaaaaceabaaaajeabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcdiadaaaaeaaaabaa
moaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
hccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hccabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 2 math
Keywords { ""SPOT"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
varying mediump vec3 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT

void main ()
{
  lowp vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 22 math
Keywords { ""SPOT"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0_level_9_1
eefiecedfimbpiggiminkfbhlgdjijhgmgblgjidabaaaaaaneagaaaaaeaaaaaa
daaaaaaacmacaaaagmafaaaageagaaaaebgpgodjpeabaaaapeabaaaaaaacpopp
leabaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaaaa
aeaaabaaaaaaaaaaaaaaamaaahaaafaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjaafaaaaadaaaaahiaaaaaffja
agaaoekaaeaaaaaeaaaaahiaafaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahia
ahaaoekaaaaakkjaaaaaoeiaaeaaaaaeabaaahoaaiaaoekaaaaappjaaaaaoeia
afaaaaadaaaaabiaacaaaajaajaaaakaafaaaaadaaaaaciaacaaaajaakaaaaka
afaaaaadaaaaaeiaacaaaajaalaaaakaafaaaaadabaaabiaacaaffjaajaaffka
afaaaaadabaaaciaacaaffjaakaaffkaafaaaaadabaaaeiaacaaffjaalaaffka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaafaaaaadabaaabiaacaakkjaajaakkka
afaaaaadabaaaciaacaakkjaakaakkkaafaaaaadabaaaeiaacaakkjaalaakkka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaaiaaaaadaaaaaiiaaaaaoeiaaaaaoeia
ahaaaaacaaaaaiiaaaaappiaafaaaaadaaaaahoaaaaappiaaaaaoeiaafaaaaad
aaaaapiaaaaaffjaacaaoekaaeaaaaaeaaaaapiaabaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaadaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiappppaaaafdeieefcdiadaaaaeaaaabaamoaaaaaafjaaaaae
egiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadhccabaaaabaaaaaa
gfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
aaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaaaaaaaaadoaaaaabejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 2 math
Keywords { ""SPOT"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
out mediump vec3 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
void main ()
{
  lowp vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  _glesFragData[0] = c_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 8 math
Keywords { ""SPOT"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
ConstBuffer ""$Globals"" 192
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [_Object2World]
Matrix 128 [_World2Object]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  half3 xlv_TEXCOORD0;
  float3 xlv_TEXCOORD1;
};
struct xlatMtlShaderUniform {
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  float4 v_3;
  v_3.x = _mtl_u._World2Object[0].x;
  v_3.y = _mtl_u._World2Object[1].x;
  v_3.z = _mtl_u._World2Object[2].x;
  v_3.w = _mtl_u._World2Object[3].x;
  float4 v_4;
  v_4.x = _mtl_u._World2Object[0].y;
  v_4.y = _mtl_u._World2Object[1].y;
  v_4.z = _mtl_u._World2Object[2].y;
  v_4.w = _mtl_u._World2Object[3].y;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].z;
  v_5.y = _mtl_u._World2Object[1].z;
  v_5.z = _mtl_u._World2Object[2].z;
  v_5.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _mtl_i._glesNormal.x)
   + 
    (v_4.xyz * _mtl_i._glesNormal.y)
  ) + (v_5.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_6);
  tmpvar_2 = worldNormal_1;
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD1 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
// Stats: 2 math
Keywords { ""POINT_COOKIE"" }
""!!GLSL
#ifdef VERTEX

uniform mat4 _Object2World;
uniform mat4 _World2Object;
varying vec3 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
void main ()
{
  vec4 v_1;
  v_1.x = _World2Object[0].x;
  v_1.y = _World2Object[1].x;
  v_1.z = _World2Object[2].x;
  v_1.w = _World2Object[3].x;
  vec4 v_2;
  v_2.x = _World2Object[0].y;
  v_2.y = _World2Object[1].y;
  v_2.z = _World2Object[2].y;
  v_2.w = _World2Object[3].y;
  vec4 v_3;
  v_3.x = _World2Object[0].z;
  v_3.y = _World2Object[1].z;
  v_3.z = _World2Object[2].z;
  v_3.w = _World2Object[3].z;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = normalize(((
    (v_1.xyz * gl_Normal.x)
   + 
    (v_2.xyz * gl_Normal.y)
  ) + (v_3.xyz * gl_Normal.z)));
  xlv_TEXCOORD1 = (_Object2World * gl_Vertex).xyz;
}


#endif
#ifdef FRAGMENT
void main ()
{
  vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 13 math
Keywords { ""POINT_COOKIE"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
""vs_2_0
dcl_position v0
dcl_normal v1
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
dp4 oT1.x, c4, v0
dp4 oT1.y, c5, v0
dp4 oT1.z, c6, v0
mul r0.xyz, v1.y, c8
mad r0.xyz, c7, v1.x, r0
mad r0.xyz, c9, v1.z, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul oT0.xyz, r0.w, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 22 math
Keywords { ""POINT_COOKIE"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0
eefiecedinidogaapcaihlhlafeaicjabdmdpgobabaaaaaaneaeaaaaadaaaaaa
cmaaaaaaceabaaaajeabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcdiadaaaaeaaaabaa
moaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
hccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hccabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 2 math
Keywords { ""POINT_COOKIE"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
varying mediump vec3 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT

void main ()
{
  lowp vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 22 math
Keywords { ""POINT_COOKIE"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0_level_9_1
eefiecedfimbpiggiminkfbhlgdjijhgmgblgjidabaaaaaaneagaaaaaeaaaaaa
daaaaaaacmacaaaagmafaaaageagaaaaebgpgodjpeabaaaapeabaaaaaaacpopp
leabaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaaaa
aeaaabaaaaaaaaaaaaaaamaaahaaafaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjaafaaaaadaaaaahiaaaaaffja
agaaoekaaeaaaaaeaaaaahiaafaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahia
ahaaoekaaaaakkjaaaaaoeiaaeaaaaaeabaaahoaaiaaoekaaaaappjaaaaaoeia
afaaaaadaaaaabiaacaaaajaajaaaakaafaaaaadaaaaaciaacaaaajaakaaaaka
afaaaaadaaaaaeiaacaaaajaalaaaakaafaaaaadabaaabiaacaaffjaajaaffka
afaaaaadabaaaciaacaaffjaakaaffkaafaaaaadabaaaeiaacaaffjaalaaffka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaafaaaaadabaaabiaacaakkjaajaakkka
afaaaaadabaaaciaacaakkjaakaakkkaafaaaaadabaaaeiaacaakkjaalaakkka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaaiaaaaadaaaaaiiaaaaaoeiaaaaaoeia
ahaaaaacaaaaaiiaaaaappiaafaaaaadaaaaahoaaaaappiaaaaaoeiaafaaaaad
aaaaapiaaaaaffjaacaaoekaaeaaaaaeaaaaapiaabaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaadaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiappppaaaafdeieefcdiadaaaaeaaaabaamoaaaaaafjaaaaae
egiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadhccabaaaabaaaaaa
gfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
aaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaaaaaaaaadoaaaaabejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 2 math
Keywords { ""POINT_COOKIE"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
out mediump vec3 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
void main ()
{
  lowp vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  _glesFragData[0] = c_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 8 math
Keywords { ""POINT_COOKIE"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
ConstBuffer ""$Globals"" 192
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [_Object2World]
Matrix 128 [_World2Object]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  half3 xlv_TEXCOORD0;
  float3 xlv_TEXCOORD1;
};
struct xlatMtlShaderUniform {
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  float4 v_3;
  v_3.x = _mtl_u._World2Object[0].x;
  v_3.y = _mtl_u._World2Object[1].x;
  v_3.z = _mtl_u._World2Object[2].x;
  v_3.w = _mtl_u._World2Object[3].x;
  float4 v_4;
  v_4.x = _mtl_u._World2Object[0].y;
  v_4.y = _mtl_u._World2Object[1].y;
  v_4.z = _mtl_u._World2Object[2].y;
  v_4.w = _mtl_u._World2Object[3].y;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].z;
  v_5.y = _mtl_u._World2Object[1].z;
  v_5.z = _mtl_u._World2Object[2].z;
  v_5.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _mtl_i._glesNormal.x)
   + 
    (v_4.xyz * _mtl_i._glesNormal.y)
  ) + (v_5.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_6);
  tmpvar_2 = worldNormal_1;
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD1 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
// Stats: 2 math
Keywords { ""DIRECTIONAL_COOKIE"" }
""!!GLSL
#ifdef VERTEX

uniform mat4 _Object2World;
uniform mat4 _World2Object;
varying vec3 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
void main ()
{
  vec4 v_1;
  v_1.x = _World2Object[0].x;
  v_1.y = _World2Object[1].x;
  v_1.z = _World2Object[2].x;
  v_1.w = _World2Object[3].x;
  vec4 v_2;
  v_2.x = _World2Object[0].y;
  v_2.y = _World2Object[1].y;
  v_2.z = _World2Object[2].y;
  v_2.w = _World2Object[3].y;
  vec4 v_3;
  v_3.x = _World2Object[0].z;
  v_3.y = _World2Object[1].z;
  v_3.z = _World2Object[2].z;
  v_3.w = _World2Object[3].z;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = normalize(((
    (v_1.xyz * gl_Normal.x)
   + 
    (v_2.xyz * gl_Normal.y)
  ) + (v_3.xyz * gl_Normal.z)));
  xlv_TEXCOORD1 = (_Object2World * gl_Vertex).xyz;
}


#endif
#ifdef FRAGMENT
void main ()
{
  vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 13 math
Keywords { ""DIRECTIONAL_COOKIE"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
""vs_2_0
dcl_position v0
dcl_normal v1
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
dp4 oT1.x, c4, v0
dp4 oT1.y, c5, v0
dp4 oT1.z, c6, v0
mul r0.xyz, v1.y, c8
mad r0.xyz, c7, v1.x, r0
mad r0.xyz, c9, v1.z, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul oT0.xyz, r0.w, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 22 math
Keywords { ""DIRECTIONAL_COOKIE"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0
eefiecedinidogaapcaihlhlafeaicjabdmdpgobabaaaaaaneaeaaaaadaaaaaa
cmaaaaaaceabaaaajeabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcdiadaaaaeaaaabaa
moaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
hccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hccabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 2 math
Keywords { ""DIRECTIONAL_COOKIE"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
varying mediump vec3 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT

void main ()
{
  lowp vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 22 math
Keywords { ""DIRECTIONAL_COOKIE"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0_level_9_1
eefiecedfimbpiggiminkfbhlgdjijhgmgblgjidabaaaaaaneagaaaaaeaaaaaa
daaaaaaacmacaaaagmafaaaageagaaaaebgpgodjpeabaaaapeabaaaaaaacpopp
leabaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaaaa
aeaaabaaaaaaaaaaaaaaamaaahaaafaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjaafaaaaadaaaaahiaaaaaffja
agaaoekaaeaaaaaeaaaaahiaafaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahia
ahaaoekaaaaakkjaaaaaoeiaaeaaaaaeabaaahoaaiaaoekaaaaappjaaaaaoeia
afaaaaadaaaaabiaacaaaajaajaaaakaafaaaaadaaaaaciaacaaaajaakaaaaka
afaaaaadaaaaaeiaacaaaajaalaaaakaafaaaaadabaaabiaacaaffjaajaaffka
afaaaaadabaaaciaacaaffjaakaaffkaafaaaaadabaaaeiaacaaffjaalaaffka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaafaaaaadabaaabiaacaakkjaajaakkka
afaaaaadabaaaciaacaakkjaakaakkkaafaaaaadabaaaeiaacaakkjaalaakkka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaaiaaaaadaaaaaiiaaaaaoeiaaaaaoeia
ahaaaaacaaaaaiiaaaaappiaafaaaaadaaaaahoaaaaappiaaaaaoeiaafaaaaad
aaaaapiaaaaaffjaacaaoekaaeaaaaaeaaaaapiaabaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaadaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiappppaaaafdeieefcdiadaaaaeaaaabaamoaaaaaafjaaaaae
egiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadhccabaaaabaaaaaa
gfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
aaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaaaaaaaaadoaaaaabejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 2 math
Keywords { ""DIRECTIONAL_COOKIE"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
out mediump vec3 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
void main ()
{
  lowp vec4 c_1;
  c_1.xyz = vec3(0.0, 0.0, 0.0);
  c_1.w = 1.0;
  _glesFragData[0] = c_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 8 math
Keywords { ""DIRECTIONAL_COOKIE"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
ConstBuffer ""$Globals"" 192
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [_Object2World]
Matrix 128 [_World2Object]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  half3 xlv_TEXCOORD0;
  float3 xlv_TEXCOORD1;
};
struct xlatMtlShaderUniform {
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  float4 v_3;
  v_3.x = _mtl_u._World2Object[0].x;
  v_3.y = _mtl_u._World2Object[1].x;
  v_3.z = _mtl_u._World2Object[2].x;
  v_3.w = _mtl_u._World2Object[3].x;
  float4 v_4;
  v_4.x = _mtl_u._World2Object[0].y;
  v_4.y = _mtl_u._World2Object[1].y;
  v_4.z = _mtl_u._World2Object[2].y;
  v_4.w = _mtl_u._World2Object[3].y;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].z;
  v_5.y = _mtl_u._World2Object[1].z;
  v_5.z = _mtl_u._World2Object[2].z;
  v_5.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _mtl_i._glesNormal.x)
   + 
    (v_4.xyz * _mtl_i._glesNormal.y)
  ) + (v_5.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_6);
  tmpvar_2 = worldNormal_1;
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD1 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  return _mtl_o;
}

""
}
}
Program ""fp"" {
SubProgram ""opengl "" {
Keywords { ""POINT"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 1 math
Keywords { ""POINT"" }
""ps_2_0
def c0, 0, 0, 0, 1
mov_pp oC0, c0

""
}
SubProgram ""d3d11 "" {
Keywords { ""POINT"" }
""ps_4_0
eefiecedpdipnlijaafddlnglckhfpnipdngegoeabaaaaaabaabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdiaaaaaaeaaaaaaaaoaaaaaa
gfaaaaadpccabaaaaaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaiadpdoaaaaab""
}
SubProgram ""gles "" {
Keywords { ""POINT"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
Keywords { ""POINT"" }
""ps_4_0_level_9_1
eefiecedpplfmimdfdbfmdimjibnefjkbapfafjlabaaaaaagmabaaaaaeaaaaaa
daaaaaaaiiaaaaaamiaaaaaadiabaaaaebgpgodjfaaaaaaafaaaaaaaaaacpppp
cmaaaaaaceaaaaaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaacpppp
fbaaaaafaaaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpabaaaaacaaaicpia
aaaaoekappppaaaafdeieefcdiaaaaaaeaaaaaaaaoaaaaaagfaaaaadpccabaaa
aaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaiadpdoaaaaabejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaahaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
Keywords { ""POINT"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 2 math
Keywords { ""POINT"" }
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 c_1;
  c_1.xyz = half3(float3(0.0, 0.0, 0.0));
  c_1.w = half(1.0);
  _mtl_o._glesFragData_0 = c_1;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
Keywords { ""DIRECTIONAL"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 1 math
Keywords { ""DIRECTIONAL"" }
""ps_2_0
def c0, 0, 0, 0, 1
mov_pp oC0, c0

""
}
SubProgram ""d3d11 "" {
Keywords { ""DIRECTIONAL"" }
""ps_4_0
eefiecedpdipnlijaafddlnglckhfpnipdngegoeabaaaaaabaabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdiaaaaaaeaaaaaaaaoaaaaaa
gfaaaaadpccabaaaaaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaiadpdoaaaaab""
}
SubProgram ""gles "" {
Keywords { ""DIRECTIONAL"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
Keywords { ""DIRECTIONAL"" }
""ps_4_0_level_9_1
eefiecedpplfmimdfdbfmdimjibnefjkbapfafjlabaaaaaagmabaaaaaeaaaaaa
daaaaaaaiiaaaaaamiaaaaaadiabaaaaebgpgodjfaaaaaaafaaaaaaaaaacpppp
cmaaaaaaceaaaaaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaacpppp
fbaaaaafaaaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpabaaaaacaaaicpia
aaaaoekappppaaaafdeieefcdiaaaaaaeaaaaaaaaoaaaaaagfaaaaadpccabaaa
aaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaiadpdoaaaaabejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaahaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
Keywords { ""DIRECTIONAL"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 2 math
Keywords { ""DIRECTIONAL"" }
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 c_1;
  c_1.xyz = half3(float3(0.0, 0.0, 0.0));
  c_1.w = half(1.0);
  _mtl_o._glesFragData_0 = c_1;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
Keywords { ""SPOT"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 1 math
Keywords { ""SPOT"" }
""ps_2_0
def c0, 0, 0, 0, 1
mov_pp oC0, c0

""
}
SubProgram ""d3d11 "" {
Keywords { ""SPOT"" }
""ps_4_0
eefiecedpdipnlijaafddlnglckhfpnipdngegoeabaaaaaabaabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdiaaaaaaeaaaaaaaaoaaaaaa
gfaaaaadpccabaaaaaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaiadpdoaaaaab""
}
SubProgram ""gles "" {
Keywords { ""SPOT"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
Keywords { ""SPOT"" }
""ps_4_0_level_9_1
eefiecedpplfmimdfdbfmdimjibnefjkbapfafjlabaaaaaagmabaaaaaeaaaaaa
daaaaaaaiiaaaaaamiaaaaaadiabaaaaebgpgodjfaaaaaaafaaaaaaaaaacpppp
cmaaaaaaceaaaaaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaacpppp
fbaaaaafaaaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpabaaaaacaaaicpia
aaaaoekappppaaaafdeieefcdiaaaaaaeaaaaaaaaoaaaaaagfaaaaadpccabaaa
aaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaiadpdoaaaaabejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaahaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
Keywords { ""SPOT"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 2 math
Keywords { ""SPOT"" }
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 c_1;
  c_1.xyz = half3(float3(0.0, 0.0, 0.0));
  c_1.w = half(1.0);
  _mtl_o._glesFragData_0 = c_1;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
Keywords { ""POINT_COOKIE"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 1 math
Keywords { ""POINT_COOKIE"" }
""ps_2_0
def c0, 0, 0, 0, 1
mov_pp oC0, c0

""
}
SubProgram ""d3d11 "" {
Keywords { ""POINT_COOKIE"" }
""ps_4_0
eefiecedpdipnlijaafddlnglckhfpnipdngegoeabaaaaaabaabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdiaaaaaaeaaaaaaaaoaaaaaa
gfaaaaadpccabaaaaaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaiadpdoaaaaab""
}
SubProgram ""gles "" {
Keywords { ""POINT_COOKIE"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
Keywords { ""POINT_COOKIE"" }
""ps_4_0_level_9_1
eefiecedpplfmimdfdbfmdimjibnefjkbapfafjlabaaaaaagmabaaaaaeaaaaaa
daaaaaaaiiaaaaaamiaaaaaadiabaaaaebgpgodjfaaaaaaafaaaaaaaaaacpppp
cmaaaaaaceaaaaaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaacpppp
fbaaaaafaaaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpabaaaaacaaaicpia
aaaaoekappppaaaafdeieefcdiaaaaaaeaaaaaaaaoaaaaaagfaaaaadpccabaaa
aaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaiadpdoaaaaabejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaahaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
Keywords { ""POINT_COOKIE"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 2 math
Keywords { ""POINT_COOKIE"" }
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 c_1;
  c_1.xyz = half3(float3(0.0, 0.0, 0.0));
  c_1.w = half(1.0);
  _mtl_o._glesFragData_0 = c_1;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
Keywords { ""DIRECTIONAL_COOKIE"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 1 math
Keywords { ""DIRECTIONAL_COOKIE"" }
""ps_2_0
def c0, 0, 0, 0, 1
mov_pp oC0, c0

""
}
SubProgram ""d3d11 "" {
Keywords { ""DIRECTIONAL_COOKIE"" }
""ps_4_0
eefiecedpdipnlijaafddlnglckhfpnipdngegoeabaaaaaabaabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdiaaaaaaeaaaaaaaaoaaaaaa
gfaaaaadpccabaaaaaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaiadpdoaaaaab""
}
SubProgram ""gles "" {
Keywords { ""DIRECTIONAL_COOKIE"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
Keywords { ""DIRECTIONAL_COOKIE"" }
""ps_4_0_level_9_1
eefiecedpplfmimdfdbfmdimjibnefjkbapfafjlabaaaaaagmabaaaaaeaaaaaa
daaaaaaaiiaaaaaamiaaaaaadiabaaaaebgpgodjfaaaaaaafaaaaaaaaaacpppp
cmaaaaaaceaaaaaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaacpppp
fbaaaaafaaaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpabaaaaacaaaicpia
aaaaoekappppaaaafdeieefcdiaaaaaaeaaaaaaaaoaaaaaagfaaaaadpccabaaa
aaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaiadpdoaaaaabejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaahaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
Keywords { ""DIRECTIONAL_COOKIE"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 2 math
Keywords { ""DIRECTIONAL_COOKIE"" }
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 c_1;
  c_1.xyz = half3(float3(0.0, 0.0, 0.0));
  c_1.w = half(1.0);
  _mtl_o._glesFragData_0 = c_1;
  return _mtl_o;
}

""
}
}
 }


 // Stats for Vertex shader:
 //       d3d11 : 22 math
 //    d3d11_9x : 22 math
 //        d3d9 : 13 math
 //        gles : 3 math
 //       gles3 : 3 math
 //       metal : 8 math
 //      opengl : 3 math
 // Stats for Fragment shader:
 //       d3d11 : 1 math
 //    d3d11_9x : 1 math
 //        d3d9 : 3 math
 //       metal : 3 math
 Pass {
  Name ""PREPASS""
  Tags { ""LIGHTMODE""=""PrePassBase"" ""ForceNoShadowCasting""=""true"" ""RenderType""=""Opaque"" }
  GpuProgramID 151750
Program ""vp"" {
SubProgram ""opengl "" {
// Stats: 3 math
""!!GLSL
#ifdef VERTEX

uniform mat4 _Object2World;
uniform mat4 _World2Object;
varying vec3 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
void main ()
{
  vec4 v_1;
  v_1.x = _World2Object[0].x;
  v_1.y = _World2Object[1].x;
  v_1.z = _World2Object[2].x;
  v_1.w = _World2Object[3].x;
  vec4 v_2;
  v_2.x = _World2Object[0].y;
  v_2.y = _World2Object[1].y;
  v_2.z = _World2Object[2].y;
  v_2.w = _World2Object[3].y;
  vec4 v_3;
  v_3.x = _World2Object[0].z;
  v_3.y = _World2Object[1].z;
  v_3.z = _World2Object[2].z;
  v_3.w = _World2Object[3].z;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = normalize(((
    (v_1.xyz * gl_Normal.x)
   + 
    (v_2.xyz * gl_Normal.y)
  ) + (v_3.xyz * gl_Normal.z)));
  xlv_TEXCOORD1 = (_Object2World * gl_Vertex).xyz;
}


#endif
#ifdef FRAGMENT
varying vec3 xlv_TEXCOORD0;
void main ()
{
  vec4 res_1;
  res_1.xyz = ((xlv_TEXCOORD0 * 0.5) + 0.5);
  res_1.w = 0.0;
  gl_FragData[0] = res_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 13 math
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
""vs_2_0
dcl_position v0
dcl_normal v1
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
dp4 oT1.x, c4, v0
dp4 oT1.y, c5, v0
dp4 oT1.z, c6, v0
mul r0.xyz, v1.y, c8
mad r0.xyz, c7, v1.x, r0
mad r0.xyz, c9, v1.z, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul oT0.xyz, r0.w, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 22 math
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0
eefiecedinidogaapcaihlhlafeaicjabdmdpgobabaaaaaaneaeaaaaadaaaaaa
cmaaaaaaceabaaaajeabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcdiadaaaaeaaaabaa
moaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
hccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hccabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 3 math
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
varying mediump vec3 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT

varying mediump vec3 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 res_1;
  lowp vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD0;
  res_1.xyz = ((tmpvar_2 * 0.5) + 0.5);
  res_1.w = 0.0;
  gl_FragData[0] = res_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 22 math
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""UnityPerDraw"" 0
""vs_4_0_level_9_1
eefiecedfimbpiggiminkfbhlgdjijhgmgblgjidabaaaaaaneagaaaaaeaaaaaa
daaaaaaacmacaaaagmafaaaageagaaaaebgpgodjpeabaaaapeabaaaaaaacpopp
leabaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaaaa
aeaaabaaaaaaaaaaaaaaamaaahaaafaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjaafaaaaadaaaaahiaaaaaffja
agaaoekaaeaaaaaeaaaaahiaafaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahia
ahaaoekaaaaakkjaaaaaoeiaaeaaaaaeabaaahoaaiaaoekaaaaappjaaaaaoeia
afaaaaadaaaaabiaacaaaajaajaaaakaafaaaaadaaaaaciaacaaaajaakaaaaka
afaaaaadaaaaaeiaacaaaajaalaaaakaafaaaaadabaaabiaacaaffjaajaaffka
afaaaaadabaaaciaacaaffjaakaaffkaafaaaaadabaaaeiaacaaffjaalaaffka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaafaaaaadabaaabiaacaakkjaajaakkka
afaaaaadabaaaciaacaakkjaakaakkkaafaaaaadabaaaeiaacaakkjaalaakkka
acaaaaadaaaaahiaaaaaoeiaabaaoeiaaiaaaaadaaaaaiiaaaaaoeiaaaaaoeia
ahaaaaacaaaaaiiaaaaappiaafaaaaadaaaaahoaaaaappiaaaaaoeiaafaaaaad
aaaaapiaaaaaffjaacaaoekaaeaaaaaeaaaaapiaabaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaadaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiappppaaaafdeieefcdiadaaaaeaaaabaamoaaaaaafjaaaaae
egiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadhccabaaaabaaaaaa
gfaaaaadhccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaaaaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaaaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
aaaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
aaaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhccabaaaacaaaaaaegiccaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaaaaaaaaadoaaaaabejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahaiaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 3 math
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
out mediump vec3 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 v_3;
  v_3.x = _World2Object[0].x;
  v_3.y = _World2Object[1].x;
  v_3.z = _World2Object[2].x;
  v_3.w = _World2Object[3].x;
  highp vec4 v_4;
  v_4.x = _World2Object[0].y;
  v_4.y = _World2Object[1].y;
  v_4.z = _World2Object[2].y;
  v_4.w = _World2Object[3].y;
  highp vec4 v_5;
  v_5.x = _World2Object[0].z;
  v_5.y = _World2Object[1].z;
  v_5.z = _World2Object[2].z;
  v_5.w = _World2Object[3].z;
  highp vec3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _glesNormal.x)
   + 
    (v_4.xyz * _glesNormal.y)
  ) + (v_5.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_6;
  tmpvar_2 = worldNormal_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
in mediump vec3 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 res_1;
  lowp vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD0;
  res_1.xyz = ((tmpvar_2 * 0.5) + 0.5);
  res_1.w = 0.0;
  _glesFragData[0] = res_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 8 math
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
ConstBuffer ""$Globals"" 192
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [_Object2World]
Matrix 128 [_World2Object]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  half3 xlv_TEXCOORD0;
  float3 xlv_TEXCOORD1;
};
struct xlatMtlShaderUniform {
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  float4 v_3;
  v_3.x = _mtl_u._World2Object[0].x;
  v_3.y = _mtl_u._World2Object[1].x;
  v_3.z = _mtl_u._World2Object[2].x;
  v_3.w = _mtl_u._World2Object[3].x;
  float4 v_4;
  v_4.x = _mtl_u._World2Object[0].y;
  v_4.y = _mtl_u._World2Object[1].y;
  v_4.z = _mtl_u._World2Object[2].y;
  v_4.w = _mtl_u._World2Object[3].y;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].z;
  v_5.y = _mtl_u._World2Object[1].z;
  v_5.z = _mtl_u._World2Object[2].z;
  v_5.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_6;
  tmpvar_6 = normalize(((
    (v_3.xyz * _mtl_i._glesNormal.x)
   + 
    (v_4.xyz * _mtl_i._glesNormal.y)
  ) + (v_5.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_6);
  tmpvar_2 = worldNormal_1;
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD1 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  return _mtl_o;
}

""
}
}
Program ""fp"" {
SubProgram ""opengl "" {
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 3 math
""ps_2_0
def c0, 0.5, 0, 0, 0
dcl_pp t0.xyz
mad_pp r0.xyz, t0, c0.x, c0.x
mov_pp r0.w, c0.y
mov_pp oC0, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 1 math
""ps_4_0
eefiecedahndifnccigjgehbcgabbojggkeiepneabaaaaaaemabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcheaaaaaaeaaaaaaabnaaaaaa
gcbaaaadhcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaadcaaaaaphccabaaa
aaaaaaaaegbcbaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaa
aceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaaaaadoaaaaab""
}
SubProgram ""gles "" {
""!!GLES""
}
SubProgram ""d3d11_9x "" {
// Stats: 1 math
""ps_4_0_level_9_1
eefiecedlhbojekhenomcgbelfdkmofngcodlfjbabaaaaaaneabaaaaaeaaaaaa
daaaaaaaleaaaaaadaabaaaakaabaaaaebgpgodjhmaaaaaahmaaaaaaaaacpppp
fiaaaaaaceaaaaaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaacpppp
fbaaaaafaaaaapkaaaaaaadpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaia
aaaachlaaeaaaaaeaaaachiaaaaaoelaaaaaaakaaaaaaakaabaaaaacaaaaciia
aaaaffkaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcheaaaaaaeaaaaaaa
bnaaaaaagcbaaaadhcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaadcaaaaap
hccabaaaaaaaaaaaegbcbaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadp
aaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaaaaadoaaaaabejfdeheogiaaaaaaadaaaaaaaiaaaaaa
faaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaahahaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl""
}
SubProgram ""gles3 "" {
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 3 math
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  half3 xlv_TEXCOORD0;
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 res_1;
  half3 tmpvar_2;
  tmpvar_2 = _mtl_i.xlv_TEXCOORD0;
  res_1.xyz = ((tmpvar_2 * (half)0.5) + (half)0.5);
  res_1.w = half(0.0);
  _mtl_o._glesFragData_0 = res_1;
  return _mtl_o;
}

""
}
}
 }


 // Stats for Vertex shader:
 //       d3d11 : 37 math
 //    d3d11_9x : 37 math
 //        d3d9 : 33 math
 //        gles : 10 avg math (9..11), 2 texture
 //       gles3 : 10 avg math (9..11), 2 texture
 //       metal : 29 math
 //      opengl : 4 math, 1 texture
 // Stats for Fragment shader:
 //       d3d11 : 1 math, 1 texture
 //    d3d11_9x : 1 math, 1 texture
 //        d3d9 : 3 math, 1 texture
 //       metal : 10 avg math (9..11), 2 texture
 Pass {
  Name ""PREPASS""
  Tags { ""LIGHTMODE""=""PrePassFinal"" ""ForceNoShadowCasting""=""true"" ""RenderType""=""Opaque"" }
  ZWrite Off
  GpuProgramID 221220
Program ""vp"" {
SubProgram ""opengl "" {
// Stats: 4 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLSL
#ifdef VERTEX
uniform vec4 _ProjectionParams;
uniform vec4 unity_SHAr;
uniform vec4 unity_SHAg;
uniform vec4 unity_SHAb;
uniform vec4 unity_SHBr;
uniform vec4 unity_SHBg;
uniform vec4 unity_SHBb;
uniform vec4 unity_SHC;

uniform mat4 _Object2World;
uniform mat4 _World2Object;
uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
varying vec4 xlv_TEXCOORD2;
varying vec4 xlv_TEXCOORD3;
varying vec3 xlv_TEXCOORD4;
void main ()
{
  vec4 tmpvar_1;
  vec4 tmpvar_2;
  tmpvar_2 = (gl_ModelViewProjectionMatrix * gl_Vertex);
  vec4 o_3;
  vec4 tmpvar_4;
  tmpvar_4 = (tmpvar_2 * 0.5);
  vec2 tmpvar_5;
  tmpvar_5.x = tmpvar_4.x;
  tmpvar_5.y = (tmpvar_4.y * _ProjectionParams.x);
  o_3.xy = (tmpvar_5 + tmpvar_4.w);
  o_3.zw = tmpvar_2.zw;
  tmpvar_1.zw = vec2(0.0, 0.0);
  tmpvar_1.xy = vec2(0.0, 0.0);
  vec4 v_6;
  v_6.x = _World2Object[0].x;
  v_6.y = _World2Object[1].x;
  v_6.z = _World2Object[2].x;
  v_6.w = _World2Object[3].x;
  vec4 v_7;
  v_7.x = _World2Object[0].y;
  v_7.y = _World2Object[1].y;
  v_7.z = _World2Object[2].y;
  v_7.w = _World2Object[3].y;
  vec4 v_8;
  v_8.x = _World2Object[0].z;
  v_8.y = _World2Object[1].z;
  v_8.z = _World2Object[2].z;
  v_8.w = _World2Object[3].z;
  vec3 tmpvar_9;
  tmpvar_9 = normalize(((
    (v_6.xyz * gl_Normal.x)
   + 
    (v_7.xyz * gl_Normal.y)
  ) + (v_8.xyz * gl_Normal.z)));
  vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = tmpvar_9;
  vec3 x2_11;
  vec3 x1_12;
  x1_12.x = dot (unity_SHAr, tmpvar_10);
  x1_12.y = dot (unity_SHAg, tmpvar_10);
  x1_12.z = dot (unity_SHAb, tmpvar_10);
  vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_9.xyzz * tmpvar_9.yzzx);
  x2_11.x = dot (unity_SHBr, tmpvar_13);
  x2_11.y = dot (unity_SHBg, tmpvar_13);
  x2_11.z = dot (unity_SHBb, tmpvar_13);
  gl_Position = tmpvar_2;
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = (_Object2World * gl_Vertex).xyz;
  xlv_TEXCOORD2 = o_3;
  xlv_TEXCOORD3 = tmpvar_1;
  xlv_TEXCOORD4 = ((x2_11 + (unity_SHC.xyz * 
    ((tmpvar_9.x * tmpvar_9.x) - (tmpvar_9.y * tmpvar_9.y))
  )) + x1_12);
}


#endif
#ifdef FRAGMENT
uniform sampler2D _XYSMap;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  vec4 c_1;
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 33 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
Vector 19 [_MainTex_ST]
Vector 10 [_ProjectionParams]
Vector 11 [_ScreenParams]
Vector 14 [unity_SHAb]
Vector 13 [unity_SHAg]
Vector 12 [unity_SHAr]
Vector 17 [unity_SHBb]
Vector 16 [unity_SHBg]
Vector 15 [unity_SHBr]
Vector 18 [unity_SHC]
""vs_2_0
def c20, 0.5, 1, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord v2
mad oT0.xy, v2, c19, c19.zwzw
dp4 oT1.x, c4, v0
dp4 oT1.y, c5, v0
dp4 oT1.z, c6, v0
dp4 r0.y, c1, v0
mul r1.x, r0.y, c10.x
mul r1.w, r1.x, c20.x
dp4 r0.x, c0, v0
dp4 r0.w, c3, v0
mul r1.xz, r0.xyww, c20.x
mad oT2.xy, r1.z, c11.zwzw, r1.xwzw
mul r1.xyz, v1.y, c8
mad r1.xyz, c7, v1.x, r1
mad r1.xyz, c9, v1.z, r1
nrm r2.xyz, r1
mul r1.x, r2.y, r2.y
mad r1.x, r2.x, r2.x, -r1.x
mul r3, r2.yzzx, r2.xyzz
dp4 r4.x, c15, r3
dp4 r4.y, c16, r3
dp4 r4.z, c17, r3
mad r1.xyz, c18, r1.x, r4
mov r2.w, c20.y
dp4 r3.x, c12, r2
dp4 r3.y, c13, r2
dp4 r3.z, c14, r2
add oT4.xyz, r1, r3
dp4 r0.z, c2, v0
mov oPos, r0
mov oT2.zw, r0
mov oT3, c20.z

""
}
SubProgram ""d3d11 "" {
// Stats: 37 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 176
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityPerCamera"" 144
Vector 80 [_ProjectionParams]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerCamera"" 1
BindCB  ""UnityLighting"" 2
BindCB  ""UnityPerDraw"" 3
""vs_4_0
eefiecedgkjhdnfcnbldbbockcppojndemhaflobabaaaaaammahaaaaadaaaaaa
cmaaaaaaceabaaaanmabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
oiafaaaaeaaaabaahkabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaae
egiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaacnaaaaaafjaaaaae
egiocaaaadaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadpccabaaa
adaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaac
aeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
pccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaai
hcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaadaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaiccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaa
agahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaaf
mccabaaaadaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaadaaaaaakgakbaaa
abaaaaaamgaabaaaabaaaaaadgaaaaaipccabaaaaeaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaadaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaadaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
adaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
adaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
adaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaa
aaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaaabaaaaaaakaabaaaaaaaaaaa
akaabaaaaaaaaaaaakaabaiaebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaa
jgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaa
acaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaa
acaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaa
acaaaaaaclaaaaaaegaobaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaa
acaaaaaacmaaaaaaagaabaaaabaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaa
aaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaacaaaaaaegiocaaaacaaaaaa
cgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaacaaaaaaegiocaaaacaaaaaa
chaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaacaaaaaaegiocaaaacaaaaaa
ciaaaaaaegaobaaaaaaaaaaaaaaaaaahhccabaaaafaaaaaaegacbaaaabaaaaaa
egacbaaaacaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 11 math, 2 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform highp vec4 _ProjectionParams;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying highp vec4 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD3;
varying highp vec3 xlv_TEXCOORD4;
void main ()
{
  highp vec4 tmpvar_1;
  highp vec3 tmpvar_2;
  highp vec4 tmpvar_3;
  tmpvar_3 = (glstate_matrix_mvp * _glesVertex);
  highp vec4 o_4;
  highp vec4 tmpvar_5;
  tmpvar_5 = (tmpvar_3 * 0.5);
  highp vec2 tmpvar_6;
  tmpvar_6.x = tmpvar_5.x;
  tmpvar_6.y = (tmpvar_5.y * _ProjectionParams.x);
  o_4.xy = (tmpvar_6 + tmpvar_5.w);
  o_4.zw = tmpvar_3.zw;
  tmpvar_1.zw = vec2(0.0, 0.0);
  tmpvar_1.xy = vec2(0.0, 0.0);
  highp vec4 v_7;
  v_7.x = _World2Object[0].x;
  v_7.y = _World2Object[1].x;
  v_7.z = _World2Object[2].x;
  v_7.w = _World2Object[3].x;
  highp vec4 v_8;
  v_8.x = _World2Object[0].y;
  v_8.y = _World2Object[1].y;
  v_8.z = _World2Object[2].y;
  v_8.w = _World2Object[3].y;
  highp vec4 v_9;
  v_9.x = _World2Object[0].z;
  v_9.y = _World2Object[1].z;
  v_9.z = _World2Object[2].z;
  v_9.w = _World2Object[3].z;
  highp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = normalize(((
    (v_7.xyz * _glesNormal.x)
   + 
    (v_8.xyz * _glesNormal.y)
  ) + (v_9.xyz * _glesNormal.z)));
  mediump vec3 tmpvar_11;
  mediump vec4 normal_12;
  normal_12 = tmpvar_10;
  mediump vec3 x2_13;
  mediump vec3 x1_14;
  x1_14.x = dot (unity_SHAr, normal_12);
  x1_14.y = dot (unity_SHAg, normal_12);
  x1_14.z = dot (unity_SHAb, normal_12);
  mediump vec4 tmpvar_15;
  tmpvar_15 = (normal_12.xyzz * normal_12.yzzx);
  x2_13.x = dot (unity_SHBr, tmpvar_15);
  x2_13.y = dot (unity_SHBg, tmpvar_15);
  x2_13.z = dot (unity_SHBb, tmpvar_15);
  tmpvar_11 = ((x2_13 + (unity_SHC.xyz * 
    ((normal_12.x * normal_12.x) - (normal_12.y * normal_12.y))
  )) + x1_14);
  tmpvar_2 = tmpvar_11;
  gl_Position = tmpvar_3;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
  xlv_TEXCOORD2 = o_4;
  xlv_TEXCOORD3 = tmpvar_1;
  xlv_TEXCOORD4 = tmpvar_2;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _XYSMap;
uniform sampler2D _LightBuffer;
varying highp vec2 xlv_TEXCOORD0;
varying highp vec4 xlv_TEXCOORD2;
varying highp vec3 xlv_TEXCOORD4;
void main ()
{
  lowp vec4 tmpvar_1;
  mediump vec4 c_2;
  mediump vec4 light_3;
  lowp vec4 tmpvar_4;
  tmpvar_4 = texture2D (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_5;
  tmpvar_5.x = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.y = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.z = (tmpvar_4.y - tmpvar_4.z);
  lowp vec4 tmpvar_6;
  tmpvar_6 = texture2DProj (_LightBuffer, xlv_TEXCOORD2);
  light_3 = tmpvar_6;
  mediump vec4 tmpvar_7;
  tmpvar_7 = -(log2(max (light_3, vec4(0.001, 0.001, 0.001, 0.001))));
  light_3.w = tmpvar_7.w;
  highp vec3 tmpvar_8;
  tmpvar_8 = (tmpvar_7.xyz + xlv_TEXCOORD4);
  light_3.xyz = tmpvar_8;
  lowp vec4 c_9;
  c_9.xyz = vec3(0.0, 0.0, 0.0);
  c_9.w = 1.0;
  c_2 = c_9;
  c_2.xyz = (c_2.xyz + tmpvar_5);
  c_2.w = 1.0;
  tmpvar_1 = c_2;
  gl_FragData[0] = tmpvar_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 37 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 176
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityPerCamera"" 144
Vector 80 [_ProjectionParams]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerCamera"" 1
BindCB  ""UnityLighting"" 2
BindCB  ""UnityPerDraw"" 3
""vs_4_0_level_9_1
eefiecedgndkonombofnfgnjocjnddidplmoojhoabaaaaaacealaaaaaeaaaaaa
daaaaaaaieadaaaaheajaaaagmakaaaaebgpgodjemadaaaaemadaaaaaaacpopp
oiacaaaageaaaaaaafaaceaaaaaagaaaaaaagaaaaaaaceaaabaagaaaaaaaajaa
abaaabaaaaaaaaaaabaaafaaabaaacaaaaaaaaaaacaacgaaahaaadaaaaaaaaaa
adaaaaaaaeaaakaaaaaaaaaaadaaamaaahaaaoaaaaaaaaaaaaaaaaaaaaacpopp
fbaaaaafbfaaapkaaaaaaadpaaaaiadpaaaaaaaaaaaaaaaabpaaaaacafaaaaia
aaaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjaaeaaaaae
aaaaadoaadaaoejaabaaoekaabaaookaafaaaaadaaaaahiaaaaaffjaapaaoeka
aeaaaaaeaaaaahiaaoaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahiabaaaoeka
aaaakkjaaaaaoeiaaeaaaaaeabaaahoabbaaoekaaaaappjaaaaaoeiaafaaaaad
aaaaapiaaaaaffjaalaaoekaaeaaaaaeaaaaapiaakaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaamaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaanaaoeka
aaaappjaaaaaoeiaafaaaaadabaaabiaaaaaffiaacaaaakaafaaaaadabaaaiia
abaaaaiabfaaaakaafaaaaadabaaafiaaaaapeiabfaaaakaacaaaaadacaaadoa
abaakkiaabaaomiaafaaaaadabaaabiaacaaaajabcaaaakaafaaaaadabaaacia
acaaaajabdaaaakaafaaaaadabaaaeiaacaaaajabeaaaakaafaaaaadacaaabia
acaaffjabcaaffkaafaaaaadacaaaciaacaaffjabdaaffkaafaaaaadacaaaeia
acaaffjabeaaffkaacaaaaadabaaahiaabaaoeiaacaaoeiaafaaaaadacaaabia
acaakkjabcaakkkaafaaaaadacaaaciaacaakkjabdaakkkaafaaaaadacaaaeia
acaakkjabeaakkkaacaaaaadabaaahiaabaaoeiaacaaoeiaceaaaaacacaaahia
abaaoeiaafaaaaadabaaabiaacaaffiaacaaffiaaeaaaaaeabaaabiaacaaaaia
acaaaaiaabaaaaibafaaaaadadaaapiaacaacjiaacaakeiaajaaaaadaeaaabia
agaaoekaadaaoeiaajaaaaadaeaaaciaahaaoekaadaaoeiaajaaaaadaeaaaeia
aiaaoekaadaaoeiaaeaaaaaeabaaahiaajaaoekaabaaaaiaaeaaoeiaabaaaaac
acaaaiiabfaaffkaajaaaaadadaaabiaadaaoekaacaaoeiaajaaaaadadaaacia
aeaaoekaacaaoeiaajaaaaadadaaaeiaafaaoekaacaaoeiaacaaaaadaeaaahoa
abaaoeiaadaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiaabaaaaacacaaamoaaaaaoeiaabaaaaacadaaapoabfaakkka
ppppaaaafdeieefcoiafaaaaeaaaabaahkabaaaafjaaaaaeegiocaaaaaaaaaaa
akaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaa
cnaaaaaafjaaaaaeegiocaaaadaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaa
gfaaaaadpccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadhccabaaa
afaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
aaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaa
ajaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaa
anaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaaacaaaaaa
egiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaadaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
adaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadgaaaaaipccabaaaaeaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaadaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaadaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaadaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaahbcaabaaa
abaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaaabaaaaaa
akaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaiaebaaaaaaabaaaaaadiaaaaah
pcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaa
adaaaaaaegiocaaaacaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaa
adaaaaaaegiocaaaacaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaa
adaaaaaaegiocaaaacaaaaaaclaaaaaaegaobaaaacaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaacaaaaaacmaaaaaaagaabaaaabaaaaaaegacbaaaadaaaaaa
dgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaacaaaaaa
egiocaaaacaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaacaaaaaa
egiocaaaacaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaacaaaaaa
egiocaaaacaaaaaaciaaaaaaegaobaaaaaaaaaaaaaaaaaahhccabaaaafaaaaaa
egacbaaaabaaaaaaegacbaaaacaaaaaadoaaaaabejfdeheopaaaaaaaaiaaaaaa
aiaaaaaamiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apadaaaaoaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaa
acaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaa
adaaaaaaagaaaaaaapaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaa
apaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffied
epepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 11 math, 2 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform highp vec4 _ProjectionParams;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
out highp vec4 xlv_TEXCOORD2;
out highp vec4 xlv_TEXCOORD3;
out highp vec3 xlv_TEXCOORD4;
void main ()
{
  highp vec4 tmpvar_1;
  highp vec3 tmpvar_2;
  highp vec4 tmpvar_3;
  tmpvar_3 = (glstate_matrix_mvp * _glesVertex);
  highp vec4 o_4;
  highp vec4 tmpvar_5;
  tmpvar_5 = (tmpvar_3 * 0.5);
  highp vec2 tmpvar_6;
  tmpvar_6.x = tmpvar_5.x;
  tmpvar_6.y = (tmpvar_5.y * _ProjectionParams.x);
  o_4.xy = (tmpvar_6 + tmpvar_5.w);
  o_4.zw = tmpvar_3.zw;
  tmpvar_1.zw = vec2(0.0, 0.0);
  tmpvar_1.xy = vec2(0.0, 0.0);
  highp vec4 v_7;
  v_7.x = _World2Object[0].x;
  v_7.y = _World2Object[1].x;
  v_7.z = _World2Object[2].x;
  v_7.w = _World2Object[3].x;
  highp vec4 v_8;
  v_8.x = _World2Object[0].y;
  v_8.y = _World2Object[1].y;
  v_8.z = _World2Object[2].y;
  v_8.w = _World2Object[3].y;
  highp vec4 v_9;
  v_9.x = _World2Object[0].z;
  v_9.y = _World2Object[1].z;
  v_9.z = _World2Object[2].z;
  v_9.w = _World2Object[3].z;
  highp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = normalize(((
    (v_7.xyz * _glesNormal.x)
   + 
    (v_8.xyz * _glesNormal.y)
  ) + (v_9.xyz * _glesNormal.z)));
  mediump vec3 tmpvar_11;
  mediump vec4 normal_12;
  normal_12 = tmpvar_10;
  mediump vec3 x2_13;
  mediump vec3 x1_14;
  x1_14.x = dot (unity_SHAr, normal_12);
  x1_14.y = dot (unity_SHAg, normal_12);
  x1_14.z = dot (unity_SHAb, normal_12);
  mediump vec4 tmpvar_15;
  tmpvar_15 = (normal_12.xyzz * normal_12.yzzx);
  x2_13.x = dot (unity_SHBr, tmpvar_15);
  x2_13.y = dot (unity_SHBg, tmpvar_15);
  x2_13.z = dot (unity_SHBb, tmpvar_15);
  tmpvar_11 = ((x2_13 + (unity_SHC.xyz * 
    ((normal_12.x * normal_12.x) - (normal_12.y * normal_12.y))
  )) + x1_14);
  tmpvar_2 = tmpvar_11;
  gl_Position = tmpvar_3;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
  xlv_TEXCOORD2 = o_4;
  xlv_TEXCOORD3 = tmpvar_1;
  xlv_TEXCOORD4 = tmpvar_2;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _XYSMap;
uniform sampler2D _LightBuffer;
in highp vec2 xlv_TEXCOORD0;
in highp vec4 xlv_TEXCOORD2;
in highp vec3 xlv_TEXCOORD4;
void main ()
{
  lowp vec4 tmpvar_1;
  mediump vec4 c_2;
  mediump vec4 light_3;
  lowp vec4 tmpvar_4;
  tmpvar_4 = texture (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_5;
  tmpvar_5.x = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.y = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.z = (tmpvar_4.y - tmpvar_4.z);
  lowp vec4 tmpvar_6;
  tmpvar_6 = textureProj (_LightBuffer, xlv_TEXCOORD2);
  light_3 = tmpvar_6;
  mediump vec4 tmpvar_7;
  tmpvar_7 = -(log2(max (light_3, vec4(0.001, 0.001, 0.001, 0.001))));
  light_3.w = tmpvar_7.w;
  highp vec3 tmpvar_8;
  tmpvar_8 = (tmpvar_7.xyz + xlv_TEXCOORD4);
  light_3.xyz = tmpvar_8;
  lowp vec4 c_9;
  c_9.xyz = vec3(0.0, 0.0, 0.0);
  c_9.w = 1.0;
  c_2 = c_9;
  c_2.xyz = (c_2.xyz + tmpvar_5);
  c_2.w = 1.0;
  tmpvar_1 = c_2;
  _glesFragData[0] = tmpvar_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 29 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
Bind ""texcoord"" ATTR2
ConstBuffer ""$Globals"" 288
Matrix 80 [glstate_matrix_mvp]
Matrix 144 [_Object2World]
Matrix 208 [_World2Object]
Vector 0 [_ProjectionParams]
VectorHalf 16 [unity_SHAr] 4
VectorHalf 24 [unity_SHAg] 4
VectorHalf 32 [unity_SHAb] 4
VectorHalf 40 [unity_SHBr] 4
VectorHalf 48 [unity_SHBg] 4
VectorHalf 56 [unity_SHBb] 4
VectorHalf 64 [unity_SHC] 4
Vector 272 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
  float4 _glesMultiTexCoord0 [[attribute(2)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  float2 xlv_TEXCOORD0;
  float3 xlv_TEXCOORD1;
  float4 xlv_TEXCOORD2;
  float4 xlv_TEXCOORD3;
  float3 xlv_TEXCOORD4;
};
struct xlatMtlShaderUniform {
  float4 _ProjectionParams;
  half4 unity_SHAr;
  half4 unity_SHAg;
  half4 unity_SHAb;
  half4 unity_SHBr;
  half4 unity_SHBg;
  half4 unity_SHBb;
  half4 unity_SHC;
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  float4 tmpvar_1;
  float3 tmpvar_2;
  float4 tmpvar_3;
  tmpvar_3 = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  float4 o_4;
  float4 tmpvar_5;
  tmpvar_5 = (tmpvar_3 * 0.5);
  float2 tmpvar_6;
  tmpvar_6.x = tmpvar_5.x;
  tmpvar_6.y = (tmpvar_5.y * _mtl_u._ProjectionParams.x);
  o_4.xy = (tmpvar_6 + tmpvar_5.w);
  o_4.zw = tmpvar_3.zw;
  tmpvar_1.zw = float2(0.0, 0.0);
  tmpvar_1.xy = float2(0.0, 0.0);
  float4 v_7;
  v_7.x = _mtl_u._World2Object[0].x;
  v_7.y = _mtl_u._World2Object[1].x;
  v_7.z = _mtl_u._World2Object[2].x;
  v_7.w = _mtl_u._World2Object[3].x;
  float4 v_8;
  v_8.x = _mtl_u._World2Object[0].y;
  v_8.y = _mtl_u._World2Object[1].y;
  v_8.z = _mtl_u._World2Object[2].y;
  v_8.w = _mtl_u._World2Object[3].y;
  float4 v_9;
  v_9.x = _mtl_u._World2Object[0].z;
  v_9.y = _mtl_u._World2Object[1].z;
  v_9.z = _mtl_u._World2Object[2].z;
  v_9.w = _mtl_u._World2Object[3].z;
  float4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = normalize(((
    (v_7.xyz * _mtl_i._glesNormal.x)
   + 
    (v_8.xyz * _mtl_i._glesNormal.y)
  ) + (v_9.xyz * _mtl_i._glesNormal.z)));
  half3 tmpvar_11;
  half4 normal_12;
  normal_12 = half4(tmpvar_10);
  half3 x2_13;
  half3 x1_14;
  x1_14.x = dot (_mtl_u.unity_SHAr, normal_12);
  x1_14.y = dot (_mtl_u.unity_SHAg, normal_12);
  x1_14.z = dot (_mtl_u.unity_SHAb, normal_12);
  half4 tmpvar_15;
  tmpvar_15 = (normal_12.xyzz * normal_12.yzzx);
  x2_13.x = dot (_mtl_u.unity_SHBr, tmpvar_15);
  x2_13.y = dot (_mtl_u.unity_SHBg, tmpvar_15);
  x2_13.z = dot (_mtl_u.unity_SHBb, tmpvar_15);
  tmpvar_11 = ((x2_13 + (_mtl_u.unity_SHC.xyz * 
    ((normal_12.x * normal_12.x) - (normal_12.y * normal_12.y))
  )) + x1_14);
  tmpvar_2 = float3(tmpvar_11);
  _mtl_o.gl_Position = tmpvar_3;
  _mtl_o.xlv_TEXCOORD0 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  _mtl_o.xlv_TEXCOORD1 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  _mtl_o.xlv_TEXCOORD2 = o_4;
  _mtl_o.xlv_TEXCOORD3 = tmpvar_1;
  _mtl_o.xlv_TEXCOORD4 = tmpvar_2;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
// Stats: 4 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLSL
#ifdef VERTEX
uniform vec4 _ProjectionParams;
uniform vec4 unity_SHAr;
uniform vec4 unity_SHAg;
uniform vec4 unity_SHAb;
uniform vec4 unity_SHBr;
uniform vec4 unity_SHBg;
uniform vec4 unity_SHBb;
uniform vec4 unity_SHC;

uniform mat4 _Object2World;
uniform mat4 _World2Object;
uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
varying vec4 xlv_TEXCOORD2;
varying vec4 xlv_TEXCOORD3;
varying vec3 xlv_TEXCOORD4;
void main ()
{
  vec4 tmpvar_1;
  vec4 tmpvar_2;
  tmpvar_2 = (gl_ModelViewProjectionMatrix * gl_Vertex);
  vec4 o_3;
  vec4 tmpvar_4;
  tmpvar_4 = (tmpvar_2 * 0.5);
  vec2 tmpvar_5;
  tmpvar_5.x = tmpvar_4.x;
  tmpvar_5.y = (tmpvar_4.y * _ProjectionParams.x);
  o_3.xy = (tmpvar_5 + tmpvar_4.w);
  o_3.zw = tmpvar_2.zw;
  tmpvar_1.zw = vec2(0.0, 0.0);
  tmpvar_1.xy = vec2(0.0, 0.0);
  vec4 v_6;
  v_6.x = _World2Object[0].x;
  v_6.y = _World2Object[1].x;
  v_6.z = _World2Object[2].x;
  v_6.w = _World2Object[3].x;
  vec4 v_7;
  v_7.x = _World2Object[0].y;
  v_7.y = _World2Object[1].y;
  v_7.z = _World2Object[2].y;
  v_7.w = _World2Object[3].y;
  vec4 v_8;
  v_8.x = _World2Object[0].z;
  v_8.y = _World2Object[1].z;
  v_8.z = _World2Object[2].z;
  v_8.w = _World2Object[3].z;
  vec3 tmpvar_9;
  tmpvar_9 = normalize(((
    (v_6.xyz * gl_Normal.x)
   + 
    (v_7.xyz * gl_Normal.y)
  ) + (v_8.xyz * gl_Normal.z)));
  vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = tmpvar_9;
  vec3 x2_11;
  vec3 x1_12;
  x1_12.x = dot (unity_SHAr, tmpvar_10);
  x1_12.y = dot (unity_SHAg, tmpvar_10);
  x1_12.z = dot (unity_SHAb, tmpvar_10);
  vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_9.xyzz * tmpvar_9.yzzx);
  x2_11.x = dot (unity_SHBr, tmpvar_13);
  x2_11.y = dot (unity_SHBg, tmpvar_13);
  x2_11.z = dot (unity_SHBb, tmpvar_13);
  gl_Position = tmpvar_2;
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = (_Object2World * gl_Vertex).xyz;
  xlv_TEXCOORD2 = o_3;
  xlv_TEXCOORD3 = tmpvar_1;
  xlv_TEXCOORD4 = ((x2_11 + (unity_SHC.xyz * 
    ((tmpvar_9.x * tmpvar_9.x) - (tmpvar_9.y * tmpvar_9.y))
  )) + x1_12);
}


#endif
#ifdef FRAGMENT
uniform sampler2D _XYSMap;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  vec4 c_1;
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  c_1.xyz = tmpvar_3;
  c_1.w = 1.0;
  gl_FragData[0] = c_1;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 33 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
Vector 19 [_MainTex_ST]
Vector 10 [_ProjectionParams]
Vector 11 [_ScreenParams]
Vector 14 [unity_SHAb]
Vector 13 [unity_SHAg]
Vector 12 [unity_SHAr]
Vector 17 [unity_SHBb]
Vector 16 [unity_SHBg]
Vector 15 [unity_SHBr]
Vector 18 [unity_SHC]
""vs_2_0
def c20, 0.5, 1, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord v2
mad oT0.xy, v2, c19, c19.zwzw
dp4 oT1.x, c4, v0
dp4 oT1.y, c5, v0
dp4 oT1.z, c6, v0
dp4 r0.y, c1, v0
mul r1.x, r0.y, c10.x
mul r1.w, r1.x, c20.x
dp4 r0.x, c0, v0
dp4 r0.w, c3, v0
mul r1.xz, r0.xyww, c20.x
mad oT2.xy, r1.z, c11.zwzw, r1.xwzw
mul r1.xyz, v1.y, c8
mad r1.xyz, c7, v1.x, r1
mad r1.xyz, c9, v1.z, r1
nrm r2.xyz, r1
mul r1.x, r2.y, r2.y
mad r1.x, r2.x, r2.x, -r1.x
mul r3, r2.yzzx, r2.xyzz
dp4 r4.x, c15, r3
dp4 r4.y, c16, r3
dp4 r4.z, c17, r3
mad r1.xyz, c18, r1.x, r4
mov r2.w, c20.y
dp4 r3.x, c12, r2
dp4 r3.y, c13, r2
dp4 r3.z, c14, r2
add oT4.xyz, r1, r3
dp4 r0.z, c2, v0
mov oPos, r0
mov oT2.zw, r0
mov oT3, c20.z

""
}
SubProgram ""d3d11 "" {
// Stats: 37 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 176
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityPerCamera"" 144
Vector 80 [_ProjectionParams]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerCamera"" 1
BindCB  ""UnityLighting"" 2
BindCB  ""UnityPerDraw"" 3
""vs_4_0
eefiecedgkjhdnfcnbldbbockcppojndemhaflobabaaaaaammahaaaaadaaaaaa
cmaaaaaaceabaaaanmabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
oiafaaaaeaaaabaahkabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaae
egiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaacnaaaaaafjaaaaae
egiocaaaadaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadpccabaaa
adaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaac
aeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
pccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaai
hcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaadaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaiccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaa
agahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaaf
mccabaaaadaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaadaaaaaakgakbaaa
abaaaaaamgaabaaaabaaaaaadgaaaaaipccabaaaaeaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaaakbabaaaacaaaaaa
akiacaaaadaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaabkbabaaaacaaaaaa
bkiacaaaadaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
adaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
adaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaaacaaaaaackiacaaa
adaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaa
aaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaaabaaaaaaakaabaaaaaaaaaaa
akaabaaaaaaaaaaaakaabaiaebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaa
jgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaa
acaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaa
acaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaa
acaaaaaaclaaaaaaegaobaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaa
acaaaaaacmaaaaaaagaabaaaabaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaa
aaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaacaaaaaaegiocaaaacaaaaaa
cgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaacaaaaaaegiocaaaacaaaaaa
chaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaacaaaaaaegiocaaaacaaaaaa
ciaaaaaaegaobaaaaaaaaaaaaaaaaaahhccabaaaafaaaaaaegacbaaaabaaaaaa
egacbaaaacaaaaaadoaaaaab""
}
SubProgram ""gles "" {
// Stats: 9 math, 2 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform highp vec4 _ProjectionParams;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying highp vec4 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD3;
varying highp vec3 xlv_TEXCOORD4;
void main ()
{
  highp vec4 tmpvar_1;
  highp vec3 tmpvar_2;
  highp vec4 tmpvar_3;
  tmpvar_3 = (glstate_matrix_mvp * _glesVertex);
  highp vec4 o_4;
  highp vec4 tmpvar_5;
  tmpvar_5 = (tmpvar_3 * 0.5);
  highp vec2 tmpvar_6;
  tmpvar_6.x = tmpvar_5.x;
  tmpvar_6.y = (tmpvar_5.y * _ProjectionParams.x);
  o_4.xy = (tmpvar_6 + tmpvar_5.w);
  o_4.zw = tmpvar_3.zw;
  tmpvar_1.zw = vec2(0.0, 0.0);
  tmpvar_1.xy = vec2(0.0, 0.0);
  highp vec4 v_7;
  v_7.x = _World2Object[0].x;
  v_7.y = _World2Object[1].x;
  v_7.z = _World2Object[2].x;
  v_7.w = _World2Object[3].x;
  highp vec4 v_8;
  v_8.x = _World2Object[0].y;
  v_8.y = _World2Object[1].y;
  v_8.z = _World2Object[2].y;
  v_8.w = _World2Object[3].y;
  highp vec4 v_9;
  v_9.x = _World2Object[0].z;
  v_9.y = _World2Object[1].z;
  v_9.z = _World2Object[2].z;
  v_9.w = _World2Object[3].z;
  highp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = normalize(((
    (v_7.xyz * _glesNormal.x)
   + 
    (v_8.xyz * _glesNormal.y)
  ) + (v_9.xyz * _glesNormal.z)));
  mediump vec3 tmpvar_11;
  mediump vec4 normal_12;
  normal_12 = tmpvar_10;
  mediump vec3 x2_13;
  mediump vec3 x1_14;
  x1_14.x = dot (unity_SHAr, normal_12);
  x1_14.y = dot (unity_SHAg, normal_12);
  x1_14.z = dot (unity_SHAb, normal_12);
  mediump vec4 tmpvar_15;
  tmpvar_15 = (normal_12.xyzz * normal_12.yzzx);
  x2_13.x = dot (unity_SHBr, tmpvar_15);
  x2_13.y = dot (unity_SHBg, tmpvar_15);
  x2_13.z = dot (unity_SHBb, tmpvar_15);
  tmpvar_11 = ((x2_13 + (unity_SHC.xyz * 
    ((normal_12.x * normal_12.x) - (normal_12.y * normal_12.y))
  )) + x1_14);
  tmpvar_2 = tmpvar_11;
  gl_Position = tmpvar_3;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
  xlv_TEXCOORD2 = o_4;
  xlv_TEXCOORD3 = tmpvar_1;
  xlv_TEXCOORD4 = tmpvar_2;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _XYSMap;
uniform sampler2D _LightBuffer;
varying highp vec2 xlv_TEXCOORD0;
varying highp vec4 xlv_TEXCOORD2;
varying highp vec3 xlv_TEXCOORD4;
void main ()
{
  lowp vec4 tmpvar_1;
  mediump vec4 c_2;
  mediump vec4 light_3;
  lowp vec4 tmpvar_4;
  tmpvar_4 = texture2D (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_5;
  tmpvar_5.x = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.y = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.z = (tmpvar_4.y - tmpvar_4.z);
  lowp vec4 tmpvar_6;
  tmpvar_6 = texture2DProj (_LightBuffer, xlv_TEXCOORD2);
  light_3 = tmpvar_6;
  mediump vec4 tmpvar_7;
  tmpvar_7 = max (light_3, vec4(0.001, 0.001, 0.001, 0.001));
  light_3.w = tmpvar_7.w;
  highp vec3 tmpvar_8;
  tmpvar_8 = (tmpvar_7.xyz + xlv_TEXCOORD4);
  light_3.xyz = tmpvar_8;
  lowp vec4 c_9;
  c_9.xyz = vec3(0.0, 0.0, 0.0);
  c_9.w = 1.0;
  c_2 = c_9;
  c_2.xyz = (c_2.xyz + tmpvar_5);
  c_2.w = 1.0;
  tmpvar_1 = c_2;
  gl_FragData[0] = tmpvar_1;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 37 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 176
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityPerCamera"" 144
Vector 80 [_ProjectionParams]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityPerCamera"" 1
BindCB  ""UnityLighting"" 2
BindCB  ""UnityPerDraw"" 3
""vs_4_0_level_9_1
eefiecedgndkonombofnfgnjocjnddidplmoojhoabaaaaaacealaaaaaeaaaaaa
daaaaaaaieadaaaaheajaaaagmakaaaaebgpgodjemadaaaaemadaaaaaaacpopp
oiacaaaageaaaaaaafaaceaaaaaagaaaaaaagaaaaaaaceaaabaagaaaaaaaajaa
abaaabaaaaaaaaaaabaaafaaabaaacaaaaaaaaaaacaacgaaahaaadaaaaaaaaaa
adaaaaaaaeaaakaaaaaaaaaaadaaamaaahaaaoaaaaaaaaaaaaaaaaaaaaacpopp
fbaaaaafbfaaapkaaaaaaadpaaaaiadpaaaaaaaaaaaaaaaabpaaaaacafaaaaia
aaaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjaaeaaaaae
aaaaadoaadaaoejaabaaoekaabaaookaafaaaaadaaaaahiaaaaaffjaapaaoeka
aeaaaaaeaaaaahiaaoaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahiabaaaoeka
aaaakkjaaaaaoeiaaeaaaaaeabaaahoabbaaoekaaaaappjaaaaaoeiaafaaaaad
aaaaapiaaaaaffjaalaaoekaaeaaaaaeaaaaapiaakaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaamaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaanaaoeka
aaaappjaaaaaoeiaafaaaaadabaaabiaaaaaffiaacaaaakaafaaaaadabaaaiia
abaaaaiabfaaaakaafaaaaadabaaafiaaaaapeiabfaaaakaacaaaaadacaaadoa
abaakkiaabaaomiaafaaaaadabaaabiaacaaaajabcaaaakaafaaaaadabaaacia
acaaaajabdaaaakaafaaaaadabaaaeiaacaaaajabeaaaakaafaaaaadacaaabia
acaaffjabcaaffkaafaaaaadacaaaciaacaaffjabdaaffkaafaaaaadacaaaeia
acaaffjabeaaffkaacaaaaadabaaahiaabaaoeiaacaaoeiaafaaaaadacaaabia
acaakkjabcaakkkaafaaaaadacaaaciaacaakkjabdaakkkaafaaaaadacaaaeia
acaakkjabeaakkkaacaaaaadabaaahiaabaaoeiaacaaoeiaceaaaaacacaaahia
abaaoeiaafaaaaadabaaabiaacaaffiaacaaffiaaeaaaaaeabaaabiaacaaaaia
acaaaaiaabaaaaibafaaaaadadaaapiaacaacjiaacaakeiaajaaaaadaeaaabia
agaaoekaadaaoeiaajaaaaadaeaaaciaahaaoekaadaaoeiaajaaaaadaeaaaeia
aiaaoekaadaaoeiaaeaaaaaeabaaahiaajaaoekaabaaaaiaaeaaoeiaabaaaaac
acaaaiiabfaaffkaajaaaaadadaaabiaadaaoekaacaaoeiaajaaaaadadaaacia
aeaaoekaacaaoeiaajaaaaadadaaaeiaafaaoekaacaaoeiaacaaaaadaeaaahoa
abaaoeiaadaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiaabaaaaacacaaamoaaaaaoeiaabaaaaacadaaapoabfaakkka
ppppaaaafdeieefcoiafaaaaeaaaabaahkabaaaafjaaaaaeegiocaaaaaaaaaaa
akaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaa
cnaaaaaafjaaaaaeegiocaaaadaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaa
gfaaaaadpccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadhccabaaa
afaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
aaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaa
ajaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaa
anaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaaacaaaaaa
egiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaadaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
adaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadgaaaaaipccabaaaaeaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaadaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaadaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaadaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaadaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaadaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaahbcaabaaa
abaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaaabaaaaaa
akaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaiaebaaaaaaabaaaaaadiaaaaah
pcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaa
adaaaaaaegiocaaaacaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaa
adaaaaaaegiocaaaacaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaa
adaaaaaaegiocaaaacaaaaaaclaaaaaaegaobaaaacaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaacaaaaaacmaaaaaaagaabaaaabaaaaaaegacbaaaadaaaaaa
dgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaacaaaaaa
egiocaaaacaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaacaaaaaa
egiocaaaacaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaacaaaaaa
egiocaaaacaaaaaaciaaaaaaegaobaaaaaaaaaaaaaaaaaahhccabaaaafaaaaaa
egacbaaaabaaaaaaegacbaaaacaaaaaadoaaaaabejfdeheopaaaaaaaaiaaaaaa
aiaaaaaamiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apadaaaaoaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaa
acaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaa
adaaaaaaagaaaaaaapaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaa
apaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffied
epepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 9 math, 2 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform highp vec4 _ProjectionParams;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
out highp vec4 xlv_TEXCOORD2;
out highp vec4 xlv_TEXCOORD3;
out highp vec3 xlv_TEXCOORD4;
void main ()
{
  highp vec4 tmpvar_1;
  highp vec3 tmpvar_2;
  highp vec4 tmpvar_3;
  tmpvar_3 = (glstate_matrix_mvp * _glesVertex);
  highp vec4 o_4;
  highp vec4 tmpvar_5;
  tmpvar_5 = (tmpvar_3 * 0.5);
  highp vec2 tmpvar_6;
  tmpvar_6.x = tmpvar_5.x;
  tmpvar_6.y = (tmpvar_5.y * _ProjectionParams.x);
  o_4.xy = (tmpvar_6 + tmpvar_5.w);
  o_4.zw = tmpvar_3.zw;
  tmpvar_1.zw = vec2(0.0, 0.0);
  tmpvar_1.xy = vec2(0.0, 0.0);
  highp vec4 v_7;
  v_7.x = _World2Object[0].x;
  v_7.y = _World2Object[1].x;
  v_7.z = _World2Object[2].x;
  v_7.w = _World2Object[3].x;
  highp vec4 v_8;
  v_8.x = _World2Object[0].y;
  v_8.y = _World2Object[1].y;
  v_8.z = _World2Object[2].y;
  v_8.w = _World2Object[3].y;
  highp vec4 v_9;
  v_9.x = _World2Object[0].z;
  v_9.y = _World2Object[1].z;
  v_9.z = _World2Object[2].z;
  v_9.w = _World2Object[3].z;
  highp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = normalize(((
    (v_7.xyz * _glesNormal.x)
   + 
    (v_8.xyz * _glesNormal.y)
  ) + (v_9.xyz * _glesNormal.z)));
  mediump vec3 tmpvar_11;
  mediump vec4 normal_12;
  normal_12 = tmpvar_10;
  mediump vec3 x2_13;
  mediump vec3 x1_14;
  x1_14.x = dot (unity_SHAr, normal_12);
  x1_14.y = dot (unity_SHAg, normal_12);
  x1_14.z = dot (unity_SHAb, normal_12);
  mediump vec4 tmpvar_15;
  tmpvar_15 = (normal_12.xyzz * normal_12.yzzx);
  x2_13.x = dot (unity_SHBr, tmpvar_15);
  x2_13.y = dot (unity_SHBg, tmpvar_15);
  x2_13.z = dot (unity_SHBb, tmpvar_15);
  tmpvar_11 = ((x2_13 + (unity_SHC.xyz * 
    ((normal_12.x * normal_12.x) - (normal_12.y * normal_12.y))
  )) + x1_14);
  tmpvar_2 = tmpvar_11;
  gl_Position = tmpvar_3;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = (_Object2World * _glesVertex).xyz;
  xlv_TEXCOORD2 = o_4;
  xlv_TEXCOORD3 = tmpvar_1;
  xlv_TEXCOORD4 = tmpvar_2;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _XYSMap;
uniform sampler2D _LightBuffer;
in highp vec2 xlv_TEXCOORD0;
in highp vec4 xlv_TEXCOORD2;
in highp vec3 xlv_TEXCOORD4;
void main ()
{
  lowp vec4 tmpvar_1;
  mediump vec4 c_2;
  mediump vec4 light_3;
  lowp vec4 tmpvar_4;
  tmpvar_4 = texture (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_5;
  tmpvar_5.x = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.y = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.z = (tmpvar_4.y - tmpvar_4.z);
  lowp vec4 tmpvar_6;
  tmpvar_6 = textureProj (_LightBuffer, xlv_TEXCOORD2);
  light_3 = tmpvar_6;
  mediump vec4 tmpvar_7;
  tmpvar_7 = max (light_3, vec4(0.001, 0.001, 0.001, 0.001));
  light_3.w = tmpvar_7.w;
  highp vec3 tmpvar_8;
  tmpvar_8 = (tmpvar_7.xyz + xlv_TEXCOORD4);
  light_3.xyz = tmpvar_8;
  lowp vec4 c_9;
  c_9.xyz = vec3(0.0, 0.0, 0.0);
  c_9.w = 1.0;
  c_2 = c_9;
  c_2.xyz = (c_2.xyz + tmpvar_5);
  c_2.w = 1.0;
  tmpvar_1 = c_2;
  _glesFragData[0] = tmpvar_1;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 29 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
Bind ""texcoord"" ATTR2
ConstBuffer ""$Globals"" 288
Matrix 80 [glstate_matrix_mvp]
Matrix 144 [_Object2World]
Matrix 208 [_World2Object]
Vector 0 [_ProjectionParams]
VectorHalf 16 [unity_SHAr] 4
VectorHalf 24 [unity_SHAg] 4
VectorHalf 32 [unity_SHAb] 4
VectorHalf 40 [unity_SHBr] 4
VectorHalf 48 [unity_SHBg] 4
VectorHalf 56 [unity_SHBb] 4
VectorHalf 64 [unity_SHC] 4
Vector 272 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
  float4 _glesMultiTexCoord0 [[attribute(2)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  float2 xlv_TEXCOORD0;
  float3 xlv_TEXCOORD1;
  float4 xlv_TEXCOORD2;
  float4 xlv_TEXCOORD3;
  float3 xlv_TEXCOORD4;
};
struct xlatMtlShaderUniform {
  float4 _ProjectionParams;
  half4 unity_SHAr;
  half4 unity_SHAg;
  half4 unity_SHAb;
  half4 unity_SHBr;
  half4 unity_SHBg;
  half4 unity_SHBb;
  half4 unity_SHC;
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  float4 tmpvar_1;
  float3 tmpvar_2;
  float4 tmpvar_3;
  tmpvar_3 = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  float4 o_4;
  float4 tmpvar_5;
  tmpvar_5 = (tmpvar_3 * 0.5);
  float2 tmpvar_6;
  tmpvar_6.x = tmpvar_5.x;
  tmpvar_6.y = (tmpvar_5.y * _mtl_u._ProjectionParams.x);
  o_4.xy = (tmpvar_6 + tmpvar_5.w);
  o_4.zw = tmpvar_3.zw;
  tmpvar_1.zw = float2(0.0, 0.0);
  tmpvar_1.xy = float2(0.0, 0.0);
  float4 v_7;
  v_7.x = _mtl_u._World2Object[0].x;
  v_7.y = _mtl_u._World2Object[1].x;
  v_7.z = _mtl_u._World2Object[2].x;
  v_7.w = _mtl_u._World2Object[3].x;
  float4 v_8;
  v_8.x = _mtl_u._World2Object[0].y;
  v_8.y = _mtl_u._World2Object[1].y;
  v_8.z = _mtl_u._World2Object[2].y;
  v_8.w = _mtl_u._World2Object[3].y;
  float4 v_9;
  v_9.x = _mtl_u._World2Object[0].z;
  v_9.y = _mtl_u._World2Object[1].z;
  v_9.z = _mtl_u._World2Object[2].z;
  v_9.w = _mtl_u._World2Object[3].z;
  float4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = normalize(((
    (v_7.xyz * _mtl_i._glesNormal.x)
   + 
    (v_8.xyz * _mtl_i._glesNormal.y)
  ) + (v_9.xyz * _mtl_i._glesNormal.z)));
  half3 tmpvar_11;
  half4 normal_12;
  normal_12 = half4(tmpvar_10);
  half3 x2_13;
  half3 x1_14;
  x1_14.x = dot (_mtl_u.unity_SHAr, normal_12);
  x1_14.y = dot (_mtl_u.unity_SHAg, normal_12);
  x1_14.z = dot (_mtl_u.unity_SHAb, normal_12);
  half4 tmpvar_15;
  tmpvar_15 = (normal_12.xyzz * normal_12.yzzx);
  x2_13.x = dot (_mtl_u.unity_SHBr, tmpvar_15);
  x2_13.y = dot (_mtl_u.unity_SHBg, tmpvar_15);
  x2_13.z = dot (_mtl_u.unity_SHBb, tmpvar_15);
  tmpvar_11 = ((x2_13 + (_mtl_u.unity_SHC.xyz * 
    ((normal_12.x * normal_12.x) - (normal_12.y * normal_12.y))
  )) + x1_14);
  tmpvar_2 = float3(tmpvar_11);
  _mtl_o.gl_Position = tmpvar_3;
  _mtl_o.xlv_TEXCOORD0 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  _mtl_o.xlv_TEXCOORD1 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  _mtl_o.xlv_TEXCOORD2 = o_4;
  _mtl_o.xlv_TEXCOORD3 = tmpvar_1;
  _mtl_o.xlv_TEXCOORD4 = tmpvar_2;
  return _mtl_o;
}

""
}
}
Program ""fp"" {
SubProgram ""opengl "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 3 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_2_0
def c0, 1, 0, 0, 0
dcl t0.xy
dcl_2d s0
texld_pp r0, t0, s0
add_pp r0.xyz, -r0.z, r0.y
mov_pp r0.w, c0.x
mov_pp oC0, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 1 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0
eefiecedoembbkbdgmmpekbpimhkpddomfikdenhabaaaaaamaabaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefckaaaaaaa
eaaaaaaaciaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
abaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaaaaaaaaaihccabaaaaaaaaaaakgakbaiaebaaaaaaaaaaaaaa
fgafbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab
""
}
SubProgram ""gles "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
// Stats: 1 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0_level_9_1
eefiecedcdhjekjackacdgbpdoaeebfjjfigolfjabaaaaaageacaaaaaeaaaaaa
daaaaaaanaaaaaaahiabaaaadaacaaaaebgpgodjjiaaaaaajiaaaaaaaaacpppp
haaaaaaaciaaaaaaaaaaciaaaaaaciaaaaaaciaaabaaceaaaaaaciaaaaaaaaaa
aaacppppfbaaaaafaaaaapkaaaaaiadpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaac
aaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapkaecaaaaadaaaacpiaaaaaoela
aaaioekaacaaaaadaaaachiaaaaakkibaaaaffiaabaaaaacaaaaciiaaaaaaaka
abaaaaacaaaicpiaaaaaoeiappppaaaafdeieefckaaaaaaaeaaaaaaaciaaaaaa
fkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacabaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
aaaaaaaihccabaaaaaaaaaaakgakbaiaebaaaaaaaaaaaaaafgafbaaaaaaaaaaa
dgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaabejfdeheolaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
keaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapaaaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaa
keaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaaaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl""
}
SubProgram ""gles3 "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 11 math, 2 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float2 xlv_TEXCOORD0;
  float4 xlv_TEXCOORD2;
  float3 xlv_TEXCOORD4;
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]]
  ,   texture2d<half> _XYSMap [[texture(0)]], sampler _mtlsmp__XYSMap [[sampler(0)]]
  ,   texture2d<half> _LightBuffer [[texture(1)]], sampler _mtlsmp__LightBuffer [[sampler(1)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 tmpvar_1;
  half4 c_2;
  half4 light_3;
  half4 tmpvar_4;
  tmpvar_4 = _XYSMap.sample(_mtlsmp__XYSMap, (float2)(_mtl_i.xlv_TEXCOORD0));
  half3 tmpvar_5;
  tmpvar_5.x = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.y = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.z = (tmpvar_4.y - tmpvar_4.z);
  half4 tmpvar_6;
  tmpvar_6 = _LightBuffer.sample(_mtlsmp__LightBuffer, ((float2)(_mtl_i.xlv_TEXCOORD2).xy / (float)(_mtl_i.xlv_TEXCOORD2).w));
  light_3 = tmpvar_6;
  half4 tmpvar_7;
  tmpvar_7 = -(log2(max (light_3, (half4)float4(0.001, 0.001, 0.001, 0.001))));
  light_3.w = tmpvar_7.w;
  float3 tmpvar_8;
  tmpvar_8 = ((float3)tmpvar_7.xyz + _mtl_i.xlv_TEXCOORD4);
  light_3.xyz = half3(tmpvar_8);
  half4 c_9;
  c_9.xyz = half3(float3(0.0, 0.0, 0.0));
  c_9.w = half(1.0);
  c_2 = c_9;
  c_2.xyz = (c_2.xyz + tmpvar_5);
  c_2.w = half(1.0);
  tmpvar_1 = c_2;
  _mtl_o._glesFragData_0 = tmpvar_1;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 3 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_2_0
def c0, 1, 0, 0, 0
dcl t0.xy
dcl_2d s0
texld_pp r0, t0, s0
add_pp r0.xyz, -r0.z, r0.y
mov_pp r0.w, c0.x
mov_pp oC0, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 1 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0
eefiecedoembbkbdgmmpekbpimhkpddomfikdenhabaaaaaamaabaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefckaaaaaaa
eaaaaaaaciaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
abaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaaaaaaaaaihccabaaaaaaaaaaakgakbaiaebaaaaaaaaaaaaaa
fgafbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab
""
}
SubProgram ""gles "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
// Stats: 1 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0_level_9_1
eefiecedcdhjekjackacdgbpdoaeebfjjfigolfjabaaaaaageacaaaaaeaaaaaa
daaaaaaanaaaaaaahiabaaaadaacaaaaebgpgodjjiaaaaaajiaaaaaaaaacpppp
haaaaaaaciaaaaaaaaaaciaaaaaaciaaaaaaciaaabaaceaaaaaaciaaaaaaaaaa
aaacppppfbaaaaafaaaaapkaaaaaiadpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaac
aaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapkaecaaaaadaaaacpiaaaaaoela
aaaioekaacaaaaadaaaachiaaaaakkibaaaaffiaabaaaaacaaaaciiaaaaaaaka
abaaaaacaaaicpiaaaaaoeiappppaaaafdeieefckaaaaaaaeaaaaaaaciaaaaaa
fkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacabaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
aaaaaaaihccabaaaaaaaaaaakgakbaiaebaaaaaaaaaaaaaafgafbaaaaaaaaaaa
dgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaabejfdeheolaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
keaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapaaaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaa
keaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaaaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl""
}
SubProgram ""gles3 "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 9 math, 2 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
SetTexture 0 [_XYSMap] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float2 xlv_TEXCOORD0;
  float4 xlv_TEXCOORD2;
  float3 xlv_TEXCOORD4;
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]]
  ,   texture2d<half> _XYSMap [[texture(0)]], sampler _mtlsmp__XYSMap [[sampler(0)]]
  ,   texture2d<half> _LightBuffer [[texture(1)]], sampler _mtlsmp__LightBuffer [[sampler(1)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 tmpvar_1;
  half4 c_2;
  half4 light_3;
  half4 tmpvar_4;
  tmpvar_4 = _XYSMap.sample(_mtlsmp__XYSMap, (float2)(_mtl_i.xlv_TEXCOORD0));
  half3 tmpvar_5;
  tmpvar_5.x = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.y = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.z = (tmpvar_4.y - tmpvar_4.z);
  half4 tmpvar_6;
  tmpvar_6 = _LightBuffer.sample(_mtlsmp__LightBuffer, ((float2)(_mtl_i.xlv_TEXCOORD2).xy / (float)(_mtl_i.xlv_TEXCOORD2).w));
  light_3 = tmpvar_6;
  half4 tmpvar_7;
  tmpvar_7 = max (light_3, (half4)float4(0.001, 0.001, 0.001, 0.001));
  light_3.w = tmpvar_7.w;
  float3 tmpvar_8;
  tmpvar_8 = ((float3)tmpvar_7.xyz + _mtl_i.xlv_TEXCOORD4);
  light_3.xyz = half3(tmpvar_8);
  half4 c_9;
  c_9.xyz = half3(float3(0.0, 0.0, 0.0));
  c_9.w = half(1.0);
  c_2 = c_9;
  c_2.xyz = (c_2.xyz + tmpvar_5);
  c_2.w = half(1.0);
  tmpvar_1 = c_2;
  _mtl_o._glesFragData_0 = tmpvar_1;
  return _mtl_o;
}

""
}
}
 }


 // Stats for Vertex shader:
 //       d3d11 : 34 math
 //    d3d11_9x : 34 math
 //        d3d9 : 28 math
 //        gles : 12 avg math (11..13), 1 texture
 //       gles3 : 12 avg math (11..13), 1 texture
 //       metal : 26 math
 //      opengl : 11 avg math (10..12), 1 texture
 // Stats for Fragment shader:
 //       d3d11 : 2 avg math (2..3), 1 texture
 //    d3d11_9x : 2 avg math (2..3), 1 texture
 //        d3d9 : 9 avg math (9..10), 1 texture
 //       metal : 12 avg math (11..13), 1 texture
 Pass {
  Name ""DEFERRED""
  Tags { ""LIGHTMODE""=""Deferred"" ""ForceNoShadowCasting""=""true"" ""RenderType""=""Opaque"" }
  GpuProgramID 274836
Program ""vp"" {
SubProgram ""opengl "" {
// Stats: 12 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLSL
#ifdef VERTEX
uniform vec4 unity_SHAr;
uniform vec4 unity_SHAg;
uniform vec4 unity_SHAb;
uniform vec4 unity_SHBr;
uniform vec4 unity_SHBg;
uniform vec4 unity_SHBb;
uniform vec4 unity_SHC;

uniform mat4 _Object2World;
uniform mat4 _World2Object;
uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
varying vec3 xlv_TEXCOORD2;
varying vec4 xlv_TEXCOORD4;
varying vec3 xlv_TEXCOORD5;
void main ()
{
  vec4 tmpvar_1;
  vec4 v_2;
  v_2.x = _World2Object[0].x;
  v_2.y = _World2Object[1].x;
  v_2.z = _World2Object[2].x;
  v_2.w = _World2Object[3].x;
  vec4 v_3;
  v_3.x = _World2Object[0].y;
  v_3.y = _World2Object[1].y;
  v_3.z = _World2Object[2].y;
  v_3.w = _World2Object[3].y;
  vec4 v_4;
  v_4.x = _World2Object[0].z;
  v_4.y = _World2Object[1].z;
  v_4.z = _World2Object[2].z;
  v_4.w = _World2Object[3].z;
  vec3 tmpvar_5;
  tmpvar_5 = normalize(((
    (v_2.xyz * gl_Normal.x)
   + 
    (v_3.xyz * gl_Normal.y)
  ) + (v_4.xyz * gl_Normal.z)));
  tmpvar_1.zw = vec2(0.0, 0.0);
  tmpvar_1.xy = vec2(0.0, 0.0);
  vec4 tmpvar_6;
  tmpvar_6.w = 1.0;
  tmpvar_6.xyz = tmpvar_5;
  vec3 x2_7;
  vec3 x1_8;
  x1_8.x = dot (unity_SHAr, tmpvar_6);
  x1_8.y = dot (unity_SHAg, tmpvar_6);
  x1_8.z = dot (unity_SHAb, tmpvar_6);
  vec4 tmpvar_9;
  tmpvar_9 = (tmpvar_5.xyzz * tmpvar_5.yzzx);
  x2_7.x = dot (unity_SHBr, tmpvar_9);
  x2_7.y = dot (unity_SHBg, tmpvar_9);
  x2_7.z = dot (unity_SHBb, tmpvar_9);
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_5;
  xlv_TEXCOORD2 = (_Object2World * gl_Vertex).xyz;
  xlv_TEXCOORD4 = tmpvar_1;
  xlv_TEXCOORD5 = ((x2_7 + (unity_SHC.xyz * 
    ((tmpvar_5.x * tmpvar_5.x) - (tmpvar_5.y * tmpvar_5.y))
  )) + x1_8);
}


#endif
#ifdef FRAGMENT
uniform sampler2D _XYSMap;
varying vec2 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
void main ()
{
  vec4 outDiffuse_1;
  vec4 outEmission_2;
  vec4 tmpvar_3;
  tmpvar_3 = texture2D (_XYSMap, xlv_TEXCOORD0);
  vec3 tmpvar_4;
  tmpvar_4.x = (tmpvar_3.y - tmpvar_3.z);
  tmpvar_4.y = (tmpvar_3.y - tmpvar_3.z);
  tmpvar_4.z = (tmpvar_3.y - tmpvar_3.z);
  vec4 emission_5;
  vec4 tmpvar_6;
  tmpvar_6.w = 1.0;
  tmpvar_6.xyz = ((xlv_TEXCOORD1 * 0.5) + 0.5);
  vec4 tmpvar_7;
  tmpvar_7.w = 1.0;
  tmpvar_7.xyz = tmpvar_4;
  emission_5.w = tmpvar_7.w;
  emission_5.xyz = tmpvar_4;
  outDiffuse_1.xyz = vec3(0.0, 0.0, 0.0);
  outEmission_2.w = emission_5.w;
  outDiffuse_1.w = 1.0;
  outEmission_2.xyz = exp2(-(tmpvar_4));
  gl_FragData[0] = outDiffuse_1;
  gl_FragData[1] = vec4(0.0, 0.0, 0.0, 0.0);
  gl_FragData[2] = tmpvar_6;
  gl_FragData[3] = outEmission_2;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 28 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
Vector 17 [_MainTex_ST]
Vector 12 [unity_SHAb]
Vector 11 [unity_SHAg]
Vector 10 [unity_SHAr]
Vector 15 [unity_SHBb]
Vector 14 [unity_SHBg]
Vector 13 [unity_SHBr]
Vector 16 [unity_SHC]
""vs_2_0
def c18, 1, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord v2
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
mad oT0.xy, v2, c17, c17.zwzw
dp4 oT2.x, c4, v0
dp4 oT2.y, c5, v0
dp4 oT2.z, c6, v0
mul r0.xyz, v1.y, c8
mad r0.xyz, c7, v1.x, r0
mad r0.xyz, c9, v1.z, r0
nrm r1.xyz, r0
mul r0.x, r1.y, r1.y
mad r0.x, r1.x, r1.x, -r0.x
mul r2, r1.yzzx, r1.xyzz
dp4 r3.x, c13, r2
dp4 r3.y, c14, r2
dp4 r3.z, c15, r2
mad r0.xyz, c16, r0.x, r3
mov r1.w, c18.x
dp4 r2.x, c10, r1
dp4 r2.y, c11, r1
dp4 r2.z, c12, r1
mov oT1.xyz, r1
add oT5.xyz, r0, r2
mov oT4, c18.y

""
}
SubProgram ""d3d11 "" {
// Stats: 34 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 176
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityLighting"" 1
BindCB  ""UnityPerDraw"" 2
""vs_4_0
eefiecedkmekdkdnlnoileefpmkfciobknnolkmfabaaaaaaeeahaaaaadaaaaaa
cmaaaaaaceabaaaanmabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapaaaaaakeaaaaaaafaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
gaafaaaaeaaaabaafiabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaae
egiocaaaabaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
hccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaaibcaabaaa
aaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaa
aaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaa
aaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabcaaaaaadiaaaaaibcaabaaa
abaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaa
abaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaa
abaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaa
ckbabaaaacaaaaaackiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
ckbabaaaacaaaaaackiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
ckbabaaaacaaaaaackiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaaf
hccabaaaacaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaa
aaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaa
acaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaakhccabaaaadaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaabaaaaaadgaaaaaipccabaaaaeaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaaaaaaaaaabkaabaaa
aaaaaaaadcaaaaakbcaabaaaabaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaa
akaabaiaebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaa
egakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaa
egaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaa
egaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaa
egaobaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaacmaaaaaa
agaabaaaabaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaa
aaaaiadpbbaaaaaibcaabaaaacaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaa
aaaaaaaabbaaaaaiccaabaaaacaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaa
aaaaaaaabbaaaaaiecaabaaaacaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaa
aaaaaaaaaaaaaaahhccabaaaafaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaa
doaaaaab""
}
SubProgram ""gles "" {
// Stats: 13 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying mediump vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD4;
varying mediump vec3 xlv_TEXCOORD5;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 tmpvar_3;
  highp vec4 v_4;
  v_4.x = _World2Object[0].x;
  v_4.y = _World2Object[1].x;
  v_4.z = _World2Object[2].x;
  v_4.w = _World2Object[3].x;
  highp vec4 v_5;
  v_5.x = _World2Object[0].y;
  v_5.y = _World2Object[1].y;
  v_5.z = _World2Object[2].y;
  v_5.w = _World2Object[3].y;
  highp vec4 v_6;
  v_6.x = _World2Object[0].z;
  v_6.y = _World2Object[1].z;
  v_6.z = _World2Object[2].z;
  v_6.w = _World2Object[3].z;
  highp vec3 tmpvar_7;
  tmpvar_7 = normalize(((
    (v_4.xyz * _glesNormal.x)
   + 
    (v_5.xyz * _glesNormal.y)
  ) + (v_6.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_7;
  tmpvar_2 = worldNormal_1;
  tmpvar_3.zw = vec2(0.0, 0.0);
  tmpvar_3.xy = vec2(0.0, 0.0);
  lowp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = worldNormal_1;
  mediump vec4 normal_9;
  normal_9 = tmpvar_8;
  mediump vec3 x2_10;
  mediump vec3 x1_11;
  x1_11.x = dot (unity_SHAr, normal_9);
  x1_11.y = dot (unity_SHAg, normal_9);
  x1_11.z = dot (unity_SHAb, normal_9);
  mediump vec4 tmpvar_12;
  tmpvar_12 = (normal_9.xyzz * normal_9.yzzx);
  x2_10.x = dot (unity_SHBr, tmpvar_12);
  x2_10.y = dot (unity_SHBg, tmpvar_12);
  x2_10.z = dot (unity_SHBb, tmpvar_12);
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = (_Object2World * _glesVertex).xyz;
  xlv_TEXCOORD4 = tmpvar_3;
  xlv_TEXCOORD5 = ((x2_10 + (unity_SHC.xyz * 
    ((normal_9.x * normal_9.x) - (normal_9.y * normal_9.y))
  )) + x1_11);
}



#endif
#ifdef FRAGMENT

#extension GL_EXT_draw_buffers : require
uniform sampler2D _XYSMap;
varying highp vec2 xlv_TEXCOORD0;
varying mediump vec3 xlv_TEXCOORD1;
void main ()
{
  mediump vec4 outDiffuse_1;
  mediump vec4 outEmission_2;
  lowp vec3 tmpvar_3;
  tmpvar_3 = xlv_TEXCOORD1;
  lowp vec4 tmpvar_4;
  tmpvar_4 = texture2D (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_5;
  tmpvar_5.x = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.y = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.z = (tmpvar_4.y - tmpvar_4.z);
  mediump vec4 outDiffuseOcclusion_6;
  mediump vec4 outNormal_7;
  mediump vec4 emission_8;
  lowp vec4 tmpvar_9;
  tmpvar_9.w = 1.0;
  tmpvar_9.xyz = vec3(0.0, 0.0, 0.0);
  outDiffuseOcclusion_6 = tmpvar_9;
  lowp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = ((tmpvar_3 * 0.5) + 0.5);
  outNormal_7 = tmpvar_10;
  lowp vec4 tmpvar_11;
  tmpvar_11.w = 1.0;
  tmpvar_11.xyz = tmpvar_5;
  emission_8 = tmpvar_11;
  emission_8.xyz = emission_8.xyz;
  outDiffuse_1.xyz = outDiffuseOcclusion_6.xyz;
  outEmission_2.w = emission_8.w;
  outDiffuse_1.w = 1.0;
  outEmission_2.xyz = exp2(-(emission_8.xyz));
  gl_FragData[0] = outDiffuse_1;
  gl_FragData[1] = vec4(0.0, 0.0, 0.0, 0.0);
  gl_FragData[2] = outNormal_7;
  gl_FragData[3] = outEmission_2;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 34 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 176
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityLighting"" 1
BindCB  ""UnityPerDraw"" 2
""vs_4_0_level_9_1
eefiecedcncjcibdbckmeihmjeoaadaefdjljinjabaaaaaafaakaaaaaeaaaaaa
daaaaaaadiadaaaakaaiaaaajiajaaaaebgpgodjaaadaaaaaaadaaaaaaacpopp
kiacaaaafiaaaaaaaeaaceaaaaaafeaaaaaafeaaaaaaceaaabaafeaaaaaaajaa
abaaabaaaaaaaaaaabaacgaaahaaacaaaaaaaaaaacaaaaaaaeaaajaaaaaaaaaa
acaaamaaahaaanaaaaaaaaaaaaaaaaaaaaacpoppfbaaaaafbeaaapkaaaaaiadp
aaaaaaaaaaaaaaaaaaaaaaaabpaaaaacafaaaaiaaaaaapjabpaaaaacafaaacia
acaaapjabpaaaaacafaaadiaadaaapjaaeaaaaaeaaaaadoaadaaoejaabaaoeka
abaaookaafaaaaadaaaaahiaaaaaffjaaoaaoekaaeaaaaaeaaaaahiaanaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaahiaapaaoekaaaaakkjaaaaaoeiaaeaaaaae
acaaahoabaaaoekaaaaappjaaaaaoeiaafaaaaadaaaaabiaacaaaajabbaaaaka
afaaaaadaaaaaciaacaaaajabcaaaakaafaaaaadaaaaaeiaacaaaajabdaaaaka
afaaaaadabaaabiaacaaffjabbaaffkaafaaaaadabaaaciaacaaffjabcaaffka
afaaaaadabaaaeiaacaaffjabdaaffkaacaaaaadaaaaahiaaaaaoeiaabaaoeia
afaaaaadabaaabiaacaakkjabbaakkkaafaaaaadabaaaciaacaakkjabcaakkka
afaaaaadabaaaeiaacaakkjabdaakkkaacaaaaadaaaaahiaaaaaoeiaabaaoeia
ceaaaaacabaaahiaaaaaoeiaafaaaaadaaaaabiaabaaffiaabaaffiaaeaaaaae
aaaaabiaabaaaaiaabaaaaiaaaaaaaibafaaaaadacaaapiaabaacjiaabaakeia
ajaaaaadadaaabiaafaaoekaacaaoeiaajaaaaadadaaaciaagaaoekaacaaoeia
ajaaaaadadaaaeiaahaaoekaacaaoeiaaeaaaaaeaaaaahiaaiaaoekaaaaaaaia
adaaoeiaabaaaaacabaaaiiabeaaaakaajaaaaadacaaabiaacaaoekaabaaoeia
ajaaaaadacaaaciaadaaoekaabaaoeiaajaaaaadacaaaeiaaeaaoekaabaaoeia
abaaaaacabaaahoaabaaoeiaacaaaaadaeaaahoaaaaaoeiaacaaoeiaafaaaaad
aaaaapiaaaaaffjaakaaoekaaeaaaaaeaaaaapiaajaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaalaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaamaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiaabaaaaacadaaapoabeaaffkappppaaaafdeieefcgaafaaaa
eaaaabaafiabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaa
abaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaafhccabaaa
acaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaaaaaaaaaa
egiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaa
amaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hccabaaaadaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaa
abaaaaaadgaaaaaipccabaaaaeaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaa
dcaaaaakbcaabaaaabaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaia
ebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaa
aaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaa
acaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaa
acaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaa
acaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaacmaaaaaaagaabaaa
abaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadp
bbaaaaaibcaabaaaacaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaa
bbaaaaaiccaabaaaacaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaa
bbaaaaaiecaabaaaacaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaa
aaaaaaahhccabaaaafaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaadoaaaaab
ejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
njaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaaoaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaaabaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
oaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaaapaaaaaaojaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofe
aaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
keaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaa
keaaaaaaafaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 13 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out mediump vec3 xlv_TEXCOORD1;
out highp vec3 xlv_TEXCOORD2;
out highp vec4 xlv_TEXCOORD4;
out mediump vec3 xlv_TEXCOORD5;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 tmpvar_3;
  highp vec4 v_4;
  v_4.x = _World2Object[0].x;
  v_4.y = _World2Object[1].x;
  v_4.z = _World2Object[2].x;
  v_4.w = _World2Object[3].x;
  highp vec4 v_5;
  v_5.x = _World2Object[0].y;
  v_5.y = _World2Object[1].y;
  v_5.z = _World2Object[2].y;
  v_5.w = _World2Object[3].y;
  highp vec4 v_6;
  v_6.x = _World2Object[0].z;
  v_6.y = _World2Object[1].z;
  v_6.z = _World2Object[2].z;
  v_6.w = _World2Object[3].z;
  highp vec3 tmpvar_7;
  tmpvar_7 = normalize(((
    (v_4.xyz * _glesNormal.x)
   + 
    (v_5.xyz * _glesNormal.y)
  ) + (v_6.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_7;
  tmpvar_2 = worldNormal_1;
  tmpvar_3.zw = vec2(0.0, 0.0);
  tmpvar_3.xy = vec2(0.0, 0.0);
  lowp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = worldNormal_1;
  mediump vec4 normal_9;
  normal_9 = tmpvar_8;
  mediump vec3 x2_10;
  mediump vec3 x1_11;
  x1_11.x = dot (unity_SHAr, normal_9);
  x1_11.y = dot (unity_SHAg, normal_9);
  x1_11.z = dot (unity_SHAb, normal_9);
  mediump vec4 tmpvar_12;
  tmpvar_12 = (normal_9.xyzz * normal_9.yzzx);
  x2_10.x = dot (unity_SHBr, tmpvar_12);
  x2_10.y = dot (unity_SHBg, tmpvar_12);
  x2_10.z = dot (unity_SHBb, tmpvar_12);
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = (_Object2World * _glesVertex).xyz;
  xlv_TEXCOORD4 = tmpvar_3;
  xlv_TEXCOORD5 = ((x2_10 + (unity_SHC.xyz * 
    ((normal_9.x * normal_9.x) - (normal_9.y * normal_9.y))
  )) + x1_11);
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _XYSMap;
in highp vec2 xlv_TEXCOORD0;
in mediump vec3 xlv_TEXCOORD1;
void main ()
{
  mediump vec4 outDiffuse_1;
  mediump vec4 outEmission_2;
  lowp vec3 tmpvar_3;
  tmpvar_3 = xlv_TEXCOORD1;
  lowp vec4 tmpvar_4;
  tmpvar_4 = texture (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_5;
  tmpvar_5.x = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.y = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.z = (tmpvar_4.y - tmpvar_4.z);
  mediump vec4 outDiffuseOcclusion_6;
  mediump vec4 outNormal_7;
  mediump vec4 emission_8;
  lowp vec4 tmpvar_9;
  tmpvar_9.w = 1.0;
  tmpvar_9.xyz = vec3(0.0, 0.0, 0.0);
  outDiffuseOcclusion_6 = tmpvar_9;
  lowp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = ((tmpvar_3 * 0.5) + 0.5);
  outNormal_7 = tmpvar_10;
  lowp vec4 tmpvar_11;
  tmpvar_11.w = 1.0;
  tmpvar_11.xyz = tmpvar_5;
  emission_8 = tmpvar_11;
  emission_8.xyz = emission_8.xyz;
  outDiffuse_1.xyz = outDiffuseOcclusion_6.xyz;
  outEmission_2.w = emission_8.w;
  outDiffuse_1.w = 1.0;
  outEmission_2.xyz = exp2(-(emission_8.xyz));
  _glesFragData[0] = outDiffuse_1;
  _glesFragData[1] = vec4(0.0, 0.0, 0.0, 0.0);
  _glesFragData[2] = outNormal_7;
  _glesFragData[3] = outEmission_2;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 26 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
Bind ""texcoord"" ATTR2
ConstBuffer ""$Globals"" 272
Matrix 64 [glstate_matrix_mvp]
Matrix 128 [_Object2World]
Matrix 192 [_World2Object]
VectorHalf 0 [unity_SHAr] 4
VectorHalf 8 [unity_SHAg] 4
VectorHalf 16 [unity_SHAb] 4
VectorHalf 24 [unity_SHBr] 4
VectorHalf 32 [unity_SHBg] 4
VectorHalf 40 [unity_SHBb] 4
VectorHalf 48 [unity_SHC] 4
Vector 256 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
  float4 _glesMultiTexCoord0 [[attribute(2)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  float2 xlv_TEXCOORD0;
  half3 xlv_TEXCOORD1;
  float3 xlv_TEXCOORD2;
  float4 xlv_TEXCOORD4;
  half3 xlv_TEXCOORD5;
};
struct xlatMtlShaderUniform {
  half4 unity_SHAr;
  half4 unity_SHAg;
  half4 unity_SHAb;
  half4 unity_SHBr;
  half4 unity_SHBg;
  half4 unity_SHBb;
  half4 unity_SHC;
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  float4 tmpvar_3;
  float4 v_4;
  v_4.x = _mtl_u._World2Object[0].x;
  v_4.y = _mtl_u._World2Object[1].x;
  v_4.z = _mtl_u._World2Object[2].x;
  v_4.w = _mtl_u._World2Object[3].x;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].y;
  v_5.y = _mtl_u._World2Object[1].y;
  v_5.z = _mtl_u._World2Object[2].y;
  v_5.w = _mtl_u._World2Object[3].y;
  float4 v_6;
  v_6.x = _mtl_u._World2Object[0].z;
  v_6.y = _mtl_u._World2Object[1].z;
  v_6.z = _mtl_u._World2Object[2].z;
  v_6.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_7;
  tmpvar_7 = normalize(((
    (v_4.xyz * _mtl_i._glesNormal.x)
   + 
    (v_5.xyz * _mtl_i._glesNormal.y)
  ) + (v_6.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_7);
  tmpvar_2 = worldNormal_1;
  tmpvar_3.zw = float2(0.0, 0.0);
  tmpvar_3.xy = float2(0.0, 0.0);
  half4 tmpvar_8;
  tmpvar_8.w = half(1.0);
  tmpvar_8.xyz = worldNormal_1;
  half4 normal_9;
  normal_9 = tmpvar_8;
  half3 x2_10;
  half3 x1_11;
  x1_11.x = dot (_mtl_u.unity_SHAr, normal_9);
  x1_11.y = dot (_mtl_u.unity_SHAg, normal_9);
  x1_11.z = dot (_mtl_u.unity_SHAb, normal_9);
  half4 tmpvar_12;
  tmpvar_12 = (normal_9.xyzz * normal_9.yzzx);
  x2_10.x = dot (_mtl_u.unity_SHBr, tmpvar_12);
  x2_10.y = dot (_mtl_u.unity_SHBg, tmpvar_12);
  x2_10.z = dot (_mtl_u.unity_SHBb, tmpvar_12);
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  _mtl_o.xlv_TEXCOORD1 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD2 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  _mtl_o.xlv_TEXCOORD4 = tmpvar_3;
  _mtl_o.xlv_TEXCOORD5 = ((x2_10 + (_mtl_u.unity_SHC.xyz * 
    ((normal_9.x * normal_9.x) - (normal_9.y * normal_9.y))
  )) + x1_11);
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
// Stats: 10 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLSL
#ifdef VERTEX
uniform vec4 unity_SHAr;
uniform vec4 unity_SHAg;
uniform vec4 unity_SHAb;
uniform vec4 unity_SHBr;
uniform vec4 unity_SHBg;
uniform vec4 unity_SHBb;
uniform vec4 unity_SHC;

uniform mat4 _Object2World;
uniform mat4 _World2Object;
uniform vec4 _MainTex_ST;
varying vec2 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
varying vec3 xlv_TEXCOORD2;
varying vec4 xlv_TEXCOORD4;
varying vec3 xlv_TEXCOORD5;
void main ()
{
  vec4 tmpvar_1;
  vec4 v_2;
  v_2.x = _World2Object[0].x;
  v_2.y = _World2Object[1].x;
  v_2.z = _World2Object[2].x;
  v_2.w = _World2Object[3].x;
  vec4 v_3;
  v_3.x = _World2Object[0].y;
  v_3.y = _World2Object[1].y;
  v_3.z = _World2Object[2].y;
  v_3.w = _World2Object[3].y;
  vec4 v_4;
  v_4.x = _World2Object[0].z;
  v_4.y = _World2Object[1].z;
  v_4.z = _World2Object[2].z;
  v_4.w = _World2Object[3].z;
  vec3 tmpvar_5;
  tmpvar_5 = normalize(((
    (v_2.xyz * gl_Normal.x)
   + 
    (v_3.xyz * gl_Normal.y)
  ) + (v_4.xyz * gl_Normal.z)));
  tmpvar_1.zw = vec2(0.0, 0.0);
  tmpvar_1.xy = vec2(0.0, 0.0);
  vec4 tmpvar_6;
  tmpvar_6.w = 1.0;
  tmpvar_6.xyz = tmpvar_5;
  vec3 x2_7;
  vec3 x1_8;
  x1_8.x = dot (unity_SHAr, tmpvar_6);
  x1_8.y = dot (unity_SHAg, tmpvar_6);
  x1_8.z = dot (unity_SHAb, tmpvar_6);
  vec4 tmpvar_9;
  tmpvar_9 = (tmpvar_5.xyzz * tmpvar_5.yzzx);
  x2_7.x = dot (unity_SHBr, tmpvar_9);
  x2_7.y = dot (unity_SHBg, tmpvar_9);
  x2_7.z = dot (unity_SHBb, tmpvar_9);
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = ((gl_MultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_5;
  xlv_TEXCOORD2 = (_Object2World * gl_Vertex).xyz;
  xlv_TEXCOORD4 = tmpvar_1;
  xlv_TEXCOORD5 = ((x2_7 + (unity_SHC.xyz * 
    ((tmpvar_5.x * tmpvar_5.x) - (tmpvar_5.y * tmpvar_5.y))
  )) + x1_8);
}


#endif
#ifdef FRAGMENT
uniform sampler2D _XYSMap;
varying vec2 xlv_TEXCOORD0;
varying vec3 xlv_TEXCOORD1;
void main ()
{
  vec4 outDiffuse_1;
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_XYSMap, xlv_TEXCOORD0);
  vec3 tmpvar_3;
  tmpvar_3.x = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.y = (tmpvar_2.y - tmpvar_2.z);
  tmpvar_3.z = (tmpvar_2.y - tmpvar_2.z);
  vec4 emission_4;
  vec4 tmpvar_5;
  tmpvar_5.w = 1.0;
  tmpvar_5.xyz = ((xlv_TEXCOORD1 * 0.5) + 0.5);
  vec4 tmpvar_6;
  tmpvar_6.w = 1.0;
  tmpvar_6.xyz = tmpvar_3;
  emission_4.w = tmpvar_6.w;
  emission_4.xyz = tmpvar_3;
  outDiffuse_1.xyz = vec3(0.0, 0.0, 0.0);
  outDiffuse_1.w = 1.0;
  gl_FragData[0] = outDiffuse_1;
  gl_FragData[1] = vec4(0.0, 0.0, 0.0, 0.0);
  gl_FragData[2] = tmpvar_5;
  gl_FragData[3] = emission_4;
}


#endif
""
}
SubProgram ""d3d9 "" {
// Stats: 28 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
Bind ""vertex"" Vertex
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
Matrix 4 [_Object2World] 3
Matrix 7 [_World2Object] 3
Matrix 0 [glstate_matrix_mvp]
Vector 17 [_MainTex_ST]
Vector 12 [unity_SHAb]
Vector 11 [unity_SHAg]
Vector 10 [unity_SHAr]
Vector 15 [unity_SHBb]
Vector 14 [unity_SHBg]
Vector 13 [unity_SHBr]
Vector 16 [unity_SHC]
""vs_2_0
def c18, 1, 0, 0, 0
dcl_position v0
dcl_normal v1
dcl_texcoord v2
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
mad oT0.xy, v2, c17, c17.zwzw
dp4 oT2.x, c4, v0
dp4 oT2.y, c5, v0
dp4 oT2.z, c6, v0
mul r0.xyz, v1.y, c8
mad r0.xyz, c7, v1.x, r0
mad r0.xyz, c9, v1.z, r0
nrm r1.xyz, r0
mul r0.x, r1.y, r1.y
mad r0.x, r1.x, r1.x, -r0.x
mul r2, r1.yzzx, r1.xyzz
dp4 r3.x, c13, r2
dp4 r3.y, c14, r2
dp4 r3.z, c15, r2
mad r0.xyz, c16, r0.x, r3
mov r1.w, c18.x
dp4 r2.x, c10, r1
dp4 r2.y, c11, r1
dp4 r2.z, c12, r1
mov oT1.xyz, r1
add oT5.xyz, r0, r2
mov oT4, c18.y

""
}
SubProgram ""d3d11 "" {
// Stats: 34 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 176
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityLighting"" 1
BindCB  ""UnityPerDraw"" 2
""vs_4_0
eefiecedkmekdkdnlnoileefpmkfciobknnolkmfabaaaaaaeeahaaaaadaaaaaa
cmaaaaaaceabaaaanmabaaaaejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaanjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaoaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaaoaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apaaaaaaojaaaaaaaaaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapaaaaaakeaaaaaaafaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
gaafaaaaeaaaabaafiabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaae
egiocaaaabaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
hccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaaibcaabaaa
aaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaa
aaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaa
aaaaaaaaakbabaaaacaaaaaaakiacaaaacaaaaaabcaaaaaadiaaaaaibcaabaaa
abaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaa
abaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaa
abaaaaaabkbabaaaacaaaaaabkiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaa
ckbabaaaacaaaaaackiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
ckbabaaaacaaaaaackiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
ckbabaaaacaaaaaackiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaaf
hccabaaaacaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaa
aaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaa
acaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaakhccabaaaadaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaabaaaaaadgaaaaaipccabaaaaeaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaaaaaaaaaabkaabaaa
aaaaaaaadcaaaaakbcaabaaaabaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaa
akaabaiaebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaa
egakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaa
egaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaa
egaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaa
egaobaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaacmaaaaaa
agaabaaaabaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaa
aaaaiadpbbaaaaaibcaabaaaacaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaa
aaaaaaaabbaaaaaiccaabaaaacaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaa
aaaaaaaabbaaaaaiecaabaaaacaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaa
aaaaaaaaaaaaaaahhccabaaaafaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaa
doaaaaab""
}
SubProgram ""gles "" {
// Stats: 11 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying mediump vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD4;
varying mediump vec3 xlv_TEXCOORD5;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 tmpvar_3;
  highp vec4 v_4;
  v_4.x = _World2Object[0].x;
  v_4.y = _World2Object[1].x;
  v_4.z = _World2Object[2].x;
  v_4.w = _World2Object[3].x;
  highp vec4 v_5;
  v_5.x = _World2Object[0].y;
  v_5.y = _World2Object[1].y;
  v_5.z = _World2Object[2].y;
  v_5.w = _World2Object[3].y;
  highp vec4 v_6;
  v_6.x = _World2Object[0].z;
  v_6.y = _World2Object[1].z;
  v_6.z = _World2Object[2].z;
  v_6.w = _World2Object[3].z;
  highp vec3 tmpvar_7;
  tmpvar_7 = normalize(((
    (v_4.xyz * _glesNormal.x)
   + 
    (v_5.xyz * _glesNormal.y)
  ) + (v_6.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_7;
  tmpvar_2 = worldNormal_1;
  tmpvar_3.zw = vec2(0.0, 0.0);
  tmpvar_3.xy = vec2(0.0, 0.0);
  lowp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = worldNormal_1;
  mediump vec4 normal_9;
  normal_9 = tmpvar_8;
  mediump vec3 x2_10;
  mediump vec3 x1_11;
  x1_11.x = dot (unity_SHAr, normal_9);
  x1_11.y = dot (unity_SHAg, normal_9);
  x1_11.z = dot (unity_SHAb, normal_9);
  mediump vec4 tmpvar_12;
  tmpvar_12 = (normal_9.xyzz * normal_9.yzzx);
  x2_10.x = dot (unity_SHBr, tmpvar_12);
  x2_10.y = dot (unity_SHBg, tmpvar_12);
  x2_10.z = dot (unity_SHBb, tmpvar_12);
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = (_Object2World * _glesVertex).xyz;
  xlv_TEXCOORD4 = tmpvar_3;
  xlv_TEXCOORD5 = ((x2_10 + (unity_SHC.xyz * 
    ((normal_9.x * normal_9.x) - (normal_9.y * normal_9.y))
  )) + x1_11);
}



#endif
#ifdef FRAGMENT

#extension GL_EXT_draw_buffers : require
uniform sampler2D _XYSMap;
varying highp vec2 xlv_TEXCOORD0;
varying mediump vec3 xlv_TEXCOORD1;
void main ()
{
  mediump vec4 outDiffuse_1;
  lowp vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp vec4 tmpvar_3;
  tmpvar_3 = texture2D (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_4;
  tmpvar_4.x = (tmpvar_3.y - tmpvar_3.z);
  tmpvar_4.y = (tmpvar_3.y - tmpvar_3.z);
  tmpvar_4.z = (tmpvar_3.y - tmpvar_3.z);
  mediump vec4 outDiffuseOcclusion_5;
  mediump vec4 outNormal_6;
  mediump vec4 emission_7;
  lowp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = vec3(0.0, 0.0, 0.0);
  outDiffuseOcclusion_5 = tmpvar_8;
  lowp vec4 tmpvar_9;
  tmpvar_9.w = 1.0;
  tmpvar_9.xyz = ((tmpvar_2 * 0.5) + 0.5);
  outNormal_6 = tmpvar_9;
  lowp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = tmpvar_4;
  emission_7 = tmpvar_10;
  emission_7.xyz = emission_7.xyz;
  outDiffuse_1.xyz = outDiffuseOcclusion_5.xyz;
  outDiffuse_1.w = 1.0;
  gl_FragData[0] = outDiffuse_1;
  gl_FragData[1] = vec4(0.0, 0.0, 0.0, 0.0);
  gl_FragData[2] = outNormal_6;
  gl_FragData[3] = emission_7;
}



#endif""
}
SubProgram ""d3d11_9x "" {
// Stats: 34 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
Bind ""vertex"" Vertex
Bind ""color"" Color
Bind ""normal"" Normal
Bind ""texcoord"" TexCoord0
ConstBuffer ""$Globals"" 176
Vector 144 [_MainTex_ST]
ConstBuffer ""UnityLighting"" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer ""UnityPerDraw"" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  ""$Globals"" 0
BindCB  ""UnityLighting"" 1
BindCB  ""UnityPerDraw"" 2
""vs_4_0_level_9_1
eefiecedcncjcibdbckmeihmjeoaadaefdjljinjabaaaaaafaakaaaaaeaaaaaa
daaaaaaadiadaaaakaaiaaaajiajaaaaebgpgodjaaadaaaaaaadaaaaaaacpopp
kiacaaaafiaaaaaaaeaaceaaaaaafeaaaaaafeaaaaaaceaaabaafeaaaaaaajaa
abaaabaaaaaaaaaaabaacgaaahaaacaaaaaaaaaaacaaaaaaaeaaajaaaaaaaaaa
acaaamaaahaaanaaaaaaaaaaaaaaaaaaaaacpoppfbaaaaafbeaaapkaaaaaiadp
aaaaaaaaaaaaaaaaaaaaaaaabpaaaaacafaaaaiaaaaaapjabpaaaaacafaaacia
acaaapjabpaaaaacafaaadiaadaaapjaaeaaaaaeaaaaadoaadaaoejaabaaoeka
abaaookaafaaaaadaaaaahiaaaaaffjaaoaaoekaaeaaaaaeaaaaahiaanaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaahiaapaaoekaaaaakkjaaaaaoeiaaeaaaaae
acaaahoabaaaoekaaaaappjaaaaaoeiaafaaaaadaaaaabiaacaaaajabbaaaaka
afaaaaadaaaaaciaacaaaajabcaaaakaafaaaaadaaaaaeiaacaaaajabdaaaaka
afaaaaadabaaabiaacaaffjabbaaffkaafaaaaadabaaaciaacaaffjabcaaffka
afaaaaadabaaaeiaacaaffjabdaaffkaacaaaaadaaaaahiaaaaaoeiaabaaoeia
afaaaaadabaaabiaacaakkjabbaakkkaafaaaaadabaaaciaacaakkjabcaakkka
afaaaaadabaaaeiaacaakkjabdaakkkaacaaaaadaaaaahiaaaaaoeiaabaaoeia
ceaaaaacabaaahiaaaaaoeiaafaaaaadaaaaabiaabaaffiaabaaffiaaeaaaaae
aaaaabiaabaaaaiaabaaaaiaaaaaaaibafaaaaadacaaapiaabaacjiaabaakeia
ajaaaaadadaaabiaafaaoekaacaaoeiaajaaaaadadaaaciaagaaoekaacaaoeia
ajaaaaadadaaaeiaahaaoekaacaaoeiaaeaaaaaeaaaaahiaaiaaoekaaaaaaaia
adaaoeiaabaaaaacabaaaiiabeaaaakaajaaaaadacaaabiaacaaoekaabaaoeia
ajaaaaadacaaaciaadaaoekaabaaoeiaajaaaaadacaaaeiaaeaaoekaabaaoeia
abaaaaacabaaahoaabaaoeiaacaaaaadaeaaahoaaaaaoeiaacaaoeiaafaaaaad
aaaaapiaaaaaffjaakaaoekaaeaaaaaeaaaaapiaajaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaalaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaamaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiaabaaaaacadaaapoabeaaffkappppaaaafdeieefcgaafaaaa
eaaaabaafiabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaa
abaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaaibcaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaaaaaaaaa
akbabaaaacaaaaaaakiacaaaacaaaaaabcaaaaaadiaaaaaibcaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaa
bkbabaaaacaaaaaabkiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabaaaaaaadiaaaaaiccaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabbaaaaaadiaaaaaiecaabaaaabaaaaaackbabaaa
acaaaaaackiacaaaacaaaaaabcaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaafhccabaaa
acaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaaaaaaaaaa
egiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaa
amaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hccabaaaadaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaa
abaaaaaadgaaaaaipccabaaaaeaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaa
dcaaaaakbcaabaaaabaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaia
ebaaaaaaabaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaa
aaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaa
acaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaa
acaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaa
acaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaacmaaaaaaagaabaaa
abaaaaaaegacbaaaadaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadp
bbaaaaaibcaabaaaacaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaa
bbaaaaaiccaabaaaacaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaa
bbaaaaaiecaabaaaacaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaa
aaaaaaahhccabaaaafaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaadoaaaaab
ejfdeheopaaaaaaaaiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaanbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
njaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaaoaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapadaaaaoaaaaaaaabaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaaoaaaaaaaacaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
oaaaaaaaadaaaaaaaaaaaaaaadaaaaaaagaaaaaaapaaaaaaojaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaahaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofe
aaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
keaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaa
keaaaaaaafaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaklklkl""
}
SubProgram ""gles3 "" {
// Stats: 11 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform mediump vec4 unity_SHAr;
uniform mediump vec4 unity_SHAg;
uniform mediump vec4 unity_SHAb;
uniform mediump vec4 unity_SHBr;
uniform mediump vec4 unity_SHBg;
uniform mediump vec4 unity_SHBb;
uniform mediump vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out mediump vec3 xlv_TEXCOORD1;
out highp vec3 xlv_TEXCOORD2;
out highp vec4 xlv_TEXCOORD4;
out mediump vec3 xlv_TEXCOORD5;
void main ()
{
  lowp vec3 worldNormal_1;
  mediump vec3 tmpvar_2;
  highp vec4 tmpvar_3;
  highp vec4 v_4;
  v_4.x = _World2Object[0].x;
  v_4.y = _World2Object[1].x;
  v_4.z = _World2Object[2].x;
  v_4.w = _World2Object[3].x;
  highp vec4 v_5;
  v_5.x = _World2Object[0].y;
  v_5.y = _World2Object[1].y;
  v_5.z = _World2Object[2].y;
  v_5.w = _World2Object[3].y;
  highp vec4 v_6;
  v_6.x = _World2Object[0].z;
  v_6.y = _World2Object[1].z;
  v_6.z = _World2Object[2].z;
  v_6.w = _World2Object[3].z;
  highp vec3 tmpvar_7;
  tmpvar_7 = normalize(((
    (v_4.xyz * _glesNormal.x)
   + 
    (v_5.xyz * _glesNormal.y)
  ) + (v_6.xyz * _glesNormal.z)));
  worldNormal_1 = tmpvar_7;
  tmpvar_2 = worldNormal_1;
  tmpvar_3.zw = vec2(0.0, 0.0);
  tmpvar_3.xy = vec2(0.0, 0.0);
  lowp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = worldNormal_1;
  mediump vec4 normal_9;
  normal_9 = tmpvar_8;
  mediump vec3 x2_10;
  mediump vec3 x1_11;
  x1_11.x = dot (unity_SHAr, normal_9);
  x1_11.y = dot (unity_SHAg, normal_9);
  x1_11.z = dot (unity_SHAb, normal_9);
  mediump vec4 tmpvar_12;
  tmpvar_12 = (normal_9.xyzz * normal_9.yzzx);
  x2_10.x = dot (unity_SHBr, tmpvar_12);
  x2_10.y = dot (unity_SHBg, tmpvar_12);
  x2_10.z = dot (unity_SHBb, tmpvar_12);
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = (_Object2World * _glesVertex).xyz;
  xlv_TEXCOORD4 = tmpvar_3;
  xlv_TEXCOORD5 = ((x2_10 + (unity_SHC.xyz * 
    ((normal_9.x * normal_9.x) - (normal_9.y * normal_9.y))
  )) + x1_11);
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _XYSMap;
in highp vec2 xlv_TEXCOORD0;
in mediump vec3 xlv_TEXCOORD1;
void main ()
{
  mediump vec4 outDiffuse_1;
  lowp vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp vec4 tmpvar_3;
  tmpvar_3 = texture (_XYSMap, xlv_TEXCOORD0);
  lowp vec3 tmpvar_4;
  tmpvar_4.x = (tmpvar_3.y - tmpvar_3.z);
  tmpvar_4.y = (tmpvar_3.y - tmpvar_3.z);
  tmpvar_4.z = (tmpvar_3.y - tmpvar_3.z);
  mediump vec4 outDiffuseOcclusion_5;
  mediump vec4 outNormal_6;
  mediump vec4 emission_7;
  lowp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = vec3(0.0, 0.0, 0.0);
  outDiffuseOcclusion_5 = tmpvar_8;
  lowp vec4 tmpvar_9;
  tmpvar_9.w = 1.0;
  tmpvar_9.xyz = ((tmpvar_2 * 0.5) + 0.5);
  outNormal_6 = tmpvar_9;
  lowp vec4 tmpvar_10;
  tmpvar_10.w = 1.0;
  tmpvar_10.xyz = tmpvar_4;
  emission_7 = tmpvar_10;
  emission_7.xyz = emission_7.xyz;
  outDiffuse_1.xyz = outDiffuseOcclusion_5.xyz;
  outDiffuse_1.w = 1.0;
  _glesFragData[0] = outDiffuse_1;
  _glesFragData[1] = vec4(0.0, 0.0, 0.0, 0.0);
  _glesFragData[2] = outNormal_6;
  _glesFragData[3] = emission_7;
}



#endif""
}
SubProgram ""metal "" {
// Stats: 26 math
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
Bind ""vertex"" ATTR0
Bind ""normal"" ATTR1
Bind ""texcoord"" ATTR2
ConstBuffer ""$Globals"" 272
Matrix 64 [glstate_matrix_mvp]
Matrix 128 [_Object2World]
Matrix 192 [_World2Object]
VectorHalf 0 [unity_SHAr] 4
VectorHalf 8 [unity_SHAg] 4
VectorHalf 16 [unity_SHAb] 4
VectorHalf 24 [unity_SHBr] 4
VectorHalf 32 [unity_SHBg] 4
VectorHalf 40 [unity_SHBb] 4
VectorHalf 48 [unity_SHC] 4
Vector 256 [_MainTex_ST]
""metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
  float3 _glesNormal [[attribute(1)]];
  float4 _glesMultiTexCoord0 [[attribute(2)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
  float2 xlv_TEXCOORD0;
  half3 xlv_TEXCOORD1;
  float3 xlv_TEXCOORD2;
  float4 xlv_TEXCOORD4;
  half3 xlv_TEXCOORD5;
};
struct xlatMtlShaderUniform {
  half4 unity_SHAr;
  half4 unity_SHAg;
  half4 unity_SHAb;
  half4 unity_SHBr;
  half4 unity_SHBg;
  half4 unity_SHBb;
  half4 unity_SHC;
  float4x4 glstate_matrix_mvp;
  float4x4 _Object2World;
  float4x4 _World2Object;
  float4 _MainTex_ST;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half3 worldNormal_1;
  half3 tmpvar_2;
  float4 tmpvar_3;
  float4 v_4;
  v_4.x = _mtl_u._World2Object[0].x;
  v_4.y = _mtl_u._World2Object[1].x;
  v_4.z = _mtl_u._World2Object[2].x;
  v_4.w = _mtl_u._World2Object[3].x;
  float4 v_5;
  v_5.x = _mtl_u._World2Object[0].y;
  v_5.y = _mtl_u._World2Object[1].y;
  v_5.z = _mtl_u._World2Object[2].y;
  v_5.w = _mtl_u._World2Object[3].y;
  float4 v_6;
  v_6.x = _mtl_u._World2Object[0].z;
  v_6.y = _mtl_u._World2Object[1].z;
  v_6.z = _mtl_u._World2Object[2].z;
  v_6.w = _mtl_u._World2Object[3].z;
  float3 tmpvar_7;
  tmpvar_7 = normalize(((
    (v_4.xyz * _mtl_i._glesNormal.x)
   + 
    (v_5.xyz * _mtl_i._glesNormal.y)
  ) + (v_6.xyz * _mtl_i._glesNormal.z)));
  worldNormal_1 = half3(tmpvar_7);
  tmpvar_2 = worldNormal_1;
  tmpvar_3.zw = float2(0.0, 0.0);
  tmpvar_3.xy = float2(0.0, 0.0);
  half4 tmpvar_8;
  tmpvar_8.w = half(1.0);
  tmpvar_8.xyz = worldNormal_1;
  half4 normal_9;
  normal_9 = tmpvar_8;
  half3 x2_10;
  half3 x1_11;
  x1_11.x = dot (_mtl_u.unity_SHAr, normal_9);
  x1_11.y = dot (_mtl_u.unity_SHAg, normal_9);
  x1_11.z = dot (_mtl_u.unity_SHAb, normal_9);
  half4 tmpvar_12;
  tmpvar_12 = (normal_9.xyzz * normal_9.yzzx);
  x2_10.x = dot (_mtl_u.unity_SHBr, tmpvar_12);
  x2_10.y = dot (_mtl_u.unity_SHBg, tmpvar_12);
  x2_10.z = dot (_mtl_u.unity_SHBb, tmpvar_12);
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  _mtl_o.xlv_TEXCOORD0 = ((_mtl_i._glesMultiTexCoord0.xy * _mtl_u._MainTex_ST.xy) + _mtl_u._MainTex_ST.zw);
  _mtl_o.xlv_TEXCOORD1 = tmpvar_2;
  _mtl_o.xlv_TEXCOORD2 = (_mtl_u._Object2World * _mtl_i._glesVertex).xyz;
  _mtl_o.xlv_TEXCOORD4 = tmpvar_3;
  _mtl_o.xlv_TEXCOORD5 = ((x2_10 + (_mtl_u.unity_SHC.xyz * 
    ((normal_9.x * normal_9.x) - (normal_9.y * normal_9.y))
  )) + x1_11);
  return _mtl_o;
}

""
}
}
Program ""fp"" {
SubProgram ""opengl "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 10 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_2_0
def c0, 0, 0, 0, 1
def c1, 0.5, 0, 0, 0
dcl t0.xy
dcl_pp t1.xyz
dcl_2d s0
texld_pp r0, t0, s0
mov_pp oC0, c0
mov_pp r1, c0.x
mov_pp oC1, r1
mad_pp r1.xyz, t1, c1.x, c1.x
mov_pp r1.w, c0.w
mov_pp oC2, r1
add_pp r0.x, -r0.z, r0.y
exp_pp r0.xyz, -r0.x
mov_pp r0.w, c0.w
mov_pp oC3, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 3 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0
eefiecednmoagjgbjohekfmoboaefjeconbpepfkabaaaaaaoaacaaaaadaaaaaa
cmaaaaaaoeaaaaaagaabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaaafaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheoheaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaagiaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
apaaaaaagiaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaagiaaaaaa
adaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefchiabaaaaeaaaaaaafoaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadhcbabaaa
acaaaaaagfaaaaadpccabaaaaaaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
pccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagiaaaaacabaaaaaadgaaaaai
pccabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpdgaaaaai
pccabaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadcaaaaap
hccabaaaacaaaaaaegbcbaaaacaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadp
aaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaaficcabaaa
acaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaaibcaabaaaaaaaaaaackaabaia
ebaaaaaaaaaaaaaabkaabaaaaaaaaaaabjaaaaaghccabaaaadaaaaaaagaabaia
ebaaaaaaaaaaaaaadgaaaaaficcabaaaadaaaaaaabeaaaaaaaaaiadpdoaaaaab
""
}
SubProgram ""gles "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
// Stats: 3 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0_level_9_1
eefiecedncegoipdnbipmokidheeanadahidbaobabaaaaaaaeaeaaaaaeaaaaaa
daaaaaaafaabaaaanaacaaaaiiadaaaaebgpgodjbiabaaaabiabaaaaaaacpppp
paaaaaaaciaaaaaaaaaaciaaaaaaciaaaaaaciaaabaaceaaaaaaciaaaaaaaaaa
aaacppppfbaaaaafaaaaapkaaaaaaaaaaaaaaadpaaaaiadpaaaaaaaafbaaaaaf
abaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpbpaaaaacaaaaaaiaaaaaadla
bpaaaaacaaaaaaiaabaachlabpaaaaacaaaaaajaaaaiapkaecaaaaadaaaacpia
aaaaoelaaaaioekaabaaaaacabaacpiaaaaaaakaabaaaaacabaicpiaabaaoeia
aeaaaaaeabaachiaabaaoelaaaaaffkaaaaaffkaabaaaaacabaaciiaaaaakkka
abaaaaacacaicpiaabaaoeiaacaaaaadaaaacbiaaaaakkibaaaaffiaaoaaaaac
aaaachiaaaaaaaibabaaaaacaaaaciiaaaaakkkaabaaaaacadaicpiaaaaaoeia
abaaaaacaaaicpiaabaaoekappppaaaafdeieefchiabaaaaeaaaaaaafoaaaaaa
fkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagfaaaaadpccabaaaaaaaaaaa
gfaaaaadpccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaa
adaaaaaagiaaaaacabaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaiadpdgaaaaaipccabaaaabaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaadcaaaaaphccabaaaacaaaaaaegbcbaaaacaaaaaa
aceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaaaceaaaaaaaaaaadpaaaaaadp
aaaaaadpaaaaaaaadgaaaaaficcabaaaacaaaaaaabeaaaaaaaaaiadpefaaaaaj
pcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
aaaaaaaibcaabaaaaaaaaaaackaabaiaebaaaaaaaaaaaaaabkaabaaaaaaaaaaa
bjaaaaaghccabaaaadaaaaaaagaabaiaebaaaaaaaaaaaaaadgaaaaaficcabaaa
adaaaaaaabeaaaaaaaaaiadpdoaaaaabejfdeheolaaaaaaaagaaaaaaaiaaaaaa
jiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaahahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaa
keaaaaaaaeaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaaafaaaaaa
aaaaaaaaadaaaaaaafaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklklepfdeheoheaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaagiaaaaaaabaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaagiaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaa
giaaaaaaadaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl""
}
SubProgram ""gles3 "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 13 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""HDR_LIGHT_PREPASS_OFF"" }
SetTexture 0 [_XYSMap] 2D 0
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float2 xlv_TEXCOORD0;
  half3 xlv_TEXCOORD1;
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
  half4 _glesFragData_1 [[color(1)]];
  half4 _glesFragData_2 [[color(2)]];
  half4 _glesFragData_3 [[color(3)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]]
  ,   texture2d<half> _XYSMap [[texture(0)]], sampler _mtlsmp__XYSMap [[sampler(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 outDiffuse_1;
  half4 outEmission_2;
  half3 tmpvar_3;
  tmpvar_3 = _mtl_i.xlv_TEXCOORD1;
  half4 tmpvar_4;
  tmpvar_4 = _XYSMap.sample(_mtlsmp__XYSMap, (float2)(_mtl_i.xlv_TEXCOORD0));
  half3 tmpvar_5;
  tmpvar_5.x = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.y = (tmpvar_4.y - tmpvar_4.z);
  tmpvar_5.z = (tmpvar_4.y - tmpvar_4.z);
  half4 outDiffuseOcclusion_6;
  half4 outNormal_7;
  half4 emission_8;
  half4 tmpvar_9;
  tmpvar_9.w = half(1.0);
  tmpvar_9.xyz = half3(float3(0.0, 0.0, 0.0));
  outDiffuseOcclusion_6 = tmpvar_9;
  half4 tmpvar_10;
  tmpvar_10.w = half(1.0);
  tmpvar_10.xyz = ((tmpvar_3 * (half)0.5) + (half)0.5);
  outNormal_7 = tmpvar_10;
  half4 tmpvar_11;
  tmpvar_11.w = half(1.0);
  tmpvar_11.xyz = tmpvar_5;
  emission_8 = tmpvar_11;
  emission_8.xyz = emission_8.xyz;
  outDiffuse_1.xyz = outDiffuseOcclusion_6.xyz;
  outEmission_2.w = emission_8.w;
  outDiffuse_1.w = half(1.0);
  outEmission_2.xyz = exp2(-(emission_8.xyz));
  _mtl_o._glesFragData_0 = outDiffuse_1;
  _mtl_o._glesFragData_1 = half4(float4(0.0, 0.0, 0.0, 0.0));
  _mtl_o._glesFragData_2 = outNormal_7;
  _mtl_o._glesFragData_3 = outEmission_2;
  return _mtl_o;
}

""
}
SubProgram ""opengl "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLSL""
}
SubProgram ""d3d9 "" {
// Stats: 9 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_2_0
def c0, 0, 0, 0, 1
def c1, 0.5, 0, 0, 0
dcl t0.xy
dcl_pp t1.xyz
dcl_2d s0
texld_pp r0, t0, s0
mov_pp oC0, c0
mov_pp r1, c0.x
mov_pp oC1, r1
mad_pp r1.xyz, t1, c1.x, c1.x
mov_pp r1.w, c0.w
mov_pp oC2, r1
add_pp r0.xyz, -r0.z, r0.y
mov_pp r0.w, c0.w
mov_pp oC3, r0

""
}
SubProgram ""d3d11 "" {
// Stats: 2 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0
eefiecedinmnkindfjbgllkmlecdhlcdfmnfdaeeabaaaaaamiacaaaaadaaaaaa
cmaaaaaaoeaaaaaagaabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaaafaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheoheaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaagiaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
apaaaaaagiaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaagiaaaaaa
adaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefcgaabaaaaeaaaaaaafiaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadhcbabaaa
acaaaaaagfaaaaadpccabaaaaaaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
pccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagiaaaaacabaaaaaadgaaaaai
pccabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpdgaaaaai
pccabaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadcaaaaap
hccabaaaacaaaaaaegbcbaaaacaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadp
aaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaaficcabaaa
acaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaaihccabaaaadaaaaaakgakbaia
ebaaaaaaaaaaaaaafgafbaaaaaaaaaaadgaaaaaficcabaaaadaaaaaaabeaaaaa
aaaaiadpdoaaaaab""
}
SubProgram ""gles "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLES""
}
SubProgram ""d3d11_9x "" {
// Stats: 2 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
SetTexture 0 [_XYSMap] 2D 0
""ps_4_0_level_9_1
eefiecedemimnnepoocfpbaakbiekjohhgojioidabaaaaaaoaadaaaaaeaaaaaa
daaaaaaaeeabaaaakmacaaaageadaaaaebgpgodjamabaaaaamabaaaaaaacpppp
oeaaaaaaciaaaaaaaaaaciaaaaaaciaaaaaaciaaabaaceaaaaaaciaaaaaaaaaa
aaacppppfbaaaaafaaaaapkaaaaaaaaaaaaaaadpaaaaiadpaaaaaaaafbaaaaaf
abaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpbpaaaaacaaaaaaiaaaaaadla
bpaaaaacaaaaaaiaabaachlabpaaaaacaaaaaajaaaaiapkaecaaaaadaaaacpia
aaaaoelaaaaioekaabaaaaacabaacpiaaaaaaakaabaaaaacabaicpiaabaaoeia
aeaaaaaeabaachiaabaaoelaaaaaffkaaaaaffkaabaaaaacabaaciiaaaaakkka
abaaaaacacaicpiaabaaoeiaacaaaaadaaaachiaaaaakkibaaaaffiaabaaaaac
aaaaciiaaaaakkkaabaaaaacadaicpiaaaaaoeiaabaaaaacaaaicpiaabaaoeka
ppppaaaafdeieefcgaabaaaaeaaaaaaafiaaaaaafkaaaaadaagabaaaaaaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaad
hcbabaaaacaaaaaagfaaaaadpccabaaaaaaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagiaaaaacabaaaaaa
dgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadp
dgaaaaaipccabaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
dcaaaaaphccabaaaacaaaaaaegbcbaaaacaaaaaaaceaaaaaaaaaaadpaaaaaadp
aaaaaadpaaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaaf
iccabaaaacaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaaaaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaaihccabaaaadaaaaaa
kgakbaiaebaaaaaaaaaaaaaafgafbaaaaaaaaaaadgaaaaaficcabaaaadaaaaaa
abeaaaaaaaaaiadpdoaaaaabejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaaafaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheoheaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaagiaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
apaaaaaagiaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaagiaaaaaa
adaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
""
}
SubProgram ""gles3 "" {
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
""!!GLES3""
}
SubProgram ""metal "" {
// Stats: 11 math, 1 textures
Keywords { ""LIGHTMAP_OFF"" ""DIRLIGHTMAP_OFF"" ""DYNAMICLIGHTMAP_OFF"" ""UNITY_HDR_ON"" }
SetTexture 0 [_XYSMap] 2D 0
""metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float2 xlv_TEXCOORD0;
  half3 xlv_TEXCOORD1;
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
  half4 _glesFragData_1 [[color(1)]];
  half4 _glesFragData_2 [[color(2)]];
  half4 _glesFragData_3 [[color(3)]];
};
struct xlatMtlShaderUniform {
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]]
  ,   texture2d<half> _XYSMap [[texture(0)]], sampler _mtlsmp__XYSMap [[sampler(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 outDiffuse_1;
  half3 tmpvar_2;
  tmpvar_2 = _mtl_i.xlv_TEXCOORD1;
  half4 tmpvar_3;
  tmpvar_3 = _XYSMap.sample(_mtlsmp__XYSMap, (float2)(_mtl_i.xlv_TEXCOORD0));
  half3 tmpvar_4;
  tmpvar_4.x = (tmpvar_3.y - tmpvar_3.z);
  tmpvar_4.y = (tmpvar_3.y - tmpvar_3.z);
  tmpvar_4.z = (tmpvar_3.y - tmpvar_3.z);
  half4 outDiffuseOcclusion_5;
  half4 outNormal_6;
  half4 emission_7;
  half4 tmpvar_8;
  tmpvar_8.w = half(1.0);
  tmpvar_8.xyz = half3(float3(0.0, 0.0, 0.0));
  outDiffuseOcclusion_5 = tmpvar_8;
  half4 tmpvar_9;
  tmpvar_9.w = half(1.0);
  tmpvar_9.xyz = ((tmpvar_2 * (half)0.5) + (half)0.5);
  outNormal_6 = tmpvar_9;
  half4 tmpvar_10;
  tmpvar_10.w = half(1.0);
  tmpvar_10.xyz = tmpvar_4;
  emission_7 = tmpvar_10;
  emission_7.xyz = emission_7.xyz;
  outDiffuse_1.xyz = outDiffuseOcclusion_5.xyz;
  outDiffuse_1.w = half(1.0);
  _mtl_o._glesFragData_0 = outDiffuse_1;
  _mtl_o._glesFragData_1 = half4(float4(0.0, 0.0, 0.0, 0.0));
  _mtl_o._glesFragData_2 = outNormal_6;
  _mtl_o._glesFragData_3 = emission_7;
  return _mtl_o;
}

""
}
}
 }
}
Fallback ""Legacy Shaders/VertexLit""
}";

    }
}
