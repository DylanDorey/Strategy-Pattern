using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [03/26/2024]
 * [A drone manuever that moves the object away from the player over time]
 */

public class FallbackManuever : MonoBehaviour, IManueverBehavior
{
    /// <summary>
    /// Sets the manuever/strategy to the Fallback manuever
    /// </summary>
    /// <param name="drone"> the drone that will implement this manuever </param>
    public void Manuever(Drone drone)
    {
        //start the fallback manuever
        StartCoroutine(Fallback(drone));
    }

    /// <summary>
    /// Makes the drone move back over a certain amount of time
    /// </summary>
    /// <param name="drone"> the drone that will implement this behavior </param>
    /// <returns> 1 frame between the lerping positions </returns>
    IEnumerator Fallback(Drone drone)
    {
        //create a time and speed variable for the fallback manuever
        float time = 0;
        float speed = drone.speed;

        //set the desired fallback positions for the drone to move from and to
        Vector3 startPosition = drone.transform.position;
        Vector3 endPosition = startPosition;

        //set the end position to the max fallback distance (z position) that the drone can move to
        endPosition.z = drone.fallbackDistance;

        //while the elapsed time is less than the drones speed
        while (time < speed)
        {
            //lerp between the start and end position
            drone.transform.position = Vector3.Lerp(startPosition, endPosition, time / speed);
            time += Time.deltaTime;

            //wait one frame and repeat the process until the time is greater than the speed
            yield return null;
        }
    }
}
