using UnityEngine;
using UnityEngine.Video;

public class Splash : MonoBehaviour
{
    void Awake()
    {
        if (TryGetComponent<VideoPlayer>(out var videoPlayer))
        {
            videoPlayer.loopPointReached += OnVideoEnd;
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}
