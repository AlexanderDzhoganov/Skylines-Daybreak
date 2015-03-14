using UnityEngine;

namespace Daybreak
{
    public class BuildingGlowRenderer : MonoBehaviour
    {
        private Camera glowCamera;

        void Awake()
        {
            var go = new GameObject();
            glowCamera = go.AddComponent<Camera>();
        }

        void RenderBuildings()
        {
            
        }

        void Update()
        {
            
        }

    }

}
