using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class BigPictureVido : MonoBehaviour
{
    public GameObject Picture;
    public MeshRenderer PictureMaterial;
    public GameObject BigPictureGO;

    public GameObject BigVideoGO;
    public VideoPlayer VideoPlayer;
    public VideoPlayer SmallVideoPlayer;

    public void BigPictureVideo(string ClickedButton)
    {
        switch (ClickedButton)
        {
            case "Video":
                BigPictureGO.SetActive(false);

                BigVideoGO.SetActive(!BigVideoGO.activeSelf);
                VideoPlayer.url = SmallVideoPlayer.url;
                break;
            case "Picture":
                BigVideoGO.SetActive(false);

                BigPictureGO.SetActive(!BigPictureGO.activeSelf);
                Material material = Picture.GetComponent<MeshRenderer>().material;

                PictureMaterial.material = material;
                break;
        }
    }
}
