using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);
    }
}
