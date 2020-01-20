using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text gameOver;
    public AudioSource musicSource;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioClip musicClipThree;

    public GameObject dynamiteparticle;

    float currentTime = 0f;
    float startingTime = 12f;

    [SerializeField] Text countdownText;

    private Rigidbody2D rb2d;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        gameOver.text = "";
        SetCountText();
        currentTime = startingTime;
        musicSource.clip = musicClipThree;
        musicSource.Play();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
        {
            currentTime = 0;
            musicSource.clip = musicClipThree;
            musicSource.Stop();
            musicSource.clip = musicClipTwo;
            musicSource.Play();
            gameOver.text = "Game Over!";
            Destroy(this);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.CompareTag("Pickups"))
        {
            other.gameObject.SetActive(false);
            Instantiate(dynamiteparticle, other.transform.position, Quaternion.identity);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText ()
    {
        countText.text = "Dynamite: " + count.ToString();
        if (count >= 5)
        {
            winText.text = "Congratulations! You Win!";
            musicSource.clip = musicClipThree;
            musicSource.Stop();
            musicSource.clip = musicClipOne;
            musicSource.Play();
            Destroy(this);
            if (Input.GetKey("escape"))
                Application.Quit();

        }
    }
}