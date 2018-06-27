using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public Transform[] spawnTransforms;
    public int areaW=10;
    public int areaH = 10;
    public int distanceFromPlayer=3;
    public float spawnRate = 1;

    public Transform player;

    public int iterations = 0;

	// Use this for initialization
	void Start () {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Spawn", spawnRate, spawnRate);
	}

    void Spawn()
    {
        if (player == null) return;
        for (int j = 0; j < iterations / 6 + 1; j++) {
            for (int i = 0; i < spawnTransforms.Length; i++)
            {
                if (Random.value > (float)i / (float)spawnTransforms.Length)
                {
                    Vector2 spawnPosition = GenerateSpawnPoint();
                    Instantiate(spawnTransforms[i], spawnPosition, Quaternion.identity);
                    Debug.DrawLine(transform.position, spawnPosition);
                }
            }
        }
        iterations++;
        spawnRate -= (spawnRate*0.2f);
    }

    Vector2 GenerateSpawnPoint()
    {
        Vector2 spawnPoint = Vector2.zero;
        while (spawnPoint==Vector2.zero || Vector2.Distance(player.position, spawnPoint)<distanceFromPlayer)
        {
            spawnPoint = new Vector2(-areaW/2 + Random.value * areaW, -areaH/2 + Random.value * areaH);
        }
        return spawnPoint;
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5F);
        if(player!=null)Gizmos.DrawWireSphere(player.position, distanceFromPlayer);
        Gizmos.DrawWireCube(transform.position, new Vector3(areaW, areaH, 1));
    }
}
