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
    public class OfferManager : IOfferService
    {
        IOfferDal _offerDal;

        public OfferManager(IOfferDal offerDal)
        {
            _offerDal = offerDal;
        }

        public void TAdd(Offer t)
        {
            _offerDal.Insert(t);
        }

        public void TDelete(Offer t)
        {
            _offerDal.Delete(t);
        }

        public Offer GetById(int id)
        {
            return _offerDal.GetByID(id);
        }

        public List<Offer> GetList()
        {
            return _offerDal.GetListAll();
        }

        public void TUpdate(Offer t)
        {
            _offerDal.Update(t);
        }
    }
}