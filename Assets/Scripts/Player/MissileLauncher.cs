using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField]
    public GameObject missilePrefab = default;
    [SerializeField]
    Transform firePoint = default;
    public static Transform target;

    GameObject missile;

    void Start()
    {
        firePoint = GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(ControlsManager.Inputs["Missile"]))
        {
            Debug.Log("Input for missile: " + ControlsManager.Inputs["Missile"]);

            if (target != null && missile == null)
            {
                Debug.Log("instantiating missile");
                missile = Instantiate(missilePrefab, firePoint.transform.position, transform.rotation);
                missile.GetComponent<Missile>().target = target;
            }
        }
    }
}
