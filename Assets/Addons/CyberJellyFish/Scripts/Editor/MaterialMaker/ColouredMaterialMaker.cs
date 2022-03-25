#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace CyberJellyFish.Editors
{
    public static class ColouredMaterialMaker
    {
        #region METHODS

        [MenuItem("Assets/Create/Materials/Random Coloured Material", false, 280)]
        public static void CompileMaterial()
        {
            string path = EditorSelection.GetSelectedFolderPath();

            Shader shader =
                GraphicsSettings.renderPipelineAsset
                    ? GraphicsSettings.renderPipelineAsset.defaultShader
                    : Shader.Find("Standard");

            Material material = new Material(shader);

            Color color = Color.black;
            color.ToRandomColor();
            material.color = color;

            ProjectWindowUtil.CreateAsset(material, $"{path}{Path.DirectorySeparatorChar}material.mat");
            AssetDatabase.Refresh();
        }

        #endregion
    }
}
#endif