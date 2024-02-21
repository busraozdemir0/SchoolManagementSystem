﻿using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Context;
using EntityLayer.DTOs.NewsLetters;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PresentationLayer.Models;
using System.Diagnostics;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReportService _reportService;
        private readonly IToastNotification _toast;

        public HomeController(ILogger<HomeController> logger, IReportService reportService, IToastNotification toast)
        {
            _logger = logger;
            _reportService = reportService;
            _toast = toast;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 6, bool isAscending = false)
        {
            var reports = await _reportService.TSearchAsync(keyword, currentPage, pageSize, isAscending);

            if (keyword.ToLower().Contains("adres") || keyword.ToLower().Contains("iletişim") || keyword.ToLower().Contains("mesaj"))
                return RedirectToAction("Index", "Contact");

            if (keyword.ToLower().Contains("hakkımızda") || keyword.ToLower().Contains("misyon") || keyword.ToLower().Contains("vizyon"))
                return RedirectToAction("Index", "Home");

            if (reports.TotalCount == 0)  // Eger aranan kelime ile hic bir haber basligi eslesmiyor ve reports 0 donuyorsa
                _toast.AddErrorToastMessage("Aradığınız kelimeye ait sonuç bulunamadı :(", new ToastrOptions { Title = "Başarısız!" });

            return View(reports);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}
