using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using NAudio.Wave;
using System.Reflection.Emit;
using NAudio.Utils;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace housework
{
    public partial class music : Form
    {
        public music()
        {
            InitializeComponent();
        }

        AudioFileReader audioFile;
        WaveOutEvent audioSound;
        Boolean loopSetting = false, continueSetting=false;
        string[] files;
        long positionStop = 0; // เก็บค่าตำแหน่งที่จุดกดหยุดเสียง

        //ปรับระดับเสียง
        void pitch()
        {
            float pitchValue = trackBar.Value / 100f;
            audioSound.Volume = pitchValue;
        }

        //ปิดเพลง
        void turnoffTheMusic()
        {
            if (audioFile != null && audioSound != null)
            {
                audioSound.Dispose();
                audioFile.Dispose();
                audioFile = null;
                audioSound = null;
                btnRUNAndSTOP.ImageLocation = Application.StartupPath + "\\OIP.jpg";
            }
        }

        //การตั้งค่าเกี่ยวกับปุ่มเล่นเพลงเดิมซ้ำ
        void loogSetting(Boolean dataBoolean)
        {
            loopSetting = dataBoolean;
            if (dataBoolean)
                btnLoop.BackColor = Color.Pink;
            else
                btnLoop.BackColor = Color.White;
        }

        //การตั้งค่าเกี่ยวกับปุ่มเล่นเพลงถัดไปอัตโนมัติ
        void contSetting(Boolean dataBoolean)
        {
            continueSetting = dataBoolean;
            if (dataBoolean)
                btnContinue.BackColor = Color.Pink;
            else
                btnContinue.BackColor = Color.White;
        }

        //เมธอดการเล่นเพลงเดิมซ้ำ และการเล่นเพลงถัดไปโดยอัตโนมัติ
        async Task loopSound()
        {
            if (loopSetting)
            {
                if (timeStart.Text == timeEnd.Text)
                {
                    openSound();
                }
            }
            else if (continueSetting)
            {
                if (timeStart.Text == timeEnd.Text)
                {
                    if ((playlist.SelectedIndex + 1) < files.Length)
                    {
                        playlist.SelectedIndex = playlist.SelectedIndex + 1; //เล่นเพลงถัดไปในเพลย์ลิสต์
                    }
                    else //เพลงปัจจุบันเป็นเพลงสุดท้ายในเพลย์ลิสต์แล้ว
                    {
                        playlist.SelectedIndex = 0; //ให้วนกลับไปเริ่มเล่นเพลงแรกในเพลย์ลิสต์
                        //หมายเหตุ : playlist.SelectedIndex เปลี่ยนก็เท่ากับการเลือกเปลี่ยนเพลงแล้ว
                    }
                    //อากิวเมนต์ที่หนึ่งเป็น 0 คือการระบุอากิวเมนต์ให้เพลงเริ่มเล่นตั้งแต่วินาทีที่ 0
                }
            }
        }

        //แสดงเวลากำกับ ณ เวลาที่เพลงได้เล่นไปแล้วของไฟล์ปัจจุบัน และแสดง ProgreeBar ของการเล่นเพลง ณ ไฟล์ปัจจุบัน
        void ShowTimeAndProgreeBar()
        {
            if (audioFile != null)
            {
                //การแสดง ProgressBar
                int progressPercentage = (int)((double)audioFile.Position / audioFile.Length * progressBar.Maximum); //ทำให้เป็นอัตราส่วนของ progressBar 
                if (progressPercentage == 99) //เพลงจบแต่ ProgreeBar ไม่เต็ม
                    progressBar.Value = progressPercentage+1;
                else progressBar.Value = progressPercentage;

                //การแสดงเวลาที่ label ชื่อ timeStart
                showTimeCurrent();
            }
        }

        //แสดงเวลาที่ label ชื่อ timeStart
        void showTimeStart(int positionTimeMinutes,int positionTimeSeconds)
        {
            timeStart.Text = positionTimeMinutes + " : " + strSeconds(positionTimeSeconds);
        }

        //แปลงตำแหน่งในเสียงให้เป็นเวลาแบบนาทีและวินาที
        async Task showTimeCurrent()
        {
            int positionTimeMinutes, positionTimeSeconds , forTotalTime ,forBeforeSeconds, forTotalTimeMinutes;
            double forTime = audioFile.TotalTime.TotalMilliseconds;

            //แสดงกำกับว่าเสียงได้เล่นไปนานเท่าไหร่แล้ว
            long positionBytes = audioFile.Position;
            TimeSpan positionTime = TimeSpan.FromSeconds((double)positionBytes / audioFile.WaveFormat.AverageBytesPerSecond);
            //นาที และวินาทีของเพลง ณ ปัจจุบัน
            positionTimeMinutes = positionTime.Minutes;
            positionTimeSeconds = positionTime.Seconds;

            showTimeStart(positionTimeMinutes, positionTimeSeconds); //แสดงเวลา ณ ปัจจุบัน

            //เวลา ณ ตอนจบที่จะเอามาเทียบ
            //ทำเอาไว้กันแก้ปัญหาที่บางครั้งเพลงจบแล้ว แต่เวลาขาดไปอีก 1 วินาทีจึงจะจบลง
            forTotalTime = ((int)forTime) / 1000; //แปลงจากมิลลิวินาทีเป็นวินาที
            forBeforeSeconds = (forTotalTime % 60) -1; //ก่อนจบหนึ่งวินาที อาทิ ระยะเวลาเพลง คือ 4 : 10 , forBeforeSeconds = 9 วินาที
            forTotalTimeMinutes = forTotalTime / 60;

            //กรณีเลขนาทีเดียวกัน
            if (positionTimeMinutes== forTotalTimeMinutes && positionTimeSeconds== forBeforeSeconds)
            {
                //หน่วงเวลาหนึ่งวินาที เพราะเราเช็กในกรณีที่ถ้าถึงเวลาที่ก่อนเพลงจบหนึ่งวินาที ดังนั้นรออีกหนึ่งวินาทีจึงเป็นเวลาที่เพลงจบพอดี
                //แก้ปัญหาเพลงจบแล้ว แต่วินาทีของเพลงที่เล่นยังไม่จบ (จากที่ควรเป็น 3:55 ขึ้น 3:54)
                await Task.Delay(1000); //หน่วงเวลา 1 วินาที
                showTimeStart(positionTimeMinutes, positionTimeSeconds+1);
            }else if (positionTimeMinutes+1==forTotalTimeMinutes&& positionTimeSeconds==59) //กรณีคนละเลขนาที
            {
                await Task.Delay(1000); //หน่วงเวลา 1 วินาที
                showTimeStart(positionTimeMinutes+1, 0);
            }
        }

        //แปลงตำแหน่งในเสียงให้เป็นเวลาแบบนาทีและวินาที
        string strTime(double forTime)
        {
            int forTotalTime = ((int)forTime) / 1000;
            int dataSeconds = forTotalTime % 60;
            return forTotalTime / 60 + " : " + strSeconds(dataSeconds);
        }

        //เช็กเลขวินาที ต้องการแบบ 0:01 ไม่ใช่ 0:1 
        string strSeconds(int dataSeconds)
        {
            return dataSeconds < 10 ? "0" + dataSeconds : dataSeconds.ToString();
        }
        //files[playlist.SelectedIndex]
        //เล่นเพลง
        async Task openSound(long positionClick = 0) //ถ้าเป็นเล่นเพลงตั้งแต่ต้น(เริ่มเพลงวินาทีที่ 0) เมธอด openSound ไม่ต้องระบุอากิวเมนต์ได้
        {
            string forTimeEndValue="";

            turnoffTheMusic(); //หยุดเพลงก่อนหน้านี้
            await Task.Delay(200); //หน่วงเวลา 200 มิลลิวินาที
            audioFile = new AudioFileReader(files[playlist.SelectedIndex]);
            audioSound = new WaveOutEvent();
            audioSound.Init(audioFile);
            pitch(); //ปรับระดับเสียง
            audioSound.Play();

            //โซนตั้งค่า
            // คำนวณหาตำแหน่งสำหรับไฟล์เสียง
            long positionSound = (long)((double)positionClick / progressBar.Maximum * audioFile.Length);
            audioFile.Position = positionSound;

            btnRUNAndSTOP.ImageLocation = Application.StartupPath + "/run.png";
            ShowTimeAndProgreeBar(); //แสดงเวลาที่เพลงเล่นไปแล้ว ณ ปัจจุบันกำกับ และแสดง ProgressBar การเล่นของเพลง
            forTimeEndValue = strTime(audioFile.TotalTime.TotalMilliseconds); //เก็บค่าเวลาที่เพลงจบ(ความยาวเพลง)
            timeEnd.Text = forTimeEndValue;

            audioSound.PlaybackStopped += (s, args) =>
            {
                turnoffTheMusic();
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //รูปเคลื่อนไหวพื้นหลัง
            string path = Application.StartupPath + "\\imgbg.gif";
            bg.Image = Image.FromFile(path);

            btnOpenFiles.Width = 902;
            listClear.Hide();
            playlist.Hide();

            trackBar.Height = 511;
            btnLoop.Hide();
            btnContinue.Hide();

            btnRUNAndSTOP.Hide();
            progressBar.Hide();
            timeStart.Hide();
            timeEnd.Hide();
        }

        //กดเลือกเสียงที่ต้องการฟังในบรรดารายการที่เลือกเข้ามา (บรรดารายการจาก listData)
        private void listData_SelectedIndexChanged(object sender, EventArgs e)
        {
            openSound();

            btnRUNAndSTOP.Show();
            progressBar.Show();
            timeStart.Show();
            timeEnd.Show();

        }

        //เปิดไฟล์เพื่อนำเข้าเสียง
        private void OpenFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Video Files|*.mp4;*.avi;*.mkv;*.wmv|Audio Files|*.mp3;*.wav;*.flac";
            openFile.Title = "เลือกรายการเพลงที่ต้องการ";
            openFile.Multiselect = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                playlist.Items.Clear();
                files = openFile.FileNames;

                //แสดงรายละเอียดรายการที่เลือกขึ้นบน listData
                for (int count = 0; count < files.Length; count++)
                {
                    playlist.Items.Add(files[count]);
                }

                playlist.Show();
                btnOpenFiles.Width = 597;
                listClear.Show();

                trackBar.Height = 422;
                btnLoop.Show();
                btnContinue.Show();
            }
        }

        //trackbar สำหรับปรับระดับเสียง
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            if (audioFile !=null && audioSound != null)
                pitch();
        }

        //ปุ่มหยุดเพลงและเล่นเพลงต่อ
        private void btnRUNAndStop_Click(object sender, EventArgs e)
        {
            string PathRUN, PathStop;
            PathRUN = Application.StartupPath + "/run.png";
            PathStop = Application.StartupPath + "\\OIP.jpg";

            if (audioSound != null && audioFile!=null) {
                if(btnRUNAndSTOP.ImageLocation == PathRUN)
                {
                    positionStop = audioFile.Position; //บันทึกตำแหน่งที่หยุดเอาไว้
                    audioSound.Pause();
                    //btnRUNAndSTOP.ImageLocation = PathStop;
                }
                else
                {
                    audioFile.Position = positionStop; //เล่นต่อจากที่หยุดเอาไว้
                    audioSound.Play();
                    //btnRUNAndSTOP.ImageLocation = PathRUN;
                }
            }

            //ต่อให้มีเพลงรันอยู่หรือไม่มี ก็อยากให้มีการตอบสนองไอคอนของปุ่ม
            btnRUNAndSTOP.ImageLocation = (btnRUNAndSTOP.ImageLocation == PathRUN) ? PathStop : PathRUN;

        }

        private void progressBar_Click(object sender, EventArgs e) //การคำนวณนี้ การแปลงเป็นทศนิยมสำคัญมาก
        {
            MouseEventArgs mouseEvent = e as MouseEventArgs;

            if (mouseEvent != null && mouseEvent.Button == MouseButtons.Left)
            {
                //เล่นเพลงในตำแหน่งที่คลิก pressBar
                // ดึงข้อมูลตำแหน่งที่คลิกบน progressBar
                int positionClick = (int)((double)mouseEvent.X / progressBar.Width * progressBar.Maximum);

                //ส่งข้อมูลตำแหน่งที่คลิกไปในเมธอดเพื่อเล่นเพลง
                openSound(positionClick);
            }
        }

        private void listClear_Click(object sender, EventArgs e)
        {
            playlist.Hide();
            playlist.Items.Clear();

            listClear.Hide();
            btnOpenFiles.Width = 902;
        }

        //รันเพลงซ้ำเมื่อเพลงจบลง
        private void loop_Click(object sender, EventArgs e)
        {
            if (loopSetting)
                loogSetting(false); //เลือกไม่รันเพลงเดิมซ้ำ
            else
            {
                contSetting(false); //เลือกอยากรันเพลงเดิมซ้ำเรื่อย ๆ ดังนั้นการตั้งค่าให้เล่นเพลงถัดไปโดยอัตโนมัติจึงต้องปิด
                loogSetting(true);
            }
        }

        //รันเพลงถัดไปเมื่อเพลงเดิมจบลง
        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (continueSetting)
                contSetting(false); //เลือกไม่รันเพลงต่อไปโดยอัตโนมัติ
            else
            {
                loogSetting(false); //เพราะถ้ามันเป็นซ้ำเพลงเดิม มันก็จะไม่รันเพลงถัดไป
                contSetting(true);
            }
        }

        private void timer1_Tick(object sender, EventArgs e) //การคำนวณนี้ การแปลงเป็นทศนิยมสำคัญมาก
        {
            ShowTimeAndProgreeBar();

            loopSound(); //เมธอดการเล่นเพลงเดิมซ้ำ และการเล่นเพลงถัดไปโดยอัตโนมัติ
        }

    }
}
