using UnityEngine;

public class MachineGun : MonoBehaviour
{
    public float rotateSpeed = 5f;
    public float delayNextShooting = 0.01f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public AudioSource audioSrc;

    float nextFireTime = 0.0f;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (Time.time > nextFireTime)
            {
                nextFireTime = Time.time + delayNextShooting;

                if (audioSrc != null)
                {
                    audioSrc.Play();
                }
                Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
            }

        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotateSpeed);
        }
    }
}
