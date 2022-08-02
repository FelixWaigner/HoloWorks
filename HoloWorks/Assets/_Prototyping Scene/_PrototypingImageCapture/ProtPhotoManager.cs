using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.WebCam;
using System.Threading;
using System;
using System.IO;

public class ProtPhotoManager : MonoBehaviour
{
    PhotoCapture photoCaptureObject = null;
    public GameObject quad;

    static readonly int TotalImagesToCapture = 1;
    int capturedImageCount = 0;
    string filePath;

    // Use this for initialization
    public void TakePhoto()
    {
        Resolution cameraResolution = PhotoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();
        Texture2D targetTexture = new Texture2D(cameraResolution.width, cameraResolution.height);

        PhotoCapture.CreateAsync(false, delegate (PhotoCapture captureObject) {
            Debug.Log("Created PhotoCapture Object");
            photoCaptureObject = captureObject;

            CameraParameters c = new CameraParameters();
            c.hologramOpacity = 0.0f;
            c.cameraResolutionWidth = targetTexture.width;
            c.cameraResolutionHeight = targetTexture.height;
            c.pixelFormat = CapturePixelFormat.BGRA32;

            captureObject.StartPhotoModeAsync(c, delegate (PhotoCapture.PhotoCaptureResult result) {
                Debug.Log("Started Photo Capture Mode");
                TakePicture();
            });
        });
    }

    void OnCapturedPhotoToDisk(PhotoCapture.PhotoCaptureResult result)
    {
        Debug.Log("Saved Picture To Disk!");

        if (capturedImageCount < TotalImagesToCapture)
        {
            TakePicture();
        }
        else
        {
            photoCaptureObject.StopPhotoModeAsync(OnStoppedPhotoMode);
        }
    }

    void TakePicture()
    {
        capturedImageCount++;
        var uuid = Guid.NewGuid();
        Debug.Log(string.Format("Taking Picture ({0}/{1})...", capturedImageCount, TotalImagesToCapture));
        string filename = string.Format($"img_{uuid}.jpg");
        filePath = System.IO.Path.Combine(Application.persistentDataPath, filename);
        photoCaptureObject.TakePhotoAsync(filePath, PhotoCaptureFileOutputFormat.JPG, OnCapturedPhotoToDisk);
        Debug.Log(filePath);
    }

    void OnStoppedPhotoMode(PhotoCapture.PhotoCaptureResult result)
    {
        photoCaptureObject.Dispose();
        photoCaptureObject = null;

        Debug.Log("Captured images have been saved at the following path.");
        Debug.Log(Application.persistentDataPath);


        LoadImage(filePath);
    }

    public void LoadImage(string path)
    {
        if (File.Exists(path))
        {
            byte[] bytes = File.ReadAllBytes(path);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(bytes);
            Renderer quadRenderer = quad.GetComponent<Renderer>() as Renderer;
            quadRenderer.material = new Material(Shader.Find("Legacy Shaders/Diffuse")); //Custom/Unlit/UnlitTexture
            quadRenderer.material.SetTexture("_MainTex", tex);
        }
        else
        {
            Debug.LogError("File does not exist");
        }
    }
}
