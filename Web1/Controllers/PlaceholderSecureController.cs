﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Db3.Interfaces.RLS;
using Db3.Model.Placeholder;
using Db3.RLS;
using Db3.SecureRepository.PlaceHolder;
using Microsoft.AspNetCore.Mvc;
using Web1.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web1.Controllers
{
    [Route("api/[controller]")]
    public class PlaceholderSecureController : Controller
    {
        private readonly IPlaceholderSecureRepository PlaceholderSecureRepository;
        private readonly IPlaceholderACLRepository PlaceholderACLRepository;
        private readonly CurrentUserProvider CurrentUserProvider;
        private readonly IMapper Mapper;
        public PlaceholderSecureController(IPlaceholderSecureRepository placeholderSecureRepository, IPlaceholderACLRepository placeholderACLRepository,
            CurrentUserProvider currentUserProvider, IMapper mapper)
        {
            PlaceholderSecureRepository = placeholderSecureRepository;
            PlaceholderACLRepository = placeholderACLRepository;
            CurrentUserProvider = currentUserProvider;
            Mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<PlaceHolderViewModel> Get(int skip = 0, int take = 100, string filter = "")
        {
            var query = PlaceholderSecureRepository.GetAll().OrderBy(x => x.Name).AsQueryable();
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(x => x.Name.Contains(filter));
            }
            query = query.Skip(skip).Take(take);

            return Mapper.Map<List<PlaceHolderViewModel>>(query);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public PlaceHolderViewModel Get(int id)
        {
            var entity = PlaceholderSecureRepository.GetById(id);
            return Mapper.Map<PlaceHolderViewModel>(entity);
        }

        // POST api/values
        [HttpPost]
        public long Post([FromBody]PlaceHolderViewModel value)
        {
            if (ModelState.IsValid)
            {
                var data = Mapper.Map<PlaceholderEntity>(value);
                PlaceholderSecureRepository.Add(data);
                PlaceholderSecureRepository.SaveChanges();

                // Giving permissions
                PlaceholderACLRepository.Add(new PlaceholderEntityACL
                {
                    EntityID = data.Id,
                    Permission = PermissionEnum.Read | PermissionEnum.Update | PermissionEnum.Delete,
                    SecurityObjectID = CurrentUserProvider.Identity.Id
                });

                PlaceholderACLRepository.Add(new PlaceholderEntityACL
                {
                    EntityID = data.Id,
                    Permission = PermissionEnum.Full,
                    SecurityObjectID = Db3.DefaultData.AdminGroup.Id
                });
                PlaceholderSecureRepository.SaveChanges();
                return data.Id;
            }

            return -1;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PlaceHolderViewModel value)
        {
            if (ModelState.IsValid)
            {
                var data = Mapper.Map<PlaceholderEntity>(value);
                PlaceholderSecureRepository.Update(data);
                PlaceholderSecureRepository.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entry = PlaceholderSecureRepository.GetById(id);
            if (entry != null)
            {
                PlaceholderSecureRepository.Delete(entry);
                PlaceholderSecureRepository.SaveChanges();
            } else
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
