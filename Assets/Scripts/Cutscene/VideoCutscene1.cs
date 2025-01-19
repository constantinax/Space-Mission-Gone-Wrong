using UnityEngine;
using UnityEngine.Video;

using UnityEngine.SceneManagement;

public class VideoCutscene1 : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.Play();
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void Update()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        videoPlayer.Stop();
        Debug.Log("Cutscene Skipped");
        
        SceneManager.LoadScene("LEVEL1");
    }
}

    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("Video Finished");
        SceneManager.LoadScene("LEVEL1");
    }
}
