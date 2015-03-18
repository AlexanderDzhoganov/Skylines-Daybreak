using System.IO;
using ColossalFramework;
using UnityEngine;

namespace Daybreak
{

    public class StreetlightController : MonoBehaviour
    {

        public int count;
        public Matrix4x4[] trs;

        public Texture2D lampTexture;
        public Material lampMaterial;
        public Vector3 lampSpriteScale = Vector3.one;

        private Mesh quadMesh;
        private int roadLayer;

        void Awake()
        {
            trs = new Matrix4x4[65535];

            var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            quadMesh = go.GetComponent<MeshFilter>().mesh;

            lampTexture = new Texture2D(512, 512);
            lampTexture.LoadImage(File.ReadAllBytes("C:\\Users\\nlight\\Desktop\\lamp_sprite.png"));

            lampMaterial = new Material(Shader.Find("Diffuse"));
            lampMaterial.mainTexture = lampTexture;

            roadLayer = LayerMask.NameToLayer("Road");
        }

        void LateUpdate()
        {
            FetchStreetlights();
        }

        private int logLimit = 50;

        private void FetchStreetlights()
        {
            count = 0;

            var netManager = Singleton<NetManager>.instance;

            for (int i = 0; i < netManager.m_lanes.m_buffer.Length; i++)
            {
                var flags = netManager.m_lanes.m_buffer[i].m_flags;

                if ((netManager.m_lanes.m_buffer[i].m_flags & ((ushort)NetLane.Flags.Created | (ushort)NetLane.Flags.Deleted)) != (ushort)NetLane.Flags.Created)
                {
                    continue;
                }

                var lane = netManager.m_lanes.m_buffer[i];

              //  var segment = netManager.m_segments.m_buffer[lane.m_segment];
              //  segment.

                /*
                NetSegment segment = netManager.m_segments.m_buffer[i];
                if (segment.Info == null)
                {
                    continue;
                }

                if (segment.Info.m_lanes == null)
                {
                    continue;
                }
                */

            }
        }

    }

}

