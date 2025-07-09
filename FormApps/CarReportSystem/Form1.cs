using System.ComponentModel;
using System.Data.SqlTypes;
using System.Drawing.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //�J�[���|�[�g�Ǘ��p���X�g
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        public Form1() {
            InitializeComponent();
            dgvRecord.DataSource = listCarReports;

        }

        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void setCbAuthor(string author) {
            //���ɓo�^�ς݂��m�F
            if (!cbAuthor.Items.Contains(author)) {
                //���o�^�Ȃ�o�^
                cbAuthor.Items.Add(author);
            }
        }

        //�Ԗ��̗������R���{�{�b�N�X�֓o�^�i�d���Ȃ��j
        private void setCbCarName(string carName) {

        }

        private void btRecordAdd_Click(object sender, EventArgs e) {

            if (cbAuthor.Text != String.Empty || cbCarName.Text == String.Empty) {
                tsslbMessage.Text = "�L�^�ҁA�܂��͎Ԗ��������͂ł�";
                return;
            }


            var carReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text,
                Picture = pbPicture.Image,
            };
            listCarReports.Add(carReport);
            setCbAuthor(cbAuthor.Text);//�R���{�{�b�N�X�֓o�^
            setCbCarName(cbCarName.Text);
            InputItemAllClear();//�o�^��̓N���A

        }


        private void tsmiExit_Click(object sender, EventArgs e) {

        }

        private void InputItemAllClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = string.Empty;
            rbOther.Checked = true;
            cbCarName.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;
        }

        private MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked)
                return MakerGroup.�g���^;
            if (rbNissan.Checked)
                return MakerGroup.���Y;
            if (rbHonda.Checked)
                return MakerGroup.�{�c;
            if (rbSubaru.Checked)
                return MakerGroup.�X�o��;
            if (rbImport.Checked)
                return MakerGroup.�A����;

            return MakerGroup.���̑�;
        }

        private void dgvRecord_Click(object sender, EventArgs e) {
            if (dgvRecord.CurrentRow is null) return;

            dtpDate.Value = (DateTime)dgvRecord.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecord.CurrentRow.Cells["Author"].Value;
            setRadioButtonMaker((MakerGroup)dgvRecord.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvRecord.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecord.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecord.CurrentRow.Cells["picture"].Value;

        }
        private void setRadioButtonMaker(MakerGroup targetMaker) {
            switch (targetMaker) {
                case MakerGroup.�g���^:
                    rbToyota.Checked = true;
                    break;
                case MakerGroup.���Y:
                    rbNissan.Checked = true;
                    break;
                case MakerGroup.�{�c:
                    rbHonda.Checked = true;
                    break;
                case MakerGroup.�X�o��:
                    rbSubaru.Checked = true;
                    break;
                case MakerGroup.�A����:
                    rbImport.Checked = true;
                    break;


            }
        }

        //�V�K�ǉ��̃C�x���g�n���h��
        private void btNewRecord_Click(object sender, EventArgs e) {
            InputItemAllClear();
        }
        //�C���{�^���̃C�x���g�n���h��
        private void btRecordModify_Click(object sender, EventArgs e) {
            if (dgvRecord.Rows.Count == 0) return;

            listCarReports[dgvRecord.CurrentRow.Index].Date = dtpDate.Value;
            listCarReports[dgvRecord.CurrentRow.Index].Author = cbAuthor.Text;
            listCarReports[dgvRecord.CurrentRow.Index].Maker = GetRadioButtonMaker();
            listCarReports[dgvRecord.CurrentRow.Index].CarName = cbCarName.Text;
            listCarReports[dgvRecord.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvRecord.CurrentRow.Index].Picture = pbPicture.Image;
        }

        private void btRecordDelete_Click(object sender, EventArgs e) {
            if ((dgvRecord.CurrentRow == null)
                || (!dgvRecord.CurrentRow.Selected)) return;

            //�I������Ă���index���擾
            int index = dgvRecord.CurrentRow.Index;
            //��������Ă���index���w�肵�ă��X�g����폜
            listCarReports.RemoveAt(index);
        }

        private void Form1_Load(object sender, EventArgs e) {
            dgvRecord.DefaultCellStyle.BackColor = Color.LightGray;
            dgvRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

        }
        private void.reportSaveFile() {
            if (sfdReportFilSave.ShowDialog() == DialogResult.OK) { 
            trv {
                    SYSLIB0011
                        var bf = new BinaryFormatter();
                    using (FileStream fs = File.Open(
                        ofdPicFileOpen.FileName, FileMode.Open, FileAccess.Read)) {

                        listCarReports = (BindingList<CarReport>)BinaryFormatter.Deserialize(fs);
                        dgvRecord.DateSource = listCarReports;

                    }
                }
        }
        private void tsmiExit_Click_1(object sender, EventArgs e) {
            Application.Exit();
        }

        private void tsmiAbout_Click(object sender, EventArgs e) {
            fmVersion fmv = new fmVersion();
            fmv.ShowDialog();

        }

        private void irosetteiToolStripMenuItem_Click(object sender, EventArgs e) {

            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;
            }
        }

        private void �ۑ�ToolStripMenuItem_Click(object sender, EventArgs e) {

        }
        private void �J��ToolStripMenuItem_Click(object sender, EventArgs e) {

        }

      
    }
}



