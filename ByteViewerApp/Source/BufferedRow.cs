namespace ByteViewerApp.Source
{
    public class BufferedRow
    {
        /// <summary>
        /// Смещение байтов относительно начала файла.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Байты символов.
        /// </summary>
        public byte[]? EncodedBytes { get; set; }

        /// <summary>
        /// Раскодированная строка согласно байтам.
        /// </summary>
        public string DecodedText { get; set; } = string.Empty;
    }
}
