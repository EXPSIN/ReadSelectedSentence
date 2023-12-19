using System;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace ReadSelectedSentence
{
    public partial class Form1 : Form
    {
        static string last_data = "";
        // [STAThread] // 必须添加这个属性，确保在单线程单元 (STA) 中执行
        public Form1()
        {
            InitializeComponent();
            
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // 获取剪贴板的文本内容
            bool flag = Clipboard.ContainsText();
            if (flag == true)
            {
                string data = Clipboard.GetText();
                if (last_data != data)
                {
                    last_data = data;
                    textBox1.Text = data;

                    // 创建语音合成器对象
                    using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
                    {
                        // 设置语音合成器的声音
                        // synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
                        // synthesizer.SelectVoice("Microsoft Huihui");


                        // 调用 Speak 方法进行文本到语音的转换
                        synthesizer.Speak(data);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
