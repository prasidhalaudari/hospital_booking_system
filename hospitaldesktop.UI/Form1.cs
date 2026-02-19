using hospitaldesktop.BLL.Interfaces;
using System.Threading.Tasks;
namespace hospitaldesktop.UI
{
    public partial class Form1 : Form
    {
        private readonly IAuthService _auth;

        public Form1(IAuthService auth)
        {
            InitializeComponent();
            _auth = auth;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            button1.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                var result = await _auth.LoginAsync(username, password);

                if (result.Success)
                {
                    MessageBox.Show("Login successful!");

                    var role = (result.Role ?? "").Trim().ToLowerInvariant();

                    Form next;
                    switch ((result.Role ?? "").Trim().ToLowerInvariant())
                    {
                        case "admin":
                            next = new Form2(result);   // Admin dashboard
                            break;

                        case "patient":
                            next = new Form3(result);   // Patient page
                            break;

                        default:
                            MessageBox.Show($"Logged in, but role '{result.Role}' is not recognized.");
                            return;
                    }

                    next.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Invalid username or password.");
                    textBox2.Clear();
                    textBox2.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                button1.Enabled = true;
                Cursor = Cursors.Default;
            }
        }
    }
}
