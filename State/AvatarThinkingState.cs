using state_pattern.WebRequest;

namespace state_pattern.States
{
  public sealed class AvatarThinkingState : IState
  {
    // シングルトン
    private AvatarThinkingState() { }
    public static AvatarThinkingState Instance { get; } = new AvatarThinkingState();

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
      talkStateMachine.ChangeState(AvatarSpeakState.Instance);
    }

    public void OnExit(TalkStateMachine talkStateMachine)
    {
      throw new NotImplementedException();
    }
  }
}
