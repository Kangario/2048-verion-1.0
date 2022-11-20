using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GameSST2048.Properties;

namespace GameProject
{
    /// <summary>
    /// Идентификаторы окон
    /// </summary>
    public enum Windows
    {
        None = 0,// Не определено
        MainMenu = 1, // Основное меню
        Pregame = 2, // Предыгровая картинка 
        GameScreen = 3, // Окно игры
        Settings = 4, // Настройки
    }

    public class WindowManager
    {
        Window current;
        System.Windows.Forms.Form form;

        Dictionary<Windows, Window> windows;

        Size size;

        Parameters parameters;

        public WindowManager(System.Windows.Forms.Form form)
        {
            this.form = form;

            current = null;

            // массив окон
            windows = new Dictionary<Windows, Window>();

            // размер экрана
            size = new Size(400, 300);

            // объект для хранения параметров
            parameters = new Parameters();

            // Главное меню
            Window menu = new MainMenu();
            menu.WindowManager = this;
            windows.Add(Windows.MainMenu, menu);

            // Предыгровая картинка
            PregameWindow pregame = new PregameWindow(this);
            pregame.WindowManager = this;
            pregame.Horizontal = Alignment.Center;
            pregame.Vertical = Alignment.Center;
            windows.Add(Windows.Pregame, pregame);

            // Игра
            Window game = new GameWindow(this);
            game.Horizontal = Alignment.Center;
            game.Vertical = Alignment.Center;
            windows.Add(Windows.GameScreen, game);

            // Настройки
            Window settings = new SettingsWindow(this);
            settings.WindowManager = this;
            settings.Horizontal = Alignment.Center;
            settings.Vertical = Alignment.Center;
            windows.Add(Windows.Settings, settings);

            // Обновить положение всех экранов
            foreach (KeyValuePair<Windows, Window> w in windows)
                w.Value.UpdateCurrectLocation();

            // Показать меню
            SetCurrentWindow(Windows.MainMenu);
        }
        /// <summary>
        /// Получает или задает размер
        /// </summary>
        public Size Size
        {
            set { size = value; }
            get { return size; }
        }

        /// <summary>
        /// Выполняет рисование
        /// </summary>
        /// <param name="render">Объект для рисования</param>
        public void Draw(Render render)
        {
            // начало рисования
            if (render != null)
            {
                // получить объект Graphics
                Graphics g = render.Graphics;
                if (g != null)
                {
                    // заполнить фон
                    g.Clear(Color.White);

                    if (current != null)
                    {
                        // нарисовать текущий экран
                        current.Draw(g);
                    }
                    // поменять местами буферы
                    render.FlipBuffers();
                }
            }
        }

        /// <summary>
        /// Выполняет обработку ввода пользователя
        /// </summary>
        /// <param name="input"></param>
        public void ProcessInput(UserInput input)
        {
            if (current != null)
                current.ProcessInput(input);
        }
        /// <summary>
        /// Завершает работу приложения
        /// </summary>
        public void Exit()
        {

            // задать текущий экран - пустой
            current = null;

            // очистить память всех экранов
            foreach (KeyValuePair<Windows, Window> w in windows)
            {
                if (w.Value != null)
                    w.Value.Dispose();
            }

            // очистить список всех экранов
            windows.Clear();

            // Завершить работу приложения
            if (form != null)
            {
                // закрыть форму
                form.Close();
            }
            else
            {
                // завершить работу приложения, если форма не задана
                System.Windows.Forms.Application.Exit();
            }
        }
        /// <summary>
        /// Задает текущее окно
        /// </summary>
        /// <param name="windowID">Идентификатор окна</param>
        public void SetCurrentWindow(int windowID)
        {
            if (windowID >= 0)
            {
                Windows id = (Windows)windowID;
                if (id == Windows.None)
                    Exit();

                Window window = null;
                if (windows.TryGetValue(id, out window))
                {
                    current = window;
                    if (current != null)
                        current.AcceptParameters();
                }
            }
            else
                current = null;

            if (current == null)
                Exit();
        }
        /// <summary>
        /// Задает текущее окно
        /// </summary>
        /// <param name="windowID">Идентификатор окна</param>
        public void SetCurrentWindow(Windows windowID)
        {
            if (windowID == Windows.None)
                Exit();

            Window window = null;
            if (windows.TryGetValue(windowID, out window))
            {
                current = window;
                if (current != null)
                    current.AcceptParameters();
            }

            if (current == null)
                Exit();
        }
        /// <summary>
        /// Получает объект, содержащий параметры
        /// </summary>
        public Parameters Parameters
        {
            get { return parameters; }
        }        
    }
}
