using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Niantic.ARDK.Utilities.Input.Legacy;

public class PlayButton : MonoBehaviour
{
    public Button playButton;
    public GameManager gameManager;
  

    public int level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   
    public void SetLevel(int level)
    {
        Debug.Log(this.gameObject.name + "Play was clicked");
        gameManager.StartGame(level);
    }

}
