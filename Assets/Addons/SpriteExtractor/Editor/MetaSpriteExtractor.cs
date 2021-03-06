#if UNITY_EDITOR
using System.IO;
using SpriteExtractor.Extensions;
using UnityEditor;
using UnityEngine;

namespace SpriteExtractor.Extractors
{
    public static partial class SpriteExtractor
    {
        #region SIMPLE SPRITE EXTRACTION METHODS

        public static void ExtractSubSprites(Object meta, string savePath = "")
        {
            string name = meta.name;
            string path = AssetDatabase.GetAssetPath(meta);
            if (string.IsNullOrEmpty(savePath))
            {
                savePath = path.Replace(Path.GetFileName(path), "");
            }

            Texture2D source = GetSourceTexture2D(path);

            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
            MakeReadable(textureImporter, path);
            foreach (SpriteMetaData metaData in textureImporter.spritesheet)
            {
                if (string.CompareOrdinal(metaData.name, name) == 0)
                {
                    Texture2D extracted = source.CropTexture2D((int) metaData.rect.x, (int) metaData.rect.y,
                                                               (int) metaData.rect.width,
                                                               (int) metaData.rect.height);

                    byte[] data = extracted.EncodeToPNG();
                    File.WriteAllBytes(Path.Combine(savePath, $"{metaData.name}.png"), data);
                }
            }

            AssetDatabase.Refresh();
        }

        #endregion

        #region EDITOR EXTRACTOR METHODS

        [MenuItem("Assets/Create/2D/Spritesheet/Extract From Meta/Extract Here", priority = 20)]
        public static void ExtractSubSpriteHere()
        {
            Object[] objects = Selection.objects;
            foreach (Object metaObject in objects)
            {
                ExtractSubSprites(metaObject);
            }
        }

        [MenuItem("Assets/Create/2D/Spritesheet/Extract From Meta/Extract Elsewhere", priority = 20)]
        public static void ExtractSubSpriteToAnotherLocation()
        {
            Object meta = Selection.activeObject;
            string path = EditorUtility.SaveFolderPanel("Save Sprite", Application.dataPath, meta.name);
            ExtractSubSprites(meta, path);
        }

        #endregion
    }
}
#endif