using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public enum GameProgress
{
    Start,
    Running,
    GameOver
}
public class GameMode:MonoBehaviour
{
    public bool Died = false;
    public int Score = 0;
    public float Height = 0;
    public bool Victory = false;

    public Text SCORE;
    public Text FinalScore;

    public GameObject GameOverUI;
    public GameObject VictoryUI;
    public GameObject StartUI;
    public GameObject RunningUI;
    public GameObject Joystickgroup;



    public static GameProgress pro;
    private void Start()
    {

        Score = 0;
        Height = 0;
        pro = GameProgress.Start;
        Time.timeScale = 0;
    }

    private void Update()
    {
        switch (pro)
        {
            case GameProgress.Start:
                {
                    GameStart();
                    break;
                }
            case GameProgress.Running:
                {
                    if (!Died && !Victory)
                        break;
                    else
                    {
                        Debug.Log("GameOver");
                        pro = GameProgress.GameOver;
                        break;
                    }
                }
            case GameProgress.GameOver:
                {
                    RunningUI.SetActive(false);
                    Invoke("GameOver", 3f);
                    if (Victory)
                    {
                        VictoryUI.SetActive(true);
                        FinalScore.text = "YOUR SCORE:" + Score;
                    }
                    if (Died)
                    {
                        GameOverUI.SetActive(true);
                    }
                    break;
                }
        }
    }

    public void GameStart()
    {
        if (/*Input.GetTouch(0).phase == TouchPhase.Began || */Input.anyKeyDown)
        {
            Time.timeScale = 1;
            pro = GameProgress.Running;
            StartUI.SetActive(false);
            RunningUI.SetActive(true);
#if UNITY_ANDROID
            Joystickgroup.SetActive(true);
#endif

        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
    }


}