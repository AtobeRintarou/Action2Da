using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI を操作するために追加している

/// <summary>
/// ゲーム全体を管理するクラス。
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("シーンをロードするコンポーネント")]
    [SerializeField] SceneLoader _sceneLoader = null;
    [Header("残機数")]
    [SerializeField] int _life = 3;
    /// <summary>残機表示をする PlayerCounter を保持しておく変数</summary>
    PlayerCounter _playerCounter;
    [Header("GameOver 表示用 Text")]
    [SerializeField] Text _gameoverText = null;
    /// <summary>ゲームの状態</summary>
    GameState _status = GameState.NonInitialized;

    private static GameManager _manager;

    private float _startTime;
    private float _resultTime;
    private static float _score;
    public float ResultTime { get => _resultTime; private set => _resultTime = value; }
    public static GameManager Instance { get => _manager; private set => _manager = value; }
    public int Score { get; set; }
    void Start()
    {
        StartGame();
        // ゲームオーバーの表示を消す
        if (_gameoverText)
        {
            _gameoverText.enabled = false;
        }

        _playerCounter = GetComponent<PlayerCounter>();
    }

    void Update()
    {
        switch (_status)   // ゲームの状態によって処理を分ける
        {
            case GameState.NonInitialized:
                Debug.Log("Initialize.");
                _status = GameState.Initialized;   // ステータスを初期化済みにする
                _playerCounter.Refresh(_life);    // 残機表示を更新する
                break;
            case GameState.Initialized:   // 待つ
                Debug.Log("Game Start.");
                _status = GameState.InGame;   // ステータスをゲーム中にする
                break;
            case GameState.PlayerDead:
                // 残機がなかったらゲームオーバーを表示する
                if (_gameoverText && _life < 1)
                {
                    _gameoverText.enabled = true;
                }

                
                if (_life > 0) // 残機がまだある場合
                {
                    Debug.Log("Restart Game.");
                    _status = GameState.NonInitialized;   // 初期化するためにステータスを更新する
                }
                else
                {
                    GameOver(); // 残機がもうない場合はゲームオーバーにする
                }
                break;
        }
    }

    /// <summary>
    /// プレイヤーがやられた時、外部から呼ばれる関数
    /// </summary>
    public void PlayerDead()
    {
        Debug.Log("Player Dead.");
        _life -= 1;    // 残機を減らす
        _status = GameState.PlayerDead;   // ステータスをプレイヤーがやられた状態に更新する
    }

    /// <summary>
    /// ゲームオーバー時に呼び出す
    /// </summary>
    void GameOver()
    {
        ResultTime = Time.time - _startTime;
        Debug.Log("Game over. Load scene.");
        if (_sceneLoader)
        {
            _sceneLoader.LoadScene();
        }
    }
    public void StartGame()
    {
        _startTime = Time.time;
        Score = 0;
    }
}


/// <summary>
/// ゲームの状態を表す列挙型
/// </summary>
enum GameState
{
    /// <summary>ゲーム初期化前</summary>
    NonInitialized,
    /// <summary>ゲーム初期化済み、ゲーム開始前</summary>
    Initialized,
    /// <summary>ゲーム中</summary>
    InGame,
    /// <summary>プレイヤーがやられた</summary>
    PlayerDead,
}