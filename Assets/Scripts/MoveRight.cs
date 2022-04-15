using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    private float positionDestroyX = 20.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (transform.position.x > positionDestroyX)
        {
            Destroy(gameObject);
        }
    }
}
