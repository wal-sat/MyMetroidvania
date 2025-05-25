using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [SerializeField] private ItemManager _itemManager;
    [SerializeField] private ItemView _itemView;
    [SerializeField] private GameObject _itemParticle;

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
        Instantiate(_itemParticle, transform.position + Vector3.forward, Quaternion.identity);
    }

    public virtual void Initialize()
    {
        _isEnable = true;
        _itemView.ChangeSprite(true);
    }
}
