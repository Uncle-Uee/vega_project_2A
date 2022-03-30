using System.Collections;
using System.Collections.Generic;
using Uee.UI.Bars;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Uee.UI.Loading
{
    public enum SceneIndex
    {
        None = -1,
        TitleScene = 1,
        Demo_World = 2,
    }
    
    public static class EnumExtensions
    {
        public static int IntValue(this SceneIndex index)
        {
            return index.GetHashCode();
        }
    }

    public class LoadSceneManager : MonoBehaviour
    {
        #region VARIABLES

        [Header("Loading Screen")]
        public Canvas LoadingScreenCanvas;
        public ProgressBar LoadingProgress;

        private List<AsyncOperation> _sceneLoadingOperations = new List<AsyncOperation>();
        private float _totalSceneProgress;

        private SceneIndex _loadedScene = SceneIndex.None;
        private List<SceneIndex> _loadedScenes = new List<SceneIndex>();

        #endregion

        #region UNITY METHODS

        #endregion

        #region LOAD AND UNLOAD SCENE METHODS

        public void LoadWorldScene_FromTitle(SceneIndex sceneIndex)
        {
            LoadingScreenCanvas.enabled = true;
            _loadedScene = sceneIndex;
            _sceneLoadingOperations.Add(SceneManager.UnloadSceneAsync(SceneIndex.TitleScene.IntValue()));
            _sceneLoadingOperations.Add(SceneManager.LoadSceneAsync(sceneIndex.IntValue()));

            StartCoroutine(GetLoadingProgress());
        }

        public void UnloadWorldScene_ToTitle()
        {
            LoadingScreenCanvas.enabled = true;
            _sceneLoadingOperations.Add(SceneManager.UnloadSceneAsync(_loadedScene.IntValue()));
            _sceneLoadingOperations.Add(SceneManager.LoadSceneAsync(SceneIndex.TitleScene.IntValue()));
            _loadedScene = SceneIndex.None;

            StartCoroutine(GetLoadingProgress());
        }

        public void LoadWorldScenes_FromTitle(List<SceneIndex> sceneIndices)
        {
            LoadingScreenCanvas.enabled = true;
            _sceneLoadingOperations.Add(SceneManager.UnloadSceneAsync(SceneIndex.TitleScene.IntValue()));
            foreach (SceneIndex sceneIndex in sceneIndices)
                _sceneLoadingOperations.Add(SceneManager.LoadSceneAsync(sceneIndex.IntValue(), LoadSceneMode.Additive));
            _loadedScenes = sceneIndices;

            StartCoroutine(GetLoadingProgress());
        }

        public void UnloadWorldScenes_ToTitle()
        {
            LoadingScreenCanvas.enabled = true;
            foreach (SceneIndex sceneIndex in _loadedScenes)
                _sceneLoadingOperations.Add(SceneManager.UnloadSceneAsync(sceneIndex.IntValue()));
            _sceneLoadingOperations.Add(SceneManager.LoadSceneAsync(SceneIndex.TitleScene.IntValue()));
            _loadedScenes.Clear();

            StartCoroutine(GetLoadingProgress());
        }

        #endregion

        #region PROGRESS METHOD

        private IEnumerator GetLoadingProgress()
        {
            for (int i = 0; i < _sceneLoadingOperations.Count; i++)
            {
                while (!_sceneLoadingOperations[i].isDone)
                {
                    _totalSceneProgress = 0;
                    foreach (AsyncOperation operation in _sceneLoadingOperations)
                    {
                        _totalSceneProgress += operation.progress;
                    }

                    _totalSceneProgress = (_totalSceneProgress / _sceneLoadingOperations.Count) * 100f;

                    LoadingProgress.Current = Mathf.Round(_totalSceneProgress);

                    yield return null;
                }
            }

            _sceneLoadingOperations.Clear();
            LoadingScreenCanvas.enabled = false;
        }

        #endregion
    }
}