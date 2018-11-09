using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CognitiveService
{
    public partial class ComputerVisionSpace : Form
    {
        // ComboboxItem
        private class Item
        {
            public string Text;
            public int Value;
            public Item(string text, int value)
            {
                Text = text; Value = value;
            }

            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Text;
            }
        }

        // SubscriptionKey
        const string subscriptionKey = "04cf3a3ead214996926b508df13434f1";

        // uri, 注意是否為subscription key相互對應的uri
        string uriBase = "https://westcentralus.api.cognitive.microsoft.com/vision/v2.0/";

        string uri = "";

        string operaionLocation = "";

        public ComputerVisionSpace()
        {
            InitializeComponent();

            this.initFunctionList();

            this.initDomainList();

            this.initLiteralModeList();

            this.setDefaultValue();

            //TODO: remove this test data
            this.setImageLocation(@"C:\Users\Shawn.AD1\Desktop\Project\technology_sharing\vision\pic\test.jpg");
        }

        /// <summary>
        /// 初始化功能清單
        /// </summary>
        private void initFunctionList()
        {
            comboSelectedFunction.Items.Clear();
            comboSelectedFunction.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSelectedFunction.Items.Add(new Item("1:標記影像特徵", 1));
            comboSelectedFunction.Items.Add(new Item("2:將影像分類", 2));
            comboSelectedFunction.Items.Add(new Item("3:描述影像", 3));
            comboSelectedFunction.Items.Add(new Item("4:偵測臉部", 4));
            comboSelectedFunction.Items.Add(new Item("5:偵測影像類型", 5));
            comboSelectedFunction.Items.Add(new Item("6:偵測特定領域內容", 6));
            comboSelectedFunction.Items.Add(new Item("7:偵測色彩配置", 7));
            comboSelectedFunction.Items.Add(new Item("8:產生縮圖", 8));
            comboSelectedFunction.Items.Add(new Item("9:利用OCR擷取文字", 9));
            comboSelectedFunction.Items.Add(new Item("10:辨識印刷和手寫的文字(限英文)", 10));
            comboSelectedFunction.Items.Add(new Item("11:偵測成人和猥褻內容", 11));
        }

        /// <summary>
        /// 初始化可選擇領域清單
        /// </summary>
        private void initDomainList()
        {
            comboSelectedDomain.Items.Clear();
            comboSelectedDomain.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSelectedDomain.Items.Add(new Item("1:名人", 1));
            comboSelectedDomain.Items.Add(new Item("2:地標", 2));
        }

        /// <summary>
        /// 初始化文字類型清單
        /// </summary>
        private void initLiteralModeList()
        {
            comboSelectedLiteralMode.Items.Clear();
            comboSelectedLiteralMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSelectedLiteralMode.Items.Add(new Item("1:印刷", 1));
            comboSelectedLiteralMode.Items.Add(new Item("2:手寫", 2));
        }

        /// <summary>
        /// 設定預設值
        /// </summary>
        private void setDefaultValue()
        {
            comboSelectedFunction.SelectedIndex = 0;
            comboSelectedDomain.SelectedIndex = 0;
            comboSelectedLiteralMode.SelectedIndex = 0;
            txtWidth.Text = "50";
            txtHeight.Text = "50";
        }

        /// <summary>
        /// 選擇影像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImage_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.setImageLocation(openFileDialog1.FileName);
            }
        }

        /// <summary>
        /// 清除所有
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.setImageLocation();
            this.initFunctionList();
            this.initDomainList();
            txtMessage.Text = "";
        }

        /// <summary>
        /// 執行影像處理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecute_Click(object sender, EventArgs e)
        {
            this.txtMessage.Text = "";
            SelectFunction();
            HandleImage();
            addMessage("處理完成");
        }

        private void addMessage(string message = "")
        {
            this.txtMessage.Text += message;
            this.txtMessage.Text += Environment.NewLine;
        }

        /// <summary>
        /// 影像處理功能選擇
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboChosenFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item selectedItem = (Item)comboSelectedFunction.SelectedItem;

            lblSelectedDomain.Visible = false;
            comboSelectedDomain.Visible = false;
            lblWidth.Visible = false;
            txtWidth.Visible = false;
            lblWidthRange.Visible = false;
            lblHeight.Visible = false;
            txtHeight.Visible = false;
            lblHeightRange.Visible = false;
            chkSmartCropping.Visible = false;
            lblLiteralMode.Visible = false;
            comboSelectedLiteralMode.Visible = false;
            btnCheck.Visible = false;
            switch (selectedItem.Value)
            {
                case 6:
                    lblSelectedDomain.Visible = true;
                    comboSelectedDomain.Visible = true;
                    break;
                case 8:
                    lblWidth.Visible = true;
                    txtWidth.Visible = true;
                    lblWidthRange.Visible = true;
                    lblHeight.Visible = true;
                    txtHeight.Visible = true;
                    lblHeightRange.Visible = true;
                    chkSmartCropping.Visible = true;
                    break;
                case 10:
                    lblLiteralMode.Visible = true;
                    comboSelectedLiteralMode.Visible = true;
                    btnCheck.Visible = true;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 設定影像
        /// </summary>
        /// <param name="imageLocation"></param>
        private void setImageLocation(string imageLocation = "")
        {
            pictureBox1.ImageLocation = imageLocation;
            txtImageFielPath.Text = imageLocation;
        }

        /// <summary>
        /// 選擇 Cognitive Service API
        /// </summary>
        void SelectFunction()
        {
            string functionName = getFunctionName();

            string queryStringOptionalParameter = getQueryStringOptionalParameter();

            uri = uriBase + functionName;
            if (!String.IsNullOrEmpty(queryStringOptionalParameter))
            {
                uri += "?" + queryStringOptionalParameter;
            }
            addMessage(uri);
        }

        /// <summary>
        /// 取得功能名稱
        /// </summary>
        /// <returns></returns>
        private string getFunctionName()
        {
            Item selectedItem = (Item)comboSelectedFunction.SelectedItem;
            Item selectedDomain = (Item)comboSelectedDomain.SelectedItem;
            string functionName = "";
            string domainName = "";

            switch (selectedItem.Value)
            {
                case 1:
                    functionName = "tag";
                    break;
                case 2:
                case 4:
                case 5:
                case 7:
                case 11:
                    functionName = "analyze";
                    break;
                case 3:
                    functionName = "describe";
                    break;
                case 6:
                    switch (selectedDomain.Value)
                    {
                        case 1:
                            domainName = "celebrities";
                            break;
                        case 2:
                            domainName = "landmarks";
                            break;
                        default:
                            break;
                    }
                    functionName = $"models/{domainName}/analyze";
                    break;
                case 8:
                    functionName = "generateThumbnail";
                    break;
                case 9:
                    functionName = "ocr";
                    break;
                case 10:
                    functionName = "recognizeText";
                    break;
                default:
                    break;
            }
            return functionName;
        }

        /// <summary>
        /// 取得queryString參數
        /// </summary>
        /// <returns></returns>
        private string getQueryStringOptionalParameter()
        {
            Item selectedItem = (Item)comboSelectedFunction.SelectedItem;
            string queryStringOptionalParameter = "visualFeatures=Categories,Tags,Description,Faces,ImageType,Color,Adult";

            switch (selectedItem.Value)
            {
                case 2:
                    queryStringOptionalParameter = "visualFeatures=Categories";
                    break;
                case 4:
                    queryStringOptionalParameter = "visualFeatures=Faces";
                    break;
                case 5:
                    queryStringOptionalParameter = "visualFeatures=ImageType";
                    break;
                case 7:
                    queryStringOptionalParameter = "visualFeatures=Color";
                    break;
                case 8:
                    var width = txtWidth.Text;
                    var height = txtHeight.Text;
                    var smartCropping = chkSmartCropping.Checked;
                    queryStringOptionalParameter = $"width={width}&height={height}&smartCropping={smartCropping}";
                    break;
                case 9:
                    //queryStringOptionalParameter = "language=en&detectOrientation=true";
                    queryStringOptionalParameter = "";
                    break;
                case 10:
                    Item selectedMode = (Item)comboSelectedLiteralMode.SelectedItem;
                    var mode = "";
                    switch (selectedMode.Value)
                    {
                        case 1:
                            mode = "Printed";
                            break;
                        case 2:
                            mode = "Handwritten";
                            break;
                        default:
                            break;
                    }
                    queryStringOptionalParameter = $"mode={mode}";
                    break;
                case 11:
                    queryStringOptionalParameter = "visualFeatures=Adult";
                    break;
                default:
                    queryStringOptionalParameter = "";
                    break;
            }
            return queryStringOptionalParameter;
        }

        /// <summary>
        /// 處理影像
        /// </summary>
        void HandleImage()
        {
            string imageFilePath = txtImageFielPath.Text;
            if (File.Exists(imageFilePath))
            {
                addMessage("等待處理...");
                MakeAnalysisRequest(imageFilePath);
            }
            else
            {
                addMessage("無效路徑");
            }
        }

        /// <summary>
        /// 透過 Cognitive Service 的 Computer Vision 處理影像
        /// </summary>
        /// <param name="imageFilePath">The image file to analyze.</param>
        async void MakeAnalysisRequest(string imageFilePath)
        {
            try
            {
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                HttpResponseMessage response;

                byte[] byteData = GetImageAsByteArray(imageFilePath);

                using (ByteArrayContent content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                    response = await client.PostAsync(uri, content);
                }

                addMessage("Response:");
                Item selectedItem = (Item)comboSelectedFunction.SelectedItem;
                if (selectedItem.Value == 8)
                {
                    byte[] bytes = await response.Content.ReadAsByteArrayAsync();

                    using (var ms = new MemoryStream(bytes, 0, bytes.Length))
                    {
                        pictureBox1.Image = Image.FromStream(ms, true);
                    }

                    addMessage("產生縮圖");
                }
                else if (selectedItem.Value == 10)
                {
                    var statusCode = response.StatusCode;
                    if (statusCode == HttpStatusCode.Accepted)
                    {
                        string[] operationLocationArray = (string[])response.Headers.GetValues("Operation-Location");
                        operaionLocation = operationLocationArray[0];
                        addMessage(comboSelectedLiteralMode.Text + ":" + operaionLocation);
                    }
                    else
                    {
                        addMessage("未實作");
                    }
                }
                else
                {
                    string contentString = await response.Content.ReadAsStringAsync();
                    addMessage(JToken.Parse(contentString).ToString());
                }
            }
            catch (Exception e)
            {
                addMessage(e.Message);
            }
        }

        /// <summary>
        /// 將影像轉換為二進制
        /// </summary>
        /// <param name="imageFilePath">影像路徑</param>
        /// <returns>影像(二進制格式)</returns>
        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            getRecognizeTextOperationResult();
        }

        async void getRecognizeTextOperationResult()
        {
            if (String.IsNullOrEmpty(operaionLocation))
            {
                addMessage("請先執行文字處理");
                return;
            }

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            HttpResponseMessage response = await client.GetAsync(operaionLocation);

            addMessage("Response:");

            string contentString = await response.Content.ReadAsStringAsync();

            addMessage(JToken.Parse(contentString).ToString());

            if (contentString.Contains("Succeeded"))
            {
                operaionLocation = "";
            }
        }
    }
}
