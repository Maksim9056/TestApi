using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [AllureNUnit]
        public class MyTestClass
        {
            private const string BASE_URL = "https://api.sampleapis.com";
            private const string TEST_USER_EMAIL = "some@gmail.com";
            private const string TEST_USER_PASSWORD = "some";

            [AllureSubSuite("��� Subsuite")]
            [AllureSeverity(SeverityLevel.Critical)]
            [AllureLink("https://example.com/issue=1234")]
            [Test]
            public async Task MyTestMethod()
            {
                try
                {
                    string apiUrl = BASE_URL;
                    string email = TEST_USER_EMAIL;
                    string password = TEST_USER_PASSWORD;

                    using (HttpClient client = new HttpClient())
                    {
                        // ��������� ��������� �����������
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GetAuthToken(email, password));

                        // ���������� GET-������ �� apiUrl
                        HttpResponseMessage response = await client.GetAsync(apiUrl);

                        // ������ ���������� ������
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseBody);

                     
                        Assert.IsTrue(responseBody.Contains("expected_data"), "������ ������ ������������ ������");

                        if(!response.IsSuccessStatusCode)
                        {

                        }
                        else
                        {
                            var d = response.EnsureSuccessStatusCode(); // ���������, ��� ������ �������
                        }

                    
                        // ���������, ��� ����� �������� ��������� ������
                    }

                }catch (Exception)
                {
                }
            }

            // ����� ��� ��������� ������ ����������� (������)
            private string GetAuthToken(string email, string password)
            {
                // ��� ��� ��� ��������� ������ �����������
                return "sample_token";
            }
        }
        public class MyModel
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        static string json = JsonConvert.SerializeObject(new MyModel { Name = "John", Age = 30 });
        // �����: {"Name":"John","Age":30}

        MyModel obj = JsonConvert.DeserializeObject<MyModel>(json);



    }
}