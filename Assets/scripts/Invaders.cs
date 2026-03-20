using UnityEngine;
using UnityEngine.SceneManagement;

public class Invaders : MonoBehaviour
{
    public Invader[] prefabs;
    public int rows = 5;
    public int columns = 11;
    public AnimationCurve speed;
    public float missileAttackRate = 1.0f;
    public Projectile missilePrefab;

    public int amountKilled { get; private set; }
    public int amountAlive => this.totalInvaders - this.amountKilled;
    public int totalInvaders => this.rows * this.columns;
    public float percentageKilled => (float)this.amountKilled / (float)this.totalInvaders;
    private Vector3 _direction = Vector3.right;

    private void Awake()
    {
        for (int row = 0; row < this.rows; row++)
        {
            float width = 2.0f * (this.columns - 1);
            float height = 2.0f * (this.rows - 1);
            Vector2 centering = new Vector2(-width / 2.0f, -height / 2.0f);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + row * 2.0f, 0.0f);
            for (int column = 0; column < this.columns; column++)
            {
                Invader invader = Instantiate(this.prefabs[row], this.transform);
                invader.killed += InvaderKilled;
                Vector3 position = rowPosition;
                position.x += column * 2.0f;
                invader.transform.localPosition = position;
            }


        }

    }
    private void Start()
    {
        InvokeRepeating(nameof(MissileAttack), this.missileAttackRate, this.missileAttackRate);
    }
    private void Update()
    {
        this.transform.position += this._direction * this.speed.Evaluate(this.percentageKilled) * Time.deltaTime;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (_direction == Vector3.right && invader.position.x >= (rightEdge.x - 1.0f))
            {
                AdvanceRow();

            }
            else if (_direction == Vector3.left && invader.position.x <= (leftEdge.x + 1.0f))
            {
                AdvanceRow();

            }

        }
    }
    private void AdvanceRow()
    {
        this._direction *= -1.0f;
        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;
    }
    private void InvaderKilled()
    {
        this.amountKilled++;
        if (this.amountKilled >= this.totalInvaders)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void MissileAttack()
    {
        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (Random.value < (1.0f / (float)this.amountAlive))
            {
                Instantiate(this.missilePrefab, invader.position, Quaternion.identity);
                break;
            }

        }
    }

}