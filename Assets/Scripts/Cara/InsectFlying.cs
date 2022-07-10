using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is meant to be attached to a flying object (especially if flying insect type movement is desired)
/// The the speed for each segment is randomized between a min and max
/// The targets are randomly generated within serialized parameters
/// Targets change when reached, and randomly before being reached
/// 
/// </summary>
///

public class InsectFlying : MonoBehaviour
{
    [SerializeField] List<Vector3> targets = new List<Vector3>();

    [SerializeField] private float m_minSpeed;
    [SerializeField] private float m_maxSpeed;
    // Number of targets
    [SerializeField] private int m_minTargets;
    [SerializeField] private int m_maxTargets;
    // Boundaries of targets
    [SerializeField] private int m_minX;
    [SerializeField] private int m_maxX;
    [SerializeField] private int m_minY;
    [SerializeField] private int m_maxY;
    [SerializeField] private int m_minZ;
    [SerializeField] private int m_maxZ;
    // Odds of redirecting before reaching target (max range of random number generation)
    [SerializeField] private int m_redirectOdds;

    private Vector3 m_currentTarget;
    private float m_currentSpeed;

    void Start()
    {

        if (targets.Count == 0)
        {
            GenerateRandomTargets(Random.Range(3, 7));
        }

        // If this game object has a Rigidbody, set it to kinematic (or it will drop like a rock - this is all animation without physics)

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        // set the target and speed to the first elements in each list
        m_currentTarget = targets[0];
        m_currentSpeed = Random.Range(m_minSpeed, m_maxSpeed);

        // place the object at the last position in the list
        transform.position = targets[targets.Count - 1];
    }


    // Update is called once per frame
    void Update()
    {
        // check to see if the object has reached the target
        if (Vector3.Distance(gameObject.transform.position, m_currentTarget) < 0.1f)
        {
            // Target reached - change to next target in list
            GoToNextTarget();
        }

        else
        {
            // Target not reached - find out if we move closer or change direction
            if (Random.Range(0, m_redirectOdds) == 0)
            {
                // Redirect to different target
                GoToNextTarget();
            }
            else
            {
                MoveTowardTarget();
            }
        }

    }
    private void GoToNextTarget()
    {

        // Update the target and speed to random values
        m_currentTarget = targets[Random.Range(0, targets.Count)];
        m_currentSpeed = Random.Range(m_minSpeed, m_maxSpeed);

    }

    private void MoveTowardTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, m_currentTarget, m_currentSpeed * Time.deltaTime);
    }


    private void GenerateRandomTargets(int targetCount)
    {
        for (int i = 0; i < targetCount; i++)
        {
            targets.Add(GenerateRandomTarget());
        }
    }

    private Vector3 GenerateRandomTarget()
    {
        float x = Random.Range(m_minX, m_maxX);
        float y = Random.Range(m_minY, m_maxY);
        float z = Random.Range(m_minZ, m_maxZ);

        return new Vector3(x, y, z);
    }
}
