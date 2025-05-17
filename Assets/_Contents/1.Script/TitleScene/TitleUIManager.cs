using UnityEngine;

public class TitleUIManager : MonoBehaviour
{
    [SerializeField] GameObject[] menuCursor = new GameObject[3];

    public void ChangeMenuCursorImage(int index)
    {
        for (int i = 0; i < menuCursor.Length; i++) menuCursor[i].SetActive(false);

        menuCursor[index].SetActive(true);
    }
}
