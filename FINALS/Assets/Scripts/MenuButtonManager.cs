using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{
    public string targetScene;

    public void goToTargetScene()
    {
        SceneManager.LoadScene(targetScene);
    }
}
