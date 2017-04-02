using Android.App;
using Android.Widget;
using Android.OS;
using RockPaperScissors.Constants;
using System;
using SysEnvironment = System.Environment;

namespace RockPaperScissors
{
    [Activity(Label = "RockPaperScissors", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        /// <summary>
        /// Activity生成時イベント
        /// </summary>
        /// <param name="bundle">Bundle</param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // レイアウトをActivityに関連付けする。
            this.SetContentView(Resource.Layout.Main);

            // 初期化処理を行う。
            this.Initialize();
        }

        /// <summary>
        /// じゃんけんの各ボタン押下時イベント
        /// </summary>
        /// <param name="sender">イベント対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void RockPaperScissorsButton_Click(object sender, System.EventArgs e)
        {
            Button eventButton = sender as Button;

            // 自分の出した手を取得する。
            Tuple<Hand, string> ownHand = this.GetOwndHand(eventButton.Id);

            string resultMessage = null;
            // 相手の手と勝負結果を取得する。
            switch(ownHand.Item1)
            {
                case Hand.Rock:
                    resultMessage = this.GetGameResultMessage(Hand.Scissors, Hand.Paper, ownHand.Item2);
                    break;
                case Hand.Scissors:
                    resultMessage = this.GetGameResultMessage(Hand.Paper, Hand.Rock, ownHand.Item2);
                    break;
                case Hand.Paper:
                    resultMessage = this.GetGameResultMessage(Hand.Rock, Hand.Scissors, ownHand.Item2);
                    break;
            }

            // 結果を表示する。
            TextView resultView = this.FindViewById<TextView>(Resource.Id.textViewResult);
            resultView.Text = resultMessage;
        }

        /// <summary>
        /// 初期化処理を行う。
        /// </summary>
        private void Initialize()
        {
            // メッセ―ジをTextViewに設定する。
            TextView readyView = this.FindViewById<TextView>(Resource.Id.textViewReady);
            readyView.Text = string.Format(Messages.READY_MESSAGE, SysEnvironment.NewLine);
            // 結果にも初期表示メッセージを設定する。
            TextView resultView = this.FindViewById<TextView>(Resource.Id.textViewResult);
            resultView.Text = string.Format(Messages.RESULT_INIT_MESSAGE, SysEnvironment.NewLine);

            // 各ボタンにイベントを設定する。
            Button rockButton = this.FindViewById<Button>(Resource.Id.buttonRock);
            rockButton.Click += RockPaperScissorsButton_Click;
            Button scissorsButton = this.FindViewById<Button>(Resource.Id.buttonScissors);
            scissorsButton.Click += RockPaperScissorsButton_Click;
            Button paperButton = this.FindViewById<Button>(Resource.Id.buttonPaper);
            paperButton.Click += RockPaperScissorsButton_Click;
        }

        /// <summary>
        /// 自分の出した手を取得する。
        /// </summary>
        /// <param name="buttonId">ボタンID</param>
        /// <returns>自分の出した手</returns>
        private Tuple<Hand, string> GetOwndHand(int buttonId)
        {
            Hand ownHand = Hand.None;
            string ownHandMessage = null;

            switch (buttonId)
            {
                // グーの場合
                case Resource.Id.buttonRock:
                    ownHand = Hand.Rock;
                    ownHandMessage = string.Format(Messages.OWN_HAND_FORMAT, this.GetString(Resource.String.Rock));
                    break;
                // チョキの場合
                case Resource.Id.buttonScissors:
                    ownHand = Hand.Scissors;
                    ownHandMessage = string.Format(Messages.OWN_HAND_FORMAT, this.GetString(Resource.String.Scissors));
                    break;
                // パーの場合
                case Resource.Id.buttonPaper:
                    ownHand = Hand.Paper;
                    ownHandMessage = string.Format(Messages.OWN_HAND_FORMAT, this.GetString(Resource.String.Paper));
                    break;
            }

            Tuple<Hand, string> ownHandTuple = Tuple.Create<Hand, string>(ownHand, ownHandMessage);
            return ownHandTuple;
        }

        /// <summary>
        /// 勝負判定し、結果メッセージを取得する。
        /// </summary>
        /// <param name="winHand">相手が出せば自分が勝つ手</param>
        /// <param name="looseHand">相手が出せば自分が負ける手</param>
        /// <param name="ownHandMessage">自分が出した手に対応するメッセージ</param>
        /// <returns>結果メッセージ</returns>
        private string GetGameResultMessage(Hand winHand, Hand looseHand, string ownHandMessage)
        {
            // 相手の手を取得する。
            Tuple<Hand, string> opponentHand = this.GetOpponentHand();
            string gameResultMessage = this.GetString(Resource.String.Tie);

            // 相手が勝ちな場合
            if (opponentHand.Item1 == winHand)
            {
                gameResultMessage = this.GetString(Resource.String.Win);
            }
            // 相手が負けな場合
            else if (opponentHand.Item1 == looseHand)
            {
                gameResultMessage = this.GetString(Resource.String.Loose);
            }

            string resultMessage = string.Format(Messages.RESULT_FORMAT, ownHandMessage,
                SysEnvironment.NewLine, opponentHand.Item2, SysEnvironment.NewLine,
                gameResultMessage);
            return resultMessage;
        }

        /// <summary>
        /// 相手の出した手を取得する。
        /// </summary>
        /// <returns>相手の手</returns>
        private Tuple<Hand, string> GetOpponentHand()
        {
            // 乱数を生成する。
            Random rnd = new Random();
            int iRnd = rnd.Next(3);

            // 乱数から相手の手を取得する。
            Hand opponentHand = (Hand)Enum.Parse(typeof(Hand), iRnd.ToString());
            string opponentHandMessage = null;

            // 相手の手に応じたメッセージを生成する。
            switch (opponentHand)
            {
                case Hand.Rock:
                    opponentHandMessage = string.Format(Messages.OPPONENT_HAND_FORMAT, this.GetString(Resource.String.Rock));
                    break;
                case Hand.Scissors:
                    opponentHandMessage = string.Format(Messages.OPPONENT_HAND_FORMAT, this.GetString(Resource.String.Scissors));
                    break;
                case Hand.Paper:
                    opponentHandMessage = string.Format(Messages.OPPONENT_HAND_FORMAT, this.GetString(Resource.String.Paper));
                    break;
            }

            Tuple<Hand, string> opponentHandTuple = Tuple.Create<Hand, string>(opponentHand, opponentHandMessage);
            return opponentHandTuple;
        }
    }
}

