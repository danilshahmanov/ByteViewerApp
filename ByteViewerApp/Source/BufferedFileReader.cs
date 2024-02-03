using System.Text;

namespace ByteViewerApp.Source
{
    public class BufferedFileReader
    {
        private FileStream? _fileStream;
        private Encoding? _encoding;
        private byte[] _buffer = new byte[BufferSize];

        /// <summary>
        /// Размер буфера для чтения данных из файла.
        /// </summary>
        public static int BufferSize { get; } = 16;

        /// <summary>
        /// Общее количество байтов в файле.
        /// </summary>
        public int? BytesCount { get; private set; }

        /// <summary>
        /// Перечисление, представляющее поддерживаемые типы кодировок.
        /// </summary>
        public enum EncodingType
        {
            UTF8,
            UTF32,
            UTF16BE,
            UTF16LE,
            ASCII
        }

        /// <summary>
        /// Устанавливает тип кодировки для чтения данных из файла.
        /// </summary>
        /// <param name="encodingType">Тип кодировки.</param>
        public void SetEncoding(EncodingType encodingType) => _encoding = ToEncoding(encodingType);
        public bool HasFile() => _fileStream is not null;
        private static Encoding ToEncoding(EncodingType encodingType) =>
            encodingType switch
            {
                EncodingType.UTF8 => Encoding.UTF8,
                EncodingType.UTF32 => Encoding.UTF32,
                EncodingType.UTF16BE => Encoding.BigEndianUnicode,
                EncodingType.UTF16LE => Encoding.Unicode,
                EncodingType.ASCII => Encoding.ASCII,
                _ => throw new NotImplementedException("Неизвестная кодировка.")
            };

        /// <summary>
        /// Устанавливает файл для чтения.
        /// </summary>
        /// <param name="filePath">Путь к файлу.</param>
        public void SetFile(string filePath)
        {
            if(_fileStream is not null)
            {
                _fileStream.Dispose();
                _fileStream = null;
            }
            _fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BytesCount = (int)_fileStream.Length;
            if (BytesCount == 0)
            {
                _fileStream.Dispose();
                _fileStream = null;
                throw new InvalidDataException("Загруженный файл пустой.");
            }
        }

        /// <summary>
        /// Получает строку данных из файла по заданному индексу.
        /// </summary>
        /// <param name="index">Индекс строки.</param>
        /// <returns>BufferedRow, представляющий буферизованную строку данных.</returns>
        public BufferedRow? GetRowByIndex(int index)
        {
            if (_fileStream is null)
                throw new NullReferenceException("Файл для чтения не загружен.");
            if (_encoding is null)
                throw new NullReferenceException("Не установлен тип кодировки.");
            if (ReadByBuffer(index * BufferSize))
            {
                return new BufferedRow()
                {
                    EncodedBytes = [.. _buffer],
                    DecodedText = _encoding.GetString(_buffer),
                    Offset = index * BufferSize,
                };
            }
            return null;
        }

        private bool ReadByBuffer(int offset)
        {
            if (offset < 0 || offset > BytesCount)
                return false;
            //преобразовываем смещение относительно SeekOrigin.Current
            offset -= (int)_fileStream.Position;
            try
            {
                _fileStream.Seek(offset, SeekOrigin.Current);
                _fileStream.Read(_buffer, 0, BufferSize);
                return true;
            }
            catch (Exception ex)
            {
                _fileStream.Dispose();
                _fileStream = null;
                throw new IOException("Ошибка при чтении файла.", ex);
            }
        }
    }
}
