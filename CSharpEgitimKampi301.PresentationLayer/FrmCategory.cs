using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.BusinessLayer.Concrete;
using CSharpEgitimKampi301.DataAccessLayer.EntityFramework;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.PresentationLayer
{
    public partial class FrmCategory : Form
    {
        private readonly ICategoryService _categoryService;

        public FrmCategory()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource = categoryValues;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = txtCategoryName.Text;
            category.CategoryDescription = txtDescription.Text;
            category.CategoryStatus = true;
            _categoryService.TInsert(category);
            MessageBox.Show("Kategori Eklendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCategoryId.Text);
            var deletedValues = _categoryService.TGetById(id);
            _categoryService.TDelete(deletedValues);
            MessageBox.Show("Kategori Silindi");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCategoryId.Text);
            var categoryValue = _categoryService.TGetById(id);

            if (categoryValue != null)
            {
                // Tek nesneyi bir listeye dönüştür
                dataGridView1.DataSource = new List<Category> { categoryValue };
            }
            else
            {
                MessageBox.Show("Kategori bulunamadı!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int updatedId = Convert.ToInt32(txtCategoryId.Text);
            var updatedvalue = _categoryService.TGetById(updatedId);
            updatedvalue.CategoryName = txtCategoryName.Text;
            updatedvalue.CategoryDescription = txtDescription.Text;
            updatedvalue.CategoryStatus = true;
            _categoryService.TUpdate(updatedvalue);
            MessageBox.Show("Kategori Güncellendi");
        }
    }
}
