using state_pattern.WebRequest;

namespace state_pattern.States
{
  // 状態を同一視するためのインターフェース
  public sealed class AvatarThinkingState : IState
  {
    public string GetStateText()
    {
      return "AvatarThinkingStateなう";
    }

    public IEnumerable<string> GetCommand()
    {
      return new List<string> { "AvatarThinking", "アバター考え中" };
    }

    public void OnEnter(TalkStateMachine talkStateMachine)
    {
      // テキストを発生
      TextToSpeech.Exec("ふむふむ、なるほど");
      // GPTが回答出力
      ChatGPT.Exec();
    }

    public void OnUpdate(TalkStateMachine talkStateMachine)
    {
      // 次Stateへの遷移
      talkStateMachine.ChangeState(new AvatarSpeakState());
    }

    public void OnExit(TalkStateMachine talkStateMachine)
    {
      throw new NotImplementedException();
    }
  }
}
