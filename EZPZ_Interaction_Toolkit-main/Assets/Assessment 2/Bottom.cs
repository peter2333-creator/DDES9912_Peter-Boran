using UnityEngine;

public class Bottom : MonoBehaviour
{
    public Transform door1;
    public Transform door2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Step"))
        {
            openDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Step"))
        {
            closeDoor();
        }
    }

    public void openDoor()
    {
        door1.localEulerAngles = new Vector3(0, -90, 0);
        door2.localEulerAngles = new Vector3(0, 90, 0);
    }
    public void closeDoor()
    {
        door1.localEulerAngles = new Vector3(0, 0, 0);
        door2.localEulerAngles = new Vector3(0, 0, 0);
    }
}
