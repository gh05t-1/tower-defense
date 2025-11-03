using UnityEngine;
using UnityEngine.SceneManagement;

public class scene : MonoBehaviour
{


    public void StartButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
    public void ReturnToMainMenuClicked()
    {
        SceneManager.LoadScene(0);
    }

}
