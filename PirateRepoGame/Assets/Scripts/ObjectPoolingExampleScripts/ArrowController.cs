using System.Collections;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Spawned()
    {
        StartCoroutine(Disable());
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
        this.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
