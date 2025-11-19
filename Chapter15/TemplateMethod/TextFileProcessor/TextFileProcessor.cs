using System.IO;

namespace TextFileProcessor {
    public class TextFileProcessor {
        private ITextFileService _service;

        public TextFileProcessor(ITextFileService service) {
            _service = service;
        }

        public void Run(string fileName) {
            _service.Initialize(fileName);

            foreach (var line in File.ReadLines(fileName)) {
                _service.Execute(line);
            }

            _service.Terminate();
        }
    }
}
