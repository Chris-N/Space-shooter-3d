using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionSpin : MonoBehaviour
{
    [SerializeField] float angle = 10.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, angle * Time.deltaTime);
    }
}
