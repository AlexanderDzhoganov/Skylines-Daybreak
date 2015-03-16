using System;
using System.IO;
using ColossalFramework;
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
            Singleton<SimulationManager>.instance.m_metaData.m_disableAchievements = SimulationMetaData.MetaBool.False;
            GameObject go = new GameObject();
            go.AddComponent<SunManager>();
            go.AddComponent<RenderingController>();
            go.AddComponent<Timer>();
            go.AddComponent<DebugMenu>();
            go.AddComponent<HeadlightsController>();
            go.AddComponent<StreetlightController>();

        }

    }

}
