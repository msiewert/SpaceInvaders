using UnityEngine;

public class MysteryShip : MonoBehaviour
{
    
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            this.gameObject.SetActive(false);
        }
    }
    public float speed = 8.0f;
    
    private void Update()
    {
        this.transform.position += Vector3.left * speed * Time.deltaTime;
        if (this.transform.position.x >= 15 || this.transform.position.x <= -15)
        {
            speed *= -1.0f;
        }
    }
}
