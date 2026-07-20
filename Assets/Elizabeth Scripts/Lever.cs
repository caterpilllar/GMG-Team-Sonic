using System;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject door;

    bool isInRange = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            door.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInRange = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
    }
}
