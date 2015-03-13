using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Daybreak
{
    public class DebugMenu : MonoBehaviour
    {

        private Rect windowRect = new Rect(128, 128, 256, 400);
        private bool show = true;


        private Timer timer;
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
            GUILayout.Label("Lights");

            var lights = FindObjectsOfType<Light>();
            foreach (var light in lights)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(light.gameObject.name);
                light.enabled = GUILayout.Toggle(light.enabled, "");
                light.intensity = GUILayout.HorizontalSlider(light.intensity, 0.0f, 2.0f, GUILayout.Width(120));
                GUILayout.EndHorizontal();

                GUILayout.Space(4);
            }

            GUILayout.Space(4);

            GUILayout.BeginHorizontal();
            GUILayout.Label("Ambient");
            RenderSettings.ambientIntensity = GUILayout.HorizontalSlider(RenderSettings.ambientIntensity, 0.0f, 2.0f, GUILayout.Width(120));
            GUILayout.EndHorizontal();

            GUILayout.Label("Ambient color: " + RenderSettings.ambientLight.ToString());


            GUILayout.Label("Time of day: " + timer.TimeOfDay);
            GUILayout.Label("T: " + timer.T);


        }

    }
}
