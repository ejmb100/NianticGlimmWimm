using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Niantic.ARDK.Utilities.Input.Legacy;

public class EarnPointsTesting : MonoBehaviour
{
    [SerializeField] public int pointsAssigned;



    Ray ray;
    RaycastHit hit;

    // Update is called once per frame


    /*public void OnClick()
    {
        GameManager.s_instance.AddScore(pointsAssigned);
        
        Destroy(gameObject);
        //Debug.Log("points granted" + pointsAssigned);
    }*/
    void Update()
    {
        if (PlatformAgnosticInput.touchCount <= 0) { return; }

        var touch = PlatformAgnosticInput.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "FireFly")
                    

                GameManager.s_instance.AddScore(pointsAssigned);
                Debug.Log("points granted" + pointsAssigned);


            }
        }
    }
}


