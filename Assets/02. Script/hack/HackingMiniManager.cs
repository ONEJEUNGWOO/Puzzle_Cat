using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.SceneManagement;
=======
>>>>>>> parent of 56f9b50 ([add]HackingMiniUI)
using UnityEngine.UI;
using URandom = UnityEngine.Random;

public enum GameState { FirstClick, Playing, Finished }
<<<<<<< HEAD
public enum DifficultyLevel { Easy, Normal, Hard }
=======
>>>>>>> parent of 56f9b50 ([add]HackingMiniUI)

[RequireComponent(typeof(GridLayoutGroup))]
public class HackingMiniManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] public GridLayoutGroup gridPanel;
    [SerializeField] public TextMeshProUGUI bufferText;
    [SerializeField] public TextMeshProUGUI logText;
    [SerializeField] public TextMeshProUGUI timerText;
    [SerializeField] public TextMeshProUGUI infoText;
    [SerializeField] public GameObject cellPrefab;
    [SerializeField] public GameObject exitButton;

    [Header("Color Settings")]
    [SerializeField] public Color normalColor = new(0.5f, 0.5f, 0.5f, 1f);
    [SerializeField] public Color selectedColor = new(0.2f, 0.8f, 0.2f, 1f);
    [SerializeField] public Color highlightColor = new(0.8f, 0.8f, 0.2f, 1f);
    [SerializeField] public Color disabledColor = new(0.2f, 0.2f, 0.2f, 1f);

    [Header("Game Settings")]
<<<<<<< HEAD
    [SerializeField] private DifficultyLevel difficulty = DifficultyLevel.Normal;
    [HideInInspector][SerializeField] private float gameTime = 60.0f;
    [HideInInspector][SerializeField] private int sequenceLength = 3;
=======
    [SerializeField] private float gameTime = 60.0f;
    [SerializeField] private int sequenceLength = 3;
>>>>>>> parent of 56f9b50 ([add]HackingMiniUI)
    [SerializeField] private int gridRows = 7;
    [SerializeField] private int gridCols = 5;
    [SerializeField] private bool reshuffleChangesDaemon = true;

    [Header("Penalty Settings")]
    [SerializeField] private bool useMistakePenalty = true;
    [SerializeField] private float mistakePenaltySeconds = 5f;
    [SerializeField] private float minTimerAfterPenalty = 0f;

    private readonly List<string> hexCodes = new() { "E9", "1C", "BD", "7A", "55" };

    private GameState currentState;
    private string[,] gridData;
    private GridCell[,] cells;
    private List<string> daemonSequence = new();
    private List<string> matchedSequence = new();
    private int matchIndex = 0;

    private int lastRow = -1, lastCol = -1;
    private float timer;

    public event System.Action<bool> OnGameFinished;

    void Start()
    {
        if (gridPanel == null || cellPrefab == null)
        {
            Debug.LogError("[HackingMiniManager] UI 또는 CellPrefab이 연결되지 않았습니다!");
            return;
        }

        if (exitButton != null) exitButton.SetActive(false);

        InitializeGame(newDaemon: true);
    }

<<<<<<< HEAD
=======
    // 🚨 Update 함수를 사용하여 타이머를 관리합니다.
>>>>>>> parent of 56f9b50 ([add]HackingMiniUI)
    void Update()
    {
        if (currentState == GameState.Playing)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F2");

            if (timer <= 0f)
            {
                TimeOutFail();
            }
        }
    }

