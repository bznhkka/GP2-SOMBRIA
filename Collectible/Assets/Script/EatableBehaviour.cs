using UnityEngine;

public class EatableBehaviour : MonoBehaviour
{
    public GameObject player;
    public float rotationSpeed = 100f;
    public float moveSpeed = 2.5f;

    private Vector3 playerPointUnitVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
        }
        Debug.Assert(player != null);
        playerPointUnitVector = (player.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += playerPointUnitVector * moveSpeed * Time.deltaTime;
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
