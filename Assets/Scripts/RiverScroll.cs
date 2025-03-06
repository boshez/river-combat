using UnityEngine;

public class RiverScroll : MonoBehaviour
{
    public float scrollSpeed = 2f;
    private Material material;
    
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }
    
    void Update()
    {
        Vector2 offset = material.mainTextureOffset;
        offset.y += Time.deltaTime * scrollSpeed;
        material.mainTextureOffset = offset;
    }
}
