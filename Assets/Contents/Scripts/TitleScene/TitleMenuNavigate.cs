using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TitleMenuNavigate : MonoBehaviour
{
    [SerializeField] private Button _startButton;

    private GameObject _lastSelectedObject;

    public void SelectInitial()
    {
        _startButton.Select();
        _lastSelectedObject = _startButton.gameObject;
    }

    public void NavigateUpdate()
    {
        GameObject current = EventSystem.current.currentSelectedGameObject;

        if (current == null && _lastSelectedObject != null)
        {
            _lastSelectedObject.GetComponent<Button>().Select();
        }
        else if (current != null && current != _lastSelectedObject)
        {
            S_SEManager.Instance.Play("u_cursor");
            _lastSelectedObject = current;
        }
    }
}
