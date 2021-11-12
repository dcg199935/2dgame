using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    int speed = 5;
    int jumpForce = 400;
    Rigidbody2D _rigidbody;
    Animator _animator;

    public Transform feet;
    public LayerMask ground;
    public bool isGrounded = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       float xSpeed = Input.GetAxis("Horizontal") * speed; 
       _rigidbody.velocity = new Vector2 (xSpeed, _rigidbody.velocity.y);
       _animator.SetFloat("Speed", Mathf.Abs(xSpeed));
    }

    private void Update()
    {    
         isGrounded = Physics2D.OverlapCircle(feet.position,.3f, ground);

         if (Input.GetButtonDown("Jump") && isGrounded)
         {
             _rigidbody.AddForce(new Vector2(0, jumpForce));
         }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
           if (other.CompareTag("Fire"))
        {
            SceneManager.LoadScene(5);
        }

        if (other.CompareTag("Bobba"))
        {
            Destroy(other.gameObject);
        }
        
    }
}
