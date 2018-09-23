using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text redCountText;
    public Text totalCountText;


    private Rigidbody rb;
    private int count;
    private int RedCount;
    private int TotalCount;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        RedCount = 0;
        SetCountText();
        winText.text = "";
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Red Pick Up"))
        {
            other.gameObject.SetActive(false);
            RedCount = RedCount + 1;
            
            SetCountText();
        }
    }



    void SetCountText()
    {
        countText.text = "Yellow Cube: " + count.ToString();
        redCountText.text = "Red Cube: " + RedCount.ToString();
        TotalCount = count - RedCount;
        totalCountText.text = "Your Total Score: " + TotalCount.ToString();
        
        if ( count >= 12)
            {
                winText.text = "You Finished with a score of: " + TotalCount.ToString();
            }

    }




        private void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
