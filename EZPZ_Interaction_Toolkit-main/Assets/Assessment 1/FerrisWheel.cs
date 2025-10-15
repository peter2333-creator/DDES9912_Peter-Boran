using System;
using UnityEngine;

public class FerrisWheel : MonoBehaviour
{
    public float speed = 5;
    public int level = 0;
    public bool started;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            var real = speed * level;
            transform.Rotate(Vector3.up, real * Time.deltaTime);
        }
    }

    public void OnFasterClick()
    {
        level += 1;
        if (level >= 3)
        {
            level = 3;
        }
    }
    public void OnSlowerClick()
    {
        level -= 1;
        if (level <= 1)
        {
            level = 1;
        }
    }
    public void OnStartClick()
    {
        started = true;
    }

    internal void OnStopClick()
    {
        started = false;
    }
}
