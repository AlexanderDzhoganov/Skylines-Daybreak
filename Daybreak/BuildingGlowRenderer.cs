using System;
using ColossalFramework;
using UnityEngine;

namespace Daybreak
{
    public class BuildingGlowRenderer : MonoBehaviour
    {
        private Camera mainCamera;
        private Camera dummyCamera;
        private GameObject dummyGO;

        private RenderManager renderManager;
        private BuildingManager buildingManager;

        private Shader buildingWindowsReplacement;
        private Material buildingsGlowPP;
        private Material glowBlurPP;

        private RenderTexture rt;
        private RenderTexture rtBlurH, rtBlurV;

        public float glowIntensity = 1.5f;
        public Color glowColor = new Color(0.862f, 0.862f, 0.831f, 1.0f);
        public float blurFactor = 1.0f;

        private int blurDownscale = 2;

        void Awake()
        {
            renderManager = Singleton<RenderManager>.instance;
            buildingManager = Singleton<BuildingManager>.instance;

            var cameraController = FindObjectOfType<CameraController>();
            mainCamera = cameraController.GetComponent<Camera>();

            var mat = new Material(Shaders.buildingReplacementV2);
            buildingWindowsReplacement = mat.shader;

            buildingsGlowPP = new Material(Shaders.buildingsGlowPPv2);
            glowBlurPP = new Material(Shaders.glowBlurPP);

            int w = Camera.main.pixelWidth/blurDownscale;
            int h = Camera.main.pixelHeight/blurDownscale;

            rt = new RenderTexture(w, h, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
            rtBlurH = new RenderTexture(w, h, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
            rtBlurV = new RenderTexture(w, h, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);

            dummyGO = new GameObject();
            dummyCamera = dummyGO.AddComponent<Camera>();
            dummyCamera.enabled = false;
        }

        void LateUpdate()
        {
            RenderBuildingWindowsToTexture(rt);
        }

        void OnRenderImage(RenderTexture src, RenderTexture dst)
        {
            glowBlurPP.SetVector("_BlurDir", new Vector4(blurFactor, 0.0f, 0.0f, 0.0f));
            Graphics.Blit(rt, rtBlurH, glowBlurPP);

            glowBlurPP.SetVector("_BlurDir", new Vector4(0.0f, blurFactor, 0.0f, 0.0f));
            Graphics.Blit(rtBlurH, rtBlurV, glowBlurPP);

            buildingsGlowPP.SetTexture("_GlowTex", rtBlurV);
            buildingsGlowPP.SetFloat("_GlowIntensity", glowIntensity);
            buildingsGlowPP.SetColor("_GlowColor", glowColor);
            Graphics.Blit(src, dst, buildingsGlowPP);
        }

        public void RenderBuildingWindowsToTexture(RenderTexture target)
        {
            RenderBuildingsToTexture(target, buildingWindowsReplacement);
        }

        public void RenderBuildingsToTexture(RenderTexture target, Shader replacement)
        {
            renderManager.m_outOfInstances = false;
            PrefabPool.m_canCreateInstances = 1;
            renderManager.UpdateCameraInfo();
            UpdateColorMap();
            var cameraInfo = renderManager.CurrentCameraInfo;
            cameraInfo.m_camera = dummyCamera;

            BeginRenderingImpl(cameraInfo);
            PrepareRenderGroups(cameraInfo);
            EndRenderingImpl(cameraInfo);

            dummyCamera.CopyFrom(mainCamera);
            dummyCamera.backgroundColor = Color.black;

            dummyCamera.targetTexture = rt;
            dummyCamera.RenderWithShader(replacement, "");
            dummyCamera.targetTexture = null;
        }

        private void UpdateColorMap()
        {
            if (Singleton<BuildingManager>.instance.UpdateColorMap(renderManager.m_objectColorMap) ||
                Singleton<NetManager>.instance.UpdateColorMap(renderManager.m_objectColorMap))
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

        private void BuildingRenderInstance(Building building, RenderManager.CameraInfo cameraInfo, ushort buildingID, int layerMask)
        {
            if (building.m_flags == Building.Flags.None)
            {
                return;
            }
            BuildingInfo info = building.Info;
            if ((layerMask & 1 << info.m_prefabDataLayer) == 0)
            {
                return;
            }
            Vector3 position = building.m_position;
            float radius = info.m_renderSize + (float)building.m_baseHeight * 0.5f;
            position.y += (info.m_size.y - (float)building.m_baseHeight) * 0.5f;
            if (!cameraInfo.Intersect(position, radius))
            {
                return;
            }
            RenderManager instance = Singleton<RenderManager>.instance;
            uint num;
            if (instance.RequireInstance((uint)buildingID, 1u, out num))
            {
                BuildingRenderInstance(building, cameraInfo, buildingID, layerMask, info, ref instance.m_instances[(int)((UIntPtr)num)]);
            }
        }

        private void BuildingRenderInstance(Building building, RenderManager.CameraInfo cameraInfo, ushort buildingID, int layerMask, BuildingInfo info, ref RenderManager.Instance data)
        {
            if (data.m_dirty)
            {
                info.m_buildingAI.RefreshInstance(cameraInfo, buildingID, ref building, layerMask, ref data);
                data.m_dirty = false;
            }

            BuildingAIRenderInstance(info.m_buildingAI, cameraInfo, buildingID, ref building, layerMask, ref data);
        }

        private void BuildingAIRenderInstance(BuildingAI buildingAI, RenderManager.CameraInfo cameraInfo, ushort buildingID, ref Building data, int layerMask, ref RenderManager.Instance instance)
        {
            BuildingAIRenderMeshes(buildingAI, cameraInfo, buildingID, ref data, layerMask, ref instance);
            buildingAI.RenderProps(cameraInfo, buildingID, ref data, layerMask, ref instance);
        }

        // 
        private void BuildingAIRenderMeshes(BuildingAI buildingAI, RenderManager.CameraInfo cameraInfo, ushort buildingID, ref Building data, int layerMask, ref RenderManager.Instance instance)
        {
            if (buildingAI.m_info.m_mesh != null)
            {
                BuildingAIRenderMesh(cameraInfo, buildingID, ref data, buildingAI.m_info, ref instance);
            }
            if (buildingAI.m_info.m_subMeshes != null)
            {
                for (int i = 0; i < buildingAI.m_info.m_subMeshes.Length; i++)
                {
                    BuildingInfo.MeshInfo meshInfo = buildingAI.m_info.m_subMeshes[i];
                    if (((meshInfo.m_flagsRequired | meshInfo.m_flagsForbidden) & data.m_flags) == meshInfo.m_flagsRequired)
                    {
                        BuildingInfoBase subInfo = meshInfo.m_subInfo;
                        BuildingAIRenderMesh(cameraInfo, buildingAI.m_info, subInfo, meshInfo.m_matrix, ref instance);
                    }
                }
            }
        }

        private void BuildingAIRenderMesh(RenderManager.CameraInfo cameraInfo, ushort buildingID, ref Building data, BuildingInfo info, ref RenderManager.Instance instance)
        {
            if (info.m_overrideMainRenderer != null)
            {
                InstanceID empty = InstanceID.Empty;
                empty.Building = buildingID;
                BuildingInfo buildingInfo = info.ObtainPrefabInstance<BuildingInfo>(empty, 255);
                if (buildingInfo != null)
                {
                    buildingInfo.m_buildingAI.SetRenderParameters(cameraInfo, buildingID, ref data, instance.m_position, instance.m_rotation, instance.m_dataVector0, instance.m_dataVector3, instance.m_dataColor0);
                    return;
                }
            }
            
            BuildingManager instance2 = Singleton<BuildingManager>.instance;
            instance2.m_materialBlock.Clear();
            instance2.m_materialBlock.AddVector(instance2.ID_BuildingState, instance.m_dataVector0);
            instance2.m_materialBlock.AddVector(instance2.ID_ObjectIndex, instance.m_dataVector3);
            instance2.m_materialBlock.AddColor(instance2.ID_Color, instance.m_dataColor0);
            
            if (info.m_requireHeightMap)
            {
                instance2.m_materialBlock.AddTexture(instance2.ID_HeightMap, instance.m_dataTexture0);
                instance2.m_materialBlock.AddVector(instance2.ID_HeightMapping, instance.m_dataVector1);
                instance2.m_materialBlock.AddVector(instance2.ID_SurfaceMapping, instance.m_dataVector2);
            }
            BuildingManager expr_134_cp_0 = instance2;
            expr_134_cp_0.m_drawCallData.m_defaultCalls = expr_134_cp_0.m_drawCallData.m_defaultCalls + 1;
            Bounds bounds = info.m_mesh.bounds;
            if (bounds.min.y > 0.1f - instance.m_dataVector0.w)
            {
                Vector3 min = bounds.min;
                min.y = -instance.m_dataVector0.w;
                bounds.min = min;
                info.m_mesh.bounds = bounds;
            }

            Graphics.DrawMesh(info.m_mesh, instance.m_dataMatrix1, info.m_material, info.m_prefabDataLayer, null, 0, instance2.m_materialBlock);
        }

        private void BuildingAIRenderMesh(RenderManager.CameraInfo cameraInfo, BuildingInfo info, BuildingInfoBase subInfo, Matrix4x4 matrix, ref RenderManager.Instance instance)
        {
            matrix = instance.m_dataMatrix1 * matrix;

            BuildingManager instance2 = Singleton<BuildingManager>.instance;

            instance2.m_materialBlock.Clear();
            instance2.m_materialBlock.AddVector(instance2.ID_BuildingState, instance.m_dataVector0);
            instance2.m_materialBlock.AddVector(instance2.ID_ObjectIndex, instance.m_dataVector3);
            instance2.m_materialBlock.AddColor(instance2.ID_Color, instance.m_dataColor0);
            if (subInfo.m_requireHeightMap)
            {
                instance2.m_materialBlock.AddTexture(instance2.ID_HeightMap, instance.m_dataTexture0);
                instance2.m_materialBlock.AddVector(instance2.ID_HeightMapping, instance.m_dataVector1);
                instance2.m_materialBlock.AddVector(instance2.ID_SurfaceMapping, instance.m_dataVector2);
            }
            BuildingManager expr_D9_cp_0 = instance2;

            expr_D9_cp_0.m_drawCallData.m_defaultCalls = expr_D9_cp_0.m_drawCallData.m_defaultCalls + 1;
            Bounds bounds = subInfo.m_mesh.bounds;
            if (bounds.min.y > 0.1f - instance.m_dataVector0.w)
            {
                Vector3 min = bounds.min;
                min.y = -instance.m_dataVector0.w;
                bounds.min = min;
                subInfo.m_mesh.bounds = bounds;
            }

            Graphics.DrawMesh(subInfo.m_mesh, matrix, subInfo.m_material, info.m_prefabDataLayer, null, 0, instance2.m_materialBlock);
        }

        private void BeginRenderingImpl(RenderManager.CameraInfo cameraInfo)
        {
            Material material = Singleton<RenderManager>.instance.m_groupLayerMaterials[LayerMask.NameToLayer("Buildings")];
            material.mainTexture = buildingManager.m_lodRgbAtlas;
            material.SetTexture(buildingManager.ID_XYSMap, buildingManager.m_lodXysAtlas);
            material.SetTexture(buildingManager.ID_ACIMap, buildingManager.m_lodAciAtlas);
        }

        private void EndRenderingImpl(RenderManager.CameraInfo cameraInfo)
        {
            FastList<RenderGroup> renderedGroups = Singleton<RenderManager>.instance.m_renderedGroups;
            for (int i = 0; i < renderedGroups.m_size; i++)
            {
                RenderGroup renderGroup = renderedGroups.m_buffer[i];
                int num = renderGroup.m_layersRendered & ~(1 << Singleton<NotificationManager>.instance.m_notificationLayer);
                if (renderGroup.m_instanceMask != 0)
                {
                    num &= ~renderGroup.m_instanceMask;
                    int num2 = renderGroup.m_x * 270 / 45;
                    int num3 = renderGroup.m_z * 270 / 45;
                    int num4 = (renderGroup.m_x + 1) * 270 / 45 - 1;
                    int num5 = (renderGroup.m_z + 1) * 270 / 45 - 1;
                    for (int j = num3; j <= num5; j++)
                    {
                        for (int k = num2; k <= num4; k++)
                        {
                            int num6 = j * 270 + k;
                            ushort num7 = buildingManager.m_buildingGrid[num6];
                            int num8 = 0;
                            while (num7 != 0)
                            {
                                BuildingRenderInstance(buildingManager.m_buildings.m_buffer[(int)num7], cameraInfo, num7, renderGroup.m_instanceMask);
                                num7 = buildingManager.m_buildings.m_buffer[(int)num7].m_nextGridBuilding;
                                if (++num8 >= 32768)
                                {
                                    CODebugBase<LogChannel>.Error(LogChannel.Core, "Invalid list detected!\n" + Environment.StackTrace);
                                    break;
                                }
                            }
                        }
                    }
                }
                if (num != 0)
                {
                    int num9 = renderGroup.m_z * 45 + renderGroup.m_x;
                    ushort num10 = buildingManager.m_buildingGrid2[num9];
                    int num11 = 0;
                    while (num10 != 0)
                    {
                        BuildingRenderInstance(buildingManager.m_buildings.m_buffer[(int)num10], cameraInfo, num10, num);
                        num10 = buildingManager.m_buildings.m_buffer[(int)num10].m_nextGridBuilding2;
                        if (++num11 >= 32768)
                        {
                            CODebugBase<LogChannel>.Error(LogChannel.Core, "Invalid list detected!\n" + Environment.StackTrace);
                            break;
                        }
                    }
                }
            }
            int num12 = PrefabCollection<BuildingInfo>.PrefabCount();
            for (int l = 0; l < num12; l++)
            {
                BuildingInfo prefab = PrefabCollection<BuildingInfo>.GetPrefab((uint)l);
                if (prefab != null)
                {
                    prefab.UpdatePrefabInstances();
                    if (prefab.m_lodCount != 0)
                    {
                        Building.RenderLod(cameraInfo, prefab);
                    }
                    if (prefab.m_subMeshes != null)
                    {
                        for (int m = 0; m < prefab.m_subMeshes.Length; m++)
                        {
                            BuildingInfoBase subInfo = prefab.m_subMeshes[m].m_subInfo;
                            if (subInfo.m_lodCount != 0)
                            {
                                Building.RenderLod(cameraInfo, subInfo);
                            }
                        }
                    }
                }
            }
            if (buildingManager.m_common != null && buildingManager.m_common.m_subInfos != null)
            {
                for (int n = 0; n < buildingManager.m_common.m_subInfos.Length; n++)
                {
                    BuildingInfoBase buildingInfoBase = buildingManager.m_common.m_subInfos[n];
                    if (buildingInfoBase.m_lodCount != 0)
                    {
                        Building.RenderLod(cameraInfo, buildingInfoBase);
                    }
                }
            }
        }
    }

}
