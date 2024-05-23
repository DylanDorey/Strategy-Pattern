using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [03/26/2024]
 * [A drone manuever that moves the object up and down over time]
 */

public class BoppingManuever : MonoBehaviour, IManueverBehavior
{
    /// <summary>
    /// Sets the manuever/strategy to the Bopping manuever
    /// </summary>
    /// <param name="drone"> the drone that will implement this manuever </param>
    public void Manuever(Drone drone)
    {
        //start the bopple manuever
        StartCoroutine(Bopple(drone));
    }

    /// <summary>
    /// Makes the drone move up and down over time
    /// </summary>
    /// <param name="drone"> the drone that will implement this behavior </param>
    /// <returns> the time before switching bopple directions </returns>
    IEnumerator Bopple(Drone drone)
    {
        //create a time, reversed, and speed variable for the bopple manuever
        float time;
        bool isReversed = false;
        float speed = drone.speed;

        //set the desired bopple positions for the drone to move between
        Vector3 startPosition = drone.transform.position;
        Vector3 endPosition = startPosition;

        //set the end position to the max height (y position) that the drone can move to
        endPosition.y = drone.maxHeight;

        while(true)
        {
            //initialize the time, start, and end position of the drone
            time = 0f;
            Vector3 start = drone.transform.position;
            Vector3 end = (isReversed) ? startPosition : endPosition;

            //while the elapsed time is less than the drones speed
            while (time < speed)
            {
                //lerp between the start and end position
                drone.transform.position = Vector3.Lerp(start, end, time / speed);
                time += Time.deltaTime;

                //wait one frame and repeat the process until the time is greater than the speed
                yield return null;
            }

            //once reached, wait one second then flip the movement direction
            yield return new WaitForSeconds(1f);
            isReversed = !isReversed;
        }
    }
}
