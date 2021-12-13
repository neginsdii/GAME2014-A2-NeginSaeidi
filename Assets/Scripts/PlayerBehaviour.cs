/*
 * Full Name        : Negin Saeidi
 * Student ID       : 101261395
 * Date Modified    : December 12, 2021
 * File             : PlayerBehaviour.cs
 * Description      : This is the PlayerBehaviour script - Controls the movement for the player, Collision between player and other objects
 * Version          : V04
 * Revision History : Added load game over scene
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerBehaviour : MonoBehaviour
{
    [Header("Touch Input")]
    public Joystick joystick;
    [Range(0.01f, 1.0f)]
    public float sensitivity;

    [Header("Movement")]
    public float horizontalForce;
    public float verticalForce;
    public bool isGrounded;
    public Transform groundOrigin;
    public float groundRadius;
    public LayerMask groundLayerMask;
    [Range(0.1f, 0.9f)]
    public float airControlFactor;

    private Rigidbody2D rigidbody;
    [Header("HUD Settings")]
    [SerializeField] private Text scoreText;
    [SerializeField] public List<GameObject> lifeImages;
    private int numberOfNeros = 0;
    private int score = 0;
    [SerializeField] private Transform spawnposition;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckIfGrounded();
        scoreText.text = "Score: " + score;
        if(lifeImages.Count<=0)
		{
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.SetInt("Neros", numberOfNeros);

            SceneManager.LoadScene("GameOver");

        }
    }
    IEnumerator respawn()
	{
        yield return new WaitForSeconds(0.1f);
        transform.position = spawnposition.position;
       
    }

    private void Move()
    {
            float x = (Input.GetAxisRaw("Horizontal") + joystick.Horizontal) * sensitivity;
        if (isGrounded)
        {
            //float deltaTime = Time.deltaTime;

            // Keyboard Input
            float y = (Input.GetAxisRaw("Vertical") + joystick.Vertical) * sensitivity;
            float jump = Input.GetAxisRaw("Jump") + ((UIController.jumpButtonDown) ? 1.0f : 0.0f);

            // Check for Flip

            if (x != 0)
            {
                x = FlipAnimation(x);
            }

            // Touch Input
            Vector2 worldTouch = new Vector2();
            foreach (var touch in Input.touches)
            {
                worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
            }

            float horizontalMoveForce = x * horizontalForce;// * deltaTime;

            float jumpMoveForce = jump * verticalForce; // * deltaTime;

            float mass = rigidbody.mass * rigidbody.gravityScale;


            rigidbody.AddForce(new Vector2(horizontalMoveForce, jumpMoveForce) * mass);
            rigidbody.velocity *= 0.99f; // scaling / stopping hack
        }
        else
		{
            if (x != 0)
            {
                x = FlipAnimation(x);

                float horizontalMoveForce = x * horizontalForce * airControlFactor;
                float mass = rigidbody.mass * rigidbody.gravityScale;

                rigidbody.AddForce(new Vector2(horizontalMoveForce, 0.0f) * mass);
            }
        }

    }

    private void CheckIfGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(groundOrigin.position, groundRadius, Vector2.down, groundRadius, groundLayerMask);

        isGrounded = (hit) ? true : false;
    }

    private float FlipAnimation(float x)
    {
        // depending on direction scale across the x-axis either 1 or -1
        
        x = (x > 0) ? 1 : -1;
        if(x>0)
        transform.localScale = new Vector3(Mathf.Abs( transform.localScale.x) * -1 , transform.localScale.y);
        else
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) , transform.localScale.y);

        return x;
    }


    // UTILITIES

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundOrigin.position, groundRadius);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(other.transform);
        }
       else if(other.gameObject.tag == "Enemy")
        {
            Debug.Log(lifeImages.Count);
            lifeImages[lifeImages.Count - 1].SetActive(false);
            lifeImages.RemoveAt(lifeImages.Count - 1);
            StartCoroutine(respawn());
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Nero")
		{
            Destroy(collision.gameObject);
            numberOfNeros++;
            score += 10;
		}
        else if (collision.gameObject.tag == "Door")
        {
            if(numberOfNeros>=7)
			{
                PlayerPrefs.SetInt("Score", score);
                PlayerPrefs.SetInt("Neros", numberOfNeros);

                SceneManager.LoadScene("GameOver");

            }
        }
    }
}
