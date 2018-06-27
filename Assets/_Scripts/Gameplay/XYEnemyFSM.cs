using UnityEngine;

public class XYEnemyFSM : MonoBehaviour
{

    public Transform target;
    XYMovement movement;
    public float forgetDistance = 10f;
    private float nextAttack = 0.0F;
    public float rateOfAttacks = 1;

    StackFSMActions fsm = new StackFSMActions();

    // Use this for initialization
    void Start()
    {
        movement = GetComponent<XYMovement>();
        fsm.pushState(WasteTime);
    }

    // Update is called once per frame
    void Update()
    {
        fsm.update();
    }

    void WasteTime()
    {
        if (target != null)
        {
            fsm.pushState(Chase);
        }
    }

    void Chase()
    {
        if (target == null)
        {
            fsm.popState();
            return;
        }
        Vector2 toTarget = target.position - transform.position;
        if (toTarget.sqrMagnitude > forgetDistance * forgetDistance)
        {
            target = null;
        }
        else if (toTarget.sqrMagnitude > 1)
        {
            toTarget.Normalize();
            movement.Move(toTarget, true);
        }
        else
        {
            fsm.pushState(Attack);
        }
    }

    void Attack()
    {
        if (Vector2.Distance(transform.position, target.position) < 1)
        {
            if (Time.time > nextAttack)
            {
                target.SendMessage("Damage", 10);
                nextAttack = Time.time + 1 / rateOfAttacks;
            }
        }
        else
        {
            fsm.popState();
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

