using UnityEngine;

public class lampLight : MonoBehaviour, Interactables
{
    public GameObject lightSource;

  public void Switch()
    {
    lightSource.SetActive(false); 
    }

  public void Interact()
    {
        Switch();
    }
}
