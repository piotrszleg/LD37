using UnityEngine;

public class XYShootingAI : MonoBehaviour
{

    public Transform target;
    XYMovement movement;
    ShootingScript shootingScript;
    public float forgetDistance = 10f;
    public float shootDistance = 5;
    public float safeDistance = 3;
    Vector2 toTarget=Vector2.zero;
    float moveAwayTime=0;
    public float stayShootingTime = 1;

    StackFSMActions fsm = new StackFSMActions();

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        movement = GetComponent<XYMovement>();
        shootingScript = GetComponent<ShootingScript>();
        fsm.pushState(WasteTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) toTarget = target.position - transform.position;
        //Debug.Log(fsm.getCurrentState().Method);
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
        if (toTarget.sqrMagnitude > forgetDistance * forgetDistance)
        {
            target = null;
        }
        else if (toTarget.sqrMagnitude > shootDistance*shootDistance)
        {
            toTarget.Normalize();
            movement.Move(toTarget, true);
            shootingScript.Aim(toTarget);
        }
        else
        {
            fsm.pushState(Shoot);
        }
    }

    void Shoot()
    {
        if (target == null)
        {
            fsm.popState();
            return;
        }
        movement.Move(Vector2.zero);
        if (toTarget.SqrMagnitude() < safeDistance*safeDistance)
        {
            if (moveAwayTime == 0)
            {
                moveAwayTime = Time.time + stayShootingTime;
            }
            if (Time.time > moveAwayTime)
            {
                fsm.pushState(MoveAway);
                moveAwayTime = 0;
            }
        }
        if (toTarget.SqrMagnitude() < shootDistance*shootDistance)
        {
           shootingScript.Aim(toTarget.normalized);
           shootingScript.Shoot();
        }
        else
        {
            fsm.popState();
        }
    }

    void MoveAway()
    {
        if (target == null)
        {
            fsm.popState();
            return;
        }
        if (toTarget.sqrMagnitude < safeDistance * safeDistance+10)
        {
            movement.Move(-toTarget);
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
