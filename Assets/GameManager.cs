using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;
    bool levelLoaded = false;
    public bool obstacleHit = false;
    public float restartDelay = 1f;
    public Text restart;
    public Text picksTxt;
    public Text counterTxt;

    public PlayerMovement playerMovement;

    private int picks = 0;
    private int counter = 3;

     float timeLeft = 0.5f;

    public GameObject completeLevelUI;

    public void Start()
    {
        //PlayerMovement.startGame = true;
        
        counterTxt.text = counter.ToString();
    }

    void OnEnable(){
         SceneManager.sceneLoaded += OnSceneLoaded;
  }

    void OnSceneLoaded (Scene scene, LoadSceneMode mode) {
        PlayerMovement.startGame = false;
        levelLoaded = true;
    }

    public void CompleteLevel()
    {
        if(!obstacleHit){
            picksTxt.text = "COLETÁVEIS: " + picks.ToString();
            completeLevelUI.SetActive(true);
        }
    }

    void Update()
    {
        if(levelLoaded){
             timeLeft -= Time.deltaTime;
            if ( timeLeft < 0 )
            {
                Countdown();
            }
        }
        
        if ( Input.GetKey("r"))
        {
            Restart();
        }
        
       
    }

    public void Countdown(){
        if(!PlayerMovement.startGame){
            if(counter == 0){
                counterTxt.text = "";
                PlayerMovement.startGame = true;
                levelLoaded = false;
            }else{
                timeLeft = 0.5f;
                counterTxt.text = (counter--).ToString();
            }
        }
        
    }

    public void EndGame()
    {
        if(!gameHasEnded && obstacleHit)
        {
            gameHasEnded = true;
            picks = 0;
            restart.text = "Press R to Restart";

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void countPicks(){
        picks++;
    }
}
