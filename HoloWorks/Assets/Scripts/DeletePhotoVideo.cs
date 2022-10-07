using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePhotoVideo : MonoBehaviour
{
    public GameObject Picture;
    public GameObject Video;

    public void DeletePhoto()
    {

        if (Picture != null)
        {
            Picture.GetComponent<MeshRenderer>().material = null;
            Picture.SetActive(false);
        }
    }

    public void DeleteVideo()
    {
        if(Video != null)
        {
            Video.SetActive(false);
        }
    }
}
