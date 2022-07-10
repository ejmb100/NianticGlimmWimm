using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Niantic.ARDK.Utilities.Input.Legacy;

public class RaycastManager : MonoBehaviour
{
    [SerializeField] public int fireFlyPointsAssigned;
    [SerializeField] public int demonPointsAssigned;
    [SerializeField] public int beePointsAssigned;
  
    public ParticleSystem m_explosionParticle;

    public Camera _mainCamera;  //This will reference the MainCamera in the scene, so the ARDK can leverage the device camera

    Ray ray;
    RaycastHit hit;
    RaycastHit raycastHit;


    // Update is called once per frame
    void Update()
    {
        TouchBegan();
    }

    void TouchBegan()
    
        {
       
            if (PlatformAgnosticInput.touchCount <= 0) { return; }

            var touch = PlatformAgnosticInput.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {


                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))// if (hit.collider.tag == "FireFly")
                {

                if (hit.collider.CompareTag("FireFly"))
                {

                    GameManager.s_instance.AddScore(fireFlyPointsAssigned);

                    Destroy(hit.collider.gameObject);
                    //Instantiate(m_explosionParticle, transform.position, m_explosionParticle.transform.rotation);
                    Instantiate(m_explosionParticle, hit.transform.position, m_explosionParticle.transform.rotation);
                }

                if (hit.collider.CompareTag("Demon"))
                {

                    GameManager.s_instance.AddScore(demonPointsAssigned);

                    Destroy(hit.collider.gameObject);
                    //Instantiate(m_explosionParticle, transform.position, m_explosionParticle.transform.rotation);
                    Instantiate(m_explosionParticle, hit.transform.position, m_explosionParticle.transform.rotation);
                }

                if (hit.collider.CompareTag("Bee"))
                {

                    GameManager.s_instance.AddScore(beePointsAssigned);

                    Destroy(hit.collider.gameObject);
                    //Instantiate(m_explosionParticle, transform.position, m_explosionParticle.transform.rotation);
                    Instantiate(m_explosionParticle, hit.transform.position, m_explosionParticle.transform.rotation);
                }
            }
                

            }

        }
    
}
