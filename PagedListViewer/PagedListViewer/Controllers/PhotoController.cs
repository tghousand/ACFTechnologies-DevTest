/*Controller used to get data from API, create models, and create a paged list to send to the view.
 * In order to parse the JSON data from the API, the package Newtonsoft.Json was used.
 * To create the paged list, the package X.PagedList.Mvc.Core was used.
 */
using Microsoft.AspNetCore.Mvc;
using PagedListViewer.Models;
using Newtonsoft.Json;
using X.PagedList;

namespace PagedListViewer.Controllers
{
	public class PhotoController : Controller
	{
		public async Task<IActionResult> Index(int? page, int? pageElements)
		{
			//Variables that will control the number of elements on a page and the current page the paged list is on.
			int pageSize;
			int pageIndex;

			//Validates that incoming values are integers above 0. If this condition is not met or if there was no incoming value, the current page defaults to 1 and the number of elements defaults to 10.
			if (page.HasValue)
			{
				if (page.Value > 0) { pageIndex = page.Value; } else pageIndex = 1;
			} else pageIndex = 1;
			if (pageElements.HasValue)
			{
				if (pageElements.Value > 0) { pageSize = pageElements.Value; } else pageSize = 10;
			} else pageSize = 10;

			//This is used to save the current number of elements on a page so that it can be passed to the view to be used.
			ViewBag.pageSize = pageSize;

			IPagedList<Photo> photosPList;
			List<Photo> photosList = new List<Photo>();

			//This retrieves and parses the data from the API link. It then converts the data into a list of Photo objects. The list is then converted to a paged list.
			using(var httpClient = new HttpClient())
			{
				using (var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/photos"))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					photosList = JsonConvert.DeserializeObject<List<Photo>>(apiResponse);
					photosPList = photosList.ToPagedList<Photo>(pageIndex, pageSize);
				}
			} 
			return View(photosPList);
		}
	}
}
