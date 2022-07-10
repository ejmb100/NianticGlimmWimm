using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManagerTest : MonoBehaviour
{
    //public List<GameObject> targets;
    // scoreText
    // gameOverText
    // public Button restartButton;
    public GameObject entranceCanvas;

    bool isGameActive;

    // private int score;
    private float spawnRate = 1.0f;

    private void Awake()
    {
        isGameActive = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate); // controls time between spawns
            //int index = Random.Range(0, targets.Count); // get random object from list
            //Instantiate(targets[index]);            
        }
    }

    /*

    public void GameOver()
    {
        // restartButton.gameObject.SetActive(true);
        // gameOverText.gameObject.SetActive(true);
        // isGameActive(false);
    }

    
    public void RestartGame()
    {
        
    }
    */

    public void StartGame(int level)
    {
        isGameActive = true;
        // score = 0;
        spawnRate /= level;

        StartCoroutine(SpawnTarget());

        entranceCanvas.gameObject.SetActive(false);

        SceneManager.LoadScene(level);
    }
}
