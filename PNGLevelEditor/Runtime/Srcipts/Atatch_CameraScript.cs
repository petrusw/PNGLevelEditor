using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atatch_CameraScript : MonoBehaviour
{
    public MovePlayer movePlayerScript;
    // Start is called before the first frame update
    void Start()
    {
        if(movePlayerScript._camera == null)
        {
            movePlayerScript._camera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
