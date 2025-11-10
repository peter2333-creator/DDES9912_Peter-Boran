using System.Collections;
using UnityEngine;

public class House : MonoBehaviour
{
    Light mLight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mLight = GetComponentInChildren<Light>();
        mLight.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        transform.up = Vector3.up;
    }


    public void LighingOn()
    {
        mLight.gameObject.SetActive(true);
    }
    public void LighingOff()
    {
        mLight.gameObject.SetActive(false);
    }
}
