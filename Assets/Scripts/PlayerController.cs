using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
   private int count;
    public Text scoreText;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetScoreText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Debug.Log("sdadas");
        float movedHorizontal = Input.GetAxis("Horizontal");
        float movedVertical = Input.GetAxis("Vertical");
        Vector3 movement=new Vector3(movedHorizontal,0.0f, movedVertical);
        rb.AddForce(movement*speed);
    }
    void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count +=1;
            SetScoreText();
            //Debug.Log(count);
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + count.ToString();
        if(count==16)
        {
            winText.text = "You Win";
        }
    }
}
