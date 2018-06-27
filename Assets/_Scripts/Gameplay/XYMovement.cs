using UnityEngine;
using System.Collections;

public class XYMovement : Player {

    Rigidbody2D body;
    public float walkSpeed = 4;
    public float runSpeed = 6;
    public enum Face { Nothing, Direction, Side };
    public Face face;
    Animator anim;
    bool moving;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!canMove) body.velocity = Vector2.zero;
        if (body.velocity == Vector2.zero)
        {
            body.drag = float.MaxValue;
        }
        else
        {
            body.drag = 1;
        }
    }

    void LateUpdate()
    {
        if (anim != null)
        {
            anim.SetBool("walk", moving);
        }
        moving = false;
    }

    public void Move(Vector2 movement, bool run=false)
    {
        if (!canMove) return;
        if(movement.SqrMagnitude()>0)moving = true;
        if (face == Face.Direction && movement.sqrMagnitude > 0)
        {
            transform.right = movement;
        }
        if (face == Face.Side)
        {
            if (((movement.x < 0 && transform.localScale.x > 0)
                || (movement.x > 0 && transform.localScale.x < 0)))
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        if (run)
        {
            body.velocity = movement * runSpeed;
        }
        else
        {
            body.velocity = movement * walkSpeed;
        }
    }
}
