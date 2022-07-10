using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GlimmWimmReturn : MonoBehaviour
{
    private ObjectPool_Simple objectPool;

    // Start is called before the first frame update
    void Start()
    {
        objectPool = FindObjectOfType<ObjectPool_Simple>();
    }

    // Update is called once per frame
    void Update()
    {
        if(objectPool != null)
        {
            objectPool.ReturnGlimmWimm(this.gameObject);
        }
    }
}
