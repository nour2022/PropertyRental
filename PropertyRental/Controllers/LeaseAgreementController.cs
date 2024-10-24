using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyRental.Application.DTOs;
using PropertyRental.Application.Services;

namespace PropertyRental.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class LeaseAgreementController : Controller
    {
        private LeaseAgreementAppService _leaseService;
        public LeaseAgreementController(LeaseAgreementAppService leaseService) {
        _leaseService = leaseService;
        }
        // GET: LeaseAgreementController
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            var result =_leaseService.GetById(id);
            return Ok(result);
        }



        // GET: LeaseAgreementController/Create
        [Authorize(Roles = "Owner")]
        [HttpPost]
        public ActionResult Create([FromBody]LeaseAgreementDTO leaseAgreementDTO)
        {
            _leaseService.Insert(leaseAgreementDTO);
            return Ok();
        }



        // GET: LeaseAgreementController/Edit/5
        [Authorize(Roles = "Owner")]
        [HttpPut("{id}")]
        public ActionResult Edit(int id, [FromBody] LeaseAgreementDTO leaseAgreementDTO)
        {
            _leaseService.Update(leaseAgreementDTO,id);
            return Ok();
        }



        // GET: LeaseAgreementController/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _leaseService.Delete(id);
            return Ok();
        }

    }
}
