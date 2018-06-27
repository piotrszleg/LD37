using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

    Transform target;
    ShootingScript shootingScript;
    public float forgetDistance = 10f;

    // Use this for initialization
    void Start()
    {
        shootingScript = GetComponent<ShootingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        Vector2 toTarget = target.position - transform.position;
        if (toTarget.sqrMagnitude > forgetDistance*forgetDistance)
        {
            target = null;
        }
        else if (toTarget.sqrMagnitude > 1)
        {
            toTarget.Normalize();
            shootingScript.Aim(toTarget);
            shootingScript.Shoot();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            target = other.transform;
        }
    }
}
