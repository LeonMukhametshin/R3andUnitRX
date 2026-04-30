using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ParamsEventInvoker : MonoBehaviour
{
    [SerializeField] private Button m_button;
    [SerializeField] private TextMeshProUGUI m_buttonText;

    public readonly Subject<int> paramsR3Event = new();

    private int m_counter = 0;

    private void Awake()
    {
        m_button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        m_counter++;
        m_buttonText.text = m_counter.ToString();
        paramsR3Event.OnNext(m_counter); 
    }
}