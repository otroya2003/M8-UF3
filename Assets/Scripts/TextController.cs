using System.Linq;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    public void SetText()
    {
        _textMeshPro.text = "Coins: " + gameManager.Coins;
    }
}
