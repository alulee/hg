using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Core.Domain.Security;
using HGenealogy.Domain;

namespace HGenealogy.Services
{
    /// <summary>
    /// HGPedigree service
    /// </summary>
    public partial class HGPedigreeMetaService : IHGPedigreeMetaService
    {
        private readonly IRepository<HGPedigreeMeta> _hGPedigreeMetaRepository;

        public HGPedigreeMetaService(
            IRepository<HGPedigreeMeta> hGPedigreeMetaRepository)
        {
            this._hGPedigreeMetaRepository = hGPedigreeMetaRepository;
        }


        public virtual List<HGPedigreeMeta> GetAllHGPedigreeMeta(
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var query = _hGPedigreeMetaRepository.Table;
            //if (!showHidden)
            //    query = query.Where(c => c.Published);
            //if (!String.IsNullOrWhiteSpace(hgPedigreeName))
            //    query = query.Where(c => c.Name.Contains(hgPedigreeName));
            //query = query.Where(c => !c.Deleted);
            //query = query.OrderBy(c => c.DisplayOrder);

            //if (!showHidden)
            //{
            //    //only distinct categories (group by ID)
            //    query = from c in query
            //            group c by c.Id
            //                into cGroup
            //                orderby cGroup.Key
            //                select cGroup.FirstOrDefault();
            //    query = query.OrderBy(c => c.DisplayOrder);
            //}

            var unsortedHGPedigrees = query.ToList();

            //sort hgPedigrees
            //var sortedHGPedigrees = unsortedHGPedigrees.SortHGPedigreesForTree();
            return query.ToList();
            //paging
            //return  query.ToList();
        }

        public HGPedigreeMeta GetHGPedigreeMetaById(int id)
        {
            var hGPedigreeMeta = _hGPedigreeMetaRepository.Table
                                                        .Where(x => x.Id == id)
                                                        .FirstOrDefault();

            return hGPedigreeMeta;
        }

        public virtual void InsertHGPedigreeMeta(HGPedigreeMeta hgPedigreeMeta)
        {
            if (hgPedigreeMeta == null)
                throw new ArgumentNullException("hgPedigreeMeta");

            _hGPedigreeMetaRepository.Insert(hgPedigreeMeta);

        }



        public virtual void UpdateHGPedigreeMeta(HGPedigreeMeta hgPedigreeMeta)
        {
            if (hgPedigreeMeta == null)
                throw new ArgumentNullException("hgPedigreeMeta");

            _hGPedigreeMetaRepository.Update(hgPedigreeMeta);
            
        }

        public virtual void DeleteHGPedigreeMeta(HGPedigreeMeta hgPedigreeMeta)
        {
            if (hgPedigreeMeta == null)
                throw new ArgumentNullException("hgPedigreeMeta");

            _hGPedigreeMetaRepository.Delete(hgPedigreeMeta);

        }
    }
}
