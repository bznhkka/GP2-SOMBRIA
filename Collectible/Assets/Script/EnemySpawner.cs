using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Assert(enemyPrefab != null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
