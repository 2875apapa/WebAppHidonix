using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApp.EfCore;

namespace WebApp.Models
{
    public class DbHelper
    {
        private DataContext _context;
        public DbHelper(DataContext context)
        {
            _context = context;
        }
        //GET ALL
        //Settore
        public List<SettoreModel> GetSettori()
        {
            List<SettoreModel> response = new List<SettoreModel>();
            var dataList = _context.Settori.ToList();
            dataList.ForEach(row => response.Add(new SettoreModel()
            {
                Id = row.Id,
                Nome = row.Nome,
                Tipologia = row.Tipologia,
                Descrizione = row.Descrizione,
                NumStand = row.NumStand,
                Stato = row.Stato,
                Tags = row.Tags
            }));
            return response;
        }

        //Padiglione
        public List<PadiglioneModel> GetPadiglione()
        {
            List<PadiglioneModel> response = new List<PadiglioneModel>();
            var dataList = _context.Padiglioni.ToList();
            dataList.ForEach(row => response.Add(new PadiglioneModel()
            {
                Id = row.Id,
                Nome = row.Nome,
                Poweredby = row.Poweredby,
                Descrizione = row.Descrizione,
                Area = row.Area,
                Tags = row.Tags
            }));
            return response;
        }

        //Categoria
        public List<CategoriaModel> GetCategoria()
        {
            List<CategoriaModel> response = new List<CategoriaModel>();
            var dataList = _context.Categorie.ToList();
            dataList.ForEach(row => response.Add(new CategoriaModel()
            {
                Id = row.Id,
                Nome = row.Nome,
                Descrizione = row.Descrizione,
                Tags = row.Tags
            }));
            return response;
        }

        //Stand
        public List<StandModel> GetStand()
        {
            List<StandModel> response = new List<StandModel>();
            var dataList = _context.Stands.ToList();
            dataList.ForEach(row => 
            response.Add(new StandModel()
            {
                Id = row.Id,
                Nome = row.Nome,
                X_dim = row.X_dim,
                Y_dim = row.Y_dim,
                Descrizione = row.Descrizione,
                Padiglione = GetNomePadiglione(row.PadiglioneId),
                Settore = GetNomeSettore(row.SettoreId),
                Tags = row.Tags
            }));
            return response;
        }


        //GET BY ID
        //Settore
        public SettoreModel GetSettoreById(int id)
        {
            var row = _context.Settori.Where(s => s.Id.Equals(id)).FirstOrDefault();
            SettoreModel response = null;
            if (row != null)
            {
                response = new SettoreModel()
                {
                    Id = row.Id,
                    Nome = row.Nome,
                    Tipologia = row.Tipologia,
                    Descrizione = row.Descrizione,
                    NumStand = row.NumStand,
                    Stato = row.Stato,
                    Tags = row.Tags
                };
            }
            return response;
        }

        //Padiglione
        public PadiglioneModel GetPadiglioneById(int id)
        {
            var row = _context.Padiglioni.Where(s => s.Id.Equals(id)).FirstOrDefault();
            PadiglioneModel response = null;
            if (row != null)
            {
                response = new PadiglioneModel()
                {
                    Id = row.Id,
                    Nome = row.Nome,
                    Poweredby = row.Poweredby,
                    Descrizione = row.Descrizione,
                    Area = row.Area,
                    Tags = row.Tags
                };
            }
            return response;
        }


        //Categoria
        public CategoriaModel GetCategoriaById(int id)
        {
            var row = _context.Categorie.Where(c => c.Id.Equals(id)).FirstOrDefault();
            CategoriaModel response = null;
            if (row != null)
            {
                response = new CategoriaModel()
                {
                    Id = row.Id,
                    Nome = row.Nome,
                    Descrizione = row.Descrizione,
                    Tags = row.Tags
                };
            }
            return response;
        }


        //Stand
        public StandModel GetStandById(int id)
        {
            var row = _context.Stands.Where(s => s.Id.Equals(id)).FirstOrDefault();
            StandModel response = null;
            if (row != null)
            {
                response = new StandModel()
                {
                    Id = row.Id,
                    Nome = row.Nome,
                    X_dim = row.X_dim,
                    Y_dim = row.Y_dim,
                    Descrizione = row.Descrizione,
                    Padiglione = GetNomePadiglione(row.PadiglioneId),
                    Settore = GetNomeSettore(row.SettoreId),
                    Tags = row.Tags
                };
            }
            return response;
        }


        //POST e PUT
        //Settore
        public void SaveSettore (SettoreModel settoreModel)
        {
            Settore dbTable = new Settore();
            if(settoreModel.Id > 0)
            {
                dbTable = _context.Settori.Where(s => s.Id.Equals(settoreModel.Id)).FirstOrDefault();
                if(dbTable != null)
                {
                    //PUT
                    dbTable.Tipologia = settoreModel.Tipologia;
                    dbTable.Descrizione = settoreModel.Descrizione;
                    dbTable.Stato = settoreModel.Stato;
                    dbTable.Tags = settoreModel.Tags;
                }
            }
            else
            {
                //POST
                dbTable.Nome = settoreModel.Nome;
                dbTable.Tipologia = settoreModel.Tipologia;
                dbTable.Descrizione = settoreModel.Descrizione;
                dbTable.Stato = settoreModel.Stato;
                dbTable.NumStand = settoreModel.NumStand;
                dbTable.Tags = settoreModel.Tags;
                _context.Settori.Add(dbTable);
            }
            _context.SaveChanges();
        }


