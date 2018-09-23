using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text yellowpText;
    

    private Rigidbody rb;
    private int count;
    private int yellowp;
    private object Player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        yellowp  = 0;
        SetYellowText();
        winText.text = "";
       
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText ();
            yellowp = yellowp + 1;
            SetYellowText();
        }

        if (other.gameObject.CompareTag("EvilCube"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            SetCountText();
        }

        if (count == 12)
        {
            transform.position = new Vector3(22.38f, 0.5f, 7.13f);
        }
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            winText.text = "You won with a score of: " + count.ToString();
        }
    }

    void SetYellowText()
    {
        yellowpText.text = "Pickups: " + yellowp.ToString();
      
    }
}