namespace ALLHAILAGNIESZKAANDHERMIRACLES
{
    partial class UIActivityObject
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            activityBox = new TextBox();
            SuspendLayout();
            // 
            // activityBox
            // 
            activityBox.Location = new Point(3, 3);
            activityBox.Multiline = true;
            activityBox.Name = "activityBox";
            activityBox.ReadOnly = true;
            activityBox.ScrollBars = ScrollBars.Vertical;
            activityBox.Size = new Size(451, 89);
            activityBox.TabIndex = 0;
            activityBox.TextChanged += activityBox_TextChanged;
            // 
            // UIActivityObject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(activityBox);
            Name = "UIActivityObject";
            Size = new Size(457, 95);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox activityBox;
    }
}
