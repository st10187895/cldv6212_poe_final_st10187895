using Microsoft.AspNetCore.Mvc;
using cldv6212_poe_final_st10187895.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Http;
using System;

namespace cldv6212_poe_final_st10187895.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult AddCustomerInfo()
        {
            return View();
        }
        public IActionResult ProcessOrderInfo()
        {
            return View();
        }
        public IActionResult UploadProductInfo()
        {
            return View();
        }
        // Action for Index page
        public IActionResult Index()
        {
            var model = new CustomerProfile();
            return View(model);
        }
    }
}
        // Existing method to store customer info in Table storage and new SQL insertion
        //[HttpPost]
        //public async Task<IActionResult> StoreTableInfo(CustomerProfile profile)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // Call Azure function to store data in Azure Table
        //            using var httpClient = _httpClientFactory.CreateClient();
        //            var baseUrl = _configuration["AzureFunctions:StoreTableInfo"];
        //            var requestUri = $"{baseUrl}&tableName=CustomerProfiles&partitionKey={profile.PartitionKey}&rowKey={profile.RowKey}&firstName={profile.FirstName}&lastName={profile.LastName}&phoneNumber={profile.PhoneNumber}&Email={profile.Email}";

        //            var response = await httpClient.PostAsync(requestUri, null);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                // Insert customer data into SQL database
        //                await _customerService.InsertCustomerAsync(profile);
        //                return RedirectToAction("Index");
        //            }
        //            else
        //            {
        //                _logger.LogError($"Error submitting client info: {response.ReasonPhrase}");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger.LogError($"Exception occurred while submitting client info: {ex.Message}");
        //        }
        //    }

        //    return RedirectToAction("Index");
        //}

        // Existing method to upload blob and new SQL insertion for blob data
        //[HttpPost]
        //public async Task<IActionResult> UploadImage(IFormFile imageFile)
        //{
        //    if (imageFile != null)
        //    {
        //        try
        //        {
        //            // Call Azure function to upload the blob
        //            using var httpClient = _httpClientFactory.CreateClient();
        //            using var stream = imageFile.OpenReadStream();
        //            var content = new StreamContent(stream);
        //            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(imageFile.ContentType);

        //            var baseUrl = _configuration["AzureFunctions:UploadBlob"];
        //            string url = $"{baseUrl}&blobName={imageFile.FileName}";
        //            var response = await httpClient.PostAsync(url, content);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                // Convert image to byte array for SQL insertion
        //                using (var memoryStream = new MemoryStream())
        //                {
        //                    await imageFile.CopyToAsync(memoryStream);
        //                    var imageData = memoryStream.ToArray();

        //                    // Insert image data into SQL BlobTable
        //                    await _blobService.InsertBlobAsync(imageData);
        //                }

        //                return RedirectToAction("Index");
        //            }
        //            else
        //            {
        //                _logger.LogError($"Error submitting image: {response.ReasonPhrase}");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger.LogError($"Exception occurred while submitting image: {ex.Message}");
        //        }
        //    }
        //    else
        //    {
        //        _logger.LogError("No image file provided.");
        //    }

        //    return View("Index");
        //}
    
//}







//____________________________________________________THIS IS PART 2 BELOW________________________________________________________________________________+
/*using Microsoft.AspNetCore.Mvc;
using SemesterTwo.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;*/
/*namespace SemesterTwo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var model = new CustomerProfile();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> StoreTableInfo(CustomerProfile profile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using var httpClient = _httpClientFactory.CreateClient();

                    var baseUrl = _configuration["AzureFunctions:StoreTableInfo"];
                    var requestUri = $"{baseUrl}&tableName=CustomerProfiles&partitionKey={profile.PartitionKey}&rowKey={profile.RowKey}&firstName={profile.FirstName}&lastName={profile.LastName}&phoneNumber={profile.PhoneNumber}&Email={profile.Email}";

                    var response = await httpClient.PostAsync(requestUri, null);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _logger.LogError($"Error submitting client info: {response.ReasonPhrase}");
                        _logger.LogError($"Response content: {await response.Content.ReadAsStringAsync()}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Exception occurred while submitting client info: {ex.Message}");
                }
            }

            return View("Index", profile);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile contractFile)
        {
            if (contractFile != null)
            {
                try
                {
                    using var httpClient = _httpClientFactory.CreateClient();
                    using var stream = contractFile.OpenReadStream();
                    var content = new StreamContent(stream);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contractFile.ContentType);

                    var baseUrl = _configuration["AzureFunctions:UploadFile"];
                    string url = $"{baseUrl}&fileName={contractFile.FileName}";
                    var response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _logger.LogError($"Error submitting document: {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Exception occurred while submitting document: {ex.Message}");
                }
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UploadBlob(IFormFile imageFile)
        {
            if (imageFile != null)
            {
                try
                {
                    using var httpClient = _httpClientFactory.CreateClient();
                    using var stream = imageFile.OpenReadStream();
                    var content = new StreamContent(stream);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(imageFile.ContentType);

                    var baseUrl = _configuration["AzureFunctions:UploadBlob"];
                    string url = $"{baseUrl}&blobName={imageFile.FileName}";
                    var response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _logger.LogError($"Error submitting image: {response.ReasonPhrase}");
                        _logger.LogError($"Response content: {await response.Content.ReadAsStringAsync()}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Exception occurred while submitting image: {ex.Message}");
                }
            }
            else
            {
                _logger.LogError("No image file provided.");
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ProcessQueueMessage(string orderId)
        {
            if (!string.IsNullOrWhiteSpace(orderId))
            {
                try
                {
                    using var httpClient = _httpClientFactory.CreateClient();

                    var baseUrl = _configuration["AzureFunctions:ProcessQueueMessage"];
                    string url = $"{baseUrl}&message={orderId}";

                    var response = await httpClient.PostAsync(url, null);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _logger.LogError($"Error processing order: {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Exception occurred while processing order: {ex.Message}");
                }
            }
            else
            {
                _logger.LogError("No order ID provided.");
            }

            return RedirectToAction("Index");
        }
    }
}*/
