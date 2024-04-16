using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private Text questionText, scoreText, timerText;
    [SerializeField] private List<Image> lifeImageList;
    [SerializeField] private GameObject gameOverPanel, mainMenuPanel, GameMenuPanel;
    [SerializeField] private Image questionImage;
    [SerializeField] private UnityEngine.Video.VideoPlayer questionVideo;
    [SerializeField] private AudioSource questionAudio;
    [SerializeField] private List<Button> options, uiButtons;
    [SerializeField] private Color correctCol, wrongCol, normalCol;

    private Question question;
    private bool answered;
    private float audioLength;

    public Text ScoreText { get { return scoreText; } }

    public Text TimerText { get { return timerText; } }

    public GameObject GameOverPanel { get { return gameOverPanel; } }
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < options.Count; i++){
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }  

        for(int i = 0; i < uiButtons.Count; i++){
            Button localBtn = uiButtons[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        } 
    }

    public void SetQuestion(Question question){
        this.question = question;

        switch (question.questionType){
            case QuestionType.TEXT:
                questionImage.transform.parent.gameObject.SetActive(false);
                break;
            case QuestionType.IMAGE:
                ImageHolder();
                questionImage.transform.gameObject.SetActive(true);
                questionImage.sprite = question.questionImg;
                break;
            case QuestionType.VIDEO:
                ImageHolder();
                questionVideo.transform.gameObject.SetActive(true);
                questionVideo.clip = question.questionVideo;
                questionVideo.Play();
                break;
            case QuestionType.AUDIO:
                ImageHolder();
                questionAudio.transform.gameObject.SetActive(true);
                audioLength = question.questionClip.length;
                StartCoroutine(PlayAudio());
                break;    
        }

        questionText.text = question.questionInfo;

        //List<string> answerList = ShuffleList.ShuffleListItems<string>(question.options);
        List<string> answerList = question.options;

        for(int i = 0; i < options.Count; i++){
            options[i].GetComponentInChildren<Text>().text = answerList[i];
            options[i].name = answerList[i];
            options[i].image.color = normalCol;
        }
        answered = false;
    }

    IEnumerator PlayAudio(){
        if (question.questionType == QuestionType.AUDIO){
            questionAudio.PlayOneShot(question.questionClip);
            yield return new WaitForSeconds(audioLength + 0.5f);
            StartCoroutine(PlayAudio());
        }
        else{
            StopCoroutine(PlayAudio());
            yield return null;
        }
    }

    void ImageHolder(){
        questionImage.transform.parent.gameObject.SetActive(true);
        questionImage.transform.gameObject.SetActive(false);
        questionAudio.transform.gameObject.SetActive(false);
        questionVideo.transform.gameObject.SetActive(false);

    }

    private void OnClick(Button btn){
        if (quizManager.GameStatus == GameStatus.Playing){

        if(!answered){
            answered = true;
            bool val = quizManager.Answer(btn.name);

            if(val){
                btn.image.color = correctCol;
            }
            else{
                btn.image.color = wrongCol;
            }
        }
    }
    switch (btn.name){
        case "AND/OR":
            quizManager.StartGame(0);
            mainMenuPanel.SetActive(false);
            GameMenuPanel.SetActive(true);
            break;
        case "NOR":
            quizManager.StartGame(1);
            mainMenuPanel.SetActive(false);
            GameMenuPanel.SetActive(true);
            break;
        //case "Mix":
            //break;        
    }
    }

    public void ReduceLife(int index){
        lifeImageList[index].color = wrongCol;
    }

    // Update is called once per frame (currently not used).
    void Update()
    {
        
    }
}
