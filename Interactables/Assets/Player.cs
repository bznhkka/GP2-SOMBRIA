using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera m_Camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // stores raycast game object
        GameObject nearestGameOBJ = NearestGameObject();
        Debug.Log(nearestGameOBJ);
        if (nearestGameOBJ == null) return;
        if (Input.GetButtonDown("Fire1"))
        {
            var interactOBJ = nearestGameOBJ.GetComponent<Interactables>();
            if (interactOBJ == null) return;
            interactOBJ.Interact();
        }
    }
    private GameObject NearestGameObject()
    {
        // creates a ray on camera origin

        GameObject result = null;
        var ray =
            m_Camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, 4f))
        {
            result = hit.transform.gameObject;
        }
        return result;
    }
}
