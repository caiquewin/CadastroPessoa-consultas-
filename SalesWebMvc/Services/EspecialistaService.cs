﻿using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class EspecialistaService
    {
        private readonly SalesWebMvcContext _contex;
        public EspecialistaService(SalesWebMvcContext context)
        {
            _contex = context;
        }
        public List<Especialista> FindAll()//operação sincrona 
        {
            return _contex.Especialista.ToList();
        }
        public void Insert(Especialista obj)//adiciona um novo Especialista do Create.cshtml dela envia pra esse metodo e vai pro BD
        {
            _contex.Add(obj);
            _contex.SaveChanges();
        }
            
    }
}
