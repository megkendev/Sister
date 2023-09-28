using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManagement : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    private void OnEnable()
    {
        Actions.updatePoints += updateScore;
        Actions.clearPoints += clearScore;
        Actions.diePoints += dieScore;
    }

    private void OnDisable()
    {
        Actions.updatePoints -= updateScore;
        Actions.clearPoints -= clearScore;
        Actions.diePoints -= dieScore;
    }

    private void updateScore()
    {
        PointsManager.Instance.Points++;
    }

    private void clearScore()
    {
        PointsManager.Instance.Points = 0;
    }

    private void dieScore()
    {
        PointsManager.Instance.Points = PointsManager.Instance.Points - 5;
    }

    void Update()
    {
        ScoreText.text = PointsManager.Instance.Points.ToString();
    }
}