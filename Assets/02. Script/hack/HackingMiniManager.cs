using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using URandom = UnityEngine.Random;

public enum GameState { FirstClick, Playing, Finished }

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
    [SerializeField] private float gameTime = 60.0f;
    [SerializeField] private int sequenceLength = 3;
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

    // 🚨 Update 함수를 사용하여 타이머를 관리합니다.
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

    void OnDestroy()
    {
        // Update 함수를 사용하므로 OnDestroy에서 특별히 할 일은 없습니다.
    }

    void InitializeGame(bool newDaemon)
    {
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

    void ApplyMistakePenaltyIfNeeded()
    {
        if (!useMistakePenalty) return;
        timer -= mistakePenaltySeconds;
        if (timer < minTimerAfterPenalty) timer = minTimerAfterPenalty;
        timerText.text = timer.ToString("F2");
        logText.text += $"[PENALTY -{mistakePenaltySeconds}s]\n";
    }

    // 🚨 TimerCoroutine() 함수는 삭제합니다.
}