using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 3.0f;
    private float positionDestroyY = -0.5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y < positionDestroyY)
        {
            Destroy(gameObject);
        }
    }
}