        //Padiglione
        public void SavePadiglione(PadiglioneModel padiglioneModel)
        {
            Padiglione dbTable = new Padiglione();
            if (padiglioneModel.Id > 0)
            {
                dbTable = _context.Padiglioni.Where(s => s.Id.Equals(padiglioneModel.Id)).FirstOrDefault();
                if (dbTable != null)
                {
                    //PUT
                    dbTable.Area = padiglioneModel.Area;
                    dbTable.Poweredby = padiglioneModel.Poweredby;
                    dbTable.Descrizione = padiglioneModel.Descrizione;
                    dbTable.Tags = padiglioneModel.Tags;
                }
            }
            else
            {
                //POST
                dbTable.Nome = padiglioneModel.Nome;
                dbTable.Area = padiglioneModel.Area;
                dbTable.Poweredby = padiglioneModel.Poweredby;
                dbTable.Descrizione = padiglioneModel.Descrizione;
                dbTable.Tags = padiglioneModel.Tags;
                _context.Padiglioni.Add(dbTable);
            }
            _context.SaveChanges();
        }


        //Categoria
        public void SaveCategoria(CategoriaModel categoriaModel)
        {
            Categoria dbTable = new Categoria();
            if (categoriaModel.Id > 0)
            {
                dbTable = _context.Categorie.Where(c => c.Id.Equals(categoriaModel.Id)).FirstOrDefault();
                if (dbTable != null)
                {
                    //PUT
                    dbTable.Descrizione = categoriaModel.Descrizione;
                    dbTable.Tags = categoriaModel.Tags;
                }
            }
            else
            {
                //POST
                dbTable.Nome = categoriaModel.Nome;
                dbTable.Descrizione = categoriaModel.Descrizione;
                dbTable.Tags = categoriaModel.Tags;
                _context.Categorie.Add(dbTable);
            }
            _context.SaveChanges();
        }


        //Stand
        public void SaveStand(StandModel standModel)
        {
            Stand dbTable = new Stand();
            if (standModel.Id > 0)
            {
                dbTable = _context.Stands.Where(s => s.Id.Equals(standModel.Id)).FirstOrDefault();
                if (dbTable != null)
                {
                    //PUT
                    dbTable.X_dim = standModel.X_dim;
                    dbTable.Y_dim = standModel.Y_dim;
                    dbTable.Descrizione = standModel.Descrizione;
                    dbTable.Tags = standModel.Tags;
                }
            }
            else
            {
                //POST
                dbTable.Nome = standModel.Nome;
                dbTable.X_dim = standModel.X_dim;
                dbTable.Y_dim = standModel.Y_dim;
                dbTable.Descrizione = standModel.Descrizione;
                dbTable.SettoreId = GetIdSettore(standModel.Settore);
                dbTable.PadiglioneId = GetIdPadiglione(standModel.Padiglione);
                dbTable.Tags = standModel.Tags;
                _context.Stands.Add(dbTable);

                Settore dbTableS = new Settore();
                int idSettore = GetIdSettore(standModel.Settore);
                if (idSettore > 0)
                {
                    dbTableS = _context.Settori.Where(s => s.Id.Equals(idSettore)).FirstOrDefault();
                    if (dbTableS != null)
                    {
                        dbTableS.NumStand = dbTableS.NumStand+1;
                    }
                }
            }
            _context.SaveChanges();
        }




        //DELETE
        //Settore
        public void DeleteSettore(int id)
        {
            var settore = _context.Settori.Where(s => s.Id.Equals(id)).FirstOrDefault();
            if(settore != null)
            {
                _context.Settori.Remove(settore);
                _context.SaveChanges();
            }
        }

        //Padiglione
        public void DeletePadiglione(int id)
        {
            var padiglione = _context.Padiglioni.Where(p => p.Id.Equals(id)).FirstOrDefault();
            if (padiglione != null)
            {
                _context.Padiglioni.Remove(padiglione);
                _context.SaveChanges();
            }
        }

        //Categoria
        public void DeleteCategoria(int id)
        {
            var categoria = _context.Categorie.Where(c => c.Id.Equals(id)).FirstOrDefault();
            if (categoria != null)
            {
                _context.Categorie.Remove(categoria);
                _context.SaveChanges();
            }
        }

        //Stand
        public void DeleteStand(int id)
        {
            var stand = _context.Stands.Where(s => s.Id.Equals(id)).FirstOrDefault();
            if (stand != null)
            {
                _context.Stands.Remove(stand);
                _context.SaveChanges();
            }
        }


        public string GetNomeSettore(int id)
        {
            var row = _context.Settori.Where(s => s.Id.Equals(id)).FirstOrDefault();
            string response = "";
            //SettoreModel response = null;
            if (row != null)
            {
                response = row.Nome;
            }
            return response;
        }

        public int GetIdSettore(string Nome)
        {
            var row = _context.Settori.Where(s => s.Nome.Equals(Nome)).FirstOrDefault();
            int response = 0;
            //SettoreModel response = null;
            if (row != null)
            {
                response = row.Id;
            }
            return response;
        }

        public string GetNomePadiglione(int id)
        {
            var row = _context.Padiglioni.Where(p => p.Id.Equals(id)).FirstOrDefault();
            string response = "";
            //SettoreModel response = null;
            if (row != null)
            {
                response = row.Nome;
            }
            return response;
        }

        public int GetIdPadiglione(string Nome)
        {
            var row = _context.Padiglioni.Where(p => p.Nome.Equals(Nome)).FirstOrDefault();
            int response = 0;
            //SettoreModel response = null;
            if (row != null)
            {
                response = row.Id;
            }
            return response;
        }



    }
}
