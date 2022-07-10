using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsControl : MonoBehaviour
{
    [SerializeField]
    private GameObject [] glimmWimmPrefab;

    // queue which holds reference to all the gameObjects
    [SerializeField]
    List<GameObject> glimmWimmPool = new List<GameObject>();

    // optional parameter, which helps to preload the object pool
    [SerializeField]
    //private int poolStartSize = 5;
    private int poolMaxSize = 5;

    [SerializeField] private float timeToSpawn = 5f;
    private float timeSinceSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn >= timeToSpawn)
        {
            int glimmWimmPrefabIndex = Random.Range(0, glimmWimmPrefab.Length);

            GameObject glimmWimm = Instantiate(glimmWimmPrefab[glimmWimmPrefabIndex]);

            glimmWimm.transform.position = this.transform.position;
            glimmWimmPool.Add(glimmWimm);
            timeSinceSpawn = 0f;
        }

        /*for(int i = 0; i < glimmWimmPool.Count; i++)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    //Select stage    
                    if (hit.transform == glimmWimmPool[i].transform)
                    {
                        //SceneManager.LoadScene("SceneTwo");
                        Destroy(glimmWimmPool[i]);
                        glimmWimmPool.Remove(glimmWimmPool[i]);
                        print("detect" + i);
                    }
                }
            }
        }*/
    }
}
