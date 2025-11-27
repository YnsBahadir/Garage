using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void TAdd(AppUser t)
        {
            _appUserDal.Insert(t);
        }

        public void TDelete(AppUser t)
        {
            _appUserDal.Delete(t);
        }

        public AppUser GetById(int id)
        {
            return _appUserDal.GetByID(id);
        }

        public List<AppUser> GetList()
        {
            return _appUserDal.GetListAll();
        }

        public void TUpdate(AppUser t)
        {
            _appUserDal.Update(t);
        }
    }
}