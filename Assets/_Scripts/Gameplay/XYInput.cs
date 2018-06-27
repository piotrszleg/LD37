using UnityEngine;
using UnityEngine.EventSystems;

public class XYInput : MonoBehaviour {

    XYMovement movement;
    ShootingScript shootingScript;
    Vector2 lastInput=Vector2.zero;
    public bool shoot=true;

    // Use this for initialization
    void Start () {
        movement = GetComponent<XYMovement>();
        shootingScript = GetComponent<ShootingScript>();

    }
	
	// Update is called once per frame
	void Update () {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        input = (input + lastInput) / 2;
        //Debug.Log(input);

        movement.Move(input, Input.GetKey(KeyCode.LeftShift));

        lastInput = input;

        Vector2 aim = Camera.main.ScreenToWorldPoint(Input.mousePosition) - shootingScript.aimTransform.position;
        aim.Normalize();
        shootingScript.Aim(aim);

        if (Input.GetMouseButton(0) && shoot)
        {
            shootingScript.Shoot();
        }
	}
}
