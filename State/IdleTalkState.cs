namespace state_pattern.States
{
  // 状態を同一視するためのインターフェース
  public sealed class IdleTalkState : IState
  {
    // シングルトン
    private IdleTalkState() { }
    public static IdleTalkState Instance { get; } = new IdleTalkState();

    public string GetStateText()
    {
      return "IdleTalkStateなう";
    }

    public IEnumerable<string> GetCommand()
    {
      return new List<string> { "Idle", "待ち状態" };
    }

    public void OnEnter(TalkStateMachine talkStateMachine)
    {
      // 何もしない
    }

    public void OnUpdate(TalkStateMachine talkStateMachine)
    {
      // 音声認識開始のトリガーを通知するなどして UserSpeakState に遷移する、など
      talkStateMachine.ChangeState(UserSpeakState.Instance);
    }

    public void OnExit(TalkStateMachine talkStateMachine)
    {
      throw new NotImplementedException();
    }
  }
}
