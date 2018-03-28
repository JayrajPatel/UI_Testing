using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class FetchJsonData : MonoBehaviour {

	private const string url = "https://api.flickr.com/services/feeds/photos_public.gne?tags=car&format=json";

	public static FetchJsonData instance;

	public Image[] sliderImages;
	public GameObject sliderPanel;
	public GameObject loadingPanel;

	public List<string> titles = new List<string> ();
	public List<string> descriptions = new List<string> ();

	public List<string> Titles { get { return titles; } }
	public List<string> Descriptions { get { return descriptions; } }

	private bool imagesLoaded;

	public bool ImagesLoaded { get { return imagesLoaded; } }

	void Awake(){
		instance = this;
	}

	void OnEnable(){
		if (imagesLoaded == true) {
			loadingPanel.SetActive (false);
		} else {
			loadingPanel.SetActive (true);
		}
	}

	void Start(){
		imagesLoaded = false;
		StartCoroutine (LoadImages());
	}

	private IEnumerator LoadImages(){
		WWW www = new WWW (url);
		yield return www;

		string rawJson = www.text;
		var jsonData = JSON.Parse (rawJson);

		titles.Clear ();
		descriptions.Clear ();

		for (int i = 0; i < sliderImages.Length; i++) {
			var imageLink = jsonData ["items"] [i] ["media"] ["m"].Value;
			titles.Add (jsonData ["items"] [i] ["title"].Value);
			descriptions.Add (jsonData ["items"] [i] ["tags"].Value);

			WWW wwwImage = new WWW (imageLink);
			yield return wwwImage;
				
			//imageLink = jsonLink [i] 
			Texture2D texture = wwwImage.texture;
			sliderImages [i].sprite = Sprite.Create (texture, new Rect(0, 0, 100, 100), Vector3.zero);
		}

		imagesLoaded = true;
		loadingPanel.SetActive (false);
	}
}
