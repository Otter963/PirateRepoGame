using System.Collections;
using UnityEngine;

public class BasicEnemyDeathScript : MonoBehaviour
{
    [SerializeField] private int enemyHealth;

    [SerializeField] private float deathTime = 5f;

    [SerializeField] private GameObject explosionEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (enemyHealth > 0)
            {
                SoundManager.PlaySound(SoundType.ENEMYHURT, 0.5f);
                enemyHealth--;
            }
            else
            {
                StartCoroutine(EnemyDeath());
            }
            
        }
    }

    IEnumerator EnemyDeath()
    {
        SoundManager.PlaySound(SoundType.ENEMYDEATH, 0.5f);
        explosionEffect.SetActive(true);
        yield return new WaitForSeconds(deathTime);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
