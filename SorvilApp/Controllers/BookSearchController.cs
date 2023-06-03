using Microsoft.AspNetCore.Mvc;
using SorvilApp.Models;
using SorvilApp.Shared;

namespace SorvilApp.Controllers
{
	public class BookSearchController : Controller
	{
		private readonly GoogleBookAPIHelper _googleBookAPIHelper;
		public BookSearchController(GoogleBookAPIHelper googleBookAPIHelper)
		{
			_googleBookAPIHelper = googleBookAPIHelper;
		}

		public IActionResult Index()
		{
			var viewModel = new SearchViewModel();
			return View(viewModel);
		}

		[HttpGet]
		public IActionResult Result(string searchTerm, string genre, int? year, bool? hasISBN)
		{
			var viewModel = new ResultViewModel
			{
				SearchTerm = searchTerm,
				Genre = genre,
				Year = year,
				HasISBN = hasISBN
			};

			try
			{
				var books = _googleBookAPIHelper.SearchBooks(searchTerm, genre, year, hasISBN);

				if (books != null)
				{
					viewModel.Books = books.Select(book => new BookViewModel
					{
						ImageUrl = book.VolumeInfo.ImageLinks.Thumbnail,
						Title = book.VolumeInfo.Title,
						Author = string.Join(", ", book.VolumeInfo.Authors),
						PublishedYear = book.VolumeInfo.PublishedDate,
						Id = book.Id,
						Description = book.VolumeInfo.Description

					}).ToList();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Ocorreu um erro ao realizar a busca dos livros: " + ex.Message);
			}

			return View(viewModel);
		}
		public IActionResult Details(BookViewModel book)
		{
			var viewModel = new DetailsViewModel
			{
				BookId = book.Id,
				Author = book.Author,
				Title = book.Title,
				PublishedYear = book.PublishedYear,
				Description = book.Description,
				ImageUrl = book.ImageUrl
			};

			return View(viewModel);
		}

		public IActionResult Perfil(Perfil info, string nomeLivro)
		{
			var viewModel = new Perfil
			{
				Nome = info.Nome,
				Texto = info.Texto,
				Imagem = info.Imagem,
				Lendo = info.Lendo,
				Lido = info.Lido,
				Lerei = info.Lerei,
				Desisti = nomeLivro
			};

			return View(viewModel);
		}

		public IActionResult Editar()
		{
			//var viewModel = new Editar
			//{
			//	Nome = edit.Nome,
			//	Texto = edit.Texto,
			//	Lendo = edit.Lendo,
			//	Lido = edit.Lido,
			//	Lerei = edit.Lerei,
			//	Desisti = edit.Desisti
			//};

			return View();
		}


	}
}
