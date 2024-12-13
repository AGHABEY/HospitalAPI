using HospitalAPI.Entities;
using HospitalAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controller;

[ApiController]
[Route("api/template")]
public class PatientController:ControllerBase
{
   private readonly IPatientRepository _patientRepository;

   public PatientController(IPatientRepository patientRepository)
   {
      _patientRepository = patientRepository;
   }
   [HttpGet]
   public async Task<IActionResult> GetAll()
   {
      var patients = await _patientRepository.GetAllAsync();
      return Ok(patients);
   }
  [HttpGet("{id}")]
   public async Task<IActionResult> GetById(int id)
   {
      var patient = await _patientRepository.GetByIdAsync(id);
      if (patient == null)
         return NotFound();
      return Ok(patient);
   }
   [HttpGet("search")]
   public async Task<IActionResult> GetByName([FromQuery] string name)
   {
      var patient = await _patientRepository.GetPatientsByName(name);
      return Ok(patient);
   }
   [HttpPost]
   public async Task<IActionResult> Add(Patient patient)
   {
      await _patientRepository.AddAsync(patient);
      return CreatedAtAction(nameof(GetById), new { id = patient.Id }, patient);
   }
   [HttpPut("{id}")]
   public async Task<IActionResult> Update(int id, Patient patient)
   {
      if (id != patient.Id)
         return BadRequest();
      await _patientRepository.UpdateAsync(patient);
      return NoContent();
   }

   public async Task<IActionResult> Delete(int id)
   {
      await _patientRepository.DeleteAsync(id);
      return NoContent();
   }
}