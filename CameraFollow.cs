using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class CameraFollow : MonoBehaviour
// {
//     public Transform playerTransform;

//     // Start is called before the first frame update
//     void Start()
//     {
//         playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
//     }

//     // Update is called once per frame
//     void LateUpdate()
//     {
//         //store cureent camera's position in variable temp
//         Vector3 temp = transform.position;

//         //set camera's position x = player's position x
//         temp.x = playerTransform.position.x;

//         //set camera's temp position to camera's position
//         transform.position = temp;
//     }
// }

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerTransform != null)
        {
            Vector3 temp = transform.position;

            temp.x = playerTransform.position.x;

            transform.position = temp;
        }
        else
        {
            GetPlayer();
        }
    }

    private void GetPlayer()
    {
        playerTransform = LevelManager.player.transform; // get it from the level manager
    }
}
