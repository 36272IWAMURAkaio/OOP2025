using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    public class Settings {
        private Settings instance;
        //設定した色情報を格納
        public int MainFormBackColor { get; set; }

        private Settings(){}

            public static Settings getInstance() {
                if(instance == null) {
                    instance = new Settings();
                }
                return instance;
            }



        }
        
    }
}
