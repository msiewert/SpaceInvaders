using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    private void Update()
    {
        this.transform.position += direction * speed * Time.deltaTime;
    }
}