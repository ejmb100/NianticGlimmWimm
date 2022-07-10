using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool_Simple : MonoBehaviour
{
    // prefab that's goona be pooled
    [SerializeField]
    private GameObject glimmWimmPrefab;

    // queue which holds reference to all the gameObjects
    [SerializeField]
    Queue<GameObject> glimmWimmPool = new Queue<GameObject>();

    // optional parameter, which helps to preload the object pool
    [SerializeField]
    private int poolStartSize = 5;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poolStartSize; i++)
        {
            GameObject glimmWimm = Instantiate(glimmWimmPrefab);
            glimmWimmPool.Enqueue(glimmWimm);
            glimmWimm.SetActive(false);

        }
    }

    // check if there are any glimmWimms in the pool
    // if there are, will dequeue this glimmWimm, set it toactive and return this glimmWimm
    // if it's empty, it creates new

    public GameObject GetGlimmWimm()
    {
        if(glimmWimmPool.Count > 0)
        {
            GameObject glimmWimm = glimmWimmPool.Dequeue();
            glimmWimm.SetActive(true);
            return glimmWimm;
        }
        else
        {
            GameObject glimmWimm = Instantiate(glimmWimmPrefab);
            return glimmWimm;
        }
               
    }

    // Return glimmWimm back to scene
    public void ReturnGlimmWimm(GameObject glimmWimm)
    {
        glimmWimmPool.Enqueue(glimmWimm);
        glimmWimm.SetActive(false);
    }
}
