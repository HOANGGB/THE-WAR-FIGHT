
using UnityEngine;

public class PointFireSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriteRenderer;
    [SerializeField] GameObject Gun;
    void Start()
    {

        spriteRenderer = Gun.GetComponent<SpriteRenderer>();
        UpdatePointFire(.5f);
    }

    public void UpdatePointFire(float lenghtGun)
    {
        Bounds bounds = spriteRenderer.bounds;
        Vector2 size = bounds.size;

        Vector3 newFirePoint = new Vector3(size.x /3+ lenghtGun,0,0);
        transform.localPosition = newFirePoint;

    }
}
