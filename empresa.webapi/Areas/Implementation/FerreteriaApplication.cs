﻿using empresa.webapi.Areas.Interface;
using empresa.webapi.Configurations;
using empresa.webapi.Dto.Ferreteria;
using System.Data;

namespace empresa.webapi.Areas.Implementation
{
    public class FerreteriaApplication : IFerreteriaApplication
    {
        public async Task<OperationResult<List<ListaFerreteriaRespuestaDto>>> RegistrarPersona(string nombre,string apePaterno, string apeMaterno, string correo, int codigoPersona)
        {
            var resultado = new OperationResult<List<ListaFerreteriaRespuestaDto>> { isValid = false, exceptions = new List<OperationException>() };
            try
            {
                var ds = await new ProcedureGeneral().Procedure(new ProcedureRequestDto()
                {
                    Procedimiento = "dbo.ProcPersona",
                    Parametro = $"{nombre}|{apePaterno}|{apeMaterno}|{correo}|{codigoPersona}",
                    Indice = 20,
                    Database = "BDAdrian"
                });

                var listaMedidaTipo = (from x in ds.Tables[0].AsEnumerable() select x);

                var response = new List<ListaFerreteriaRespuestaDto>();

                foreach (var medidaTipo in listaMedidaTipo)
                {
                    response.Add(new ListaFerreteriaRespuestaDto()
                    {
                        CodResultado = medidaTipo.Field<int?>("CodResultado") ?? 0,
                        DesResultado = medidaTipo.Field<string?>("DesResultado") ?? "",
                    });
                }

                resultado.isValid = true;
                resultado.content = response;

                Console.WriteLine(DateTime.Now + ": " + resultado);

                return resultado;
            }
            catch (Exception e)
            {
                Console.WriteLine(DateTime.Now + ": " + e);
                throw new Exception(e.Message);
            }
        }
        public async Task<OperationResult<List<ListaFerreteriaRespuestaDto>>> RegistrarProducto(string NomProducto, string AbrevProducto, string DescripcionProducto, string CodigoProducto, int CodSubCategoria, int CantidadMinima, int CantidadMaxima, double PrecioCompra, double PrecioVenta, int CodMonedaCompra, int CodMonedaVenta, int CodUsuarioCreacion)
        {
            var resultado = new OperationResult<List<ListaFerreteriaRespuestaDto>> { isValid = false, exceptions = new List<OperationException>() };
            try
            {
                var ds = await new ProcedureGeneral().Procedure(new ProcedureRequestDto()
                {
                    Procedimiento = "dbo.ProcProducto",
                    Parametro = $"{NomProducto}|{AbrevProducto}|{DescripcionProducto}|{CodigoProducto}|{CodSubCategoria}|{CantidadMinima}|{CantidadMaxima}|{PrecioCompra}|{PrecioVenta}|{CodMonedaCompra}|{CodMonedaVenta}|{CodUsuarioCreacion}",
                    Indice = 20,
                    Database = "BDAdrian"
                });

                var listaMedidaTipo = (from x in ds.Tables[0].AsEnumerable() select x);

                var response = new List<ListaFerreteriaRespuestaDto>();

                foreach (var medidaTipo in listaMedidaTipo)
                {
                    response.Add(new ListaFerreteriaRespuestaDto()
                    {
                        CodResultado = medidaTipo.Field<int?>("CodResultado") ?? 0,
                        DesResultado = medidaTipo.Field<string?>("DesResultado") ?? "",
                    });
                }

                resultado.isValid = true;
                resultado.content = response;

                Console.WriteLine(DateTime.Now + ": " + resultado);

                return resultado;
            }
            catch (Exception e)
            {
                Console.WriteLine(DateTime.Now + ": " + e);
                throw new Exception(e.Message);
            }
        }
        public async Task<OperationResult<List<ListaProductosDto>>> ListarProductos()
        {
            var resultado = new OperationResult<List<ListaProductosDto>> { isValid = false, exceptions = new List<OperationException>() };
            try
            {
                var ds = await new ProcedureGeneral().Procedure(new ProcedureRequestDto()
                {
                    Procedimiento = "dbo.ProcPersona",
                    Parametro = "",
                    Indice = 10,
                    Database = "BDAdrian"
                });

                var listaMedidaTipo = (from x in ds.Tables[0].AsEnumerable() select x);

                var response = new List<ListaProductosDto>();

                foreach (var medidaTipo in listaMedidaTipo)
                {
                    response.Add(new ListaProductosDto()
                    {
                        CodProducto = medidaTipo.Field<int?>("CodProducto") ?? 0,
                        NomProducto = medidaTipo.Field<string?>("NomProducto") ?? "",
                        CantidadActual = medidaTipo.Field<int?>("CantidadActual") ?? 0,
                        CantidadMinima = medidaTipo.Field<int?>("CantidadMinima") ?? 0,
                        CantidadMaxima = medidaTipo.Field<int?>("CantidadMaxima") ?? 0,
                        PrecioCompra = medidaTipo.Field<double?>("PrecioCompra") ?? 0,
                        PrecioVenta = medidaTipo.Field<double?>("PrecioVenta") ?? 0,
                        CodMonedaCompra = medidaTipo.Field<int?>("CodMonedaCompra") ?? 0,
                        CodMonedaVenta = medidaTipo.Field<int?>("CodMonedaVenta") ?? 0,
                    });
                }

                resultado.isValid = true;
                resultado.content = response;

                Console.WriteLine(DateTime.Now + ": " + resultado);

                return resultado;
            }
            catch (Exception e)
            {
                Console.WriteLine(DateTime.Now + ": " + e);
                throw new Exception(e.Message);
            }
        }

    }
}