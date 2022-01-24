using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagement : MonoBehaviour
{

    void LateUpdate()
    {
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);
    }
}
