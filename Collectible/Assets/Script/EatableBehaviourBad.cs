using UnityEngine;

public class EatableBehaviourBad : MonoBehaviour
{
    public GameObject player;
    public float rotationSpeed = 100f;
    public float moveSpeed = 2.5f;

    private Vector3 playerPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Assert(player != null);
        playerPoint = player.transform.position; // transform is by reference, vector3 is by value (copy)
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPoint, moveSpeed * Time.deltaTime);
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
