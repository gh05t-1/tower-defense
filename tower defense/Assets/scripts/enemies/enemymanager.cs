using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymanager : MonoBehaviour
{
    public static enemymanager main;

    public Transform[] checkpoints;
    public Transform spawnpoint;

    [SerializeField] private int wave = 1;
    [SerializeField] private int enemyCount = 6;
    [SerializeField] private float enemyCountRate = 0.2f;
    [SerializeField] private float spawnDelayMax = 1f;
    [SerializeField] private float spawnDelayMin = 0.75f;

    [SerializeField] private GameObject turtle;
    [SerializeField] private GameObject whaleShark;
    [SerializeField] private GameObject walkingFish;

    [SerializeField] private float turtleRate = 0.5f;
    [SerializeField] private float whaleSharkRate = 0.4f;
    [SerializeField] private float walkingFishRate = 0.1f;

    private bool wavedone = false;
    private List<GameObject> waveset =  new List<GameObject> ();
    private int enemyLeft;

    private int turtleCount;
    private int whaleSharkCount;
    private int walkingFishCount;
    void Awake()
    {
        main = this;
    }
    void Start()
    {
        SetWave();
    }
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (Input.GetKeyDown(KeyCode.Return) && wavedone && enemies.Length == 0)
        {
            wave++;
            wavedone = false;
            enemyCount += Mathf.RoundToInt(enemyCount * enemyCountRate);
            SetWave();
        }
        if (Input.GetKeyDown(KeyCode.D) && wavedone)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i]);
            }
        }
    }

    private void SetWave()
    {
        turtleCount = Mathf.RoundToInt (enemyCount * (turtleRate + walkingFishRate));
        whaleSharkCount = Mathf.RoundToInt(enemyCount * whaleSharkRate);
        walkingFishCount = 0;

        if (wave % 5 == 0)
        {
            turtleCount = Mathf.RoundToInt(enemyCount * turtleRate);
            walkingFishCount = Mathf.RoundToInt(enemyCount * walkingFishRate);
        }

        enemyLeft = turtleCount + whaleSharkCount + walkingFishCount;
        enemyCount = enemyLeft;
        waveset = new List<GameObject>();

        for (int i = 0; i < turtleCount; i++)
        {
            waveset.Add(turtle);
        }
        for (int i = 0; i < whaleSharkCount; i++)
        {
            waveset.Add(whaleShark);
        }
        for (int i = 0; i < walkingFishCount; i++)
        {
            waveset.Add(walkingFish);
        }

        waveset = Shuffle(waveset);

        StartCoroutine(spawn());
    }

    public List<GameObject> Shuffle(List<GameObject> waveSet)
    {
        List<GameObject> temp = new List<GameObject>();
        List<GameObject> result = new List<GameObject>();
        temp.AddRange(waveSet);
        
        for (int i = 0; i < waveSet.Count; i++)
        {
            int index = Random.Range(0, temp.Count - 1);
            result.Add(temp[index]);
            temp.RemoveAt(index);
        }
        return result;
    }
    IEnumerator spawn()
    {
        for (int i = 0; i < waveset.Count;i++)
        {
            Instantiate(waveset[i], spawnpoint.position , Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(spawnDelayMin,spawnDelayMax));
        }
        wavedone = true;
    }
}
