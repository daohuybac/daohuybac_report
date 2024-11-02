using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project
{
    public partial class ImageForm : Form
    {
        public ImageForm()
        {
            InitializeComponent();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại chọn file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Hiển thị ảnh đã chọn vào PictureBox
                pickImage.Image = Image.FromFile(openFileDialog.FileName);
                pickImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbId_TextChanged(object sender, EventArgs e)
        {

        }

        private void pickImage_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lbName_Click(object sender, EventArgs e)
        {

        }

        private void lbId_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại để chọn đường dẫn và tên tệp để lưu ảnh
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            saveFileDialog.Title = "Save an Image File";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (pickImage.Image != null)
                {
                    // Lưu hình ảnh từ PictureBox vào tệp
                    using (var stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        // Lưu hình ảnh
                        pickImage.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg); // Hoặc ImageFormat.Png
                    }

                    // Lưu thông tin vào tệp .txt
                    string textFilePath = Path.ChangeExtension(saveFileDialog.FileName, ".txt");
                    using (StreamWriter sw = new StreamWriter(textFilePath, true))
                    {
                        sw.WriteLine("Tên: " + tbName.Text); // Lưu nội dung của TextBox tbName
                        sw.WriteLine("ID: " + tbId.Text); // Lưu nội dung của TextBox tbId
                        sw.WriteLine("Vị trí hình ảnh: " + saveFileDialog.FileName); // Lưu vị trí hình ảnh
                    }

                    // Hiện thông báo thành công
                    MessageBox.Show("Save Image and Information Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No Image to save!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 fr01 = new Form1();
            fr01.Show();
            this.Hide();
        }
    }
}
