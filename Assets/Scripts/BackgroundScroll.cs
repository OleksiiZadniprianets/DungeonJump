using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    private Material backgroundMaterial;
    private Vector2 offset;

    void Start()
    {
        backgroundMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(0, scrollSpeed);
    }

    void Update()
    {
        // Зміщення текстури по осі Y для ефекту руху вгору
        backgroundMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
