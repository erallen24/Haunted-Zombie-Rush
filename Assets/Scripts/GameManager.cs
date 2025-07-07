using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject scoreBox;
    [SerializeField] private Text scoreText;

    private int score = 0;

    public static GameManager instance = null;

    private bool playerActive = false;
    private bool gameOver = false;
    private bool gameStarted = false;
    

    public bool PlayerActive
    {
        get { return playerActive;}
    }
    public bool GameOver
    {
        get { return gameOver;}
    }
    public bool GameStarted
    {
        get { return gameStarted;}
    }

    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad (gameObject);

        Assert.IsNotNull (mainMenu);
    }

    // Start is called before the first frame update
    void Start()
    {
      scoreText.text = "Score: " + score++;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerCollided()
    {
        gameOver = true;
        gameOverText.SetActive (true);  
    }

    public void PlayerStartedGame()
    {
        playerActive = true;
    }

    public void EnterGame ()
    {
        mainMenu.SetActive (false);
        scoreBox.SetActive (true);
        gameStarted = true;
    }

    public void Replay ()
    {
        gameOverText.SetActive (false);
        
    }

    public void AddPoint()
    {
        scoreText.text = "Score: " + score++;
        Debug.Log("point");
    }
}
