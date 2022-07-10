using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Niantic.ARDK.Utilities.Input.Legacy;

public class EarnPoints : MonoBehaviour
{
    [SerializeField] public int pointsAssigned;

    public ParticleSystem m_explosionParticle;

    Ray ray;
    RaycastHit hit;

    // Update is called once per frame

    public void OnClick()
    {

        GameManager.s_instance.AddScore(pointsAssigned);
        GameManager.s_instance.positionList.Add(transform.position);


        Instantiate(m_explosionParticle, transform.position, m_explosionParticle.transform.rotation);
        Destroy(gameObject);
 
        
      
    }

    // or leverag raycast

    /*public void ExplodeOnRay()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "FireFly")

                print(hit.collider.name);
            Instantiate(m_explosionParticle, transform.position, m_explosionParticle.transform.rotation);
            Destroy(gameObject);

            print(hit.collider.name);

            GameManager.s_instance.AddScore(pointsAssigned);
            Debug.Log("points granted" + pointsAssigned);
        }
    }*/
}


