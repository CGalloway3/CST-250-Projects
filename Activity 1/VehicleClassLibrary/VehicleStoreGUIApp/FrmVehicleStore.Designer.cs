namespace VehicleStoreGUIApp
{
    partial class FrmVehicleStore
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
            gbxCreate = new GroupBox();
            lblEngineSizeWarning = new Label();
            lblWheelsWarning = new Label();
            lblPriceWarning = new Label();
            lblYearWarning = new Label();
            lblColorWarning = new Label();
            lblModelWarning = new Label();
            lblMakeWarning = new Label();
            lblTypeWarning = new Label();
            txtWheels = new TextBox();
            txtEngineSize = new TextBox();
            lblEngineSize = new Label();
            lblWheels = new Label();
            txtMake = new TextBox();
            txtModel = new TextBox();
            txtColor = new TextBox();
            txtYear = new TextBox();
            txtPrice = new TextBox();
            btnCreate = new Button();
            lblPrice = new Label();
            lblYear = new Label();
            lblColor = new Label();
            lblModel = new Label();
            lblMake = new Label();
            rdoVehicle = new RadioButton();
            rdoPickup = new RadioButton();
            rdoMotorcycle = new RadioButton();
            rdoCar = new RadioButton();
            gbxSpecialty = new GroupBox();
            lblSpecialWarning = new Label();
            lblBooleanWarning = new Label();
            rdoSpecialtyNo = new RadioButton();
            rdoSpecialtyYes = new RadioButton();
            txtSpecialtyDecimal = new TextBox();
            lblSpecialtyDecimal = new Label();
            lblSpecialtyBoolean = new Label();
            gbxInventory = new GroupBox();
            lstInventory = new ListBox();
            btnAddToCart = new Button();
            gbxCart = new GroupBox();
            lstShoppingCart = new ListBox();
            btnCheckout = new Button();
            lblTotalLabel = new Label();
            lblTotalAmount = new Label();
            gbxCreate.SuspendLayout();
            gbxSpecialty.SuspendLayout();
            gbxInventory.SuspendLayout();
            gbxCart.SuspendLayout();
            SuspendLayout();
            // 
            // gbxCreate
            // 
            gbxCreate.Controls.Add(lblEngineSizeWarning);
            gbxCreate.Controls.Add(lblWheelsWarning);
            gbxCreate.Controls.Add(lblPriceWarning);
            gbxCreate.Controls.Add(lblYearWarning);
            gbxCreate.Controls.Add(lblColorWarning);
            gbxCreate.Controls.Add(lblModelWarning);
            gbxCreate.Controls.Add(lblMakeWarning);
            gbxCreate.Controls.Add(lblTypeWarning);
            gbxCreate.Controls.Add(txtWheels);
            gbxCreate.Controls.Add(txtEngineSize);
            gbxCreate.Controls.Add(lblEngineSize);
            gbxCreate.Controls.Add(lblWheels);
            gbxCreate.Controls.Add(txtMake);
            gbxCreate.Controls.Add(txtModel);
            gbxCreate.Controls.Add(txtColor);
            gbxCreate.Controls.Add(txtYear);
            gbxCreate.Controls.Add(txtPrice);
            gbxCreate.Controls.Add(btnCreate);
            gbxCreate.Controls.Add(lblPrice);
            gbxCreate.Controls.Add(lblYear);
            gbxCreate.Controls.Add(lblColor);
            gbxCreate.Controls.Add(lblModel);
            gbxCreate.Controls.Add(lblMake);
            gbxCreate.Controls.Add(rdoVehicle);
            gbxCreate.Controls.Add(rdoPickup);
            gbxCreate.Controls.Add(rdoMotorcycle);
            gbxCreate.Controls.Add(rdoCar);
            gbxCreate.Location = new Point(11, 12);
            gbxCreate.Name = "gbxCreate";
            gbxCreate.Size = new Size(227, 438);
            gbxCreate.TabIndex = 0;
            gbxCreate.TabStop = false;
            gbxCreate.Text = "Create a Vehicle";
            // 
            // lblEngineSizeWarning
            // 
            lblEngineSizeWarning.AutoSize = true;
            lblEngineSizeWarning.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEngineSizeWarning.ForeColor = Color.Red;
            lblEngineSizeWarning.Location = new Point(33, 383);
            lblEngineSizeWarning.Name = "lblEngineSizeWarning";
            lblEngineSizeWarning.Size = new Size(180, 15);
            lblEngineSizeWarning.TabIndex = 22;
            lblEngineSizeWarning.Text = "Please enter a valid Engine Size";
            // 
            // lblWheelsWarning
            // 
            lblWheelsWarning.AutoSize = true;
            lblWheelsWarning.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblWheelsWarning.ForeColor = Color.Red;
            lblWheelsWarning.Location = new Point(27, 338);
            lblWheelsWarning.Name = "lblWheelsWarning";
            lblWheelsWarning.Size = new Size(188, 15);
            lblWheelsWarning.TabIndex = 21;
            lblWheelsWarning.Text = "Please enter a valid Wheel count";
            // 
            // lblPriceWarning
            // 
            lblPriceWarning.AutoSize = true;
            lblPriceWarning.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPriceWarning.ForeColor = Color.Red;
            lblPriceWarning.Location = new Point(59, 291);
            lblPriceWarning.Name = "lblPriceWarning";
            lblPriceWarning.Size = new Size(145, 15);
            lblPriceWarning.TabIndex = 20;
            lblPriceWarning.Text = "Please enter a valid Price";
            // 
            // lblYearWarning
            // 
            lblYearWarning.AutoSize = true;
            lblYearWarning.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblYearWarning.ForeColor = Color.Red;
            lblYearWarning.Location = new Point(63, 246);
            lblYearWarning.Name = "lblYearWarning";
            lblYearWarning.Size = new Size(141, 15);
            lblYearWarning.TabIndex = 19;
            lblYearWarning.Text = "Please enter a valid Year";
            // 
            // lblColorWarning
            // 
            lblColorWarning.AutoSize = true;
            lblColorWarning.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblColorWarning.ForeColor = Color.Red;
            lblColorWarning.Location = new Point(92, 201);
            lblColorWarning.Name = "lblColorWarning";
            lblColorWarning.Size = new Size(117, 15);
            lblColorWarning.TabIndex = 18;
            lblColorWarning.Text = "Please enter a Color";
            // 
            // lblModelWarning
            // 
            lblModelWarning.AutoSize = true;
            lblModelWarning.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblModelWarning.ForeColor = Color.Red;
            lblModelWarning.Location = new Point(89, 156);
            lblModelWarning.Name = "lblModelWarning";
            lblModelWarning.Size = new Size(123, 15);
            lblModelWarning.TabIndex = 17;
            lblModelWarning.Text = "Please enter a Model";
            // 
            // lblMakeWarning
            // 
            lblMakeWarning.AutoSize = true;
            lblMakeWarning.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMakeWarning.ForeColor = Color.Red;
            lblMakeWarning.Location = new Point(91, 111);
            lblMakeWarning.Name = "lblMakeWarning";
            lblMakeWarning.Size = new Size(119, 15);
            lblMakeWarning.TabIndex = 16;
            lblMakeWarning.Text = "Please enter a Make";
            // 
            // lblTypeWarning
            // 
            lblTypeWarning.AutoSize = true;
            lblTypeWarning.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTypeWarning.ForeColor = Color.Red;
            lblTypeWarning.Location = new Point(28, 65);
            lblTypeWarning.Name = "lblTypeWarning";
            lblTypeWarning.Size = new Size(166, 15);
            lblTypeWarning.TabIndex = 15;
            lblTypeWarning.Text = "Please Choose a Vehicle Type";
            // 
            // txtWheels
            // 
            txtWheels.Location = new Point(86, 311);
            txtWheels.Name = "txtWheels";
            txtWheels.Size = new Size(130, 23);
            txtWheels.TabIndex = 13;
            txtWheels.Leave += TxtWheelsLeaveEH;
            // 
            // txtEngineSize
            // 
            txtEngineSize.Location = new Point(86, 356);
            txtEngineSize.Name = "txtEngineSize";
            txtEngineSize.Size = new Size(130, 23);
            txtEngineSize.TabIndex = 14;
            txtEngineSize.Leave += TxtEngineSizeLeaveEH;
            // 
            // lblEngineSize
            // 
            lblEngineSize.AutoSize = true;
            lblEngineSize.Location = new Point(12, 361);
            lblEngineSize.Name = "lblEngineSize";
            lblEngineSize.RightToLeft = RightToLeft.No;
            lblEngineSize.Size = new Size(69, 15);
            lblEngineSize.TabIndex = 12;
            lblEngineSize.Text = "Engine Size:";
            lblEngineSize.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblWheels
            // 
            lblWheels.AutoSize = true;
            lblWheels.Location = new Point(33, 316);
            lblWheels.Name = "lblWheels";
            lblWheels.RightToLeft = RightToLeft.No;
            lblWheels.Size = new Size(48, 15);
            lblWheels.TabIndex = 11;
            lblWheels.Text = "Wheels:";
            lblWheels.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtMake
            // 
            txtMake.Location = new Point(86, 84);
            txtMake.Name = "txtMake";
            txtMake.Size = new Size(130, 23);
            txtMake.TabIndex = 10;
            txtMake.Leave += TxtMakeLeaveEH;
            // 
            // txtModel
            // 
            txtModel.Location = new Point(86, 129);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(130, 23);
            txtModel.TabIndex = 10;
            txtModel.Leave += TxtModelLeaveEH;
            // 
            // txtColor
            // 
            txtColor.Location = new Point(86, 174);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(130, 23);
            txtColor.TabIndex = 10;
            txtColor.Leave += TxtColorLeaveEH;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(86, 219);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(130, 23);
            txtYear.TabIndex = 10;
            txtYear.Leave += TxtYearLeaveEH;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(86, 264);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(130, 23);
            txtPrice.TabIndex = 10;
            txtPrice.Leave += TxtPriceLeaveEH;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(83, 403);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 23);
            btnCreate.TabIndex = 9;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += BtnCreateClickEH;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(45, 269);
            lblPrice.Name = "lblPrice";
            lblPrice.RightToLeft = RightToLeft.No;
            lblPrice.Size = new Size(36, 15);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "Price:";
            lblPrice.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(49, 224);
            lblYear.Name = "lblYear";
            lblYear.RightToLeft = RightToLeft.No;
            lblYear.Size = new Size(32, 15);
            lblYear.TabIndex = 7;
            lblYear.Text = "Year:";
            lblYear.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Location = new Point(42, 179);
            lblColor.Name = "lblColor";
            lblColor.RightToLeft = RightToLeft.No;
            lblColor.Size = new Size(39, 15);
            lblColor.TabIndex = 6;
            lblColor.Text = "Color:";
            lblColor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.Location = new Point(37, 134);
            lblModel.Name = "lblModel";
            lblModel.RightToLeft = RightToLeft.No;
            lblModel.Size = new Size(44, 15);
            lblModel.TabIndex = 5;
            lblModel.Text = "Model:";
            lblModel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblMake
            // 
            lblMake.AutoSize = true;
            lblMake.Location = new Point(42, 89);
            lblMake.Name = "lblMake";
            lblMake.RightToLeft = RightToLeft.No;
            lblMake.Size = new Size(39, 15);
            lblMake.TabIndex = 4;
            lblMake.Text = "Make:";
            lblMake.TextAlign = ContentAlignment.MiddleRight;
            // 
            // rdoVehicle
            // 
            rdoVehicle.AutoSize = true;
            rdoVehicle.Location = new Point(113, 44);
            rdoVehicle.Name = "rdoVehicle";
            rdoVehicle.Size = new Size(62, 19);
            rdoVehicle.TabIndex = 3;
            rdoVehicle.TabStop = true;
            rdoVehicle.Text = "Vehicle";
            rdoVehicle.UseVisualStyleBackColor = true;
            rdoVehicle.Click += RdoVehicleClickEH;
            // 
            // rdoPickup
            // 
            rdoPickup.AutoSize = true;
            rdoPickup.Location = new Point(11, 44);
            rdoPickup.Name = "rdoPickup";
            rdoPickup.Size = new Size(61, 19);
            rdoPickup.TabIndex = 2;
            rdoPickup.TabStop = true;
            rdoPickup.Text = "Pickup";
            rdoPickup.UseVisualStyleBackColor = true;
            rdoPickup.Click += RdoPickupClickEH;
            // 
            // rdoMotorcycle
            // 
            rdoMotorcycle.AutoSize = true;
            rdoMotorcycle.Location = new Point(113, 22);
            rdoMotorcycle.Name = "rdoMotorcycle";
            rdoMotorcycle.Size = new Size(85, 19);
            rdoMotorcycle.TabIndex = 1;
            rdoMotorcycle.TabStop = true;
            rdoMotorcycle.Text = "Motorcycle";
            rdoMotorcycle.UseVisualStyleBackColor = true;
            rdoMotorcycle.Click += RdoMotorcycleClickEH;
            // 
            // rdoCar
            // 
            rdoCar.AutoSize = true;
            rdoCar.Location = new Point(12, 22);
            rdoCar.Name = "rdoCar";
            rdoCar.Size = new Size(43, 19);
            rdoCar.TabIndex = 0;
            rdoCar.TabStop = true;
            rdoCar.Text = "Car";
            rdoCar.UseVisualStyleBackColor = true;
            rdoCar.Click += RdoCarClickEH;
            // 
            // gbxSpecialty
            // 
            gbxSpecialty.Controls.Add(lblSpecialWarning);
            gbxSpecialty.Controls.Add(lblBooleanWarning);
            gbxSpecialty.Controls.Add(rdoSpecialtyNo);
            gbxSpecialty.Controls.Add(rdoSpecialtyYes);
            gbxSpecialty.Controls.Add(txtSpecialtyDecimal);
            gbxSpecialty.Controls.Add(lblSpecialtyDecimal);
            gbxSpecialty.Controls.Add(lblSpecialtyBoolean);
            gbxSpecialty.Location = new Point(12, 456);
            gbxSpecialty.Name = "gbxSpecialty";
            gbxSpecialty.Size = new Size(226, 142);
            gbxSpecialty.TabIndex = 1;
            gbxSpecialty.TabStop = false;
            gbxSpecialty.Text = "Specialty Properties";
            // 
            // lblSpecialWarning
            // 
            lblSpecialWarning.AutoSize = true;
            lblSpecialWarning.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSpecialWarning.ForeColor = Color.Red;
            lblSpecialWarning.Location = new Point(46, 118);
            lblSpecialWarning.Name = "lblSpecialWarning";
            lblSpecialWarning.Size = new Size(161, 15);
            lblSpecialWarning.TabIndex = 6;
            lblSpecialWarning.Text = "Please enter a valid number";
            // 
            // lblBooleanWarning
            // 
            lblBooleanWarning.AutoSize = true;
            lblBooleanWarning.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBooleanWarning.ForeColor = Color.Red;
            lblBooleanWarning.Location = new Point(12, 71);
            lblBooleanWarning.Name = "lblBooleanWarning";
            lblBooleanWarning.Size = new Size(133, 15);
            lblBooleanWarning.TabIndex = 5;
            lblBooleanWarning.Text = "Please select Yes or No";
            // 
            // rdoSpecialtyNo
            // 
            rdoSpecialtyNo.AutoSize = true;
            rdoSpecialtyNo.Location = new Point(76, 48);
            rdoSpecialtyNo.Name = "rdoSpecialtyNo";
            rdoSpecialtyNo.Size = new Size(41, 19);
            rdoSpecialtyNo.TabIndex = 4;
            rdoSpecialtyNo.TabStop = true;
            rdoSpecialtyNo.Text = "No";
            rdoSpecialtyNo.UseVisualStyleBackColor = true;
            rdoSpecialtyNo.Click += RdoSpecialtyBooleanClickEH;
            // 
            // rdoSpecialtyYes
            // 
            rdoSpecialtyYes.AutoSize = true;
            rdoSpecialtyYes.Location = new Point(29, 48);
            rdoSpecialtyYes.Name = "rdoSpecialtyYes";
            rdoSpecialtyYes.Size = new Size(42, 19);
            rdoSpecialtyYes.TabIndex = 3;
            rdoSpecialtyYes.TabStop = true;
            rdoSpecialtyYes.Text = "Yes";
            rdoSpecialtyYes.UseVisualStyleBackColor = true;
            rdoSpecialtyYes.Click += RdoSpecialtyBooleanClickEH;
            // 
            // txtSpecialtyDecimal
            // 
            txtSpecialtyDecimal.Location = new Point(134, 92);
            txtSpecialtyDecimal.Name = "txtSpecialtyDecimal";
            txtSpecialtyDecimal.Size = new Size(79, 23);
            txtSpecialtyDecimal.TabIndex = 2;
            txtSpecialtyDecimal.Leave += TxtSpecialLeaveEH;
            // 
            // lblSpecialtyDecimal
            // 
            lblSpecialtyDecimal.AutoSize = true;
            lblSpecialtyDecimal.Location = new Point(5, 98);
            lblSpecialtyDecimal.Name = "lblSpecialtyDecimal";
            lblSpecialtyDecimal.Size = new Size(103, 15);
            lblSpecialtyDecimal.TabIndex = 1;
            lblSpecialtyDecimal.Text = "Specialty Decimal:";
            // 
            // lblSpecialtyBoolean
            // 
            lblSpecialtyBoolean.AutoSize = true;
            lblSpecialtyBoolean.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSpecialtyBoolean.ForeColor = SystemColors.ControlText;
            lblSpecialtyBoolean.Location = new Point(11, 30);
            lblSpecialtyBoolean.Name = "lblSpecialtyBoolean";
            lblSpecialtyBoolean.Size = new Size(103, 15);
            lblSpecialtyBoolean.TabIndex = 0;
            lblSpecialtyBoolean.Text = "Specialty Boolean:";
            // 
            // gbxInventory
            // 
            gbxInventory.Controls.Add(lstInventory);
            gbxInventory.Location = new Point(244, 12);
            gbxInventory.Name = "gbxInventory";
            gbxInventory.Size = new Size(262, 503);
            gbxInventory.TabIndex = 2;
            gbxInventory.TabStop = false;
            gbxInventory.Text = "Inventory";
            // 
            // lstInventory
            // 
            lstInventory.FormattingEnabled = true;
            lstInventory.Location = new Point(6, 16);
            lstInventory.Name = "lstInventory";
            lstInventory.Size = new Size(250, 484);
            lstInventory.TabIndex = 0;
            // 
            // btnAddToCart
            // 
            btnAddToCart.Location = new Point(512, 198);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(71, 56);
            btnAddToCart.TabIndex = 3;
            btnAddToCart.Text = "Add to Cart";
            btnAddToCart.UseVisualStyleBackColor = true;
            // 
            // gbxCart
            // 
            gbxCart.Controls.Add(lstShoppingCart);
            gbxCart.Location = new Point(589, 12);
            gbxCart.Name = "gbxCart";
            gbxCart.Size = new Size(261, 503);
            gbxCart.TabIndex = 4;
            gbxCart.TabStop = false;
            gbxCart.Text = "Shopping Cart";
            // 
            // lstShoppingCart
            // 
            lstShoppingCart.FormattingEnabled = true;
            lstShoppingCart.Location = new Point(6, 16);
            lstShoppingCart.Name = "lstShoppingCart";
            lstShoppingCart.Size = new Size(250, 484);
            lstShoppingCart.TabIndex = 0;
            // 
            // btnCheckout
            // 
            btnCheckout.Font = new Font("Segoe UI", 12F);
            btnCheckout.Location = new Point(502, 534);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(95, 37);
            btnCheckout.TabIndex = 5;
            btnCheckout.Text = "Checkout";
            btnCheckout.UseVisualStyleBackColor = true;
            // 
            // lblTotalLabel
            // 
            lblTotalLabel.AutoSize = true;
            lblTotalLabel.Font = new Font("Segoe UI", 12F);
            lblTotalLabel.Location = new Point(492, 574);
            lblTotalLabel.Name = "lblTotalLabel";
            lblTotalLabel.Size = new Size(45, 21);
            lblTotalLabel.TabIndex = 6;
            lblTotalLabel.Text = "Total:";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 12F);
            lblTotalAmount.Location = new Point(546, 575);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(28, 21);
            lblTotalAmount.TabIndex = 7;
            lblTotalAmount.Text = "$0";
            // 
            // FrmVehicleStore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 609);
            Controls.Add(lblTotalAmount);
            Controls.Add(lblTotalLabel);
            Controls.Add(btnCheckout);
            Controls.Add(gbxCart);
            Controls.Add(btnAddToCart);
            Controls.Add(gbxInventory);
            Controls.Add(gbxSpecialty);
            Controls.Add(gbxCreate);
            Name = "FrmVehicleStore";
            Text = "Vehicel Store";
            gbxCreate.ResumeLayout(false);
            gbxCreate.PerformLayout();
            gbxSpecialty.ResumeLayout(false);
            gbxSpecialty.PerformLayout();
            gbxInventory.ResumeLayout(false);
            gbxCart.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbxCreate;
        private Label lblPrice;
        private Label lblYear;
        private Label lblColor;
        private Label lblModel;
        private Label lblMake;
        private RadioButton rdoVehicle;
        private RadioButton rdoPickup;
        private RadioButton rdoMotorcycle;
        private RadioButton rdoCar;
        private TextBox txtMake;
        private TextBox txtModel;
        private TextBox txtColor;
        private TextBox txtYear;
        private TextBox txtPrice;
        private Button btnCreate;
        private GroupBox gbxSpecialty;
        private TextBox txtWheels;
        private TextBox txtEngineSize;
        private Label lblEngineSize;
        private Label lblWheels;
        private RadioButton rdoSpecialtyNo;
        private RadioButton rdoSpecialtyYes;
        private TextBox txtSpecialtyDecimal;
        private Label lblSpecialtyDecimal;
        private Label lblSpecialtyBoolean;
        private GroupBox gbxInventory;
        private ListBox lstInventory;
        private Button btnAddToCart;
        private GroupBox gbxCart;
        private ListBox lstShoppingCart;
        private Button btnCheckout;
        private Label lblEngineSizeWarning;
        private Label lblWheelsWarning;
        private Label lblPriceWarning;
        private Label lblYearWarning;
        private Label lblColorWarning;
        private Label lblModelWarning;
        private Label lblMakeWarning;
        private Label lblTypeWarning;
        private Label lblSpecialWarning;
        private Label lblBooleanWarning;
        private Label lblTotalLabel;
        private Label lblTotalAmount;
    }
}
