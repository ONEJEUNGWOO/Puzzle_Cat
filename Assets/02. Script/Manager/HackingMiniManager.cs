using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using URandom = UnityEngine.Random;

public enum GameState { FirstClick, Playing, Finished }
public enum DifficultyLevel { Easy, Normal, Hard }

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
    [SerializeField] private DifficultyLevel difficulty = DifficultyLevel.Normal;
    [HideInInspector][SerializeField] private float gameTime = 60.0f; // 🚨 인스펙터에서 숨김
    [HideInInspector][SerializeField] private int sequenceLength = 3; // 🚨 인스펙터에서 숨김
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

        // 🚨 난이도를 설정한 뒤 게임을 다시 초기화합니다.
        InitializeGame(true);
    }


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

    List<string> GenerateDaemon()
    {
        var seq = new List<string>();
        for (int i = 0; i < sequenceLength; i++)
            seq.Add(hexCodes[URandom.Range(0, hexCodes.Count)]);
        return seq;
    }

    void OnCellClick(int row, int col)
    {
        if (currentState == GameState.Finished) return;

        string clicked = gridData[row, col];

        if (currentState == GameState.FirstClick)
        {
            if (clicked != daemonSequence[0])
            {
                ApplyMistakePenaltyIfNeeded();
                Reshuffle(reshuffleChangesDaemon);
                return;
            }

            SelectCell(row, col);
            matchedSequence.Add(clicked);
            matchIndex = 1;
            bufferText.text = string.Join(" ", matchedSequence);
            currentState = GameState.Playing;
            UpdateCrossHighlights();
            TryComplete();
            return;
        }

        bool inCross = (row == lastRow) || (col == lastCol);
        if (!inCross)
        {
            ApplyMistakePenaltyIfNeeded();
            Reshuffle(reshuffleChangesDaemon);
            return;
        }

        if (clicked != daemonSequence[matchIndex])
        {
            ApplyMistakePenaltyIfNeeded();
            Reshuffle(reshuffleChangesDaemon);
            return;
        }

        SelectCell(row, col);
        matchedSequence.Add(clicked);
        matchIndex++;
        bufferText.text = string.Join(" ", matchedSequence);

        if (TryComplete()) return;
        UpdateCrossHighlights();
    }

    void SelectCell(int row, int col)
    {
        cells[row, col].SetState(CellState.Selected, selectedColor);
        logText.text += gridData[row, col] + "\n";
        lastRow = row; lastCol = col;
    }

    void UpdateCrossHighlights()
    {
        for (int r = 0; r < gridRows; r++)
        {
            for (int c = 0; c < gridCols; c++)
            {
                if (cells[r, c].currentState == CellState.Selected) continue;

                bool highlight = (r == lastRow) || (c == lastCol);
                cells[r, c].SetState(highlight ? CellState.Highlighted : CellState.Disabled,
                                     highlight ? highlightColor : disabledColor);
            }
        }
    }

    bool TryComplete()
    {
        if (matchIndex >= daemonSequence.Count)
        {
            SuccessGame();
            return true;
        }
        return false;
    }

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

    void ApplyMistakePenaltyIfNeeded()
    {
        if (!useMistakePenalty) return;
        timer -= mistakePenaltySeconds;
        if (timer < minTimerAfterPenalty) timer = minTimerAfterPenalty;
        timerText.text = timer.ToString("F2");
        logText.text += $"[PENALTY -{mistakePenaltySeconds}s]\n";
    }

    public void LoadNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}