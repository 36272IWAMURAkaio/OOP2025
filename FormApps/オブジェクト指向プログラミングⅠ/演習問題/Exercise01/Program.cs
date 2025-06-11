using Exercise01;
using System.ComponentModel.DataAnnotations;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            //歌データを入れるリストオブジェクト
            var songs = new List<Song>();

            Console.WriteLine("*****曲の登録*****");
            //何件入れるかわからないので無限ループ
            while (true) {
                //曲名を出力
                Console.WriteLine("曲名:");
                //入力された曲名を取得
                string title = Console.ReadLine();

                //endが入力されたら登録終了
                if (title.Equals("end", StringComparison.OrdinalIgnoreCase)) break;

                Console.WriteLine("アーティスト名:");
                //入力されたアーティスト名を取得
                string ArtistName = Console.ReadLine();

                Console.WriteLine("演奏時間 :");
                //入力された演奏時間を取得
                int Length = int.Parse(Console.ReadLine());

                //Songのインスタンス
                Song song = new Song() {
                    Title = title,
                    ArtistName = ArtistName,
                    Length = Length
                };
                //歌データを入れるリストオブジェクトへ登録
                songs.Add(song);

                Console.WriteLine();
            }

        }
    }
}


//2.1.4
