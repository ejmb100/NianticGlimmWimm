using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;//allows to save data
using UnityEngine.SceneManagement; // allows sceneSwitch

public class GameManager : MonoBehaviour
{
    public static GameManager s_instance;

    [SerializeField] private TextMeshProUGUI m_highScoreText;
    [SerializeField] private TextMeshProUGUI m_currentScoreText;

    private int m_currentScore;
    private int m_highScore;
    public string m_scoreKey = "HighScore";//used in player prefs approach?
    public List<Vector3> positionList;

    public GameObject rewardLevel1;
    public GameObject rewardLevel2;
    public GameObject rewardLevel3;
    public GameObject rewardLevel4;

    // added for play and screenSwitch
    public GameObject entranceCanvas;
    bool isGameActive;
    private float spawnRate;

    // added for CountDownTimer
    public int NextSceneToLoad;


    public float timer = 3f;
    public TMP_Text timerSeconds;


    public void AddScore(int points)
    {
        m_currentScore += points;
        m_currentScoreText.text = m_currentScore.ToString();

        if (m_currentScore > m_highScore)
        {
            m_highScore = m_currentScore;
            m_highScoreText.text = m_highScore.ToString();
        }

        if (m_currentScore > 40)
        {
            Instantiate(rewardLevel1);// need to place in view
            Debug.Log("rewardLevel1 achieved");
        }

        else if (m_currentScore > 60)
        {
            Instantiate(rewardLevel2);// need to place in view
            Debug.Log("rewardLevel2 achieved");
        }

        else if (m_currentScore > 70)
        {
            Instantiate(rewardLevel3);// need to place in view
            Debug.Log("rewardLevel3 achieved");
        }

        else if (m_currentScore > 80)
        {
            Instantiate(rewardLevel4);// need to place in view
        }


    }

    void Awake()
    {
        isGameActive = true; // added for playButton

        if (s_instance == null)
        {
            s_instance = this;
        }
        else
        {
            Debug.LogError("mltiple singleton instances!");
        }

        //if (File.Exists(Application.dataPath + "/SaveData.json"))



        if (PlayerPrefs.HasKey(m_scoreKey))//if  using Playerprefs use this line. player prefs  when thhiings get more complicated
        {
            m_highScore = PlayerPrefs.GetInt(m_scoreKey);
            //m_highScore = 0;
            //string json = File.ReadAllText(Application.dataPath + "/SaveData.json");//reads text file
            //SaveData data = JsonUtility.FromJson<SaveData>(json);//convert back from jason to data variablee

            //m_highScore = int.Parse(data.highScore);
            //m_highScoreText.text =  m_highScore.ToString();

        }
        else
        {
            m_highScore = 0;

        }
        m_highScoreText.text = m_highScore.ToString();
    }

    // added for CountDownTimer
    void Update()
    {
        timer -= Time.deltaTime;
        timerSeconds.text = timer.ToString("f2");
        if (timer <= 0)
        {
            SceneManager.LoadScene(NextSceneToLoad);
            PlayerPrefs.SetInt(m_scoreKey, m_highScore);

            /*
            if (m_currentScore >= m_highScore)
            {
                m_highScore = m_currentScore;
                PlayerPrefs.SetInt(m_scoreKey, m_highScore);
                //SaveData data = new SaveData();//gets refeerence to the class
                //data.highScore = m_highScore.ToString();//assigns value
                //string json = JsonUtility.ToJson(data);//converts data into jason format..ovnverts to string
                //File.WriteAllText(Application.dataPath + "/SaveData.json", json);//strng gets written to file
            }
            */

        }
    }

    // added for playButton -> wait one second until GlimmWimms show up
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
        }
    }

    // added to start Game
    public void StartGame(int level)
    {
        isGameActive = true;
        spawnRate /= level;

        StartCoroutine(SpawnTarget());

        entranceCanvas.gameObject.SetActive(false);

        SceneManager.LoadScene(level);
    }

    private void OnApplicationQuit()
    {
        if (m_currentScore >= m_highScore)
        {
            m_highScore = m_currentScore;
            PlayerPrefs.SetInt(m_scoreKey, m_highScore);

            //SaveData data = new SaveData();//gets refeerence to the class
            //data.highScore = m_highScore.ToString();//assigns value
            //string json = JsonUtility.ToJson(data);//converts data into jason format..ovnverts to string
            //File.WriteAllText(Application.dataPath + "/SaveData.json", json);//strng gets written to file
        }
    }
}
