using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Context;
using EntityLayer.DTOs.NewsLetters;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System.Diagnostics;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAddressService _addressService;
       
        public HomeController(ILogger<HomeController> logger, IAddressService addressService)
        {
            _logger = logger;
            _addressService = addressService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var address= await _addressService.GetListAsync();
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}
