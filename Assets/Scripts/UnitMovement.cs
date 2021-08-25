using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public bool shouldMove;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        shouldMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if(shouldMove)
        {
            transform.Translate(-transform.forward * speed * Time.deltaTime);
        }
    }
}
