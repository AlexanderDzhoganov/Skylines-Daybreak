using System;
using ColossalFramework;
using UnityEngine;

namespace Daybreak
{
    public class StreetLightEffectInfo : EffectInfo
    {

        private Mesh sphereMesh;

        public StreetLightEffectInfo()
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphereMesh = go.GetComponent<MeshFilter>().mesh;
        }

        private int idRef = 0;


        public override void RenderEffect(InstanceID id, EffectInfo.SpawnArea area, Vector3 velocity, float acceleration, float magnitude, float timeDelta, RenderManager.CameraInfo cameraInfo)
        {
            var pos = area.m_matrix.MultiplyPoint(Vector3.zero);
            if ((pos - Camera.main.transform.position).sqrMagnitude > 1000.0f)
            {
                return;
            }

            var dir = area.m_matrix.MultiplyVector(Vector3.forward);

          //  Log.Warning(dir.ToString());

            pos += Vector3.up * 8.0f;
            pos += dir*5.0f;

            LightData data = new LightData(id, pos, new Color(1.0f, 0.827f, 0.471f), 0.3f, 32.0f, 10.0f);

            data.m_type = LightType.Spot;
            data.m_spotAngle = 60.0f;
            data.m_rotation = Quaternion.Euler(90, 0, 0);

            Singleton<RenderManager>.instance.DrawLight(data);
        }

        public override void PlayEffect(InstanceID id, EffectInfo.SpawnArea area, Vector3 velocity, float acceleration, float magnitude, AudioManager.ListenerInfo listenerInfo, AudioGroup audioGroup)
        {
        }

        protected override void CreateEffect()
        {
        }

        protected override void DestroyEffect()
        {
        }

        public override bool RequireRender()
        {
            return true;
        }

        public override bool RequirePlay()
        {
            return false;
        }

    }
}
