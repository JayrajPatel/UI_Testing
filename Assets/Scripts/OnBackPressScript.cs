using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnBackPressScript : MonoBehaviour {

    public void OnBackPress()
    {
        SceneManager.UnloadSceneAsync(2);
    }
}
