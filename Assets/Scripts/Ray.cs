using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ray : MonoBehaviour
{
    public float maxDistance;
    public TextMeshProUGUI noteText;
    public GameObject candle;
    public GameObject text1;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            text1.SetActive(false);
        }
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance))
        {
            Debug.DrawRay(this.transform.position, transform.TransformDirection(Vector3.forward) * maxDistance);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.transform.CompareTag("Candle"))
                {
                    hit.transform.gameObject.SetActive(false);
                    candle.SetActive(true);
                }
                if (hit.transform.CompareTag("Door"))
                {
                    Animator doorAnimator = hit.transform.GetComponent<Animator>();
                    AudioSource doorAudio = hit.transform.GetComponent<AudioSource>();
                    doorAudio.Play();
                    doorAnimator.SetBool("DoorClosed", !doorAnimator.GetBool("DoorClosed"));
                }
                if (hit.transform.CompareTag("Text"))
                {
                    text1.SetActive(true);
                    noteText.text = hit.transform.GetComponent<Notes>().note;
                }
                if (hit.transform.CompareTag("FuseBox"))
                {
                    Animator fuseAnimator = hit.transform.GetComponent<Animator>();
                    fuseAnimator.SetBool("FuseClosed", !fuseAnimator.GetBool("FuseClosed"));
                }
            }
        }
    }
}
