using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor2 : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 tmpOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 3.0f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);

	// Use this for initialization
	void Start ()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        moveVector = lookAt.position + new Vector3(startOffset.x, 3.5f, startOffset.z);

        moveVector.x = 0;

        moveVector.y = Mathf.Clamp((moveVector.y),1,2);

        transform.position = moveVector;

        if (transition > 1.0f)
        {
            transform.position = new Vector3(moveVector.x, 3.5f, moveVector.z);
        }
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        }
	}
}
