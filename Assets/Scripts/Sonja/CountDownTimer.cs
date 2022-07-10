using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    public int HighScoreScene;
    public GameManager gameManager;

    public float timer = 3f;
    [SerializeField] public TextMeshProUGUI timerSeconds;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerSeconds.text = "Timer" + timer.ToString("f2");
        if(timer <= 0)
        {
            SceneManager.LoadScene(HighScoreScene);

        }

    }
}
