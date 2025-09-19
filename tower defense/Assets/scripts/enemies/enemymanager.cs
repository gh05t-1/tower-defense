using UnityEngine;

public class enemymanager : MonoBehaviour
{
    public static enemymanager main;
    public Transform[] checkpoints;
    void Awake()
    {
        main = this;
    }
}
