using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoLoader : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    //public string videoUrl = "yourvideourl";

    // Start is called before the first frame update
    public void StartVideo(string videoUrl)
    {
        videoPlayer.url = videoUrl;
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.Prepare();
    }
}