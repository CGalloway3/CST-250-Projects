namespace PizzaMaker
{
    partial class FrmPizzaMarker
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblName = new Label();
            txtName = new TextBox();
            grpIngredients = new GroupBox();
            chbTomatoes = new CheckBox();
            chbPeppers = new CheckBox();
            chbSausage = new CheckBox();
            chbPineapple = new CheckBox();
            chbMushrooms = new CheckBox();
            chbOlives = new CheckBox();
            chbBacon = new CheckBox();
            chbPepperoni = new CheckBox();
            lblStrangeAddOns = new Label();
            lsbStrangeAddOns = new ListBox();
            grpCrust = new GroupBox();
            rdoGlutenFree = new RadioButton();
            rdoStuffedCrust = new RadioButton();
            rdoDeepDish = new RadioButton();
            rdoThinCrust = new RadioButton();
            grpExtraGoodies = new GroupBox();
            lblSauceAmount = new Label();
            lblSauce = new Label();
            hsbSauce = new HScrollBar();
            lblCheeseAmount = new Label();
            lblCheese = new Label();
            hsbCheese = new HScrollBar();
            lblDeliveryTime = new Label();
            dtpDeliveryTime = new DateTimePicker();
            lblPizzaBoxColor = new Label();
            picPizzaBoxColor = new PictureBox();
            lblPizzaPriceText = new Label();
            lblPizzaPriceAmount = new Label();
            btnResetForm = new Button();
            btnCreatePizza = new Button();
            grpIngredients.SuspendLayout();
            grpCrust.SuspendLayout();
            grpExtraGoodies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPizzaBoxColor).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(18, 17);
            lblName.Name = "lblName";
            lblName.Size = new Size(55, 18);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(73, 14);
            txtName.Name = "txtName";
            txtName.Size = new Size(181, 26);
            txtName.TabIndex = 1;
            txtName.Leave += TxtNameLeaveEH;
            // 
            // grpIngredients
            // 
            grpIngredients.Controls.Add(chbTomatoes);
            grpIngredients.Controls.Add(chbPeppers);
            grpIngredients.Controls.Add(chbSausage);
            grpIngredients.Controls.Add(chbPineapple);
            grpIngredients.Controls.Add(chbMushrooms);
            grpIngredients.Controls.Add(chbOlives);
            grpIngredients.Controls.Add(chbBacon);
            grpIngredients.Controls.Add(chbPepperoni);
            grpIngredients.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpIngredients.Location = new Point(18, 56);
            grpIngredients.Name = "grpIngredients";
            grpIngredients.Size = new Size(253, 147);
            grpIngredients.TabIndex = 2;
            grpIngredients.TabStop = false;
            grpIngredients.Text = "Ingredients";
            // 
            // chbTomatoes
            // 
            chbTomatoes.AutoSize = true;
            chbTomatoes.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chbTomatoes.Location = new Point(139, 109);
            chbTomatoes.Name = "chbTomatoes";
            chbTomatoes.Size = new Size(97, 22);
            chbTomatoes.TabIndex = 7;
            chbTomatoes.Text = "Tomatoes";
            chbTomatoes.UseVisualStyleBackColor = true;
            chbTomatoes.CheckedChanged += ChbIngredientsCheckedChangedEH;
            // 
            // chbPeppers
            // 
            chbPeppers.AutoSize = true;
            chbPeppers.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chbPeppers.Location = new Point(139, 81);
            chbPeppers.Name = "chbPeppers";
            chbPeppers.Size = new Size(85, 22);
            chbPeppers.TabIndex = 6;
            chbPeppers.Text = "Peppers";
            chbPeppers.UseVisualStyleBackColor = true;
            chbPeppers.CheckedChanged += ChbIngredientsCheckedChangedEH;
            // 
            // chbSausage
            // 
            chbSausage.AutoSize = true;
            chbSausage.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chbSausage.Location = new Point(139, 53);
            chbSausage.Name = "chbSausage";
            chbSausage.Size = new Size(84, 22);
            chbSausage.TabIndex = 5;
            chbSausage.Text = "Sausage";
            chbSausage.UseVisualStyleBackColor = true;
            chbSausage.CheckedChanged += ChbIngredientsCheckedChangedEH;
            // 
            // chbPineapple
            // 
            chbPineapple.AutoSize = true;
            chbPineapple.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chbPineapple.Location = new Point(139, 25);
            chbPineapple.Name = "chbPineapple";
            chbPineapple.Size = new Size(96, 22);
            chbPineapple.TabIndex = 4;
            chbPineapple.Text = "Pineapple";
            chbPineapple.UseVisualStyleBackColor = true;
            chbPineapple.CheckedChanged += ChbIngredientsCheckedChangedEH;
            // 
            // chbMushrooms
            // 
            chbMushrooms.AutoSize = true;
            chbMushrooms.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chbMushrooms.Location = new Point(12, 109);
            chbMushrooms.Name = "chbMushrooms";
            chbMushrooms.Size = new Size(111, 22);
            chbMushrooms.TabIndex = 3;
            chbMushrooms.Text = "Mushrooms";
            chbMushrooms.UseVisualStyleBackColor = true;
            chbMushrooms.CheckedChanged += ChbIngredientsCheckedChangedEH;
            // 
            // chbOlives
            // 
            chbOlives.AutoSize = true;
            chbOlives.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chbOlives.Location = new Point(12, 81);
            chbOlives.Name = "chbOlives";
            chbOlives.Size = new Size(71, 22);
            chbOlives.TabIndex = 2;
            chbOlives.Text = "Olives";
            chbOlives.UseVisualStyleBackColor = true;
            chbOlives.CheckedChanged += ChbIngredientsCheckedChangedEH;
            // 
            // chbBacon
            // 
            chbBacon.AutoSize = true;
            chbBacon.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chbBacon.Location = new Point(12, 53);
            chbBacon.Name = "chbBacon";
            chbBacon.Size = new Size(69, 22);
            chbBacon.TabIndex = 1;
            chbBacon.Text = "Bacon";
            chbBacon.UseVisualStyleBackColor = true;
            chbBacon.CheckedChanged += ChbIngredientsCheckedChangedEH;
            // 
            // chbPepperoni
            // 
            chbPepperoni.AutoSize = true;
            chbPepperoni.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chbPepperoni.Location = new Point(12, 25);
            chbPepperoni.Name = "chbPepperoni";
            chbPepperoni.Size = new Size(99, 22);
            chbPepperoni.TabIndex = 0;
            chbPepperoni.Text = "Pepperoni";
            chbPepperoni.UseVisualStyleBackColor = true;
            chbPepperoni.CheckedChanged += ChbIngredientsCheckedChangedEH;
            // 
            // lblStrangeAddOns
            // 
            lblStrangeAddOns.AutoSize = true;
            lblStrangeAddOns.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStrangeAddOns.Location = new Point(22, 217);
            lblStrangeAddOns.Name = "lblStrangeAddOns";
            lblStrangeAddOns.Size = new Size(146, 18);
            lblStrangeAddOns.TabIndex = 3;
            lblStrangeAddOns.Text = "Strange Add Ons";
            // 
            // lsbStrangeAddOns
            // 
            lsbStrangeAddOns.FormattingEnabled = true;
            lsbStrangeAddOns.Items.AddRange(new object[] { "Hotdogs", "Eggplant", "Artichoke Hearts", "Eggs", "Peanut Butter", "Prosciutto", "Honey", "Chilli Thread", "Olive Oil", "Arugula", "Garlic", "Chicken", "Anchovies", "BBQ Sauce", "Green Onions", "Red Onions", "Carrots", "Peanuts" });
            lsbStrangeAddOns.Location = new Point(18, 238);
            lsbStrangeAddOns.Name = "lsbStrangeAddOns";
            lsbStrangeAddOns.SelectionMode = SelectionMode.MultiSimple;
            lsbStrangeAddOns.Size = new Size(150, 148);
            lsbStrangeAddOns.TabIndex = 4;
            lsbStrangeAddOns.SelectedIndexChanged += LsbStrangeAddOnsSelectedIndexChangedEH;
            // 
            // grpCrust
            // 
            grpCrust.Controls.Add(rdoGlutenFree);
            grpCrust.Controls.Add(rdoStuffedCrust);
            grpCrust.Controls.Add(rdoDeepDish);
            grpCrust.Controls.Add(rdoThinCrust);
            grpCrust.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpCrust.Location = new Point(174, 223);
            grpCrust.Name = "grpCrust";
            grpCrust.Size = new Size(132, 163);
            grpCrust.TabIndex = 5;
            grpCrust.TabStop = false;
            grpCrust.Text = "Crust";
            // 
            // rdoGlutenFree
            // 
            rdoGlutenFree.AutoSize = true;
            rdoGlutenFree.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoGlutenFree.Location = new Point(5, 111);
            rdoGlutenFree.Name = "rdoGlutenFree";
            rdoGlutenFree.Size = new Size(111, 22);
            rdoGlutenFree.TabIndex = 3;
            rdoGlutenFree.TabStop = true;
            rdoGlutenFree.Text = "Gluten Free";
            rdoGlutenFree.UseVisualStyleBackColor = true;
            rdoGlutenFree.CheckedChanged += RdoCrustCheckedChangedEH;
            // 
            // rdoStuffedCrust
            // 
            rdoStuffedCrust.AutoSize = true;
            rdoStuffedCrust.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoStuffedCrust.Location = new Point(6, 83);
            rdoStuffedCrust.Name = "rdoStuffedCrust";
            rdoStuffedCrust.Size = new Size(120, 22);
            rdoStuffedCrust.TabIndex = 2;
            rdoStuffedCrust.TabStop = true;
            rdoStuffedCrust.Text = "Stuffed Crust";
            rdoStuffedCrust.UseVisualStyleBackColor = true;
            rdoStuffedCrust.CheckedChanged += RdoCrustCheckedChangedEH;
            // 
            // rdoDeepDish
            // 
            rdoDeepDish.AutoSize = true;
            rdoDeepDish.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoDeepDish.Location = new Point(6, 55);
            rdoDeepDish.Name = "rdoDeepDish";
            rdoDeepDish.Size = new Size(97, 22);
            rdoDeepDish.TabIndex = 1;
            rdoDeepDish.TabStop = true;
            rdoDeepDish.Text = "Deep Dish";
            rdoDeepDish.UseVisualStyleBackColor = true;
            rdoDeepDish.CheckedChanged += RdoCrustCheckedChangedEH;
            // 
            // rdoThinCrust
            // 
            rdoThinCrust.AutoSize = true;
            rdoThinCrust.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoThinCrust.Location = new Point(6, 27);
            rdoThinCrust.Name = "rdoThinCrust";
            rdoThinCrust.Size = new Size(102, 22);
            rdoThinCrust.TabIndex = 0;
            rdoThinCrust.TabStop = true;
            rdoThinCrust.Text = "Thin Crust";
            rdoThinCrust.UseVisualStyleBackColor = true;
            rdoThinCrust.CheckedChanged += RdoCrustCheckedChangedEH;
            // 
            // grpExtraGoodies
            // 
            grpExtraGoodies.Controls.Add(lblSauceAmount);
            grpExtraGoodies.Controls.Add(lblSauce);
            grpExtraGoodies.Controls.Add(hsbSauce);
            grpExtraGoodies.Controls.Add(lblCheeseAmount);
            grpExtraGoodies.Controls.Add(lblCheese);
            grpExtraGoodies.Controls.Add(hsbCheese);
            grpExtraGoodies.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpExtraGoodies.Location = new Point(18, 392);
            grpExtraGoodies.Name = "grpExtraGoodies";
            grpExtraGoodies.Size = new Size(288, 136);
            grpExtraGoodies.TabIndex = 6;
            grpExtraGoodies.TabStop = false;
            grpExtraGoodies.Text = "Extra Goodies";
            // 
            // lblSauceAmount
            // 
            lblSauceAmount.AutoSize = true;
            lblSauceAmount.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSauceAmount.Location = new Point(145, 32);
            lblSauceAmount.Name = "lblSauceAmount";
            lblSauceAmount.Size = new Size(28, 18);
            lblSauceAmount.TabIndex = 6;
            lblSauceAmount.Text = "00";
            lblSauceAmount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSauce
            // 
            lblSauce.AutoSize = true;
            lblSauce.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSauce.Location = new Point(12, 32);
            lblSauce.Name = "lblSauce";
            lblSauce.Size = new Size(127, 18);
            lblSauce.TabIndex = 5;
            lblSauce.Text = "Amount of Sauce";
            // 
            // hsbSauce
            // 
            hsbSauce.Location = new Point(6, 50);
            hsbSauce.Name = "hsbSauce";
            hsbSauce.Size = new Size(270, 20);
            hsbSauce.TabIndex = 4;
            // 
            // lblCheeseAmount
            // 
            lblCheeseAmount.AutoSize = true;
            lblCheeseAmount.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCheeseAmount.Location = new Point(153, 84);
            lblCheeseAmount.Name = "lblCheeseAmount";
            lblCheeseAmount.Size = new Size(28, 18);
            lblCheeseAmount.TabIndex = 3;
            lblCheeseAmount.Text = "00";
            lblCheeseAmount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCheese
            // 
            lblCheese.AutoSize = true;
            lblCheese.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCheese.Location = new Point(11, 84);
            lblCheese.Name = "lblCheese";
            lblCheese.Size = new Size(136, 18);
            lblCheese.TabIndex = 2;
            lblCheese.Text = "Amount of Cheese";
            // 
            // hsbCheese
            // 
            hsbCheese.Location = new Point(6, 102);
            hsbCheese.Name = "hsbCheese";
            hsbCheese.Size = new Size(270, 20);
            hsbCheese.TabIndex = 1;
            // 
            // lblDeliveryTime
            // 
            lblDeliveryTime.AutoSize = true;
            lblDeliveryTime.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDeliveryTime.Location = new Point(284, 22);
            lblDeliveryTime.Name = "lblDeliveryTime";
            lblDeliveryTime.Size = new Size(123, 18);
            lblDeliveryTime.TabIndex = 7;
            lblDeliveryTime.Text = "Delivery Time";
            // 
            // dtpDeliveryTime
            // 
            dtpDeliveryTime.CustomFormat = "MM/dd/yy HH:mm";
            dtpDeliveryTime.Format = DateTimePickerFormat.Custom;
            dtpDeliveryTime.Location = new Point(284, 43);
            dtpDeliveryTime.MinDate = new DateTime(2025, 11, 10, 0, 0, 0, 0);
            dtpDeliveryTime.Name = "dtpDeliveryTime";
            dtpDeliveryTime.Size = new Size(215, 26);
            dtpDeliveryTime.TabIndex = 8;
            dtpDeliveryTime.Value = new DateTime(2025, 11, 12, 12, 0, 0, 0);
            // 
            // lblPizzaBoxColor
            // 
            lblPizzaBoxColor.AutoSize = true;
            lblPizzaBoxColor.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPizzaBoxColor.Location = new Point(284, 82);
            lblPizzaBoxColor.Name = "lblPizzaBoxColor";
            lblPizzaBoxColor.Size = new Size(137, 18);
            lblPizzaBoxColor.TabIndex = 9;
            lblPizzaBoxColor.Text = "Pizza Box Color";
            // 
            // picPizzaBoxColor
            // 
            picPizzaBoxColor.BorderStyle = BorderStyle.FixedSingle;
            picPizzaBoxColor.Location = new Point(284, 103);
            picPizzaBoxColor.Name = "picPizzaBoxColor";
            picPizzaBoxColor.Size = new Size(215, 50);
            picPizzaBoxColor.TabIndex = 10;
            picPizzaBoxColor.TabStop = false;
            // 
            // lblPizzaPriceText
            // 
            lblPizzaPriceText.AutoSize = true;
            lblPizzaPriceText.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPizzaPriceText.Location = new Point(284, 165);
            lblPizzaPriceText.Name = "lblPizzaPriceText";
            lblPizzaPriceText.Size = new Size(106, 18);
            lblPizzaPriceText.TabIndex = 11;
            lblPizzaPriceText.Text = "Pizza Price:";
            // 
            // lblPizzaPriceAmount
            // 
            lblPizzaPriceAmount.AutoSize = true;
            lblPizzaPriceAmount.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPizzaPriceAmount.ForeColor = Color.Red;
            lblPizzaPriceAmount.Location = new Point(391, 165);
            lblPizzaPriceAmount.Name = "lblPizzaPriceAmount";
            lblPizzaPriceAmount.Size = new Size(27, 18);
            lblPizzaPriceAmount.TabIndex = 12;
            lblPizzaPriceAmount.Text = "$0";
            // 
            // btnResetForm
            // 
            btnResetForm.Location = new Point(284, 192);
            btnResetForm.Name = "btnResetForm";
            btnResetForm.Size = new Size(105, 25);
            btnResetForm.TabIndex = 13;
            btnResetForm.Text = "Reset Form";
            btnResetForm.UseVisualStyleBackColor = true;
            // 
            // btnCreatePizza
            // 
            btnCreatePizza.Location = new Point(394, 192);
            btnCreatePizza.Name = "btnCreatePizza";
            btnCreatePizza.Size = new Size(105, 25);
            btnCreatePizza.TabIndex = 14;
            btnCreatePizza.Text = "Create Pizza";
            btnCreatePizza.UseVisualStyleBackColor = true;
            // 
            // FrmPizzaMarker
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 540);
            Controls.Add(btnCreatePizza);
            Controls.Add(btnResetForm);
            Controls.Add(lblPizzaPriceAmount);
            Controls.Add(lblPizzaPriceText);
            Controls.Add(picPizzaBoxColor);
            Controls.Add(lblPizzaBoxColor);
            Controls.Add(dtpDeliveryTime);
            Controls.Add(lblDeliveryTime);
            Controls.Add(grpExtraGoodies);
            Controls.Add(grpCrust);
            Controls.Add(lsbStrangeAddOns);
            Controls.Add(lblStrangeAddOns);
            Controls.Add(grpIngredients);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FrmPizzaMarker";
            Text = "Pizza Maker";
            grpIngredients.ResumeLayout(false);
            grpIngredients.PerformLayout();
            grpCrust.ResumeLayout(false);
            grpCrust.PerformLayout();
            grpExtraGoodies.ResumeLayout(false);
            grpExtraGoodies.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPizzaBoxColor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private GroupBox grpIngredients;
        private CheckBox chbBacon;
        private CheckBox chbPepperoni;
        private CheckBox chbTomatoes;
        private CheckBox chbPeppers;
        private CheckBox chbSausage;
        private CheckBox chbPineapple;
        private CheckBox chbMushrooms;
        private CheckBox chbOlives;
        private Label lblStrangeAddOns;
        private ListBox lsbStrangeAddOns;
        private GroupBox grpCrust;
        private RadioButton rdoGlutenFree;
        private RadioButton rdoStuffedCrust;
        private RadioButton rdoDeepDish;
        private RadioButton rdoThinCrust;
        private GroupBox grpExtraGoodies;
        private Label lblCheeseAmount;
        private Label lblCheese;
        private HScrollBar hsbCheese;
        private Label lblSauceAmount;
        private Label lblSauce;
        private HScrollBar hsbSauce;
        private Label lblDeliveryTime;
        private DateTimePicker dtpDeliveryTime;
        private Label lblPizzaBoxColor;
        private PictureBox picPizzaBoxColor;
        private Label lblPizzaPriceText;
        private Label lblPizzaPriceAmount;
        private Button btnResetForm;
        private Button btnCreatePizza;
    }
}
