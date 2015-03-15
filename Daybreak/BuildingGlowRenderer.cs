using System;
using ColossalFramework;
using UnityEngine;

namespace Daybreak
{
    public class BuildingGlowRenderer : MonoBehaviour
    {
        private Camera mainCamera;

        private RenderManager renderManager;
        private BuildingManager buildingManager;

        private Shader buildingWindowsReplacement;
        private Material buildingsGlowPP;
        private Material glowBlurPP;

        private RenderTexture rt;
        private RenderTexture rtBlurH, rtBlurV;

        private int blurDownscale = 2;

        void Awake()
        {
            renderManager = Singleton<RenderManager>.instance;
            buildingManager = Singleton<BuildingManager>.instance;

            var cameraController = FindObjectOfType<CameraController>();
            mainCamera = cameraController.GetComponent<Camera>();

            var mat = new Material(Shaders.buildingsWindowReplacement);
            buildingWindowsReplacement = mat.shader;

            buildingsGlowPP = new Material(Shaders.buildingsGlowPP);
            glowBlurPP = new Material(Shaders.glowBlurPP);

            int w = Camera.main.pixelWidth/blurDownscale;
            int h = Camera.main.pixelHeight/blurDownscale;

            rt = new RenderTexture(w, h, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
            rtBlurH = new RenderTexture(w, h, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
            rtBlurV = new RenderTexture(w, h, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
        }


        void OnRenderImage(RenderTexture src, RenderTexture dst)
        {
            RenderWindowGlowTexture(rt);

            glowBlurPP.SetVector("_BlurDir", new Vector4(1.0f, 0.0f, 0.0f, 0.0f));
            Graphics.Blit(rt, rtBlurH, glowBlurPP);

            glowBlurPP.SetVector("_BlurDir", new Vector4(0.0f, 1.0f, 0.0f, 0.0f));
            Graphics.Blit(rtBlurH, rtBlurV, glowBlurPP);

            buildingsGlowPP.SetTexture("_GlowTex", rtBlurV);
            Graphics.Blit(src, dst, buildingsGlowPP);
        }

        public void RenderWindowGlowTexture(RenderTexture target)
        {
            RenderBuildingWindowsToTexture(target);
        }

        public void RenderBuildingWindowsToTexture(RenderTexture target)
        {
            RenderBuildingsToTexture(target, buildingWindowsReplacement);
        }

        public void RenderBuildingsToTexture(RenderTexture target, Shader replacement)
        {
            InitializeRendering();

            var cameraInfo = renderManager.CurrentCameraInfo;

            buildingManager.BeginRendering(cameraInfo);
            PrepareRenderGroups(cameraInfo);
            buildingManager.EndRendering(cameraInfo);
            
            var go = new GameObject();
            var dummyCamera = go.AddComponent<Camera>();
            dummyCamera.CopyFrom(mainCamera);
            dummyCamera.backgroundColor = Color.black;

            dummyCamera.targetTexture = target;
            dummyCamera.cullingMask = 0;
            dummyCamera.cullingMask |= 1 << LayerMask.NameToLayer("Buildings");
            dummyCamera.RenderWithShader(replacement, "");

            Destroy(dummyCamera);
            Destroy(go);
        }

        private void InitializeRendering()
        {
            renderManager.m_outOfInstances = false;
            PrefabPool.m_canCreateInstances = 1;
            renderManager.UpdateCameraInfo();
            UpdateColorMap();
        }

        private void UpdateColorMap()
        {
            bool flag = false;
            if (Singleton<BuildingManager>.instance.UpdateColorMap(renderManager.m_objectColorMap))
            {
                flag = true;
            }
            if (Singleton<NetManager>.instance.UpdateColorMap(renderManager.m_objectColorMap))
            {
                flag = true;
            }
            if (flag)
            {
                renderManager.m_objectColorMap.Apply(false);
            }
        }

        void PrepareRenderGroups(RenderManager.CameraInfo cameraInfo)
        {
            try
            {
                Vector3 min = cameraInfo.m_bounds.min;
                Vector3 max = cameraInfo.m_bounds.max;
                int num = Mathf.Max((int)((min.x - 128f) / 384f + 22.5f), 0);
                int num2 = Mathf.Max((int)((min.z - 128f) / 384f + 22.5f), 0);
                int num3 = Mathf.Min((int)((max.x + 128f) / 384f + 22.5f), 44);
                int num4 = Mathf.Min((int)((max.z + 128f) / 384f + 22.5f), 44);
                int num5 = 5;
                int num6 = 10000;
                int num7 = 10000;
                int num8 = -10000;
                int num9 = -10000;
                renderManager.m_renderedGroups.Clear();

                for (int j = num2; j <= num4; j++)
                {
                    for (int k = num; k <= num3; k++)
                    {
                        int num10 = j * 45 + k;
                        RenderGroup renderGroup = renderManager.m_groups[num10];
                        if (renderGroup != null && renderGroup.Render(cameraInfo))
                        {
                            renderManager.m_renderedGroups.Add(renderGroup);
                            int num11 = k / num5;
                            int num12 = j / num5;
                            int num13 = num12 * 9 + num11;
                            MegaRenderGroup megaRenderGroup = renderManager.m_megaGroups[num13];
                            if (megaRenderGroup != null)
                            {
                                megaRenderGroup.m_layersRendered2 |= (megaRenderGroup.m_layersRendered1 &
                                                                      renderGroup.m_layersRendered);
                                megaRenderGroup.m_layersRendered1 |= renderGroup.m_layersRendered;
                                megaRenderGroup.m_instanceMask |= renderGroup.m_instanceMask;
                                num6 = Mathf.Min(num6, num11);
                                num7 = Mathf.Min(num7, num12);
                                num8 = Mathf.Max(num8, num11);
                                num9 = Mathf.Max(num9, num12);
                            }
                        }
                    }
                }
                for (int l = num7; l <= num9; l++)
                {
                    for (int m = num6; m <= num8; m++)
                    {
                        int num14 = l * 9 + m;
                        MegaRenderGroup megaRenderGroup2 = renderManager.m_megaGroups[num14];
                        if (megaRenderGroup2 != null)
                        {
                            megaRenderGroup2.Render();
                        }
                    }
                }
                for (int n = 0; n < renderManager.m_renderedGroups.m_size; n++)
                {
                    RenderGroup renderGroup2 = renderManager.m_renderedGroups.m_buffer[n];
                    int num15 = renderGroup2.m_x / num5;
                    int num16 = renderGroup2.m_z / num5;
                    int num17 = num16 * 9 + num15;
                    MegaRenderGroup megaRenderGroup3 = renderManager.m_megaGroups[num17];
                    if (megaRenderGroup3 != null && megaRenderGroup3.m_groupMask != 0)
                    {
                        renderGroup2.Render(megaRenderGroup3.m_groupMask);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Exception in EPPF.PrepareForRendering() - " + ex.Message);
            }
        }
    }

}
