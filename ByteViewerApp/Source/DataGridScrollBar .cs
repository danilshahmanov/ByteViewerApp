namespace ByteViewerApp.Source
{
    public partial class DataGridScrollBar : VScrollBar 
    {
        private int _currentScrollValue = 0;
        private int _scrollOffset = 1;
        /// <summary>
        /// Код сообщения нажатия левой кнопки мыши.
        /// </summary>
        private const int WM_LBUTTONDOWN = 0x0201;
        /// <summary>
        /// Код сообщения двойного клика левой кнопки мыши.
        /// </summary>
        private const int WM_LBUTTONDBLCLK = 0x0203;
        /// <summary>
        /// Событие скролинга вверх.
        /// </summary>
        public event Action? ScrollUp;
        /// <summary>
        /// Событие скролинга вниз.
        /// </summary>
        public event Action? ScrollDown;
       
        /// <summary>
        /// Вычисляет максимальное значение scrollbar для корректного отображения последних строк таблицы.
        /// </summary>
        /// <param name="maxRowIndexToLoad">Максимальный индекс загружаемых строк.</param>
        /// <param name="displayedRowCount">Максимальное количество отображаемых строк в datagrid.</param>
        public int SetMaximum(int maxRowIndexToLoad, int displayedRowCount) =>
                   Maximum = maxRowIndexToLoad - displayedRowCount;
        /// <summary>
        /// Определяет необходим ли скролинг для заданного размера строк.
        /// </summary>
        /// <param name="maxRowIndexToLoad">Максимальный индекс загружаемых строк.</param>
        /// <param name="displayedRowCount">Максимальное количество отображаемых строк в datagrid.</param>
        public void CheckScrollEnabled(int maxRowIndexToLoad, int displayedRowCount)
        {
            if (maxRowIndexToLoad <= displayedRowCount)
                Enabled = false;
            else
                Enabled = true;
        }
        public new int Value 
        { 
            get { return base.Value; }
            set
            {
                if (value > Maximum || value < Minimum)
                    return;
                base.Value = value;
            }
        }
       
        public void OnScroll()
        {
            if (IsScrollingDown)
            {
                ScrollDown?.Invoke();
                _currentScrollValue = Value;
                return;
            }
            if (IsScrollingUp)
            {
                ScrollUp?.Invoke();
                _currentScrollValue = Value;
                return;
            }
        }
        /// <summary>
        /// Используется для переустановки начальных значений скрола.
        /// </summary>
        public void Reset(int startScrollValue)
        {
            Value = startScrollValue;
            _currentScrollValue=startScrollValue;
        }
        /// <summary>
        /// Метод для предвращения передвижения скрола через необраббатываемые способы.
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            // Перехватываем события нажатия и двойного нажатия левой кнопки мыши
            if (m.Msg == WM_LBUTTONDOWN || m.Msg == WM_LBUTTONDBLCLK)
                return;
            base.WndProc(ref m);
        }
        /// <summary>
        /// Определяет происходит ли прокрутка вниз.
        /// </summary>
        public bool IsScrollingDown => Value - _currentScrollValue == _scrollOffset;
        /// <summary>
        /// Определяет происходит ли прокрутка вверх.
        /// </summary>
        public bool IsScrollingUp => Value - _currentScrollValue == -_scrollOffset;
    }
}
