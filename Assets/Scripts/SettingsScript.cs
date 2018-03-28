using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour {
    public Image steeringImage;
    public Image arrowImage;
    public Image manualDriveImage;
    public Image steeringButtonImage;
    public Image arrowButtonImage;
    public Image tiltButtonImage;
    public Sprite steeringLeftSprite;
    public Sprite steeringRightSprite;
    public Sprite arrowLeftSprite;
    public Sprite arrowRightSprite;
    public Sprite manualDriveOn;
    public Sprite manualDriveOff;
    public Button sideToggle;
    public Sprite toggleOff;
    public Sprite toggleOn;
    public Button mdButton;
    public Slider steeringSensiSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    private int isLeft;
    private int Arrow;
    private int manualDriveIsOn;

  
    public void Start() {
        SetValues();
    }

    private void SetValues() {
        if (PlayerPrefs.GetInt("isLeft") == 0)
        {
            isLeft = 0;
            sideToggle.GetComponent<Image>().sprite = toggleOff;
            steeringImage.sprite = steeringLeftSprite;
            arrowImage.sprite = arrowLeftSprite;
        }
        else
        {
            isLeft = 1;
            sideToggle.GetComponent<Image>().sprite = toggleOn;
            steeringImage.sprite = steeringRightSprite;
            arrowImage.sprite = arrowRightSprite;
        }
        if (PlayerPrefs.GetInt("mdIsOn") == 0)
        {
            manualDriveIsOn = 0;
            manualDriveImage.sprite = manualDriveOff;
            mdButton.GetComponent<Image>().color = Color.white;
            mdButton.transform.GetChild(0).GetComponent<Text>().text = ("OFF");
        }
        else
        {
            manualDriveIsOn = 1;
            manualDriveImage.sprite = manualDriveOn;
            mdButton.GetComponent<Image>().color = Color.green;
            mdButton.transform.GetChild(0).GetComponent<Text>().text = ("ON");
        }
        if (PlayerPrefs.GetInt("controls") == 0)
        {
            steeringButtonImage.GetComponent<Image>().color = Color.green;
        }
        else if (PlayerPrefs.GetInt("controls") == 1)
        {
            arrowButtonImage.GetComponent<Image>().color = Color.green;
        }
        else
        {
            tiltButtonImage.GetComponent<Image>().color = Color.green;
        }
        steeringSensiSlider.value = PlayerPrefs.GetFloat("steeringSensitivity");
        musicSlider.value = PlayerPrefs.GetFloat("music");
        sfxSlider.value = PlayerPrefs.GetFloat("sfx");
    }

    public void FlipControls()
    {
        if (isLeft == 1)
        {
            isLeft = 0;
            sideToggle.GetComponent<Image>().sprite = toggleOff;
            steeringImage.sprite = steeringLeftSprite;
            arrowImage.sprite = arrowLeftSprite;
            PlayerPrefs.SetInt("isLeft", 0);
        }
        else
        {
            isLeft = 1;
            sideToggle.GetComponent<Image>().sprite = toggleOn;
            steeringImage.sprite = steeringRightSprite;
            arrowImage.sprite = arrowRightSprite;
            PlayerPrefs.SetInt("isLeft", 1);
        }
    }
    public void OnManualDrivePress()
    {
        if (manualDriveIsOn == 0)
        {
            manualDriveIsOn = 1;
            manualDriveImage.sprite = manualDriveOn;
            PlayerPrefs.SetInt("mdIsOn", 1);
            mdButton.GetComponent<Image>().color = Color.green;
            mdButton.transform.GetChild(0).GetComponent<Text>().text = ("ON");
        }
        else
        {
            manualDriveIsOn = 0;
            manualDriveImage.sprite = manualDriveOff;
            PlayerPrefs.SetInt("mdIsOn", 0);
            mdButton.GetComponent<Image>().color = Color.white;
            mdButton.transform.GetChild(0).GetComponent<Text>().text = ("OFF");
        }
    }
    public void OnSteeringSelectionPress()
    {
        steeringButtonImage.GetComponent<Image>().color = Color.green;
        arrowButtonImage.GetComponent<Image>().color = Color.white;
        tiltButtonImage.GetComponent<Image>().color = Color.white;
        PlayerPrefs.SetInt("controls", 0);
    }
    public void OnArrowSelectionPress()
    {
        arrowButtonImage.GetComponent<Image>().color = Color.green;
        tiltButtonImage.GetComponent<Image>().color = Color.white;
        steeringButtonImage.GetComponent<Image>().color = Color.white;
        PlayerPrefs.SetInt("controls", 1);
    }
    public void OnTiltSelectionPress()
    {
        tiltButtonImage.GetComponent<Image>().color = Color.green;
        arrowButtonImage.GetComponent<Image>().color = Color.white;
        steeringButtonImage.GetComponent<Image>().color = Color.white;
        PlayerPrefs.SetInt("controls", 2);
    }
    public void Games2win()
    {
        Application.OpenURL("https://www.games2win.com");
    }
    public void OnHelpPress() {
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }
    public void OnSteeringPress()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
    
    public void SteeringSlider() {
        PlayerPrefs.SetFloat("steeringSensitivity", steeringSensiSlider.value);
    }
    public void MusicSlider()
    {
        PlayerPrefs.SetFloat("music", musicSlider.value);
    }
    public void SfxSlider()
    {
        PlayerPrefs.SetFloat("sfx", sfxSlider.value);
    }
}
