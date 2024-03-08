using System.ComponentModel;
using CreateDynamicControlsCore.Classes;
using CreateDynamicControlsCore.Classes.Containers;
using CreateDynamicControlsCore.Classes.Controls;
using CreateDynamicControlsCore.Properties;

namespace CreateDynamicControlsCore;

public partial class Form1 : Form
{
    private BindingList<Product> productsBindingList;
    private readonly BindingSource productBindingSource = new ();
    public Form1()
    {
        InitializeComponent();

        ButtonOperations.BaseName = "CategoryButton";


        var buttonSetup = new ButtonSetup
        {
            Control = this,
            Top = 20,
            BaseHeightPadding = 42,
            Left = 10,
            Width = 150,
            ButtonClick = CategoryButtonClick
        };

        ButtonOperations.Initialize(buttonSetup);
        ProductsListBox.DoubleClick += ProductsListBoxOnDoubleClick;
        ButtonOperations.BuildButtons();
    }

    private void ProductsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplayCurrentProduct();
    }

    private void DisplayCurrentProduct()
    {
        if (productBindingSource.Current is null)
        {
            return;
        }

        var product = productsBindingList[productBindingSource.Position];
        CurrentProductTextBox.Text = $"{product.Id}, {product.Name}";
    }

    private void ProductsListBoxOnDoubleClick(object sender, EventArgs e)
    {
        if (productBindingSource.Current is null)
        {
            return;
        }

        var product = productsBindingList[productBindingSource.Position];

        MessageBox.Show($"{product.Id}, {product.Name}");
    }

    private void CategoryButtonClick(object sender, EventArgs e)
    {

        ButtonOperations.ButtonsList.ForEach(b => b.Image = null);

        var button = (DataButton)sender;

        button.Image = Resources.rightArrow24;

        ProductsListBox.SelectedIndexChanged -= ProductsListBox_SelectedIndexChanged;
        productsBindingList = new BindingList<Product>(DataOperations.ReadProducts(button.Identifier));
        productBindingSource.DataSource = productsBindingList;
        ProductsListBox.DataSource = productBindingSource;
        ProductsListBox.SelectedIndexChanged += ProductsListBox_SelectedIndexChanged;

        DisplayCurrentProduct();

    }
}
