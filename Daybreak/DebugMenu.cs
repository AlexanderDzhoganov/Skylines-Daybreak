using System;
using System.IO;
using ColossalFramework;
using UnityEngine;

namespace Daybreak
{
    public class DebugMenu : MonoBehaviour
    {

        private Rect windowRect = new Rect(128, 128, 360, 600);
        private bool showUI = true;
        private Vector2 scrollViewPos = Vector2.zero;

        private Timer timer;
        private HeadlightsController headlights;
        private FogEffect fogEffect;

        void Awake()
        {
            timer = GetComponent<Timer>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F6))
            {
                showUI = !showUI;
            }
        }

        void OnGUI()
        {
            

            if (showUI)
            {
                windowRect = GUI.Window(1626212, windowRect, DrawDebugWindow, "Daybreak debug menu");
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

            if (fogEffect == null)
            {
                fogEffect = FindObjectOfType<FogEffect>();
            }

            if (fogEffect == null)
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

            /*
  public Color m_3DFogColor = Color.white;
  public float m_3DNoiseScale = 0.01f;
  public Color m_PollutionColor = Color.white;
  public float m_PollutionIntensityWater = 2f;
  public float m_PollutionIntensity = 1f;
  public float m_FogPatternChangeSpeed = 0.5f;
  public Color m_InscatteringColor = Color.white;
  public float m_InscateringExponent = 15f;
  public float m_InscatteringIntensity = 2f;
  public float m_InscatteringStartDistance = 400f;
  public float m_InscatteringTransitionSoftness = 1f;
  private float m_LastSimTime = -1f;
  public Shader m_fogShader;
  [Range(0.0f, 3800f)]
  public float m_edgeFogDistance;
  public Texture3D m_3DNoiseTexture;
  public float m_NoiseContrast;
  public float m_3DFogStart;
  public float m_WindSpeed;*/
            /*
            GUILayout.BeginHorizontal();
            GUILayout.Label("Edge Fog");
            fogEffect.m_edgeFog = GUILayout.Toggle(fogEffect.m_edgeFog, "");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Use volume fog");
            fogEffect.m_UseVolumeFog = GUILayout.Toggle(fogEffect.m_UseVolumeFog, "");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Fog height");
            fogEffect.m_FogHeight = GUILayout.HorizontalSlider(fogEffect.m_FogHeight, 0.0f, 10000.0f);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Noise gain");
            fogEffect.m_NoiseGain = GUILayout.HorizontalSlider(fogEffect.m_NoiseGain, 0.0f, 2.0f);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("3D fog amount");
            fogEffect.m_3DFogAmount = GUILayout.HorizontalSlider(fogEffect.m_3DFogAmount, 0.0f, 2.0f);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("3D fog distance");
            fogEffect.m_3DFogDistance = GUILayout.HorizontalSlider(fogEffect.m_3DFogDistance, 0.0f, 20.0f);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("3D noise step size");
            fogEffect.m_3DNoiseStepSize = GUILayout.HorizontalSlider(fogEffect.m_3DNoiseStepSize, 0.0f, 8.0f);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Pollution intensity");
            fogEffect.m_PollutionIntensity = GUILayout.HorizontalSlider(fogEffect.m_PollutionIntensity, 0.0f, 2.0f);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Inscattering exponent");
            fogEffect.m_InscateringExponent = GUILayout.HorizontalSlider(fogEffect.m_InscateringExponent, 0.0f, 30.0f);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Inscattering intensity");
            fogEffect.m_InscatteringIntensity = GUILayout.HorizontalSlider(fogEffect.m_InscatteringIntensity, 0.0f, 4.0f);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Inscattering start distance");
            fogEffect.m_InscatteringStartDistance = GUILayout.HorizontalSlider(fogEffect.m_InscatteringStartDistance, 0.0f, 800.0f);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Inscattering start distance");
            fogEffect.m_InscatteringTransitionSoftness = GUILayout.HorizontalSlider(fogEffect.m_InscatteringTransitionSoftness, 0.0f, 2.0f);
            GUILayout.EndHorizontal();
            */

            if (fogEffect.m_Sun != null)
            {
                var pos = fogEffect.m_Sun.position;
                pos.x = FloatField("x", pos.x);
                pos.y = FloatField("y", pos.y);
                pos.z = FloatField("z", pos.z);
                fogEffect.m_Sun.position = pos;
            }
            else
            {
                var go = new GameObject();
                fogEffect.m_Sun = go.transform;
            }

            ///////
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
            GUILayout.Label("Vehicle count (ItemCount): " + vManager.m_vehicles.ItemCount());
            GUILayout.Label("Vehicle count: " + vManager.m_vehicleCount);
            GUILayout.Label("Active headlights: " + headlights.activeHeadlights.Count);

            var propManager = FindObjectOfType<PropManager>();
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

            GUILayout.BeginHorizontal();
            foreach (TimeOfDay timeOfDay in Enum.GetValues(typeof (TimeOfDay)))
            {
                if (GUILayout.Button(timeOfDay.ToString()))
                {
                    timer.ForceTimeOfDay(timeOfDay);
                }
            }

            if (GUILayout.Button("Reset"))
            {
                timer.StopEnforcingTimeOfDay();
            }

            GUILayout.EndHorizontal();

            if (GUILayout.Button("Turn off all lights"))
            {
                var lights = FindObjectsOfType<Light>();
                foreach (var light in lights)
                {
                    light.enabled = false;
                }
            }

            if (GUILayout.Button("Dump shaders"))
            {
                string s = "";

                var materials = Resources.FindObjectsOfTypeAll<Material>();
                foreach (var material in materials)
                {
                    s += material.name + " - " + material.shader.name + " - " + material.color.ToString() + '\n';
                }

                File.WriteAllText("C:\\Users\\nlight\\Desktop\\shaders.txt", s);
            }

            if (GUILayout.Button("Fuck the system"))
            {
                Shader.SetGlobalTexture("_EnvironmentCubemap", null);
                Shader.SetGlobalColor("_EnvironmentFogColor", Color.black);

                //var materials = Resources.FindObjectsOfTypeAll<Material>();
                //foreach (var material in materials)
                //{
                  //  material.SetTexture("_EnvironmentCubemap", null);
                  //  material.SetColor("_EnvironmentFogColor", Color.black);
              //  }
            }

            GUILayout.EndScrollView();
        }

        float FloatField(string label, float x)
        {
            float res = x;
            GUILayout.BeginHorizontal();
            GUILayout.Label(label + ": ");
            string s = GUILayout.TextField(x.ToString("0.00"), GUILayout.Width(256));
            float y;
            if (float.TryParse(s, out y))
            {
                res = y;
            }

            GUILayout.EndHorizontal();

            return res;
        }

    }
}
