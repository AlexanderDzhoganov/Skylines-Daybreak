using ColossalFramework;
using UnityEngine;

namespace Daybreak
{

    public class StreetlightController : MonoBehaviour
    {

        public int count;
        public Vector3[] positions;
        public float[] angles;

        void Awake()
        {
            positions = new Vector3[65535];
            angles = new float[65535];
        }

        void Update()
        {
            FetchStreetlights();
        }

        private void FetchStreetlights()
        {
            count = 0;

            var netManager = Singleton<NetManager>.instance;

            for (int i = 0; i < netManager.m_segments.m_buffer.Length; i++)
            {
                if ((netManager.m_segments.m_buffer[i].m_flags & (NetSegment.Flags.Created | NetSegment.Flags.Deleted)) != NetSegment.Flags.Created)
                {
                    continue;
                }

                NetSegment segment = netManager.m_segments.m_buffer[i];
                if (segment.Info == null)
                {
                    continue;
                }

                if (segment.Info.m_lanes == null)
                {
                    continue;
                }

                for (int q = 0; q < segment.Info.m_lanes.Length; q++)
                {
                    NetInfo.Lane lane = segment.Info.m_lanes[q];

                    var props = lane.m_laneProps;
                    if (lane.m_laneProps != null)
                    {
                        foreach (var prop in props.m_props)
                        {
                            if (prop.m_prop != null)
                            {
                                if (prop.m_prop.name == "New Street Light")
                                {
                                    positions[count] = prop.m_position;
                                    angles[count] = prop.m_angle;
                                    count++;
                                }
                            }
                        }
                    }
                }
            }
        }

    }

}

