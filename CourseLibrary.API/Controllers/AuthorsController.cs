using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CourseLibrary.API.Controllers
{
	[ApiController]
	[Route("api/authors")]
	public class AuthorsController : ControllerBase
	{
		private readonly ICourseLibRepo _courseLibRepo;

		public AuthorsController(ICourseLibRepo courseLibRepo)
		{
			_courseLibRepo = courseLibRepo ?? throw new ArgumentNullException(nameof(courseLibRepo));
		}

		[HttpGet]
		public IActionResult GetAuthors()
		{
			var authors = _courseLibRepo.GetAuthors();
			//return new JsonResult(authors);
			return Ok(authors);
		}

		[HttpGet("{authorId}")]
		public IActionResult GetAuthor(Guid authorId)
		{
			var author = _courseLibRepo.GetAuthor(authorId);

			if (author == null)
				return NotFound();

			return Ok(author);
		}
	}
}
