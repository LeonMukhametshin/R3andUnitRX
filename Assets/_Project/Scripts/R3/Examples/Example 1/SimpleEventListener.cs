using R3;
using UnityEngine;

public class SimpleEventListener : MonoBehaviour
{
    [SerializeField] private SimpleEventInvoker m_invoker;

    private CompositeDisposable m_disposable = new();

    private void Awake()
    {
        m_invoker
            .onSimpleR3Event
            .Subscribe(_ => OnSimpleR3Event())
            .AddTo(m_disposable);
    }

    private void OnSimpleR3Event()
    {
        Debug.Log("R3 event handled");
    }

    private void OnDestroy()
    {
        m_disposable.Dispose();
    }
}