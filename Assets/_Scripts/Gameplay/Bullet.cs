using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public int damage = 10;
    public Transform hitPrefab;

    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (!rend.isVisible)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Health health = col.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.Damage(damage);
        }
        if(hitPrefab!=null)
            Instantiate(hitPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
