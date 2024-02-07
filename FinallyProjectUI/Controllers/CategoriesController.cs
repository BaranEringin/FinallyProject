using FinallyProjectDATA.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace FinallyProjectUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private HttpClient httpClient;

        public CategoriesController()
        {
            httpClient = new HttpClient();
        }


        

        public async Task<IActionResult> Index()
        {
            var responseMessage = await httpClient.GetAsync("http://localhost:5050/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Category>>(jsonString);
                return View(values);
            }
            return NotFound("Kategori Listesi alınamadı");
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            var responseMessage = await httpClient.GetAsync("http://localhost:5050/api/Categories/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Category>(jsonString);
                return View(value);
            }
            return NotFound("Categori bulunamadı");
        }

        
        [Authorize(Roles = "Admin,Create")]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Category category)
        {
            var jsonCategory = JsonConvert.SerializeObject(category);
            var stringContent = new StringContent(jsonCategory, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("http://localhost:5050/api/Categories", stringContent);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View(category);
        }

        
        [Authorize(Roles = "Admin,Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            var responseMessage = await httpClient.GetAsync("http://localhost:5050/api/Categories/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Category>(jsonString);
                return View(value);
            }
            return NotFound("Categori bulunamadı");
        }

         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Category category)
        {
            var jsonCategory = JsonConvert.SerializeObject(category);
            var stringContent = new StringContent(jsonCategory, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("http://localhost:5050/api/Categories", stringContent);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View(category);
        }

        
        [Authorize(Roles = "Admin,Delete")]
        public async Task<IActionResult> Delete(int? id)
        {

            var responseMessage = await httpClient.GetAsync("http://localhost:5050/api/Categories/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Category>(jsonString);
                return View(value);
            }
            return NotFound("Categori bulunamadı");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var responseMessage = await httpClient.DeleteAsync("http://localhost:5050/api/Categories?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return NotFound("Categori bulunamadı");
        }
    }
}
