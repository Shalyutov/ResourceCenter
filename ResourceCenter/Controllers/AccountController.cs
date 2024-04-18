using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceCenter.Data;
using ResourceCenter.Models;
using System.Security.Principal;

namespace ResourceCenter.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController(ApplicationContext context) : ControllerBase
    {
        readonly EntityRepository<Account> accountRepository = new(context);
        readonly EntityRepository<Resident> residentRepository = new(context);

        [HttpPost]
        public IActionResult Create([FromBody] Account account)
        {
            if (account.Opened >= account.Closed)
            {
                return BadRequest("Дата начала действия лицевого счёта должна быть раньше его даты окончания действия");
            }
            if (account.Area <= 0)
            {
                return BadRequest("Площадь помещения должна быть больше 0");
            }
            try
            {
                accountRepository.Create(account);
                return Accepted();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException!.Message.Contains("UNIQUE constraint failed: Accounts.Number"))
                {
                    return BadRequest("Номер лицевого счёта должен быть уникальным");
                }
                return BadRequest($"Неопознанная ошибка: {ex.Message}");
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] Account account)
        {
            try
            {
                accountRepository.Remove(account);
                return Accepted();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException!.Message.Contains("UNIQUE constraint failed: Accounts.Number"))
                {
                    return BadRequest("Номер лицевого счёта должен быть уникальным");
                }
                return BadRequest($"Неопознанная ошибка: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            Account? account = accountRepository.FindById(id);
            if (account == null)
            {
                return BadRequest("Лицевой счёт с данным идентификатором не найден");
            }
            try
            {
                accountRepository.Remove(account);
                return Accepted();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException!.Message.Contains("UNIQUE constraint failed: Accounts.Number"))
                {
                    return BadRequest("Номер лицевого счёта должен быть уникальным");
                }
                return BadRequest($"Неопознанная ошибка: {ex.Message}");
            }
        }
        [HttpPut]
        public IActionResult Update([FromBody] Account account)
        {
            if (account.Opened >= account.Closed)
            {
                return BadRequest("Дата начала действия лицевого счёта должна быть раньше его даты окончания действия");
            }
            if (account.Area <= 0)
            {
                return BadRequest("Площадь помещения должна быть больше 0");
            }
            try
            {
                accountRepository.Update(account);
                return Accepted();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException!.Message.Contains("UNIQUE constraint failed: Accounts.Number"))
                {
                    return BadRequest("Номер лицевого счёта должен быть уникальным");
                }
                return BadRequest($"Неопознанная ошибка: {ex.Message}");
            }
        }
        [HttpGet]
        public IActionResult Get([FromQuery] string? fullName = null, [FromQuery] DateTime? opened = null, [FromQuery] string? address = null, [FromQuery] bool? hasResidents = null)
        {
            Func<Account, bool> predicate = (Account account) =>
            {
                bool nameFilter = true;
                if (!string.IsNullOrEmpty(fullName))
                {
                    nameFilter = account.Residents.Where(resident => resident.FullName.Contains(fullName)).Any();
                }

                bool openedFilter = true;
                if (opened != null)
                {
                    openedFilter = account.Opened == opened;
                }

                bool addressFilter = true;
                if (!string.IsNullOrEmpty(address))
                {
                    addressFilter = account.Address.Contains(address);
                }

                bool hasResidentsFilter = true;
                if (hasResidents != null)
                {
                    if ((bool)hasResidents)
                    {
                        hasResidentsFilter = account.Residents.Any();
                    }
                    else
                    {
                        hasResidentsFilter = !account.Residents.Any();
                    }
                }

                return nameFilter && openedFilter && addressFilter && hasResidentsFilter;
            };

            return Ok(accountRepository.Get(predicate));
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Account? account = accountRepository.FindById(id);
            if (account == null)
            {
                return BadRequest("Лицевой счёт с данным идентификатором не существует");
            }
            return Ok(account);
        }
        [HttpPost("{id}/resident")]
        public IActionResult AddResident(int id, Resident resident)
        {
            Account? account = accountRepository.FindById(id);
            if (account == null)
            {
                return BadRequest("Лицевой счёт с данным идентификатором не существует");
            }
            int rid = residentRepository.Create(resident);
            account.Residents.Append(residentRepository.FindById(rid)!);
            accountRepository.Update(account);

            return Accepted();
        }
        [HttpGet("{id}/resident")]
        public IActionResult GetResidents(int id)
        {
            Account? account = accountRepository.FindById(id);
            if (account == null)
            {
                return BadRequest("Лицевой счёт с данным идентификатором не существует");
            }
            return Ok(account.Residents.ToList());
        }
        [HttpDelete("{accountId}/resident/{residentId}")]
        public IActionResult DeleteResident(int accountId, int residentId)
        {
            Account? account = accountRepository.FindById(accountId);
            if (account == null)
            {
                return BadRequest("Лицевой счёт с данным идентификатором не существует");
            }
            Resident? resident = residentRepository.FindById(residentId);
            if (resident == null)
            {
                return BadRequest("Резидента с данным идентификатором не существует");
            }
            account.Residents.Remove(resident);
            accountRepository.Update(account);

            return Accepted();
        }
        [HttpGet("test")]
        public IActionResult Test()
        {
            Account? account = accountRepository.FindById(4);
            if (account == null)
            {
                return BadRequest("Лицевой счёт с данным идентификатором не существует");
            }
            Resident? resident = residentRepository.FindById(4);
            if (resident == null)
            {
                return BadRequest("Резидента с данным идентификатором не существует");
            }
            account.Residents.Add(resident);
            accountRepository.Update(account);
            return Accepted();
        }
    }
}
