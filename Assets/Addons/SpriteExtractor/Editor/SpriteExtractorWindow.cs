/**
 * Created By: Ubaidullah Effendi-Emjedi
 * LinkedIn : https://www.linkedin.com/in/ubaidullah-effendi-emjedi-202494183/
 */

#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace SpriteExtractor.Extractors
{
    public class SpriteExtractorWindow : EditorWindow
    {
        #region EDITOR WINDOW

        /// <summary>
        /// Sprite Extractor Window Instance.
        /// </summary>
        public static SpriteExtractorWindow Window;

        [MenuItem("Window/Spritesheet/Sprite Extractor")]
        public static void CreateWindow()
        {
            Window = GetWindow<SpriteExtractorWindow>("Sprite Extractor Tool");
            Window.Show();
        }

        #endregion

        #region VARIABLES

        private const float IMAGE_WIDTH = 128f;
        private const float IMAGE_HEIGHT = 128f;

        public Texture2D Spritesheet;
        private TextAsset _xmlAsset;

        private string _spritesheetPath = "";
        private string _savePath = "";
        private string _xmlPath = "";

        private bool _autoExtractSelectedSprites;

        private Vector2 _delta;

        private float _width = 0f;
        private float _height = 0f;

        private Rect _imageRect = Rect.zero;

        private GUIContent _spriteContent;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            _spriteContent = new GUIContent("Sprite Sheet", Spritesheet, "Selected Sprite Sheet");
        }

        public void OnGUI()
        {
            SelectedImageField();
            DragAndDropSpriteSheets();
            AutoExtractOnSelectionField();
            SpriteSheetPathFields();
            FileHandlingButtons();
            ExtractButtons();
            SpriteSheetDisplayField();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Selected Sprite Sheet Preview
        /// </summary>
        private void SelectedImageField()
        {
            EditorGUI.BeginChangeCheck();

            Spritesheet =
                EditorGUILayout.ObjectField(_spriteContent, Spritesheet, typeof(Texture2D), false) as Texture2D;

            if (EditorGUI.EndChangeCheck())
            {
                if (Spritesheet)
                {
                    _spritesheetPath = AssetDatabase.GetAssetPath(Spritesheet);
                }
                else
                {
                    _spritesheetPath = "";
                    _imageRect = Rect.zero;
                }
            }
        }

        /// <summary>
        /// Drag and Drop Sprite Sheets into the Window.
        /// </summary>
        private void DragAndDropSpriteSheets()
        {
            if (Event.current.type == EventType.DragUpdated)
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
                Event.current.Use();
            }
            else if (Event.current.type == EventType.DragPerform)
            {
                // To consume drag data.
                DragAndDrop.AcceptDrag();

                // Unity Assets including folder.
                if (DragAndDrop.objectReferences.Length > 0)
                {
                    Debug.Log("UnityAsset");

                    int length = DragAndDrop.objectReferences.Length;

                    foreach (Object objectReference in DragAndDrop.objectReferences)
                    {
                        _spritesheetPath = AssetDatabase.GetAssetPath(objectReference);
                        _savePath = _spritesheetPath.Replace(Path.GetFileName(_spritesheetPath), "");

                        if (!(objectReference is Texture2D))
                        {
                            Debug.Log($"Not a Texture2D: {objectReference.name}");
                            continue;
                        }

                        Spritesheet = objectReference as Texture2D;
                        Assert.IsNotNull(Spritesheet);

                        if (!_autoExtractSelectedSprites)
                        {
                            break;
                        }

                        SpriteExtractor.ExtractAllSprites(Spritesheet);
                    }
                }
                // Log to make sure we cover all cases.
                else
                {
                    Debug.Log("Out of reach");
                    Debug.Log("Paths:");

                    foreach (string path in DragAndDrop.paths)
                    {
                        Debug.Log("- " + path);
                    }

                    Debug.Log("ObjectReferences:");

                    foreach (Object obj in DragAndDrop.objectReferences)
                    {
                        Debug.Log("- " + obj);
                    }
                }
            }
        }

        /// <summary>
        /// Automatically Extract Selected Sprites GUI
        /// </summary>
        private void AutoExtractOnSelectionField()
        {
            _autoExtractSelectedSprites =
                EditorGUILayout.ToggleLeft("Auto Extract on Drop", _autoExtractSelectedSprites);
        }

        /// <summary>
        /// Spritesheet Path and Extracted Sprites Save Path Fields
        /// </summary>
        private void SpriteSheetPathFields()
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.TextField("Sprite Sheet Path:", _spritesheetPath, new GUIStyle
            {
                alignment = TextAnchor.MiddleLeft,
            });

            EditorGUILayout.TextField("Extracted Sprites Path:", _savePath, new GUIStyle
            {
                alignment = TextAnchor.MiddleLeft
            });

            EditorGUILayout.TextField("XML Path:", _xmlPath, new GUIStyle
            {
                alignment = TextAnchor.MiddleLeft
            });

            EditorGUILayout.EndVertical();
        }

        /// <summary>
        /// File Path Handling Button
        /// </summary>
        private void FileHandlingButtons()
        {
            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Select New Extraction Path"))
            {
                _savePath = EditorUtility.SaveFolderPanel("Extracted Sprites Path", Application.dataPath, "");
            }

            if (GUILayout.Button("Reset Save Location"))
            {
                if (!string.IsNullOrEmpty(_spritesheetPath))
                {
                    _savePath = _spritesheetPath.Replace(Path.GetFileName(_spritesheetPath), "");
                }
                else
                {
                    _savePath = "";
                }
            }

            if (GUILayout.Button("Find XML"))
            {
                _xmlPath = EditorUtility.OpenFilePanel("Image XML", Application.dataPath, "xml");
            }

            EditorGUILayout.EndHorizontal();
        }

        /// <summary>
        /// Sprite Extraction Button
        /// </summary>
        private void ExtractButtons()
        {
            if (GUILayout.Button("Extract"))
            {
                if (Spritesheet)
                {
                    SpriteExtractor.ExtractAllSprites(Spritesheet);
                }
            }

            if (GUILayout.Button("Extract From XML"))
            {
                if (Spritesheet)
                {
                    SpriteExtractor.ExtractFromXml(Spritesheet, File.ReadAllText(_xmlPath), _savePath);
                }
            }
        }

        /// <summary>
        /// Sprite Sheet Display Field.
        /// </summary>
        private void SpriteSheetDisplayField()
        {
            if (!Spritesheet)
            {
                return;
            }


            if (_imageRect == Rect.zero)
            {
                _imageRect = new Rect(0, 196, IMAGE_WIDTH, IMAGE_HEIGHT);
            }

            _delta = Event.current.delta;

            if (_imageRect.Contains(Event.current.mousePosition) && Event.current.type == EventType.ScrollWheel)
            {
                _width += _delta.y  * -9f;
                _height += _delta.y * -9f;

                if (_width < IMAGE_WIDTH)
                {
                    _width = IMAGE_WIDTH;
                }

                if (_height < IMAGE_HEIGHT)
                {
                    _height = IMAGE_HEIGHT;
                }

                _imageRect.width = _width;
                _imageRect.height = _height;
            }

            if (_imageRect.Contains(Event.current.mousePosition))
            {
                _imageRect.x += _delta.normalized.x;
                _imageRect.y += _delta.normalized.y;
            }

            Repaint();
            GUI.DrawTexture(_imageRect, Spritesheet, ScaleMode.ScaleToFit);
        }

        #endregion
    }
}
#endif