using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [03/26/2024]
 * [The client component that allows the user to interact with the demo]
 */

public class ClientStrategy : MonoBehaviour
{
    //drone game object
    private GameObject drone;

    //list of unique drone manuevers
    private List<IManueverBehavior> components = new List<IManueverBehavior>();

    /// <summary>
    /// Spawns a drone within a random unit sphere distance
    /// </summary>
    private void SpawnDrone()
    {
        //initialize the drone gameobject to a primitive cube
        drone = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //add the drone script to the drone gameobject
        drone.AddComponent<Drone>();

        //set the drones position to a random location within a random unit sphere distance
        drone.transform.position = Random.insideUnitSphere * 10;

        //apply a random strategy to the drone on spawn
        ApplyRandomStrategy();
    }

    /// <summary>
    /// Applies a random strategy/manuever to a drone on spawn
    /// </summary>
    private void ApplyRandomStrategy()
    {
        //add the various drone manuevers to the components list
        components.Add(drone.AddComponent<WeavingManuever>());
        components.Add(drone.AddComponent<BoppingManuever>());
        components.Add(drone.AddComponent<FallbackManuever>());

        //initilize a random index to a random components list element index
        int index = Random.Range(0, components.Count);

        //Apply the random strategy/manuever to the drone from the list of manuevers
        drone.GetComponent<Drone>().ApplyStrategy(components[index]);
    }

    /// <summary>
    /// TESTING PURPOSES ONLY ( DO NOT USE IN PRODUCTION CODE ) EXTREMELY INEFFICIENT
    /// </summary>
    private void OnGUI()
    {
        //create a button to spawn a drone
        if(GUILayout.Button("Spawn Drone"))
        {
            //if pressed spawn a drone with a random strategy/manuever applied to it
            SpawnDrone();
        }
    }
}
