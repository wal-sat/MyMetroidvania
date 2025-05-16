using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public void ChangeScaleX(float scaleX)
    {
        transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
    }
}
