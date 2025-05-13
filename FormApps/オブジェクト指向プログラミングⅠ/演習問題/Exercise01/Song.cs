using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {//2.1.1
    public class Song {
        public String Title;
        public String ArtistName;
        public int Length;



        //コンストラクタ
        public Song(String Title, String ArtistName, int Lenght) {
            this.Title = Title;
            this.ArtistName = ArtistName;
            this.Length = Lenght;

        }//2.1.2

    }

}
