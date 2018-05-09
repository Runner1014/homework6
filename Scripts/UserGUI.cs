using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserGUI : MonoBehaviour
{
    private IUserAction action;
    private float speed;
    private bool isGameOver = false;
    public Text scoreText;
    public Text gameOverText;
    public ScoreRecorder sR { get; set; }

    void Start()
    {
        action = SSDirector.getInstance().currentSceneController as IUserAction;
        speed = 10;
        //sR = Singleton<ScoreRecorder>.Instance;//获取计分员单例
        sR = ScoreRecorder.getInstance();
    }

    void Update()
    {
        if (isGameOver)
        {//显示结束游戏
            gameOverText.text = "Game Over!";
            return;
        }
        isGameOver = action.getGameOver();//检查游戏是否结束
        //scoreText.text = "Score: " + sR.getScore();//显示分数
    }

}