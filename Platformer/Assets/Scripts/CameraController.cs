using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var charPosition = character.GetComponent<Transform>().position.x;
        if(charPosition > transform.position.x)
        {
            transform.position = new Vector3(charPosition, transform.position.y, transform.position.z);
        }
    }
}
