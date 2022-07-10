using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private float timeToSpawn = 5f;
    private float timeSinceSpawn;
    private ObjectPool_Simple objectPool;
    

    // Start is called before the first frame update
    void Start()
    {
        objectPool = FindObjectOfType<ObjectPool_Simple>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn >= timeToSpawn)
        {
            GameObject newGlimmWimmm = objectPool.GetGlimmWimm();
            newGlimmWimmm.transform.position = this.transform.position;
            timeSinceSpawn = 0f;
        }
    }

    private void LightOff()
    {
        // glimmWimm turns off
        

    }
    /*
    IEnumerator turnGlimmWimmOff(GameObject glimmWimm)
    {
        // WaitForSeconds
        // depending on level turn glimm on/off
       
    }
    */
}
