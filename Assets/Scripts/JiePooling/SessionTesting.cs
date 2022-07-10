using System.Collections;
using System.Collections.Generic;
using Niantic.ARDK.AR;
using Niantic.ARDK.AR.ARSessionEventArgs;
using Niantic.ARDK.Extensions;
using UnityEngine;

public class SessionTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ARSessionFactory.SessionInitialized += TestSession;

    }

    void TestSession(AnyARSessionInitializedArgs args)
    {
        Debug.Log("Session has started");
    }

}