using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    public float bulletSpeed = 10f;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Vector3 movement;
    public bool canMove = true;
    private Animator animator;
    public GameObject bulletPrefab;

    public AudioClip shootSound;
    public AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        change.x = Input.GetAxis("Horizontal");
        change.y = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", change.x);
        animator.SetFloat("Vertical", change.y);
        animator.SetFloat("Speed", change.sqrMagnitude);

        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }

        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero && canMove)
        {
            MoveCharacter();
     
        }
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    public void MoveCharacterAutomaticToPosition(Vector3 position)
    {
        Debug.Log("Move Char automatic");
        myRigidbody.MovePosition(position);
    }

    public void ShootBullet()
    {
        audioPlayer.PlayOneShot(shootSound);
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, rotZ);

        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();

        GameObject bulletObject = Instantiate(bulletPrefab, transform.position, rotation);
        bulletObject.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    public static Vector3 MouseWorldPosition
    {
        get { return Camera.main.ScreenToWorldPoint(Input.mousePosition); }
    }
}
