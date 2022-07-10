using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetUI : MonoBehaviour
{
    [SerializeField] public Rigidbody targetRb;
    public GameManager gameManager;

    // private float minSpeed = 12;
    // private float maxSpeed = 16;
    // private float maxTorque = 10;
    // private float xRange = 1;
    // private float ySpawnPos = 1;
    // private float zRange = 0;

    public bool isGameActive;

    // public int pointValue; // must be aligned with Elias typing!!

    private void Awake()
    {
        isGameActive = true;
    }


    // Start is called before the first frame update
    void Start()
    {

        // gameManagerTEST = GameObject.Find("GameMangerTest").GetComponent<GameManagerTest>();
        // targetRb.AddForce(RandomForce(), ForceMode.Impulse); // add upwards force
        // targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse); // apply rotation on objects, might not be needed

        targetRb = GetComponent<Rigidbody>(); // get GlimmWimm
        //transform.position = RandomSpawnPos(); // spawn GlimmWimms

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {

        if(gameManager)
        {
            Destroy(gameObject);
            // gameManagerTEST.UpdateScore(pointValue);
            Debug.Log("click");

        }
    }

    /*
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);         
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, zRange);
    }
    */
}
