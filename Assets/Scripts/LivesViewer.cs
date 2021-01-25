using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesViewer : MonoBehaviour
{
    private Text _livesText;
    // Start is called before the first frame update
    void Start()
    {
        _livesText = GetComponent<Text>();
        GameManager.getInstance().LivesChanged += UpdateLivesUI;
        UpdateLivesUI();
    }

    private void UpdateLivesUI() {
        _livesText.text = GameManager.getInstance().PlayerLives.ToString();
    }

    private void UpdateLivesUI(int lives) {
        _livesText.text = lives.ToString();
    }

    private void OnDestroy() {
        GameManager.getInstance().LivesChanged -= UpdateLivesUI;
    }
}
