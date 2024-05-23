using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [03/26/2024]
 * [A drone that implements different behaviors on spawn]
 */

public class Drone : MonoBehaviour
{
    //Ray parameters
    private RaycastHit hit;
    private Vector3 rayDirection;
    private float rayAngle = -45f;
    private float rayDistance = 15f;

    //Movement parameters
    public float speed = 1f;
    public float maxHeight = 5f;
    public float weavingDistance = 1.5f;
    public float fallbackDistance = 20f;

    private void Start()
    {
        //initialize our ray
        rayDirection = transform.TransformDirection(Vector3.back) * rayDistance;
        rayDirection = Quaternion.Euler(rayAngle, 0f, 0f) * rayDirection;
    }

    private void Update()
    {
        //draw our laser
        Debug.DrawRay(transform.position, rayDirection, Color.blue);

        //if that ray hits something
        if (Physics.Raycast(transform.position, rayDirection, out hit, rayDistance))
        {
            //if it hit another collider
            if (hit.collider)
            {
                //change the ray color to green
                Debug.DrawRay(transform.position, rayDirection, Color.green);
            }
        }
    }

    /// <summary>
    /// Applies a strategy to the drone
    /// </summary>
    /// <param name="strategy"> the unique manuever/strategy </param>
    public void ApplyStrategy(IManueverBehavior strategy)
    {
        //applies the passed in manuever/strategy to this game object
        strategy.Manuever(this);
    }
}
