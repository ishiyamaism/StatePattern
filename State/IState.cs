namespace state_pattern.States
{
  // 状態を同一視するためのインターフェース
  public interface IState
  {
    void OnEnter(TalkStateMachine talkStateMachine);
    void OnUpdate(TalkStateMachine talkStateMachine);
    void OnExit(TalkStateMachine talkStateMachine);

    string GetStateText();

    // State固有の何らかの情報を取得するなど用
    IEnumerable<string> GetCommand();


  }
}
