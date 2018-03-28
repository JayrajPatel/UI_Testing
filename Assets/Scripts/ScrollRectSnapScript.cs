using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrollRectSnapScript : MonoBehaviour {

	public RectTransform panel;
	public Image[] modelImages;
	public RectTransform center;
	public int startImage;

	public int distanceBetweenTwoImage; 
	public Text titleText;
	public Text descriptionText;

	private float[] distance;
	private float[] distReposition;
	private bool dragging = false;
	private int imageDistance;
	private int minImageNum;
	private float minDistance;
	private float newX;

	void Awake(){
		startImage = PlayerPrefs.GetInt ("SelectedModelNo");
	}

	void Start(){
		distance = new float[modelImages.Length];
		distReposition = new float[modelImages.Length];
		imageDistance = (int)Mathf.Abs (modelImages [1].GetComponent<RectTransform> ().anchoredPosition.x - modelImages [0].GetComponent<RectTransform> ().anchoredPosition.x);

		panel.anchoredPosition = new Vector2 ((startImage) * -imageDistance, 0f);
	}

	void Update(){

		for (int i = 0; i < modelImages.Length; i++) {
			distReposition[i] = center.GetComponent<RectTransform> ().position.x - modelImages [i].GetComponent<RectTransform> ().position.x;
			distance [i] = Mathf.Abs (distReposition[i]);
		}
		
		minDistance = Mathf.Min (distance); 

		for (int i = 0; i < modelImages.Length; i++) {
			if (minDistance == distance [i]) {
				minImageNum = i;
			}
		}
			
		if (!dragging) {
			LerpToImage (-modelImages[minImageNum].GetComponent<RectTransform>().anchoredPosition.x);
		}
	}

	private void LerpToImage(float position){
		newX = Mathf.Lerp (panel.anchoredPosition.x, position, Time.deltaTime * 15f);
		panel.anchoredPosition = new Vector2 (newX, panel.anchoredPosition.y);
		if (FetchJsonData.instance.ImagesLoaded) {
			titleText.text = FetchJsonData.instance.Titles [-(int)(position / distanceBetweenTwoImage)];
			descriptionText.text = FetchJsonData.instance.Descriptions [-(int)(position / distanceBetweenTwoImage)];
		}
	}

	public void StartDrag(){
		dragging = true;
	}

	public void EndDrag(){
		dragging = false;
	}
    public void OnBackPress()
    {
        SceneManager.UnloadSceneAsync(1);
    }
}
