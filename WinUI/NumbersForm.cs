using DataLayer;

namespace WinUI
{
    /// <summary>
    /// Форма для работы с данными.
    /// </summary>
    public partial class NumbersForm : Form
    {
        #region Private Fields

        /// <inheritdoc cref="DataProviderBase"/>
        private readonly DataProviderBase dataProvider;

        #endregion

        public NumbersForm(DataProviderBase dataProvider)
        {
            Check.ArgumentNotNull(dataProvider, nameof(dataProvider));

            this.dataProvider = dataProvider;
            InitializeComponent();
        }

        private void getFrequenceBtn_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(this.numberTB.Text, out var number))
            {
                MessageBox.Show("Incorrect data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var frequency = this.dataProvider.GetFrequenceByNumber(number);
            var textToShow = frequency.HasValue
                ? $"Frequency for {number} is {frequency}"
                : $"Number {number} not exists";
            MessageBox.Show(textToShow);
        }

        private void getNumbersByFrequenceBtn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(this.frequencyTB.Text, out var frequency))
            {
                MessageBox.Show("Incorrect data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var numbers = this.dataProvider.GetNumberByFrequence(frequency);
            this.numbersByFrequenceRtb.Text = numbers.Any()
                ? string.Join(", ", numbers)
                : $"Values for frequency {frequency} not found";
        }

        private void getTopFrequenceBtn_Click(object sender, EventArgs e)
        {
            var topTen = this.dataProvider.GetTopTenFrequenceNumbers();
            this.topFrequenceRtb.Text = string.Join(Environment.NewLine, topTen.Select(x => $"{x.Key} - {x.Value}"));
        }
    }
}