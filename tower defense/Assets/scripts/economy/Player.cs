using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player main;

    [SerializeField] private int health = 500;
    public int money = 0;

    [SerializeField] private TextMeshProUGUI HPGUI;
    [SerializeField] private TextMeshProUGUI moneyGUI;
 

    [SerializeField] private GameObject gameOverGUI;
   
    
    void Awake()
    {
        main = this;

    }

    // Update is called once per frame
    void Update()
    {

        HPGUI.text = "HP: " + health.ToString();
        moneyGUI.text = "Money: " + money.ToString();

    }

    public void Damage(int damage)
    {
        health -= damage;
        if(health < 0)
        {
            gameOverGUI.SetActive(true);
        }
    }
    
    public void restart()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
