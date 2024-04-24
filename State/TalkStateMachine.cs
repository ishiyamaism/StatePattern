namespace state_pattern.States
{
  // 状態管理のためのクラス
  public sealed class TalkStateMachine
  {
    private IState _state = new IdleTalkState();
    private readonly string path = "state-information.txt";

    // 状態の通信等をする想定(仮にテキストファイル出力)
    private void OutputResponse(IEnumerable<string> commands)
    {
      File.WriteAllLines(path, _state.GetCommand());
    }

    // State変化監視用のオブザーバー
    public event Action? StateChanged;

    public void Init()
    {
      _state = new IdleTalkState();

      // 状態通信的処理
      OutputResponse(_state.GetCommand());
    }

    // Clientに公開する窓口を作る
    // State開始時
    public void Enter()
    {
      // State開始時
      // 状態を変え、
      _state.OnEnter(this);
    }

    // State変更時
    public void Update()
    {
      // 状態を変え、
      _state.OnUpdate(this);

      // 状態通信的処理
      OutputResponse(_state.GetCommand());
    }

    // State終了時
    public void Exit()
    {
      // State終了時処理
    }

    public string GetText()
    {
      return _state.GetStateText();
    }

    internal void ChangeState(IState state)
    {
      _state = state;
      // State変更時にクライアントに通知
      StateChanged?.Invoke();
    }
  }
}
