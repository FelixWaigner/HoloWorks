using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.Windows.WebCam;
using System;
using UnityEngine.Video;
using System.Threading;

[RequireComponent(typeof(AudioSource))]
public class VideoCaptureExample : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    AudioClip PhotoCountdownClip, VideoCountdownClip, VideoSavedClip;
    AudioSource audioSource;
    public EventHandler<string> OnVideoCaptured;
    VideoCapture webcamVideoCaptureObject;
    public VideoCapture VideoPlayerObject;
    string videoFilePath;

    public void RecordVideo()
    {
        Resolution cameraResolution = VideoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();
        float cameraFramerate = VideoCapture.GetSupportedFrameRatesForResolution(cameraResolution).OrderByDescending((fps) => fps).First();


        VideoCapture.CreateAsync(false, delegate (VideoCapture videoCapture)
        {
            if (videoCapture != null)
            {
                webcamVideoCaptureObject = videoCapture;
                Debug.Log("Created VideoCapture Instance!");

                CameraParameters cameraParameters = new CameraParameters();
                cameraParameters.hologramOpacity = 0.0f;
                cameraParameters.frameRate = cameraFramerate;
                cameraParameters.cameraResolutionWidth = cameraResolution.width;
                cameraParameters.cameraResolutionHeight = cameraResolution.height;
                cameraParameters.pixelFormat = CapturePixelFormat.BGRA32;

                webcamVideoCaptureObject.StartVideoModeAsync(cameraParameters,
                                                   VideoCapture.AudioState.ApplicationAndMicAudio,
                                                   OnStartedVideoCaptureMode);
            }
            else
            {
                Debug.LogError("Failed to create VideoCapture Instance!");
            }
        });
    }

    // called every time the hand menu is opened
    public void StopRecordVideo()
    {
        if (webcamVideoCaptureObject == null || !webcamVideoCaptureObject.IsRecording) return;

        webcamVideoCaptureObject.StopRecordingAsync(OnStoppedRecordingVideo);
        Debug.Log(videoFilePath);
        Thread.Sleep(1000);     //Wait till windows created video !EXPERIMENTAL!
        videoPlayer.url = videoFilePath;    //Load the video form path
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.Prepare();
    }

    void OnStartedVideoCaptureMode(VideoCapture.VideoCaptureResult result)
    {
        var uuid = Guid.NewGuid();
        videoFilePath = $"{Application.persistentDataPath}/{uuid}.mp4";
        webcamVideoCaptureObject.StartRecordingAsync(videoFilePath, OnStartedRecordingVideo);
    }

    void OnStartedRecordingVideo(VideoCapture.VideoCaptureResult result)
    {
        Debug.Log("Started Recording Video!");
    }

    void OnStoppedRecordingVideo(VideoCapture.VideoCaptureResult result)
    {
        webcamVideoCaptureObject.StopVideoModeAsync(OnStoppedVideoCaptureMode);
        OnVideoCaptured?.Invoke(this, videoFilePath);
    }

    void OnStoppedVideoCaptureMode(VideoCapture.VideoCaptureResult result)
    {
        Debug.Log("Stopped Video Capture Mode!");
    }
}