using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private bool isFailed = false;
    public GameObject GameoverText;
    public GameObject ScoreUI;

    void Start()
    {
        Debug.Assert(GameoverText != null);
        Debug.Assert(ScoreUI != null);

        GameoverText.SetActive(false);

        // for(int i = 0; i < 5; i++)
        // {
        //     Debug.Log($"Debug: {i}");
        // }

        // int[] arr = {15, 58, 64, 128};
        // Debug.Log($"Debug arr.Length = {arr.Length}");
        // for(int i = 0; i < arr.Length; i++)
        // {
        // Debug.Log($"Debug arr[{i}] = {arr[i]}");
        // }
    }

    public void FailGame()
    {
        isFailed = true;
        Debug.Log("Game failed!");
        GameoverText.SetActive(true);
        // TODO: get array of "Collect" and "Enemy" game objects, iterate through each of them and destroy them

        // for(int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
        // {
        //     Destroy(GameObject.FindGameObjectsWithTag("Enemy")[i]);
        // }
        
        GameObject[] enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        int enemyArraySize = enemyArray.Length;
        for(int i = 0; i < enemyArraySize; i++)
        {
            Destroy(enemyArray[i]);
        }

        GameObject[] collectArray = GameObject.FindGameObjectsWithTag("Collect"); // I have an array of GameObject called "collectArray"
        int collectArraySize = collectArray.Length;
        for (int i = 0; i < collectArray.Length; i++)
        {
            Destroy(collectArray[i]);
        }

        // Same as below:
        // for (int i = 0; i < GameObject.FindGameObjectsWithTag("Collect").Length; i++)
        // {
        //     Destroy(GameObject.FindGameObjectsWithTag("Collect")[i]);
        // }
    }

    public void IncrementScore()
    {
        score++;

        Debug.Log($"Game score currently at {score}!");
        ScoreUI.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}
