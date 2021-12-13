using DependancyInjection.Contracts;

namespace DependancyInjection.Core
{
    public class Engine
    {
        private IWriter _consoleWriter;
        private IWriter _fileWriter;
        private IReader _reader;

        public Engine(IConsoleWriter consoleWriter,
            IFileWriter fileWriter,
            IReader reader)
        {
            this._consoleWriter = consoleWriter;
            this._fileWriter = fileWriter;
            this._reader = reader;
        }

        public void Run()
        {
            string text = _reader.Read();
            _fileWriter.Write(text);
            _consoleWriter.Write(text);
        }
    }
}
