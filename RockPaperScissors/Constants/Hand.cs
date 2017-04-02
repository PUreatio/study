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
    /// ����񂯂�̎�
    /// </summary>
    public enum Hand : int
    {
        /// <summary>�����l</summary>
        None = -1,
        /// <summary>�O�[</summary>
        Rock = 0,
        /// <summary>�`���L</summary>
        Scissors = 1,
        /// <summary>�p�[</summary>
        Paper = 2
    }
}