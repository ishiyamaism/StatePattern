using state_pattern.WebRequest;

namespace state_pattern.States
{
  public sealed class UserSpeakState : IState
  {
    // シングルトン
    private UserSpeakState() { }
    public static UserSpeakState Instance { get; } = new UserSpeakState();

    public string GetStateText()
    {
      return "UserSpeakStateなう";
    }

    public IEnumerable<string> GetCommand()
    {
      return new List<string> { "UserSpeaking", "ユーザー話し中" };
    }

    public void OnEnter(TalkStateMachine talkStateMachine)
    {
      // ユーザーの発話をテキスト化
      SpeechToText.Exec();
    }

    public void OnUpdate(TalkStateMachine talkStateMachine)
    {
      // 次Stateへの遷移
      talkStateMachine.ChangeState(AvatarThinkingState.Instance);
    }

    public void OnExit(TalkStateMachine talkStateMachine)
    {
      throw new NotImplementedException();
    }
  }
}
