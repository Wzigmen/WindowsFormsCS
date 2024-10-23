using System;
using System.IO;
using System.Drawing.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace Clock
{
    public partial class ChooseFont : Form
    {
        public Font ChoseFont { get; private set; }
        public ChooseFont()
        {
            InitializeComponent();
            LoadFonts();
        }
        void LoadFonts()
        {
            // 1) Получаем список всех файлов в текущем каталоге, и сохраняем этот список в массив 'fonts'
            string[] fonts = Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.ttf").ToArray();
            // 2) Поскольку в массиве хранятся полные пути к файлам, убираем пути и оставляем только именна полученных файлов
            for (int i = 0; i < fonts.Length; i++)
            {
                fonts[i] = fonts[i].Split('\\').Last();
            }
            // 3) Загружаем весь массив в файлов в КомбоБокс
            comboBoxFonts.Items.AddRange(fonts);
            
        }

        private void comboBoxFont_SelectedValueChanged(object sender, EventArgs e)
        {
            string fontFile = $"{Directory.GetCurrentDirectory()}\\{comboBoxFonts.SelectedItem.ToString()}";
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(fontFile);
            Font font = new Font(pfc.Families[0], 36);
            labelExample.Font = font;
            
        }

        private void Cansel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            ChoseFont = new Font(labelExample.Font.FontFamily, labelExample.Font.Size);
        }
    }
}
