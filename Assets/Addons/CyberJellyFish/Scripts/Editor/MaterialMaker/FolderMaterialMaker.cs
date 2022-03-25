#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;

namespace CyberJellyFish.Editors
{
    public static class FolderMaterialMaker
    {
        #region VARIABLES

        /// <summary>
        /// Main Texture
        /// </summary>
        public static int _MainTex = Shader.PropertyToID("_MainTex");
        public static int _BaseMap = Shader.PropertyToID("_BaseMap");

        /// <summary>
        /// Metallic Map
        /// </summary>
        private static int _MetallicGlossMap = Shader.PropertyToID("_MetallicGlossMap");

        /// <summary>
        /// Specular Map
        /// </summary>
        private static int _SpecGlossMap = Shader.PropertyToID("_SpecGlossMap");

        /// <summary>
        /// Occlusion Map / AO Map
        /// </summary>
        private static int _OcclusionMap = Shader.PropertyToID("_OcclusionMap");

        /// <summary>
        /// Normal Map
        /// </summary>
        private static int _BumpMap = Shader.PropertyToID("_BumpMap");

        #endregion

        #region METHODS

        [MenuItem("Assets/Create/Materials/From Folder", false, 280)]
        public static void CompileMaterial()
        {
            string path = EditorSelection.GetSelectedFolderPath();
            string materialName = string.Empty;

            string[] guids = AssetDatabase.FindAssets("t:texture2D", new[] {path});
            if (guids.IsNull())
            {
                Debug.LogWarning("Incorrect Folder Selected");
                return;
            }

            TextureKeywords textureKeywords = Resources.Load<TextureKeywords>("TextureKeywords/texture-keywords");
            if (!textureKeywords) textureKeywords = ScriptableObject.CreateInstance<TextureKeywords>();

            CreateMaterial(out Material material);

            foreach (string guid in guids)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);

                materialName = string.IsNullOrEmpty(materialName)
                    ? "material.mat"
                    : $"{Path.GetFileName(Path.GetDirectoryName(assetPath))}.mat";

                Texture texture = AssetDatabase.LoadAssetAtPath<Texture>(assetPath);

                SetTextureMap(textureKeywords.BaseMapKeys, texture, material, _BaseMap);
                SetTextureMap(textureKeywords.MetallicMapKeys, texture, material, _MetallicGlossMap);
                SetTextureMap(textureKeywords.SpecularMapKeys, texture, material, _SpecGlossMap);
                SetTextureMap(textureKeywords.OcclusionMapKeys, texture, material, _OcclusionMap);
                SetNormalMap(textureKeywords, texture, assetPath, material);
            }

            ProjectWindowUtil.CreateAsset(material, $"{path}{Path.DirectorySeparatorChar}{materialName}");
            AssetDatabase.Refresh();
        }

        private static Material CreateMaterial(out Material material)
        {
            Shader shader =
                GraphicsSettings.renderPipelineAsset
                    ? GraphicsSettings.renderPipelineAsset.defaultShader
                    : Shader.Find("Standard");

            material = new Material(shader);

            return material;
        }

        private static void ImportAsNormalMap(string path)
        {
            TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;
            if (!importer) return;
            importer.textureType = TextureImporterType.NormalMap;
            EditorUtility.SetDirty(importer);
            importer.SaveAndReimport();
        }

        private static bool ContainsKeyword(List<string> keywords, string name)
        {
            return keywords.Any(keyword => name.Contains(keyword));
        }

        private static void SetTextureMap(List<string> keywords, Texture texture, Material material, int materialKey)
        {
            if (ContainsKeyword(keywords, texture.name.ToLower()))
            {
                material.SetTexture(materialKey, texture);
            }
        }

        private static void SetNormalMap(TextureKeywords textureKeywords, Texture texture, string assetPath,
                                         Material material)
        {
            if (ContainsKeyword(textureKeywords.NormalMapKeys, texture.name.ToLower()))
            {
                ImportAsNormalMap(assetPath);
                material.SetTexture(_BumpMap, texture);
            }
        }

        #endregion
    }
}

#endif