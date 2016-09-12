using SpaUserControl.Api.Models.Account;
using SpaUserControl.Domain.Contracts.Services;
using SpaUserControl.Resource.Resources;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SpaUserControl.Api.Controllers
{
    [RoutePrefix="api/account"]
    public class AccountController : ApiController
    {
        private IUserService  service;

        public AcountController (IUserService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("")]
        public Task<HttpResponseMessage> Post(RegisterUserModel model)
        {
            var response = new HttpResponseMessage();

            try
            {
                service.Register(model.Name, model.Email, model.Password, model.ConfirmPassword);
                response = Request.CreateResponse(HttpStatusCode.OK, new { name = model.Name, email = model.Email });
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [Authorize]
        [HttpPut]
        [Route("")]
        public Task<HttpResponseMessage> Put(ChangeInformationModel model)
        {
            var response = new HttpResponseMessage();

            try
            {
                service.ChangeInformation(User.Identity.Name, model.Name);
                response = Request.CreateResponse(HttpStatusCode.OK, new { name = model.Name });
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [Authorize]
        [HttpPost]
        [Route("changepassword")]
        public Task<HttpResponseMessage> Post(ChangePasswordModel model)
        {
            var response = new HttpResponseMessage();

            try
            {
                service.ChangePassword(User.Identity.Name, model.Password, model.NewPassword, model.ConfirmNewPassword);
                response = Request.CreateResponse(HttpStatusCode.OK, Messages.PasswordSuccessfulyChanges);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpPost]
        [Route("resetpassword")]
        public Task<HttpResponseMessage> Post(ResetPasswordModel model)
        {
            var response = new HttpResponseMessage();

            try
            {
                var password = service.ResetPassword(model.Email);
                response = Request.CreateResponse(HttpStatusCode.OK, String.Format(Messages.ResetPasswordEmailBody, password));
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        protected override void Dispose(bool disposing)
        {
            service.Dispose();
        }
    }
}