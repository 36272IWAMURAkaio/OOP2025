using LineCounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessor {
    internal class TextFileProcessor {
        private ITextFileServer _service;

        public TextFileProcessor(ITextFileServer service) {
            _service = service;
        }

        public void Run(string fileName) {
            _service.Initialize(fileName);

            var lines = File.ReadLines(fileName);
            foreach (var line in lines) {
                _service.Execute(line);
            }
            _service.Terminate();
        }

    }
}
