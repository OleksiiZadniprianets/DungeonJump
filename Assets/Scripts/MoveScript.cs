using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField]
    private float baseSpeed = 1f; // Базова швидкість для кожної платформи

    private float currentSpeed; // Поточна швидкість, що оновлюється зі множником
    private Vector3 moveVector;

    void Start()
    {
        // Встановлюємо поточну швидкість з базовою швидкістю платформи
        currentSpeed = baseSpeed;
        moveVector = new Vector3(0, -currentSpeed, 0);
    }

    void Update()
    {
        transform.Translate(moveVector * Time.deltaTime);
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
        moveVector = new Vector3(0, -currentSpeed, 0);
    }

    public float GetBaseSpeed()
    {
        return baseSpeed;
    }

    // Встановлює базову швидкість для різних типів платформ
    public void SetBaseSpeed(float speed)
    {
        baseSpeed = speed;
        currentSpeed = baseSpeed;
        moveVector = new Vector3(0, -currentSpeed, 0);
    }
}
