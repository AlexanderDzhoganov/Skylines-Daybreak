using ColossalFramework;
using UnityEngine;

namespace Daybreak
{
    public class RenderingController : MonoBehaviour
    {

        void Awake()
        {
            var controller = FindObjectOfType<CameraController>();
            Destroy(controller.gameObject.GetComponent("Bloom"));
            Destroy(controller.gameObject.GetComponent<FilmGrainEffect>());

            controller.gameObject.AddComponent<BuildingGlowRenderer>();
            controller.gameObject.AddComponent<SkyboxManager>();
        }

        void Update()
        {

        }

    }
}
