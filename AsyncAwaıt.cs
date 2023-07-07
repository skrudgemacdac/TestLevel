using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncAwaıt : MonoBehaviour
{
    public async void Start()
    {
        static async Task Task1(CancellationToken cancellationToken)
        {
            await Task.Delay(1000, cancellationToken);
            Debug.Log("Task1 completed");
        }

        static async Task Task2(CancellationToken cancellationToken)
        {
            int frameCount = 0;
            while (frameCount < 60 && !cancellationToken.IsCancellationRequested)
            {
                await Task.Yield();
                frameCount++;
            }
            Debug.Log("Task2 completed");
        }

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            Task task1 = Task1(cancellationToken);
            Task task2 = Task2(cancellationToken);

            await Task.WhenAll(task1, task2);

            cancellationTokenSource.Dispose();
    }
}