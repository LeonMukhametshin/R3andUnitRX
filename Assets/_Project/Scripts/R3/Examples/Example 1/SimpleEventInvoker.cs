using R3;
using UnityEngine;
using UnityEngine.UI;

public class SimpleEventInvoker : MonoBehaviour
{
    [SerializeField] private Button m_button;

    public readonly Subject<Unit> onSimpleR3Event = new();

    private void Awake()
    {
        m_button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
       onSimpleR3Event.OnNext(Unit.Default); 
    }
}