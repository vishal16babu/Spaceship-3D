using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{

    //Spawning the hazards in our game
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait; //To hold our wait time value
    public float startWait; // For the player to get ready
    public float waveWait; // for the wave of hazard wave to wait before next wave
    public Text scoreText;
    public Text gameoverText;
    public Text restartText;
    private int score;
    private bool gameover, restart;

    void Start() // Unity will call this Start() function on the very first frame that this "game object" is enabled. 
    {
        gameover = false;
        restart = false;
        restartText.text = "";
        gameoverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            Application.LoadLevel(Application.loadedLevel);
            //if (Input.GetKeyDown(KeyCode.R))
            // {
            //   Application.LoadLevel(Application.loadedLevel);
            //}
        }
    }
    IEnumerator SpawnWaves() //to instantiate our hazards-This is function is coroutine
    {
        yield return new WaitForSeconds(startWait); //Short pause for the player to get ready and prepare for action.. :)
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
                AddScore(1);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameover)
            {
                //restartText.text = "Press 'r' for Restart";
                restartText.text = "Restarting hang on... :)";
                restart = true;
                break;
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    public void Gameover()
    {
        gameoverText.text = "Game Over :P";
        gameover = true;
    }
}
