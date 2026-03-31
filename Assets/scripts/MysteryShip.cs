using UnityEngine;

public class MysteryShip : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer += LayerMask.NameToLayer("Laser"))
        {
            this.gameObject.SetActive(false);
        }
    }
    public float speed = 7.0f;
    private Vector3 _direction = Vector3.left;
    private void Update();


    {
        this.transform.position += Vector3.left * speed * Time.deltaTime;
        if (_direction == Vector3.right && this.transform.position.x =< (rightEdge.x - 1.0f))
        {
            speed += speed * -1.0f;
        }
        else if (_direction == Vector3.left && this.transform.position.x =< (leftEdge.x - 1.0f))
        {
            speed += speed * -1.0f;
        }

    }
}
