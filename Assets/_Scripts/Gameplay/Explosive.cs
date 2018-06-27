using UnityEngine;
using System.Collections;

public class Explosive : MonoBehaviour {

    public int explosionRadius=10;
    public int arrSize=10;
    int damage = 100;
    public bool destroyItself;
    public Transform destroyedPrefab;

	void OnCollisionEnter2D()
    {
        RaycastHit2D[] hits= new RaycastHit2D[arrSize];
        int hitsLength = Physics2D.CircleCastNonAlloc(transform.position, explosionRadius, Vector2.zero, hits);
        for (int i=0; i<hitsLength; i++)
        {
            Health health = hits[i].transform.GetComponent<Health>();
            if (health != null && hits[i].transform.tag!="Player")
            {
                health.Damage((int)(damage / hits[i].distance));
            }
        }
        if (destroyItself)
        {
            Destroy(gameObject);
            Instantiate(destroyedPrefab, transform.position, Quaternion.identity);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5F);
        Gizmos.DrawWireSphere(transform.position,explosionRadius);
    }
}
