#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SpriteExtractor.Extensions;
using SpriteExtractor.Parser;
using SpriteExtractor.Serializables;
using UnityEditor;
using UnityEngine;

namespace SpriteExtractor.Extractors
{
    public static partial class SpriteExtractor
    {
        #region XML SPRITE EXTRACTION AND METADATA METHODS

        public static void ExtractFromXml(Texture2D source, TextAsset xml, string savePath = "")
        {
            List<SubTexture> subTextures = XMLParser.ParseXml(xml);

            string path = AssetDatabase.GetAssetPath(source);
            if (string.IsNullOrEmpty(savePath))
                savePath = path.Replace(Path.GetFileName(path), "");

            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
            MakeReadable(textureImporter, path);
            foreach (SubTexture subTexture in subTextures)
            {
                Texture2D extracted =
                    source.CropTexture2D(subTexture.x, subTexture.y, subTexture.width, subTexture.height);
                byte[] data = extracted.EncodeToPNG();
                File.WriteAllBytes(Path.Combine(savePath, $"{subTexture.name}.png"), data);
            }

            AssetDatabase.Refresh();
        }

        public static void ExtractFromXml(Texture2D source, string xml, string savePath = "")
        {
            List<SubTexture> subTextures = XMLParser.ParseXml(xml);

            string path = AssetDatabase.GetAssetPath(source);
            if (string.IsNullOrEmpty(savePath))
                savePath = path.Replace(Path.GetFileName(path), "");

            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
            MakeReadable(textureImporter, path);
            foreach (SubTexture subTexture in subTextures)
            {
                Texture2D extracted =
                    source.CropTexture2D(subTexture.x, subTexture.y, subTexture.width, subTexture.height);
                byte[] data = extracted.EncodeToPNG();
                File.WriteAllBytes(Path.Combine(savePath, $"{subTexture.name}.png"), data);
            }

            AssetDatabase.Refresh();
        }

        // ToDo : Complete Functionality
        public static void ApplyXmlToMetadata(Texture2D source, TextAsset xml)
        {
            List<SubTexture> subTextures = XMLParser.ParseXml(xml);
            ApplyMetadata(source, subTextures);
        }

        public static void ApplyXmlToMetadata(Texture2D source, string xml)
        {
            List<SubTexture> subTextures = XMLParser.ParseXml(xml);
            ApplyMetadata(source, subTextures);
        }

        private static void ApplyMetadata(Texture2D source, List<SubTexture> subTextures)
        {
            string path = AssetDatabase.GetAssetPath(source);
            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;

            int height = source.height;
            bool updateImage = false;

            if (textureImporter.spriteImportMode != SpriteImportMode.Multiple)
            {
                updateImage = true;
                textureImporter.spriteImportMode = SpriteImportMode.Multiple;
            }


            SpriteMetaData[] spriteMetaData = (from subTexture in subTextures
                                               let actualY = height - (subTexture.y + subTexture.height)
                                               select new SpriteMetaData
                                               {
                                                   alignment = (int) SpriteAlignment.Center,
                                                   border = new Vector4(),
                                                   name = subTexture.name,
                                                   pivot = new Vector2(0.5f, 0.5f),
                                                   rect = new Rect(subTexture.x, subTexture.y, subTexture.width,
                                                                   subTexture.height)
                                               }).ToArray();

            if (!updateImage && !textureImporter.spritesheet.SequenceEqual(spriteMetaData))
            {
                updateImage = true;

                textureImporter.spritesheet = spriteMetaData;
            }

            if (updateImage)
            {
                EditorUtility.SetDirty(textureImporter);
                AssetDatabase.StartAssetEditing();
                AssetDatabase.ImportAsset(textureImporter.assetPath);
                AssetDatabase.StopAssetEditing();
            }

            AssetDatabase.Refresh();
        }

        #endregion

        #region EDITOR EXTRACTOR METHODS

        [MenuItem("Assets/Create/2D/Spritesheet/Extract From XML/Extract Here", priority = 30)]
        public static void ExtractSpritesFromXml()
        {
            Texture2D texture2D = Selection.activeObject as Texture2D;
            string texture2DPath = AssetDatabase.GetAssetPath(texture2D);

            string extension = Path.GetExtension(texture2DPath);
            string xmlPath = $"{texture2DPath.Replace(extension, ".xml")}";
            Debug.Log(xmlPath);
            TextAsset xml = AssetDatabase.LoadAssetAtPath<TextAsset>(xmlPath);

            if (xml == null)
            {
                SpriteExtractorWindow.CreateWindow();
                SpriteExtractorWindow.Window.Spritesheet = texture2D;
            }
            else
            {
                ExtractFromXml(texture2D, xml);
            }
        }

        #endregion
    }
}
#endif