using UnityEngine;
using System.Collections;

public class RogueInput : MonoBehaviour {

    XYMovement movement;
    ShootingScript shootingScript;
    Vector2 lastInput = Vector2.zero;

    // Use this for initialization
    void Start()
    {
        movement = GetComponent<XYMovement>();
        shootingScript = GetComponent<ShootingScript>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        //input = (input + lastInput) / 2;

        movement.Move(input, Input.GetKey(KeyCode.LeftShift));

        lastInput = input;

        if (input.y == 0)
        {
            if (input.x > 0) shootingScript.Aim(Vector2.right);
            if (input.x < 0) shootingScript.Aim(Vector2.left);
        }
        if (input.x == 0)
        {
            if (input.y > 0) shootingScript.Aim(Vector2.up);
            if (input.y < 0) shootingScript.Aim(Vector2.down);
        }

        if (Input.GetMouseButton(0))
        {
            shootingScript.Shoot();
        }
    }
}
