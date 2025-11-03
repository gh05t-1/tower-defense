using UnityEngine;

public class TowerType : ScriptableObject
{
    public float range = 8f;
    public int damage = 25;
    public float fireRate = 1f;
    public int cost = 50;

    public bool first = true;
    public bool last = false;
    public bool strong = false;

    public string targetingMode;
}
