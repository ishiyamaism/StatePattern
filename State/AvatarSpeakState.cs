using state_pattern.WebRequest;

namespace state_pattern.States
{
  public sealed class AvatarSpeakState : IState
  {
    // シングルトン
    private AvatarSpeakState() { }
    public static AvatarSpeakState Instance { get; } = new AvatarSpeakState();

    public string GetStateText()
    {
      return "AvatarSpeakStateなう";
    }

    public IEnumerable<string> GetCommand()
    {
      return new List<string> { "AvatarSpeaking", "アバター話し中" };
    }

    public void OnEnter(TalkStateMachine talkStateMachine)
    {
      // アバターがテキストを発声
      TextToSpeech.Exec();

      Console.WriteLine("(一連の流れ終了・アイドル状態へ)");
      // 一連の流れ終了・アイドル状態へ
      OnUpdate(talkStateMachine);
    }

    public void OnUpdate(TalkStateMachine talkStateMachine)
    {
      // 次Stateへの遷移
      talkStateMachine.ChangeState(IdleTalkState.Instance);
    }

    public void OnExit(TalkStateMachine talkStateMachine)
    {
      throw new NotImplementedException();
    }
  }
}
