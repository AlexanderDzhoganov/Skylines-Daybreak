using System.IO;
using ColossalFramework;
using UnityEngine;

namespace Daybreak
{
    public class DebugMenu : MonoBehaviour
    {

        private Rect windowRect = new Rect(128, 128, 360, 600);
        private bool show = true;
        private Vector2 scrollViewPos = Vector2.zero;

        private Timer timer;
        private HeadlightsController headlights;
        void Awake()
        {
            timer = GetComponent<Timer>();
        }

        void OnGUI()
        {
            if (show)
            {
                windowRect = GUI.Window(152512, windowRect, DrawDebugWindow, "Daybreak debug menu");
            }

            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.L))
            {
                show = !show;
            }
        }

        void DrawDebugWindow(int wnd)
        {
            if (headlights == null)
            {
                headlights = GetComponent<HeadlightsController>();
            }

            if (headlights == null)
            {
                return;
            }

            scrollViewPos = GUILayout.BeginScrollView(scrollViewPos);

           /* GUILayout.Label("Lights");

            var lights = FindObjectsOfType<Light>();
            foreach (var light in lights)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(light.gameObject.name);
                light.enabled = GUILayout.Toggle(light.enabled, "");
                light.intensity = GUILayout.HorizontalSlider(light.intensity, 0.0f, 2.0f, GUILayout.Width(120));
                GUILayout.EndHorizontal();
                GUILayout.Label(light.transform.position.ToString());

                GUILayout.Space(4);
            }
            */
            GUILayout.BeginHorizontal();
            GUILayout.Label("Range: ");
            headlights.debugRange = GUILayout.HorizontalSlider(headlights.debugRange, 0.0f, 16.0f, GUILayout.Width(120));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Spot angle: ");
            headlights.debugSpotAngle = GUILayout.HorizontalSlider(headlights.debugSpotAngle, 0.0f, 180.0f, GUILayout.Width(120));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Intensity: ");
            headlights.debugIntensity = GUILayout.HorizontalSlider(headlights.debugIntensity, 0.0f, 16.0f, GUILayout.Width(120));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Displacement: ");
            headlights.debugDisplacement = GUILayout.HorizontalSlider(headlights.debugDisplacement, -8.0f, 8.0f, GUILayout.Width(120));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Side offset: ");
            headlights.debugSideOffset = GUILayout.HorizontalSlider(headlights.debugSideOffset, 0.0f, 2.0f, GUILayout.Width(120));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Use point lights: ");
            headlights.debugPoint = GUILayout.Toggle(headlights.debugPoint, "");
            GUILayout.EndHorizontal();

            VehicleManager vManager = Singleton<VehicleManager>.instance;
            GUILayout.Label("Vehicle count: " + vManager.m_vehicleCount);

            var propManager = Singleton<PropManager>.instance;
            GUILayout.Label("Prop count: " + propManager.m_propCount);

            GUILayout.Space(4);

            GUILayout.BeginHorizontal();
            GUILayout.Label("Ambient");
            RenderSettings.ambientIntensity = GUILayout.HorizontalSlider(RenderSettings.ambientIntensity, 0.0f, 2.0f, GUILayout.Width(120));
            GUILayout.EndHorizontal();

            GUILayout.Label("Ambient color: " + RenderSettings.ambientLight.ToString());

            GUILayout.Label("Time of day: " + timer.TimeOfDay);
            GUILayout.Label("T: " + timer.T);

            if (GUILayout.Button("export props"))
            {
                
                string t = "";
                for (int i = 0; i < propManager.m_propCount; i++)
                {
                    var mesh = propManager.m_props.m_buffer[i].Info.m_mesh;
                    if (mesh != null)
                    {
                        t += "prop - " + mesh.name + '\n';
                    }
                }

                File.WriteAllText("C:\\Users\\nlight\\Desktop\\props.txt", t);
            }

            GUILayout.EndScrollView();
        }

    }
}
