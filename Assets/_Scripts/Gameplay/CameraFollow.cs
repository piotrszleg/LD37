using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public float speed = 1;
    public Vector3 offset = new Vector3(0, 0, -10);
    public Vector2 absoluteOffset=Vector2.zero;

    // Use this for initialization
    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 newPosition = player.position + offset;
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed)+(Vector3)absoluteOffset;
        }
    }

    public void Shake(float magnitude, float duration)
    {
        StartCoroutine(_Shake(magnitude, duration));
    }

    IEnumerator _Shake(float magnitude, float duration)
    {
        float elapsed = 0.0f;

        //Vector3 originalCamPos = transform.position;

        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            transform.position = new Vector3(transform.position.x+ x, transform.position.x + y, transform.position.z);

            yield return null;
        }

        //transform.position = originalCamPos;
    }
}
