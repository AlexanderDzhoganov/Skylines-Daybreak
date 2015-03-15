using ColossalFramework;
using UnityEngine;

namespace Daybreak
{
    public class SkyboxManager : MonoBehaviour
    {

        private FogEffect fogEffect;
        private RenderProperties renderProperties;

        void Awake()
        {
            fogEffect = FindObjectOfType<FogEffect>();
            renderProperties = FindObjectOfType<RenderProperties>();
        }

        void Update()
        {
            renderProperties.m_cubemap = null;


            //     RenderSettings.skybox = null;
            //    Singleton<RenderManager>.instance.m_properties.m_fogColor = Color.black;
        }

    }

}
