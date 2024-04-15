using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private List<QuizDataScriptable> quizData;
    [SerializeField] private float timeLimit = 30f;
    private List<Question> questions;

    private Question selectedQuestion;
    private GameStatus gameStatus = GameStatus.Next;
    //private Question selectedQuestion = new Question();
    private QuizDataScriptable dataScriptable;
    private float currentTime;
    private int lifeRemaining = 3;
    private int scoreCount = 0;

    //public GameStatus { get { return gameStatus; } }
    public GameStatus GameStatus { get { return gameStatus; } }


    // Start is called before the first frame update
    public void StartGame(int index)
    {
        scoreCount = 0;
        currentTime = timeLimit;
        lifeRemaining = 3;
        questions = new List<Question>();

        for(int i = 0; i < quizData[index].questions.Count; i++){
            questions.Add(quizData[index].questions[i]);
        }
        
        //questions = quizData[index].questions;
        SelectQuestion(); 
        gameStatus = GameStatus.Playing;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStatus == GameStatus.Playing){
            currentTime -= Time.deltaTime;
            SetTimer(currentTime);
        }
    }

   private void SelectQuestion(){
        int val = UnityEngine.Random.Range(0, questions.Count);
        selectedQuestion = questions[val];
        quizUI.SetQuestion(selectedQuestion);
        questions.RemoveAt(val);
    }

    private void SetTimer(float value){
        TimeSpan time = TimeSpan.FromSeconds(value);
        quizUI.TimerText.text = "Time" + time.ToString("mm':'ss");

        if (currentTime <= 0){

        }
    }

    public bool Answer(string answered){
        bool correctAns = false;

        if(answered == selectedQuestion.correctAns){
            //yes
            correctAns = true;
            scoreCount += 50;
            quizUI.ScoreText.text = "Score:" + scoreCount;
        }
        else{
            //no
            lifeRemaining--;
            quizUI.ReduceLife(lifeRemaining);

            if (lifeRemaining <= 0){
                gameStatus = GameStatus.Next;
                quizUI.GameOverPanel.SetActive(true);
            }
        }

        if (gameStatus == GameStatus.Playing){
            if (questions.Count > 0){
                Invoke("SelectQuestion", 0.4f);
            }
            else{
                gameStatus = GameStatus.Next;
                quizUI.GameOverPanel.SetActive(true);
            }
        }

        return correctAns;
    }
}

[System.Serializable]

public class Question{
    public string questionInfo;
    public QuestionType questionType;
    public Sprite questionImg;
    public AudioClip questionClip;
    public UnityEngine.Video.VideoClip questionVideo;
    public List<string> options;
    public string correctAns;
}

[System.Serializable]

public enum QuestionType{
    TEXT,
    IMAGE,
    VIDEO,
    AUDIO
}

[System.Serializable]

public enum GameStatus{
    Playing,
    Next
}