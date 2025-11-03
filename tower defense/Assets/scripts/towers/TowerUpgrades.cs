using System;
using UnityEngine;

public class TowerUpgrades : MonoBehaviour
{
    [System.Serializable]
    class Level
    {
        public float range = 8f;
        public int damage = 25;
        public float fireRate = 1f;
        public int cost = 100;
    }
    [SerializeField] private Level[] levels = new Level[3];
    [NonSerialized] public int currentLevel = 0;
    [NonSerialized] public string currentCost;

    private Tower tower;
    [SerializeField] private TowerRange towerRange;
    void Awake()
    {
        tower = GetComponent<Tower>();
        currentCost = levels[0].cost.ToString();
    }

    public void Upgrade()
    {
        if (currentLevel < levels.Length && levels[currentLevel].cost < Player.main.money)
        {
            tower.range = levels[currentLevel].range;
            tower.damage = levels[currentLevel].damage;
            tower.fireRate = levels[currentLevel].fireRate;
            towerRange.UpdateRange();

            Player.main.money -= levels[currentLevel].cost;

            currentLevel++;

            if(currentLevel >= levels.Length)
            {
                currentCost = "MAX";
            }
            else
            {
                currentCost = levels[currentLevel].cost.ToString();
            }
        }
    }
}
