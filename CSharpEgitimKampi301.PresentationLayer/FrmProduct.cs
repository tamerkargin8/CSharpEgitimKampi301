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
    public partial class FrmProduct : Form
    {
        private readonly IProductService _productService;
        public FrmProduct()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
            LoadCategories();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetAll();
            dataGridView1.DataSource = values;
        }

        private void btnList2_Click(object sender, EventArgs e)
        {
            var values = _productService.GetProductsWithCategory();
            dataGridView1.DataSource = values;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtPruductId.Text);
            var deletedValues = _productService.TGetById(id);
            _productService.TDelete(deletedValues);
            MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Product product = new Product();
            product.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
            product.ProductName = txtPruductName.Text;
            product.ProductPrice = Convert.ToDecimal(txtProductPrice.Text);
            product.UnitsInStock = (short)Convert.ToInt32(txtProductStock.Text);
            product.ProductDescription = txtProductDescription.Text;
            _productService.TInsert(product);
            MessageBox.Show("Ürün Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void LoadCategories()
        {
            var categories = _productService.TGetAll().Select(p => p.Category).Distinct().ToList();
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
        }
        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtPruductId.Text);
            var value = _productService.TGetById(id);
            dataGridView1.DataSource = new List<Product> { value };
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtPruductId.Text);
            var value = _productService.TGetById(id);
            value.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
            value.ProductName = txtPruductName.Text;
            value.ProductPrice = Convert.ToDecimal(txtProductPrice.Text);
            value.UnitsInStock = (short)Convert.ToInt32(txtProductStock.Text);
            value.ProductDescription = txtProductDescription.Text;
            _productService.TUpdate(value);
            MessageBox.Show("Ürün Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
