using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Randarevich_Modul_5_Var_3
{
    public partial class Form1 : Form
    {
        private List<string> tasks = new List<string>(); // список задач

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Инициализация DataGridView
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Задача";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Добавление новой задачи
            string newTask = textBox1.Text;
            tasks.Add(newTask);
            dataGridView1.Rows.Add(newTask);
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Удаление выбранной задачи или пометка задачи как выполненной
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                string selectedTask = tasks[selectedIndex];

                // Проверка, если задача уже помечена как выполненная, то удаляем ее
                if (selectedTask.StartsWith("[Задача выполнена] "))
                {
                    dataGridView1.Rows.RemoveAt(selectedIndex);
                    tasks.RemoveAt(selectedIndex);
                }
                else
                {
                    // Пометить задачу как выполненную
                    tasks[selectedIndex] = "[Задача выполнена] " + selectedTask;
                    dataGridView1.Rows[selectedIndex].Cells[0].Value = tasks[selectedIndex];
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Обработка отметки задачи как выполненной
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                string selectedTask = tasks[selectedIndex];
                if (checkBox1.Checked)
                {
                    // Пометить задачу как выполненную
                    tasks[selectedIndex] = "[Задача выполнена] " + selectedTask;
                    dataGridView1.Rows[selectedIndex].Cells[0].Value = tasks[selectedIndex];
                }
                else
                {
                    // Убрать пометку о выполнении
                    tasks[selectedIndex] = selectedTask.Replace("[Задача выполнена] ", "");
                    dataGridView1.Rows[selectedIndex].Cells[0].Value = tasks[selectedIndex];
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Выполняется при щелчке на ячейке DataGridView
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Выполняется при щелчке на метке
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Выполняется при изменении текста в TextBox
        }
    }
}
