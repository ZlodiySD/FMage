using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Range(0,1f)]
    public float parallaxEffect;

    private GameObject camera;
    private float lenght;
    private float startPos;

    void Start()
    {
        camera = Camera.main.gameObject;

        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = (camera.transform.position.x * (1f - parallaxEffect));
        float dist = (camera.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + lenght)
            startPos += lenght;
        else if (temp < startPos - lenght)
            startPos -= lenght;
    }
}
