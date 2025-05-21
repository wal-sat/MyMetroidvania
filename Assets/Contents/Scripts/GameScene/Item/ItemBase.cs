using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [SerializeField] ItemManager itemManager;
    [SerializeField] ItemView itemView;
    [SerializeField] GameObject itemParticle;

    private bool _isEnable;

    private void Awake()
    {
        itemManager.Register(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_isEnable) Get();
        }
    }

    protected virtual void Get()
    {
        _isEnable = false;
        itemView.ChangeSprite(false);
        Instantiate(itemParticle, transform.position + Vector3.forward, Quaternion.identity);
    }

    public virtual void Initialize()
    {
        _isEnable = true;
        itemView.ChangeSprite(true);
    }
}
