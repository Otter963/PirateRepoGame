using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public BulletPool bulletPool;
    public float bulletSpeed = 10f;
    [SerializeField] private float bulletAliveTime = 0.5f;

    [SerializeField] private PauseMenuScript pauseMenuScript;

    [SerializeField] private InputActionAsset playerControls;

    [SerializeField] private Animator playerAnimator;

    private void Update()
    {
        if (!pauseMenuScript.isPaused)
        {
            if (playerControls.FindAction("Shoot").WasPressedThisFrame())
            {
                playerAnimator.SetTrigger("Shoot");
                Shoot();
            }
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
            SoundManager.PlaySound(SoundType.SHOOT, 0.5f);
        }

        StartCoroutine(DeactivateBullet(bullet));
    }

    IEnumerator DeactivateBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(bulletAliveTime);
        bulletPool.ReturnObject(bullet);
    }
}
