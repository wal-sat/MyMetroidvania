using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T instance = default;

	public virtual void Awake()
	{
		if (instance)
		{
			Destroy(this);
			return;
		}

		instance = this as T;

        // 親要素があるとDontDestroyOnLoadが機能しないため、親要素を外す
		this.gameObject.transform.parent = null;
        DontDestroyOnLoad(this.gameObject);
	}

	protected virtual void OnDestroy()
	{
		if (ReferenceEquals(this, instance)) instance = null;
	}
}
