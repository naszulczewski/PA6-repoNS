using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA6
{
    public partial class frmMain : Form
    {
        string cwid;
        List<Book> myBooks;

        public frmMain(string tempCwid)
        {
            this.cwid = tempCwid;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            myBooks = BookFile.GetAllBooks(cwid);
            lstBooks.DataSource = myBooks;
        }

        private void lblAuthor_Click(object sender, EventArgs e)
        {

        }

        private void txtAuthorData_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo);

            if(dialogResult == DialogResult.Yes)
            {
                BookFile.DeleteBook(myBook, cwid);
                LoadList();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Book myBook = new Book();
            frmEdit myForm = new frmEdit(myBook, "new", cwid);

            if (myForm.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                LoadList();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblGenre_Click(object sender, EventArgs e)
        {

        }

        private void lblCopies_Click(object sender, EventArgs e)
        {

        }

        private void lblISBN_Click(object sender, EventArgs e)
        {

        }

        private void lblLength_Click(object sender, EventArgs e)
        {

        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            myBook.copies--;
            BookFile.SaveBook(myBook, cwid, "edit");
            LoadList();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            myBook.copies++;
            BookFile.SaveBook(myBook, cwid, "edit");
            LoadList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;
            frmEdit myForm = new frmEdit(myBook, "edit", cwid);

            if(myForm.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                LoadList();
            }
        }

        private void lstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            txtTitleData.Text = myBook.title;
            txtAuthorData.Text = myBook.author;
            txtGenreData.Text = myBook.genre;
            txtISBNData.Text = myBook.isbn;
            txtCopiesData.Text = myBook.copies.ToString();
            txtLengthData.Text = myBook.length.ToString();

            try
            {
                pbCover.Load(myBook.cover);
            }
            catch
            {

            }

        }

        private void pbCover_Click(object sender, EventArgs e)
        {

        }

        private void txtTitleData_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGenreData_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCopiesData_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtISBNData_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLengthData_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
