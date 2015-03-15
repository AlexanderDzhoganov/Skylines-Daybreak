using ColossalFramework;
using UnityEngine;

namespace Daybreak
{
    public class RenderingController : MonoBehaviour
    {

        void Awake()
        {
            var controller = FindObjectOfType<CameraController>();
            controller.gameObject.AddComponent<BuildingGlowRenderer>();
            controller.gameObject.AddComponent<SkyboxManager>();

        }

        void Update()
        {

        }

    }
}
