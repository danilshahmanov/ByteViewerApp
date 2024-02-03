using ByteViewerApp.Source;

namespace ByteViewerApp
{
    public partial class ByteViewerForm : Form
    {
        private readonly BufferedFileReader _bufferedFileReader;

        /// <summary>
        /// Максимальное количество строк, которое может быть загружено в таблицу.
        /// </summary>
        private const int MaxLoadedRowCount = 100;
        /// <summary>
        /// Индекс крайней сверху загруженной строки.
        /// </summary>
        private int _firstLoadedRowIndex;
        /// <summary>
        /// Индекс крайней снизу загруженной строки.
        /// </summary>
        private int _lastLoadedRowIndex;
        /// <summary>
        /// Максимальный индекс строки.
        /// </summary>
        private int _maxRowIndexToLoad;
        /// <summary>
        /// Количество отображаемых строк в таблице.
        /// </summary>
        private int _displayedRowsCount;
        public ByteViewerForm()
        {
            _bufferedFileReader = new BufferedFileReader();
            InitializeComponent();
        }

        /// <summary>
        /// Преобразует число в строку в виде 16-ричного смещения (например: 16 -> "0x10").
        /// </summary>
        /// <param name="number">Число для преобразования.</param>
        /// <returns>Строка с 16-ричным смещением.</returns>
        private static string ToHexOffset(int number) => $"0x{number:X}";
        /// <summary>
        /// Очищает таблицу.
        /// </summary>
        private void ClearDataGrid()
        {
            if (byteViewDataGrid.RowCount != 0)
                byteViewDataGrid.Rows.Clear();
        }
        /// <summary>
        /// Устанавливает файл для просмотра.
        /// </summary>
        private void SetFile()
        {
            string filePath = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                filePath = openFileDialog1.FileName;
            _bufferedFileReader.SetFile(filePath);
        }
        /// <summary>
        ///  Устанавливает начальные значения контролов при первичной загрузке файла.
        /// </summary>
        private void SetUpValuesOfControls()
        {
            //переустановка скрола
            scrollBar.Reset(0);
            //вычисление максимального доступного смещения
            int maxOffset = _bufferedFileReader.BytesCount.Value - (_bufferedFileReader.BytesCount.Value % 16);
            maxOffset = Math.Max(0, maxOffset - MaxLoadedRowCount * 16);

            offsetNumericUpDown.Maximum = maxOffset;
            offsetNumericUpDown.Value = 0;
            offsetLabel.Text = $"максимальное смещение: {maxOffset:X}";


            _maxRowIndexToLoad = _bufferedFileReader.BytesCount.Value / 16;
            _firstLoadedRowIndex = 0;
            _lastLoadedRowIndex = -1;
        }
        /// <summary>
        /// Обработчик события клика на кнопку "загрузить файл".
        /// </summary>
        private void LoadFile_Click(object sender, EventArgs e)
        {
            //проверка выбрана ли кодировка
            if (encodingTypeComboBox.SelectedItem is not null)
                _bufferedFileReader.SetEncoding((BufferedFileReader.EncodingType)encodingTypeComboBox.SelectedItem);
            else
            {
                MessageBox.Show("Необходимо выбрать кодировку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ClearDataGrid();
            try
            {
                SetFile();
                SetUpValuesOfControls();
                LoadRowsDown(0, MaxLoadedRowCount, true);
                //подсчет макимального значения скролла для корректного отображения файла
                _displayedRowsCount = byteViewDataGrid.DisplayedRowCount(false);
                scrollBar.SetMaximum(_maxRowIndexToLoad, _displayedRowsCount);
                scrollBar.CheckScrollEnabled(_maxRowIndexToLoad, _displayedRowsCount);
            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Обработчик события клика на кнопку "сместить файл".
        /// </summary>
        private void OffsetFile_Click(object sender, EventArgs e)
        {
            if (!_bufferedFileReader.HasFile())
            {
                MessageBox.Show("Необходимо загрузить файл.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ClearDataGrid();
            int startRowIndex = (int)offsetNumericUpDown.Value / 16;
            scrollBar.Reset(startRowIndex);
            offsetNumericUpDown.Value = startRowIndex * 16;
            _firstLoadedRowIndex = startRowIndex;
            _lastLoadedRowIndex = startRowIndex - 1;
            LoadRowsDown(startRowIndex, MaxLoadedRowCount, true);
        }

        /// <summary>
        /// Подгружает строки в DataGridView с указанного индекса вниз.
        /// </summary>
        /// <param name="startRowIndexToLoad">Индекс с которого будут добавляться строки.</param>
        /// <param name="maxRowCount">Максимальное количество строк для добавления.</param>
        /// <param name="isFirstLoad">Определяет в первый ли раз происходит подгрузка строк.</param>
        /// <returns>Количество добавленных строк.</returns>
        private int LoadRowsDown(int startRowIndexToLoad, int maxRowCount, bool isFirstLoad)
        {
            int loadedRows = 0;
            try
            {
                while (loadedRows < maxRowCount)
                {
                    var row = _bufferedFileReader.GetRowByIndex(startRowIndexToLoad);
                    if (row is null)
                        break;
                    loadedRows++;
                    startRowIndexToLoad++;
                    byteViewDataGrid.Rows.Add(
                        ToHexOffset(row.Offset),
                        BitConverter.ToString(row.EncodedBytes).Replace('-', ' '),
                        row.DecodedText
                    );
                }
                _lastLoadedRowIndex += loadedRows;
                if (!isFirstLoad)
                {
                    for (int i = 0; i < loadedRows; i++)
                        byteViewDataGrid.Rows.RemoveAt(0);
                    _firstLoadedRowIndex += loadedRows;
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return loadedRows;
        }

        /// <summary>
        /// Подгружает строки в DataGridView с указанного индекса вверх.
        /// </summary>
        /// <param name="startRowIndexToLoad">Индекс с которого будут добавляться строки.</param>
        /// <param name="maxRowCount">Максимальное количество строк для добавления.</param>
        /// <returns>Количество добавленных строк.</returns>
        private int LoadRowsUp(int startRowIndexToLoad, int maxRowCount)
        {
            int loadedRows = 0;
            try
            {
                while (loadedRows < maxRowCount)
                {
                    var row = _bufferedFileReader.GetRowByIndex(startRowIndexToLoad);
                    if (row is null)
                        break;
                    loadedRows++;
                    startRowIndexToLoad--;
                    byteViewDataGrid.Rows.Insert(
                        0,
                        ToHexOffset(row.Offset),
                        BitConverter.ToString(row.EncodedBytes).Replace('-', ' '),
                        row.DecodedText
                    );
                }
                for (int i = 0; i < loadedRows; i++)
                    byteViewDataGrid.Rows.RemoveAt(byteViewDataGrid.Rows.Count - 1);

                _lastLoadedRowIndex -= loadedRows;
                _firstLoadedRowIndex -= loadedRows;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return loadedRows;
        }

        /// <summary>
        /// Осуществляет скроллирование таблицы вниз.
        /// </summary>
        /// <param name="scrollValue">Индекс следующей строки снизу.</param>
        private void LoadRows_ScrollDown()
        {
            int scrollValue = scrollBar.Value;
            //если при скролинге вниз достаточно загруженных строк для отображения
            if (scrollValue < _lastLoadedRowIndex - _displayedRowsCount + 1)
                byteViewDataGrid.FirstDisplayedScrollingRowIndex += 1;
            else
            {
                int firstScrollRowIndex = byteViewDataGrid.FirstDisplayedScrollingRowIndex;
                var loadedRows = LoadRowsDown(_lastLoadedRowIndex + 1, MaxLoadedRowCount / 2, false);

                if (loadedRows != 0)
                    byteViewDataGrid.FirstDisplayedScrollingRowIndex = firstScrollRowIndex - loadedRows + 1;
            }
        }
        /// <summary>
        /// Осуществляет скроллирование таблицы вверх.
        /// </summary>
        /// <param name="scrollValue">Индекс следующей строки сверху.</param>
        private void LoadRows_ScrollUp()
        {
            int scrollValue = scrollBar.Value;
            //если при скролинге ввер необходимо догрузить строки
            if (scrollValue < _firstLoadedRowIndex)
            {
                var loadedRows = LoadRowsUp(_firstLoadedRowIndex - 1, MaxLoadedRowCount / 2);
                if (loadedRows != 0)
                    byteViewDataGrid.FirstDisplayedScrollingRowIndex = loadedRows - 1;
            }
            //если при скролинге вверх достаточно загруженных строк для отображения
            else
                byteViewDataGrid.FirstDisplayedScrollingRowIndex -= 1;
        }
        /// <summary>
        /// Обработчик события изменения значения скролла.
        /// </summary>
        private void ScrollBar_ValueChanged(object sender, EventArgs e) => scrollBar.OnScroll();
    }
}