using JetBrains.Annotations;
using UnityEngine;

public class MOVEMENT : MonoBehaviour
{
    public float speed;
    float horizontalinput;
    float verticalinput;
    public bullet prefabbullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bullet bullet = Instantiate(prefabbullet, transform.position, transform.rotation);
            bullet.direction = transform.right;
            
        }

        horizontalinput = -Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward, horizontalinput * Time.deltaTime * 100f);

        verticalinput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * verticalinput * Time.deltaTime * speed); 
    }
}
