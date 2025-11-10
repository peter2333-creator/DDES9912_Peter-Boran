using TMPro;
using UnityEngine;

public class ConsoleBoard : MonoBehaviour
{
    public FerrisWheel m_well;
    public TextMeshPro m_speedText;
    public AudioSource m_audio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                switch (hit.collider.tag)
                {
                    case "Start":
                        m_well.OnStartClick();
                        m_audio.Play();
                        break;
                    case "Faster":
                        m_well.OnFasterClick();
                        break;
                    case "Slower":
                        m_well.OnSlowerClick();
                        break;
                    case "Stop":
                        m_well.OnStopClick();
                        m_audio.Stop();
                        break;
                    default:
                        break;
                }
                m_speedText.text = m_well.level.ToString();
            }
        }
    }
}
