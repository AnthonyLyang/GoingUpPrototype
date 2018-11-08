using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject pausebutton;
    public GameObject playbutton;
    public GameMode mode;


    public void PauseButton()
    {
        Debug.Log("Pause");
        Time.timeScale = 0;
        GameMode.pro = GameProgress.Start;
        playbutton.SetActive(true);
        pausebutton.SetActive(false);
    }


    public void PlayButton()
    {
        Time.timeScale = 1;
        GameMode.pro = GameProgress.Running;
        pausebutton.SetActive(true);
        playbutton.SetActive(false);
    }


    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
