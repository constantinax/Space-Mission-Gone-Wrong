using UnityEngine;
using UnityEngine.Video;

using UnityEngine.SceneManagement;

public class VideoCutscene2 : MonoBehaviour
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
        
        SceneManager.LoadScene("Station");
    }
}

    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("Video Finished");
        SceneManager.LoadScene("Station");
    }
}
