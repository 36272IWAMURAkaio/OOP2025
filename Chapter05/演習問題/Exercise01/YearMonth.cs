﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    // 5.1.1
    public class YearMonth {
        public int Year { get; init; }
        public int Month { get; init; }

        public YearMonth(int year, int month) {
            Year = year;
            Month = month;
        }

        // 5.1.2
        //設定されている西暦が２１世紀か判定する
        //Yearが2001～2100年の間ならtrue、それ以外ならfalseを返す
        public bool Is21Century => 2001 <= Year && Year <= 2100;

        // 5.1.3
        public YearMonth AddOneMonth() {

            if(         ) {
                return new YearMonth(   ,    ); //Monthが12月以外
            } else {
                return new YearMonth(    ,   );//Monthが12月
            }

        }

        // 5.1.4
        public override string ToString() =>
    }
}
