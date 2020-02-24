using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontalInput;
    private float verticalInput;
    private bool isPowered = false;
    public GameObject particle;
    private float powerIncrease = 1.0f;
    private float speedIncrease = 1.0f;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI gameOverText;
    public float health = 20;
    public bool isGameActive = true;
    void Start()
    {
        isGameActive = true;
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            Move();
        }
        if (!isGameActive)
        {
            gameOverText.gameObject.SetActive(true);
        }
        
        if(health < 1)
        {
            isGameActive = false;
        }
        healthText.text = "Health: " + health;
    }

    void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput / 5 * speedIncrease);
        transform.Translate(Vector3.right * horizontalInput / 5 * speedIncrease);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * 10 * powerIncrease, ForceMode.Impulse);
            Debug.Log("Collided with enemy");
            if (!isPowered)
            {
                health -= 5;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Powerup")
        {
            powerIncrease = 10.0f;
            speedIncrease = 2.0f;
            particle.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerCooldown());
            isPowered = true;
        }
    }

    IEnumerator PowerCooldown()
    {
        yield return new WaitForSeconds(5);
        powerIncrease = 1.0f;
        speedIncrease = 1.0f;
        isPowered = false;
        particle.gameObject.SetActive(false);

    }
}
