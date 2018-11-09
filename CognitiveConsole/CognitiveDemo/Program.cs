using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CognitiveService
{
    class ComputerVision
    {
        // test image path
        // C:\Users\Shawn.AD1\Desktop\Project\technology_sharing\vision\test.jpg

        // SubscriptionKey
        const string subscriptionKey = "3c1223db5f86492fa764c68d726c1e13";

        // uri, 注意是否為subscription key相互對應的uri
        static string uriBase = "https://westcentralus.api.cognitive.microsoft.com/vision/v2.0/";

        static string queryStringOptionalParameter = "visualFeatures=Categories,Tags,Description,Faces,ImageType,Color,Adult";

        static void Main()
        {
            SelectFunction();

            HandleImage();

            Console.WriteLine("\n按 Enter 結束程式...");
            Console.ReadLine();
        }

        /// <summary>
        /// 選擇 Cognitive Service API
        /// </summary>
        static void SelectFunction()
        {
            int functionCode;
            string functionString = "";
            bool isLegal = true;

            Console.WriteLine("請選擇要使用的功能(輸入代號):");
            Console.WriteLine("1:標記影像特徵 2:將影像分類 3:描述影像 4:偵測臉部 5:偵測影像類型 6:偵測特定領域內容");
            Console.WriteLine("7:偵測色彩配置 8:產生縮圖 9 10 11:偵測成人和猥褻內容");
            isLegal = int.TryParse(Console.ReadLine(), out functionCode);

            if (!isLegal) { return; }

            switch (functionCode)
            {
                case 1:
                    functionString = "tag";
                    break;
                case 2:
                case 4:
                case 5:
                case 7:
                case 11:
                    functionString = "analyze";
                    break;
                case 3:
                    functionString = "describe";
                    break;
                case 6:
                    int modelCode;
                    string model = "";

                    Console.WriteLine("要找的特定內容是什麼:");
                    Console.WriteLine("1:名人 2:地標");

                    int.TryParse(Console.ReadLine(), out modelCode);
                    switch (modelCode)
                    {
                        case 1:
                            model = "celebrities";
                            break;
                        case 2:
                            model = "landmarks";
                            break;
                        default:
                            isLegal = false;
                            break;
                    }
                    functionString = $"models/{model}/analyze";
                    break;
                case 8:
                    functionString = "generateThumbnail";
                    var width = 50;
                    var height = 50;
                    var smartCropping = true;
                    queryStringOptionalParameter = $"width={width}&height={height}&smartCropping={smartCropping}";
                    break;
                default:
                    isLegal = false;
                    break;
            }

            if (!isLegal) { return; }

            uriBase += functionString + "?" + queryStringOptionalParameter;

            Console.WriteLine(uriBase);
        }

        /// <summary>
        /// 處理影像
        /// </summary>
        static void HandleImage()
        {
            // Get the path and filename to process from the user.
            Console.WriteLine("請輸入要處理的圖片路徑: ");
            string imageFilePath = Console.ReadLine();
            if (File.Exists(imageFilePath))
            {
                // 透過 Microsoft Cognitive Service 處理
                Console.WriteLine("等待處理");
                MakeAnalysisRequest(imageFilePath).Wait();
            }
            else
            {
                Console.WriteLine("無效路徑");
            }
        }

        /// <summary>
        /// 透過 Cognitive Service 的 Computer Vision 處理影像
        /// </summary>
        /// <param name="imageFilePath">The image file to analyze.</param>
        static async Task MakeAnalysisRequest(string imageFilePath)
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

                    response = await client.PostAsync(uriBase, content);
                }

                // 取得response(JSON格式)
                string contentString = await response.Content.ReadAsStringAsync();

                Console.WriteLine("Response:\n{0}\n", JToken.Parse(contentString).ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
    }
}