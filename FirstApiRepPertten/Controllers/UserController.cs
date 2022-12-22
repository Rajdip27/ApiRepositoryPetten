using CoreApiResponse;
using FirstApiRepPertten.ApplicationDbCon;
using FirstApiRepPertten.Interface.Manager;
using FirstApiRepPertten.Manager;
using FirstApiRepPertten.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FirstApiRepPertten.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {
        ApplicationDbContext _dbContext;
        IUserManager _userManager;
        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _userManager = new UserManager(_dbContext);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var Result=_userManager.GetAll().ToList();
                if (Result == null)
                {
                    return CustomResult("Data Not Found",HttpStatusCode.NotFound);
                }
                return CustomResult("Data Loaded Successfull",Result);

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var Result = _userManager.GetById(id);
                if (Result == null)
                {
                    return CustomResult("Data Not Found", HttpStatusCode.BadRequest);
                }
                return CustomResult("Data Found Successfulluy", Result);

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);

            }
        }
        [HttpGet]
        public IActionResult GetAllDesc()
        {
            try
            {
                var Result = _userManager.GetAll().OrderByDescending(x => x.Id).ToList();
                return CustomResult("Data Loaded Successfull", Result);

            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        [HttpGet]
        public IActionResult SarchAdress(string address)
        {
            try
            {
                var Result=_userManager.SarchAddress(address);
                return CustomResult("Sarching Result.", Result);

            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        [HttpGet]
        public IActionResult UserSarch( string text)
        {
            try
            {
                var Result=_userManager.Sarch(text);
                return CustomResult("Data Sarch Sucessfull.", Result);

            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);

            }
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                bool IsSave=_userManager.Add(user);
                if (IsSave)
                {
                    return CustomResult("User Has Been Create",user);
                }
                return CustomResult("User Save Failed", HttpStatusCode.BadRequest);

            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);


            }

        }
        
        [HttpPut]
        public IActionResult Edit(User user)
        {
            try
            {
                if (user.Id == 0)
                {
                    return CustomResult("Id is Messing",HttpStatusCode.NotFound);

                }
                bool IsUpdate=_userManager.Update(user);
                if (IsUpdate)
                {
                    return CustomResult("User Update Successfull.", user);
                }
                return CustomResult("User Update Failed", HttpStatusCode.BadRequest);

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);

            }
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Result = _userManager.GetById(id);
                if (Result == null)
                {
                    return CustomResult("Data Not Found.", HttpStatusCode.NotFound);
                }
                bool IsDelete=_userManager.Delete(Result);
                if (IsDelete)
                {
                    return CustomResult("User has beeen Delete.", Result);
                }
                return CustomResult("User Deleted Failed.", Result);

            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);

            }
        }
        [HttpGet]
        public IActionResult Pagaing(int page = 1)
        {
            try
            { 
                var Paging = _userManager.Pagging(page,5);
                return CustomResult("Page No:"+page, Paging);

            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
