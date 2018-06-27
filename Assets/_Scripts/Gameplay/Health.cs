using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int maxHP = 100;
    private int currentHP;
    public int points = 1;
    public int CurrentHP
    {
        get
        {
            return currentHP;
        }
    }
    public Transform corpsePrefab;

    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {

    }

    public void Damage(int amount)
    {
        currentHP -= amount;
        if (currentHP <= 0)
        {
            if (corpsePrefab != null)
            {
                Instantiate(corpsePrefab, transform.position, Quaternion.identity);
            }
            if (points>0)
            {
                GameObject.FindObjectOfType<Points>().Score(points);
            }
            Destroy(gameObject);
        }
    }

    public void Heal(int amount)
    {
        if (currentHP + amount < maxHP)
        {
            currentHP += amount;
        }
        else
        {
            currentHP = maxHP;
        }
    }

    public float PercentHealth()
    {
        return (float)currentHP / (float)maxHP;
    }
}
