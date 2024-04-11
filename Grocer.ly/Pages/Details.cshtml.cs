using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Grocer.ly.Models;

namespace Grocer.ly.Pages
{
	public class DetailsModel : PageModel
	{
		public List<GroceryItem> Foods { get; set; }
		public GroceryItem? CurrentFood { get; set; }

		public async Task<IActionResult> OnGetAsync(string name)
		{
			using (StreamWriter writer = new StreamWriter("log.txt", append: true))
			{
				await writer.WriteLineAsync($"{DateTime.Now} {name}");
			}
			Foods = Inventory.ToList();
			CurrentFood = Foods.Find(food => food.Name == name);
			return Page();
		}
	}
}
