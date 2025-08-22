using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootScript : MonoBehaviour
{
    public Transform shootLocation;

    public GameObject arrowPrefab;

    public float arrowSpeed;

    public Animator anim;

    public string currentType = "arrow";

    [Header("Input Actions")]
    [SerializeField] private InputActionAsset playerControls;

    private InputAction shootAction;

    public void ChangeType(string type)
    {
        currentType = type;
    }

    private void Awake()
    {
        shootAction = playerControls.FindActionMap("Player").FindAction("Shoot");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shootAction.WasPressedThisFrame())
        {
            Shoot();
            ChangeType("arrow");
            //anim.SetTrigger("Attack2");
        }
        if (Input.GetMouseButtonDown(1))
        {
            //Shoot();
            ChangeType("arrowPoison");
            //anim.SetTrigger("Attack2");
        }
    }

    public void Shoot()
    {
        /*
        GameObject temp = Instantiate(arrowPrefab, shootLocation.position, Quaternion.identity);

        temp.GetComponent<Rigidbody2D>().linearVelocity = new Vector3(arrowSpeed, 0, 0);

        //old way
        //Destroy(temp, 2f);
        */

        //object pooling way
        GameObject temp = ArrowPooler.Instance.SpawnFromPool(currentType, shootLocation.position,Quaternion.identity);
        temp.GetComponent<Rigidbody>().linearVelocity = new Vector3(arrowSpeed, 0, 0);
        temp.GetComponent<ArrowController>().Spawned();
    }
}
