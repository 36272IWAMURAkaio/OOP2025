using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessor {
    public abstract class TextFileProcessor {
        public static void Run<T>(string fileName) where T : TextFileProcessor, new() {
            var self = new T();
            self.Process(fileName);
        }

        private void Process(string fileName) {
            Initialize(fileName);
            var lines = File.ReadLines(fileName);
            foreach (var line in lines) {
                Execute(line);
            }
            Terminate();
        }

        protected virtual void Initialize(string fname) { }
        protected virtual void Execute(string line) { }
        protected virtual void Terminate() { }
    }
}