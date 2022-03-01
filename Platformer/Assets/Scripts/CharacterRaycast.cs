using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRaycast : MonoBehaviour
{
    public UIManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag != "rock")
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, Vector3.up);
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider != null)
                {
                    GameObject block = hit.collider.gameObject;
                    if(block.tag == "question") {
                        manager.addCoins(1);
                    }
                    else if(block.tag == "brick") {
                        Destroy(block);
                        manager.addScore(100);
                    }
                }
            }

            if(collision.gameObject.tag == "lava") {
                Destroy(gameObject);
                Debug.Log("Player died in lava! Game over.");
            }

            if(collision.gameObject.tag == "goal") {
                Debug.Log("Player cleared the level! Congratulations!");
            }
        }
    }

}
