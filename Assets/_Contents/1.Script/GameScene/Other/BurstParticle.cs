using UnityEngine;
using Cysharp.Threading.Tasks;

public class BurstParticle : MonoBehaviour
{
    private const float DESTROY_TIME = 4.5f;

    private async void Start()
    {
        await UniTask.WaitForSeconds(DESTROY_TIME);

        Destroy(this.gameObject);
    }
}
