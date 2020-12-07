using AutoMapper;
using BookStoreAPI.DTOS;
using BookStoreAPI.Mdels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IMapper _mapper;

        public PublisherController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [Route("addpublisher")]
        public IActionResult AddPublisher(PublisherDTO publisher)
        {

            Publisher newPublisher = _mapper.Map<Publisher>(publisher);
            using (var _context = new BookStoreDbContext())
            {

                _context.Publishers.Add(newPublisher);

                _context.SaveChanges();
            }

            return Ok();
        }

        [HttpGet]
        public IEnumerable<Publisher> Get()
        {
            using (var _context = new BookStoreDbContext())
            {
                return _context.Publishers.ToList();
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult<Publisher> UpdatePusblisher(string oldName, string newName)
        {
            using (var _context = new BookStoreDbContext())
            {
                try
                {
                    Publisher pub = _context.Publishers.FirstOrDefault(p => p.PublisherName == oldName);
                    pub.PublisherName = newName;

                    _context.SaveChanges();

                    return Ok();
                }
                catch (NullReferenceException)
                {
                    return NotFound();
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }
            }
        }
    }
}