using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ProtLoadImage : MonoBehaviour
{
	public GameObject rawImage;
	Texture2D myTexture;

	// Use this for initialization
	public void loadPhoto()
	{
		// load texture from resource folder
		myTexture = Resources.Load("C:/Users/Waign/AppData/LocalLow/DefaultCompany/HoloWorks/img_81151410-4dc2-473c-8772-f076ae3c7eee.jpg") as Texture2D;

		rawImage.GetComponent<RawImage>().texture = myTexture;
	}
}
