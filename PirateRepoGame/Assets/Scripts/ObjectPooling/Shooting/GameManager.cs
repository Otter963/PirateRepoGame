using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public BulletPool bulletPool;
    public float bulletSpeed = 10f;

    [SerializeField] private InputActionAsset playerControls;

    private void Update()
    {
        if (playerControls.FindAction("Shoot").WasPressedThisFrame())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;

        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();

        if (bulletRB != null)
        {
            bulletRB.linearVelocity = bullet.transform.forward * bulletSpeed;
        }

        StartCoroutine(DeactivateBullet(bullet));
    }

    IEnumerator DeactivateBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(2f);
        bulletPool.ReturnObject(bullet);
    }
}
