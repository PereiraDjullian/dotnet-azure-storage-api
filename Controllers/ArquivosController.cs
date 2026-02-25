using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace blobAPI.Controllers
{   

    [ApiController]
    [Route("[controller]")] 
    public class ArquivosController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly string _containerName; 

        public ArquivosController(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("BlobConnectionString");
            _containerName = configuration.GetValue<string>("BlobContainerName");
        }
        
        [HttpPost("upload")]
        public IActionResult UploadArquivo(IFormFile arquivo)
        {
            BlobContainerClient container = new(_connectionString, _containerName); 
            BlobClient blob = container.GetBlobClient(arquivo.FileName);
            
            using var data = arquivo.OpenReadStream();
            blob.Upload(data, new BlobUploadOptions
            {
                HttpHeaders = new BlobHttpHeaders
                {
                    ContentType = arquivo.ContentType
                }
            });
            return Ok(blob.Uri.ToString());
        }

        [HttpGet("download/{nome}")]
        public IActionResult DownloadArquivo(string nome)
        {
            BlobContainerClient container = new(_connectionString, _containerName); 
            BlobClient blob = container.GetBlobClient(nome);
            
            if (!blob.Exists())
                return BadRequest();

            var retorno = blob.DownloadContent();
            return File(retorno.Value.Content.ToArray(),retorno.Value.Details.ContentType,blob.Name);
        }

        [HttpDelete("delete/{nome}")]
        public IActionResult DeleteArquivo(string nome)
        {
            BlobContainerClient container = new(_connectionString, _containerName); 
            BlobClient blob = container.GetBlobClient(nome);
            
            if (!blob.Exists())
                return BadRequest();

            blob.DeleteIfExists();
            return Ok();
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            List<BlobDto> blobDtos = new List<BlobDto>();
            BlobContainerClient container = new(_connectionString, _containerName); 

           foreach (var blob in container.GetBlobs())
           {
            
               blobDtos.Add(new BlobDto
               {
                   Nome = blob.Name,
                   Tipo = blob.Properties.ContentType,
                   Uri = container.Uri.AbsoluteUri + "/" + blob.Name
               });
           }
            return Ok(blobDtos);
            
        }
    }
}