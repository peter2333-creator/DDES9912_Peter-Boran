using System;
using UnityEngine;

public class FerrisWheel : MonoBehaviour
{
    public float speed = 1;
    public int level = 0;
    public bool started;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (started)
        {
            var real = speed + level*0.5f;
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
        var cols = gameObject.GetComponentsInChildren<House>();
        foreach (House house in cols) {
            house.LighingOn();
        }
    }

    internal void OnStopClick()
    {
        started = false;
        var cols = gameObject.GetComponentsInChildren<House>();
        foreach (House house in cols)
        {
            house.LighingOff();
        }
    }
}
