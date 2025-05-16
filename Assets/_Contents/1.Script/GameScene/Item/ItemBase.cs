using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [SerializeField] ItemManager _itemManager;
    [SerializeField] ItemView _itemView;

    private bool _isEnable;

    private void Awake()
    {
        _itemManager.Register(this);
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
        _itemView.ChangeSprite(false);
    }

    public virtual void Initialize()
    {
        _isEnable = true;
        _itemView.ChangeSprite(true);
    }
}
