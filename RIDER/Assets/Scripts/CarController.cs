using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed = 20f;
    public float rotationSpeed;

    bool move = false;
    bool isGrounded = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            move = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            move = false;
        }

        if (gameObject.transform.position.y < -11f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void FixedUpdate()
    {
        // update for inputs and fixedUpdate for physics controls
        if (move == true)
        {
            if (isGrounded)
            {
                rb.AddForce(transform.right * speed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
            else
            {
                // rotational force
                rb.AddTorque(rotationSpeed * rotationSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
            
        }
    }

    private void OnCollisionEnter2D()
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D()
    {
        isGrounded = false;
    }
}
