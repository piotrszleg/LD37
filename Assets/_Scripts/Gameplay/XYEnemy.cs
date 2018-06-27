using UnityEngine;

public class XYEnemy : MonoBehaviour {

    Transform target;
    XYMovement movement;
    public float forgetDistance = 10f;
    private float nextAttack = 0.0F;
    public float rateOfAttacks=1;

    // Use this for initialization
    void Start () {
        movement = GetComponent<XYMovement>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            movement.Move(Vector2.zero);
            return;
        }
        Vector2 toTarget=target.position - transform.position;
        if (toTarget.sqrMagnitude > forgetDistance * forgetDistance)
        {
            target = null;
        }
        else if (toTarget.sqrMagnitude > 1)
        {
            toTarget.Normalize();
            movement.Move(toTarget);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (Time.time > nextAttack && col.transform==target)
        {
            target.SendMessage("Damage", 10);
            nextAttack = Time.time + rateOfAttacks;
            Debug.Log("Attacked Player, next " + nextAttack);
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
