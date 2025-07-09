﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    public class CarReport {

        public enum MakerGroup {
            なし,
            トヨタ,
            日産,
            本田,
            スバル,
            輸入車,
            その他,
        }
        [System.ComponentModel.DisplayName("日付")]
        public DateTime Date { get; set; }  //日付
        [System.ComponentModel.DisplayName("記録者")]
        public string Author { get; set; } = string.Empty;
        [System.ComponentModel.DisplayName("メーカー")]//記録者
        public MakerGroup Maker { get; set; }//メーカー
        [System.ComponentModel.DisplayName("車名")]
        public string CarName { get; set; } = string.Empty;
        [System.ComponentModel.DisplayName("レポート")]//車名
        public string Report { get; set; } = string.Empty;
        [System.ComponentModel.DisplayName("画像")]//レポート
        //[System.ComponentModel.Browsable(false)]
        public Image? Picture { get; set; }  //画像
    }
}
