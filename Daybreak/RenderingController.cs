using UnityEngine;

namespace Daybreak
{
    public class RenderingController : MonoBehaviour
    {

        private CameraHook hook;

        void Awake()
        {
            var controller = FindObjectOfType<CameraController>();
            hook = controller.gameObject.AddComponent<CameraHook>();
            controller.gameObject.AddComponent<BuildingGlowRenderer>();
        }

    }
}
