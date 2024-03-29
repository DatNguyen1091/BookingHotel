﻿using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Dtos.News;
using BusinessLogic.Entities;

namespace WebApp.Areas.Admin.Controllers
{
    public class NewsController(INewsService newsService) : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get Pagination
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllPaging(NewRequest request)
        {
            var result = await newsService.GetPagination(request);
            return Json(result);
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await newsService.GetById(id);

            return Json(result);
        }

        /// <summary>
        /// Save entity
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SaveEntity(NewsDto request)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }

            if (request.Id == 0)
            {
                var result = await newsService.Add(request);
                return Json(result);
            }
            else
            {
                var result = await newsService.Update(request);
                return Json(result);
            }
        }

        /// <summary>
        /// Delete by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            var result = await newsService.Delete(id);

            return Json(result);
        }

        /// <summary>
        /// Change Status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> ChangeStatus(int id)
        {
            var result = await newsService.ChangeStatusAsync(id);
            return Json(result);
        }

        /// <summary>
        /// Change Hot
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> ChangeHot(int id)
        {
            var result = await newsService.ChangeHotAsync(id);
            return Json(result);
        }
    }
}
