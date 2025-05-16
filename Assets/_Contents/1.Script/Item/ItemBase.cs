using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [SerializeField] ItemManager _itemManager;
    [SerializeField] ItemView _itemView;

    private void Awake()
    {
        _itemManager.Register(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Get();
        }
    }

    protected virtual void Get()
    {
        _itemView.ChangeSprite(false);
    }

    public virtual void Initialize()
    {
        _itemView.ChangeSprite(true);
    }
}
