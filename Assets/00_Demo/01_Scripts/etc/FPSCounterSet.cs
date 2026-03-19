using UnityEngine;
using UnityEngine.SceneManagement;

public static class FPSCounterSet
{
    private const string AnalysisSetSceneName = "FPSCounter";
    private const string SplashSceneName = "Splash";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        EnsureAnalysisSetLoaded();
        SceneManager.sceneLoaded += (_, __) => EnsureAnalysisSetLoaded();
    }
    private static void EnsureAnalysisSetLoaded()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        if (activeScene.name == SplashSceneName)
        {
            return;
        }

        Scene gameManagerScene = SceneManager.GetSceneByName(AnalysisSetSceneName);
        if (gameManagerScene.isLoaded)
        {
            return;
        }

        SceneManager.LoadScene(AnalysisSetSceneName, LoadSceneMode.Additive);
    }
}
