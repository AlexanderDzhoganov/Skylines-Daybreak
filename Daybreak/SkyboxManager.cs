using System.IO;
using ColossalFramework;
using UnityEngine;

namespace Daybreak
{
    public class SkyboxManager : MonoBehaviour
    {

        private FogEffect fogEffect;
        private RenderProperties renderProperties;

        private Cubemap cubemap;

        void Awake()
        {
            fogEffect = FindObjectOfType<FogEffect>();
            renderProperties = FindObjectOfType<RenderProperties>();

            var tmp = new Texture2D(4096, 4096);
            tmp.LoadImage(File.ReadAllBytes("C:\\Users\\nlight\\Desktop\\sky.png"));
            var pixels = tmp.GetPixels();

            cubemap = new Cubemap(4096, TextureFormat.RGBA32, false);
            cubemap.SetPixels(pixels, CubemapFace.NegativeX);
            cubemap.SetPixels(pixels, CubemapFace.NegativeY);
            cubemap.SetPixels(pixels, CubemapFace.NegativeZ);
            cubemap.SetPixels(pixels, CubemapFace.PositiveX);
            cubemap.SetPixels(pixels, CubemapFace.PositiveY);
            cubemap.SetPixels(pixels, CubemapFace.PositiveZ);
            cubemap.Apply();
        }

        void Update()
        {
            renderProperties.m_cubemap = cubemap;
            Shader.SetGlobalTexture("_EnvironmentCubemap", cubemap);
        }

    }

}
