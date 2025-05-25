using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class BurstParticle : MonoBehaviour
{
    private const float DestroyTime = 4.5f;

    private async void Start()
    {
        try
        {
            var token = this.GetCancellationTokenOnDestroy();

            await UniTask.WaitForSeconds(DestroyTime, cancellationToken: token);

            Destroy(this.gameObject);
        }
        catch (OperationCanceledException)
        {
            ;
        }
    }
}
