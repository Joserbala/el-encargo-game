using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] private bool isChasing = false;
    [SerializeField] private bool stopChasing = false;
    [SerializeField] private bool hasArrivedToWaypoint = false;
    [SerializeField] private float speed = 5;
    [SerializeField] private float speedChasing = 8;
    [SerializeField] private float distanceCheck = 2;
    [SerializeField] private float distanceStop = 3;
    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private List<Vector3> waypoints;
    [SerializeField] private Rigidbody rb;

    private int currentWaypointsIndex = 0;
    private Collider[] chaseArray;
    private Collider[] detectionArray;

    public bool HasCollidedWSafeZone { get => stopChasing; set => stopChasing = value; }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceCheck);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanceStop);
    }

    private void Update()
    {
        detectionArray = Physics.OverlapSphere(transform.position, distanceCheck, playerLayerMask);
        chaseArray = Physics.OverlapSphere(transform.position, distanceStop, playerLayerMask);

        if (!isChasing && detectionArray.Length > 0 && !stopChasing)
        {
            isChasing = true;
        }
        else if (isChasing && chaseArray.Length > 0 && !stopChasing)
        {
            transform.LookAt(chaseArray[0].transform);
            transform.Translate(Vector3.forward * speedChasing * Time.deltaTime);
        }
        else
        {
            isChasing = false;
            GoToNextWaypoint();
        }
    }

    private void GoToNextWaypoint()
    {
        if (!hasArrivedToWaypoint)
        {
            transform.LookAt(waypoints[currentWaypointsIndex]);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, waypoints[currentWaypointsIndex]) < 0.5)
            {
                hasArrivedToWaypoint = true;
                stopChasing = false;
            }
        }
        else
        {
            UpdateWaypointsIndex();
            hasArrivedToWaypoint = false;
        }
    }

    private void UpdateWaypointsIndex()
    {
        if (currentWaypointsIndex < waypoints.Count - 1)
        {
            currentWaypointsIndex++;
        }
        else
        {
            currentWaypointsIndex = 0;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<ThirdPersonHandler>(out ThirdPersonHandler controller))
        {
            controller.DoDying();
            stopChasing = true;
        }
    }

    [ContextMenu("Add a waypoint here")]
    public void AddWaypoint()
    {
        waypoints.Add(transform.position);
    }
}