<<<<<<< HEAD
    void OnDestroy() { }

    void InitializeGame(bool newDaemon)
    {
        switch (difficulty)
        {
            case DifficultyLevel.Easy:
                gameTime = 90f;
                sequenceLength = 2;
                break;
            case DifficultyLevel.Normal:
                gameTime = 60f;
                sequenceLength = 3;
                break;
            case DifficultyLevel.Hard:
                gameTime = 45f;
                sequenceLength = 4;
                break;
        }

=======
    void OnDestroy()
    {
        // Update 함수를 사용하므로 OnDestroy에서 특별히 할 일은 없습니다.
    }

    void InitializeGame(bool newDaemon)
    {
>>>>>>> parent of 56f9b50 ([add]HackingMiniUI)
        gridData = new string[gridRows, gridCols];
        cells = new GridCell[gridRows, gridCols];

        matchedSequence.Clear();
        matchIndex = 0;
        bufferText.text = "";
        logText.text = "";

        currentState = GameState.FirstClick;
        lastRow = -1; lastCol = -1;

        ResetGrid();
        GenerateGrid();

        if (newDaemon || daemonSequence.Count == 0)
            daemonSequence = GenerateDaemon();

        infoText.text = "Daemon: " + string.Join(" ", daemonSequence);

        timer = gameTime;
        timerText.text = timer.ToString("F2");
    }

<<<<<<< HEAD
    public void SetDifficultyAndRestart(string difficulty)
    {
        switch (difficulty.ToLower())
        {
            case "easy":
                gameTime = 90f;
                sequenceLength = 2;
                break;
            case "normal":
                gameTime = 60f;
                sequenceLength = 3;
                break;
            case "hard":
                gameTime = 45f;
                sequenceLength = 4;
                break;
            default:
                Debug.LogWarning("Invalid difficulty level. Setting to Normal.");
                gameTime = 60f;
                sequenceLength = 3;
                break;
        }

        InitializeGame(true);
    }

=======
>>>>>>> parent of 56f9b50 ([add]HackingMiniUI)
    void Reshuffle(bool changeDaemon)
    {
        matchedSequence.Clear();
        matchIndex = 0;
        bufferText.text = "";

        currentState = GameState.FirstClick;
        lastRow = -1; lastCol = -1;

        ResetGrid();
        GenerateGrid();

        if (changeDaemon)
            daemonSequence = GenerateDaemon();

        infoText.text = "Daemon: " + string.Join(" ", daemonSequence);
        logText.text += "[RESHUFFLE]\n";
    }

    void ResetGrid()
    {
        for (int i = gridPanel.transform.childCount - 1; i >= 0; i--)
            Destroy(gridPanel.transform.GetChild(i).gameObject);
    }

    void GenerateGrid()
    {
        gridPanel.constraintCount = gridCols;
<<<<<<< HEAD
=======

>>>>>>> parent of 56f9b50 ([add]HackingMiniUI)
        for (int r = 0; r < gridRows; r++)
        {
            for (int c = 0; c < gridCols; c++)
            {
                string code = hexCodes[URandom.Range(0, hexCodes.Count)];
                gridData[r, c] = code;

                GameObject cellObj = Instantiate(cellPrefab, gridPanel.transform);
                var cell = cellObj.GetComponent<GridCell>();
                int lr = r, lc = c;
                cell.Setup(code, lr, lc, () => OnCellClick(lr, lc));
                cell.SetState(CellState.Normal, normalColor);
                cells[r, c] = cell;
            }
        }
    }
<<<<<<< HEAD
=======

>>>>>>> parent of 56f9b50 ([add]HackingMiniUI)
    List<string> GenerateDaemon()
    {
        var seq = new List<string>();
        for (int i = 0; i < sequenceLength; i++)
            seq.Add(hexCodes[URandom.Range(0, hexCodes.Count)]);
        return seq;
    }
<<<<<<< HEAD
    void OnCellClick(int row, int col)
    {
        if (currentState == GameState.Finished) return;
        string clicked = gridData[row, col];
=======

    void OnCellClick(int row, int col)
    {
        if (currentState == GameState.Finished) return;

        string clicked = gridData[row, col];

>>>>>>> parent of 56f9b50 ([add]HackingMiniUI)
        if (currentState == GameState.FirstClick)
        {
            if (clicked != daemonSequence[0])
            {
                ApplyMistakePenaltyIfNeeded();
                Reshuffle(reshuffleChangesDaemon);
                return;
            }
<<<<<<< HEAD
=======

>>>>>>> parent of 56f9b50 ([add]HackingMiniUI)
            SelectCell(row, col);
            matchedSequence.Add(clicked);
            matchIndex = 1;
            bufferText.text = string.Join(" ", matchedSequence);
            currentState = GameState.Playing;
            UpdateCrossHighlights();
            TryComplete();
            return;
        }
<<<<<<< HEAD
=======

>>>>>>> parent of 56f9b50 ([add]HackingMiniUI)
        bool inCross = (row == lastRow) || (col == lastCol);
        if (!inCross)
        {
            ApplyMistakePenaltyIfNeeded();
            Reshuffle(reshuffleChangesDaemon);
            return;
        }
<<<<<<< HEAD
=======

>>>>>>> parent of 56f9b50 ([add]HackingMiniUI)
        if (clicked != daemonSequence[matchIndex])
        {
            ApplyMistakePenaltyIfNeeded();
            Reshuffle(reshuffleChangesDaemon);
            return;
        }
<<<<<<< HEAD
=======

>>>>>>> parent of 56f9b50 ([add]HackingMiniUI)
        SelectCell(row, col);
        matchedSequence.Add(clicked);
        matchIndex++;
        bufferText.text = string.Join(" ", matchedSequence);
<<<<<<< HEAD
        if (TryComplete()) return;
        UpdateCrossHighlights();
    }
=======

        if (TryComplete()) return;
        UpdateCrossHighlights();
    }

>>>>>>> parent of 56f9b50 ([add]HackingMiniUI)
    void SelectCell(int row, int col)
    {
        cells[row, col].SetState(CellState.Selected, selectedColor);
        logText.text += gridData[row, col] + "\n";
        lastRow = row; lastCol = col;
    }
<<<<<<< HEAD
=======

>>>>>>> parent of 56f9b50 ([add]HackingMiniUI)
    void UpdateCrossHighlights()
    {
        for (int r = 0; r < gridRows; r++)
        {
            for (int c = 0; c < gridCols; c++)
            {
                if (cells[r, c].currentState == CellState.Selected) continue;
<<<<<<< HEAD
=======

>>>>>>> parent of 56f9b50 ([add]HackingMiniUI)
                bool highlight = (r == lastRow) || (c == lastCol);
                cells[r, c].SetState(highlight ? CellState.Highlighted : CellState.Disabled,
                                     highlight ? highlightColor : disabledColor);
            }
        }
    }
<<<<<<< HEAD
=======

>>>>>>> parent of 56f9b50 ([add]HackingMiniUI)
    bool TryComplete()
    {
        if (matchIndex >= daemonSequence.Count)
        {
            SuccessGame();
            return true;
        }
        return false;
    }
<<<<<<< HEAD
    void SuccessGame()
    {
        currentState = GameState.Finished;
        infoText.text += "\n<color=green>SUCCESS!</color>";
        foreach (var cell in cells)
            cell.GetComponent<Button>().interactable = false;
        if (exitButton != null)
            exitButton.SetActive(true);
        OnGameFinished?.Invoke(true);
    }
    void TimeOutFail()
    {
        currentState = GameState.Finished;
        infoText.text += "\n<color=red>ACCESS DENIED</color>\nReason: Time Over... 실패...";
        foreach (var cell in cells)
            cell.GetComponent<Button>().interactable = false;
        if (exitButton != null)
            exitButton.SetActive(true);
        OnGameFinished?.Invoke(false);
    }
=======

    void SuccessGame()
    {
        // 🚨 성공 시 GameState를 Finished로 설정하는 것이 핵심입니다.
        currentState = GameState.Finished;
        infoText.text += "\n<color=green>SUCCESS!</color>";

        // 클릭 무효화
        foreach (var cell in cells)
            cell.GetComponent<Button>().interactable = false;

        // 종료 UI 활성화
        if (exitButton != null)
            exitButton.SetActive(true);

        OnGameFinished?.Invoke(true);
    }

    void TimeOutFail()
    {
        // 🚨 실패 시에도 GameState를 Finished로 설정합니다.
        currentState = GameState.Finished;
        infoText.text += "\n<color=red>ACCESS DENIED</color>\nReason: Time Over... 실패...";

        foreach (var cell in cells)
            cell.GetComponent<Button>().interactable = false;

        if (exitButton != null)
            exitButton.SetActive(true);

        OnGameFinished?.Invoke(false);
    }

>>>>>>> parent of 56f9b50 ([add]HackingMiniUI)
    void ApplyMistakePenaltyIfNeeded()
    {
        if (!useMistakePenalty) return;
        timer -= mistakePenaltySeconds;
        if (timer < minTimerAfterPenalty) timer = minTimerAfterPenalty;
        timerText.text = timer.ToString("F2");
        logText.text += $"[PENALTY -{mistakePenaltySeconds}s]\n";
    }
<<<<<<< HEAD
    public void LoadNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
=======

    // 🚨 TimerCoroutine() 함수는 삭제합니다.
>>>>>>> parent of 56f9b50 ([add]HackingMiniUI)
}