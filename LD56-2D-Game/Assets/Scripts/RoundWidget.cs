using TMPro;
using UnityEngine;

public class RoundWidget : MonoBehaviour
{
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI scoreText;
    int DisplayScore = 0;
    int TargetScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.RoundStarted.AddListener(UpdateRoundText);
        ScoreManager.PointsAddedEvent.AddListener(UpdateScore);
    }


    void OnDisable()
    {
        GameManager.Instance.RoundStarted.RemoveListener(UpdateRoundText);
        ScoreManager.PointsAddedEvent.RemoveListener(UpdateScore);
    }
    private void UpdateScore(int addedPoints)
    {
        TargetScore = ScoreManager.Instance.CurrentRoundScore;
        LeanTween.cancel(scoreText.gameObject);
        DisplayScore = TargetScore - addedPoints;
        LeanTween.value(scoreText.gameObject, DisplayScore, TargetScore, 0.5f).setEaseOutCubic().setOnUpdate((float n) =>
        {
            scoreText.text = ((int)n).ToString();
        }).setOnComplete(() => scoreText.text = TargetScore.ToString());
        scoreText.transform.localScale *= 1.05f;
        scoreText.transform.Rotate(Vector3.forward, Random.Range(-5, 5));
    }

    private void UpdateRoundText()
    {
        roundText.text = "Day " + GameManager.Instance.Day.ToString() + ":";
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.transform.rotation = Quaternion.Lerp(scoreText.transform.rotation, Quaternion.Euler(Vector3.zero), 1f * Time.deltaTime);
        scoreText.transform.localScale = Vector3.Lerp(scoreText.transform.localScale, Vector3.one, 1f * Time.deltaTime);
    }
}
