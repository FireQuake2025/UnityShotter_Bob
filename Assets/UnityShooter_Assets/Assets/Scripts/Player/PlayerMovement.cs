using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float speedBoost = 6f;
    Vector3 movment;
    Animator animator;
    int floorMask;
    float camRayLength = 100f;
    Rigidbody playerRigidbody;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Turning();
        Animating(h,v);
    }

    void Move(float h, float v)
    {
        movment.Set(h, 0, v);
        movment = movment.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movment);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerMouse = floorHit.point - transform.position;
            playerMouse.y = 0;

            Quaternion newRotation = Quaternion.LookRotation(playerMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0 || v != 0;
        animator.SetBool("IsWalking", walking);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedBoost"))
        {
            Destroy(other.gameObject);
            speed += speedBoost;
            StartCoroutine(Timer(10));

        }
        
    }

    IEnumerator Timer(float boostDuration)
    {
        yield return new WaitForSeconds(boostDuration);
        speed = 6f;
        Debug.Log("Finish Speed Boost");
    }
}
