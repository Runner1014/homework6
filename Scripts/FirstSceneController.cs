using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneController : MonoBehaviour, ISceneController, IUserAction
{
    public GameObject player;
    public List<GameObject> monsters;
    public PatrolFactory mF;
    private bool isGameOver = false;
    private bool isJump = true;

    void Awake()
    {
        SSDirector director = SSDirector.getInstance();
        director.currentSceneController = this;
        LoadResources();
    }

    void Start()
    {
        mF = Singleton<PatrolFactory>.Instance;
        monsters = mF.getPatrols();
        PatrolController.hitPlayerEvent += gameOver;
    }

    public bool getGameOver()
    {
        return isGameOver;
    }

    public void gameOver()
    {
        //player.GetComponent<Animator>().SetTrigger("death");
        player.GetComponent<Rigidbody>().isKinematic = true;
        this.isGameOver = true;
    }

    public void LoadResources()
    {
        player = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("UnityChan/Prefabs/for Locomotion/unitychan 1"));
        //
    }
}