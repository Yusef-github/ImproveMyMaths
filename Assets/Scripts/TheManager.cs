using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TheManager : MonoBehaviour
{
    /// <summary>
    /// Classes Called
    /// </summary>
    [SerializeField] private SoundsManager soundsManagerClass;



    /// <summary>
    /// UserInpField: Getting a value from the user, and checking if its equal to (Sum).
    /// 
    /// Sum: the total value of (FirstGeneratedNumber) & (SecondGeneratedNumber).
    /// FirstGeneratedNumber: The first randomized number (the one on the left).
    /// SecondGeneratedNumber: The second randomized number (the one on the right).
    /// CorrectAnswersCount: The value of the correct answers entered by the user.
    /// WrongAnswersCount: The value of the wrong answers entered by the user.
    /// 
    /// Since there are two numbers that are being added/subtracted, SO
    /// Text_Nb1: A text showing (FirstGeneratedNumber).
    /// Text_Nb2: A text showing (SecondGeneratedNumber).
    /// Text_CorrectAnswersCount: A text showing (CorrectAnswersCount).
    /// Text_WrongAnswersCount: A text showing (WrongAnswersCount).
    /// </summary>
    [SerializeField] private TMP_InputField UserInpField;
    private int Sum, FirstGeneratedNumber, SecondGeneratedNumber, CorrectAnswersCount, WrongAnswersCount;
    [SerializeField] private TextMeshProUGUI Text_Nb1, Text_Nb2, Text_CorrectAnswersCount, Text_WrongAnswersCount;



    /// <summary>
    /// Pressing this button twice leads to animation error, so I disabled it after game is done.
    /// </summary>
    [SerializeField] private Button SubmitButton;



    /// <summary>
    /// GameMode: It will be equal to 1(AddMode) or 2(SubMode) depending on users choice.
    /// AddMode = 1: In case the user have chosen the addition mode the ((GameMode) will be equal to 1 too).
    /// SubMode = 2: In case the user have chosen the subtraction mode the ((GameMode) will be equal to 2 too).
    /// </summary>
    private int GameMode;
    private readonly int AddMode = 1, SubMode = 2;



    /// <summary>
    /// AddIcon: It's a (+ icon) that will be shown if the user chooses (AddMode).
    /// SubIcon: It's a (- icon) that will be shown if the user chooses (SubMode).
    /// </summary>
    [SerializeField] private GameObject AddIcon, SubIcon;



    /// <summary>
    /// GameDifficulty: It will be equal to 1(Easy), 2(Normal), or 3(Hard) depending on users choice.
    /// NoDifficulty = 0: In case of reseting and platin g new round, the (GameDifficulty) should be equal
    /// to 0 so it's not meant to be any other real game difficulty.
    /// Easy = 1: In case the user have chosen the easy mode the ((GameDifficulty) will be equal to 1 too).
    /// Normal = 2: In case the user have chosen the normal mode the ((GameDifficulty) will be equal to 1 too).
    /// Hard = 3: In case the user have chosen the hard mode the ((GameDifficulty) will be equal to 1 too).
    /// </summary>
    private int GameDifficulty;
    private readonly int NoDifficulty = 0, Easy = 1, Normal = 2, Hard = 3;



    /// <summary>
    /// SetsLeft_Int = 10: The sets the user will play, 10 by default.
    /// Score_Int: the score the user will get after answering all qustions.
    /// SetsLeft_Text: A text for (SetsLeft_Int).
    /// Score_Text: A text for (Score_Int).
    /// </summary>
    private int SetsLeft_Int = 10, Score_Int;
    [SerializeField] private TextMeshProUGUI SetsLeft_Text, Score_Text;



    /// <summary>
    /// ScorePanel_Animator: A animator controller that will control the score panel at the end.
    /// FinalMsg: A msg that will be displayed to the user after getting a specific score.
    /// </summary>
    [SerializeField] private Animator ScorePanel_Animator;
    [SerializeField] private TextMeshProUGUI FinalMsg;



    /// <summary>
    /// Set to check whether the user is actually playing the game (Inside Game Panel) or not.
    /// </summary>
    private bool InStartPanel = true, InChooseModePanel, GameOn, InYouSureTextBox, InScorePanel;
    [SerializeField] private GameObject StartPanel, ChooseModePanel, GamePanel, ScorePanel;
    [SerializeField] private GameObject YouSureTextBox;


    /// <summary>
    /// Application.targetFrameRate --> To manage frame rate.
    /// </summary>
    private void Awake() => Application.targetFrameRate = 60;
    private void Update()
    {
        /// <summary>
        /// (InStartPanel) is true by default so doing the go backward movement leads to quitting the game.
        /// </summary>
        if (Input.GetKey(KeyCode.Escape) && InStartPanel == true)
        {
            Application.Quit();
            return;
        }


        /// <summary>
        /// When (InChooseModePanel) is true and the user do the go backward movement, this leads to go back to the start panel, So:
        /// (InStartPanel) is set to be true.
        /// (StartPanel) which has been activated.
        /// 
        /// (InChooseModePanel) set to be false.
        /// (ChooseModePanel) has been deactivated.
        /// 
        /// return; --> to avoid any other if statment from being compiled.
        /// </summary>
        if (Input.GetKey(KeyCode.Escape) && InChooseModePanel == true)
        {
            InStartPanel = true;
            StartPanel.SetActive(true);

            InChooseModePanel = false;
            ChooseModePanel.SetActive(false);

            return;
        }


        /// <summary>
        /// When (GameOn) is true and (InYouSureTextBox) is false and the user do the go backward movement, this leads to activate(YouSureTextBox), So:
        /// (InYouSureTextBox) is set to be true.
        /// (YouSureTextBox) which has been activated.
        /// 
        /// (GameOn) set to be false.
        /// (GamePanel) has been deactivated.
        /// 
        /// return; --> to avoid any other if statment from being compiled.
        /// </summary>
        if (Input.GetKey(KeyCode.Escape) && GameOn == true && InYouSureTextBox == false)
        {
            InYouSureTextBox = true;
            YouSureTextBox.SetActive(true);

            GameOn = false;
            GamePanel.SetActive(false);

            return;
        }


        /// <summary>
        /// When (InYouSureTextBox) is true and the user do the go backward movement, this leads to deactivating(YouSureTextBox), So:
        /// (GameOn) is set to be true.
        /// (GamePanel) which has been activated.
        /// 
        /// (InYouSureTextBox) set to be false.
        /// (YouSureTextBox) has been deactivated.
        /// 
        /// return; --> to avoid any other if statment from being compiled.
        /// </summary>
        if (Input.GetKey(KeyCode.Escape) && InYouSureTextBox == true)
        {
            GameOn = true;
            GamePanel.SetActive(true);

            InYouSureTextBox = false;
            YouSureTextBox.SetActive(false);

            return;
        }


        /// <summary>
        /// When (InScorePanel) is true and the user do the go backward movement, this leads to go back to the (ChooseModePanel), So:
        /// (InScorePanel) set to be false since every thing will be reseted by using the (ResetEveryThing();) method.
        /// return; --> to avoid any other if statment from being compiled.
        /// </summary>
        if (Input.GetKey(KeyCode.Escape) && InScorePanel == true)
        {
            InScorePanel = false;
            ResetEveryThing();
            return;
        }
    }



    /// <summary>
    /// IconManager: this method is used to enable the (+) or (-) icon depending on the user chosen mode.
    /// When user choose the (AddMode), the enabled icon is (+) and (-) will be disabled.
    /// When user choose the (SubMode), the enabled icon is (-) and (+) will be enabled.
    /// </summary>
    public void IconManager()
    {
        if (GameMode == AddMode)
        {
            AddIcon.SetActive(true);
            SubIcon.SetActive(false);
        }
        if (GameMode == SubMode)
        {
            SubIcon.SetActive(true);
            AddIcon.SetActive(false);
        }
    }



    /// <summary>
    /// A method that will be called on pressing easy, normal, or hard buttons under addition mode button.
    /// (GameMode) is now equal to 1(AddMode).
    /// </summary>
    public void AddModeSelector() => GameMode = AddMode;

    /// <summary>
    /// A method that will be called on pressing easy, normal, or hard buttons under subtraction mode button.
    /// (GameMode) is now equal to 2(SubMode).
    /// </summary>
    public void SubModeSelector() => GameMode = SubMode;



    public void EnteringChooseModePanel()
    {
        InStartPanel = false;
        InChooseModePanel = true;
    }
    public void EnteringGamePanel()
    {
        GameOn = true;
        InChooseModePanel = false;
    }
    public void EnteringYouSureTextBox()
    {
        GameOn = false;
        InYouSureTextBox = true;
    }
    private void EnteringScorePanel()
    {
        GameOn = false;
        InScorePanel = true;
    }


    /// <summary>
    /// A method that will be called once after pressing easy, normal, or hard buttons under
    /// addition or subtraction modes button.
    /// When user choose (Easy) difficulty, the (GameDifficulty) is now (Easy) so the (FirstGeneratedNumber) &
    /// (SecondGeneratedNumber) will have a random value between 20 & 99.
    /// When user choose (Normal) difficulty, the (GameDifficulty) is now (Normal) so the (FirstGeneratedNumber) &
    /// (SecondGeneratedNumber) will have a random value between 20 & 99.
    /// otherwise, the user choosen (Hard) difficulty (since its the last option), the (GameDifficulty) is now (hard)
    /// so the (FirstGeneratedNumber) & (SecondGeneratedNumber) will have a random value between 100 & 499.
    /// 
    /// Checking if the (GameMode) equal to (SubMode) so (Sum) will be equal to (FirstGeneratedNumber) &
    /// (SecondGeneratedNumber) added together.
    /// Checking if the (GameMode) equal to (AddMode) so (Sum) will be equal to (FirstGeneratedNumber) &
    /// (SecondGeneratedNumber) subtracted together.
    /// 
    /// Since I'm updating (FirstGeneratedNumber), I'm displaying it in the (Text_Nb1).text .
    /// Since I'm updating (SecondGeneratedNumber), I'm displaying it in the (Text_Nb2).text .
    /// .ToString(); --> Used to converts (FirstGeneratedNumber) & (SecondGeneratedNumber)to their string representation.
    /// </summary>
    public void GenerateNumbers()
    {
        if (GameDifficulty == Easy)
        {
            FirstGeneratedNumber = Random.Range(2, 25);
            SecondGeneratedNumber = Random.Range(2, 25);
        }// Easy Mode
        else if (GameDifficulty == Normal)
        {
            FirstGeneratedNumber = Random.Range(20, 100);
            SecondGeneratedNumber = Random.Range(20, 100);
        }// Normal Mode
        else
        {
            FirstGeneratedNumber = Random.Range(100, 500);
            SecondGeneratedNumber = Random.Range(100, 500);
        }// Hard Mode


        if (GameMode == AddMode) Sum = FirstGeneratedNumber + SecondGeneratedNumber;
        if (GameMode == SubMode) Sum = FirstGeneratedNumber - SecondGeneratedNumber;

        Text_Nb1.text = FirstGeneratedNumber.ToString();
        Text_Nb2.text = SecondGeneratedNumber.ToString();
    }



    /// <summary>
    /// A method that will be called once after pressing submit button.
    /// if (UserInpField.text == Sum.ToString()) --> if answer is correct.
    /// CorrectAnswersCount++; --> it will get increased by 1.
    /// soundsManagerClass.CorrectAnswer(); --> correct answer audio.
    /// 
    /// otherwise, the answer is wrong, so,
    /// WrongAnswersCount++; --> it will be increased by 1.
    /// soundsManagerClass.WrongAnswer(); --> wrong answer audio.
    /// 
    /// SetsLeft_Int--; --> sets are 10 in the first of the game, it will be reduced by 1 each time the user
    /// press on the submit button.
    /// UserInpField.text = ""; --> Its like reseting the inputField value so the user will not need to erase
    /// the old value before writing a new one. 
    /// </summary>
    public void Submit()
    {
        if (UserInpField.text == Sum.ToString())
        {
            CorrectAnswersCount++;
            soundsManagerClass.CorrectAnswer();
        }
        else
        {
            WrongAnswersCount++;
            soundsManagerClass.WrongAnswer();
        }

        SetsLeft_Int--;
        UserInpField.text = "";

        ChangeTexts();
        CheckIfGameEnded();
    }



    /// <summary>
    /// Updating the (Text_CorrectAnswersCount), (Text_WrongAnswersCount), (SetsLeft_Text) & giving them the
    /// (CorrectAnswersCount), (WrongAnswersCount), & (SetsLeft_Int) since these values have been changed before calling this method.
    /// </summary>
    public void ChangeTexts()
    {
        Text_CorrectAnswersCount.text = "You have answered " + CorrectAnswersCount.ToString() + " correct answers.";
        Text_WrongAnswersCount.text = "You have answered " + WrongAnswersCount.ToString() + " wrong answers.";

        SetsLeft_Text.text = SetsLeft_Int.ToString("0") + " LEFT!";
    }



    /// <summary>
    /// since (SetsLeft_Int) is being changed before calling this method, I'm checking if it's more that 0 the user will continue by calling
    /// (GenerateNumbers();) OR calling (GameEnded();) if it's less than or equal to 0.
    /// </summary>
    private void CheckIfGameEnded()
    {
        if (SetsLeft_Int > 0)
            GenerateNumbers();
        else GameEnded();
    }


    
    /// <summary>
    /// Called by buttons, Set to be enabled when the user is playing the game (Inside Game Panel).
    /// </summary>
    public void GameIsOn() => GameOn = true;



    /// <summary>
    /// To assign the (GameDifficulty) value to (Easy) value.
    /// </summary>
    public void EasyMode() => GameDifficulty = Easy;

    /// <summary>
    /// To assign the (GameDifficulty) value to (Normal) value.
    /// </summary>
    public void NormalMode() => GameDifficulty = Normal;

    /// <summary>
    /// To assign the (GameDifficulty) value to (Hard) value.
    /// </summary>
    public void HardMode() => GameDifficulty = Hard;



    /// <summary>
    /// SubmitButton.enabled = false; --> set to false to disable the following error:
    /// when the user press on the submit button twice the animation will stick and the game will not function well duo to this error.
    /// 
    /// Score_Int = (CorrectAnswersCount * 10); --> Multiplying (CorrectAnswersCount) by 10 since the total is over 100.
    /// Score_Text.text = Score_Int.ToString() + "/ 100"; --> Displaying the (Score_Int).
    /// ScorePanel_Animator.SetTrigger("PopUpScorePanel"); --> Animating the ScorePanel.
    /// GameOn = false; --> Setting it to false since the user is out of the GamePanel.
    /// 
    /// Texts --> A specific msg will be displayed depending on the user's score.
    /// </summary>
    public void GameEnded()
    {
        EnteringScorePanel();
        SubmitButton.enabled = false;
        Score_Int = (CorrectAnswersCount * 10);
        Score_Text.text = Score_Int.ToString() + "/ 100";
        ScorePanel_Animator.SetTrigger("PopUpScorePanel");
        GameOn = false;
        #region Texts
        //Easy Mode
        if (GameDifficulty == Easy && Score_Int >= 0 && Score_Int <= 30) FinalMsg.text = "You Can Do It! Let's Try Again!";
        if (GameDifficulty == Easy && Score_Int > 30 && Score_Int <= 65) FinalMsg.text = "Keep Trying! You can do It.";
        if (GameDifficulty == Easy && Score_Int > 65 && Score_Int <= 90) FinalMsg.text = "Great, Not Too Far From Getting The Perfect Grade.";
        if (GameDifficulty == Easy && Score_Int > 90 && Score_Int <= 100) FinalMsg.text = "Perfect! Now, Let's Try The Normal Mode!";

        //Normal Mode
        if (GameDifficulty == Normal && Score_Int >= 0 && Score_Int <= 30) FinalMsg.text = "You Can Do Better! Let's Try Again, But This Time Harder!";
        if (GameDifficulty == Normal && Score_Int > 30 && Score_Int <= 65) FinalMsg.text = "Reaching a Better Score Is a Matter of Time!";
        if (GameDifficulty == Normal && Score_Int > 65 && Score_Int <= 90) FinalMsg.text = "Great Grade In Normal Mode! Work Harder To Get The Perfect Grade!";
        if (GameDifficulty == Normal && Score_Int > 90 && Score_Int <= 100) FinalMsg.text = "Such a Perfect Grade! Now, Try Your Skills In The Hard Mode! It's Much More Challenging!";

        //Hard Mode
        if (GameDifficulty == Hard && Score_Int >= 0 && Score_Int <= 30) FinalMsg.text = "You Can Always Try Again For a Better Score!";
        if (GameDifficulty == Hard && Score_Int > 30 && Score_Int <= 65) FinalMsg.text = "You Will Reach a Better Score If you Try Harder!";
        if (GameDifficulty == Hard && Score_Int > 65 && Score_Int <= 90) FinalMsg.text = "Awesome Grade In Hard Mode! 'Perfect Grade' Is Not Far Away From You, Try Harder!";
        if (GameDifficulty == Hard && Score_Int > 90 && Score_Int <= 100) FinalMsg.text = "WOW!! A Perfect Grade In 'Hard Mode'! I Will Tell You a Secret, 'Extreme' Mode Is Coming Soon!!";
        #endregion
    }



    /// <summary>
    /// In this method , I'm reseting everything to its defult value.
    /// </summary>
    public void ResetEveryThing()
    {
        GameOn = false;
        SetsLeft_Int = 10;
        FinalMsg.text = "";
        Score_Text.text = "";
        WrongAnswersCount = 0;
        CorrectAnswersCount = 0;
        SetsLeft_Text.text = "";
        SubmitButton.enabled = true;
        GameDifficulty = NoDifficulty;
        ScorePanel_Animator.SetTrigger("IdleScorePanel");
    }
}