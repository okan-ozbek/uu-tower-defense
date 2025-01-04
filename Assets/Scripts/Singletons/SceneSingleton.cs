using System.Collections;
using Controllers.UI;
using Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Singletons
{
    public class SceneSingleton : MonoBehaviour
    {
        private void OnEnable()
        {
            SceneManager.sceneLoaded += HandleSceneLoaded;
            
            MenuButtonController.OnYesQuitGameClicked += HandleYesQuitGameClicked;
            MenuButtonController.OnStartGameClicked += HandleStartGameClicked;
            GameButtonController.OnYesQuitGameClicked += HandleYesQuitGameClicked;
            GameButtonController.OnGameLostClicked += HandleGameLostClicked;
        }
        
        private void OnDisable()
        {
            SceneManager.sceneLoaded -= HandleSceneLoaded;
            
            GameButtonController.OnYesQuitGameClicked -= HandleYesQuitGameClicked;
            MenuButtonController.OnYesQuitGameClicked -= HandleYesQuitGameClicked;
            MenuButtonController.OnStartGameClicked -= HandleStartGameClicked;
            GameButtonController.OnGameLostClicked -= HandleGameLostClicked;
        }

        private void Start()
        {
            FromPreviousScene();
        }

        private void LoadScene(SceneName sceneName)
        {
            SceneManager.LoadScene(sceneName.ToString());
        }
        
        private void HandleStartGameClicked()
        {
            ToNextScene(SceneName.Game);
        }

        private void HandleYesQuitGameClicked()
        {
            ToNextScene(SceneManager.GetActiveScene().name == SceneName.Game.ToString()
                ? SceneName.MainScreen
                : SceneName.Quit);
        }
        
        private void HandleGameLostClicked()
        {
            ToNextScene(SceneName.MainScreen);
        }
        
        private void HandleSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            FromPreviousScene();
        }
        
        private void FromPreviousScene()
        {
            StartCoroutine(FromScene(TransitionAnimationType.ToDown));
        }

        private void ToNextScene(SceneName sceneName)
        {
            StartCoroutine(ToScene(TransitionAnimationType.FromUp, sceneName));
        }

        private IEnumerator FromScene(TransitionAnimationType transitionAnimationType)
        {
            yield return Transition(transitionAnimationType);
        }
        
        private IEnumerator ToScene(TransitionAnimationType transitionAnimationType, SceneName sceneName)
        {
            yield return Transition(transitionAnimationType);
            
            if (sceneName == SceneName.Quit)
            {
                Application.Quit();
            }
            else
            {
                LoadScene(sceneName);
            }
        }
        
        private IEnumerator Transition(TransitionAnimationType transitionAnimationType)
        {
            const float speed = 1500.0f;
            
            GameObject instance = GameObject.FindWithTag(Tags.Transition.ToString());
            RectTransform instanceTransform = instance.GetComponent<RectTransform>();
            
            Vector2 startPosition = transitionAnimationType switch
            {
                TransitionAnimationType.FromUp => (Vector3.up * (Screen.height + 250)),
                TransitionAnimationType.ToDown => Vector3.zero,
                _ => Vector3.zero
            };
            
            Vector2 endPosition = transitionAnimationType switch
            {
                TransitionAnimationType.FromUp => Vector3.zero,
                TransitionAnimationType.ToDown => -(Vector3.up * (Screen.height + 250)),
                _ => Vector3.zero
            };
            
            instanceTransform.anchoredPosition = startPosition;
            float journeyDistance = Vector3.Distance(startPosition, endPosition);
            float startTime = Time.unscaledTime;
            
            while (instanceTransform.anchoredPosition != endPosition)
            {
                float coveredDistance = (Time.unscaledTime - startTime) * speed;
                float fractionOfJourney = coveredDistance / journeyDistance;
                instanceTransform.anchoredPosition = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
                
                yield return null;
            }
        }
    }
}