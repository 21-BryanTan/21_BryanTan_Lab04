using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float speed;

    public GameObject coinText;

    private int coinsCollected;

    Rigidbody PlayerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidBody = this.gameObject.GetComponent<Rigidbody>();

        coinText.GetComponent<Text>().text = "Coins Collected: " + coinsCollected;

        coinsCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {

        coinText.GetComponent<Text>().text = "Coins Collected: " + coinsCollected;

        if (coinsCollected == 4 && SceneManager.GetActiveScene().name == "GamePlay_Level1")
        {
            SceneManager.LoadScene("GamePlay_Level2");
        }
        else if(coinsCollected == 4 && SceneManager.GetActiveScene().name == "GamePlay_Level2")
        {
            SceneManager.LoadScene("GameWin");
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        PlayerRigidBody.AddForce(movement * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Hazard"))
        {
            SceneManager.LoadScene("GameLose");
        }

        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinsCollected++;
        }
    }
}
