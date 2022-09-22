using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Seroley.SceneLoading
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance { get; private set; }

        [SerializeField] private GameObject _loaderCanvas = null;
        [SerializeField] private Image _loaderBgImage = null;

        private enum SceneTransitionState { WaitBeforeFadeIn, FadeIn, WaitFadeIn, FadeOut }
        private SceneTransitionState _sceneTransitionState;

        private bool _transitionActive;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
            }
            else
            {
                _transitionActive = false;
                Instance = this;
                DontDestroyOnLoad(gameObject);
                _loaderCanvas.SetActive(false);
                _loaderBgImage.gameObject.SetActive(true);
            }
        }

        public static void LoadScene(UnityEvent OnBeforeSceneLoaded = null, UnityEvent OnAfterSceneLoaded = null, Action loadSceneAction = null, float delayBeforeFadeIn = 0f, float delayFadeIn = 0.2f, float duration = 1.0f)
        {
            if (Instance._transitionActive) return;

            Instance.StartCoroutine(Instance.LoadSceneDelay(OnBeforeSceneLoaded, OnAfterSceneLoaded, loadSceneAction, delayBeforeFadeIn, delayFadeIn, duration));
        }

        private IEnumerator LoadSceneDelay(UnityEvent onBeforeSceneLoaded, UnityEvent onAfterSceneLoaded, Action loadSceneAction, float delayBeforeFadeIn, float delayFadeIn, float duration = 1.0f)
        {
            _loaderCanvas.SetActive(true);
            _sceneTransitionState = SceneTransitionState.WaitBeforeFadeIn;
            Color imageColor = _loaderBgImage.color;
            float alpha = 0.0f;
            float timer = 0.0f;
            bool breakWhile = false;
            _transitionActive = true;
            _loaderBgImage.color = new Color(imageColor.r, imageColor.g, imageColor.b, alpha);

            while (!breakWhile)
            {
                switch (_sceneTransitionState)
                {
                    case SceneTransitionState.WaitBeforeFadeIn:

                        timer += Time.deltaTime;
                        if (timer >= delayBeforeFadeIn)
                        {
                            timer = 0.0f;
                            _sceneTransitionState = SceneTransitionState.FadeIn;
                        }

                        break;

                    case SceneTransitionState.FadeIn:

                        alpha += Time.deltaTime / duration;
                        _loaderBgImage.color = new Color(imageColor.r, imageColor.g, imageColor.b, alpha);

                        if (alpha >= 1.0f)
                        {
                            onBeforeSceneLoaded?.Invoke();
                            loadSceneAction?.Invoke();
                            timer = 0.0f;
                            _sceneTransitionState = SceneTransitionState.WaitFadeIn;
                        }

                        break;

                    case SceneTransitionState.WaitFadeIn:

                        timer += Time.deltaTime;
                        if (timer >= delayFadeIn)
                        {
                            timer = 0.0f;
                            _sceneTransitionState = SceneTransitionState.FadeOut;

                            onAfterSceneLoaded?.Invoke();
                        }

                        break;

                    case SceneTransitionState.FadeOut:

                        alpha -= Time.deltaTime / duration;
                        _loaderBgImage.color = new Color(imageColor.r, imageColor.g, imageColor.b, alpha);

                        if (alpha <= 0.0f)
                        {
                            breakWhile = true;
                        }

                        break;
                }

                yield return null;
            }

            _transitionActive = false;
        }
    }
}