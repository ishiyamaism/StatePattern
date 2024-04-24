using state_pattern.WebRequest;

namespace state_pattern.States
{
  // 状態を同一視するためのインターフェース
  public sealed class UserSpeakState : IState
  {
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
      talkStateMachine.ChangeState(new AvatarThinkingState());
    }

    public void OnExit(TalkStateMachine talkStateMachine)
    {
      throw new NotImplementedException();
    }
  }
}
