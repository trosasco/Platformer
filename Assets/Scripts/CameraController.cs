using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x + (Time.deltaTime * 2);
        Vector3 newPos = new Vector3(x,transform.position.y, transform.position.z);
        transform.position = newPos;
    }
}
