using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassButton : MonoBehaviour
{

    public Character pickableCharacter;

    [Header("Lerping")]
    public bool canLerp;
    public Transform lerpToTarget;
    public float moveSpeed;
    public float rotateSpeed;

    private void Update()
    {
        if (canLerp)
        {
            Lerp();
        }
    }

    public void Lerp()
    {
        transform.position = Vector3.Lerp(transform.position, lerpToTarget.position, (Time.deltaTime * moveSpeed));
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.zero), (Time.deltaTime * rotateSpeed));
    }
}
