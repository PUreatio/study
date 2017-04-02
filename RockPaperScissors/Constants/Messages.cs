using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RockPaperScissors.Constants
{
    /// <summary>
    /// ���b�Z�[�W
    /// </summary>
    public class Messages
    {
        /// <summary>�����\�����b�Z�[�W</summary>
        public const string READY_MESSAGE = "��������̓O�[�I{0}����񂯂�E�E�E�E�E";
        /// <summary>���ʏ����\�����b�Z�[�W</summary>
        public const string RESULT_INIT_MESSAGE = "����񂯂񂵂悤�I{0}����񂯂񂵂悤�I";
        /// <summary>�������o����</summary>
        public const string OWN_HAND_FORMAT = "���Ȃ��̎�F{0}";
        /// <summary>���肪�o����</summary>
        public const string OPPONENT_HAND_FORMAT = "����̎�F{0}";
        /// <summary>���ʃ��b�Z�[�W</summary>
        public const string RESULT_FORMAT = "{0}{1}{2}{3}{4}�I";
    }
}