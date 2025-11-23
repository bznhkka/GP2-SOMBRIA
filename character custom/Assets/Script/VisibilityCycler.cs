using UnityEngine;

public class VisibilityCycler : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    private int index = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetVisibilities();
    }

    public void CycleNext()
    {
        index++;
        Debug.Log($"index before modulo = {index}");
        index %= objects.Length;
        Debug.Log($"objects.Length = {objects.Length}");
        Debug.Log($"index after modulo with {objects.Length} = {index}");
        SetVisibilities();
    }

    void SetVisibilities()
    {
        foreach (GameObject selectedObject in objects)
        {
            selectedObject.SetActive(false);
        }
        objects[index].SetActive(true);
    }

    // public void CyclePrev()
    // {
    //     index--;
    //     if(index < 0)
    //     {
    //         index = objects.Length - 1;
    //     }
    // }
}
