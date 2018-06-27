using UnityEngine;

public class ShootingScript : MonoBehaviour {

    public Transform bulletPrefab;
    Vector2 shootDirection=Vector2.right;
    public Transform aimTransform;
    public CameraFollow camFollow;
    public float fireRate = 10;
    public int damagePerShoot=10;
    float nextShoot = 0;
    SpriteRenderer rend;
    SpriteRenderer gunRend;
    Animator anim;
    public float distanceFromTransform = 1.5f;
    AudioSource source;

    // Use this for initialization
    void Start () {
        rend = GetComponent<SpriteRenderer>();
        gunRend = GetComponentsInChildren<SpriteRenderer>()[1];
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Aim(Vector2 direction)
    {
        shootDirection = direction;
        if (camFollow != null) camFollow.offset=new Vector3(direction.x*2, direction.y*2, camFollow.offset.z);

        if (aimTransform.lossyScale.x>0)
        {
            aimTransform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x));
        } else
        {
            aimTransform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(-direction.y, -direction.x));
        }
        if (shootDirection.x > 0 && transform.localScale.x<0)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        if(shootDirection.x < 0 && transform.localScale.x > 0)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        if (shootDirection.y < 0)//looking up
        {
            if(gunRend!=null)gunRend.sortingOrder = rend.sortingOrder + 1;
            if(anim!=null)anim.SetInteger("direction", -1);
        }
        if (shootDirection.y > 0)//looking down
        {
            if (gunRend != null) gunRend.sortingOrder = rend.sortingOrder - 1;
            if (anim != null) anim.SetInteger("direction", 1);
        }
    }

    public void Shoot() {
        if (nextShoot <= Time.time && enabled)
        {
            Vector2 bulletPosition = (Vector2)aimTransform.position + shootDirection * distanceFromTransform;
            Transform newBullet = (Transform)Instantiate(bulletPrefab, bulletPosition, Quaternion.identity);
            Bullet newBulletScript = newBullet.GetComponent<Bullet>();
            if (newBulletScript != null)
            {
                newBulletScript.damage = damagePerShoot;
            }
            float angle = AngleBetweenPoints(Vector2.zero, -shootDirection);
            newBullet.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            if(source!=null)source.Play();
            nextShoot = Time.time + 1 / fireRate;
        }
    }

    float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.5F);
        Gizmos.DrawWireSphere(aimTransform.position, distanceFromTransform);
    }
}
