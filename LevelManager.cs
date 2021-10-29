using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class LevelManager : MonoBehaviour
// {
//     public static LevelManager instance;
//     public static CameraFollow cameraFollow;

//     public Transform respawnPoint;
//     public GameObject playerPrefab;

//     public Camera cam;

//     private void Awake()
//     {
//         if(instance == null)
//         {
//         instance = this;
//         }
//         else
//         {
//             Destroy(gameObject);
//         }
//     }

//     public void Respawn()
//     {
//         var newPlayer = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
//         cameraFollow.playerTransform = newPlayer.transform;
//     }
// }

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public CameraFollow cameraFollow;

    public Transform respawnPoint;
    public GameObject playerPrefab;

    public Camera cam;

    // assign first player game object
    public static GameObject player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Respawn()
    {
        // assign instantiated player object
        player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
    }
}
