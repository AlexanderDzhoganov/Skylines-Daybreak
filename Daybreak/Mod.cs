using System;
using System.IO;
using ColossalFramework.UI;
using ICities;
using UnityEngine;

namespace Daybreak
{

    public class Mod : IUserMod
    {

        public string Name
        {
            get { return "Daybreak"; }
        }

        public string Description
        {
            get { return "Adds a day/ night cycle to the game"; }
        }

    }
    public class ModLoad : LoadingExtensionBase
    {

        public override void OnLevelLoaded(LoadMode mode)
        {

            GameObject go = new GameObject();
            go.AddComponent<SunManager>();
            go.AddComponent<RenderingController>();
            go.AddComponent<Timer>();
            go.AddComponent<DebugMenu>();
            go.AddComponent<HeadlightsController>();

            var controller = GameObject.FindObjectOfType<CameraController>();
            GameObject.Destroy(controller.gameObject.GetComponent<FogEffect>());
        }

    }

}
