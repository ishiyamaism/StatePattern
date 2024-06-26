﻿using state_pattern.States;

namespace state_pattern;

class Program
{
    // ここがクライアント側
    static private TalkStateMachine _talkStateMachine = new TalkStateMachine();
    static private string? _currentState;

    static Program()
    {
        _talkStateMachine.Init();
        _currentState = _talkStateMachine.GetText();
        _talkStateMachine.StateChanged += StateMachine_StateChanged;

        Console.WriteLine("Enter '1' for State Change, '2' for Exec Process X, or 'exit' to quit:");
        Console.WriteLine(_currentState);
    }

    static void Main(string[] args)
    {
        // コンソールでの入力をインプットとして処理する
        // 1: State状態変化トリガー
        // exit: 終了
        while (true)
        {
            string? input = Console.ReadLine();

            if (input == "exit")
            {
                Console.WriteLine("Exiting program...");
                break;
            }

            switch (input)
            {
                case "1":
                    // State状態変化トリガー発動
                    _talkStateMachine.Update();

                    break;

                default:
                    Console.WriteLine("Invalid input. Please enter '1', '2', or 'exit'.");
                    break;
            }
        }
    }

    // ObserverパターンでState変更タイミングを検知。
    static private void StateMachine_StateChanged()
    {
        // State変更時の処理を実装
        _currentState = _talkStateMachine.GetText();
        Console.WriteLine(_currentState);

        // Stateが変化したら、それぞれ各種State毎のEnter()処理を実行する
        _talkStateMachine.Enter();
    }
}
