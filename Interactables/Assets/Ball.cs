using UnityEngine;

public class Ball : MonoBehaviour, Interactables
{
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    public void FallDown()
    {
        rb.useGravity = false;
    }
  
    public void Interact()
    {
        FallDown();
    }
}
